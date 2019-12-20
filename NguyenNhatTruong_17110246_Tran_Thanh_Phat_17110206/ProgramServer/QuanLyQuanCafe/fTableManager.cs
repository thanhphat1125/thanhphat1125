using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyQuanCafe
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;
        private string command = "select statusTable from dbo.TableFood";
        public fTableManager(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            loadTable();
            loadCaregory();
            loadComboBoxTable(cbSwitchTable);
            loadComboBoxTable(cbPutTogether);
            clsNotification cls = new clsNotification(setData, command);
            cls.loadData();
        }
        #region Variable
        private int IDCategory = 0;
        private float Quantity = 0;
        private int IDFood = 0;
        private float TTP = 0;

        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }
            set
            {
                loginAccount = value;
                changeAccount(loginAccount.Type);
            }
        }
        #endregion

        #region Method
        void changeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = (type == 1);
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Tài khoản: " + LoginAccount.DisplayName + " ";
        }

        void loadTable()
        {
            if (flpTable.InvokeRequired)
            {
                MethodInvoker methodInvoker = new MethodInvoker(loadTable);
                flpTable.Invoke(methodInvoker);
            }
            else
            {
                flpTable.Controls.Clear();
                List<Table> listTable = TableLoadDAO.Instance.loadTableList();
                foreach (Table item in listTable)
                {
                    Button bt = new Button() { Width = Table.width, Height = Table.height };
                    if (item.StatusTable == "trống") item.StatusTable = "Trống";
                    bt.Text = item.NameTable + Environment.NewLine + item.StatusTable;
                    //Show bill by a click on the button:
                    bt.Click += Bt_Click;
                    bt.Tag = item;

                    switch (item.StatusTable)
                    {
                        case "Trống":
                            bt.BackColor = Color.LightBlue;
                            break;
                        case "trống":
                            bt.BackColor = Color.LightBlue;
                            break;
                        default:
                            bt.BackColor = Color.Aqua;
                            break;
                    }
                    flpTable.Controls.Add(bt);
                }
            }
        }
        void ShowBill(int id)
        {
            TTP = 0;
            lvBill.Items.Clear();
            List<Show> listBillInfo = ShowMenuDAO.Instance.GetShowByIdTable(id);
            float totalPrice = 0;

            foreach (Show item in listBillInfo)
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

        void loadCaregory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "name";
        }

        void loadFoodListByCaregoryID(int id)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryId(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "name";
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

        void loadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableLoadDAO.Instance.loadTableList();
            cb.DisplayMember = "nameTable";
        }
        void checKtableStatus(int idTable)
        {
            string query = "exec USP_CheckTableStatus " + idTable;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        #endregion

        #region Events

        private void thôngTinTàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            thôngTinCáNhânToolStripMenuItem_Click(this, new EventArgs());
        }
        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddFood_Click(this, new EventArgs());
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckOut_Click(this, new EventArgs());
        }
        private void Bt_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            ShowBill(tableID);

            lvBill.Tag = (sender as Button).Tag;
            btnTableChooseCurrent.Text = ((sender as Button).Tag as Table).NameTable;

        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccount fA = new fAccount(LoginAccount);

            fA.UpdateAccounttt += f_UpdateAccoubt;

            fA.ShowDialog();

        }

        void f_UpdateAccoubt(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Tài khoản: " + e.Acc.DisplayName + " ";
        }
        private void fTableManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAd = new fAdmin();
            fAd.loginAccount = LoginAccount;
            fAd.InsertFood += FAd_InsertFood;
            fAd.UpdateFood += FAd_UpdateFood;
            fAd.DeleteFood += FAd_DeleteFood;
            fAd.ShowDialog();
        }

        private void FAd_DeleteFood(object sender, EventArgs e)
        {
            loadFoodListByCaregoryID((cbCategory.SelectedItem as Category).Id);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).ID);
            loadTable();
        }

        private void FAd_UpdateFood(object sender, EventArgs e)
        {
            loadFoodListByCaregoryID((cbCategory.SelectedItem as Category).Id);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).ID);
        }

        private void FAd_InsertFood(object sender, EventArgs e)
        {
            loadFoodListByCaregoryID((cbCategory.SelectedItem as Category).Id);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).ID);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category select = cb.SelectedItem as Category;
            id = select.Id;
            IDCategory = id;

            loadFoodListByCaregoryID(id);

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
        private void numericFoodCount_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numUD = sender as NumericUpDown;
            if (numUD == null)
                return;
            Quantity = (float)Convert.ToDouble(nmUDfoodCount.Value.ToString());
            loadPriceOfFood(IDCategory, IDFood);
        }
        /// <summary>
        /// Did this Bill is exist? 
        /// -1 is not -> create Bill, add BillInfo
        /// else is yes -> add BillInfo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table tb = lvBill.Tag as Table;
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
                loadTable();
            }
            catch (Exception)
            {
                return;
            }


        }
        private async void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table tb = lvBill.Tag as Table;
            try
            {
                int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(tb.ID);
                int discount = (int)nmUDdiscount.Value;

                float finalyTotalPrice = TTP - (TTP / 100) * discount;

                if (idBill != -1)
                {
                    
                    if (MessageBox.Show(string.Format("Bạn muốn thanh toán hóa đơn {0}, với mức giảm giá {1}%?", tb.NameTable, discount), "Thanh toán thành công", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        
                        MessageBox.Show(string.Format("Số tiền hóa đơn của {0} sau khi giảm giá {1}% là:\n\n \t\t{2} VND", tb.NameTable, discount, finalyTotalPrice), "Thanh toán thành công", MessageBoxButtons.OK);
                       
                        //exportText(tb.ID);

                        
                        //string saveExcelFile = @"D:\excel_report.xlsx";
                        BillDAO.Instance.CheckOut(idBill, discount, finalyTotalPrice);
                        ShowBill(tb.ID);
                    }
                }
                else
                {
                    if (tb.StatusTable == "Có người")
                    {
                        tb.StatusTable = "Trống";
                        TableLoadDAO.Instance.UpdateStatusTableWhenNoBillButStatusIsNotNull(tb.ID);
                        loadTable();
                    }
                    else
                        return;
                }
                loadTable();
            }
            catch (Exception)
            {

                MessageBox.Show("Bạn cần chọn bàn để thanh toán", "Thanh toán thất bại");
            }

}

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cbSwitchTable.SelectedItem as Table).NameTable == btnTableChooseCurrent.Text)
                {
                    MessageBox.Show("Bạn cần chọn bàn khác " + (cbPutTogether.SelectedItem as Table).NameTable + " để chuyển bàn", "Thao tác chưa đúng");
                }
                else
                {
                    int id1 = (lvBill.Tag as Table).ID;

                    int id2 = (cbSwitchTable.SelectedItem as Table).ID;

                    if (MessageBox.Show(string.Format("Bạn muốn chuyển {0} và {1} cho nhau?", (lvBill.Tag as Table).NameTable, (cbSwitchTable.SelectedItem as Table).NameTable), "Chuyển bàn", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        TableLoadDAO.Instance.switchTable(id1, id2);

                        checKtableStatus(id1);
                        checKtableStatus(id2);

                        loadTable();
                        ShowBill(id1);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnPutTogether_Click(object sender, EventArgs e)
        {
            try
            {
                if ((cbPutTogether.SelectedItem as Table).NameTable == btnTableChooseCurrent.Text)
                {
                    MessageBox.Show("Bạn cần chọn bàn khác "+ (cbPutTogether.SelectedItem as Table).NameTable + " để gộp bàn", "Thao tác chưa đúng");
                }
                else
                {
                    int id1 = (lvBill.Tag as Table).ID;

                    int id2 = (cbPutTogether.SelectedItem as Table).ID;

                    if (MessageBox.Show(string.Format("Bạn muốn gộp {0} vào {1}?", (lvBill.Tag as Table).NameTable, (cbPutTogether.SelectedItem as Table).NameTable), "Gộp bàn", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        TableLoadDAO.Instance.putTableTogether(id1, id2);

                        checKtableStatus(id1);
                        checKtableStatus(id2);

                        loadTable();
                        ShowBill(id1);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Gộp bàn thất bại, hãy gọi nhân viên bảo trì", "Lỗi hệ thống");
            }

        }

        //moi
        private void exportText(int id)
        {

            TextWriter writer = new StreamWriter(@"D:\output.txt");
            writer.WriteLine("-----------Retaurant Bill-----------");

            lvBill.Items.Clear();
            List<Show> listBillInfo = ShowMenuDAO.Instance.GetShowByIdTable(id);
            float totalPrice = 0;

            foreach (Show item in listBillInfo)
            {
                
                writer.WriteLine("---" +item.FoodName.ToString() +" :  "+item.Count.ToString()+"     "+item.Price.ToString()+"       "+item.TotalPrice.ToString());
                 //lvItem.SubItems.Add(item.Count.ToString());
                 //lvItem.SubItems.Add(item.Price.ToString());
                 //lvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;

               
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            string total = totalPrice.ToString("c", culture);
            writer.WriteLine("-------------------------------------");
            writer.WriteLine("                   Tổng: "+total);

            writer.Close();
            MessageBox.Show("File Saved!");
        }


        #endregion

        private void txbTotalPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbSwitchTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void XuatHoaDon_Click(object sender, EventArgs e)
        {
            //using (SaveFileDialog sfd = new SaveFileDialog() { Filter = " Text Document|*.txt", ValidateNames = true })
            {
                int discount = (int)nmUDdiscount.Value;
                float finalyTotalPrice = TTP - (TTP / 100) * discount;
                {
                    using (TextWriter tw = new StreamWriter(@"D:\output.txt"))
                    {

                        await tw.WriteLineAsync(btnTableChooseCurrent.Text);
                        await tw.WriteLineAsync("            Tên món           " + " " + "   Số lượng   "            + " " + "Giá"                 + " " + "  Thành tiền");
                        foreach (ListViewItem item in lvBill.Items)
                        { 
                            await tw.WriteLineAsync(item.SubItems[0].Text+ "    " + item.SubItems[1].Text + "    " + item.SubItems[2].Text + "    " + item.SubItems[3].Text );
                            await tw.WriteLineAsync("--------------------------------------------------------------- ");
                        }
                        await tw.WriteLineAsync("                        Tổng tiền (chưa giảm giá):   "+ txbTotalPrice.Text +"VND");
                        await tw.WriteLineAsync("                   Giảm giá:       " + nmUDdiscount.Text +"%");
                        await tw.WriteLineAsync("                        Tổng tiền (sau giảm giá):   " + finalyTotalPrice +"VND");
                        MessageBox.Show("Hoa don da xuat", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            
        }
        
        //
        private void setData()
        {
            Thread thread = new Thread(loadTable);
            thread.Start();
        }
    }
}
