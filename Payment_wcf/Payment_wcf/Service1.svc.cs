using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace Payment_wcf
{
    
    public class Service1 : IService1
    {
        public static List<Customer> customerLista = new List<Customer>();
        Random random = new Random();

        public static HashSet<int> customerIndex = new HashSet<int>();//ID kerül ide

        public static int Pozicio(int id)
        {
            int index = 0;
            int soroSzama = customerLista.Count;
            while (index < soroSzama)
            {
                if (customerLista[index].ID == id)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        // Adatbázisból lekérdezés //
        public List<Customer> CustomerListaDB()
        {
            List<Customer> customerList = new List<Customer>();
            DatabaseManager.ISQL tableCustomerManager = new DatabaseManager.CustomerManager();
            List<Sor> sorok = tableCustomerManager.Select();
            foreach (Sor egySor in sorok)
            {
                if (egySor is Customer)
                {
                    customerList.Add(egySor as Customer);
                }
            }
            return customerList;
        }

        // Hozzáadás Adatbázisban //
        public string CustomerPostDB(Customer customer)
        {
            DatabaseManager.CustomerManager tableCustomerManager = new DatabaseManager.CustomerManager();
            if (tableCustomerManager.Insert(customer) > 0)
            {
                return "A vásárló adatainak a tárolása sikeresen megtörtént.";
              
            }
            else
            {
                return "A vásárló adatainak a tárolása sikertelen!";
            }
        }

        public string CustomerPostDBCS(Customer customer)
        {
            return CustomerPostDB(customer);
        }

        // Módosítás adatbázisban //

        public string CustomerPutDB(Customer customer)
        {
            DatabaseManager.CustomerManager tableCustomerManager = new DatabaseManager.CustomerManager();
            if (tableCustomerManager.Update(customer) > 0)
            {
                return "A vásárló adatainak a módosítása sikeresen megtörtént.";
            }
            else
            {
                return "A vásárló adatainak a módosítása sikertelen!";
            }
        }

        public string CustomerPutDBCS(Customer customer)
        {
            return CustomerPostDB(customer);
        }

        // Törlés adatbázisban //

        public string CustomerDeleteDB(int id)
        {
            DatabaseManager.CustomerManager tableCustomerManager = new DatabaseManager.CustomerManager();
            if (tableCustomerManager.Delete(id) <= 0)
            {
                return "A vásárló adatainak törlése sikeresen megtörtént.";
            }
            else
            {
                return "A vásárló adatainak törlése sikertelen!";
            }
        }

        public string CustomerDeleteDBCS(int id)
        {
            return CustomerDeleteDB(id);
        }

       
        public Customer EgyCustomerGetCS()
        {
            Customer customer = new Customer();
            customer.ID = 1;
            customer.Nev = "Józsi";
            customer.Eletkor = 35;
            customer.Varos = "Miskolc";
            Console.WriteLine("Adatok lekérve...");
            return customer;
        }

        public Customer EgyCustomerGet()
        {
            return EgyCustomerGetCS();
        }

        public Customer EgyCustomerPostCS()
        {
            Customer customer = new Customer();
            customer.ID = 2;
            customer.Nev = "Péter";
            customer.Eletkor = 35;
            customer.Varos = "Budapest";
            Console.WriteLine("Adatok");
            return customer;
        }

        public Customer EgyCustomerPost()
        {
            return EgyCustomerPostCS();
        }

        public List<Customer> CustomersListaja()
        {
            return customerLista;
        }

        public List<Customer> CustomerListajaCS()
        {
            return CustomersListaja();
        }

        public string EgyCustomerAddCS(Customer customer)
        {
            if (customer != null && customer.ID != null)
            {
                int id = (int)customer.ID;
                if (!customerIndex.Contains(id))
                {
                    customerLista.Add(customer);
                    customerIndex.Add(id);
                    return "Adat hozzáadása sikeres.";
                }
            }
            return "Az adat hozzáadása sikertelen!";
        }

        public string EgyCustomerAdd(Customer customer)
        {
            Console.WriteLine(customer);
            return EgyCustomerAddCS(customer);
        }

        public string EgyCustomerPutCS(Customer customer)
        {
            if (customer != null && customer.ID != null)
            {
                int id = (int)customer.ID;
                if (customerIndex.Contains(id))
                {
                    int index = Pozicio(id);
                    if (index != -1)
                    {
                        customerLista[index] = customer;
                        return "Adat módosítása sikeres.";
                    }
                }
            }
            return "Adatok módosítása sikertelen!";
        }

        public string EgyCustomerPut (Customer customer)
        {
            return EgyCustomerPutCS(customer);
        }

        public string EgyCustomerDeleteCS(int ID)
        {
            if (ID != null)
            {
                int id = (int)ID;
                if (customerIndex.Contains(id))
                {
                    int index = Pozicio(id);
                    if (index != -1)
                    {
                        customerLista.RemoveAt(index);
                        customerIndex.Remove(id);
                        return "Adat törlése sikeres.";
                    }
                }
            }
            return "Adatok törlése sikertelen";
        }

        public string EgyCustomerDelete(int ID)
        {
            return EgyCustomerDeleteCS(ID);
        }

        public string EgyCustomerDeleteID(int ID)
        {
            return EgyCustomerDeleteCS(ID);
        }
    }
}