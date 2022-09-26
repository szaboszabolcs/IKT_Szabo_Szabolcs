using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace serialGeneratorGUI
{
    public partial class Form1 : Form
    {
        Queries q = new Queries();
        public Form1()
        {
            InitializeComponent();
            q.dbRead(listBox1);

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
