using System;

class Program
{
	static void Main(string[] args)
	{
		//5 here is an integer literal
		int a = 5;

		//This works due to OOP - every variable has a ToString() method
		if("5" == a.ToString())
		{
			Console.WriteLine("We cannot compare string and int, but string and string.");
		}

		//A double value is a floating point literal.
		double x = 2.5;
		//A single value is given by a floating point literal with the suffix f.
		float y = 3.1f;

		string input = Console.ReadLine();

		//int, string, double, float, ... are just keywords - in fact, they are represented
		//by Int32, String, Double, Single - which have static (and non-static) members.
		a = int.Parse(input);

		//Output of a mod operation - adding string and something (or something and string)
		//will always result in a string. Additionally we have the regular operator ordering
		//which performs a % 10 before the string and a get concatenated.
		Console.WriteLine("a % 10 = " + a % 10);
	}
}
