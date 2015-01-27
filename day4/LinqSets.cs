using System;
using System.Collections.Generic;
using System.Linq;

namespace Tag4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Just create and fill some sets
            var A = new List<int>(new [] { 1, 2, 3, 4, 5, 6, 7, 8, 19});
            var B = new List<int>(new [] { 2, 4, 9, 29 });

            //Print them
            A.Dump("A");
            B.Dump("B");

            //C is the union of both sets, D the intersection
            var C = A.Union(B).ToList();
            var D = A.Intersect(B).ToList();

            C.Dump("C");
            D.Dump("D");

            //Let's use our own, custom implementation for SymmetricExcept
            var E = A.SymmetricExcept(B);

            //Print it
            E.Dump("E");

            //Let's see distinct (only unique elements will be kept) in action
            var F = new List<int>(new[] { 1, 2, 2, 4, 9, 9, 9, 29, 29, 29, 100 });

            F.Dump("F");

            F.Distinct().Dump("F without duplicates");
        }
    }

    //Some useful extensions
    static class MyExtensions
    {
        //Dumping any IEnumerable with some caption
        public static void Dump<T>(this IEnumerable<T> liste, string caption)
        {
            Console.WriteLine(caption);
            Console.WriteLine("===");

            foreach (var element in liste)
                Console.WriteLine(element);

            Console.WriteLine("----------");
        }

        //The SymmetricExcept implementation
        public static IEnumerable<T> SymmetricExcept<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.Union(right).Except(left.Intersect(right));
        }
    }
}
