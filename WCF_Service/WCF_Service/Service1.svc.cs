using System.Collections.Generic;
using System;
using System.ServiceModel.Web;
using System.Text;


namespace WCF_Service
{

    public class Service1 : IService1
    {
        public static List<User> userLista = new List<User>();
        Random random = new Random();

        public static HashSet<int> userIndex = new HashSet<int>();//ID kerül ide

        public static int Pozicio(int id)
        {
            int index = 0;
            int sorokSzama = userLista.Count;
            while (index < sorokSzama)
            {
                if (userLista[index].ID == id)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        // Adatbázisból lekérdezés //
        public List<User> UserLista()
        {
            List<User> userList = new List<User>();
            DatabaseManager.ISQL tableUserManager = new DatabaseManager.Muveletek();
            List<Rekord> rekordok = tableUserManager.Select();
            foreach (Rekord egyRekord in rekordok)
            {
                if (egyRekord is User)
                {
                    userList.Add(egyRekord as User);
                }
            }
            return userList;
        }
    }
}
