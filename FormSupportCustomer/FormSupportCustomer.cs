using Common;
using System.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Tokens;
namespace FormSupportCustomer
{


    public partial class FormSupportCustomer : Form
    {

        string strcon = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);



        public FormSupportCustomer()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.CSKH;

        }


        void loadUser()
        {
            string sql = "SELECT * FROM KHACHHANG WHERE MAKH = @MAKH";

            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@MAKH", GlobalData.UserID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txtMaKH.Text = reader["MAKH"].ToString();
                        txtTenKH.Text = reader["HOTENKH"].ToString();
                        txtSDT.Text = reader["SDT"].ToString();
                        txtEmail.Text = reader["EMAIL"].ToString();
                    }
                }
            }
        }

        void Load_KN()
        {
            List<string> complaintTypes = new List<string>
                {
                    "Chất lượng dịch vụ",
                    "Thái độ nhân viên",
                    "Hóa đơn sai",
                    "Trễ giờ phục vụ",
                    "Khác"
                };

            cboLoaiPH.DataSource = complaintTypes;

            sbyte defaultIndex = 0;
            cboLoaiPH.SelectedIndex = defaultIndex;

        }

        private void FormSupportCustomer_Load(object sender, EventArgs e)
        {

            loadUser();

            Load_KN();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            rchNoiDung.Clear();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rchNoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung phản hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql = @"INSERT INTO CSKH(MaKH, MaNV, LoaiVanDe, TieuDe, NoiDung, PhanHoi, TrangThai, NgayTao, NgayXuLy) VALUES
                        (@MAKH, null, @LOAIPH, N'Khiếu nại từ khách hàng', @NOIDUNGPH, null, N'Chờ xử lý', CAST(GETDATE() as date), null)";
            using (SqlConnection con = new SqlConnection(strcon))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@MAKH", GlobalData.UserID);
                    cmd.Parameters.AddWithValue("@LOAIPH", cboLoaiPH.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@NOIDUNGPH", rchNoiDung.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Gửi phản hồi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rchNoiDung.Clear();
                }
            }
        }
    }
}

