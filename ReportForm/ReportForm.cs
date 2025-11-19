using ClosedXML.Excel;
using Common;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace ReportForm
{
    public partial class ReportForm : Form
    {

        string strcon = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        SqlConnection con;


        private PrintDocument printDoc = new PrintDocument();

        private int currentRow = 0;

        public ReportForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.report;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.AllowUserToAddRows = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int startX = 50;
            int startY = 50;
            int offsetY = 0;

            Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
            Font fontHeader = new Font("Arial", 12, FontStyle.Bold);
            Font fontRow = new Font("Arial", 10);

            // Tiêu đề
            e.Graphics.DrawString("Báo cáo doanh thu", fontTitle, Brushes.Black, startX + 200, startY + offsetY);
            offsetY += 50;

            // Header DataGridView
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                e.Graphics.DrawString(dgv.Columns[i].HeaderText, fontHeader, Brushes.Black, startX + i * 100, startY + offsetY);
            }
            offsetY += 30;

            // Rows
            while (currentRow < dgv.Rows.Count)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    string text = dgv.Rows[currentRow].Cells[i].Value?.ToString() ?? "";
                    e.Graphics.DrawString(text, fontRow, Brushes.Black, startX + i * 100, startY + offsetY);
                }
                offsetY += 20;

                // Nếu in vượt quá trang
                if (startY + offsetY > e.MarginBounds.Height)
                {
                    e.HasMorePages = true;
                    return;
                }
                currentRow++;
            }

            // In tổng tiền
            offsetY += 20;
            e.Graphics.DrawString(txtTotal.Text, fontHeader, Brushes.Black, startX, startY + offsetY);

            e.HasMorePages = false;
            currentRow = 0; // reset cho lần in sau
        }


        void load_dgv()
        {
            string sql = "BAOCAO_LOAD";
            using (SqlConnection con = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    con.ConnectionString = strcon;

                    con.Open();

                    da.Fill(dt);

                    dgv.DataSource = dt;

                    dgv.Columns[0].HeaderText = "Mã vé";
                    dgv.Columns[1].HeaderText = "Tên vé";
                    dgv.Columns[2].HeaderText = "Tên phim";
                    dgv.Columns[3].HeaderText = "Đơn giá";
                    dgv.Columns[4].HeaderText = "Suất chiếu";
                    dgv.Columns[5].HeaderText = "Ngày bán vé";

                    txtTotal.Text = "Lọc dữ liệu để xem danh thu tổng";

                }
            }
        }

        void load_cboPhim(string sql = "SELECT MAPHIM, TENPHIM FROM PHIM")
        {


            using (SqlConnection con = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    con.ConnectionString = strcon;

                    con.Open();

                    da.Fill(dt);

                    cboMovie.DataSource = dt;

                    cboMovie.DisplayMember = "TENPHIM";

                    cboMovie.ValueMember = "MAPHIM";

                }
            }
        }


        void load_LV()
        {
            string sql = "SELECT MALV, TENLV FROM  LOAIVE";

            using (SqlConnection con = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    con.ConnectionString = strcon;

                    con.Open();

                    da.Fill(dt);

                    cboloaive.DataSource = dt;

                    cboloaive.DisplayMember = "TENLV";

                    cboloaive.ValueMember = "MALV";

                }
            }

        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            load_dgv();

            load_cboPhim();

            load_LV();

            printDoc.PrintPage += PrintDoc_PrintPage;


        }

        private void btnFilter_Click(object sender, EventArgs e)
        {



            string sql = "BAOCAO";
            using (SqlConnection con = new SqlConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NGAYBATDAU", dataStart.Value);
                    cmd.Parameters.AddWithValue("@NGAYKETTHUC", dateEnd.Value);
                    cmd.Parameters.AddWithValue("@TENPHIM", cboMovie.Text);
                    cmd.Parameters.AddWithValue("@LV", cboloaive.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    con.ConnectionString = strcon;

                    con.Open();

                    da.Fill(dt);

                    dgv.DataSource = dt;

                    dgv.Columns[0].HeaderText = "Mã vé";
                    dgv.Columns[1].HeaderText = "Tên vé";
                    dgv.Columns[2].HeaderText = "Tên phim";
                    dgv.Columns[3].HeaderText = "Đơn giá";
                    dgv.Columns[4].HeaderText = "Suất chiếu";
                    dgv.Columns[5].HeaderText = "Ngày bán vé";

                    decimal tongtien = 0;

                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        tongtien += Convert.ToDecimal(dgv.Rows[i].Cells[3].Value);
                    }
                    txtTotal.Text = "Tổng tiền: " + tongtien.ToString("N0") + " VND";
                }
            }
        }



        private void btnreload_Click(object sender, EventArgs e)
        {
            load_dgv();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0) return;

            DataTable dt = (DataTable)dgv.DataSource;

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "BaoCao");

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = "BaoCao.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(sfd.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.ShowDialog();
        }
    }
}

