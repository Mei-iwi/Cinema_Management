using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace StaffForm
{
    public partial class TimNhanVien : Form
    {
        SqlConnection conn;
        public TimNhanVien()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=DESKTOP-IQCO6JU\\SQLEXPRESS;Initial catalog=QL_RAP_PHIM;User ID=sa;Password=123");
        }
        private void TimNhanVien_Load(object sender, EventArgs e)
        {
            LoadAllNhanVien();
        }
        private void LoadAllNhanVien()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT * FROM NHANVIEN";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            string maNV = txtMa.Text.Trim();

            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên để tìm!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT * FROM NHANVIEN WHERE MANV = @MANV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MANV", maNV);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên!");
                        dgvNhanVien.DataSource = null; // hoặc vẫn hiển thị tất cả tùy bạn
                    }
                    else
                    {
                        dgvNhanVien.DataSource = dt; // chỉ hiển thị kết quả
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm nhân viên: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            LoadAllNhanVien();
        }

        private void TimNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát không?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                e.Cancel = true; 
            } 
                
        }
    }



}
