using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderDrink
{
    public partial class fShowCategory : Form
    {
        private int IDCategory = 0;
        private int IDFood = 0;
        private float Quantity = 0;
        private static int width = 90;
        private static int height = 73;
        public fShowCategory()
        {
            InitializeComponent();
            loadCategory();
            cbTable.DataSource = TableLoadDAO.Instance.loadTableEmptyList();
            cbTable.DisplayMember = "nameTable";
            lvBill.Tag = cbTable.Tag;
        }
        private void loadCategory()
        {
            flbCategory.Controls.Clear();
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            foreach(var item in listCategory)
            {

                Button bt = new Button() { Width= width , Height =height  };
                bt.Text = item.Name  ;
                bt.Click += Bt_Click;
                bt.Tag = item;
                flbCategory.Controls.Add(bt);
                
            }


        }
        
        private void Bt_Click(object sender, EventArgs e)
        {
            int id = ((sender as Button).Tag as Category).Id;
            FoodDAO foodDAO = new FoodDAO();
            IDCategory = id;
           
            cbFood.DataSource = foodDAO.GetFoodByCategoryId(id);
            cbFood.DisplayMember = "name";
        }
        
      

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            
            Table tb = cbTable.SelectedItem as Table;

            
            if (tb == null)
            {
                MessageBox.Show("Bạn cần chọn bàn để thêm món", "Thêm món thất bại");
                return;
            }
            try
            {
                if (tb == null) return;
                int billID = BillDAO.Instance.GetUncheckBillIDByTableID(tb.ID);

                int newBillID = BillDAO.Instance.GetMaxIDBill();
                int foodID = (cbFood.SelectedItem as Food).Id;
                int count = (int)nmUDfoodCount.Value;

                if (billID == -1)
                {
                    BillDAO.Instance.InsertBill(tb.ID);
                    newBillID = BillDAO.Instance.GetMaxIDBill();
                    BillInfoDAO.Instance.InsertBillInfo(newBillID, foodID, count);
                }
                else
                {
                    BillInfoDAO.Instance.InsertBillInfo(billID, foodID, count);
                }
                ShowBill(tb.ID);
                
            }
            catch (Exception)
            {
                ShowBill(tb.ID);
                return;
            }
            
        }
        void ShowBill(int id)
        {
            float TTP = 0;
            lvBill.Items.Clear();
            List<Show> listBillInfo = ShowMenuDAO.Instance.GetShowByIdTable(id);
            float totalPrice = 0;

            foreach (var item in listBillInfo)
            {
                ListViewItem lvItem = new ListViewItem(item.FoodName.ToString());
                lvItem.SubItems.Add(item.Count.ToString());
                lvItem.SubItems.Add(item.Price.ToString());
                lvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;

                lvBill.Items.Add(lvItem);
            }

            CultureInfo culture = new CultureInfo("vi-VN");

            // Thread.CurrentThread.CurrentCulture = culture;

            txbTotalPrice.Text = totalPrice.ToString("c", culture);
            TTP = totalPrice;
        }

        
        void loadPriceOfFood(int idCategory, int idFood)
        {
            
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryId(idCategory);
            foreach (Food item in listFood)
            {
                if (item.Id == idFood)
                {
                    Quantity = (float)Convert.ToDouble(nmUDfoodCount.Value.ToString());
                    //float a = (float)Convert.ToDouble(numericFoodCount.Value.ToString());
                    CultureInfo culture = new CultureInfo("vi-VN");
                    //Thread.CurrentThread.CurrentCulture = culture;
                    txbPrice.Text = (item.Price * Quantity).ToString("c", culture);

                }
            }
        }

        private void cbFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idFood = 0;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Food select = cb.SelectedItem as Food;
            idFood = select.Id;
            IDFood = idFood;

            loadPriceOfFood(IDCategory, IDFood);
        }

        private void nmUDfoodCount_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numUD = sender as NumericUpDown;
            if (numUD == null)
                return;
            Quantity = (float)Convert.ToDouble(nmUDfoodCount.Value.ToString());
            loadPriceOfFood(IDCategory, IDFood);
        }
    }
}
