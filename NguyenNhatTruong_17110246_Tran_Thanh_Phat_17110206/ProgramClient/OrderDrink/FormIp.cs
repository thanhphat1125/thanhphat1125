using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderDrink
{
    public partial class FormIp : Form
    {
        public FormIp()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if(txbIp.Text=="")
            {
                MessageBox.Show("Vui lòng nhập Ip");

            }
            else
            {
                DataProvider.Instance.connectionStr = @"Data Source="+txbIp.Text+";Initial Catalog=QuanLyQuanCafe;User ID= demo;Password= 123456";
             
                try
                {
                    using (SqlConnection conn = new SqlConnection(DataProvider.Instance.connectionStr))
                    {
                        conn.Open();
                        conn.Close();
                    }
                    fShowCategory fShowCategory = new fShowCategory();
                    this.Hide();
                    fShowCategory.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Sai địa chỉ Ip");

                }
                
            }
        }
    }
}
