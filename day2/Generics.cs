using System;
using System.Collections.Generics;

class Program
{
	static void Main(string[] args)
	{
		//Using a generic class, e.g. the very useful List<T> class
		List<int> list = new List<int>();

		//Only ints can be inserted, which is much more constrained than ArrayList
		list.Add(2);
		list.Add(3);

		//Additionally we only get integers out of the list, no cast required
		int difference = list[1] - list[0];

		int a = 2;
		int b = 5;

		//Usually (if all type parameters are used in the argument list) the types
		//for generic methods can be inferred by the compiler
		Swap(ref a, ref b);

		//Question: Why can't the compiler infer the type here?
		//Answer: It is possible to create a non-generic class Wrapper, without
		//having a name-conflict, i.e. the call new Wrapper(5) and new Wrapper<int>(5)
		//would be ambiguous if the compiler would start inferring the types for
		//classes.
		Wrapper<int> myGeneric = new Wrapper<int>(5);
	}

	//Just use T where you usually would use a real type like int
	static void Swap<T>(ref T left, ref T right)
	{
		//Creating a variable of our placeholder type T
		T temp = right;
		right = left;
		left = temp;
	}
}

class Wrapper<T>
{
	T content;

	public Wrapper(T content)
	{
		//To distinguish between the local content and the global content we 
		//can use the current instance pointer this.
		this.content = content;
	}
}

//This places a constraint on the type T - only types that have a default
//constructor defined can be used as types for this class.
class ConstraintWrapper<T> where T : new()
{
	T content;

	public ConstraintWrapper(T content)
	{
		//To distinguish between the local content and the global content we 
		//can use the current instance pointer this.
		this.content = content;
	}

	public T Fresh
	{
		//Returning new T() would not have been possible before, since we
		//could not be sure that every possible inserted type has a default
		//constructor
		get { return new T(); }
	}
}
