using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PartA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App start!");

            IEnumerable<string> m_oEnum = new List<string>() { "1", "2", "3" };

            AsyncWorker.LoopAsync(m_oEnum);

            Console.WriteLine("App completed!");

            Console.Read();

        }

        public class AsyncWorker
        {
            //Asynchronous method
            public static Task AsyncWork(string Item)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Item: {Item}");
                return Task.CompletedTask;
            }

            //Iteration over collection and await AsyncWork method
            public static async Task LoopAsync(IEnumerable<string> loopArray)
            {
                List<Task> listOfWork = new List<Task>();

                foreach (var thing in loopArray)
                {

                    listOfWork.Add(AsyncWork(thing));
                }

                await Task.WhenAll(listOfWork);
            }
        }
    }
}
