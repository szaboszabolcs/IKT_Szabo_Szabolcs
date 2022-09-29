using serial_Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace serialGenaratorGUI
{
    internal class Queries
    {
        Connect c = new Connect();

        public void dbRead(ListBox listboxForm1)
        {
            listboxForm1.Items.Clear();

            string qry = "SELECT `id`,`razon`,`active` FROM `serial`;";

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
                string qry = "INSERT INTO `serial`(`razon`, `active`) " +
                       "VALUES ('" + rnd.Next(100000, 10000000).ToString() + "', 1);";

                MySqlCommand cmd = new MySqlCommand(qry, c.connection);

                cmd.ExecuteNonQuery();
            }
            catch
            {
                dbCreate();
            }

        }

        public void dbDelete(ListBox listboxForm1)
        {
            /*textbox3.Text = listboxForm1.SelectedIndex.ToString();
            MessageBox.Show(listboxForm1.Items[listboxForm1.SelectedIndex].ToString());*/
            string[] split = listboxForm1.Items[listboxForm1.SelectedIndex].ToString().Split('-');

            string qry = "DELETE FROM serial WHERE id=" + split[0];
            MySqlCommand cmd = new MySqlCommand(qry, c.connection);

            cmd.ExecuteNonQuery();
        }

        string id;
        public void textPaste(ListBox listboxForm1, TextBox textbox1, TextBox textbox2)
        {
            string[] split = listboxForm1.Items[listboxForm1.SelectedIndex].ToString().Split('-');

            textbox1.Text = split[1];
            textbox2.Text = split[2];

            id = split[0];

        }

        public void dbUpdate(TextBox textbox1, TextBox textbox2)
        {
            try
            {
                string qry = "UPDATE `serial` SET `razon`='" + textbox1.Text + "'," +
                "`active`=" + textbox2.Text + " " + "WHERE id=" + id;

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
