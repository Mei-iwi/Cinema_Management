using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_RAP_PHIM
{
    public class FeedbackDAL
    {
        private static string connectionString =
     "Data Source=34.133.93.201;Initial Catalog=QL_RAP_PHIM;Persist Security Info=True;User ID=sqlserver;Password=123456789";
        public static bool SaveFeedback(string feedbackContent)
        {
            // Bảng Feedback chưa tồn tại trong bacpac, đây là hàm giả định
            string query = "INSERT INTO Feedback (NoiDung, NgayGui) VALUES (@NoiDung, GETDATE())";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NoiDung", feedbackContent);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi lưu ý kiến: " + ex.Message + "\n(Cần tạo bảng 'Feedback' trong DB)", "Lỗi DAL");
                        return false;
                    }
                }
            }
        }
    }
}