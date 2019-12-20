using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class ShowMenuDAO
    {
        private static ShowMenuDAO instance;

        public static ShowMenuDAO Instance
        {
            get
            {
                if (instance == null) instance = new ShowMenuDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private ShowMenuDAO() { }

        public List<Show> GetShowByIdTable(int id)
        {
            List<Show> listShow = new List<Show>();
            String query = "select f.name, bi.count, f.price, f.price*bi.count as totalPrice from dbo.Bill as b, dbo.BillInfo as bi, dbo.Food as f where bi.idBill = b.id and status =0 and bi.idFood = f.id  and b.idTable = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Show show = new Show(item);
                listShow.Add(show);
            }

            return listShow;
        }
    }
}
