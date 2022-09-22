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
        public List<string> lista = new List<string>();
        public Form1()
        {
            InitializeComponent();
           

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Queries q = new Queries();
            q.dbRead();

            MessageBox.Show(lista.Count.ToString());

            for (int i = 0; i < lista.Count; i++)
            {
                listBox1.Items.Add(lista[i]);
            }
        }
    }
}
