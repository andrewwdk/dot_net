using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelService
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = DoWorkAsync();
            task.Wait();
            //await DoWorkAsync();
            Console.WriteLine("Done");

            Console.ReadKey();
        }

        public static async Task DoWorkAsync()
        {
            UserService service = new UserService();
            var ids = new int[] { 1, 2, 3, 4, 4 };

            await Task.Run(async () =>
            {
                foreach (int id in ids)
                {
                    try
                    {
                        Console.WriteLine("Start adding");
                        await service.AddAsync(new User(id, "Andrew" + id.ToString(), "ss", "s", "b", DateTime.Now, DateTime.Now));
                        Console.WriteLine("Done");
                        User user = await service.GetAsync(id);
                        if (user != null)
                        {
                            Console.WriteLine("{0} {1}", user.Id, user.FirstName);
                        }
                        else
                        {
                            Console.WriteLine("No user with such id");
                        }
                    }
                    catch (Exception e)
                    {
                        if(e.InnerException != null)
                        {
                            Console.WriteLine(e.InnerException.Message);
                        }
                        else
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                    }
                }
            });
        }

       
    }
}
