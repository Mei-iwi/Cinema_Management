using Common;
using System.Data;
using System.Data.SqlClient;
namespace MemberTierForm
{
    public partial class MemberTierForm : Form
    {
        SqlConnection conn;
        public MemberTierForm()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=DESKTOP-IQCO6JU\\SQLEXPRESS;Initial catalog=QL_RAP_PHIM;User ID=sa;Password=123");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HANGTHANHVIEN", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHienThi.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void ClearInput()
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtDiem.Clear();
            txtUuDai.Clear();
            txtMoTa.Clear();
        }


        private void MemberTierForm_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvHienThi.ReadOnly = true; // Không cho chỉnh trực tiếp
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaHang.Text) ||
                    string.IsNullOrWhiteSpace(txtTenHang.Text) ||
                    string.IsNullOrWhiteSpace(txtDiem.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc (Mã hạng, Tên hạng, Điểm tối thiểu).");
                    return;
                }

                // --- Kiểm tra MÃ HẠNG đã tồn tại chưa ---
                string checkQuery = "SELECT COUNT(*) FROM HANGTHANHVIEN WHERE MAHANG = @MAHANG";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@MAHANG", txtMaHang.Text);

                conn.Open();
                int count = (int)checkCmd.ExecuteScalar();
                conn.Close();

                if (count > 0)
                {
                    MessageBox.Show("Mã hạng này đã tồn tại, vui lòng nhập mã khác!");
                    return;
                }

                // --- Kiểm tra DIEMTOITHIEU là số ---
                if (!int.TryParse(txtDiem.Text, out int diem))
                {
                    MessageBox.Show("Điểm tối thiểu phải là số nguyên!");
                    return;
                }

                // --- Thêm dữ liệu mới ---
                string insertQuery = @"INSERT INTO HANGTHANHVIEN (MAHANG, TENHANG, DIEMTOITHIEU, UUDAI, MOTA)
                               VALUES (@MAHANG, @TENHANG, @DIEMTOITHIEU, @UUDAI, @MOTA)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@MAHANG", txtMaHang.Text);
                insertCmd.Parameters.AddWithValue("@TENHANG", txtTenHang.Text);
                insertCmd.Parameters.AddWithValue("@DIEMTOITHIEU", diem);
                insertCmd.Parameters.AddWithValue("@UUDAI", txtUuDai.Text);
                insertCmd.Parameters.AddWithValue("@MOTA", txtMoTa.Text);

                conn.Open();
                insertCmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Thêm thành công!");
                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
                conn.Close();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa hạng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string query = "DELETE FROM HANGTHANHVIEN WHERE MAHANG = @MAHANG";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MAHANG", txtMaHang.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                    ClearInput();
                }
                catch (SqlException ex)
                {
                    conn.Close();
                    // 547 là lỗi vi phạm ràng buộc FK
                    if (ex.Number == 547)
                        MessageBox.Show("Không thể xóa do đang được sử dụng ở bảng khác!");
                    else
                        MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"UPDATE HANGTHANHVIEN 
                                 SET TENHANG = @TENHANG, DIEMTOITHIEU = @DIEMTOITHIEU, UUDAI = @UUDAI, MOTA = @MOTA 
                                 WHERE MAHANG = @MAHANG";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAHANG", txtMaHang.Text);
                cmd.Parameters.AddWithValue("@TENHANG", txtTenHang.Text);
                cmd.Parameters.AddWithValue("@DIEMTOITHIEU", txtDiem.Text);
                cmd.Parameters.AddWithValue("@UUDAI", txtUuDai.Text);
                cmd.Parameters.AddWithValue("@MOTA", txtMoTa.Text);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                if (rows > 0)
                    MessageBox.Show("Cập nhật thành công!");
                else
                    MessageBox.Show("Không tìm thấy mã hạng để sửa.");

                LoadData();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
                conn.Close();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }

        private void MemberTierForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {

            }
        }
    }
}
