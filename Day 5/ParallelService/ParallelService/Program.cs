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

            //for (int i = 1; i <= 11; i++)
            //{
                try
                {
                //service.Add(new User(i, "Andrew", "Zhidenko", "aa", "ss", DateTime.Now, DateTime.Now));
                //var user = service.Get(10);
                //var user2 = service.Get(12);

                ThreadStart get = () =>
                {
                    for (int j = 1; j < 10; j++)
                    {
                        var user = service.Get(j);
                        Thread.Sleep(100);
                        Console.WriteLine("User id  - {0}. Thread id - {1}.", user.Id, Thread.CurrentThread.ManagedThreadId);
                    }
                };

                var threadGet = new Thread[10];

                for (var j = 0; j < 10; j++)
                {
                    threadGet[j] = new Thread(get);
                    threadGet[j].Start();
                }

                //ThreadStart set1 = () =>
                //{
                //    for(var j = 18; j <= 19; j++)
                //    {
                //        service.Add(new User(j, "Andrew", "Zhidenko"+j.ToString(), "aa", "ss", DateTime.Now, DateTime.Now));
                //    } 
                //};

                //ThreadStart set2 = () =>
                //{
                //    for (var j = 20; j <= 21; j++)
                //    {
                //        service.Add(new User(j, "Andrew", "Zhidenko" + j.ToString(), "aa", "ss", DateTime.Now, DateTime.Now));
                //    }
                //};

                //var threadWrite = new Thread(set1);
                //var threadWrite2 = new Thread(set2);
                //threadWrite.Start();
                //threadWrite2.Start();
            }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            //} 

            Console.ReadKey();
        }
    }
}
