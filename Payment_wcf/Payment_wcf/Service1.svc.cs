using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

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
        public Customer EgyCustomerGet()
        {
            Customer customer = new Customer();
            customer.ID = 1;
            customer.Nev = "Józsi";
            customer.Varos = "Miskolc";
            Console.WriteLine("Adatok lekérve...");
            return customer;
        }

        public Customer EgyCustomerGetCS()
        {
            return EgyCustomerGet();
        }

        public Customer EgyCustomerPost()
        {
            Customer customer = new Customer();
            customer.ID = random.Next(1, 10001);
            customer.Nev = "Péter";
            customer.Varos = "Budapest";
            customerLista.Add(customer);
            Console.WriteLine("Működik a post");
            return customer;
        }

        public Customer EgyCustomerPostCS()
        {
            return EgyCustomerPost();
        }

        public List<Customer> CustomersListaja()
        {
            Console.WriteLine("Kutyalista lekérve");
            return customerLista;
        }

        public List<Customer> CustomersListajaCS()
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
            return "Az adat hozzáadás sikertelen!";
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
            return "Adatok módosítása sikertelen";
        }

        public string EgyCustomerPut(Customer customer)
        {
            Console.WriteLine(customer);
            return EgyCustomerPutCS(customer);
        }

        public string EgyCustomerPatchCS(Customer customer)
        {
            Console.WriteLine(customer);
            return EgyCustomerPutCS(customer);
        }

        public string EgyCustomerPatch(Customer customer)
        {
            Console.WriteLine(customer);
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

        public Customer EgyCustomerGetIDCS(int ID)
        {
            if (ID != null)
            {
                int id = (int)ID;
                if (customerIndex.Contains(id))
                {
                    int index = Pozicio(id);
                    if (index != -1)
                    {
                        return customerLista[index];
                    }
                }
            }
            return null;
        }

        public Customer EgyCustomerGetID(int ID)
        {
            return EgyCustomerGetIDCS(ID);
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

