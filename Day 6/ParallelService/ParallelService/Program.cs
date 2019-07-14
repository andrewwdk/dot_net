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
            UserService service = new UserService();

            try
            {
                var tasks = new Task[5];
                var ids = new int[] { 1, 2, 3, 4, 5 };

                foreach(int id in ids)
                {
                    tasks[id-1] = Task.Run(() =>
                    {
                        //service.Add(new User(id, "Andrew" + id.ToString(), "ss", "s", "b", DateTime.Now, DateTime.Now));

                        User user = service.Get(id).Result;
                        Console.WriteLine("{0} {1}", user.Id, user.FirstName);
                    });
                }

                Task.WaitAll(tasks);
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

       
    }
}
