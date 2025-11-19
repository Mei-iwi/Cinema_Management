using Common;
using System.Data.SqlClient;
namespace ProfileForm
{
    public partial class ProfileForm : Form
    {
        Customer customer;

        Employee employee;

        int position;

        public ProfileForm(Customer cus, Employee em, int position)
        {
            InitializeComponent();

            if (cus != null)
            {
                this.customer = cus;
            }

            if (em != null)
            {
                this.employee = em;
            }

            this.position = position;
            load_info();

            btnLuu.Enabled = false;

        }

        void load_image(string avatar)
        {

            // Truy đến folder solution
            string root = Path.GetFullPath(Application.StartupPath + @"..\..\..\..");

            // Đường dẫn chính xác đến hình ảnh

            string imagePath = System.IO.Path.Combine(root, "ProfileForm", "Images", avatar);

            // Kiểm tra nếu file hình ảnh tồn tại

            if (File.Exists(imagePath))
            {
                // Tải ảnh và clone để giải phóng file ngay
                using (var img = Image.FromFile(imagePath))
                {
                    picAvatarfull.Image = new Bitmap(img);
                    picAvatar.Image = new Bitmap(img);
                }
            }
            else
            {
                MessageBox.Show("Hình ảnh nền không tồn tại tại đường dẫn: " + imagePath);
            }

        }

        void load_info()
        {
            if (customer != null)
            {
                txtMa.Text = customer.MAKH.ToString();
                txtTen.Text = customer.FullName;
                txtEmail.Text = customer.Email;
                txtDC.Text = customer.Address;
                dateNgaysinh.Value = customer.BirthDate;
                cboGT.Text = customer.Gender;
                txtEmail.Text = customer.Email;
                txtSDT.Text = customer.Phone;

                load_image(customer.Avatar);
            }
            else if (employee != null)
            {
                txtMa.Text = employee.MANV.ToString();
                txtTen.Text = employee.FullName;
                txtEmail.Text = employee.Email;
                txtDC.Text = employee.Address;
                dateNgaysinh.Value = employee.BirthDate;
                cboGT.Text = employee.Gender;
                txtEmail.Text = employee.Email;
                txtSDT.Text = employee.Phone;
                txtLuong.Text = employee.Salary.ToString();
                txtCT.Text = employee.Catruc;
                txtMaQL.Text = employee.MA_NQL.ToString();


                load_image(employee.Avatar);
            }

            if (position == 0)
            {
                lblVaiTro.Text = "Vai trò: Khách Hàng";
            }
            else if (position == 1)
            {
                lblVaiTro.Text = "Vai trò: Nhân Viên";
            }
            else if (position == 2)
            {
                lblVaiTro.Text = "Vai trò: Quản Lý";

            }
            else
            {
                lblVaiTro.Text = "Vai trò: Toàn quyền";
            }
        }

        void enableControls(bool enable = false)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox || c is ComboBox || c is DateTimePicker)
                    c.Enabled = enable;
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {


            Close();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            enableControls();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

            cboGT.Enabled = true;
            dateNgaysinh.Enabled = true;
            txtDC.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void ProfileForm_Load_1(object sender, EventArgs e)
        {
            enableControls();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string connectionString = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

            if (position == 0)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"UPDATE KHACHHANG
                                SET PHAI = @GT,
                                NGAYSINH = @NGAYSINH,
                                DIACHI = @DIACHI
                                WHERE MAKH = @MA";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@GT", cboGT.Text.ToString());
                        cmd.Parameters.AddWithValue("@NGAYSINH", dateNgaysinh.Value);
                        cmd.Parameters.AddWithValue("@DIACHI", txtDC.Text);
                        cmd.Parameters.AddWithValue("@MA", txtMa.Text);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected + " bản ghi đã được cập nhật.");
                    }
                }

            }
            else if(position == 1|| position == 2)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"UPDATE NHANVIEN
                                SET PHAI = @GT,
                                NGAYSINH = @NGAYSINH,
                                DIACHI = @DIACHI
                                WHERE MANV = @MA";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@GT", cboGT.Text.ToString());
                        cmd.Parameters.AddWithValue("@NGAYSINH", dateNgaysinh.Value);
                        cmd.Parameters.AddWithValue("@DIACHI", txtDC.Text);
                        cmd.Parameters.AddWithValue("@MA", txtMa.Text);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected + " bản ghi đã được cập nhật.");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Lỗi trong quá trình xác thực", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            enableControls();
            btnLuu.Enabled = false;
        }
       
    }
}
