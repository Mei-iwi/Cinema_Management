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
            //if (GlobalData.Positon != 2)
            //{
            //    MessageBox.Show("❌ Bạn không có quyền truy cập vào khu vực Quản lý!",
            //                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    this.Close();
            //    return;
            //}
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
                        KH.TICHDIEM,
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

                // Đặt tên cột hiển thị
                dgvThongTinKhachHang.Columns["MAKH"].HeaderText = "Mã KH";
                dgvThongTinKhachHang.Columns["HOTENKH"].HeaderText = "Họ tên KH";
                dgvThongTinKhachHang.Columns["PHAI"].HeaderText = "Phái";
                dgvThongTinKhachHang.Columns["SDT"].HeaderText = "Số điện thoại";
                dgvThongTinKhachHang.Columns["DIACHI"].HeaderText = "Địa chỉ";
                dgvThongTinKhachHang.Columns["NGAYSINH"].HeaderText = "Ngày sinh";
                dgvThongTinKhachHang.Columns["EMAIL"].HeaderText = "Email";
                dgvThongTinKhachHang.Columns["TICHDIEM"].HeaderText = "Tích điểm";
                dgvThongTinKhachHang.Columns["TENHANG"].HeaderText = "Hạng TV";
                dgvThongTinKhachHang.Columns["DIEMTOITHIEU"].HeaderText = "Điểm hiện tại";
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
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
        private void ClearTextBoxes()
        {
            txtMaKhachHang.Clear();
            txtTen.Clear();
            cboPhai.SelectedIndex = -1;
            txtSDT.Clear();
            txtDiaChi.Clear();
            mstNgay.Clear();
            txtEmail.Clear();
            txtTichDiem.Clear();
            cboMaHang.SelectedIndex = -1;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKhachHang.Text))
            {
                MessageBox.Show("❌ Vui lòng nhập Mã khách hàng!");
                return;
            }

            if (!ktr_MaKH(txtMaKhachHang.Text))
            {
                MessageBox.Show("❌ Mã khách hàng đã tồn tại!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = @"INSERT INTO KHACHHANG
                    (MAKH, MAHANG, HOTENKH, PHAI, SDT, DIACHI, NGAYSINH, EMAIL, TICHDIEM)
                    VALUES
                    (@MAKH, @MAHANG, @HOTENKH, @PHAI, @SDT, @DIACHI, @NGAYSINH, @EMAIL, @TICHDIEM)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAKH", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@MAHANG", cboMaHang.SelectedValue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HOTENKH", txtTen.Text);
                cmd.Parameters.AddWithValue("@PHAI", cboPhai.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@DIACHI", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@NGAYSINH", string.IsNullOrWhiteSpace(mstNgay.Text) ? DBNull.Value : DateTime.Parse(mstNgay.Text));
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);

                int tichDiem = 0;
                int.TryParse(txtTichDiem.Text, out tichDiem);
                cmd.Parameters.AddWithValue("@TICHDIEM", tichDiem);

                cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Thêm khách hàng thành công!");
                LoadCustomerData();
                ClearTextBoxes();
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

            string maKH = dgvThongTinKhachHang.CurrentRow.Cells["MAKH"].Value.ToString();
            if (MessageBox.Show($"Bạn có chắc muốn xóa khách hàng {maKH}?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = "DELETE FROM KHACHHANG WHERE MAKH=@MAKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAKH", maKH);
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Xóa khách hàng thành công!");
                LoadCustomerData();
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi xóa: " + ex.Message);
            }
            finally { conn.Close(); }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvThongTinKhachHang.CurrentRow == null) return;

            string maKH = dgvThongTinKhachHang.CurrentRow.Cells["MAKH"].Value.ToString();

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = @"
            UPDATE KHACHHANG SET
                HOTENKH=@HOTENKH,
                PHAI=@PHAI,
                SDT=@SDT,
                DIACHI=@DIACHI,
                NGAYSINH=@NGAYSINH,
                EMAIL=@EMAIL,
                TICHDIEM=@TICHDIEM
            WHERE MAKH=@MAKH";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAKH", maKH);
                cmd.Parameters.AddWithValue("@HOTENKH", string.IsNullOrWhiteSpace(txtTen.Text)
                    ? dgvThongTinKhachHang.CurrentRow.Cells["HOTENKH"].Value
                    : txtTen.Text);

                cmd.Parameters.AddWithValue("@PHAI", string.IsNullOrWhiteSpace(cboPhai.Text)
                    ? dgvThongTinKhachHang.CurrentRow.Cells["PHAI"].Value
                    : cboPhai.Text);

                cmd.Parameters.AddWithValue("@SDT", string.IsNullOrWhiteSpace(txtSDT.Text)
                    ? dgvThongTinKhachHang.CurrentRow.Cells["SDT"].Value
                    : txtSDT.Text);

                // Ngày sinh
                DateTime ngaySinh;
                if (string.IsNullOrWhiteSpace(mstNgay.Text) ||
                    !DateTime.TryParse(mstNgay.Text, out ngaySinh))
                {
                    cmd.Parameters.AddWithValue("@NGAYSINH",
                        dgvThongTinKhachHang.CurrentRow.Cells["NGAYSINH"].Value ?? DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@NGAYSINH", ngaySinh);
                }

                cmd.Parameters.AddWithValue("@DIACHI", string.IsNullOrWhiteSpace(txtDiaChi.Text)
                    ? dgvThongTinKhachHang.CurrentRow.Cells["DIACHI"].Value
                    : txtDiaChi.Text);

                cmd.Parameters.AddWithValue("@EMAIL", string.IsNullOrWhiteSpace(txtEmail.Text)
                    ? dgvThongTinKhachHang.CurrentRow.Cells["EMAIL"].Value
                    : txtEmail.Text);

                int tichDiem;
                if (!int.TryParse(txtTichDiem.Text.Trim(), out tichDiem))
                    tichDiem = Convert.ToInt32(dgvThongTinKhachHang.CurrentRow.Cells["TICHDIEM"].Value);

                cmd.Parameters.AddWithValue("@TICHDIEM", tichDiem);

                cmd.ExecuteNonQuery();
                MessageBox.Show("✅ Cập nhật khách hàng thành công!");
                LoadCustomerData();
                ClearTextBoxes();
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

        private void CustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1); 
            if(r == DialogResult.No)
            {
                e.Cancel = true; 
            }    
        }
    }

}
