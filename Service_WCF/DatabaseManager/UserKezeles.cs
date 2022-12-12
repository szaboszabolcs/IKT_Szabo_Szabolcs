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
using System.Web.UI.WebControls;

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
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    User egyUser = new User();
                    egyUser.ID = dr.GetInt32(0);
                    egyUser.Uname = dr.GetString(1);
                    egyUser.Email = dr.GetString(2);
                    egyUser.Password = dr.GetString(3);
                    egyUser.Fullname = dr.GetString(4);
                    egyUser.Active = dr.GetByte(5);
                    egyUser.Rank = dr.GetInt32(6);
                    egyUser.Banned = dr.GetBoolean(7);
                    egyUser.Reg_Time = dr.GetDateTime("reg_time");
                    egyUser.Log_Time = dr.GetDateTime("log_time");

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

        public int Insert(Rekord rekord)
        {
            {
                try
                {
                    User user = rekord as User;
                    string qry = "INSERT INTO `users`(`uname`, `email`, `pwd`, `fullname`, `active`, `rank`, `ban`, `reg_time`, `log_time`) " +
                        "VALUES (@uname, @email, @pwd, @fullname, @active, @rank, @ban, @reg_time, @log_time);";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Kapcsolat.connection;
                    cmd.Parameters.AddWithValue("@uname", user.Uname);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@pwd", user.Password);
                    cmd.Parameters.AddWithValue("@fullname", user.Fullname);
                    cmd.Parameters.AddWithValue("@active", user.Active);
                    cmd.Parameters.AddWithValue("@rank", user.Rank);
                    cmd.Parameters.AddWithValue("@ban", user.Banned);
                    cmd.Parameters.AddWithValue("@reg_time", user.Reg_Time);
                    cmd.Parameters.AddWithValue("@log_time", user.Log_Time);
                    cmd.CommandText = qry;
                    int hozzaAdottSorokSzama = 0;
                    try
                    {
                        cmd.Connection.Open();
                        try
                        {
                            hozzaAdottSorokSzama = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Nem tudta hozzáadni!");
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
            }
        }

        public int Update(Rekord rekord)
        {
            try
            {
                User user = rekord as User;
                string qry = "UPDATE `users` SET `uname`= @uname,`email`= @email,`pwd`= @pwd,`fullname`= @fullname,`active`= @active,`rank`= @rank,`ban`= @ban, `reg_time`=@reg_time, `log_time`=@log_time WHERE ID = @id; ";
                MySqlCommand command = new MySqlCommand();
                command.Connection = Kapcsolat.connection;
                command.Parameters.AddWithValue("@id", user.ID);
                command.Parameters.AddWithValue("@uname", user.Uname);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@pwd", user.Password);
                command.Parameters.AddWithValue("@fullname", user.Fullname);
                command.Parameters.AddWithValue("@active", user.Active);
                command.Parameters.AddWithValue("@rank", user.Rank);
                command.Parameters.AddWithValue("@ban", user.Banned);
                command.Parameters.AddWithValue("@reg_time", user.Reg_Time);
                command.Parameters.AddWithValue("@log_time", user.Log_Time);
                command.CommandText = qry;
                int modositottSorokSzama = 0;
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