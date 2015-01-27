using System;
using System.Collections.Generic;
using System.Linq;

namespace Tag3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class MyClass
    {
    	//Usually it is enough to create a variable and use VS
    	//to create the property
    	int myVariable;

    	//Or we just write it out - this is the "long way"
    	public int MyVariable
    	{
    		get { return myVariable; }
    		set { myVariable = value; }
    	}

    	//Now we use the auto-generate property
    	//we need both: the get and the set
    	public int MyVariableAuto
    	{
    		get;
    		set;
    	}

    	//However, we can restrict the access to a part
    	//(like the set here) to another modifier (like private)
    	public int MyVariableAutoOnlyGet
    	{
    		get;
    		private set;
    	}
    }
}
