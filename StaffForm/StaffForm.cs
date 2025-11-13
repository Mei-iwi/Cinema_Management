using Common;
using System.Data;
using System.Data.SqlClient;
namespace StaffForm
{
    public partial class StaffForm : Form
    {
        SqlConnection conn;
        public StaffForm()
        {
            InitializeComponent();
            //conn = new SqlConnection("Data Source=34.133.93.201;Initial catalog=QL_RAP_PHIM;User ID=sqlserver;Password=123456789");
            conn = new SqlConnection("Data Source=DESKTOP-IQCO6JU\\SQLEXPRESS;Initial catalog=QL_RAP_PHIM;User ID=sa;Password=123");
            ////---------------------------------Kết nối sever mở--------------------------------------------------------------///
            //// string connectionString = ConnectionHelper.CreateConnectionString(
            //     "34.133.93.201",      // Tên server giống CinemaRooms
            //     "QL_RAP_PHIM",        // Tên cơ sở dữ liệu
            //     "sqlserver",          // Tài khoản SQL
            //     "123456789"           // Mật khẩu SQL
            // );
            // conn = new SqlConnection(connectionString);
        }
        private void StaffForm_Load(object sender, EventArgs e)
        {
            //if (GlobalData.Positon != 2)
            //{
            //    MessageBox.Show("❌ Bạn không có quyền truy cập vào khu vực Quản lý!",
            //                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.Close();
            //    return;
            //}
            mtxtNgaySinh.ValidatingType = typeof(DateTime);
            cboPhai.Items.Add("Nam");
            cboPhai.Items.Add("Nữ");

            // Gán dữ liệu cho combobox ca trực
            cboCaTruc.Items.Add("SÁNG");
            cboCaTruc.Items.Add("CHIỀU");
            cboCaTruc.Items.Add("TỐI");
        }
        bool ktr_MaNhanVien(string ma)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                //xác định chuỗi truy vấn
                string selectString = "select count(*) from NHANVIEN WHERE MANV='" + ma + "'";
                //khai báo command với chuỗi truy vấn và biến kết quả
                SqlCommand cmd = new SqlCommand(selectString, conn);
                //gọi hàm thực thi truy vấn
                int count = (int)cmd.ExecuteScalar();
                //Dong kết nói 
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                //xử lý kết quả try vấn 
                if (count >= 1)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex) { return false; }
        }

        private void mtxtNgaySinh_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập theo dạng dd/MM/yyyy");
                mtxtNgaySinh.Focus();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra mã NV trùng
                if (!ktr_MaNhanVien(txtMaNhanVien.Text.Trim()))
                {
                    MessageBox.Show("❌ Mã nhân viên đã tồn tại!");
                    return;
                }

                // Mở kết nối
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Câu lệnh thêm
                string insertString = @"
            INSERT INTO NHANVIEN 
            (MANV, HOTENNV, SDT, DIACHI, NGAYSINH, PHAI, LUONG, CATRUC, EMAIL, CHUCVU, MA_NQL)
            VALUES 
            (@MANV, @TENNV, @SDT, @DIACHI, @NGAYSINH, @PHAI, @LUONG, @CATRUC, @EMAIL, @CHUCVU, @MA_NQL)";

                using (SqlCommand cmd = new SqlCommand(insertString, conn))
                {
                    cmd.Parameters.AddWithValue("@MANV", txtMaNhanVien.Text.Trim());
                    cmd.Parameters.AddWithValue("@TENNV", txtTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSdt.Text.Trim());
                    cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAYSINH", DateTime.ParseExact(mtxtNgaySinh.Text, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@PHAI", cboPhai.Text);

                    if (decimal.TryParse(txtLuong.Text, out decimal luong))
                        cmd.Parameters.AddWithValue("@LUONG", luong);
                    else
                    {
                        MessageBox.Show("⚠ Lương phải là số!");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@CATRUC", cboCaTruc.Text);

                    // Nếu bạn có 3 textbox này
                    cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@CHUCVU", txtChucVu.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_NQL", txtMaNQL.Text.Trim());

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Thêm nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi thêm nhân viên: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNhanVien.Text.Trim();

                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa!");
                    return;
                }

                DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {maNV}?",
                                                  "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string deleteString = "DELETE FROM NHANVIEN WHERE MANV = @MANV";
                    using (SqlCommand cmd = new SqlCommand(deleteString, conn))
                    {
                        cmd.Parameters.AddWithValue("@MANV", maNV);
                        int affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                            MessageBox.Show("✅ Xóa nhân viên thành công!");
                        else
                            MessageBox.Show("❌ Không tìm thấy nhân viên để xóa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi xóa nhân viên: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNhanVien.Text.Trim();
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên cần sửa!");
                    return;
                }

                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string updateString = @"
            UPDATE NHANVIEN
            SET HOTENNV = @TENNV,
                SDT = @SDT,
                DIACHI = @DIACHI,
                NGAYSINH = @NGAYSINH,
                PHAI = @PHAI,
                LUONG = @LUONG,
                CATRUC = @CATRUC,
                EMAIL = @EMAIL,
                CHUCVU = @CHUCVU,
                MA_NQL = @MA_NQL
            WHERE MANV = @MANV";

                using (SqlCommand cmd = new SqlCommand(updateString, conn))
                {
                    cmd.Parameters.AddWithValue("@MANV", maNV);
                    cmd.Parameters.AddWithValue("@TENNV", txtTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSdt.Text.Trim());
                    cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAYSINH", DateTime.ParseExact(mtxtNgaySinh.Text, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@PHAI", cboPhai.Text);

                    if (decimal.TryParse(txtLuong.Text, out decimal luong))
                        cmd.Parameters.AddWithValue("@LUONG", luong);
                    else
                    {
                        MessageBox.Show("⚠ Lương phải là số!");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@CATRUC", cboCaTruc.Text);
                    cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@CHUCVU", txtChucVu.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_NQL", txtMaNQL.Text.Trim());

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                        MessageBox.Show("✅ Cập nhật thông tin nhân viên thành công!");
                    else
                        MessageBox.Show("❌ Không tìm thấy nhân viên để cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi cập nhật nhân viên: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            TimNhanVien timForm = new TimNhanVien();

            // 2️⃣ Ẩn form hiện tại (StaffForm)
            this.Hide();

            // 3️⃣ Hiển thị form mới
            timForm.Show();

            // 4️⃣ Khi TimNhanVien đóng, StaffForm có thể đóng theo hoặc hiện lại
            timForm.FormClosed += (s, args) =>
            {
                this.Show(); //    hiện lại StaffForm khi TimNhanVien đóng
                             // this.Close(); nếu muốn đóng hẳn StaffForm
            };
        }
    }
}
