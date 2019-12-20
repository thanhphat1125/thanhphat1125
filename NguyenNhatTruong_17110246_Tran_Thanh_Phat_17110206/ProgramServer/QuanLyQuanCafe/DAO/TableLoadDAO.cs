using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableLoadDAO
    {
        private static TableLoadDAO instance;
        public static TableLoadDAO Instance
        {
            get
            {
                if (instance == null) instance = new TableLoadDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private TableLoadDAO() { }

        public void putTableTogether(int idTable1, int idTable2)
        {
            DataProvider.Instance.ExecuteQuery("USP_PutTableTogether @idTable1 , @idTable2 ", new object[] { idTable1, idTable2 });
        }

        public void switchTable(int idTable1, int idTable2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2 ", new object[] {idTable1, idTable2 });
        }
        public List<Table> loadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow row in data.Rows)
            {
                Table tb = new Table(row);
                tableList.Add(tb);
            }
            return tableList;
        }
        public void UpdateStatusTableWhenNoBillButStatusIsNotNull(int idTable)
        {
            string query = "update dbo.TableFood set statusTable = N'Trống' where TableFood.id = " + idTable;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public bool INsertTable(string name)
        {
            string query = string.Format("Insert dbo.TableFood (nameTable , statusTable) values ( N'{0}' , N'Trống')");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable getTableForAdmin()
        {
            return DataProvider.Instance.ExecuteQuery("select * from TableFood");
        }
    }
}
