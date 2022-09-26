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

        public void dbCreate()
        {
            Random rnd = new Random();

            try
            {
                string qry = "INSERT INTO `serial`( `razon`, `active` ) VALUES ('" + rnd.Next(1000000,1000000) + ", 1);";

                MySqlCommand cmd = new MySqlCommand(qry, c.connection);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                dbCreate();
            }
        }

        public void dbDelete(ListBox listboxForm1)
        {
            /*textbox5.Text = listboxForm1.SelectedIndex.ToString();
            MessageBox.Show(listboxForm1.Items[listboxForm1.SelectedIndex].ToString());*/
            string[] split = listboxForm1.Items[listboxForm1.SelectedIndex].ToString().Split('-');
            string qry = "DELETE FROM serial WHERE id=" + split[0];
            MySqlCommand cmd = new MySqlCommand(qry, c.connection);

            cmd.ExecuteNonQuery();
        }

        string id;

        public void textPaste(ListBox listboxForm1, TextBox textbox3, TextBox textbox4)
        {
            string[] split = listboxForm1.Items[listboxForm1.SelectedIndex].ToString().Split('-');

            textbox3.Text = split[1];
            textbox4.Text = split[2];

            id = split[0];
        }

        public void dbUpdate(TextBox textbox3, TextBox textbox4)
        {
            try
            {
                string qry = "UPDATE `serial` SET `razon`='" + textbox3.Text + "'," + "`active`=" + textbox4.Text + " " + "WHERE id=" + id;

                MySqlCommand cmd = new MySqlCommand(qry, c.connection);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
    }
} 
