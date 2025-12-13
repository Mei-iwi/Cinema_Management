using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class HistoryTickets : Form
    {

        string connectionString = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        SqlConnection con;

        DataSet ds;

        SqlDataAdapter da;

        DataColumn[] key = new DataColumn[1];

        public HistoryTickets()
        {
            InitializeComponent();

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.AllowUserToAddRows = false;



            string sql = @$"
            SELECT V.MAVE, TENLV, MAGHE, L.DONGIA, NGAYBANVE, L.DONGIA+(SOLUONG*DV.DONGIA) AS TOTAL
            FROM VE V
            INNER JOIN LOAIVE L ON L.MALV = V.MALV
            INNER JOIN DANGKY DK ON DK.MAVE = V.MAVE
            INNER JOIN DICHVU DV ON DV.MASP = DK.MASP
            WHERE MAKH = '{GlobalData.UserID}'
            ORDER BY NGAYBANVE DESC";

            con = new SqlConnection(connectionString);

            da = new SqlDataAdapter(sql, con);

            ds = new DataSet();

            da.Fill(ds, "HISTORYTICKETS");

            //key[0] = ds.Tables["HISTORYTICKETS"].Columns[0];

            //ds.Tables["HISTORYTICKETS"].PrimaryKey = key;

            //dgv.DataSource = ds.Tables["HISTORYTICKETS"];

        }

        void load_dgv() { 
            dgv.DataSource = ds.Tables["HISTORYTICKETS"];

            dgv.Columns[0].HeaderText = "Mã vé";
            dgv.Columns[1].HeaderText = "Loại vé";
            dgv.Columns[2].HeaderText = "Mã ghế";
            dgv.Columns[3].HeaderText = "Đơn giá vé";
            dgv.Columns[4].HeaderText = "Ngày bán vé";
            dgv.Columns[5].HeaderText = "Tổng thanh toán";

        }
        private void HistoryTickets_Load(object sender, EventArgs e)
        {
            load_dgv();
        }
    }
}
