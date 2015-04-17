using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CancelThreadSample
{
    class Program
    {
        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        static Action _blockingWork = () =>
        {

            int i = 0;
            while (true && i++ < 10)
            {
                Console.WriteLine("Do job " + i);
                Thread.Sleep(2000);

                if (i == 3)
                {
                    throw new ArgumentException("Exception !!!");
                }
            }
        };

        static private void RunTask()
        {
            var innerTask = new Task(_blockingWork,
                                     cancellationTokenSource.Token,
                                     TaskCreationOptions.LongRunning);
            innerTask.Start();

            innerTask.Wait(cancellationTokenSource.Token);
            Console.WriteLine("End");
        }

        static void Main(string[] args)
        {
            var outerTask = new Task(RunTask, cancellationTokenSource.Token);
            outerTask.ContinueWith((e) =>
                {
                    foreach (var item in e.Exception.InnerExceptions)
                    {
                        ArgumentException exp = item.InnerException as ArgumentException;
                        Console.WriteLine(e.Exception.ToString());
                    }
                }, TaskContinuationOptions.OnlyOnFaulted);

            outerTask.ContinueWith((e) =>
            {
                Console.WriteLine("Canceled!");
            }, TaskContinuationOptions.OnlyOnCanceled);
            

            outerTask.ContinueWith<string>((e)=>
                {
                    Console.WriteLine("Done!");
                    return "Done";
                },TaskContinuationOptions.OnlyOnRanToCompletion);

            outerTask.Start();

            Thread.Sleep(1500);
            //buttonclick();

            Console.ReadLine();
        }

        static void buttonclick()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
