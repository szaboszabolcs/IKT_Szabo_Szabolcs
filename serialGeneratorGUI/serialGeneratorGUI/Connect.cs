using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace serial_Generator
{
    class Connect
    {
        public MySqlConnection connection;

        string db;      //Database name
        string srv;     //Database Server
        string usr;     //User
        string pass;    //Passworld

        string connectionstring;

        public Connect()
        {
            srv = "localhost";
            db = "serials";
            usr = "root";
            pass = "";

            connectionstring = "SERVER=" + srv + ";" + "DATABASE=" + db + ";" + "UID=" + usr + ";"
                + "PASSWORD=" + pass + ";" + "SslMode=None;";

            connection = new MySqlConnection(connectionstring);

            try
            {
                connection.Open();
                //MessageBox.Show("Sikeres csatlakozás!");
                
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

       
    }
}