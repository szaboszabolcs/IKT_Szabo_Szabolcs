using serialGenaratorGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;


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
        }
    }
}
