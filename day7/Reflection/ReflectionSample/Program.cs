using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loading current executable with all types
            var assembly = Assembly.GetExecutingAssembly();
            //Get the types form the assembly
            var types = assembly.GetTypes();
            //Create a dictionary for storing them
            var things = new Dictionary<string, BaseThings>();

            //Iterate over all types
            foreach (var type in types)
            {
                //If the type is a subclass of BaseThings and not abstract (could be instantiated)
                if (type.IsSubclassOf(typeof(BaseThings)) && !type.IsAbstract)
                {
                    //We get the constructor (empty)
                    var ctor = type.GetConstructor(System.Type.EmptyTypes);
                    //We call the constructor (no parameters)
                    var thing = ctor.Invoke(null) as BaseThings;

                    //We insert the generated instance in the dictionary
                    things.Add(type.Name.Replace("Things", ""), thing);
                }
            }

            Console.WriteLine("Enter a class name: ");

            //Display all available instances
            foreach (var thing in things)
            {
                Console.Write("- ");
                Console.WriteLine(thing.Key);
            }

            var choice = Console.ReadLine();

            //If found
            if (things.ContainsKey(choice))
            {
                //Get the instance
                var thing = things[choice];
                //Execute something
                thing.IamHere();

                //Get the explicit type (again, reflection)
                var meta = thing.GetType();

                //Just simply make a string consisting of all strings separated by commas
                var str = string.Join(", ", meta.GetMethods().Select(m => m.Name).ToArray());

                //Display it!
                Console.WriteLine("The available methods are: " + str);
            }
            else
                Console.WriteLine("Not found!!");
        }
    }
}
