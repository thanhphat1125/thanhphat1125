using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using Microsoft.Office.Interop.Excel;





namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        #region AvailableForTrans
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        public Account loginAccount;
        #endregion

        Member member = new Member();
        public fAdmin()
        {
            InitializeComponent();
            LoadMethods();
        }
        #region methods
        void LoadMethods()
        {
            dtgvFoods.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            dtgvCaregory.DataSource = categoryList;
            dtgvTables.DataSource = tableList;

            loadDateTimePickerBill();
            loadListFood();
            addFoodBinding();
            loadListBillByDate(dtpkFromDay.Value, dtpkToDay.Value);
            loadCategoryIntoCombox(cbCaregoryFood);
            loadAllPrice(dtpkFromDay.Value, dtpkToDay.Value);
            LoadAccount();
            addAccountBinding();
            loadCategory();
            listCategoryBinding();
            loadListTable();
        }

        void loadListTable()
        {
            tableList.DataSource = TableLoadDAO.Instance.getTableForAdmin();
        }
        void addAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void listCategoryBinding()
        {
            txbNameCaregory.DataBindings.Add(new Binding("Text", dtgvCaregory.DataSource, "name", true, DataSourceUpdateMode.Never));
            txbIdCaregory.DataBindings.Add(new Binding("Text", dtgvCaregory.DataSource, "id", true, DataSourceUpdateMode.Never));
        }
        void loadCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetCategoryForAdmin();
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void loadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void loadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBills.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        void loadAllPrice(DateTime checkIn, DateTime checkOut)
        {
            float allPrice = BillDAO.Instance.GetAllPrice(checkIn, checkOut);
            CultureInfo culture = new CultureInfo("vi-VN");
            txbAllPrice.Text = allPrice.ToString("c", culture);
        }
        void loadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDay.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDay.Value = dtpkFromDay.Value.AddMonths(1).AddDays(-1);
        }
        void addFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFoods.DataSource, "name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFoods.DataSource, "ID", true, DataSourceUpdateMode.Never));
            numericSearchFood.DataBindings.Add(new Binding("Value", dtgvFoods.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void loadCategoryIntoCombox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "name";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Food> SearchFoodByName(string nameFood)
        {
            List<Food> listFood = null;

            listFood = FoodDAO.Instance.SearchFoodByName(nameFood);

            return listFood;
        }
        void AddAccount(string userName, string displayName, int type)
        {
            try
            {
                if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
                {
                    MessageBox.Show("Mật khẩu mặc định là:  1503", "Thêm thành công");
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại", "Thất bại");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm tài khoản thất bại\n Tài khoản đã tồn tại", "Thất bại");
                return;
            }


            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            try
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
                {
                    MessageBox.Show("Cập nhật tài khoản thành công", "Thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật tài khoản thất bại", "Thất bại");
                }
            }
            catch (Exception)
            {
                return;
            }
            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Không thể xóa tài khoản đang dùng để đăng nhập", "Thất bại");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công", "Thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại", "Thất bại");
            }

            LoadAccount();
        }

        void addCategory(string name)
        {
            try
            {
                if (CategoryDAO.Instance.InsertCategory(name))
                {
                    MessageBox.Show("Thêm Loại món ăn thành công", "Thành công");
                }
                else
                {
                    MessageBox.Show("Thêm loại món ăn thất bại", "Thất bại");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm loại món ăn thất bại", "Thất bại");
            }
            loadCategory();
        }
        void addTable(string name)
        {
            try
            {
                if (TableLoadDAO.Instance.INsertTable(name))
                {
                    MessageBox.Show("Thêm Loại món ăn thành công", "Thành công");
                }
                else
                {
                    MessageBox.Show("Thêm loại món ăn thất bại", "Thất bại");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm loại món ăn thất bại", "Thất bại");
            }
        }
        #endregion

        #region events

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            addCategory(txbNameCaregory.Text);
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;
            AddAccount(userName, displayName, type);
            Refresh();
        }
        private void txbSearchFoodName_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSearchFood_Click(this, new EventArgs());
        }
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;
           
            EditAccount(userName, displayName, type);
            Refresh();
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
           
            DeleteAccount(userName);
            Refresh();
        }
        private void btnViewBills_Click(object sender, EventArgs e)
        {
            loadListBillByDate(dtpkFromDay.Value, dtpkToDay.Value);
            loadAllPrice(dtpkFromDay.Value, dtpkToDay.Value);
        }
        private void btnShowFoods_Click(object sender, EventArgs e)
        {
            loadListFood();
        }
        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            if (dtgvFoods.SelectedCells.Count > 0)
            {
                try
                {
                    int id = (int)dtgvFoods.SelectedCells[0].OwningRow.Cells["idCategory"].Value;

                    Category cateogory = CategoryDAO.Instance.GetCategoryById(id);

                    cbCaregoryFood.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbCaregoryFood.Items)
                    {
                        if (item.Id == cateogory.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbCaregoryFood.SelectedIndex = index;
                }
                catch (Exception)
                {
                    return;
                }

            }
        }
        private void btnAddFoods_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbCaregoryFood.SelectedItem as Category).Id;
            float price = (float)numericSearchFood.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công", "Thành công");
                loadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm món thất bại", "Thất bại");
            }
        }
        private void btnEditFoods_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbCaregoryFood.SelectedItem as Category).Id;
            float price = (float)numericSearchFood.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công", "Thành công");
                loadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Sửa món thất bại", "Thất bại");
            }
        }
        private void btnDeleteFoods_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công", "Thành công");
                loadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa món thất bại", "Thất bại");
            }
        }
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }

        #endregion

        #region Create events
        private event EventHandler updateFood;
        private event EventHandler insertFood;
        private event EventHandler deleteFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }









        #endregion
        private void fAdmin_Load(object sender, EventArgs e)
        {
            MY_DB myDB = new MY_DB();
            SqlCommand command = new SqlCommand("select Id, FirstName, LastName, Gender, BirthDate, Address, Phone , Picture, username  from Member", myDB.getConnection);
            SqlDataAdapter adap = new SqlDataAdapter(command);
            System.Data.DataTable table = new System.Data.DataTable();
            adap.Fill(table);

            dataGridViewNhansu.DataSource = table;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)dataGridViewNhansu.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewNhansu.RowTemplate.Height = 60;

            comboBox1.DataSource = AccountDAO.Instance.GetAccountNoMember();
            comboBox1.DisplayMember = "userName";
            comboBox1.ValueMember = "userName";
            comboBox1.SelectedItem = null;
        }
        private void dataGridViewNhansu_Click(object sender, EventArgs e)
        {

            dataGridViewNhansu.RowTemplate.Height = 80;
            txtId.Text = dataGridViewNhansu.CurrentRow.Cells[0].Value.ToString();
            txtFirstname.Text = dataGridViewNhansu.CurrentRow.Cells[1].Value.ToString();
            txtLastname.Text = dataGridViewNhansu.CurrentRow.Cells[2].Value.ToString();
            if ((dataGridViewNhansu.CurrentRow.Cells[3].Value.ToString() == "Female"))
            {
                radioButtonFemale.Checked = true;
            }
            else
                radioButtonMale.Checked = true;
            dateTimePicker1.Value = (DateTime)dataGridViewNhansu.CurrentRow.Cells[4].Value;
            txtAddress.Text = dataGridViewNhansu.CurrentRow.Cells[5].Value.ToString();
            txtPhone.Text = dataGridViewNhansu.CurrentRow.Cells[6].Value.ToString();
            byte[] pic;
            pic = (byte[])dataGridViewNhansu.CurrentRow.Cells[7].Value;

            MemoryStream picture = new MemoryStream(pic);
            pictureBoxMember.Image = Image.FromStream(picture);

            comboBox1.Text = dataGridViewNhansu.CurrentRow.Cells[8].Value.ToString();


        }
        bool verif()
        {
            if ((txtFirstname.Text.Trim() == "") || (txtLastname.Text.Trim() == "") || (txtAddress.Text.Trim() == "") || (txtPhone.Text.Trim() == "") || (pictureBoxMember.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string fname = txtFirstname.Text;
            string lname = txtLastname.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = txtPhone.Text;
            string adrs = txtAddress.Text;
            string gender = "Male";

            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();

            if (verif())
            {
                pictureBoxMember.Image.Save(pic, pictureBoxMember.Image.RawFormat);
                if (member.UpdateMember(id, fname, lname, gender, bdate, adrs, phone, pic))
                {
                    Refresh();
                    Clear();
                    MessageBox.Show("Sửa thông tin thành công");
                }
                else
                {
                    MessageBox.Show("Error", "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Refresh()
        {
                MY_DB myDB = new MY_DB();
                SqlCommand command = new SqlCommand("select Id, FirstName, LastName, Gender, BirthDate, Address, Phone , Picture, username  from Member", myDB.getConnection);
                SqlDataAdapter adap = new SqlDataAdapter(command);
                System.Data.DataTable table = new System.Data.DataTable();
                adap.Fill(table);

                dataGridViewNhansu.DataSource = table;
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                picCol = (DataGridViewImageColumn)dataGridViewNhansu.Columns[7];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridViewNhansu.RowTemplate.Height = 60;

                comboBox1.DataSource = AccountDAO.Instance.GetAccountNoMember();
                comboBox1.DisplayMember = "userName";
                comboBox1.ValueMember = "userName";
                comboBox1.SelectedItem = null;
            
        }
        private void Clear()
        {
            txtId.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            comboBox1.Text = "";
            pictureBoxMember.Image = null;
            dateTimePicker1.Value = DateTime.Now;
        }
        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pictureBoxMember.Image = Image.FromFile(opf.FileName);
            }
        }
        private void buttonAddMember_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            string fname = txtFirstname.Text;
            string lname = txtLastname.Text;
            DateTime bdate = dateTimePicker1.Value;
            string phone = txtPhone.Text;
            string adrs = txtAddress.Text;
            string gender = "Male";
            string username = (string) comboBox1.SelectedValue;
            if (radioButtonFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();

            if (verif())
            {
                pictureBoxMember.Image.Save(pic, pictureBoxMember.Image.RawFormat);
                if (AccountDAO.Instance.GetAccountByUserName(username)!=null)
                {
                    if (member.InsertMember(id, fname, lname, gender, bdate, adrs, phone, pic, username))
                    {
                        Refresh();
                        Clear();
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Error", "Add Member", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc chưa tạo tài khoản!");
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteMember_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            if (verif())
            {
                
                if(member.DeleteMember(id))
                {
                    Refresh();
                    Clear();
                    MessageBox.Show("Đã xóa!");
                }
                else
                {
                    MessageBox.Show("Error", "Delete Member", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Delete Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butSearchFoodBestSell_Click(object sender, EventArgs e)
        {
            fSearchFood form = new fSearchFood();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        
    }
}