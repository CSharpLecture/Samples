using System;
//This is the namespace where e.g. ArrayList is associated with
using System.Collections;

class Program
{
	static void Main(string[] args)
	{
		//Arrays can be directly initialized using the initializer lists
		int[] oneDim = new int[] { 1, 2, 4, 6 };

		//We can also create (fixed) two-dimensional arrays
		int[,] twoDim = new int[2, 2];
		twoDim[0, 0] = 4;
		twoDim[1, 0] = 2;
		twoDim[0, 1] = -3;

		//Again: Initializer lists are possible, but they use more curly brackets
		int[,] twoDimInit = new int[,] { {4, -3}, {2, 0} };

		//Since an array can be made out of any datatype, we can make an array out
		//of an array of some datatype. This is then called a jagged array, since
		//we now could make non-fixed 2D arrays
		double[][] jagged = new double[2][];

		//Important here: We have to instantiate all the sub-arrays individually
		//before we can use them - otherwise we get nasty null-reference exception!
		jagged[0] = new double[3];
		jagged[1] = new double[1];
	}
}
