using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventExample
{
    //Let's use our own delegate, which allows us to specialize the sender
    delegate void DiceEventHandler(Dice sender, DiceEventArgs e);

    class Dice
    {
        Random random;
        Timer timer;
        int desired;
        int count;
        List<int> list;

        public event DiceEventHandler DesiredNumberFound;

        public Dice()
        {
            list = new List<int>();
            desired = 1;
            random = new Random();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
        }

        public int DesiredNumber
        {
            get { return desired; }
            set
            {
                if (value < 7 && value > 0)
                {
                    count = 0;
                    timer.Stop();
                    timer.Start();
                    desired = value;
                }
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            count++;
            var num = random.Next(1, 7);

            if (num == DesiredNumber)
            {
                timer.Stop();

                //Here we use the event - important: Check if the delegate instance is NULL
                if (DesiredNumberFound != null)
                //if not null, call the delegate - this will call all registered event handlers
                    DesiredNumberFound(this, new DiceEventArgs { Count = count, Numbers = list.ToArray() });
            }
            else
                list.Add(num);
        }
    }
}
