using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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

            //Load items into the ListBox
            LoadItems();
        }

        private void LoadItems()
        {
            //Read out directory
            var files = Directory.GetFiles(Environment.CurrentDirectory);

            //Go over each file, add them to the listBox as FileInfo instances
            foreach (var file in files)
                listBox1.Items.Add(new FileInfo(file));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Start the equalizer
            equalizer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Stop the equalizer
            equalizer1.Stop();
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //Does the index make sense?
            if (e.Index >= 0 && e.Index < listBox1.Items.Count)
            {
                //Draw the background
                e.DrawBackground();

                //Get the element
                var item = listBox1.Items[e.Index] as FileInfo;

                //If the element is not null and of type FileInfo then ....
                if (item != null)
                {
                    //Just a short alias for e.Graphics
                    var g = e.Graphics;
                    //Is selected ?!
                    var selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                    var name = Path.GetFileNameWithoutExtension(item.Name);
                    var icon = GetIcon(item.Extension);

                    //Draw the icon
                    g.DrawImage(icon, new Point(e.Bounds.Left + 2, e.Bounds.Top + 2));

                    //Draw the filename
                    g.DrawString(name, selected ? new Font(e.Font, FontStyle.Bold) : e.Font,
                        selected ? Brushes.White : Brushes.Black, e.Bounds, new StringFormat()
                    {
                        //Place it at the right position (center, center)
                        LineAlignment = StringAlignment.Center,
                        Alignment = StringAlignment.Center
                    });
                }

                //Draw focus rectangle!
                e.DrawFocusRectangle();
            }
        }

        Bitmap GetIcon(string extension)
        {
            //Get an appropriate icon and return it
            switch (extension)
            {
                case ".xml":
                    return FileIcons.exce;

                case ".exe":
                    return FileIcons.psd;

                default:
                    return FileIcons.pdf;
            }
        }

        private void listBox1_SizeChanged(object sender, EventArgs e)
        {
            //We need this to ensure a valid and good drawing
            listBox1.Refresh();
        }
    }
}
