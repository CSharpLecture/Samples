using System;

static void Main()
{
	//We create a new dynamic type ...
	dynamic a = 4;
	//Adding it to an integer yields another dynamic type
	var b = a + 3;//Will be 7
	//Even a is an integer (behind the scenes) above, we can change it
	a = "4";
	var c = a + 3;//Will be "43"

	dynamic y1 = 3;
	dynamic z1 = 4;

	//This will call int Add(int, int)
	//however, the type of w1 will be dynamic
	var w1 = y1 + z1;

	dynamic y2 = 3.0;
	dynamic z2 = 4;

	//This will call double Add(double, double)
	//hence z2 will be casted to double implicitly
	var w2 = y2 + z2;

	dynamic y3 = "Hallo";
	dynamic z3 = 4;

	//This will result in an exception, since there is no
	//overload Add(string, int) or something similar.
	var w3 = y3 + z3;
}

static int Add(int a, int b)
{
	return a + b;
}

static double Add(double a, double b)
{
	return a + b;
}