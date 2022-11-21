using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Service.DatabaseManager
{
    public interface IDML
    {
        int Insert(Rekord rekord);

        int Update(Rekord rekord);

        int Delete(Rekord rekord);
    }
}