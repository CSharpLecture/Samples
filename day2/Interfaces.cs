using System;

class Program
{
	static void Main(string[] args)
	{
		//We cannot create instances of Car, but we can
		//treat more specialized instances (like Porsche)
		//as a Car
		Car porsche = new Porsche();

		Car mercedes = new Mercedes();

		//The same with interfaces. Creating an instance
		//is not possible, but treating an existing instance
		//as the interface is possible.
		if(porsche is ITrunk)
			((ITrunk)porsche).OpenTrunk();

		//While the one before was obviously not right (we
		//see that porsche does not implement ITrunk, hence
		//porsche is ITrunk will be false and not execute
		//the OpenTrunk method), this one will work.
		if(mercedes is ITrunk)
			((ITrunk)mercedes).OpenTrunk();
	}
}

//Abstract classes can not be instantiated and enable
//the usage of the keyword abstract in the class body
abstract class Car
{
	//abstract is like prototyping - no body required
	public abstract void Drive();
}

//Interfaces do not offer any functionality, but offer
//the ability to MARK functionality as being available
interface ITrunk //The I in the beginning is just a .NET convention
{
	//No public required since all interface definitions
	//are by default abstract and public, i.e. they have
	//to be implemented and will have a public modifier
	void OpenTrunk();

	void CloseTrunk();
}

class Porsche : Car
{
	//We have to implement this method!
	public override void Drive()
	{
		Console.WriteLine("Porsche driving")
	}
}

//Additionally to all the functionality provided by
//the abstract base class, we want to extend this class
//by further abilities as stated in the interface ITrunk
class Mercedes : Car, ITrunk
{
	public override void Drive()
	{
		Console.WriteLine("Mercedes driving")
	}

	//Here no override is necessary
	public void OpenTrunk()
	{
		Console.WriteLine("Trunk opened");
	}

	public void CloseTrunk()
	{
		Console.WriteLine("Trunk closed");
	}
}