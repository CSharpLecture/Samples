using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{
	//An abstract base for all "Things"
    abstract class BaseThings
    {
        public void IamHere()
        {
            Console.WriteLine("Hi from a thing!!");
        }
    }
}
