using Common;
using System.Data;
using System.Data.SqlClient;
namespace CustomerForm
{
    public partial class CustomerForm : Form
    {
        SqlConnection conn;
        string str = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        public CustomerForm()
        {
            InitializeComponent();
            //conn = new SqlConnection("Data Source=34.133.93.201;Initial catalog=QL_RAP_PHIM;User ID=sqlserver;Password=123456789");
            conn = new SqlConnection(str);
            ////Kết nối sever mở///
            //// string connectionString = ConnectionHelper.CreateConnectionString(
            //     "34.133.93.201",      // Tên server giống CinemaRooms
            //     "QL_RAP_PHIM",        // Tên cơ sở dữ liệu
            //     "sqlserver",          // Tài khoản SQL
            //     "123456789"           // Mật khẩu SQL
            // );
            // conn = new SqlConnection(connectionString);

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
            // Chỉ xem, không sửa
            dgvThongTinKhachHang.ReadOnly = true;
            dgvThongTinKhachHang.AllowUserToAddRows = false;    // không cho thêm dòng mới
            dgvThongTinKhachHang.AllowUserToDeleteRows = false; // không cho xóa dòng
            dgvThongTinKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // chọn cả hàng
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
                        KH.DIEMTICHLUY,
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
                dgvThongTinKhachHang.Columns["DIEMTICHLUY"].HeaderText = "Tích điểm";
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
                    (MAKH, MAHANG, HOTENKH, PHAI, SDT, DIACHI, NGAYSINH, EMAIL, DIEMTICHLUY)
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
            string maKH = txtMaKhachHang.Text.Trim();

            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("⚠️ Vui lòng nhập Mã khách hàng cần sửa!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // 1️⃣ Lấy dữ liệu hiện tại từ DB
                string selectQuery = "SELECT * FROM KHACHHANG WHERE MAKH = @MAKH";
                SqlCommand cmdSelect = new SqlCommand(selectQuery, conn);
                cmdSelect.Parameters.AddWithValue("@MAKH", maKH);
                SqlDataReader reader = cmdSelect.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("❌ Không tìm thấy khách hàng có mã này!");
                    reader.Close();
                    return;
                }

                // Lưu dữ liệu gốc
                string oldTen = reader["HOTENKH"].ToString();
                string oldPhai = reader["PHAI"].ToString();
                string oldSDT = reader["SDT"].ToString();
                string oldDiaChi = reader["DIACHI"].ToString();
                string oldEmail = reader["EMAIL"].ToString();
                string oldMaHang = reader["MAHANG"].ToString();
                int oldTichDiem = Convert.ToInt32(reader["DIEMTICHLUY"]);
                DateTime? oldNgaySinh = reader["NGAYSINH"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["NGAYSINH"]);

                reader.Close();

                // 2️⃣ Chọn giá trị mới (nếu có)
                string newTen = string.IsNullOrWhiteSpace(txtTen.Text) ? oldTen : txtTen.Text.Trim();
                string newPhai = string.IsNullOrWhiteSpace(cboPhai.Text) ? oldPhai : cboPhai.Text.Trim();
                string newSDT = string.IsNullOrWhiteSpace(txtSDT.Text) ? oldSDT : txtSDT.Text.Trim();
                string newDiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? oldDiaChi : txtDiaChi.Text.Trim();
                string newEmail = string.IsNullOrWhiteSpace(txtEmail.Text) ? oldEmail : txtEmail.Text.Trim();
                string newMaHang = (cboMaHang.SelectedValue == null || cboMaHang.SelectedValue.ToString() == "") ? oldMaHang : cboMaHang.SelectedValue.ToString();

                DateTime newNgaySinh;
                if (string.IsNullOrWhiteSpace(mstNgay.Text) || !DateTime.TryParse(mstNgay.Text, out newNgaySinh))
                    newNgaySinh = oldNgaySinh ?? DateTime.MinValue;

                int newTichDiem;
                if (!int.TryParse(txtTichDiem.Text.Trim(), out newTichDiem))
                    newTichDiem = oldTichDiem;

                // 3️⃣ Cập nhật
                string updateQuery = @"
            UPDATE KHACHHANG SET
                HOTENKH=@HOTENKH,
                PHAI=@PHAI,
                SDT=@SDT,
                DIACHI=@DIACHI,
                NGAYSINH=@NGAYSINH,
                EMAIL=@EMAIL,
                DIEMTICHLUY=@TICHDIEM,
                MAHANG=@MAHANG
            WHERE MAKH=@MAKH";

                SqlCommand cmdUpdate = new SqlCommand(updateQuery, conn);
                cmdUpdate.Parameters.AddWithValue("@MAKH", maKH);
                cmdUpdate.Parameters.AddWithValue("@HOTENKH", newTen);
                cmdUpdate.Parameters.AddWithValue("@PHAI", newPhai);
                cmdUpdate.Parameters.AddWithValue("@SDT", newSDT);
                cmdUpdate.Parameters.AddWithValue("@DIACHI", newDiaChi);
                cmdUpdate.Parameters.AddWithValue("@EMAIL", newEmail);
                cmdUpdate.Parameters.AddWithValue("@MAHANG", newMaHang);
                cmdUpdate.Parameters.AddWithValue("@NGAYSINH", oldNgaySinh == null && newNgaySinh == DateTime.MinValue ? DBNull.Value : newNgaySinh);
                cmdUpdate.Parameters.AddWithValue("@TICHDIEM", newTichDiem);

                int rows = cmdUpdate.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("✅ Cập nhật khách hàng thành công!");
                    LoadCustomerData();
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("⚠️ Không có dữ liệu nào được sửa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi sửa: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
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
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }

}
