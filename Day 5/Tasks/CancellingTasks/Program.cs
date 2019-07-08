using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancellingTasks
{
    class Program
    {
        private const int TasksAmount = 20;
        public const string Token = "Thread";

        static void Main(string[] args)
        {
            string[] urls =
            {
                "http://www.learnasync.net/",
                "http://www.albahari.com/threading/",
                "http://jonskeet.uk/csharp/threads/",
                // TODO Uncomment after completing the task.
                "http://asd234efwdw23reefsfdsfds.com",
                "https://codewala.net/2015/07/29/concurrency-vs-multi-threading-vs-asynchronous-programming-explained/",
            };

            var cts = new CancellationTokenSource();
            var ct = cts.Token;

            // TODO Create a new task with cancellation token and queue it.
            var task = Task.Run(() => {
                Console.WriteLine("Task is started.");

                var webClient = new WebClient();

                var list = new List<Tuple<string, int>>();

                foreach (var url in urls)
                {
                        Console.WriteLine("Downloading {0}", url);

                        var bytes = webClient.DownloadData(url);

                        // TODO Cancel the task.
                        if (ct.IsCancellationRequested)
                        {
                            ct.ThrowIfCancellationRequested();
                        }

                        var resultString = Encoding.UTF8.GetString(bytes);

                        // TODO Cancel the task.
                        if (ct.IsCancellationRequested)
                        {
                            ct.ThrowIfCancellationRequested();
                        }

                        var occurences = IndexesOf(resultString, Token).Length;
                        list.Add(Tuple.Create(url, occurences));

                        // TODO Cancel the task.
                        if (ct.IsCancellationRequested)
                        {
                            ct.ThrowIfCancellationRequested();
                        }

                        Task.Delay(100);
                }

                Console.WriteLine("Task is completed.");

                // TODO Set task result in list.ToArray().
                return list.ToArray();
            }, cts.Token);

            task.ContinueWith(t => {
                string exceptionMessage = string.Empty;

                // TODO Set exceptionMessage in inner exception's message.
                exceptionMessage = t.Exception.Message;

                Console.WriteLine("Task failed with an exception: {0}", exceptionMessage);
            }, TaskContinuationOptions.OnlyOnFaulted);

            task.ContinueWith(t => {
                Console.WriteLine("Task completed successfully.");

                Tuple<string, int>[] results = null;

                // TODO Set results in task result.
                results = t.Result;

                foreach (var tuple in results)
                {
                    Console.WriteLine("{0} - {1}", tuple.Item1, tuple.Item2);
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            task.ContinueWith(t => {
                Console.WriteLine("Task was cancelled.");
            }, TaskContinuationOptions.OnlyOnCanceled);

            Console.WriteLine("Press any key to stop the task.");
            Console.ReadKey();

            TaskStatus taskStatus = TaskStatus.Created;

            // TODO Set the current task status.
            taskStatus = task.Status;

            Console.WriteLine("Task status is {0}.", taskStatus);

            cts.Cancel();

            Console.WriteLine("Press any key to get task status.");
            Console.ReadKey();

            // TODO Set the current task status.
            taskStatus = task.Status;

            Console.WriteLine("Task status is {0}.", taskStatus);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static int[] IndexesOf(string str, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("value is empty", "value");
            }

            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                {
                    return indexes.ToArray();
                }

                indexes.Add(index);
            }
        }
    }
}
