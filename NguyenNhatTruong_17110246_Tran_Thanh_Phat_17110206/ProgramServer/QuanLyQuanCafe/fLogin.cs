using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            loadPicture();
     
            
        }
        #region Methods
        void loadPicture()
        {
            string path = Application.StartupPath;
            
            //this.pbLogoCoffee.Image = new Bitmap(Application.StartupPath + "\\Resources\\iconpng.png");
            
       
        }

        private bool checkLogin(string userName, string passWord)
        {
            return AccountDAO.Instance.checkLogin(userName, passWord);
        }
        #endregion

        #region Event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (txbUserName.Text == "" || txbPassWord.Text=="" )
            {
                MessageBox.Show("Vui lòng điền đầy đủ tên đăng nhập và mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (checkLogin(userName, passWord))
                    {
                        Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);

                        fTableManager fT = new fTableManager(loginAccount);
                        this.Hide();
                        fT.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai Tên đăng nhập hoặc Mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Sai Tên đăng nhập hoặc Mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình không?", "Thoát", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        #endregion

    }
}
