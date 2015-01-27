using System;
using System.Collections.Generic;
using System.Linq;

namespace Tag3
{
    //This looks like a function prototype except that the first keyword is delegate
    delegate double MyDoubleDelegate(double x);

    class Program
    {
        static void Main(string[] args)
        {
            //If we just use the method's name we get the reference
            //of the method. We need to save it in a delegate type
            //that fulfills the signature (return type and argument types)
            //of the method
            MyDoubleDelegate squareNormal1 = Square;

            //The generic delegate Func<Tin, Tout> gives us a
            //really general delegate that can easily be specified
            Func<double, double> squareNormal2 = Square;

            //Now we do the same with a lambda expression
            Func<double, double> squareLambda = x => x * x;

            //Question: What is shorter?

            Console.WriteLine(squareLambda(2));

            //There are other generic types like Action for no return value
            Action<string> printf = str => Console.WriteLine(str);

            //The method behind a delegate can be accessed by using the delegate
            //instance like a method (just calling it with some arguments):
            printf("Hi there!");
            printf("how are you?!");

            //Another popular generic delegate is the predicate, which
            //always returns a boolean
            Predicate<int, int> equal = (l, r) => l == r;

            if(equal(2, 3))
                printf("The two numbers are equal (how?!).");
            else if(equal (3,3))
                printf("Now that looks more like it!");
        }

        static double Square(double x)
        {
            return x * x;
        }
    }
}
