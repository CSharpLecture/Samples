using System;

namespace PropertiesExample
{
	class Program
	{
		static void Main(string[] args)
		{
			//Instantiate the Car class
			Car porsche = new Car();

			//Just print the initial value (will be 0)
			Console.WriteLine("Initial value of the horse power: {0}", porsche.Horses);

			//Reset to 200 (should be fine - print to be sure)
			porsche.Horses = 200;
			Console.WriteLine("Value of the horse power after change: {0}", porsche.Horses);

			//Reset to 0 (this should not work - value should still be 200)
			porsche.Horses = 0;
			Console.WriteLine("Final value of the horse power: {0}", porsche.Horses);
		}
	}

	class Car
	{
		//The (private) field of the class - not visible from outside Car
		int horses;

		//The access to horses is only possible over this wrapper
		public int Horses
		{
			//We have a compiler-generted "int GetHorses()" method
			get 
			{ 
				return horses; 
			}
			//We have a compiler-generted "void SetHorses(int value)" method
			set
			{
				//Here we use the power of our wrapper to decide if we really
				//want to change the value for our horses field
				if(value > 0)
					horses = value;
			}
		}
	}
}