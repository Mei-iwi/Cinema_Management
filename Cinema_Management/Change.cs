using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management
{
    public partial class Change : Form
    {
        string userName;
        string str;
        public Change(string userName, string str)
        {
            InitializeComponent();

            txtNewPass.UseSystemPasswordChar = true;
            txtNewPassAgain.UseSystemPasswordChar = true;

            this.userName = userName;
            this.str = str;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                this.Hide();

                Login login = new Login();

                login.Show();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                errorProvider.SetError(txtNewPass, "Vui lòng nhập mật khẩu mới!");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }

            if (string.IsNullOrEmpty(txtNewPassAgain.Text))
            {
                errorProvider.SetError(Owner, "Vui lòng nhập lại mật khẩu mới!");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }
            if (cnt > 0) return;

            if (txtNewPass.Text != txtNewPassAgain.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UpdatePassword update = new UpdatePassword();

                int kq = update.changePassword(str, userName, txtNewPass.Text);

                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    Login login = new Login();

                    login.Show();
                }
                else
                {
                    MessageBox.Show("Cập nhật mật khẩu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật mật khẩu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
