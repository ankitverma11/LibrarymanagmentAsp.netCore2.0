using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LandaexpressionActionFuncpredicate
{
    class AsyncAndAwait
    {
        //Async and Await are are the markers which mark code position from where control should resume after the task (thred) complete.
        static void Main(string[] args)
        {
            Method();
            Console.WriteLine("main thread");
            Console.ReadLine();

        }

        public static async void Method()
        {
            await Task.Run(new Action(LongTask)); // main thred did not wait and long task execute after 20 second
            Console.WriteLine("new Thread"); // wait untill the long task finished for 20 second
        }

        public static void LongTask()
        {
            Thread.Sleep(20000);
        }
    }
}
