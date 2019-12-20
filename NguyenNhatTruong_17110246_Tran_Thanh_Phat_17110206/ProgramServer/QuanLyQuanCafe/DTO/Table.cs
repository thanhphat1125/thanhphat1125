using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Table
    {

        public Table(int id, string name, string status)
        {
            this.ID = id;
            this.NameTable = name;
            this.StatusTable = status;
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.NameTable = row["nameTable"].ToString();
            this.StatusTable = row["statusTable"].ToString();
        }
        public static int width = 90;
        public static int height = 73;

        private string statusTable;
        private string nameTable;
        private int iD;
        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public string NameTable
        {
            get
            {
                return nameTable;
            }

            set
            {
                nameTable = value;
            }
        }

        public string StatusTable
        {
            get
            {
                return statusTable;
            }

            set
            {
                statusTable = value;
            }
        }
    }
}
