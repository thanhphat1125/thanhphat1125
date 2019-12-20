using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDrink
{
    public class DataProvider
    {
        private static DataProvider instance;


        public string connectionStr;
        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider();
                return instance;
            }

            set
            {
                instance = value;
            }
        }
        private DataProvider() { }
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable dtTable = new DataTable();

            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                connect.Open();

                SqlCommand command = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dtTable);
                connect.Close();
            }

            return dtTable;
        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int result = 0;

            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                connect.Open();

                SqlCommand command = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                result = command.ExecuteNonQuery();
                connect.Close();
            }

            return result;
        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object result = 0;

            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                connect.Open();

                SqlCommand command = new SqlCommand(query, connect);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                result = command.ExecuteScalar();
                connect.Close();
            }

            return result;
        }
    }
}
