using Common;
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
    public partial class ChangePassword : Form
    {
        private string savedCode;
        private DateTime otpGeneratedTime;
        private DateTime otpExpiryTime;
        private System.Windows.Forms.Timer otpTimer;

        string str;
        public ChangePassword()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.IconLogin;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            grpXacThuc.Hide();
        }

        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Vui lòng nhập tên đăng nhập!");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }


            if (string.IsNullOrEmpty(txtMail.Text))
            {
                errorProvider.SetError(txtMail, "Vui lòng nhập email!");
            }
            else
            {
                errorProvider.Clear();
            }
            if (cnt > 0) return;

            try
            {

                str = Common.ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, FullAccount.UserID, FullAccount.Password);

                bool checkUser = DataAccess.DataProvider.TestConnection(str);

                if (checkUser)
                {

                    string userName = txtUsername.Text.Trim();

                    Authentication auth = new Authentication();

                    if (userName.Substring(0, 2) == "NV")
                    {
                        Employee em = auth.getInfomation(str, userName);
                        if (em != null)
                        {
                            if (em.Email != txtMail.Text.Trim())
                            {
                                MessageBox.Show("Email không đúng với tài khoản nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        }
                    }
                    else
                    {
                        Customer cus = auth.getCustomerInfomation(str, userName);
                        if (cus != null)
                        {
                            if (cus.Email != txtMail.Text.Trim())
                            {
                                MessageBox.Show("Email không đúng với tài khoản khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        }
                    }

                    MessageBox.Show("Xác thực người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kết nối cơ sở dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                string email = txtMail.Text.Trim();
                Common.VerifyViaEmail verifier = new Common.VerifyViaEmail();// gửi OTP
                MessageBox.Show("Mã xác thực đã được gửi đến: " + email);
                savedCode = verifier.SendVerificationCode(email);

                grpXacThuc.Show();

                // OTP có hiệu lực 5 phút
                otpExpiryTime = DateTime.Now.AddMinutes(5);

                otpTimer = new System.Windows.Forms.Timer();
                otpTimer.Interval = 1000; // 1 giây
                otpTimer.Tick += OtpTimer_Tick;
                otpTimer.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (savedCode == null)
            {
                MessageBox.Show("OTP đã hết hạn. Vui lòng gửi lại.");
                return;
            }

            if (txtXacThuc.Text.Trim() == savedCode)
            {
                otpTimer.Stop();
                MessageBox.Show("OTP xác thực thành công!");

                this.Hide();

                Change change = new Change(txtUsername.Text, str);

                change.Show();
            }
            else
            {
                MessageBox.Show("OTP không chính xác.");
            }
        }

        private void OtpTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan remaining = otpExpiryTime - DateTime.Now;

            if (remaining.TotalSeconds <= 0)
            {
                otpTimer.Stop();
                lblTime.Text = "00:00";
                MessageBox.Show("OTP đã hết hạn. Vui lòng yêu cầu gửi lại mã.");
                grpXacThuc.Hide();
                savedCode = null;
                return;
            }

            lblTime.Text = $"{remaining.Minutes:D2}:{remaining.Seconds:D2}";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan remaining = otpExpiryTime - DateTime.Now;

            if (remaining.TotalSeconds <= 0)
            {
                otpTimer.Stop();
                lblTime.Text = "00:00";
                MessageBox.Show("OTP đã hết hạn. Vui lòng yêu cầu gửi lại mã.");
                grpXacThuc.Hide();
                savedCode = null;
                return;
            }

            lblTime.Text = $"{remaining.Minutes:D2}:{remaining.Seconds:D2}";
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            Login login = new Login();
            login.Show();
        }
    }
}
