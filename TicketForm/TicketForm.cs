using Common;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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

            BuildTreeView();
        }


        private void BuildTreeView()
        {
            treeView1.Nodes.Clear();

            // Parent root
            TreeNode root = new TreeNode("Danh sách vé");
            treeView1.Nodes.Add(root);

            // Nhóm theo suất chiếu
            var group = dt.AsEnumerable().GroupBy(r => r.Field<string>("MASUAT"));

            foreach (var g in group)
            {
                // lấy thông tin suất
                string maSuat = g.Key;
                string tenSuat = dtSuat.AsEnumerable()
                                       .Where(x => x["MASUAT"].ToString() == maSuat)
                                       .Select(x => x["THONGTIN"].ToString())
                                       .FirstOrDefault();

                TreeNode suatNode = new TreeNode($"{maSuat} - {tenSuat}");
                suatNode.Tag = maSuat;
                root.Nodes.Add(suatNode);

                foreach (DataRow row in g)
                {
                    string maVe = row["MAVE"].ToString();
                    TreeNode veNode = new TreeNode($"Vé {maVe}");
                    veNode.Tag = row; // tag chính là DataRow
                    suatNode.Nodes.Add(veNode);
                }
            }

            treeView1.ExpandAll();
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
        // 5. NÚT LƯU (QUAN TRỌNG)
        // ==================================================================


        private void SaveChangesToDatabase()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            DataTable changes = dt.GetChanges();
            if (changes == null)
            {
                conn.Close();
                return;
            }

            foreach (DataRow row in changes.Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    string sql = @"INSERT INTO VE
                (MAVE, MASUAT, MALV, MAKH, MANV, MAGHE, NGAYBANVE)
                VALUES (@MA, @SUAT, @LV, @KH, @NV, @GHE, @NGAY)";
                    ExecuteInsertOrUpdate(sql, row);
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    string sql = @"UPDATE VE SET
                MASUAT=@SUAT, MALV=@LV, MAKH=@KH,
                MANV=@NV, MAGHE=@GHE, NGAYBANVE=@NGAY
                WHERE MAVE=@MA";
                    ExecuteInsertOrUpdate(sql, row);
                }
                else if (row.RowState == DataRowState.Deleted)
                {
                    try
                    {
                        using SqlCommand cmd = new SqlCommand(
                       "DELETE FROM VE WHERE MAVE=@MA", conn);
                        cmd.Parameters.Add("@MA", SqlDbType.VarChar)
                           .Value = row["MAVE", DataRowVersion.Original];
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Không thể xóa vé vì có dữ liệu liên quan.");
                        return;
                    }
                }
            }

            dt.AcceptChanges();
            conn.Close();
        }


        //private void ExecuteInsertOrUpdate(string sql, DataRow row)
        //{
        //    using (SqlCommand cmd = new SqlCommand(sql, conn))
        //    {
        //        DataRowVersion ver = DataRowVersion.Current;

        //        cmd.Parameters.AddWithValue("@MA", row["MAVE", ver]);
        //        cmd.Parameters.AddWithValue("@SUAT", row["MASUAT", ver] ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@LV", row["MALV", ver] ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@KH", row["MAKH", ver] ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@NV", row["MANV", ver] ?? DBNull.Value);
        //        cmd.Parameters.AddWithValue("@GHE", row["MAGHE", ver] ?? DBNull.Value);

        //        // Xử lý Ngày
        //        object valNgay = row["NGAYBANVE", ver];
        //        if (valNgay != null && valNgay != DBNull.Value && !string.IsNullOrEmpty(valNgay.ToString()))
        //        {
        //            DateTime dtNgay;
        //            if (valNgay is DateTime) dtNgay = (DateTime)valNgay;
        //            else DateTime.TryParseExact(valNgay.ToString(), "dd/MM/yyyy",
        //                System.Globalization.CultureInfo.InvariantCulture,
        //                System.Globalization.DateTimeStyles.None, out dtNgay);

        //            if (dtNgay != DateTime.MinValue) cmd.Parameters.AddWithValue("@NGAY", dtNgay);
        //            else cmd.Parameters.AddWithValue("@NGAY", DBNull.Value);
        //        }
        //        else cmd.Parameters.AddWithValue("@NGAY", DBNull.Value);

        //        cmd.ExecuteNonQuery();
        //    }
        //}


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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            // Nếu Tag là null → Node root → hiển thị tất cả vé
            if (e.Node.Tag == null)
            {
                bs.DataSource = dt;
                return;
            }

            // Nếu Tag là string → đó là MASUAT
            if (e.Node.Tag is string maSuat)
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = $"MASUAT = '{maSuat}'";
                bs.DataSource = dv;
                return;
            }

            // Nếu Tag chứa DataRow → Node vé → chọn vé trên lưới
            if (e.Node.Tag is DataRow row)
            {
                string maVe = row["MAVE"].ToString();

                // Tìm dòng tương ứng trong BindingSource
                for (int i = 0; i < bs.Count; i++)
                {
                    DataRowView drv = bs[i] as DataRowView;
                    if (drv != null && drv["MAVE"].ToString() == maVe)
                    {
                        bs.Position = i;
                        break;
                    }
                }

                // Hiển thị dữ liệu vé lên form (bindings sẽ tự cập nhật)
                txtMaVe.Text = row["MAVE"].ToString();
                cboMaSuat.SelectedValue = row["MASUAT"];
                cboMaLoaiVe.SelectedValue = row["MALV"];
                cboMaKhachHang.SelectedValue = row["MAKH"];
                cboMaNhanVien.SelectedValue = row["MANV"];
                cboMaGhe.SelectedValue = row["MAGHE"];

                if (row["NGAYBANVE"] != DBNull.Value)
                {
                    DateTime d = (DateTime)row["NGAYBANVE"];
                    mstNgayBan.Text = d.ToString("dd/MM/yyyy");
                }
                else mstNgayBan.Clear();
            }
        }

        private void SetControlsEditable()
        {
            txtMaVe.ReadOnly = false;
            mstNgayBan.ReadOnly = false;
            mstNgayBan.Enabled = true;

            cboMaSuat.Enabled = true;
            cboMaLoaiVe.Enabled = true;
            cboMaKhachHang.Enabled = true;
            cboMaNhanVien.Enabled = true;
            cboMaGhe.Enabled = true;
        }

        

        private void btnThem_Click_1(object sender, EventArgs e)
        {

            SetControlsEditable();

            txtMaVe.Clear();
            mstNgayBan.Clear();

            cboMaSuat.SelectedIndex = -1;
            cboMaLoaiVe.SelectedIndex = -1;
            cboMaKhachHang.SelectedIndex = -1;
            cboMaNhanVien.SelectedIndex = -1;
            cboMaGhe.SelectedIndex = -1;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            dgvTicket.Enabled = false;

            txtMaVe.Focus();
        }




        //private void btnLuu_Click_1(object sender, EventArgs e)
        //{
        //    string maVe = txtMaVe.Text.Trim();
        //    if (string.IsNullOrEmpty(maVe))
        //    {
        //        MessageBox.Show("Mã vé không được trống");
        //        return;
        //    }

        //    // Tìm xem có tồn tại không
        //    DataRow row = dt.AsEnumerable()
        //        .FirstOrDefault(x => x["MAVE"].ToString() == maVe);

        //    bool isNew = row == null;

        //    if (isNew)
        //    {
        //        row = dt.NewRow();
        //        row["MAVE"] = maVe;
        //        dt.Rows.Add(row);
        //    }

        //    row["MASUAT"] = cboMaSuat.SelectedValue;
        //    row["MALV"] = cboMaLoaiVe.SelectedValue;
        //    row["MAKH"] = cboMaKhachHang.SelectedValue;
        //    row["MANV"] = cboMaNhanVien.SelectedValue;
        //    row["MAGHE"] = cboMaGhe.SelectedValue;

        //    DateTime ngay;
        //    if (DateTime.TryParseExact(mstNgayBan.Text, "dd/MM/yyyy",
        //        System.Globalization.CultureInfo.InvariantCulture,
        //        System.Globalization.DateTimeStyles.None, out ngay))
        //    {
        //        row["NGAYBANVE"] = ngay;
        //    }

        //    SaveChangesToDatabase();
        //    BuildTreeView();

        //    MessageBox.Show(isNew ? "Đã thêm vé mới" : "Đã cập nhật vé");
        //}



        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maVe = txtMaVe.Text.Trim();
            if (string.IsNullOrEmpty(maVe))
            {
                MessageBox.Show("Chưa chọn vé để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn chắc muốn xóa vé này?",
                "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            DataRow row = dt.AsEnumerable()
                .FirstOrDefault(r => r["MAVE"].ToString() == maVe);

            if (row == null)
            {
                MessageBox.Show("Không tìm thấy vé trong dữ liệu.");
                return;
            }

            row.Delete();

            SaveChangesToDatabase();
            BuildTreeView();

            MessageBox.Show("Đã xóa vé.");
        }

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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaVe.Text))
            {
                MessageBox.Show("Mã vé không được trống");
                return;
            }

            //if (!DateTime.TryParseExact(
            //    mstNgayBan.Text, "dd/MM/yyyy",
            //    CultureInfo.InvariantCulture,
            //    DateTimeStyles.None,
            //    out DateTime ngay))
            //{
            //    MessageBox.Show("Ngày không hợp lệ (dd/MM/yyyy)");
            //    return;
            //}

            // KIỂM TRA TỒN TẠI
            DataRow row = dt.AsEnumerable()
                .FirstOrDefault(r => r.RowState != DataRowState.Deleted &&
                                     r["MAVE"].ToString() == txtMaVe.Text.Trim());

            bool isNew = row == null;

            if (isNew)
            {
                row = dt.NewRow();        // 🔥 tạo row ở đây
                row["MAVE"] = txtMaVe.Text.Trim();
                dt.Rows.Add(row);
            }

            row["MASUAT"] = cboMaSuat.SelectedValue;
            row["MALV"] = cboMaLoaiVe.SelectedValue;
            row["MAKH"] = cboMaKhachHang.SelectedValue;
            row["MANV"] = cboMaNhanVien.SelectedValue;
            row["MAGHE"] = cboMaGhe.SelectedValue;
            row["NGAYBANVE"] = DateTime.Now;

            SaveChangesToDatabase();
            BuildTreeView();

            SetControlsReadOnly();
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            dgvTicket.Enabled = true;

            MessageBox.Show(isNew ? "Đã thêm vé mới" : "Đã cập nhật vé");
        }
        private void ExecuteInsertOrUpdate(string sql, DataRow row)
        {
            using SqlCommand cmd = new SqlCommand(sql, conn);

            DataRowVersion ver = DataRowVersion.Current;

            cmd.Parameters.Add("@MA", SqlDbType.VarChar).Value = row["MAVE"];
            cmd.Parameters.Add("@SUAT", SqlDbType.VarChar).Value = row["MASUAT"];
            cmd.Parameters.Add("@LV", SqlDbType.VarChar).Value = row["MALV"];
            cmd.Parameters.Add("@KH", SqlDbType.VarChar).Value = row["MAKH"];
            cmd.Parameters.Add("@NV", SqlDbType.VarChar).Value = row["MANV"];
            cmd.Parameters.Add("@GHE", SqlDbType.VarChar).Value = row["MAGHE"];
            cmd.Parameters.Add("@NGAY", SqlDbType.Date).Value = row["NGAYBANVE"];


            cmd.ExecuteNonQuery();
        }

    }
}
