using System;
using System.Collections.Generic;
using System.Linq;

namespace Whatever
{
    //This needs to be used, or the extension is not available!
    using ExtNS;

    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            //We can use extension methods as if they have been designed for the object
            i.Print();

            //We now extended EVERY object in C#, since we applied the extension method
            //for this object
            "Hi there, how are you?".Dump();

            (5.0 - 3 * 2).Dump();

            //It is important to see, that extension methods are still just static methods
            //defined in some class. Hence the following way is also possible, however,
            //We see that this is a.) not as short as the other way and b.) from an
            //object-oriented perspective not very meaningful.
            MyExtensions.Print("Another way");
        }
    }
}

//We need to use that namespace above!
namespace ExtNS
{
    //A class for our own extensions
    static class MyExtensions
    {
        //A dump method to output any object to the console
        public static void Print(this object o)
        {
            Console.WriteLine("Extension method used!");
            Console.WriteLine(o);
        }
    }
}