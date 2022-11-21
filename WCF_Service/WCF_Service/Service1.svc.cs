using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Service
{
    public class Service1 : IService1
    {
        public static List<User> usersLista = new List<User>();
        Random random = new Random();

        public static HashSet<int> usersIndex = new HashSet<int>(); // ide kerül az id //


        public static int Pozicio(int id)
        {
            int index = 0;
            int sorSzama = usersLista.Count;
            while (index < sorSzama)
            {
                if (usersLista[index].ID == id)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        // Lekérés adatbázisból //

        public List<User> UserLista()
        {
            List<User> userlist  = new List<User>();
            DatabaseManager.ISQL tableCustomerManager = new DatabaseManager.Muveletek();
            List<Rekord> rekordok = tableCustomerManager.Select();
            foreach (Rekord egyRekord in rekordok)
            {
                if (egyRekord is Rekord)
                {
                    userlist.Add(egyRekord as User);
                }
            }
            return userlist;
        }
    }
}
