using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{

    public partial class fAccount : Form
    {
        
        private Account loginAccount;
        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;
                changeAccount(loginAccount);
            }
        }
        #region Transfer
        public fAccount(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }
        #endregion

        #region methods
        void changeAccount(Account acc)
        {
            txbUserName.Text = loginAccount.UserName;
            txbDisplayName.Text = loginAccount.DisplayName;
        }

        void UpdateAccount()
        {
            string displayName = txbDisplayName.Text;
            string passWord = txbPassWord.Text;
            string newPassWord = txbNewPassword.Text;
            string reEnterPass = txbReEnterPassword.Text;
            string userName = txbUserName.Text;

            if (!newPassWord.Equals(reEnterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu mới, với 2 lần giống nhau", "Cập nhật thất bại");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, passWord, newPassWord))
                {
                    MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Cập nhật thành công",MessageBoxButtons.OK);
                    if (updateAccountt != null)
                    {
                        updateAccountt(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra và nhập lại mật khẩu", "Cập nhật thất bại");
                }
            }
        }
        #endregion

        #region events
        private event EventHandler<AccountEvent> updateAccountt;
        public event EventHandler<AccountEvent> UpdateAccounttt
        {
            add { updateAccountt += value; }
            remove { updateAccountt -= value; }
        }


       
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            UpdateAccount();
        }

        #endregion

        private void fAccount_Load(object sender, EventArgs e)
        {
            //load Account

            DataTable tableAc = AccountDAO.Instance.getAccount(Globals.GlobalsUserName);
            txbUserName.Text = tableAc.Rows[0][0].ToString();
            txbDisplayName.Text = tableAc.Rows[0][1].ToString();
            txbPassWord.Text = tableAc.Rows[0][2].ToString();
            //load Member
            Member member = new Member();
            DataTable tableMem = member.getMemberForUsername(Globals.GlobalsUserName);
            if (tableMem.Rows.Count > 0)
            {
                txtId.Text = tableMem.Rows[0][0].ToString();
                txtFirstname.Text = tableMem.Rows[0][1].ToString();
                txtLastname.Text = tableMem.Rows[0][2].ToString();
                if ((tableMem.Rows[0][3].ToString() == "Female"))
                {
                    radioButtonFemale.Checked = true;
                }
                else
                    radioButtonMale.Checked = true;
                dateTimePicker1.Value = Convert.ToDateTime(tableMem.Rows[0][4].ToString());
                txtAddress.Text = tableMem.Rows[0][5].ToString();
                txtPhone.Text = tableMem.Rows[0][6].ToString();
                byte[] pic;
                pic = (byte[])tableMem.Rows[0][7];
                MemoryStream picture = new MemoryStream(pic);
                pictureBoxMember.Image = Image.FromStream(picture);
            }
        
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
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
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            Member member = new Member();
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get
            {
                return acc;
            }

            set
            {
                acc = value;
            }
        }
        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
