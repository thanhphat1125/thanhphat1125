using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDrink
{
    class MY_DB
    {
        SqlConnection con = new SqlConnection(DataProvider.Instance.connectionStr);

        public SqlConnection getConnection
        {

            get
            {
                return con;
            }
        }
        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
            {
                con.Close();
            }
        }
    }
}
