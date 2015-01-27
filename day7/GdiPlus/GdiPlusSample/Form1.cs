using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GdiPlusSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Try out those three methods

            //Draw a simple rectangle and circle
            //pictureBox1.Image = DrawSimpleRectangle();

            //Draw a rectangle using transformations
            //pictureBox1.Image = DrawTransformedRectangle();

            //Draw some arbitrary path (a star like shape)
            pictureBox1.Image = DrawArbitraryPath();
        }

        private Bitmap DrawArbitraryPath()
        {
            Bitmap bmp = new Bitmap(400, 300);
            Graphics g = Graphics.FromImage(bmp);

            //Create the path
            GraphicsPath p = new GraphicsPath();

            //Add some fixed lines by adding the points
            p.AddLines(new Point[] 
            { 
                new Point(200, 0),
                new Point(220, 130),
                new Point(400, 130),
                new Point(220, 150),
                new Point(300, 300),
                new Point(200, 150)
            });

            //Fill the path (this will fill one (the right) half)
            g.FillPath(Brushes.Red, p);

            //Scale with -1, i.e. 200 will be -200, 220 will be -220
            g.ScaleTransform(-1f, 1f);

            //Transform with -400, i.e. -200 will be 200, -220 will be 180
            g.TranslateTransform(-400, 0);

            //Fill the second half (left half)
            g.FillPath(Brushes.Blue, p);

            return bmp;
        }

        private Bitmap DrawTransformedRectangle()
        {
            Bitmap bmp = new Bitmap(400, 300);
            Graphics g = Graphics.FromImage(bmp);

            //The smoothing mode enables drawing of intermediate pixels
            g.SmoothingMode = SmoothingMode.AntiAlias;

            //Fill some rectangle (full image)
            g.FillRectangle(Brushes.Turquoise, new Rectangle(0, 0, 400, 300));

            //Use the translate to change px, py to px', py' by using px + a, py + b
            g.TranslateTransform(200, 150);

            //Use rotate to change px, py to px', py' by using cos(alpha) * px - sin(alpha) * py, cos(alpha) * px + sin(alpha) * py
            g.RotateTransform(45f);

            //Scale it with px, py to px', py' by using a * px, b * py
            g.ScaleTransform(0.3f, 0.3f);

            //Draw a rectangle using these transformations
            g.DrawRectangle(Pens.Red, new Rectangle(-100, -50, 200, 100));

            return bmp;
        }

        private Bitmap DrawSimpleRectangle()
        {
            Bitmap bmp = new Bitmap(400, 300);
            Graphics g = Graphics.FromImage(bmp);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            //Draw a simple rectangle (fill the complete rectangle with yellow)
            g.FillRectangle(Brushes.Yellow, new Rectangle(0, 0, 400, 300));

            //Drawing a rectangle with some big border
            g.DrawRectangle(new Pen(Color.Red, 4f), new Rectangle(10, 10, 380, 280));

            var circle = new Rectangle(15, 15, 270, 270);

            //Drawing a very simple linear gradient requires using a lineargradientbrush object
            var lgb = new LinearGradientBrush(new Point(15, 15), new Point(295, 295), Color.Red, Color.Black);

            //Now we can fill an ellipse with the gradient brush
            g.FillEllipse(lgb, circle);

            //Let's just try another circle
            g.DrawEllipse(Pens.DarkGreen, circle);

            return bmp;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Getting the graphics pointer to the bitmap in the image box
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            //Drawing a line on it
            g.DrawLine(Pens.Black, new Point(0, 0), new Point(pictureBox1.Width, pictureBox1.Height));
            //The line will not be displayed UNTIL we refresh the screen, i.e. refresh the control in this case
            pictureBox1.Refresh();
        }
    }
}
