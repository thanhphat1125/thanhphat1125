using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null) instance = new FoodDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private FoodDAO() { }

        #region Methods
        public List<Food> SearchFoodByName(string name)
        {
            List<Food> list = new List<Food>();

            string query = string.Format("SELECT * FROM dbo.Food WHERE dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }
        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}', idCategory = {1}, price = {2} WHERE id = {3}", name, id, price, idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool InsertFood(string name, int id, float price)
        {
            string query = string.Format("INSERT dbo.Food ( name, idCategory, price ) values  ( N'{0}', {1}, {2})", name, id, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteFood(int idFood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByIdFood(idFood);

            string query = string.Format("Delete Food where id = {0}", idFood);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<Food> GetFoodByCategoryId(int id)
        {
            List<Food> listFood = new List<Food>();

            string query = "select * from Food where idCategory = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food temp = new Food(item);
                listFood.Add(temp);
            }
            return listFood;
        }
        public DataTable GetListFood()
        {
            string query = "exec USP_GetListFood ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;
        }
        #endregion
        public string GetFoodBestSellForDate(DateTime date)
        {
            try
            {
                MY_DB mydb = new MY_DB();

                //string ngay = 
                date.ToShortDateString();

                SqlCommand command = new SqlCommand("SELECT BillInfo.idFood, COUNT(count) AS number FROM BillInfo,Bill where Bill.id = BillInfo.idBill and DateCheckOut = '" +date + "' group by BillInfo.idFood ORDER BY number DESC ", mydb.getConnection);
                //command.Parameters.Add("@date", SqlDbType.NVarChar).Value = ngay;

                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adap.Fill(table);
                int idfood = Convert.ToInt32(table.Rows[0][0].ToString());
                SqlCommand command1 = new SqlCommand("SELECT name FROM Food where id=" + idfood, mydb.getConnection);
                SqlDataAdapter adap1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adap1.Fill(table1);
                string namefood = table1.Rows[0][0].ToString();
                return namefood;
            }
            catch
            {
                string a = "false";
                return a;
            }

        }
        public string GetFoodBestSellForMonthAndYear(DateTime dateStart,DateTime dateEnd)
        {
            try
            {
                MY_DB mydb = new MY_DB();

                dateStart.ToShortDateString();
                dateEnd.ToShortDateString(); 

                SqlCommand command = new SqlCommand("SELECT BillInfo.idFood, COUNT(count) AS number FROM BillInfo,Bill where Bill.id = BillInfo.idBill and DateCheckOut >= '" + dateStart + "' and DateCheckOut <= '"+dateEnd+"' group by BillInfo.idFood ORDER BY number DESC ", mydb.getConnection);
                
                SqlDataAdapter adap = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adap.Fill(table);
                int idfood = Convert.ToInt32(table.Rows[0][0].ToString());
                SqlCommand command1 = new SqlCommand("SELECT name FROM Food where id=" + idfood, mydb.getConnection);
                SqlDataAdapter adap1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adap1.Fill(table1);
                string namefood = table1.Rows[0][0].ToString();
                return namefood;
            }
            catch
            {
                string a = "false";
                return a;
            }

        }
    }
}
