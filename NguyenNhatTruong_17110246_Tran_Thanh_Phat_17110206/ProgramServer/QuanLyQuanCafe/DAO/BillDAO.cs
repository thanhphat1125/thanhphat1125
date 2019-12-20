using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public BillDAO() { }
        /// <summary>
        /// Success return Bill ID,
        /// Fail return -1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Bill where  idTable = " + id + " and status = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_INsertBill @idTable", new object[] { id });
        }
        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut ", new object[] { checkIn, checkOut });
        }
        public float GetAllPrice(DateTime checkIn, DateTime checkOut)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("exec USP_GetAllPrice @checkIn , @checkOut ", new object[] { checkIn, checkOut });
            try
            {
                return (float)Convert.ToDouble((data.Rows[0])["allPrice"].ToString());
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int GetMaxIDBill()
        {
            try
            {
                int result = (int)DataProvider.Instance.ExecuteScalar("select MAx(id) from Bill");
                return result;
            }
            catch (Exception)
            {
                return 1;
            }

        }
        public void CheckOut(int idBill, int discount, float totalPrice)
        {

            //string query = "update dbo.Bill set DateCheckOut= " + DateTime.Now + ", status = 1 , discount = " + discount + " , totalPrice = " + totalPrice + " where id = " + idBill;
            //DataProvider.Instance.ExecuteNonQuery(query);
            DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateBill @idBill , @discount , @totalprice ", new object[] { idBill, discount, totalPrice });       
           
        }
    }
}
