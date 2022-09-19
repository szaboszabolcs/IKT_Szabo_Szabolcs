using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serial_Generator
{
    internal class Program
    {
        static void kapcsolodas()
        {
            Connect c = new Connect();
            c.querySelect();
        }

        
        static void Main(string[] args)
        {
            kapcsolodas();
           
        }
    }
}
