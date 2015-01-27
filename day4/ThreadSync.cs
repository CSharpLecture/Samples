using System;
using System.Threading;
using System.Diagnostics;

namespace Tag4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create now instance
            Program p = new Program();
            //Invoke method RunThreads
            p.RunThreads();

            //For GUI threads use SynchronizationContext.Current with
            //var current = SynchronizationContext.Current; from the GUI thread
            //and current.Send(_ => { /* CODE HERE */ }, null); from the thread
        }

        //This object is only used for the locks
        object myLock;

        //Constructor to initialize the lock object
        public Program()
        {
            //Create the object reference
            myLock = new object();
        }

        public void RunThreads()
        {
            //Create the two threads
            Thread t1 = new Thread(MyWorkerOne);
            Thread t2 = new Thread(MyWorkerTwo);

            //Run them
            t1.Start();
            t2.Start();        
        }

        void MyWorkerOne()
        {
            //This will run without any rule
            Debug.WriteLine("Erster Worker ist drin!");

            //The rule for the following block is: only enter
            //when myLock is not in use, otherwise wait
            lock (myLock)
            {
                Debug.WriteLine("Erster im Lock!");
                Thread.Sleep(1000);
                Debug.WriteLine("Erster aus Lock!");
            }

            //Finally print this
            Debug.WriteLine("Eins Habe fertig!");
        }

        void MyWorkerTwo()
        {
            Debug.WriteLine("Zweiter Worker ist drin!");

            //The rule for the following block is: only enter
            //when myLock is not in use, otherwise wait
            lock (myLock)
            {
                Debug.WriteLine("Zweiter im Lock!");
                Thread.Sleep(5000);
                Debug.WriteLine("Zweiter aus Lock!");
            }

            //Finally print this
            Debug.WriteLine("Zwei Habe fertig!");
        }
    }
}
