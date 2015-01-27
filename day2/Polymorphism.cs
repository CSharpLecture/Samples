using System;

class Program
{
	static void Main(string[] args)
	{
		//A new vehicle is created, the Console will display "Vehicle created."
		Vehicle veh = new Vehicle();

		//Let's create a new car
		Car car = new Car();
		//The Console displayed "Vehicle created." and "Car built." (in that order)

		//Here we create a new Porsche, but treat it as a vehicle
		Vehicle porsche = new Porsche();
		//The console displayed all 3 constructor messages, starting with the most
		//basic constructor, the one from vehicle, then the one from the car and 
		//finally the invoked one.

		veh.Drive();//A driving vehicle.

		car.Drive();//A driving car!

		porsche.Drive();//WOOOOAH! This is a Porsche driving!!

		//So the re-implementation works - and it still works when we treat Porsche as Vehicle

		//However, if we just hide it like here:

		veh.Brake();//Vehicle stopped.

		porsche.Brake();//Vehicle stopped.

		//So hiding is different, but how to display the hidden implementation?

		Porsche myporsche = (Porsche)porsche;

		myporsche.Brake();//A Porsche cannot be stopped ...

		//Casting works. A much better way (in general) would have been one of those two:

		//is will return true or false depending if a cast is possible
		if(porsche is Porsche)
			((Porsche)porsche).Brake();

		//Or using "as" (if no cast possible then the return value is null)

		Porsche anotherPorsche = porsche as Porsche;

		if(porsche != null)
			anotherPorsche.Brake();
	}
}

class Vehicle
{
	public Vehicle()
	{
		Console.WriteLine("Vehicle created.");
	}

	//The virtual keyword enables overriding the method
	public virtual void Drive()
	{
		Console.WriteLine("A driving vehicle.");
	}

	public void Brake()
	{
		Console.WriteLine("Vehicle stopped.");
	}
}

//The colon (:) symbolizes inheritance
class Car : Vehicle
{
	public Car()
	{
		Console.WriteLine("Car built.");
	}

	//The override keyword lets use re-implement the method
	public override void Drive()
	{
		Console.WriteLine("A driving car!");
	}
}

class Porsche : Car
{
	public Porsche()
	{
		Console.WriteLine("Finally created a Porsche!");
	}

	//Another re-implementation, this time for Porsche instances
	public override void Drive()
	{
		Console.WriteLine("WOOOOAH! This is a Porsche driving!!");
	}	

	//Methods without virtual (or abstract) cannot be re-implemented,
	//but can be hidden. However, hiding a method only works if the
	//instance is treated as the corresponding class, i.e. a Porsche
	//instance has to be treated as Porsche and not as Car or Vehicle.
	//( More in the Main() method )
	public new void Brake()
	{
		Console.WriteLine("A Porsche cannot be stopped ...");
	}
}