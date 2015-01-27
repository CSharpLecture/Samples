using System;
using System.Diagnostics;
using System.Threading;

namespace Tag4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating a thread and starting it is straight forward
            Thread t = new Thread(DoALotOfWork);
            //Just pass in a void Method(), or void Method(obj) and invoke start
            t.Start();
        }

        static void DoALotOfWork()
        {
            double sum = 0.0;
            Random r = new Random();
            Debug.WriteLine("A lot of work has been started!");
            
            //infinite loop with goto
        LOOP:

            //some weird algorithm
            var d = r.NextDouble();

            if (d < 0.333)
                sum += Math.Exp(-d);
            else if (d > 0.666)
                sum += Math.Cos(d) * Math.Sin(d);
            else
                sum = Math.Sqrt(sum);

            goto LOOP;

            Debug.WriteLine("The thread has been stopped!");
        }
    }
}
