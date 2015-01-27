using System;

class Program
{
	static void Main(string[] args)
	{
		//We get some user input with the ReadLine() method
		string input = Console.ReadLine();

		//Let's see if this is empty or not
		if(input == "")
		{
			Console.WriteLine("The input is empty!");
		}
		else
		{
			//A string is a char array and has a Length property
			//It also can be accessed like a char array, giving
			//us single chars.
			for(int i = 0; i < input.Length; i++)
			{
				switch(input[i])
				{
					case 'a':
						Console.WriteLine("An a - and not ...");
						//This is always required, we cannot just fall through.
						goto case 'z':
					case 'z':
						Console.WriteLine("A z!");
						break;
					default:
						Console.WriteLine("Whatever ...");
						//This is required even in the last block
						break;
				}
			}
		}
	}
}
