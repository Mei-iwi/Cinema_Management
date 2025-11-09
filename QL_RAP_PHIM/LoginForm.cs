using System;
using System.Windows.Forms;

namespace QL_RAP_PHIM
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isLoginSuccessful = LoginDAL.CheckLogin(username, password);

            if (isLoginSuccessful)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng. Vui lòng thử lại.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}