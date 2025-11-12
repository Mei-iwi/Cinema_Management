using Common;
using System.Data;
using System.Data.SqlClient; 
namespace CustomerForm
{
    public partial class CustomerForm : Form
    {
        SqlConnection conn;
        public CustomerForm()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=DESKTOP-IQCO6JU\\SQLEXPRESS;Initial catalog=QL_RAP_PHIM;User ID=sa;Password=123");
            //conn = new SqlConnection("Data Source=34.133.93.201;Initial catalog=QL_RAP_PHIM;User ID=sqlserver;Password=123456789");

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            if (GlobalData.Positon != 2)
            {
                MessageBox.Show("❌ Bạn không có quyền truy cập vào khu vực Quản lý!",
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            mstNgay.ValidatingType = typeof(DateTime);
            cboPhai.Items.Add("Nam");
            cboPhai.Items.Add("Nữ");
            //------------------------------//
            LoadHangThanhVien();
            //-----------------------------//

            LoadCustomerData();
        }
        private void LoadCustomerData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = @"
                    SELECT 
                        KH.MAKH,
                        KH.MAHANG,
                        KH.HOTENKH,
                        KH.PHAI,
                        KH.SDT,
                        KH.DIACHI,
                        KH.NGAYSINH,
                        KH.EMAIL,
                        H.TENHANG,
                        H.DIEMTOITHIEU
                    FROM KHACHHANG KH
                    JOIN HANGTHANHVIEN H ON KH.MAHANG = H.MAHANG;
                ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvThongTinKhachHang.DataSource = dt;

                // Ẩn cột MAHANG
                if (dgvThongTinKhachHang.Columns["MAHANG"] != null)
                    dgvThongTinKhachHang.Columns["MAHANG"].Visible = false;

                // Đặt tên cột
                dgvThongTinKhachHang.Columns["MAKH"].HeaderText = "Mã KH";
                dgvThongTinKhachHang.Columns["HOTENKH"].HeaderText = "Họ tên KH";
                dgvThongTinKhachHang.Columns["PHAI"].HeaderText = "Phái";
                dgvThongTinKhachHang.Columns["SDT"].HeaderText = "Số điện thoại";
                dgvThongTinKhachHang.Columns["DIACHI"].HeaderText = "Địa chỉ";
                dgvThongTinKhachHang.Columns["NGAYSINH"].HeaderText = "Ngày sinh";
                dgvThongTinKhachHang.Columns["EMAIL"].HeaderText = "Email";
                dgvThongTinKhachHang.Columns["TENHANG"].HeaderText = "Hạng TV";
                dgvThongTinKhachHang.Columns["DIEMTOITHIEU"].HeaderText = "Điểm hiện tại";
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void LoadHangThanhVien()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT MAHANG, TENHANG FROM HANGTHANHVIEN";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboMaHang.DataSource = dt;
                cboMaHang.DisplayMember = "TENHANG";
                cboMaHang.ValueMember = "MAHANG";
                if (cboMaHang.Items.Count > 0)
                    cboMaHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi load Hạng TV: " + ex.Message);
            }
            finally { conn.Close(); }
        }
        private void mstNgay_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            // Nếu không nhập gì thì không báo lỗi
            if (string.IsNullOrWhiteSpace(mstNgay.Text))
                return;

            // Nếu nhập thì phải đúng định dạng
            if (!e.IsValidInput)
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập theo dạng dd/MM/yyyy");
                mstNgay.Focus();
            }
        }
        bool ktr_MaKH(string ma)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT COUNT(*) FROM KHACHHANG WHERE MAKH=@MAKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAKH", ma);
                int count = (int)cmd.ExecuteScalar();
                return count == 0; // true nếu chưa tồn tại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã KH: " + ex.Message);
                return false;
            }
            finally { if (conn.State == ConnectionState.Open) conn.Close(); }
        }
        private void ClearForm()
        {
            txtMaKhachHang.Clear();
            txtTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            cboPhai.SelectedIndex = -1;  // reset ComboBox
            cboMaHang.SelectedIndex = -1; // reset ComboBox
            mstNgay.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ktr_MaKH(txtMaKhachHang.Text))
            {
                MessageBox.Show("❌ Mã khách hàng đã tồn tại!");
                return;
            }

            if (cboMaHang.SelectedValue == null)
            {
                MessageBox.Show("❌ Vui lòng chọn Hạng TV!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"INSERT INTO KHACHHANG
                    (MAKH, MAHANG, HOTENKH, PHAI, SDT, DIACHI, NGAYSINH, EMAIL)
                    VALUES
                    (@MAKH, @MAHANG, @HOTENKH, @PHAI, @SDT, @DIACHI, @NGAYSINH, @EMAIL)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAKH", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@MAHANG", cboMaHang.SelectedValue);
                cmd.Parameters.AddWithValue("@HOTENKH", txtTen.Text);
                cmd.Parameters.AddWithValue("@PHAI", cboPhai.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@NGAYSINH", DateTime.Parse(mstNgay.Text));
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Thêm khách hàng thành công!");
                LoadCustomerData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi thêm: " + ex.Message);
            }
            finally { conn.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvThongTinKhachHang.CurrentRow == null) return;

            string maKH = dgvThongTinKhachHang.CurrentRow.Cells["MAKH"].Value?.ToString();
            if (string.IsNullOrEmpty(maKH)) return;

            if (MessageBox.Show($"Bạn có chắc muốn xóa khách hàng {maKH}?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "DELETE FROM KHACHHANG WHERE MAKH=@MAKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAKH", maKH);
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Xóa khách hàng thành công!");
                LoadCustomerData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi xóa: " + ex.Message);
            }
            finally { conn.Close(); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKhachHang.Text.Trim();
            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("❌ Vui lòng nhập Mã khách hàng để sửa!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Lấy dữ liệu cũ
                string selectQuery = "SELECT * FROM KHACHHANG WHERE MAKH=@MAKH";
                SqlCommand selectCmd = new SqlCommand(selectQuery, conn);
                selectCmd.Parameters.AddWithValue("@MAKH", maKH);
                SqlDataReader reader = selectCmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("❌ Không tìm thấy khách hàng với mã này!");
                    reader.Close();
                    return;
                }

                reader.Read();
                // Lấy dữ liệu cũ để so sánh
                string oldMaHang = reader["MAHANG"].ToString();
                string oldHoten = reader["HOTENKH"].ToString();
                string oldPhai = reader["PHAI"].ToString();
                string oldSDT = reader["SDT"].ToString();
                string oldDiaChi = reader["DIACHI"].ToString();
                DateTime oldNgaySinh = (DateTime)reader["NGAYSINH"];
                string oldEmail = reader["EMAIL"].ToString();
                reader.Close();

                // Build câu lệnh update chỉ thay đổi những cột có giá trị mới
                string updateQuery = @"
            UPDATE KHACHHANG SET
                MAHANG=@MAHANG,
                HOTENKH=@HOTENKH,
                PHAI=@PHAI,
                SDT=@SDT,
                DIACHI=@DIACHI,
                NGAYSINH=@NGAYSINH,
                EMAIL=@EMAIL
            WHERE MAKH=@MAKH";

                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@MAKH", maKH);
                cmd.Parameters.AddWithValue("@MAHANG", cboMaHang.SelectedValue ?? oldMaHang);
                cmd.Parameters.AddWithValue("@HOTENKH", string.IsNullOrEmpty(txtTen.Text) ? oldHoten : txtTen.Text);
                cmd.Parameters.AddWithValue("@PHAI", string.IsNullOrEmpty(cboPhai.Text) ? oldPhai : cboPhai.Text);
                cmd.Parameters.AddWithValue("@SDT", string.IsNullOrEmpty(txtSDT.Text) ? oldSDT : txtSDT.Text);
                cmd.Parameters.AddWithValue("@DIACHI", string.IsNullOrEmpty(txtDiaChi.Text) ? oldDiaChi : txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@NGAYSINH", string.IsNullOrEmpty(mstNgay.Text) ? oldNgaySinh : DateTime.Parse(mstNgay.Text));
                cmd.Parameters.AddWithValue("@EMAIL", string.IsNullOrEmpty(txtEmail.Text) ? oldEmail : txtEmail.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Cập nhật khách hàng thành công!");
                LoadCustomerData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi sửa: " + ex.Message);
            }
            finally { conn.Close(); }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
