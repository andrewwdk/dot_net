using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelService
{
    class Program
    {
        static void Main(string[] args)
        {
            UserService service = new UserService();

            for (int i = 1; i <= 11; i++)
            {
                try
                {
                    // service.Add(new User(i, "Andrew", "Zhidenko", "aa", "ss", DateTime.Now, DateTime.Now));
                    var user = service.Get(10);
                    var user2 = service.Get(12);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } 

            Console.ReadKey();
        }
    }
}
