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
        public static List<Customer> customerList = new List<Customer>();
        Random random = new Random();

        public static HashSet<int> customerIndex = new HashSet<int>(); // ID helye

        public static int Helyzet(int id)
        {
            int index = 0;
            int sorSzama = customerList.Count;
            while (index < sorSzama)
            {
                if (customerList[index].ID == id)
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
            customer.Nev = "Gipsz Jakab";
            customer.Varos = "Miskolc";
            Console.WriteLine("Adatok lekérése sikeres.");
            return customer;

        }

        public Customer EgyCustomerGetCS()
        {
            return EgyCustomerGet();
        }

        public Customer EgyCustomerPost()
        {
            Customer customer = new Customer();
            customer.ID = 2;
            customer.Nev = "Minta Péter";
            customer.Varos = "Budapest";
            return customer;

        }

        public Customer EgyCustomerPostCS()
        {
            return EgyCustomerPost();
        }

        public List<Customer> CustomersLista()
        {
            return customerList;
        }

        public List<Customer> CustomersListajaCS()
        {
            return CustomersLista();
        }
    }
}
