using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_Service.DatabaseManager
{
    internal interface IDQL
    {
        List<Rekord> Select();
    }
}
