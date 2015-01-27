using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskPower
{
    class BlinkLabel : Label
    {
        bool blinking;

        public BlinkLabel()
        {
            blinking = false;
            Interval = 1000;
        }

        public int Interval
        {
            get;
            set;
        }

        public bool IsBlinking
        {
            get { return blinking; }
        }

        public void Start()
        {
            if (!blinking)
            {
                blinking = true;
                DoBlink();
            }
        }

        public void Stop()
        {
            if (blinking)
            {
                blinking = false;
            }
        }

        async Task DoBlink()
        {
            while (blinking)
            {
                await Task.Delay(Interval);
                Visible = !Visible;
            }
        }
    }
}
