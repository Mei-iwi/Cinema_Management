using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class GlobalData
    {
        public static string DataSource = "MEI\\SQLEXPRESS";

        public static string InitialCatalog = "QL_RAP_PHIM";

        public static string UserID;

        public static string Password;

        public static int Positon;

        public static void getGlobalData(string userID, string password, int positon)
        {
            UserID = userID;
            Password = password;
            Positon = positon;
        }

    }
}
