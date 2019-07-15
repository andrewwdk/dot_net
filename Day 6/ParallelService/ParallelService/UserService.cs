using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelService
{
    public class UserService : IUserService
    {
        const int blockSize = 144;
        const string path = @"D:\file.dat";
        private List<Tuple<int, long>> list = new List<Tuple<int, long>>();
        private object locker = new object();
        //private ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public UserService()
        {
           ReadOrCreateStorage();
        }

        public async Task AddAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException();

            lock (locker)
            {
                if (UserExists(user.Id))
                    throw new UserExistsException("User with such id has already existed!");
            }

            await semaphore.WaitAsync();
            try
            {
                using (var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    using (var bw = new BinaryWriter(fileStream))
                    {
                        list.Add(new Tuple<int, long>(user.Id, bw.BaseStream.Length));

                        bw.Write(user.Id);
                        bw.Write(user.FirstName);
                        bw.Write(user.LastName);
                        bw.Write(user.Email);
                        bw.Write(user.Login);
                        bw.Write(user.BirthDate.ToBinary());
                        bw.Write(user.LastEntry.ToBinary());
                    }
                }
            }
            finally
            {
                semaphore.Release();
            }
        }

        public async Task<User> GetAsync(int userId)
        {
            long offset;
            User user;

            lock (locker)
            {
                offset = GetOffset(userId);
            }

            if (offset == -1)
                return null;

            await semaphore.WaitAsync();
            try
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    fs.Position = offset;
                    using (var br = new BinaryReader(fs))
                    {
                        user = new User(br.ReadInt32(), br.ReadString(), br.ReadString(), br.ReadString(), br.ReadString(),
                            DateTime.FromBinary(br.ReadInt64()), DateTime.FromBinary(br.ReadInt64()));
                    }
                }
            }
            finally
            {
                semaphore.Release();
            }

            return user;
        }

        private void ReadOrCreateStorage()
        {

            if (!File.Exists(path))
            {
                using (var fs = File.Create(path)) { }
            }
            else
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    fs.Position = 0;
                    using (var br = new BinaryReader(fs))
                    {
                        int offsetInsex = 0;

                        while (br.BaseStream.Position != br.BaseStream.Length)
                        {
                            var id = br.ReadInt32();
                            br.ReadBytes(blockSize - sizeof(Int32));
                            list.Add(new Tuple<int, long>(id, offsetInsex * blockSize));
                            offsetInsex++;
                        }
                    }
                }
            }
        }

        private bool UserExists(int id)
        {
            foreach(Tuple<int, long> user in list)
            {
                if (user.Item1 == id)
                    return true;
            }

            return false;
        }

        private long GetOffset(int id)
        {
            foreach (Tuple<int, long> user in list)
            {
                if (user.Item1 == id)
                    return user.Item2;
            }

            return -1;
        }
    }
}
