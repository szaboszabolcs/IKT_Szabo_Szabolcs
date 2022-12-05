using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Service_WCF
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


        // Adatbázisból lekérdezés //


        public List<User> UserListaDB()
        {
            List<User> userList = new List<User>();
            AdatbazisKezelese.ISQL tableUserKezeles = new AdatbazisKezelese.UserKezeles();
            List<Rekord> rekordok = tableUserKezeles.Select();
            foreach (Rekord egyRekord in rekordok)
            {
                if (egyRekord is User)
                {
                    userList.Add(egyRekord as User);
                }
            }
            return userList;
        }


      


        // Hozzáadás Adatbázisban //
        public string UserPostDB(User user)
        {
            AdatbazisKezelese.UserKezeles tableUserKezeles = new AdatbazisKezelese.UserKezeles();
            if (tableUserKezeles.Insert(user) > 0)
            {
                return "A felhasználó adatainak a tárolása megtörtént.";

            }
            else
            {
                return "A felhasználó adatainak a tárolása sikertelen!";
            }
        }

        public string UserPostDBCS(User user)
        {
            return UserPostDB(user);
        }


        // Módosítás adatbázisban //

        public string UserPutDB(User user)
        {
            AdatbazisKezelese.UserKezeles tableUserKezeles = new AdatbazisKezelese.UserKezeles();
            if (tableUserKezeles.Update(user) > 0)
            {
                return "A felhasználó adatainak módosítása megtörtént.";
            }
            else
            {
                return "A felhasználó adatainak a módosítása sikertelen!";
            }
        }

        public string UserPutDBCS(User user)
        {
            return UserPostDB(user);
        }


        // Törlés adatbázisban //

        public string UserDeleteDB(int id)
        {
            AdatbazisKezelese.UserKezeles tableUserKezeles = new AdatbazisKezelese.UserKezeles();
            if (tableUserKezeles.Delete(id) <= 0)
            {
                
                return "A felhasználó adatainak törlése sikertelen!";
            }
            else
            {
                return "A felhasználó adatainak törlése megtörtént.";
            }
        }

        public string UserDeleteDBCS(int id)
        {
            return UserDeleteDB(id);
        }


       

        public User EgyUserPostCS()
        {
            User user = new User();
            user.ID = 1;
            user.Uname = "minta124";
            user.Email = "minta2@minta2.com";
            user.Password = "a";
            user.Fullname = "Gipsz József";
            user.Active = 0;
            user.Rank = 1;
            user.Banned = false;
            user.Reg_Time = DateTime.Now;
            user.Log_Time = DateTime.Now;
            return user;
        }

        public User EgyUserPost()
        {
            return EgyUserPostCS();
        }


        public List<User> UsersListaja()
        {
            return userLista;
        }

        public List<User> UserListajaCS()
        {
            return UsersListaja();
        }

        public string EgyUserAddCS(User user)
        {
            if (user != null && user.ID != null)
            {
                int id = (int)user.ID;
                if (!userIndex.Contains(id))
                {
                    userLista.Add(user);
                    userIndex.Add(id);
                    return "Adat hozzáadása sikeres.";
                }
            }
            return "Az adat hozzáadása sikertelen!";
        }

        public string EgyUserAdd(User user)
        {
            Console.WriteLine(user);
            return EgyUserAddCS(user);
        }

        public string EgyUserPutCS(User user)
        {
            if (user != null && user.ID != null)
            {
                int id = (int)user.ID;
                if (userIndex.Contains(id))
                {
                    int index = Pozicio(id);
                    if (index != -1)
                    {
                        userLista[index] = user;
                        return "Adat módosítása sikeres.";
                    }
                }
            }
            return "Adatok módosítása sikertelen!";
        }

        public string EgyUserPut(User user)
        {
            return EgyUserPutCS(user);
        }

        public string EgyUserDeleteCS(int ID)
        {
            if (ID != 0)
            {
                int id = (int)ID;
                if (userIndex.Contains(id))
                {
                    int index = Pozicio(id);
                    if (index != -1)
                    {
                        userLista.RemoveAt(index);
                        userIndex.Remove(id);
                        return "Adat törlése sikeres.";
                    }
                }
            }
            return "Adatok törlése sikertelen";
        }

        public string EgyUserDelete(int ID)
        {
            return EgyUserDeleteCS(ID);
        }

        public string EgyUserDeleteID(int ID)
        {
            return EgyUserDeleteCS(ID);
        }
    }
}
