//Those are the namespaces that are (by default) included
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

//By default Visual Studio creates already a namespace
namespace HelloWorld
{
	//Remember: Everything (variables, functions) has to be encapsulated
	class Program
	{
		//The entry point is called Main (capital M) and has to be static
		static void Main(string[] args)
		{
			//Writing something to the console is easily possible using the
			//class Console with the static method Write or WriteLine
			Console.WriteLine("Hello World!");
		}
	}
}