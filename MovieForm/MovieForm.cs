using Common;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieForm
{
    public partial class MovieForm : Form
    {
        SqlConnection conn;
        string strConnectionString = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        BindingSource bs = new BindingSource();
        SqlDataAdapter da;
        DataTable dt;
        DataTable dtTheLoai;
        DataTable dtDangPhim;

        public MovieForm()
        {
            InitializeComponent();
            conn = new SqlConnection(strConnectionString);

            this.Load += MovieForm_Load;
            this.FormClosing += MovieForm_FormClosing;
        }

        // ==================================================================
        // 1. LOAD FORM & CẤU HÌNH MẶC ĐỊNH
        // ==================================================================
        private void MovieForm_Load(object sender, EventArgs e)
        {
            SetTextBoxReadOnly();
            SetupControlFormats();
            LoadReferenceData();
            SetupDataGridViewColumns();
            LoadPhim();

            dgvPhim.DataError += dgvPhim_DataError;
            dgvPhim.CellEnter += dgvPhim_CellEnter;

            // 🟩 CẤU HÌNH MẶC ĐỊNH: Khóa Grid, Chọn cả dòng
            ResetGridState();
        }

        // Hàm đưa Grid về trạng thái chỉ xem
        private void ResetGridState()
        {
            dgvPhim.ReadOnly = true;
            dgvPhim.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Trả lại màu trắng cho tất cả dòng
            foreach (DataGridViewRow row in dgvPhim.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void SetTextBoxReadOnly()
        {
            txtMa.ReadOnly = true;
            txtTenPhim.ReadOnly = true;
            txtNhaSanXuat.ReadOnly = true;
            mstNgayKhoiChieu.ReadOnly = true;
            mstNgayKetThuc.ReadOnly = true;
            mstThoiLuong.ReadOnly = true;
            mstCapNhat.ReadOnly = true;

            cboTheLoai.Enabled = false;
            cboDangPhim.Enabled = false;
        }

        private void SetupControlFormats()
        {
            mstNgayKhoiChieu.Mask = "00/00/0000";
            mstNgayKetThuc.Mask = "00/00/0000";
            mstThoiLuong.Mask = "00:00:00";
            mstCapNhat.Mask = "00/00/0000 00:00:00";

            mstNgayKhoiChieu.ValidatingType = typeof(DateTime);
            mstNgayKetThuc.ValidatingType = typeof(DateTime);
            mstThoiLuong.ValidatingType = typeof(TimeSpan);
            mstCapNhat.ValidatingType = typeof(DateTime);
        }

        private void LoadReferenceData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlDataAdapter daTL = new SqlDataAdapter("SELECT MATHELOAI, TENTHELOAI FROM THELOAIPHIM", conn);
                dtTheLoai = new DataTable();
                daTL.Fill(dtTheLoai);
                cboTheLoai.DataSource = dtTheLoai; cboTheLoai.DisplayMember = "TENTHELOAI"; cboTheLoai.ValueMember = "MATHELOAI";

                SqlDataAdapter daDP = new SqlDataAdapter("SELECT MADP, DANGPHIM FROM DANGPHIM", conn);
                dtDangPhim = new DataTable();
                daDP.Fill(dtDangPhim);
                cboDangPhim.DataSource = dtDangPhim; cboDangPhim.DisplayMember = "DANGPHIM"; cboDangPhim.ValueMember = "MADP";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load danh mục: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void SetupDataGridViewColumns()
        {
            dgvPhim.AutoGenerateColumns = false;
            dgvPhim.Columns.Clear();

            DataGridViewTextBoxColumn colMa = new DataGridViewTextBoxColumn();
            colMa.HeaderText = "Mã Phim"; colMa.DataPropertyName = "MAPHIM"; colMa.Name = "MAPHIM";
            dgvPhim.Columns.Add(colMa);

            DataGridViewTextBoxColumn colTen = new DataGridViewTextBoxColumn();
            colTen.HeaderText = "Tên Phim"; colTen.DataPropertyName = "TENPHIM"; colTen.Width = 200;
            dgvPhim.Columns.Add(colTen);

            DataGridViewComboBoxColumn colTL = new DataGridViewComboBoxColumn();
            colTL.HeaderText = "Thể Loại"; colTL.DataPropertyName = "MATHELOAI";
            colTL.DataSource = dtTheLoai; colTL.DisplayMember = "TENTHELOAI"; colTL.ValueMember = "MATHELOAI"; colTL.Width = 150;
            dgvPhim.Columns.Add(colTL);

            DataGridViewComboBoxColumn colDP = new DataGridViewComboBoxColumn();
            colDP.HeaderText = "Dạng Phim"; colDP.DataPropertyName = "MADP";
            colDP.DataSource = dtDangPhim; colDP.DisplayMember = "DANGPHIM"; colDP.ValueMember = "MADP"; colDP.Width = 120;
            dgvPhim.Columns.Add(colDP);

            AddTextColumn("Nhà SX", "NHASX");
            AddTextColumn("Ngày KC", "NGAYKHOICHIEU");
            AddTextColumn("Ngày KT", "NGAYKETTHUC");
            AddTextColumn("Thời Lượng", "THOILUONG");
            AddTextColumn("Cập nhật", "NGAYCAPNHAT");

            dgvPhim.AllowUserToAddRows = false;
        }

        private void AddTextColumn(string header, string property)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = header; col.DataPropertyName = property;
            dgvPhim.Columns.Add(col);
        }

        private void LoadPhim()
        {
            try
            {
                string query = "SELECT * FROM PHIM";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);

                bs.DataSource = dt;
                dgvPhim.DataSource = bs;

                AddBindings();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void AddBindings()
        {
            txtMa.DataBindings.Clear();
            txtTenPhim.DataBindings.Clear();
            txtNhaSanXuat.DataBindings.Clear();
            cboTheLoai.DataBindings.Clear();
            cboDangPhim.DataBindings.Clear();
            mstNgayKhoiChieu.DataBindings.Clear();
            mstNgayKetThuc.DataBindings.Clear();
            mstThoiLuong.DataBindings.Clear();
            mstCapNhat.DataBindings.Clear();

            txtMa.DataBindings.Add("Text", bs, "MAPHIM", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenPhim.DataBindings.Add("Text", bs, "TENPHIM", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNhaSanXuat.DataBindings.Add("Text", bs, "NHASX", true, DataSourceUpdateMode.OnPropertyChanged);
            cboTheLoai.DataBindings.Add("SelectedValue", bs, "MATHELOAI", true, DataSourceUpdateMode.OnPropertyChanged);
            cboDangPhim.DataBindings.Add("SelectedValue", bs, "MADP", true, DataSourceUpdateMode.OnPropertyChanged);

            Binding bNgayKC = new Binding("Text", bs, "NGAYKHOICHIEU", true); bNgayKC.FormatString = "dd/MM/yyyy"; bNgayKC.FormattingEnabled = true;
            mstNgayKhoiChieu.DataBindings.Add(bNgayKC);

            Binding bNgayKT = new Binding("Text", bs, "NGAYKETTHUC", true); bNgayKT.FormatString = "dd/MM/yyyy"; bNgayKT.FormattingEnabled = true;
            mstNgayKetThuc.DataBindings.Add(bNgayKT);

            Binding bCapNhat = new Binding("Text", bs, "NGAYCAPNHAT", true); bCapNhat.FormatString = "dd/MM/yyyy HH:mm:ss"; bCapNhat.FormattingEnabled = true;
            mstCapNhat.DataBindings.Add(bCapNhat);

            Binding bThoiLuong = new Binding("Text", bs, "THOILUONG", true);
            bThoiLuong.Format += (s, e) => { if (e.Value != DBNull.Value) e.Value = ((TimeSpan)e.Value).ToString(@"hh\:mm\:ss"); };
            mstThoiLuong.DataBindings.Add(bThoiLuong);
        }

        // ==================================================================
        // 2. NÚT THÊM (KHÓA DÒNG CŨ - CHỈ NHẬP DÒNG MỚI)
        // ==================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Mở khóa Grid
                dgvPhim.ReadOnly = false;
                dgvPhim.SelectionMode = DataGridViewSelectionMode.CellSelect;

                // 2. 🟩 KHÓA VÀ LÀM XÁM TOÀN BỘ DÒNG CŨ
                foreach (DataGridViewRow row in dgvPhim.Rows)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }

                // 3. Tạo dòng mới
                bs.AddNew();
                dgvPhim.Focus();

                // 4. 🟩 CHỈ MỞ KHÓA DÒNG MỚI
                if (dgvPhim.Rows.Count > 0)
                {
                    int lastIndex = dgvPhim.Rows.Count - 1;
                    DataGridViewRow newRow = dgvPhim.Rows[lastIndex];

                    // Reset màu và mở khóa cho dòng mới
                    newRow.ReadOnly = false;
                    newRow.DefaultCellStyle.BackColor = Color.White;
                    newRow.DefaultCellStyle.ForeColor = Color.Black;

                    // Focus vào ô Mã
                    dgvPhim.CurrentCell = newRow.Cells["MAPHIM"];
                    dgvPhim.BeginEdit(true);
                }
                MessageBox.Show("Đã thêm dòng mới. Các dòng cũ đã bị khóa để tránh sửa nhầm.", "Thông báo");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // ==================================================================
        // 3. NÚT SỬA (MỞ KHÓA TẤT CẢ)
        // ==================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Mở khóa Grid
            dgvPhim.ReadOnly = false;
            dgvPhim.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // 2. 🟩 MỞ KHÓA VÀ TRẢ LẠI MÀU TRẮNG CHO TẤT CẢ
            foreach (DataGridViewRow row in dgvPhim.Rows)
            {
                row.ReadOnly = false;
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

            MessageBox.Show("Đã mở chế độ SỬA. Bạn có thể sửa bất kỳ dòng nào (Trừ Mã Phim cũ).", "Thông báo");
        }

        // ==================================================================
        // 4. NÚT XÓA
        // ==================================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bs.Current == null) return;

            if (MessageBox.Show("Xóa phim này khỏi lưới (Chưa xóa DB)?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bs.RemoveCurrent();
                MessageBox.Show("Đã xóa khỏi lưới. Nhấn LƯU để xóa vĩnh viễn trong Database.", "Thông báo");
            }
        }

        // ==================================================================
        // 5. NÚT LƯU (CẬP NHẬT SQL -> KHÓA LẠI)
        // ==================================================================
        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (dgvPhim.IsCurrentCellInEditMode) dgvPhim.EndEdit();
            this.Validate();
            bs.EndEdit();

            if (dt.GetChanges() == null)
            {
                MessageBox.Show("Không có dữ liệu nào thay đổi để lưu!");
                ResetGridState(); // Khóa lại cho an toàn
                return;
            }

            try
            {
                conn.Open();
                foreach (DataRow row in dt.GetChanges().Rows)
                {
                    if (row.RowState == DataRowState.Deleted)
                    {
                        string ma = row["MAPHIM", DataRowVersion.Original].ToString();
                        string sql = "DELETE FROM PHIM WHERE MAPHIM = @Ma";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Ma", ma);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        if (row["MAPHIM"] == DBNull.Value || string.IsNullOrWhiteSpace(row["MAPHIM"].ToString()))
                        {
                            MessageBox.Show("Cảnh báo: Dòng dữ liệu thiếu Mã Phim sẽ bị bỏ qua.");
                            continue;
                        }

                        string sql = "";
                        if (row.RowState == DataRowState.Added)
                        {
                            sql = @"INSERT INTO PHIM (MAPHIM, MATHELOAI, MADP, TENPHIM, NHASX, NGAYKHOICHIEU, NGAYKETTHUC, THOILUONG, NGAYCAPNHAT) 
                                    VALUES (@Ma, @TL, @DP, @Ten, @SX, @KC, @KT, @Time, @CN)";
                        }
                        else if (row.RowState == DataRowState.Modified)
                        {
                            sql = @"UPDATE PHIM SET MATHELOAI=@TL, MADP=@DP, TENPHIM=@Ten, NHASX=@SX, 
                                    NGAYKHOICHIEU=@KC, NGAYKETTHUC=@KT, THOILUONG=@Time, NGAYCAPNHAT=@CN WHERE MAPHIM=@Ma";
                        }
                        ExecuteInsertOrUpdate(sql, row);
                    }
                }

                dt.AcceptChanges();
                MessageBox.Show("Cập nhật Database thành công!", "Thông báo");

                // 🟩 SAU KHI LƯU XONG -> RESET VỀ TRẠNG THÁI BAN ĐẦU
                ResetGridState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật Database: " + ex.Message);
                LoadPhim();
                ResetGridState();
            }
            finally { conn.Close(); }
        }

        private void ExecuteInsertOrUpdate(string sql, DataRow row)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                DataRowVersion ver = DataRowVersion.Current;

                cmd.Parameters.AddWithValue("@Ma", row["MAPHIM", ver]);
                cmd.Parameters.AddWithValue("@TL", row["MATHELOAI", ver] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DP", row["MADP", ver] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Ten", row["TENPHIM", ver]);
                cmd.Parameters.AddWithValue("@SX", row["NHASX", ver]);
                cmd.Parameters.AddWithValue("@KC", row["NGAYKHOICHIEU", ver] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@KT", row["NGAYKETTHUC", ver] ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CN", row["NGAYCAPNHAT", ver] ?? DBNull.Value);

                object valTime = row["THOILUONG", ver];
                if (valTime != null && valTime != DBNull.Value)
                {
                    if (valTime is TimeSpan) cmd.Parameters.AddWithValue("@Time", valTime);
                    else cmd.Parameters.AddWithValue("@Time", TimeSpan.Parse(valTime.ToString()));
                }
                else cmd.Parameters.AddWithValue("@Time", TimeSpan.Zero);

                cmd.ExecuteNonQuery();
            }
        }

        // Logic khóa cột Mã Phim khi sửa dòng cũ
        private void dgvPhim_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPhim.Columns[e.ColumnIndex].Name == "MAPHIM")
            {
                var val = dgvPhim.Rows[e.RowIndex].Cells["MAPHIM"].Value;
                // Nếu ô trống -> Dòng mới -> Cho nhập. Nếu có dữ liệu -> Dòng cũ -> Khóa.
                bool isNewRow = (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString()));
                dgvPhim.Columns["MAPHIM"].ReadOnly = !isNewRow;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e) { LoadPhim(); ResetGridState(); }
        private void btnDong_Click(object sender, EventArgs e) { this.Close(); }

        private void MovieForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r; 
            r = MessageBox.Show("Bạn có muốn thoát không?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void dgvPhim_DataError(object sender, DataGridViewDataErrorEventArgs e) { e.ThrowException = false; }
    }
}



 