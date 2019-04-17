using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace FSTA.DAO
{
    public static class Database
    {
        public static string conString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
    }
}