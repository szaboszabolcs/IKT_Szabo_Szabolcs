using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel.Channels;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Service_WCF.AdatbazisKezelese
{
    public class UserKezeles : Kapcsolat, ISQL
    {
        public List<Rekord> Select()
        {
            List<Rekord> rekordok = new List<Rekord>();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM users";

            try
            {
                MySqlConnection connection = Kapcsolat.connection;
                connection.Open();
                command.Connection = connection;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User egyUser = new User();
                    egyUser.ID = reader.GetInt32("ID");
                    egyUser.Uname =reader.GetString("uname");
                    egyUser.Email = reader.GetString("email");
                    egyUser.Password = reader.GetString("pwd");
                    egyUser.Fullname = reader.GetString("fullname");
                    egyUser.Active = reader.GetByte("active");
                    egyUser.Rank = reader.GetInt32("rank");
                    egyUser.Banned = reader.GetBoolean("ban");
                    egyUser.Reg_Time = reader.GetDateTime("reg_time");
                    egyUser.Log_Time = reader.GetDateTime("log_time");
                    rekordok.Add(egyUser);
                    /*egyUser.ID = 0;
                    egyUser.Uname = "sdfs";
                    egyUser.Password = "sdfs";
                    egyUser.Email = "dlvmds";
                    egyUser.Fullname = "dlvmds";
                    egyUser.Rank = 0;
                    egyUser.Active = 0;
                    egyUser.Banned = true;
                    egyUser.Reg_Time = DateTime.Now;
                    egyUser.Log_Time = DateTime.Now;
                    rekordok.Add(egyUser);*/
                }

            }
            catch (Exception ex)
            {
                User egyUser = new User();
                egyUser.Uname = ex.Message;
                rekordok.Add(egyUser);
            }
            finally
            {
                connection.Close();
            }
            return rekordok;
        }

        // Login végponthoz //

        /*public User getUsers(string uname, string pwd)
        {

            try
            {
                string qry = "SELECT * FROM `users` WHERE uname=@uname AND pwd=@pwd";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Kapcsolat.connection;
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                cmd.CommandText = qry;

                MySqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                User users = new User();

                users.ID = dr.GetInt32(0);
                users.Uname = dr.GetString(1);
                users.Email = dr.GetString(2);
                users.Password = dr.GetString(3);
                users.Fullname = dr.GetString(4);
                users.Active = dr.GetByte(5);
                users.Rank = dr.GetInt32(6);
                users.Banned = dr.GetBoolean(7);


                dr.Close();
                return users;
            }
            catch (Exception)
            {
                throw;
            }

        }*/


        public int Insert(Rekord rekord)
        {
           

            try
            {
                User user = rekord as User;
                MySqlConnection connection = Kapcsolat.connection;
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO users (Uname,Email,Password,Fullname,Active,Rank,Banned,Reg_Time,Log_Time) VALUES (@uname,@email,@pwd,@fullname,@active,@rank,@ban,@reg_time,@log_time)");
                cmd.Parameters.AddWithValue("@uname", user.Uname);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@pwd", user.Password);
                cmd.Parameters.AddWithValue("@fullname", user.Fullname);
                cmd.Parameters.AddWithValue("@active", user.Active);
                cmd.Parameters.AddWithValue("@rank", user.Rank);
                cmd.Parameters.AddWithValue("@ban", user.Banned);
                cmd.Parameters.AddWithValue("reg_time", user.Reg_Time);
                cmd.Parameters.AddWithValue("log_time", user.Log_Time);
                int hozzaAdottSorokSzama = 0;
                cmd.Connection = Kapcsolat.connection;
                try
                {
                    cmd.Connection.Open();
                    try
                    {
                        hozzaAdottSorokSzama = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Nem tudta megnyitni!");
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cmd.Connection.Close();
                }
                cmd.Parameters.Clear();
                return hozzaAdottSorokSzama;
            }
            catch
            {

                return 0;
            }
            

                /*User user = rekord as User;
                MySqlCommand command = new MySqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"INSERT INTO users (Uname,Email,Password,Fullname,Active,Rank,Banned,Reg_Time,Log_Time) VALUES (@uname,@email,@pwd,@fullname,@active,@rank,@ban,@reg_time,@log_time);";
                command.Parameters.Add(new MySqlParameter("@uname", MySqlDbType.VarChar)).Value = user.Uname;
                command.Parameters.Add(new MySqlParameter("@email", MySqlDbType.VarChar)).Value = user.Email;
                command.Parameters.Add(new MySqlParameter("@pwd", MySqlDbType.VarChar)).Value = user.Password;
                command.Parameters.Add(new MySqlParameter("@fullname", MySqlDbType.VarChar)).Value = user.Fullname;
                command.Parameters.Add(new MySqlParameter("@active", MySqlDbType.Byte)).Value = user.Active;
                command.Parameters.Add(new MySqlParameter("@rank", MySqlDbType.Int32)).Value = user.Active;
                command.Parameters.Add(new MySqlParameter("@ban", MySqlDbType.Bit)).Value = user.Banned;
                command.Parameters.Add(new MySqlParameter("@reg_time", MySqlDbType.DateTime)).Value = user.Reg_Time;
                command.Parameters.Add(new MySqlParameter("@log_time", MySqlDbType.DateTime)).Value = user.Log_Time;
                
                command.Parameters.AddWithValue("@uname", user.Uname);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@pwd", user.Password);
                command.Parameters.AddWithValue("@fullname", user.Fullname);
                command.Parameters.AddWithValue("@active", user.Active);
                command.Parameters.AddWithValue("@rank", user.Rank);
                command.Parameters.AddWithValue("@ban", user.Banned);
                command.Parameters.AddWithValue("@reg_time", user.Reg_Time);
                command.Parameters.AddWithValue("log_time", user.Log_Time);*/
               
        }
         

        public int Update(Rekord rekord)
        {
            try
            {
                User user = rekord as User;
                MySqlCommand command = new MySqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"UPDATE users SET Uname=@uname, Email=@email, Password=@pwd, Fullname=@fullname, Active=@active, Rank=@rank, Banned=@ban, Reg_Time=@reg_time, Log_Time=@log_time WHERE id=@id";
                command.Parameters.AddWithValue("@uname", user.Uname);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@pwd", user.Password);
                command.Parameters.AddWithValue("@fullname", user.Fullname);
                command.Parameters.AddWithValue("@active", user.Active);
                command.Parameters.AddWithValue("@rank", user.Rank);
                command.Parameters.AddWithValue("@ban", user.Banned);
                command.Parameters.AddWithValue("@reg_time", user.Reg_Time);
                command.Parameters.AddWithValue("@log_time", user.Log_Time);
                int modositottSorokSzama = 0;
                command.Connection = AdatbazisKezelese.connection;
                try
                {
                    command.Connection.Open();
                    try
                    {
                        modositottSorokSzama = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Nem tudta módosítani!");
                        Console.WriteLine(ex.Message);
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Nem tudta megnyitni!");
                    Console.WriteLine(ex.Message);
                    return -2;
                }
                finally
                {
                    command.Connection.Close();
                }
                command.Parameters.Clear();
                return modositottSorokSzama;
            }
            catch
            {

                return 0;
            }

        }
  
        public int Delete(int id)
        {
            try
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = @"DELETE FROM users WHERE id=@id";
                command.Parameters.Add(new MySqlParameter("id", id));
                command.Connection = Kapcsolat.connection;

                command.Connection.Open();
                int toroltSorokSzama = command.ExecuteNonQuery();
                command.Connection.Close();

                return toroltSorokSzama;
            }
            catch
            {
                return 0;
            }
        }
    }
}