using Common;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
namespace MovieForm
{
    public partial class MovieForm : Form
    {
        SqlConnection conn;
        string str = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        public MovieForm()
        {
            InitializeComponent();
            conn = new SqlConnection(str);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 🟩 Load thể loại phim
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT MATHELOAI, TENTHELOAI FROM THELOAIPHIM", conn);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cboTheLoai.DataSource = dt1;
            cboTheLoai.DisplayMember = "TENTHELOAI";
            cboTheLoai.ValueMember = "MATHELOAI";

            // 🟩 Load dạng phim
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT MADP, DANGPHIM FROM DANGPHIM", conn);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cboDangPhim.DataSource = dt2;
            cboDangPhim.DisplayMember = "DANGPHIM";
            cboDangPhim.ValueMember = "MADP";

            // 🟩 Load danh sách phim
            LoadPhim();
            ///////////
            mstNgayKhoiChieu.Mask = "00/00/0000";
            mstNgayKetThuc.Mask = "00/00/0000";
            mstThoiLuong.Mask = "00:00:00";
            mstCapNhat.Mask = "00/00/0000 00:00:00";

            mstNgayKhoiChieu.ValidatingType = typeof(DateTime);
            mstNgayKetThuc.ValidatingType = typeof(DateTime);
            mstCapNhat.ValidatingType = typeof(DateTime);
            /////////////////////
            dgvPhim.ReadOnly = true;                    // không cho sửa ô
            dgvPhim.AllowUserToAddRows = false;         // không cho thêm dòng
            dgvPhim.AllowUserToDeleteRows = false;      // không cho xóa dòng
            dgvPhim.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // chọn nguyên hàng
            dgvPhim.MultiSelect = false;
        }
        private void LoadPhim()
        {
            string query = @"SELECT P.MAPHIM, T.TENTHELOAI, D.DANGPHIM, P.TENPHIM, P.NHASX, 
                            P.NGAYKHOICHIEU, P.NGAYKETTHUC, P.THOILUONG, P.NGAYCAPNHAT
                     FROM PHIM P
                     JOIN THELOAIPHIM T ON P.MATHELOAI = T.MATHELOAI
                     JOIN DANGPHIM D ON P.MADP = D.MADP";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPhim.DataSource = dt;
            dgvPhim.ReadOnly = true;
            dgvPhim.AllowUserToAddRows = false;
        }
        private void maskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            MaskedTextBox mtb = sender as MaskedTextBox;
            string name = mtb.Name;

            // Nếu ô rỗng -> bỏ qua, không báo lỗi
            if (string.IsNullOrWhiteSpace(mtb.Text.Trim()))
                return;

            // Nếu là ô thời lượng (HH:mm:ss)
            if (name == "mtbThoiLuong")
            {
                if (!TimeSpan.TryParse(mtb.Text, out _))
                {
                    MessageBox.Show("Thời lượng không hợp lệ (định dạng đúng là HH:mm:ss).",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
                return;
            }

            // Còn lại là kiểu ngày
            if (!DateTime.TryParse(mtb.Text, out _))
            {
                MessageBox.Show("Ngày hoặc giờ không hợp lệ ở ô: " + name,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            conn.Open();
            // Kiểm tra trùng mã
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM PHIM WHERE MAPHIM = @MAPHIM", conn);
            checkCmd.Parameters.AddWithValue("@MAPHIM", txtMa.Text);
            int exists = (int)checkCmd.ExecuteScalar();

            if (exists > 0)
            {
                MessageBox.Show("Mã phim đã tồn tại!");
                conn.Close();
                return;
            }

            // Lấy dữ liệu
            if (!TimeSpan.TryParse(mstThoiLuong.Text, out TimeSpan thoiLuong))
            {
                MessageBox.Show("Thời lượng không hợp lệ!");
                conn.Close();
                return;
            }

            SqlCommand cmd = new SqlCommand(@"INSERT INTO PHIM VALUES (@MAPHIM, @MATHELOAI, @MADP, @TENPHIM, @NHASX,
                                    @NGAYKHOICHIEU, @NGAYKETTHUC, @THOILUONG, @NGAYCAPNHAT)", conn);
            cmd.Parameters.AddWithValue("@MAPHIM", txtMa.Text);
            cmd.Parameters.AddWithValue("@MATHELOAI", cboTheLoai.SelectedValue);
            cmd.Parameters.AddWithValue("@MADP", cboDangPhim.SelectedValue);
            cmd.Parameters.AddWithValue("@TENPHIM", txtTenPhim.Text);
            cmd.Parameters.AddWithValue("@NHASX", txtNhaSanXuat.Text);
            cmd.Parameters.AddWithValue("@NGAYKHOICHIEU", DateTime.Parse(mstNgayKhoiChieu.Text));
            cmd.Parameters.AddWithValue("@NGAYKETTHUC", DateTime.Parse(mstNgayKetThuc.Text));
            cmd.Parameters.AddWithValue("@THOILUONG", thoiLuong);
            cmd.Parameters.AddWithValue("@NGAYCAPNHAT", DateTime.Parse(mstCapNhat.Text));

            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Thêm phim thành công!");
            ClearAll();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maPhim = txtMa.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa phim này không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            conn.Open();
            SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM SUATCHIEU WHERE MAPHIM = @MAPHIM", conn);
            check.Parameters.AddWithValue("@MAPHIM", maPhim);
            int used = (int)check.ExecuteScalar();

            if (used > 0)
            {
                MessageBox.Show("Không thể xóa vì phim đang được sử dụng!");
                conn.Close();
                return;
            }

            SqlCommand del = new SqlCommand("DELETE FROM PHIM WHERE MAPHIM = @MAPHIM", conn);
            del.Parameters.AddWithValue("@MAPHIM", maPhim);
            del.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Đã xóa thành công!");
            ClearAll();

        }
        private void ClearAll()
        {
            txtMa.Clear();
            txtTenPhim.Clear();
            txtNhaSanXuat.Clear();
            mstNgayKhoiChieu.Clear();
            mstNgayKetThuc.Clear();
            mstThoiLuong.Clear();
            mstCapNhat.Clear();
            cboTheLoai.SelectedIndex = 0;
            cboDangPhim.SelectedIndex = 0;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadPhim();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPhim = txtMa.Text.Trim();
            if (string.IsNullOrEmpty(maPhim))
            {
                MessageBox.Show("Vui lòng nhập mã phim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy giá trị mới, nếu trống thì để DBNull (sẽ giữ nguyên trong DB)
            string tenPhim = string.IsNullOrWhiteSpace(txtTenPhim.Text) ? null : txtTenPhim.Text;
            string nhaSX = string.IsNullOrWhiteSpace(txtNhaSanXuat.Text) ? null : txtNhaSanXuat.Text;
            string maTL = cboTheLoai.SelectedValue?.ToString();
            string maDP = cboDangPhim.SelectedValue?.ToString();

            DateTime? ngayKC = null;
            if (mstNgayKhoiChieu.MaskCompleted && !string.IsNullOrWhiteSpace(mstNgayKhoiChieu.Text))
                ngayKC = DateTime.ParseExact(mstNgayKhoiChieu.Text, "dd/MM/yyyy", null);

            DateTime? ngayKT = null;
            if (mstNgayKetThuc.MaskCompleted && !string.IsNullOrWhiteSpace(mstNgayKetThuc.Text))
                ngayKT = DateTime.ParseExact(mstNgayKetThuc.Text, "dd/MM/yyyy", null);

            TimeSpan? thoiLuong = null;
            if (!string.IsNullOrWhiteSpace(mstThoiLuong.Text))
                thoiLuong = TimeSpan.Parse(mstThoiLuong.Text);

            DateTime? ngayCapNhat = null;
            if (mstCapNhat.MaskCompleted && !string.IsNullOrWhiteSpace(mstCapNhat.Text))
                ngayCapNhat = DateTime.ParseExact(mstCapNhat.Text, "dd/MM/yyyy HH:mm:ss", null);

            try
            {
                string sql = @"
            UPDATE PHIM SET
                MATHELOAI = ISNULL(@MATHELOAI, MATHELOAI),
                MADP = ISNULL(@MADP, MADP),
                TENPHIM = ISNULL(@TENPHIM, TENPHIM),
                NHASX = ISNULL(@NHASX, NHASX),
                NGAYKHOICHIEU = ISNULL(@NGAYKHOICHIEU, NGAYKHOICHIEU),
                NGAYKETTHUC = ISNULL(@NGAYKETTHUC, NGAYKETTHUC),
                THOILUONG = ISNULL(@THOILUONG, THOILUONG),
                NGAYCAPNHAT = ISNULL(@NGAYCAPNHAT, NGAYCAPNHAT)
            WHERE MAPHIM = @MAPHIM";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MAPHIM", maPhim);
                    cmd.Parameters.AddWithValue("@MATHELOAI", (object)maTL ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MADP", (object)maDP ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TENPHIM", (object)tenPhim ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NHASX", (object)nhaSX ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NGAYKHOICHIEU", (object)ngayKC ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NGAYKETTHUC", (object)ngayKT ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@THOILUONG", (object)thoiLuong ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NGAYCAPNHAT", (object)ngayCapNhat ?? DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearAll(); // xóa hết textbox
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MovieForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
