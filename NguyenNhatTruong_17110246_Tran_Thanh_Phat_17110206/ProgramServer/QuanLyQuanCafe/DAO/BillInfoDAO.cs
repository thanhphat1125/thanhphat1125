using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillInfoDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            string query = "select * from dbo.BillInfo where idBill =";

            DataTable data = DataProvider.Instance.ExecuteQuery(query + id);
            foreach (DataRow item in data.Rows)
            {
                BillInfo billinfo = new BillInfo(item);
                listBillInfo.Add(billinfo);
            }

            return listBillInfo;
        }

        public void DeleteBillInfoByIdFood(int idFood)
        {
            string query = "delete from dbo.BillInfo where idFood = " + idFood;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBillInfo @idBill , @idFood , @count ", new object[] { idBill, idFood, count });
        }
    }
}
