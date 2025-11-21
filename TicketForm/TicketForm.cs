using Common;
using System.Data;
using System.Data.SqlClient;
namespace TicketForm
{
    public partial class TicketForm : Form
    {
        SqlConnection conn;
        string str = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        BindingSource bs = new BindingSource();
        SqlDataAdapter da;
        DataTable dt; // Bảng VE (Chính)

        // Các bảng phụ cho ComboBox
        DataTable dtSuat;
        DataTable dtLoaiVe;
        DataTable dtKhach;
        DataTable dtNhanVien;
        DataTable dtGhe;

        public TicketForm()
        {
            InitializeComponent();
            conn = new SqlConnection(str);

            this.Load += TicketForm_Load;
            this.FormClosing += TicketForm_FormClosing;
        }

        // ==================================================================
        // 1. LOAD FORM & CẤU HÌNH
        // ==================================================================
        private void TicketForm_Load(object sender, EventArgs e)
        {
            SetControlsReadOnly();

            // Format ngày tháng
            mstNgayBan.Mask = "00/00/0000";
            mstNgayBan.ValidatingType = typeof(DateTime);

            LoadReferenceData();      // Load các bảng phụ (Suất, Khách, Ghế...)
            SetupDataGridViewColumns(); // Cấu hình cột Grid (ComboBox)
            LoadTicketData();         // Load dữ liệu Vé

            dgvTicket.DataError += dgvTicket_DataError;
            dgvTicket.CellEnter += dgvTicket_CellEnter;

            // Mặc định khóa Grid
            ResetGridState();
        }

        private void SetControlsReadOnly()
        {
            // TextBox/MaskedBox chỉ xem
            txtMaVe.ReadOnly = true;
            mstNgayBan.ReadOnly = true;

            // ComboBox khóa lại
            cboMaSuat.Enabled = false;
            cboMaLoaiVe.Enabled = false;
            cboMaKhachHang.Enabled = false;
            cboMaNhanVien.Enabled = false;
            cboMaGhe.Enabled = false;
        }

        private void ResetGridState()
        {
            dgvTicket.ReadOnly = true;
            dgvTicket.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewRow row in dgvTicket.Rows)
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

                // 1. Load SUATCHIEU (Join với Phim để hiện tên Phim cho dễ chọn)
                // Giả sử bảng PHIM có TENPHIM. Nếu không, bạn sửa query thành "SELECT MASUAT FROM SUATCHIEU"
                SqlDataAdapter daSuat = new SqlDataAdapter(@"
                    SELECT S.MASUAT, P.TENPHIM + ' (' + CONVERT(VARCHAR(5), S.GIOBATDAU) + ')' AS THONGTIN 
                    FROM SUATCHIEU S 
                    LEFT JOIN PHIM P ON S.MAPHIM = P.MAPHIM", conn);
                dtSuat = new DataTable();
                daSuat.Fill(dtSuat);
                cboMaSuat.DataSource = dtSuat; cboMaSuat.DisplayMember = "THONGTIN"; cboMaSuat.ValueMember = "MASUAT";

                // 2. Load LOAIVE
                SqlDataAdapter daLV = new SqlDataAdapter("SELECT MALV, TENLV FROM LOAIVE", conn);
                dtLoaiVe = new DataTable();
                daLV.Fill(dtLoaiVe);
                cboMaLoaiVe.DataSource = dtLoaiVe; cboMaLoaiVe.DisplayMember = "TENLV"; cboMaLoaiVe.ValueMember = "MALV";

                // 3. Load KHACHHANG
                SqlDataAdapter daKH = new SqlDataAdapter("SELECT MAKH, HOTENKH FROM KHACHHANG", conn);
                dtKhach = new DataTable();
                daKH.Fill(dtKhach);
                cboMaKhachHang.DataSource = dtKhach; cboMaKhachHang.DisplayMember = "HOTENKH"; cboMaKhachHang.ValueMember = "MAKH";

                // 4. Load NHANVIEN
                SqlDataAdapter daNV = new SqlDataAdapter("SELECT MANV, HOTENNV FROM NHANVIEN", conn);
                dtNhanVien = new DataTable();
                daNV.Fill(dtNhanVien);
                cboMaNhanVien.DataSource = dtNhanVien; cboMaNhanVien.DisplayMember = "HOTENNV"; cboMaNhanVien.ValueMember = "MANV";

                // 5. Load GHE
                SqlDataAdapter daGhe = new SqlDataAdapter("SELECT MAGHE, LOAIGHE FROM GHE", conn);
                dtGhe = new DataTable();
                daGhe.Fill(dtGhe);
                cboMaGhe.DataSource = dtGhe; cboMaGhe.DisplayMember = "MAGHE"; cboMaGhe.ValueMember = "MAGHE";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load danh mục: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void SetupDataGridViewColumns()
        {
            dgvTicket.AutoGenerateColumns = false;
            dgvTicket.Columns.Clear();

            // 1. Mã Vé
            DataGridViewTextBoxColumn colMa = new DataGridViewTextBoxColumn();
            colMa.HeaderText = "Mã Vé"; colMa.DataPropertyName = "MAVE"; colMa.Name = "MAVE";
            dgvTicket.Columns.Add(colMa);

            // 2. Suất Chiếu (Combo)
            DataGridViewComboBoxColumn colSuat = new DataGridViewComboBoxColumn();
            colSuat.HeaderText = "Suất/Phim"; colSuat.DataPropertyName = "MASUAT";
            colSuat.DataSource = dtSuat; colSuat.DisplayMember = "THONGTIN"; colSuat.ValueMember = "MASUAT"; colSuat.Width = 200;
            dgvTicket.Columns.Add(colSuat);

            // 3. Loại Vé (Combo)
            DataGridViewComboBoxColumn colLV = new DataGridViewComboBoxColumn();
            colLV.HeaderText = "Loại Vé"; colLV.DataPropertyName = "MALV";
            colLV.DataSource = dtLoaiVe; colLV.DisplayMember = "TENLV"; colLV.ValueMember = "MALV";
            dgvTicket.Columns.Add(colLV);

            // 4. Khách Hàng (Combo)
            DataGridViewComboBoxColumn colKH = new DataGridViewComboBoxColumn();
            colKH.HeaderText = "Khách Hàng"; colKH.DataPropertyName = "MAKH";
            colKH.DataSource = dtKhach; colKH.DisplayMember = "HOTENKH"; colKH.ValueMember = "MAKH"; colKH.Width = 150;
            dgvTicket.Columns.Add(colKH);

            // 5. Nhân Viên (Combo)
            DataGridViewComboBoxColumn colNV = new DataGridViewComboBoxColumn();
            colNV.HeaderText = "Nhân Viên"; colNV.DataPropertyName = "MANV";
            colNV.DataSource = dtNhanVien; colNV.DisplayMember = "HOTENNV"; colNV.ValueMember = "MANV"; colNV.Width = 150;
            dgvTicket.Columns.Add(colNV);

            // 6. Ghế (Combo)
            DataGridViewComboBoxColumn colGhe = new DataGridViewComboBoxColumn();
            colGhe.HeaderText = "Ghế"; colGhe.DataPropertyName = "MAGHE";
            colGhe.DataSource = dtGhe; colGhe.DisplayMember = "MAGHE"; colGhe.ValueMember = "MAGHE"; colGhe.Width = 80;
            dgvTicket.Columns.Add(colGhe);

            // 7. Ngày Bán
            DataGridViewTextBoxColumn colNgay = new DataGridViewTextBoxColumn();
            colNgay.HeaderText = "Ngày Bán"; colNgay.DataPropertyName = "NGAYBANVE";
            colNgay.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvTicket.Columns.Add(colNgay);

            dgvTicket.AllowUserToAddRows = false;
        }

        private void LoadTicketData()
        {
            try
            {
                string query = "SELECT * FROM VE";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);

                bs.DataSource = dt;
                dgvTicket.DataSource = bs;

                AddBindings();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void AddBindings()
        {
            txtMaVe.DataBindings.Clear();
            cboMaSuat.DataBindings.Clear();
            cboMaLoaiVe.DataBindings.Clear();
            cboMaKhachHang.DataBindings.Clear();
            cboMaNhanVien.DataBindings.Clear();
            cboMaGhe.DataBindings.Clear();
            mstNgayBan.DataBindings.Clear();

            txtMaVe.DataBindings.Add("Text", bs, "MAVE", true, DataSourceUpdateMode.OnPropertyChanged);
            cboMaSuat.DataBindings.Add("SelectedValue", bs, "MASUAT", true, DataSourceUpdateMode.OnPropertyChanged);
            cboMaLoaiVe.DataBindings.Add("SelectedValue", bs, "MALV", true, DataSourceUpdateMode.OnPropertyChanged);
            cboMaKhachHang.DataBindings.Add("SelectedValue", bs, "MAKH", true, DataSourceUpdateMode.OnPropertyChanged);
            cboMaNhanVien.DataBindings.Add("SelectedValue", bs, "MANV", true, DataSourceUpdateMode.OnPropertyChanged);
            cboMaGhe.DataBindings.Add("SelectedValue", bs, "MAGHE", true, DataSourceUpdateMode.OnPropertyChanged);

            Binding bNgay = new Binding("Text", bs, "NGAYBANVE", true);
            bNgay.FormatString = "dd/MM/yyyy";
            bNgay.FormattingEnabled = true;
            mstNgayBan.DataBindings.Add(bNgay);
        }

        // ==================================================================
        // 2. NÚT THÊM (Khóa dòng cũ, mở dòng mới)
        // ==================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvTicket.ReadOnly = false;
                dgvTicket.SelectionMode = DataGridViewSelectionMode.CellSelect;

                // Khóa dòng cũ
                foreach (DataGridViewRow row in dgvTicket.Rows)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }

                bs.AddNew();
                dgvTicket.Focus();

                if (dgvTicket.Rows.Count > 0)
                {
                    int lastIndex = dgvTicket.Rows.Count - 1;
                    DataGridViewRow newRow = dgvTicket.Rows[lastIndex];

                    newRow.ReadOnly = false;
                    newRow.DefaultCellStyle.BackColor = Color.White;
                    newRow.DefaultCellStyle.ForeColor = Color.Black;

                    dgvTicket.CurrentCell = newRow.Cells["MAVE"];
                    dgvTicket.BeginEdit(true);
                }
                MessageBox.Show("Đã thêm dòng mới. Hãy nhập liệu (Ngày bán nhập dd/MM/yyyy).", "Thông báo");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        // ==================================================================
        // 3. NÚT XÓA
        // ==================================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bs.Current == null) return;

            if (MessageBox.Show("Bạn muốn xóa vé này (Chờ Lưu)?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bs.RemoveCurrent();
                MessageBox.Show("Đã xóa trên lưới. Nhấn 'Lưu' để cập nhật Database.", "Thông báo");
            }
        }

        // ==================================================================
        // 4. NÚT SỬA (Mở khóa tất cả)
        // ==================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            dgvTicket.ReadOnly = false;
            dgvTicket.SelectionMode = DataGridViewSelectionMode.CellSelect;

            foreach (DataGridViewRow row in dgvTicket.Rows)
            {
                row.ReadOnly = false;
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            MessageBox.Show("Đã mở chế độ SỬA.", "Thông báo");
        }

        // ==================================================================
        // 5. NÚT LƯU (QUAN TRỌNG)
        // ==================================================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dgvTicket.IsCurrentCellInEditMode) dgvTicket.EndEdit();
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
                        string ma = row["MAVE", DataRowVersion.Original].ToString();
                        string sql = "DELETE FROM VE WHERE MAVE = @MA";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MA", ma);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Kiểm tra Mã Vé rỗng
                        if (row["MAVE"] == DBNull.Value || string.IsNullOrWhiteSpace(row["MAVE"].ToString()))
                        {
                            MessageBox.Show("Cảnh báo: Dòng thiếu Mã Vé sẽ bị bỏ qua.");
                            continue;
                        }

                        string sql = "";
                        if (row.RowState == DataRowState.Added)
                        {
                            sql = @"INSERT INTO VE (MAVE, MASUAT, MALV, MAKH, MANV, MAGHE, NGAYBANVE) 
                                    VALUES (@MA, @SUAT, @LV, @KH, @NV, @GHE, @NGAY)";
                        }
                        else if (row.RowState == DataRowState.Modified)
                        {
                            sql = @"UPDATE VE SET 
                                    MASUAT=@SUAT, MALV=@LV, MAKH=@KH, MANV=@NV, MAGHE=@GHE, NGAYBANVE=@NGAY
                                    WHERE MAVE=@MA";
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
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                LoadTicketData();
                ResetGridState();
            }
            finally { conn.Close(); }
        }

        private void ExecuteInsertOrUpdate(string sql, DataRow row)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                DataRowVersion ver = DataRowVersion.Current;

                cmd.Parameters.AddWithValue("@MA", row["MAVE", ver]);
                cmd.Parameters.AddWithValue("@SUAT", row["MASUAT", ver] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@LV", row["MALV", ver] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@KH", row["MAKH", ver] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NV", row["MANV", ver] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GHE", row["MAGHE", ver] ?? DBNull.Value);

                // Xử lý Ngày
                object valNgay = row["NGAYBANVE", ver];
                if (valNgay != null && valNgay != DBNull.Value && !string.IsNullOrEmpty(valNgay.ToString()))
                {
                    DateTime dtNgay;
                    if (valNgay is DateTime) dtNgay = (DateTime)valNgay;
                    else DateTime.TryParseExact(valNgay.ToString(), "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out dtNgay);

                    if (dtNgay != DateTime.MinValue) cmd.Parameters.AddWithValue("@NGAY", dtNgay);
                    else cmd.Parameters.AddWithValue("@NGAY", DBNull.Value);
                }
                else cmd.Parameters.AddWithValue("@NGAY", DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        private void btnDong_Click(object sender, EventArgs e) { this.Close(); }

        private void dgvTicket_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTicket.Columns[e.ColumnIndex].Name == "MAVE")
            {
                var val = dgvTicket.Rows[e.RowIndex].Cells["MAVE"].Value;
                bool isNew = (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString()));
                dgvTicket.Columns["MAVE"].ReadOnly = !isNew;
            }
        }

        private void dgvTicket_DataError(object sender, DataGridViewDataErrorEventArgs e) { e.ThrowException = false; }

        private void TicketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
