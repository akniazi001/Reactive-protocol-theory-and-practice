using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Implementation_of_Reactive_protocol
{
    class db_con
    {
        public static SqlConnection newcon;
       
        public static string ConStr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public static SqlConnection GetConnection()
        {
            newcon = new SqlConnection(ConStr);
            return newcon;
        }
    }
}
