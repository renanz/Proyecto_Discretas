using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PPP
{
    class ConnectionsGetter
    {
        public ConnectionsGetter()
        {

        }

        public static SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=localhost;Initial Catalog=SISTEMA_EVALUADOR;"
                + "User Id=sa;Password=12345;";

            return con;
        }


    }
}
