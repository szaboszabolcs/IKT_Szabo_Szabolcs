using serial_Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace serialGeneratorGUI
{
    internal class Queries
    {
        Connect c = new Connect();
        Form1 f1 = new Form1();
       
        public void dbRead()
        {
            string qry = "SELECT `id`,`razon`, `active` FROM `serial`;";

            MySqlCommand cmd = new MySqlCommand(qry, c.connection);

            MySqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                f1.lista.Add(dr.GetValue(0) + "-" + dr.GetValue(1) + "-" + dr.GetValue(2));
            }

            dr.Close();
        }
    }
}
