using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new CategoryDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private CategoryDAO() { }

        public bool InsertCategory(string name)
        {
            string query = string.Format("insert dbo.FoodCategory ( name ) values (N'{0}')", name);

            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public DataTable GetCategoryForAdmin()
        {
            string query = "Select * from FoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public List<Category> GetListCategory()
        {
            List<Category> listCategory = new List<Category>();

            string query = "Select * from FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category temp = new Category(item);
                listCategory.Add(temp);
            }
            return listCategory;
        }
        public Category GetCategoryById(int id)
        {
            Category category = null;
            string query = "select * from FoodCategory where id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }

    }

}
