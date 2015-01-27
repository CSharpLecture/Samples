using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDropExample
{
    public partial class Form1 : Form
    {
        MemoryStream ms;

        const int BUFFER_SIZE = 256;
        const string WRITE_PATH = @"Test.log";

        public Form1()
        {
            InitializeComponent();
        }

        //Once a file is dropped
        async void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var list = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (list != null)
            {
                //Read out the first file of the list
                await ReadFile(list[0]);
            }
        }

        //Once a file is dragged over the form
        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            var list = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (list != null)
            {
                //If there is a file over the box then allow it
                e.Effect = DragDropEffects.Move;
            }
        }

        //Let's make a task
        async Task ReadFile(string fileName)
        {
            //The memory stream should buffer the read
            ms = new MemoryStream();

            var total = 0;
            //a temporary buffer for small reads
            var buffer = new char[BUFFER_SIZE];
            var bytesRead = 0;
            //The StreamReader to read the text file
            var sr = new StreamReader(fileName, true);

            do
            {
                bytesRead = await sr.ReadAsync(buffer, 0, buffer.Length);

                //For each character that has been received, put it ...
                for (int i = 0; i < bytesRead; i++)
                {
                    char c = buffer[i];
                    //as bytes to the MemoryStream
                    var b = BitConverter.GetBytes(c);
                    ms.Write(b, 0, b.Length);
                    //Let's save the number of characters (not bytes) that have been read
                    total++;
                }
            }
            while (bytesRead != 0);

            //Important: Close the StreamReader
            sr.Close();
            MessageBox.Show("Total characters: " + total);
            button2.Enabled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            var bytesRead = 0;

            //Take the users my Documents folder as path
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Create the StreamWriter
            var sw = new StreamWriter(path + "\\" + WRITE_PATH, false, Encoding.UTF8);
            var buffer = new byte[BUFFER_SIZE];

            //Important: Reset the position of the Stream
            ms.Position = 0;

            do
            {
                bytesRead = await ms.ReadAsync(buffer, 0, buffer.Length);

                //Each character is given by 2 bytes
                for (int i = 0; i < bytesRead; i+=2)
			    {
                    //Convert it back!
                    var chr = BitConverter.ToChar(buffer, i);
                    await sw.WriteAsync(chr);
			    }
            }
            while (bytesRead != 0);

            //Close everything
            sw.Close();
            ms.Close();
            MessageBox.Show("File created successfully.");
        }
    }
}
