using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.DAO;
namespace QuanLyQuanCafe
{
    public partial class fSearchFood : Form
    {
        public fSearchFood()
        {
            InitializeComponent();
        }

        private void butSearchDate_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            string food = FoodDAO.Instance.GetFoodBestSellForDate(date);
            if (food == "false")
            {
                MessageBox.Show("Chọn lại thời gian cần tìm","Search",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                labelFood.Text ="Món bán chạy: "+food;
            }
        }

        private void butSearchMonth_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            DateTime dateStart = new DateTime(date.Year, date.Month, 1);
            DateTime dateEnd= dateStart.AddMonths(1).AddDays(-1);

            string food = FoodDAO.Instance.GetFoodBestSellForMonthAndYear(dateStart,dateEnd);
            if (food == "false")
            {
                MessageBox.Show("Chọn lại thời gian cần tìm", "Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                labelFood.Text = "Món bán chạy: " + food;
            }

        }

        private void butSearchYear_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            DateTime dateStart = new DateTime(date.Year, 1, 1);
            DateTime dateEnd = dateStart.AddYears(1).AddDays(-1);

            string food = FoodDAO.Instance.GetFoodBestSellForMonthAndYear(dateStart, dateEnd);
            if (food == "false")
            {
                MessageBox.Show("Chọn lại thời gian cần tìm", "Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                labelFood.Text = "Món bán chạy: " + food;
            }
        }
    }
}
