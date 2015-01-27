using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GdiPlusSample
{
    //Creating our control is as simple as inheriting from Control
    class Equalizer : Control
    {
        //Just some members
        Random rand;
        int[] channels;
        bool stopped;

        //And a useful constant
        const int MAX_BOXES = 10;

        public Equalizer()
        {
            //Set a more optimized draw-mode
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            //Instantiate everything
            rand = new Random();
            channels = new int[10];
            //Some startup config
            UpdateChannels();
            stopped = true;
        }

        public void UpdateChannels()
        {
            //Give every "channel" a random value
            for (int i = 0; i < channels.Length; i++)
            {
                channels[i] = rand.Next(0, 100);
            }
        }

        //Do something
        public async Task Start()
        {
            stopped = false;

            while (!stopped)
            {
                UpdateChannels();
                Refresh();
                //Do not block the UI thread!
                await Task.Delay(100);
            }
        }

        public void Stop()
        {
            //Just set the stopped variable to true
            stopped = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            //Anti-alias for smooth rendering
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var offset = 0;
            //Compute distance between elements
            var dx = Width / channels.Length;

            //draw all elements, i.e. channels
            for (int i = 0; i < channels.Length; i++)
            {
                DrawChannel(g, channels[i], offset, dx);
                offset += dx;
            }
        }

        //Draw one channel
        private void DrawChannel(Graphics g, int value, int offset, int width)
        {
            //Compute the height for each "bar"
            var boxes = value / MAX_BOXES;
            var y = Height;
            var dy = Height / MAX_BOXES;

            for (int i = 0; i < boxes; i++)
            {
                //Draw one bar
                y -= dy;
                g.FillRectangle(GetBrush(i), new Rectangle(offset, y,  width, dy));
            }
        }

        private Brush GetBrush(int i)
        {
            //We want to assign each of the bars a certain fixed color
            switch (i)
            {
                case 0:
                    return Brushes.Green;
                case 1:
                    return Brushes.Yellow;
                case 2:
                    return Brushes.Pink;
                case 3:
                    return Brushes.Olive;
                case 4:
                    return Brushes.Red;
                case 5:
                    return Brushes.SteelBlue;
                case 6:
                    return Brushes.ForestGreen;
                case 7:
                    return Brushes.Orange;
                case 8:
                    return Brushes.Red;
                default:
                    return Brushes.DarkRed;
            }
        }
    }
}
