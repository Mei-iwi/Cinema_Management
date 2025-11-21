using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Common;

namespace StaffForm
{
    public partial class TimNhanVien : Form
    {
        // --- KHAI BÁO BIẾN ---
        SqlConnection conn;
        string str = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        // Các biến phục vụ DataBinding
        BindingSource bs = new BindingSource();
        SqlDataAdapter da;
        DataTable dt;
        SqlCommandBuilder cmdb; // "Đũa thần" tự sinh lệnh Insert/Update/Delete

        public TimNhanVien()
        {
            InitializeComponent();
            conn = new SqlConnection(str);
        }

        // 1. LOAD FORM (Load dữ liệu và cấu hình Binding)
        private void TimNhanVien_Load(object sender, EventArgs e)
        {
            // Cấu hình Grid cho phép nhập liệu
            dgvNhanVien.ReadOnly = false;           // Cho phép sửa
            dgvNhanVien.AllowUserToAddRows = true;  // Cho phép thêm dòng mới
            dgvNhanVien.AllowUserToDeleteRows = true; // Cho phép xóa (nhấn nút Delete trên bàn phím)

            // Xử lý lỗi DataError để tránh crash khi nhập sai kiểu dữ liệu
            dgvNhanVien.DataError += dgvNhanVien_DataError;

            LoadAllNhanVien();
        }

        private void LoadAllNhanVien()
        {
            try
            {
                // Khởi tạo Adapter với câu lệnh SELECT
                string query = "SELECT * FROM NHANVIEN";
                da = new SqlDataAdapter(query, conn);

                // Tự động sinh lệnh Insert/Update/Delete dựa trên SELECT
                // Yêu cầu: Bảng NHANVIEN trong SQL phải có Khóa Chính (Primary Key)
                cmdb = new SqlCommandBuilder(da);

                dt = new DataTable();
                da.Fill(dt);

                // Gắn dữ liệu vào BindingSource
                bs.DataSource = dt;

                // Gắn BindingSource vào Grid
                dgvNhanVien.DataSource = bs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        // 2. NÚT TÌM (Dùng Filter của BindingSource)
        private void btnTim_Click(object sender, EventArgs e)
        {
            string maNV = txtMa.Text.Trim();

            // Nếu ô tìm kiếm trống thì bỏ lọc (hiện tất cả)
            if (string.IsNullOrEmpty(maNV))
            {
                bs.RemoveFilter();
                return;
            }

            try
            {
                // Lọc dữ liệu ngay trên BindingSource
                // Lưu ý: Cách này giúp bạn tìm thấy dòng đó VÀ VẪN SỬA ĐƯỢC NÓ
                bs.Filter = $"MANV = '{maNV}'";
                // Hoặc tìm gần đúng: bs.Filter = $"MANV LIKE '%{maNV}%'";

                if (bs.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // 3. NÚT HIỂN THỊ TẤT CẢ (Bỏ lọc)
        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            bs.RemoveFilter();
            txtMa.Clear();
        }

        // 4. SỰ KIỆN ĐÓNG FORM
        private void TimNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // 5. NÚT LƯU (BẠN CẦN THÊM NÚT NÀY TRÊN FORM ĐỂ CẬP NHẬT SQL)
        // Hãy tạo một nút tên btnLuu và gán sự kiện này vào
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết thúc chỉnh sửa trên Grid
                dgvNhanVien.EndEdit();
                bs.EndEdit();

                // Kiểm tra có thay đổi không
                if (dt.GetChanges() == null)
                {
                    MessageBox.Show("Không có thay đổi nào để lưu.");
                    return;
                }

                // Cập nhật xuống SQL
                // SqlCommandBuilder sẽ tự động lo liệu việc Insert/Update/Delete
                da.Update(dt);

                MessageBox.Show("Cập nhật dữ liệu thành công!");
                dt.AcceptChanges(); // Đồng bộ trạng thái
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message + "\n(Hãy kiểm tra ràng buộc khóa chính/khóa ngoại)");
                // Load lại để tránh lỗi dây chuyền
                dt.RejectChanges(); // Hoàn tác các thay đổi lỗi trên giao diện
            }
        }

        // Xử lý lỗi nhập liệu trên Grid (ví dụ nhập chữ vào ô số)
        private void dgvNhanVien_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false; // Ngăn không cho crash chương trình
            MessageBox.Show("Dữ liệu nhập không hợp lệ tại cột " + dgvNhanVien.Columns[e.ColumnIndex].HeaderText);
        }
    }
}