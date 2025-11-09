using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace QL_RAP_PHIM
{
    public class LoginDAL
    {
        private static string connectionString =
     "Data Source=34.133.93.201;Initial Catalog=QL_RAP_PHIM;Persist Security Info=True;User ID=sqlserver;Password=123456789";

        public static bool CheckLogin(string username, string password)
        {
            string query = "SELECT COUNT(MaNV) FROM NHANVIEN WHERE Username = @user AND Password = @pass";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    try
                    {
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi SQL khi đăng nhập: " + ex.Message, "Lỗi Database");
                        return false;
                    }
                }
            }
        }
    }
}