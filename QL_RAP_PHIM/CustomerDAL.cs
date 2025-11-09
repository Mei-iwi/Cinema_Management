using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_RAP_PHIM
{
    public class CustomerDAL
    {
        private static string connectionString =
            "Data Source=34.133.93.201;Initial Catalog=QL_RAP_PHIM;Persist Security Info=True;User ID=sqlserver;Password=123456789;Trust Server Certificate=True";

        public static DataTable GetCustomerProfile(int customerId)
        {
            DataTable dt = new DataTable();
            string query =
                "SELECT KH.*, HTV.TenHang FROM KHACHHANG KH JOIN HANGTHANHVIEN HTV ON KH.MaHangTV = HTV.MaHangTV WHERE KH.MaKH = @MaKH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", customerId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    try
                    {
                        conn.Open();
                        da.Fill(dt);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi truy vấn hồ sơ khách hàng: " + ex.Message, "Lỗi DAL");
                    }
                }
            }
            return dt;
        }

        public static bool UpdateCustomerProfile(int maKH, string tenKH, string sdt, string email)
        {
            string query =
                "UPDATE KHACHHANG SET TenKH = @TenKH, Sdt = @Sdt, Email = @Email WHERE MaKH = @MaKH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    cmd.Parameters.AddWithValue("@TenKH", tenKH);
                    cmd.Parameters.AddWithValue("@Sdt", sdt);
                    cmd.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi cập nhật hồ sơ: " + ex.Message, "Lỗi DAL");
                        return false;
                    }
                }
            }
        }
    }
}