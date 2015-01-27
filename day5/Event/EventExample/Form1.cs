using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventExample
{
    public partial class Form1 : Form
    {
        Dice dice;

        public Form1()
        {
            //Create new instance of that Dice class
            dice = new Dice();
            InitializeComponent();
            //This is how we register an event handler manually!
            dice.DesiredNumberFound += dice_DesiredNumberFound;
        }

        void dice_DesiredNumberFound(Dice sender, DiceEventArgs e)
        {
            //Let's output the previous numbers
            Debug.WriteLine(string.Join(", ", e.Numbers.Select(m => m.ToString()).ToArray()));
            MessageBox.Show("Correct! The number of trials was: " + e.Count);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Setting the desired number will trigger the dice algorithm
            var d = Convert.ToInt32(numericUpDown1.Value);
            //We had to convert the decimal to integer first
            dice.DesiredNumber = d;
        }
    }
}
