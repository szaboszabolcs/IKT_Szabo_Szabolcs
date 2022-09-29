using serialGenaratorGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;


namespace serialGeneratorGUI
{
    public partial class Form1 : Form
    {
        Queries q = new Queries();
        Printing p = new Printing();


        public Form1()
        {
            InitializeComponent();
            q.dbRead(listBox1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*q.dbCreate(textBox3, textBox4);
            q.dbRead(listBox1);*/

            q.dbUpdate(textBox3, textBox4);
            q.dbRead(listBox1);
        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Biztosan törlöd?", "Elem törlése", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                q.dbDelete(listBox1);
                q.dbRead(listBox1);
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            q.textPaste(listBox1, textBox3, textBox4);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            q.dbCreate();
            q.dbRead(listBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            p.doPdf(listBox1);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.button2.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        this.button2.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        this.button2.Image.Save(fs,
                           System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }

    }
}