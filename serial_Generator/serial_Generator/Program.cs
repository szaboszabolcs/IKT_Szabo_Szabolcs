using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serial_Generator
{
    internal class Program
    {
        static void adatbazisMuveletek()
        {
            int id;

            Connect c = new Connect();
            c.querySelect();
            Console.Write("Válassz id-t amit törölni akarsz: ");
            id = int.Parse(Console.ReadLine());

            c.queryDelete(id);

            c.querySelect();

        }

        
        static void Main(string[] args)
        {
            adatbazisMuveletek();
           
        }
    }
}
