using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int idBill, int idFood, int count)
        {
            this.ID = id;
            this.IdBill = idBill;
            this.IdFood = idFood;
            this.Count = count;
        }
        public BillInfo(DataRow Row)
        {
            this.ID = (int)Row["id"];
            this.IdBill = (int)Row["idBill"];
            this.IdFood = (int)Row["idFood"];
            this.Count = (int)Row["count"];
        }

        private int idFood;
        private int count;
        private int idBill;
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

        public int IdBill
        {
            get
            {
                return idBill;
            }

            set
            {
                idBill = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public int IdFood
        {
            get
            {
                return idFood;
            }

            set
            {
                idFood = value;
            }
        }
    }
}
