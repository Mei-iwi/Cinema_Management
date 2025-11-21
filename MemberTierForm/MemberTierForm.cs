using Common;
using System.Data;
using System.Data.SqlClient;
namespace MemberTierForm
{
    public partial class MemberTierForm : Form
    {
        // --- KHAI BÁO BIẾN ---
        SqlConnection conn;
        string str = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        BindingSource bs = new BindingSource();
        SqlDataAdapter da;
        DataTable dt; // Bảng HANGTHANHVIEN

        public MemberTierForm()
        {
            InitializeComponent();
            conn = new SqlConnection(str);

            // Gắn sự kiện Load
            this.Load += MemberTierForm_Load;
            this.FormClosing += MemberTierForm_FormClosing;
        }

        // ==================================================================
        // 1. LOAD FORM & CẤU HÌNH MẶC ĐỊNH
        // ==================================================================
        private void MemberTierForm_Load(object sender, EventArgs e)
        {
            SetControlsReadOnly();
            LoadData();
            SetupDataGridViewColumns();

            dgvHienThi.DataError += dgvHienThi_DataError;
            dgvHienThi.CellEnter += dgvHienThi_CellEnter;

            // 🟩 TRẠNG THÁI BAN ĐẦU: Khóa Grid, Chọn cả dòng
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SetControlsReadOnly()
        {
            txtMaHang.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDiem.ReadOnly = true;
            txtUuDai.ReadOnly = true;
            txtMoTa.ReadOnly = true;
        }

        private void SetupDataGridViewColumns()
        {
            dgvHienThi.AutoGenerateColumns = false;
            dgvHienThi.Columns.Clear();

            // Cột Mã Hạng
            DataGridViewTextBoxColumn colMa = new DataGridViewTextBoxColumn();
            colMa.HeaderText = "Mã Hạng"; colMa.DataPropertyName = "MAHANG"; colMa.Name = "MAHANG";
            dgvHienThi.Columns.Add(colMa);

            // Cột Tên Hạng
            DataGridViewTextBoxColumn colTen = new DataGridViewTextBoxColumn();
            colTen.HeaderText = "Tên Hạng"; colTen.DataPropertyName = "TENHANG"; colTen.Width = 150;
            dgvHienThi.Columns.Add(colTen);

            // Cột Điểm
            DataGridViewTextBoxColumn colDiem = new DataGridViewTextBoxColumn();
            colDiem.HeaderText = "Điểm Tối Thiểu"; colDiem.DataPropertyName = "DIEMTOITHIEU";
            dgvHienThi.Columns.Add(colDiem);

            // Cột Ưu Đãi
            DataGridViewTextBoxColumn colUuDai = new DataGridViewTextBoxColumn();
            colUuDai.HeaderText = "Ưu Đãi"; colUuDai.DataPropertyName = "UUDAI"; colUuDai.Width = 200;
            dgvHienThi.Columns.Add(colUuDai);

            // Cột Mô Tả
            DataGridViewTextBoxColumn colMoTa = new DataGridViewTextBoxColumn();
            colMoTa.HeaderText = "Mô Tả"; colMoTa.DataPropertyName = "MOTA"; colMoTa.Width = 200;
            dgvHienThi.Columns.Add(colMoTa);

            dgvHienThi.AllowUserToAddRows = false;
        }

        private void LoadData()
        {
            try
            {
                string query = "SELECT * FROM HANGTHANHVIEN";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);

                bs.DataSource = dt;
                dgvHienThi.DataSource = bs;

                AddBindings();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        private void AddBindings()
        {
            txtMaHang.DataBindings.Clear();
            txtTenHang.DataBindings.Clear();
            txtDiem.DataBindings.Clear();
            txtUuDai.DataBindings.Clear();
            txtMoTa.DataBindings.Clear();

            txtMaHang.DataBindings.Add("Text", bs, "MAHANG", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenHang.DataBindings.Add("Text", bs, "TENHANG", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDiem.DataBindings.Add("Text", bs, "DIEMTOITHIEU", true, DataSourceUpdateMode.OnPropertyChanged);
            txtUuDai.DataBindings.Add("Text", bs, "UUDAI", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMoTa.DataBindings.Add("Text", bs, "MOTA", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        // ==================================================================
        // 2. NÚT THÊM (KHÓA DÒNG CŨ, MỞ DÒNG MỚI)
        // ==================================================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Mở khóa Grid tổng thể
                dgvHienThi.ReadOnly = false;
                dgvHienThi.SelectionMode = DataGridViewSelectionMode.CellSelect;

                // 2. KHÓA VÀ LÀM XÁM TẤT CẢ CÁC DÒNG CŨ
                foreach (DataGridViewRow row in dgvHienThi.Rows)
                {
                    row.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    row.DefaultCellStyle.ForeColor = Color.DarkGray;
                }

                // 3. Tạo dòng mới
                bs.AddNew();
                dgvHienThi.Focus();

                // 4. Mở khóa riêng dòng mới tạo
                if (dgvHienThi.Rows.Count > 0)
                {
                    int lastIndex = dgvHienThi.Rows.Count - 1;
                    DataGridViewRow newRow = dgvHienThi.Rows[lastIndex];

                    // Reset giao diện cho dòng mới
                    newRow.ReadOnly = false;
                    newRow.DefaultCellStyle.BackColor = Color.White;
                    newRow.DefaultCellStyle.ForeColor = Color.Black;

                    // Đặt trỏ chuột vào
                    dgvHienThi.CurrentCell = newRow.Cells["MAHANG"];
                    dgvHienThi.BeginEdit(true);
                }

                MessageBox.Show("Đã tạo dòng mới. Các dòng cũ đã được khóa lại để tránh sửa nhầm.", "Chế độ Thêm");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi thêm: " + ex.Message); }
        }

        // ==================================================================
        // 3. NÚT SỬA (MỞ KHÓA TOÀN BỘ ĐỂ SỬA)
        // ==================================================================
        private void btnSua_Click(object sender, EventArgs e)
        {
            // 1. Mở khóa Grid
            dgvHienThi.ReadOnly = false;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // 2. Reset màu và mở khóa tất cả dòng
            foreach (DataGridViewRow row in dgvHienThi.Rows)
            {
                row.ReadOnly = false;
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

            MessageBox.Show("Đã bật chế độ Sửa. Bạn có thể chỉnh sửa dữ liệu trên lưới (Trừ Mã Hạng cũ).", "Chế độ Sửa");
        }

        // ==================================================================
        // 4. NÚT XÓA
        // ==================================================================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (bs.Current == null) return;

            if (MessageBox.Show("Xóa dòng này khỏi lưới (Chưa xóa Database)?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bs.RemoveCurrent();
                MessageBox.Show("Đã xóa dòng khỏi lưới. Nhấn 'Lưu' để xác nhận xóa trong Database.", "Thông báo");
            }
        }

        // ==================================================================
        // 5. NÚT LƯU (CẬP NHẬT SQL -> KHÓA GRID LẠI)
        // ==================================================================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Chốt dữ liệu
            if (dgvHienThi.IsCurrentCellInEditMode) dgvHienThi.EndEdit();
            this.Validate();
            bs.EndEdit();

            if (dt.GetChanges() == null)
            {
                MessageBox.Show("Không có dữ liệu nào thay đổi để lưu!");
                // Reset lại trạng thái khóa cho an toàn
                ResetGridState();
                return;
            }

            try
            {
                conn.Open();
                foreach (DataRow row in dt.GetChanges().Rows)
                {
                    // --- XỬ LÝ XÓA ---
                    if (row.RowState == DataRowState.Deleted)
                    {
                        string ma = row["MAHANG", DataRowVersion.Original].ToString();
                        string sql = "DELETE FROM HANGTHANHVIEN WHERE MAHANG = @MA";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MA", ma);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    // --- XỬ LÝ THÊM HOẶC SỬA ---
                    else
                    {
                        // Kiểm tra Mã Hạng rỗng
                        if (row["MAHANG"] == DBNull.Value || string.IsNullOrWhiteSpace(row["MAHANG"].ToString()))
                        {
                            MessageBox.Show("Cảnh báo: Dòng dữ liệu thiếu Mã Hạng sẽ bị bỏ qua.");
                            continue;
                        }

                        string sql = "";
                        if (row.RowState == DataRowState.Added)
                        {
                            sql = @"INSERT INTO HANGTHANHVIEN (MAHANG, TENHANG, DIEMTOITHIEU, UUDAI, MOTA) 
                                    VALUES (@MA, @TEN, @DIEM, @UU, @MO)";
                        }
                        else if (row.RowState == DataRowState.Modified)
                        {
                            sql = @"UPDATE HANGTHANHVIEN SET TENHANG=@TEN, DIEMTOITHIEU=@DIEM, UUDAI=@UU, MOTA=@MO 
                                    WHERE MAHANG=@MA";
                        }
                        ExecuteInsertOrUpdate(sql, row);
                    }
                }

                dt.AcceptChanges();
                MessageBox.Show("Cập nhật Database thành công!", "Thông báo");

                // 🟩 3. KHÓA LẠI SAU KHI LƯU
                ResetGridState();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) MessageBox.Show("Lỗi: Hạng này đang được sử dụng, không thể xóa!");
                else MessageBox.Show("Lỗi SQL: " + ex.Message);
                LoadData(); // Load lại để đồng bộ
                ResetGridState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                LoadData();
                ResetGridState();
            }
            finally { conn.Close(); }
        }

        // Hàm reset trạng thái Grid về ban đầu (Khóa, Trắng)
        private void ResetGridState()
        {
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Trả lại màu trắng cho tất cả các dòng
            foreach (DataGridViewRow row in dgvHienThi.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void ExecuteInsertOrUpdate(string sql, DataRow row)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                DataRowVersion ver = DataRowVersion.Current;

                cmd.Parameters.AddWithValue("@MA", row["MAHANG", ver]);
                cmd.Parameters.AddWithValue("@TEN", row["TENHANG", ver]);

                object diem = row["DIEMTOITHIEU", ver];
                cmd.Parameters.AddWithValue("@DIEM", (diem != null && diem != DBNull.Value) ? diem : 0);

                cmd.Parameters.AddWithValue("@UU", row["UUDAI", ver]);
                cmd.Parameters.AddWithValue("@MO", row["MOTA", ver]);

                cmd.ExecuteNonQuery();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e) { LoadData(); ResetGridState(); }
        private void btnDong_Click(object sender, EventArgs e) { this.Close(); }

        // Logic: Khóa Mã Hạng khi sửa dòng cũ (Chỉ cho sửa mã khi dòng đó Mới Tinh)
        private void dgvHienThi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHienThi.Columns[e.ColumnIndex].Name == "MAHANG")
            {
                // Kiểm tra giá trị ô Mã Hạng
                var val = dgvHienThi.Rows[e.RowIndex].Cells["MAHANG"].Value;
                bool isEmpty = (val == null || val == DBNull.Value || string.IsNullOrEmpty(val.ToString()));

                // Nếu ô có dữ liệu -> Khóa. Nếu ô trống -> Mở.
                dgvHienThi.Columns["MAHANG"].ReadOnly = !isEmpty;
            }
        }

        private void MemberTierForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if(r ==DialogResult.No)
            {
                e.Cancel = true;
            }    
        }

        private void dgvHienThi_DataError(object sender, DataGridViewDataErrorEventArgs e) { e.ThrowException = false; }
    }
}


