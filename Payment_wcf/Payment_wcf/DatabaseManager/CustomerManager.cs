using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment_wcf.DatabaseManager
{
    public class CustomerManager: BaseDatabaseManager, ISQL
    {
        public List<Sor> Select()
        {
            List<Sor> sorok = new List<Sor>();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM customer ORDER BY Name";

            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                command.Connection = connection;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer egyCustomer = new Customer();
                    egyCustomer.ID = int.Parse(reader["Id"].ToString());
                    egyCustomer.Nev= reader["Name"].ToString();
                    egyCustomer.Eletkor = int.Parse(reader["Age"].ToString());
                    egyCustomer.Varos = reader["City"].ToString();
                    sorok.Add(egyCustomer);
                }
            }
            catch (Exception ex)
            {
                Customer egyCustomer = new Customer();
                egyCustomer.Nev = ex.Message;
                sorok.Add(egyCustomer);
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return sorok;
        }

        public int Insert(Sor sor)
        {
            Customer customer = sor as Customer;
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"INSERT INTO customer (Name,Age,City) VALUES (@Name,@Age,@City);";
            command.Parameters.Add(new MySqlParameter("@Name", MySqlDbType.VarChar)).Value = customer.Nev;
            command.Parameters.Add(new MySqlParameter("@Age", MySqlDbType.Byte)).Value = customer.Eletkor;
            command.Parameters.Add(new MySqlParameter("@City", MySqlDbType.VarChar)).Value = customer.Varos;
            int hozzaAdottSorokSzama = 0;
            command.Connection = BaseDatabaseManager.connection;
            try
            {
                command.Connection.Open();
                try
                {
                    hozzaAdottSorokSzama = command.ExecuteNonQuery();
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
                command.Connection.Close();
            }
            command.Parameters.Clear();
            return hozzaAdottSorokSzama;
        }

        public int Update(Sor sor)
        {
            Customer customer = sor as Customer;
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"UPDATE customer SET Name=@Name, Age=@Age, City=@City WHERE Id=@Id";
            command.Parameters.Add(new MySqlParameter("Id", customer.ID));
            command.Parameters.Add(new MySqlParameter("Name", customer.Nev));
            command.Parameters.Add(new MySqlParameter("Age", customer.Eletkor));
            command.Parameters.Add(new MySqlParameter("City", customer.Varos));
            int modositottSorokSzama = 0;
            command.Connection = BaseDatabaseManager.connection;
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

        public int Delete(int id)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"DELETE FROM customer WHERE Id=@Id";
            command.Parameters.Add(new MySqlParameter("Id", id));
            command.Connection = BaseDatabaseManager.connection;
            int toroltSorokSzama = 0;
            try
            {
                command.Connection.Open();
                try
                {
                    toroltSorokSzama = command.ExecuteNonQuery();
                }
                catch
                {
                    return -1;
                }
            }
            catch
            {
                return -2;
            }
            finally
            {
                command.Connection.Close();
            }
            return toroltSorokSzama;
        }
    }
}