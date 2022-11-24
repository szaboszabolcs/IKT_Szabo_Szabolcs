using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Service.DatabaseManager
{
    public class Muveletek: DataConnection, ISQL
    {
        public int Delete(Rekord rekord)
        {
            return 0;
        }

        public int Insert(Rekord rekord)
        {
            return 0;
        }

        public List<Rekord> Select()
        {
            List<Rekord> rekordok = new List<Rekord>();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM login ORDER BY id";

            try
            {
                MySqlConnection connection = DataConnection.connection;
                connection.Open();
                command.Connection = connection;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User egyUser = new User();
                    egyUser.ID = int.Parse(reader["id"].ToString());
                    egyUser.Uname = reader["uname"].ToString();
                    egyUser.Email = reader["email"].ToString();
                    egyUser.Password = reader["pwd"].ToString();
                    egyUser.Fullname = reader["fullname"].ToString();
                    egyUser.Active = byte.Parse(reader["active"].ToString());
                    egyUser.Rank = int.Parse(reader["rank"].ToString());
                    egyUser.Banned = bool.Parse(reader["ban"].ToString().ToLower());
                    egyUser.Reg_Time = DateTime.Parse(reader["reg_time"].ToString());
                    egyUser.Log_Time = DateTime.Parse(reader["log_time"].ToString());
                    rekordok.Add(egyUser);
                }
            }
            catch (Exception ex)
            {
                User egyUser = new User();
                egyUser.Uname = ex.Message;
                rekordok.Add(egyUser);
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return rekordok;
        }

        public int Update(Rekord rekord)
        {
            return 0;
        }
    }
}