using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Common
{

    public static class ConnectionHelper
    {
        //Lấy chuỗi kết nối từ file cấu hình
        public static string GetconnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;

        }
        //Tạo chuỗi kết nối động
        public static string CreateConnectionString(string server, string database, string userId = "JustWatch", string password = "Abc12345!")
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = database,
                UserID = userId,
                Password = password,
                IntegratedSecurity = false
            };
            return builder.ConnectionString;
        }
    }
}
