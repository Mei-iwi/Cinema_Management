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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;

namespace Cinema_Management
{
    public partial class Registration : Form
    {
        int pass = 0;
        int passAgain = 0;

        public Registration()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.regis;
            foreach (var c in tableLayoutPanel2.Controls.OfType<Button>())
            {
                c.Image = new Bitmap(Properties.Resources.eye.ToBitmap(), new Size(30, 30));
            }
            txtPass.UseSystemPasswordChar = true;
            txtPassAgain.UseSystemPasswordChar = true;
            groupBox2.Hide();

        }



        private void btnPass_Click(object sender, EventArgs e)
        {
            // Đảo trạng thái UseSystemPasswordChar
            bool isHidden = txtPass.UseSystemPasswordChar; // đang ẩn
            txtPass.UseSystemPasswordChar = !isHidden;

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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void btnPassAgain_Click(object sender, EventArgs e)
        {
            // Đảo trạng thái UseSystemPasswordChar
            bool isHidden = txtPassAgain.UseSystemPasswordChar; // đang ẩn
            txtPassAgain.UseSystemPasswordChar = !isHidden;

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

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg";
            openFileDialog.Title = "Chọn ảnh đại diện";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog.FileName;

                txtImage.Text = selectedFile;
                picAvatar.Image = Image.FromFile(selectedFile);
                picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
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


        private string createdID()
        {
            string sql = "SELECT TOP 1 MAKH FROM KHACHHANG ORDER BY MAKH DESC";

            SqlConnection con = new SqlConnection(ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, "sqlserver", "Aa@123456789"));

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            string currentcode = null;

            if (reader.Read())
            {
                currentcode = reader["MAKH"].ToString();
            }

            con.Close();



            int newID = 1;

            if (!string.IsNullOrEmpty(currentcode))
            {
                string currentID = currentcode;

                // Định dạng KH + 8 số
                if (currentID.Length == 10 && currentID.StartsWith("KH") &&
                    int.TryParse(currentID.Substring(2, 8), out int num))
                {
                    newID = num + 1;
                }
            }


            return "KH" + newID.ToString("D8");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var c in tableLayoutPanel1.Controls.OfType<TextBox>())
            {
                if (string.IsNullOrEmpty(c.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            string emailInput = txtEmail.Text.Trim();

            if (!IsValidEmail(emailInput))
            {
                MessageBox.Show("Email không hợp lệ, vui lòng nhập đúng định dạng.");
                return;
            }



            txtUser.Text = createdID();



        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            groupBox2.Show();
            foreach (var c in groupBox1.Controls.OfType<TextBox>())
            {
                c.Enabled = false;
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
            if (txtPass.Text != txtPassAgain.Text)
            {
                MessageBox.Show("Mật khẩu không khớp, vui lòng kiểm tra lại!", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidPassword(txtPass.Text))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự, bao gồm cả số và ký tự đặc biệt.", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = "INSERT INTO KHACHHANG(MAKH, MAHANG, HOTENKH, SDT, DIACHI, NGAYSINH, EMAIL, HINH_ANH, PHAI, DIEMTICHLUY) VALUES(@makh, 'H00000001', @ten, @dt, @dc, @ns, @email, @anh, @phai, 0)";
                string str = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, "sqlserver", "Aa@123456789");
                if (!string.IsNullOrEmpty(txtImage.Text))
                {
                    string originalFilePath = txtImage.Text.Trim(); // giữ đường dẫn gốc
                    string filename = Path.GetFileName(originalFilePath);
                    string uniqueFileName = $"{Guid.NewGuid()}_{filename}";

                    // Thư mục đích trong project
                    string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\.."));
                    string destinationPath = Path.Combine(projectRoot, "ProfileForm", "Images");

                    if (!Directory.Exists(destinationPath))
                        Directory.CreateDirectory(destinationPath);

                    string destinationFilePath = Path.Combine(destinationPath, uniqueFileName);

                    // Copy file gốc vào project
                    File.Copy(originalFilePath, destinationFilePath, true);

                    // Cập nhật tên file vào TextBox
                    txtImage.Text = uniqueFileName;

                    // Load ảnh lên PictureBox
                    picAvatar.Image = Image.FromFile(destinationFilePath);
                    picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                }



                SqlConnection con = new SqlConnection(str);

                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);



                cmd.Parameters.AddWithValue("@makh", txtUser.Text.Trim());
                cmd.Parameters.AddWithValue("@ten", txtTen.Text.Trim());
                cmd.Parameters.AddWithValue("@dt", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@dc", txtDC.Text.Trim());
                cmd.Parameters.AddWithValue("@ns", dateNS.Value);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@anh", txtImage.Text.Trim());
                cmd.Parameters.AddWithValue("@phai", cboGT.SelectedText);
                int result = cmd.ExecuteNonQuery();
                con.Close();


                con.Open();

                string proc = "SP_CREATE_ACCOUNT";

                SqlCommand cmdlog = new SqlCommand(proc, con);


                cmdlog.CommandType = CommandType.StoredProcedure;

                cmdlog.Parameters.AddWithValue("@UserName", txtUser.Text);

                cmdlog.Parameters.AddWithValue("@Password", txtPass.Text);

                cmdlog.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Đăng ký thành công! Vui lòng ghi nhớ Mã khách hàng để đăng nhập: " + txtUser.Text.Trim(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Login login = new Login();
                login.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Đăng ký thất bại, vui lòng thử lại!", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
