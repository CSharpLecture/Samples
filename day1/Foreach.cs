//Now we are only using the System namespace - we do not need more
using System;

class Program
{
	static void Main(string[] args)
	{
		//Creating an array is possible by just appending [] to any datatype
		int[] myints = new int[4];
		//This is now a fixed array with 4 elements. Arrays in C# are 0-based
		//hence the first element has index 0.
		myints[0] = 2;
		myints[1] = 3;
		myints[2] = 17;
		myints[3] = 24;

		//Also any array type instance, i.e. an instance of any type that appends
		//the brackets [] has the property Length - we will soon learn what
		//properties are. For now: They can be accessed like variables.
		Console.WriteLine("Length = " + myints.Length);

		//This foreach construct is new in C# (compared to C++):
		foreach(int myint in myints)
		{
			//Write will not start a new line after the string.
			Console.Write("The element is given by ");
			//WriteLine will do that.
			Console.WriteLine(myint);
		}
	}
}
