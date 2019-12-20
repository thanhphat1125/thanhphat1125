using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status, int discount = 0)
        {
            this.ID = id;
            this.DataCheckIn = dateCheckIn;
            this.DataCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DataCheckIn = (DateTime?)row["DateCheckIn"];

            var dateCheckOut = row["DateCheckOut"];
            if (dataCheckOut.ToString() != "")
                this.DataCheckOut = (DateTime?)dataCheckOut;

            this.Status = (int)row["status"];
            if (row["discount"] == null)
                this.Discount = 0;
        }

        private int status;
        private DateTime? dataCheckOut;
        private DateTime? dataCheckIn;
        private int iD;
        private int discount;

        public DateTime? DataCheckIn
        {
            get
            {
                return dataCheckIn;
            }

            set
            {
                dataCheckIn = value;
            }
        }

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

        public DateTime? DataCheckOut
        {
            get
            {
                return dataCheckOut;
            }

            set
            {
                dataCheckOut = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }
    }
}
