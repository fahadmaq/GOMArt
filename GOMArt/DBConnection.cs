using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace GOMArt
{
    class DBConnection
    {
        private SqlConnection con = new SqlConnection(@"");

        public SqlConnection GetCon() { return con; }
        public void Open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //con.Close(); }

        }
        public void Close() 
        {
            if (con.State==ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}