using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{
    //Another example
    class CoolThings : BaseThings
    {
        public void CoolShizzle()
        {
        }
    }

    //And even more implementations (program is extended automatically!)

    class CoolestThings : BaseThings
    {
    }


    class HotThings : BaseThings
    {
    }

    class DirtyThings : BaseThings
    {
    }
}
