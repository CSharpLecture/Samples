using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Tag4
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Create a new task
            Task t = new Task(SomeWork);
            //Specify the continuation (this yields a new task, but we are not interested in that)
            t.ContinueWith(Continuation);
            //Start the task (SomeWork)
            t.Start();

            //Let's create two tasks
            Task task1 = new Task(WaitSomeOne);
            Task task2 = new Task(WaitSomeTwo);

            //Start them (make them "hot")
            task1.Start();
            task2.Start();

            //We create a third task (we are not interested in that task), which will be completed
            //once task1 AND task2 are finished. After that completion, Continuation should be called again
            Task.WhenAll(task1, task2).ContinueWith(Continuation);

            //We can also use tasks to return values of a computation, like the computation method.
            var sim = new Task<double>(Simulation);
            //However, once we run the task, we have no way to access the result
            sim.Start();
            //One way is to wait for it, however, that is blocking the UI, hence no good idea
            //sim.Wait();

            //This is the best way, we create a continuation task, that will run in the UI thread
            sim.ContinueWith(task =>
            {
                //use task.Result here!
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        static void SomeWork()
        {
            Debug.WriteLine("Entering sleep state (1).");
            //A little bit of slow to simulate work
            Thread.Sleep(2000);
            //Uncomment the following line to see the task crashing (program will continue)
            //throw new Exception();
            Debug.WriteLine("Finished the first task (2).");
        }

        static void Continuation(Task someTask)
        {
            //Did the previous task crash?
            if (someTask.IsFaulted)
            {
                Debug.WriteLine("An exception occurred in the previous task!");
                return;
            }

            Debug.WriteLine("Entering sleep state (3).");
            Thread.Sleep(5000);
            Debug.WriteLine("All finished!");
        }

        static void WaitSomeOne()
        {
            Thread.Sleep(3000);
            Debug.WriteLine("WaitSomeOne is ready.");
        }

        static void WaitSomeTwo()
        {
            Thread.Sleep(2000);
            Debug.WriteLine("WaitSomeTwo is ready.");
        }

        static double Simulation()
        {
            Random r = new Random();
            double sum = 0.0;

            for (int i = 0; i < 10000000; i++)
            {
                if (r.NextDouble() < 0.33)
                    sum += Math.Exp(-sum) + r.NextDouble();
                else
                    sum -= Math.Exp(-sum) + r.NextDouble();
            }

            return sum;
        }
    }
}
