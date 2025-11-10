using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management
{
    internal class UpdatePassword
    {

        public int changePassword(string str, string user, string newPass)
        {
            int result = -1;

            using (SqlConnection conn = new SqlConnection(str))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_CHANGE_PASSWORD", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@USERID", user);
                        cmd.Parameters.AddWithValue("@NEWPASS", newPass);

                        result = cmd.ExecuteNonQuery();
                    }
                    return 1;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL Error: " + ex.Message);
                    return -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return -1;
                }
            }

            return result;
        }

    }
}
