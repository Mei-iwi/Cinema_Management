using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_RAP_PHIM
{
    public class ServiceDAL
    {
        private static string connectionString =
     "Data Source=34.133.93.201;Initial Catalog=QL_RAP_PHIM;Persist Security Info=True;User ID=sqlserver;Password=123456789";
        public static DataTable GetAllServices()
        {
            DataTable dt = new DataTable();
            string query = "SELECT MaDV, TenDV, MoTa FROM DICHVU";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        conn.Open();
                        da.Fill(dt);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi truy vấn dịch vụ: " + ex.Message, "Lỗi DAL");
                    }
                }
            }
            return dt;
        }

        public static bool RegisterService(int maKH, int maDV)
        {
            string query = "INSERT INTO DANGKY (MaKH, MaDV, NgayDK) VALUES (@MaKH, @MaDV, GETDATE())";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.Parameters.AddWithValue("@MaDV", maDV);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi đăng ký dịch vụ: " + ex.Message, "Lỗi DAL");
                        return false;
                    }
                }
            }
        }
    }
}