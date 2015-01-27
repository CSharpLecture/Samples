using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
	//It is a good pattern to inherit from EventArgs
	//This marks such objects as being used for passing event arguments
    class DiceEventArgs : EventArgs
    {
        public int Count { get; set; }

        public int[] Numbers { get; set; }
    }
}
