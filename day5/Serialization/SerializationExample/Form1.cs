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
using System.Xml.Serialization;

namespace SerializationExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //What happens if we press the button?
        private void button1_Click(object sender, EventArgs e)
        {
            //Create a sample object
            var note = new Note
            {
                Created = DateTime.Now.AddDays(-1),
                Description = "Some description",
                Title = "My Title"
            };

            //Ask the user to point us to some file
            SaveFileDialog sfd = new SaveFileDialog();

            //If the directory was closed with OK then
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Open the file stream
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                //Create the serializer
                XmlSerializer xml = new XmlSerializer(typeof(Note));
                //Serialize!
                xml.Serialize(fs, note);
                //Close the filestream (important!)
                fs.Close();
            }
        }

        void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                FileStream fs = new FileStream(sfd.FileName, FileMode.Open);
                XmlSerializer xml = new XmlSerializer(typeof(Note));
                var note = xml.Deserialize(fs) as Note;

                if (note != null)
                {
                    MessageBox.Show(note.ToString());
                }

                fs.Close();

            }
        }
    }
}
