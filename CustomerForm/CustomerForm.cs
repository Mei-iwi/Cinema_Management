using Common;
using System.Data;
using System.Data.SqlClient;
namespace CustomerForm
{
    public partial class CustomerForm : Form
    {
        // --- KHAI BÁO BIẾN ---
        SqlConnection conn;
        string str = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        BindingSource bs = new BindingSource();
        SqlDataAdapter da;
        DataTable dt;
        DataTable dtHangTV;

        public CustomerForm()
        {
            InitializeComponent();
            conn = new SqlConnection(str);
        }

        // 1. LOAD FORM
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            SetControlsReadOnly();

            mstNgay.Mask = "00/00/0000";
            mstNgay.ValidatingType = typeof(DateTime);

            LoadHangThanhVien();
            SetupDataGridViewColumns();
            LoadCustomerData();

            dgvThongTinKhachHang.DataError += dgvThongTinKhachHang_DataError;
            dgvThongTinKhachHang.CellEnter += dgvThongTinKhachHang_CellEnter;

            // Mặc định: Khóa Grid và Chọn cả hàng
            ResetGridState();
        }

        private void SetControlsReadOnly()
        {
            // Vô hiệu hóa toàn bộ textbox
            txtMaKhachHang.Enabled = false;
            txtTen.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
            txtTichDiem.Enabled = false;
            mstNgay.Enabled = false;
            cboPhai.Enabled = false;
            cboMaHang.Enabled = false;
        }

        // Hàm đưa Grid về trạng thái ban đầu (Chỉ xem)
        private void ResetGridState()
        {
            dgvThongTinKhachHang.ReadOnly = true;
            dgvThongTinKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Trả lại màu trắng cho tất cả dòng
            foreach (DataGridViewRow row in dgvThongTinKhachHang.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void LoadHangThanhVien()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlDataAdapter daHang = new SqlDataAdapter("SELECT MAHANG, TENHANG FROM HANGTHANHVIEN", conn);
                dtHangTV = new DataTable();
                daHang.Fill(dtHangTV);

                cboMaHang.DataSource = dtHangTV;
                cboMaHang.DisplayMember = "TENHANG";
                cboMaHang.ValueMember = "MAHANG";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load hạng: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void SetupDataGridViewColumns()
        {
            dgvThongTinKhachHang.AutoGenerateColumns = false;
            dgvThongTinKhachHang.Columns.Clear();

            // Cột Mã KH
            DataGridViewTextBoxColumn colMa = new DataGridViewTextBoxColumn();
            colMa.HeaderText = "Mã KH"; colMa.DataPropertyName = "MAKH"; colMa.Name = "MAKH";
            dgvThongTinKhachHang.Columns.Add(colMa);

            // Cột Hạng TV (ComboBox)
            DataGridViewComboBoxColumn colHang = new DataGridViewComboBoxColumn();
            colHang.HeaderText = "Hạng TV"; colHang.DataPropertyName = "MAHANG";
            colHang.DataSource = dtHangTV; colHang.DisplayMember = "TENHANG"; colHang.ValueMember = "MAHANG"; colHang.Width = 150;
            dgvThongTinKhachHang.Columns.Add(colHang);

            // Cột Tên
            DataGridViewTextBoxColumn colTen = new DataGridViewTextBoxColumn();
            colTen.HeaderText = "Họ Tên"; colTen.DataPropertyName = "HOTENKH"; colTen.Width = 180;
            dgvThongTinKhachHang.Columns.Add(colTen);

            // Cột Phái
            DataGridViewComboBoxColumn colPhai = new DataGridViewComboBoxColumn();
            colPhai.HeaderText = "Phái"; colPhai.DataPropertyName = "PHAI";
            colPhai.Items.AddRange("Nam", "Nữ");
            dgvThongTinKhachHang.Columns.Add(colPhai);

            AddTextColumn("SĐT", "SDT");
            AddTextColumn("Địa Chỉ", "DIACHI");
            AddTextColumn("Ngày Sinh", "NGAYSINH");
            AddTextColumn("Email", "EMAIL");
            AddTextColumn("Điểm TL", "DIEMTICHLUY");

            dgvThongTinKhachHang.AllowUserToAddRows = false;
        }

        private void AddTextColumn(string header, string prop)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = header; col.DataPropertyName = prop;
            dgvThongTinKhachHang.Columns.Add(col);
        }

        private void LoadCustomerData()
        {
            try
            {
                string query = "SELECT * FROM KHACHHANG";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);
                bs.DataSource = dt;
                dgvThongTinKhachHang.DataSource = bs;
                AddBindings();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load KH: " + ex.Message); }
        }

        private void AddBindings()
        {
            txtMaKhachHang.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtTichDiem.DataBindings.Clear();
            mstNgay.DataBindings.Clear();
            cboPhai.DataBindings.Clear();
            cboMaHang.DataBindings.Clear();

            txtMaKhachHang.DataBindings.Add("Text", bs, "MAKH", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTen.DataBindings.Add("Text", bs, "HOTENKH", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSDT.DataBindings.Add("Text", bs, "SDT", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDiaChi.DataBindings.Add("Text", bs, "DIACHI", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", bs, "EMAIL", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTichDiem.DataBindings.Add("Text", bs, "DIEMTICHLUY", true, DataSourceUpdateMode.OnPropertyChanged);
            cboPhai.DataBindings.Add("Text", bs, "PHAI", true, DataSourceUpdateMode.OnPropertyChanged);
            cboMaHang.DataBindings.Add("SelectedValue", bs, "MAHANG", true, DataSourceUpdateMode.OnPropertyChanged);

            Binding bNgay = new Binding("Text", bs, "NGAYSINH", true);
            bNgay.FormatString = "dd/MM/yyyy"; bNgay.FormattingEnabled = true;
            mstNgay.DataBindings.Add(bNgay);
        }

        // ==================================================================
        // 2. NÚT THÊM (KHÓA DÒNG CŨ, MỞ DÒNG MỚI)
        // ==================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Mở khóa Grid để bắt đầu
                dgvThongTinKhachHang.ReadOnly = false;
                dgvThongTinKhachHang.SelectionMode = DataGridViewSelectionMode.CellSelect;

                // 2. KHÓA VÀ LÀM XÁM CÁC DÒNG CŨ (Để tránh sửa nhầm)
                foreach (DataGridViewRow row in dgvThongTinKhachHang.Rows)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }

                // 3. Thêm dòng mới
                bs.AddNew();
                dgvThongTinKhachHang.Focus();

                // 4. MỞ KHÓA RIÊNG DÒNG MỚI TẠO
                if (dgvThongTinKhachHang.Rows.Count > 0)
                {
                    int lastIndex = dgvThongTinKhachHang.Rows.Count - 1;
                    DataGridViewRow newRow = dgvThongTinKhachHang.Rows[lastIndex];

                    // Reset màu và mở khóa cho dòng mới
                    newRow.ReadOnly = false;
                    newRow.DefaultCellStyle.BackColor = Color.White;
                    newRow.DefaultCellStyle.ForeColor = Color.Black;

                    // Focus vào ô Mã KH
                    dgvThongTinKhachHang.CurrentCell = newRow.Cells["MAKH"];
                    dgvThongTinKhachHang.BeginEdit(true);
                }

                MessageBox.Show("Đã vào chế độ THÊM MỚI.\nCác dòng cũ đã bị khóa để bạn tập trung nhập liệu.", "Thông báo");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // ==================================================================
        // 3. NÚT SỬA (MỞ KHÓA TẤT CẢ)
        // ==================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Mở khóa Grid
            dgvThongTinKhachHang.ReadOnly = false;
            dgvThongTinKhachHang.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // 2. MỞ KHÓA VÀ TRẢ LẠI MÀU TRẮNG CHO TẤT CẢ DÒNG
            foreach (DataGridViewRow row in dgvThongTinKhachHang.Rows)
            {
                row.ReadOnly = false;
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

            MessageBox.Show("Đã mở chế độ SỬA.\nBạn có thể chỉnh sửa bất kỳ dòng nào (Trừ Mã KH cũ).", "Thông báo");
        }

        // ==================================================================
        // 4. NÚT XÓA (TÊN SỰ KIỆN: button2_Click)
        // ==================================================================
        private void button2_Click(object sender, EventArgs e)
        {
            if (bs.Current == null) return;

            if (MessageBox.Show("Bạn muốn xóa dòng này khỏi lưới (Chờ Lưu)?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bs.RemoveCurrent();
                MessageBox.Show("Đã xóa dòng khỏi lưới. Nhấn 'Lưu' để cập nhật Database.", "Thông báo");
            }
        }

        // ==================================================================
        // 5. NÚT LƯU (CẬP NHẬT DATABASE -> RESET TRẠNG THÁI)
        // ==================================================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvThongTinKhachHang.IsCurrentCellInEditMode) dgvThongTinKhachHang.EndEdit();
            this.Validate();
            bs.EndEdit();

            if (dt.GetChanges() == null)
            {
                MessageBox.Show("Không có thay đổi nào để lưu!");
                ResetGridState(); // Reset lại cho an toàn
                return;
            }

            try
            {
                conn.Open();
                foreach (DataRow row in dt.GetChanges().Rows)
                {
                    // XÓA
                    if (row.RowState == DataRowState.Deleted)
                    {
                        string ma = row["MAKH", DataRowVersion.Original].ToString();
                        string sql = "DELETE FROM KHACHHANG WHERE MAKH = @MAKH";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MAKH", ma);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    // THÊM HOẶC SỬA
                    else
                    {
                        // Kiểm tra Mã rỗng
                        if (row["MAKH"] == DBNull.Value || string.IsNullOrWhiteSpace(row["MAKH"].ToString()))
                        {
                            MessageBox.Show("Cảnh báo: Dòng thiếu Mã KH sẽ bị bỏ qua.");
                            continue;
                        }

                        string sql = "";
                        if (row.RowState == DataRowState.Added)
                        {
                            sql = @"INSERT INTO KHACHHANG (MAKH, MAHANG, HOTENKH, PHAI, SDT, DIACHI, NGAYSINH, EMAIL, DIEMTICHLUY) 
                                    VALUES (@MAKH, @MAHANG, @HOTENKH, @PHAI, @SDT, @DIACHI, @NGAYSINH, @EMAIL, @DIEM)";
                        }
                        else if (row.RowState == DataRowState.Modified)
                        {
                            sql = @"UPDATE KHACHHANG SET 
                                    MAHANG=@MAHANG, HOTENKH=@HOTENKH, PHAI=@PHAI, SDT=@SDT, 
                                    DIACHI=@DIACHI, NGAYSINH=@NGAYSINH, EMAIL=@EMAIL, DIEMTICHLUY=@DIEM 
                                    WHERE MAKH=@MAKH";
                        }
                        ExecuteInsertOrUpdate(sql, row);
                    }
                }

                dt.AcceptChanges();
                MessageBox.Show("Cập nhật Database thành công!", "Thông báo");

                // SAU KHI LƯU -> RESET VỀ TRẠNG THÁI CHỈ XEM
                ResetGridState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật Database: " + ex.Message);
                LoadCustomerData();
                ResetGridState();
            }
            finally { conn.Close(); }
        }

        private void ExecuteInsertOrUpdate(string sql, DataRow row)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                DataRowVersion ver = DataRowVersion.Current;

                cmd.Parameters.AddWithValue("@MAKH", row["MAKH", ver]);
                cmd.Parameters.AddWithValue("@MAHANG", row["MAHANG", ver] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HOTENKH", row["HOTENKH", ver]);
                cmd.Parameters.AddWithValue("@PHAI", row["PHAI", ver]);
                cmd.Parameters.AddWithValue("@SDT", row["SDT", ver]);
                cmd.Parameters.AddWithValue("@DIACHI", row["DIACHI", ver]);
                cmd.Parameters.AddWithValue("@EMAIL", row["EMAIL", ver]);
                cmd.Parameters.AddWithValue("@NGAYSINH", row["NGAYSINH", ver] ?? DBNull.Value);

                object diem = row["DIEMTICHLUY", ver];
                cmd.Parameters.AddWithValue("@DIEM", (diem != null && diem != DBNull.Value) ? diem : 0);

                cmd.ExecuteNonQuery();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCustomerData();
            ResetGridState();
        }

        private void btnDong_Click(object sender, EventArgs e) { this.Close(); }

        // Logic khóa Mã KH khi sửa dòng cũ (Chỉ được nhập mã nếu là dòng mới)
        private void dgvThongTinKhachHang_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvThongTinKhachHang.Columns[e.ColumnIndex].Name == "MAKH")
            {
                var val = dgvThongTinKhachHang.Rows[e.RowIndex].Cells["MAKH"].Value;
                bool isNew = (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString()));

                // Nếu dòng có dữ liệu -> Khóa (ReadOnly = true). Nếu dòng mới -> Mở.
                dgvThongTinKhachHang.Columns["MAKH"].ReadOnly = !isNew;
            }
        }

        private void dgvThongTinKhachHang_DataError(object sender, DataGridViewDataErrorEventArgs e) { e.ThrowException = false; }

        private void CustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

    }
}


