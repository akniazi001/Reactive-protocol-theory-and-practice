using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Implementation_of_Reactive_protocol
{
    class DB_access
    {
        SqlConnection conn;
        public DB_access()
        {
          //conn = db_con.GetConnection();
        }
        public void add_User(string name, string pass)
        {
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            SqlCommand newCmd = conn.CreateCommand();
            newCmd.Connection = conn;
            newCmd.CommandType = CommandType.Text;
            newCmd.CommandText = "insert into User_Table values('"+name+"','"+pass+"')";
            newCmd.ExecuteNonQuery();
        }
    }
}
