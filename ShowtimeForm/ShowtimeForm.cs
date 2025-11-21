using Common;
using System.Data;
using System.Data.SqlClient;
namespace ShowtimeForm
{
    public partial class ShowtimeForm : Form
    {
        // --- KHAI BÁO BIẾN ---
        SqlConnection conn;
        string str = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        BindingSource bs = new BindingSource();
        SqlDataAdapter da;
        DataTable dt;
        DataTable dtPhim;
        DataTable dtPhong;

        public ShowtimeForm()
        {
            InitializeComponent();
            conn = new SqlConnection(str);

            this.Load += ShowtimeForm_Load;
            this.FormClosing += ShowtimeForm_FormClosing;
        }

        // ==================================================================
        // 1. LOAD FORM
        // ==================================================================
        private void ShowtimeForm_Load(object sender, EventArgs e)
        {
            SetControlsReadOnly();
            LoadReferenceData();
            SetupDataGridViewColumns();
            LoadShowtimeData();

            dgvShowTime.DataError += dgvShowTime_DataError;
            dgvShowTime.CellEnter += dgvShowTime_CellEnter;

            // Mặc định khóa
            ResetGridState();
        }

        private void SetControlsReadOnly()
        {
            txtMaSuat.ReadOnly = true;
            mskGioBatDau.ReadOnly = true;
             mskGioKetThuc.ReadOnly = true;
            mskNgayChieu.ReadOnly = true;
            txtSoLuong.ReadOnly = true;

            txtMaSuat.Enabled = false;
            mskGioBatDau.Enabled = false;
            mskGioKetThuc.Enabled= false;
            mskNgayChieu.Enabled = false;
            txtSoLuong.Enabled = false;
            cboPhim.Enabled = false;
            cboPhong.Enabled = false;
        }

        private void ResetGridState()
        {
            dgvShowTime.ReadOnly = true;
            dgvShowTime.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewRow row in dgvShowTime.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void LoadReferenceData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Load PHIM
                SqlDataAdapter daPhim = new SqlDataAdapter("SELECT MAPHIM, TENPHIM FROM PHIM", conn);
                dtPhim = new DataTable();
                daPhim.Fill(dtPhim);
                cboPhim.DataSource = dtPhim; cboPhim.DisplayMember = "TENPHIM"; cboPhim.ValueMember = "MAPHIM";

                // Load PHÒNG
                SqlDataAdapter daPhong = new SqlDataAdapter("SELECT MAPHONG, TENPHONG FROM PHONGCHIEU", conn);
                dtPhong = new DataTable();
                daPhong.Fill(dtPhong);
                cboPhong.DataSource = dtPhong; cboPhong.DisplayMember = "TENPHONG"; cboPhong.ValueMember = "MAPHONG";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load danh mục: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void SetupDataGridViewColumns()
        {
            dgvShowTime.AutoGenerateColumns = false;
            dgvShowTime.Columns.Clear();

            // Mã Suất
            DataGridViewTextBoxColumn colMa = new DataGridViewTextBoxColumn();
            colMa.HeaderText = "Mã Suất"; colMa.DataPropertyName = "MASUAT"; colMa.Name = "MASUAT";
            dgvShowTime.Columns.Add(colMa);

            // Phim
            DataGridViewComboBoxColumn colPhim = new DataGridViewComboBoxColumn();
            colPhim.HeaderText = "Phim"; colPhim.DataPropertyName = "MAPHIM";
            colPhim.DataSource = dtPhim; colPhim.DisplayMember = "TENPHIM"; colPhim.ValueMember = "MAPHIM"; colPhim.Width = 200;
            dgvShowTime.Columns.Add(colPhim);

            // Phòng
            DataGridViewComboBoxColumn colPhong = new DataGridViewComboBoxColumn();
            colPhong.HeaderText = "Phòng Chiếu"; colPhong.DataPropertyName = "MAPHONG";
            colPhong.DataSource = dtPhong; colPhong.DisplayMember = "TENPHONG"; colPhong.ValueMember = "MAPHONG"; colPhong.Width = 120;
            dgvShowTime.Columns.Add(colPhong);

            // Giờ
            AddTextColumn("Giờ BĐ", "GIOBATDAU");
            AddTextColumn("Giờ KT", "GIOKETTHUC");

            // 🟩 NGÀY CHIẾU (Định dạng hiển thị trên Grid cho đúng chuẩn Việt Nam)
            DataGridViewTextBoxColumn colNgay = new DataGridViewTextBoxColumn();
            colNgay.HeaderText = "Ngày Chiếu";
            colNgay.DataPropertyName = "NGAYCHIEU";
            colNgay.DefaultCellStyle.Format = "dd/MM/yyyy"; // Định dạng hiển thị
            dgvShowTime.Columns.Add(colNgay);

            // Số lượng
            AddTextColumn("Số Lượng", "SOLUONG");

            dgvShowTime.AllowUserToAddRows = false;
        }

        private void AddTextColumn(string header, string prop)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = header; col.DataPropertyName = prop;
            dgvShowTime.Columns.Add(col);
        }

        private void LoadShowtimeData()
        {
            try
            {
                string query = "SELECT * FROM SUATCHIEU";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);

                bs.DataSource = dt;
                dgvShowTime.DataSource = bs;

                AddBindings();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void AddBindings()
        {
            txtMaSuat.DataBindings.Clear();
            cboPhim.DataBindings.Clear();
            cboPhong.DataBindings.Clear();
            mskGioBatDau.DataBindings.Clear();
            mskGioKetThuc.DataBindings.Clear();
            mskGioBatDau.DataBindings.Clear();
            mskNgayChieu.DataBindings.Clear();

            txtMaSuat.DataBindings.Add("Text", bs, "MASUAT", true, DataSourceUpdateMode.OnPropertyChanged);
            cboPhim.DataBindings.Add("SelectedValue", bs, "MAPHIM", true, DataSourceUpdateMode.OnPropertyChanged);
            cboPhong.DataBindings.Add("SelectedValue", bs, "MAPHONG", true, DataSourceUpdateMode.OnPropertyChanged);

            // Format Giờ
            Binding bGioBD = new Binding("Text", bs, "GIOBATDAU", true);
            bGioBD.Format += (s, e) => { if (e.Value != DBNull.Value) e.Value = e.Value.ToString(); };
            mskGioBatDau.DataBindings.Add(bGioBD);

            Binding bGioKT = new Binding("Text", bs, "GIOKETTHUC", true);
            bGioKT.Format += (s, e) => { if (e.Value != DBNull.Value) e.Value = e.Value.ToString(); };
            mskGioKetThuc.DataBindings.Add(bGioKT);

            // Format Ngày
            Binding bNgay = new Binding("Text", bs, "NGAYCHIEU", true);
            bNgay.FormatString = "dd/MM/yyyy";
            bNgay.FormattingEnabled = true;
            mskNgayChieu.DataBindings.Add(bNgay);

            txtSoLuong.DataBindings.Add("Text", bs, "SOLUONG", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        // ==================================================================
        // 2. NÚT THÊM
        // ==================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvShowTime.ReadOnly = false;
                dgvShowTime.SelectionMode = DataGridViewSelectionMode.CellSelect;

                // Khóa dòng cũ
                foreach (DataGridViewRow row in dgvShowTime.Rows)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }

                bs.AddNew();
                dgvShowTime.Focus();

                if (dgvShowTime.Rows.Count > 0)
                {
                    int lastIndex = dgvShowTime.Rows.Count - 1;
                    DataGridViewRow newRow = dgvShowTime.Rows[lastIndex];

                    newRow.ReadOnly = false;
                    newRow.DefaultCellStyle.BackColor = Color.White;
                    newRow.DefaultCellStyle.ForeColor = Color.Black;

                    dgvShowTime.CurrentCell = newRow.Cells["MASUAT"];
                    dgvShowTime.BeginEdit(true);
                }
                MessageBox.Show("Đã thêm dòng mới. Hãy nhập liệu (Ngày chiếu nhập dd/MM/yyyy).", "Thông báo");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        // ==================================================================
        // 3. NÚT XÓA
        // ==================================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bs.Current == null) return;

            if (MessageBox.Show("Bạn muốn xóa suất chiếu này (Chờ Lưu)?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bs.RemoveCurrent();
                MessageBox.Show("Đã xóa trên lưới. Nhấn 'Lưu' để cập nhật.", "Thông báo");
            }
        }

        // ==================================================================
        // 4. NÚT SỬA
        // ==================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            dgvShowTime.ReadOnly = false;
            dgvShowTime.SelectionMode = DataGridViewSelectionMode.CellSelect;

            foreach (DataGridViewRow row in dgvShowTime.Rows)
            {
                row.ReadOnly = false;
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            MessageBox.Show("Đã mở chế độ SỬA.", "Thông báo");
        }

        // ==================================================================
        // 5. NÚT LƯU (ĐÃ SỬA LỖI NGÀY THÁNG)
        // ==================================================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dgvShowTime.IsCurrentCellInEditMode) dgvShowTime.EndEdit();
            this.Validate();
            bs.EndEdit();

            if (dt.GetChanges() == null)
            {
                MessageBox.Show("Không có thay đổi nào để lưu!");
                ResetGridState();
                return;
            }

            try
            {
                conn.Open();
                foreach (DataRow row in dt.GetChanges().Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                    {
                        string ma = row["MASUAT", DataRowVersion.Original].ToString();
                        string sql = "DELETE FROM SUATCHIEU WHERE MASUAT = @MA";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MA", ma);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Kiểm tra Mã Suất
                        if (row["MASUAT"] == DBNull.Value || string.IsNullOrWhiteSpace(row["MASUAT"].ToString()))
                        {
                            MessageBox.Show("Cảnh báo: Dòng thiếu Mã Suất sẽ bị bỏ qua.");
                            continue;
                        }

                        string sql = "";
                        if (row.RowState == DataRowState.Added)
                        {
                            sql = @"INSERT INTO SUATCHIEU (MASUAT, MAPHONG, MAPHIM, GIOBATDAU, GIOKETTHUC, NGAYCHIEU, SOLUONG) 
                                    VALUES (@MA, @PHONG, @PHIM, @BD, @KT, @NGAY, @SL)";
                        }
                        else if (row.RowState == DataRowState.Modified)
                        {
                            sql = @"UPDATE SUATCHIEU SET 
                                    MAPHONG=@PHONG, MAPHIM=@PHIM, GIOBATDAU=@BD, GIOKETTHUC=@KT, NGAYCHIEU=@NGAY, SOLUONG=@SL
                                    WHERE MASUAT=@MA";
                        }
                        ExecuteInsertOrUpdate(sql, row);
                    }
                }

                dt.AcceptChanges();
                MessageBox.Show("Cập nhật Database thành công!", "Thông báo");
                ResetGridState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message + "\n(Hãy kiểm tra định dạng ngày dd/MM/yyyy)");
                LoadShowtimeData();
                ResetGridState();
            }
            finally { conn.Close(); }
        }

        private void ExecuteInsertOrUpdate(string sql, DataRow row)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                DataRowVersion ver = DataRowVersion.Current;

                cmd.Parameters.AddWithValue("@MA", row["MASUAT", ver]);
                cmd.Parameters.AddWithValue("@PHONG", row["MAPHONG", ver] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PHIM", row["MAPHIM", ver] ?? DBNull.Value);

                // Xử lý Giờ
                object gioBD = row["GIOBATDAU", ver];
                cmd.Parameters.AddWithValue("@BD", (gioBD != null && gioBD != DBNull.Value) ? TimeSpan.Parse(gioBD.ToString()) : DBNull.Value);

                object gioKT = row["GIOKETTHUC", ver];
                cmd.Parameters.AddWithValue("@KT", (gioKT != null && gioKT != DBNull.Value) ? TimeSpan.Parse(gioKT.ToString()) : DBNull.Value);

                // 🟩 XỬ LÝ NGÀY CHIẾU (QUAN TRỌNG NHẤT)
                object valNgay = row["NGAYCHIEU", ver];
                if (valNgay != null && valNgay != DBNull.Value && !string.IsNullOrEmpty(valNgay.ToString()))
                {
                    DateTime dtNgay;
                    // Trường hợp 1: Dữ liệu là DateTime sẵn (do Binding từ Database)
                    if (valNgay is DateTime)
                    {
                        dtNgay = (DateTime)valNgay;
                    }
                    // Trường hợp 2: Dữ liệu là String (do người dùng nhập trên Grid dạng dd/MM/yyyy)
                    else
                    {
                        // Cố gắng parse theo định dạng Việt Nam
                        if (!DateTime.TryParseExact(valNgay.ToString(), "dd/MM/yyyy",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None, out dtNgay))
                        {
                            // Nếu thất bại, thử parse mặc định
                            DateTime.TryParse(valNgay.ToString(), out dtNgay);
                        }
                    }

                    // Nếu parse được thì truyền vào, nếu không được thì truyền DBNull hoặc ngày mặc định
                    if (dtNgay != DateTime.MinValue)
                        cmd.Parameters.AddWithValue("@NGAY", dtNgay);
                    else
                        cmd.Parameters.AddWithValue("@NGAY", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@NGAY", DBNull.Value);
                }

                // Xử lý Số lượng
                object sl = row["SOLUONG", ver];
                cmd.Parameters.AddWithValue("@SL", (sl != null && sl != DBNull.Value) ? sl : 0);

                cmd.ExecuteNonQuery();
            }
        }

        private void btnDong_Click(object sender, EventArgs e) { this.Close(); }

        private void dgvShowTime_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvShowTime.Columns[e.ColumnIndex].Name == "MASUAT")
            {
                var val = dgvShowTime.Rows[e.RowIndex].Cells["MASUAT"].Value;
                bool isNew = (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString()));
                dgvShowTime.Columns["MASUAT"].ReadOnly = !isNew;
            }
        }

        private void dgvShowTime_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false; // Chặn crash
        }

        private void ShowtimeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
