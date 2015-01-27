using System;
using System.Collections.Generic;
using System.Linq;

namespace Tag3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Let's fill a list of doubles with values
            var list = new List<double>(new []{ 1.0, 5.0, 6.0, 9.0, 19.0 });

            //Let's define a LINQ query and save it in squares
            var squares = list.Select(m => m * m).OrderByDescending(m => m);

            Console.WriteLine("Dump of the list");

            list.Dump();

            Console.WriteLine("Dump of the LINQ query");

            //Here a (temporary) result is created (not before)
            squares.Dump();

            //Here a permanent result is generated and saved in squaresBefore
            var squaresBefore = squares.ToArray();

            //We add something to the initial list
            list.Add(0.0);

            //Here a permanent result is generated and saved in squaresAfter
            var squaresAfter = squares.ToArray();

            Console.WriteLine("Dump of squaresBefore (Array)");

            //Here we applied LINQ before changing the initial list
            squaresBefore.Dump();

            Console.WriteLine("Dump of squaresAfter (Array)");

            //Here we applied LINQ after changing the initial list
            squaresAfter.Dump();

            //Let's use LINQ with an anonymous type
            var moreOnSquares = squares.Select(m => new
            {
                Digits = m.ToString().Length,
                Sum = m.ToString().Select(n => int.Parse(n.ToString())).Sum(),
                Num = m
            });

            //Let's add something (so the iteration hereafter will also change!)
            list.Add(174842.0);

            //Observe that the result is only generated once it is needed
            foreach (var element in moreOnSquares)
            {
                //We do not have ToString() on this anonymous object,
                //which is why we iterate over the elements without
                //using our Dump() extension method
                Console.WriteLine("Digits = {0}, Digit sum = {1}, Number = {2}",
                    element.Digits, element.Sum, element.Num);
            }
        }
    }

    //A class for our own extensions
    static class MyExtensions
    {
        //A dump method to output instances that implement IEnumerable 
        public static void Dump<T>(this IEnumerable<T> elements)
        {
            //Just writing every element to the console
            foreach(var element in elements)
                Console.WriteLine(element);
        }
    }
}
