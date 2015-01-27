using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Destructor();
            Console.WriteLine("Before");

            try
            {
                Sub();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division by 0 detected");
            }
            catch (MyException)
            {
                Console.WriteLine("My own exception occurred");
            }
            catch (Exception ex)
            {
                Console.WriteLine("A general exception happened");
                Console.WriteLine("Message: " + ex.Message);
            }

            try
            {
                //We do not want to let exceptions bubble up 
                TryTheFile();
            }
            catch (Exception)
            {
                //Rethrow exceptions with the following line
                //throw;
            }

            Console.WriteLine("After");
        }

        private static void Destructor()
        {
            //This is a very comfortable way of automatically disposing resources
            using (var ex = new MyException("a"))
            {
                //Access to ex like usually
            }
        }

        private static void TryTheFile()
        {
            //We need to declare this here otherwise we
            //cannot use fs in catch or finally
            FileStream fs = null;

            try
            {
                Console.WriteLine("Opening file");
                fs = new FileStream(@"C:\error.txt", FileMode.Open);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied...");
                //If we enter this block we will STILL enter finally as well
                return;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found...");
            }
            finally
            {
                Console.WriteLine("Finally!");

                fs.Close();
            }
        }

        private static void Sub()
        {
            int a = 0;
            Console.WriteLine("Entering sub");

            //Throwing a custom exception
            //throw new MyException("a");

            //Throwing a DividedByZeroException
            //int b = 2 / a;

            //Throwing a very general exception
            throw new Exception("Oops!");

            Console.WriteLine("Leaving sub");
        }
    }

    //Creating a custom exception is as easy as deriving from Exception
    class MyException : Exception, IDisposable
    {
        //Our own constructor
        public MyException(string variable)
            : base("The variable " + variable + " did throw an exception.")
        {
        }

        //Destructors are available everywhere, however, we cannot control
        //when they are called (the Garbage Collector does that)
        ~MyException()
        {
            Console.WriteLine("Destructor called");
            //Much better:
            //Dispose();
        }

        //This is the best: Dispose() can be called from outside AND from GC
        public void Dispose()
        {
            Console.WriteLine("Dispose called");
        }
    }
}
