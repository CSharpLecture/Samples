using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //String Literals have an @ symbol before the string
            //There \ is no escape sequence starter
            string path = @"C:\Windows";

            //Reading out the files of the given directory
            var files = Directory.GetFiles(path);

            //Reading out all drives
            var drives = DriveInfo.GetDrives();

            //Adding all files
            foreach (var file in files)
            {
                //The listbox collection takes arbitrary objects as input
                //and uses the ToString() for drawing
                FileInfo fi = new FileInfo(file);
                listBox1.Items.Add(fi);
            }

            //Adding all drives
            foreach (var drive in drives)
            {
                listBox1.Items.Add(drive);
            }
        }

        //What if we change the selected index (i.e. pick a new item)?
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = listBox1.SelectedItem != null;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //Just be sure that we really have an item selected
            var fi = listBox1.SelectedItem as FileInfo;

            //if we have an item selected AND that item is of type FileInfo then ...
            if (fi != null)
            {
                //Read that file and show it in the MessageBox (beware of large and non-text files!)
                string text = await fi.OpenText().ReadToEndAsync();
                MessageBox.Show(text);
            }
        }
    }
}
