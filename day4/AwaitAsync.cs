using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Tag4
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.RunTask();
        }

        //We need async to enable await, additionally it wraps the contents in a Task
        public async Task RunTask()
        {
            Console.WriteLine("Let's start some task.");
            //Realize that the type of result is DOUBLE and not a Task of double
            double result = await SimulationAsync();
            //This is the implementation of the continuation - no problem
            Console.WriteLine("More UI operations are possible here.");

            //Perform a permanent (and still responsive) loop in a new task
            await WriteSomething();
        }

        async Task WriteSomething()
        {
            //infinite loop
            for(;;)
            {
                //Write hi there on the console
                Console.WriteLine("Hi there!");
                //Wait a second then perform the next iteration
                await Task.Delay(1000);
            }
        }

        Task<double> SimulationAsync()
        {
            //Create a new task with a lambda expression
            var task = new Task<double>(() =>
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
            });

            //Start it and return it
            task.Start();
            return task;
        }
    }
}
