using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment_wcf.DatabaseManager
{
    public interface IDML 
    {
        int Insert(Sor sor);

        int Update(Sor sor);

        int Delete(int id);
    }
}