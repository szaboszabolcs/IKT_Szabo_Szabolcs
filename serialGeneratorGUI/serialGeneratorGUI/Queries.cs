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
        
       
        public void dbRead(ListBox listboxForm1)
        {
            string qry = "SELECT `id`,`razon`, `active` FROM `serial`;";

            MySqlCommand cmd = new MySqlCommand(qry, c.connection);

            MySqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                listboxForm1.Items.Add(dr.GetValue(0) + "-" + dr.GetValue(1) + "-" + dr.GetValue(2));
            }

            dr.Close();
        }
    }
}
