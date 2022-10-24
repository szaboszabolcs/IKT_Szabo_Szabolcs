using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment_wcf.DatabaseManager
{
    internal interface IDQL
    {
        List<Sor> Select();
    }
}