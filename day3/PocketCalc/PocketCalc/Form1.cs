using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocketCalc
{
    public partial class Form1 : Form
    {
        int result;
        int temp;
        Operationen op;

        public Form1()
        {
            op = Operationen.Keine;
            temp = 0;
            result = 0;
            InitializeComponent();
        }

        private void buttonFor0_Click(object sender, EventArgs e)
        {
            temp = 0;
            textBox1.Text = "0";
        }

        private void buttonFor1Clicked(object sender, EventArgs e)
        {
            temp = 1;
            textBox1.Text = "1";
        }

        private void plusButtonClicked(object sender, EventArgs e)
        {
            result = temp;
            op = Operationen.Plus;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result = temp;
            op = Operationen.Minus;
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            switch (op)
            {
                case Operationen.Plus:
                    result += temp;
                    break;

                case Operationen.Minus:
                    result -= temp;
                    break;
            }

            temp = result;
            textBox1.Text = result.ToString();
        }
    }

    enum Operationen
    {
        Keine,
        Plus,
        Minus
    }
}
