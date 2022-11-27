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
        public static List<User> userLista = new List<User>();
        Random random = new Random();

        public static HashSet<int> userIndex = new HashSet<int>(); // ID ide kerül //

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

        public User EgyUserGetCS()
        {
            User user = new User();
            user.ID = 1;
            user.Uname = "minta123";
            user.Email = "minta@minta.com";
            user.Password = "-";
            user.Fullname = "Minta Péter";
            user.Active = 1;
            user.Rank = 0;
            user.Banned = false;
            return user;
        }

        public User EgyUserGet()
        {
            return EgyUserGetCS();
        }

    }
}
