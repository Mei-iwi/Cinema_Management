using Common;
using iText.Commons.Bouncycastle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class ChangePasswordUser : Form
    {
        int position = -1;
        public ChangePasswordUser(int position)
        {
            InitializeComponent();

            this.Icon = Properties.Resources.house;


            pictureBox1.Image = new Bitmap(Properties.Resources.nen, new Size(100, 100));

            foreach (Button btn in tableLayoutPanel1.Controls.OfType<Button>())
            {
                btn.Image = new Bitmap(Properties.Resources.eyeclose.ToBitmap(), new Size(30, 30));
            }
            txtnewPass.UseSystemPasswordChar = true;
            txtnewPassAgian.UseSystemPasswordChar = true;
            txtPassOld.UseSystemPasswordChar = true;
            this.position = position;
        }


        private void btnPassOld_Click(object sender, EventArgs e)
        {
            // Đảo trạng thái UseSystemPasswordChar
            bool isHidden = txtPassOld.UseSystemPasswordChar; // đang ẩn
            txtPassOld.UseSystemPasswordChar = !isHidden;

            // Thay đổi icon mắt
            if (isHidden)
            {
                btnPassOld.Image = new Bitmap(Properties.Resources.eye.ToBitmap(), new Size(30, 30));
            }
            else
            {
                btnPassOld.Image = new Bitmap(Properties.Resources.eyeclose.ToBitmap(), new Size(30, 30));
            }
        }

        private void btnPassAgain_Click(object sender, EventArgs e)
        {
            bool isHidden = txtnewPassAgian.UseSystemPasswordChar; // đang ẩn
            txtnewPassAgian.UseSystemPasswordChar = !isHidden;

            // Thay đổi icon mắt
            if (isHidden)
            {
                btnPassAgain.Image = new Bitmap(Properties.Resources.eye.ToBitmap(), new Size(30, 30));
            }
            else
            {
                btnPassAgain.Image = new Bitmap(Properties.Resources.eyeclose.ToBitmap(), new Size(30, 30));
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {

            // Đảo trạng thái UseSystemPasswordChar
            bool isHidden = txtnewPass.UseSystemPasswordChar; // đang ẩn
            txtnewPass.UseSystemPasswordChar = !isHidden;

            // Thay đổi icon mắt
            if (isHidden)
            {
                btnPass.Image = new Bitmap(Properties.Resources.eye.ToBitmap(), new Size(30, 30));
            }
            else
            {
                btnPass.Image = new Bitmap(Properties.Resources.eyeclose.ToBitmap(), new Size(30, 30));
            }

        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regex chuẩn cơ bản cho email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (position == 0)
            {
                this.Hide();
                MainFormForCustomer mainFormForCustomer = new MainFormForCustomer();
                mainFormForCustomer.Show();
            }
            else if (position == 1)
            {
                this.Hide();
                MainFormForEmployee mainFormForEmployee = new MainFormForEmployee();
                mainFormForEmployee.Show();
            }
            else if (position == 2)
            {
                this.Hide();
                MainFormForManegement mainFormForManegement = new MainFormForManegement();
                mainFormForManegement.Show();
            }
            else
            {
                MessageBox.Show("Lỗi hệ thống, vui lòng đăng nhập lại");
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;

                // Truy đến folder solution
                string root = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\.."));

                // Đường dẫn chính xác đến LoginForm.exe
                string exePath = Path.Combine(root, "Cinema_Management", "bin", "Debug", "net8.0-windows", "Cinema_Management.exe");

                if (File.Exists(exePath))
                {
                    Process.Start(exePath);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lỗi đăng xuất, vui lòng chạy lại ứng dụng");
                    this.Close();
                }
            }
        }


        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            // Regex: ít nhất 8 ký tự, có số và ký tự đặc biệt
            string pattern = @"^(?=.*[0-9])(?=.*[!@#$%^&*()_\-+=\[{\]};:'"",<.>/?|]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str = Common.ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, txtPassOld.Text.Trim());

            bool checkconnect = Common.DataAccess.DataProvider.TestConnection(str);

            if (checkconnect)
            {
                if (txtnewPass.Text != txtnewPassAgian.Text)
                {
                    MessageBox.Show("Mật khẩu mới không khớp, vui lòng nhập lại!");
                    return;
                }

                if (!IsValidPassword(txtnewPass.Text))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự, bao gồm cả số và ký tự đặc biệt.", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "PROC_DOI_MK_SQLLOGIN";

                string strAdmin = Common.ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, "sqlserver", "Aa@123456789");

                using (SqlConnection con = new SqlConnection(strAdmin))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UserName", GlobalData.UserID);
                        cmd.Parameters.AddWithValue("@OldPassword", txtPassOld.Text);
                        cmd.Parameters.AddWithValue("@NewPassword", txtnewPass.Text);

                        con.Open();

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Đổi mật khẩu thành công! Vui lòng đăng nhập lại");
                            this.Hide();

                            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

                            // Truy đến folder solution
                            string root = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\.."));

                            // Đường dẫn chính xác đến LoginForm.exe
                            string exePath = Path.Combine(root, "Cinema_Management", "bin", "Debug", "net8.0-windows", "Cinema_Management.exe");

                            if (File.Exists(exePath))
                            {
                                Process.Start(exePath);
                                this.Hide();
                            }
                            else
                            {
                                this.Close();
                            }

                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Đổi mật khẩu thất bại! Vui lòng kiểm tra lại mật khẩu cũ.\nChi tiết lỗi: " + ex.Message);
                            return;
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Kết nối thất bại, vui lòng kiểm tra lại kết nối mạng hoặc thông tin đăng nhập!");
                return;
            }


        }
    }
}
