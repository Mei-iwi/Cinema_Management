using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using Common;

namespace CustomerServiceForm

{
    public partial class CustomerServiceForm : Form
    {

        string connectionString = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        SqlConnection con;

        DataSet ds;

        SqlDataAdapter da;

        public string SelectedServiceName { get; private set; }
        public string SelectedServiceID { get; private set; }

        public string SelectedPrice { get; private set; }

        DataColumn[] key = new DataColumn[1];
        public CustomerServiceForm()
        {
            InitializeComponent();

            con = new SqlConnection(connectionString);

            string sql = "SELECT * FROM DICHVU";

            da = new SqlDataAdapter(sql, con);

            ds = new DataSet();

            da.Fill(ds, "DV");

            key[0] = ds.Tables["DV"].Columns[0];

            ds.Tables["DV"].PrimaryKey = key;

            // Tạo panel chứa TableLayoutPanel và scroll
            Panel scrollPanel = new Panel();
            scrollPanel.Dock = DockStyle.Fill; // chiếm phần còn lại của form
            scrollPanel.AutoScroll = true;     // bật scroll
            this.Controls.Add(scrollPanel);
            scrollPanel.BringToFront();

            // Thêm TableLayoutPanel vào panel scroll
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            scrollPanel.Controls.Add(tableLayoutPanel);

            // Load phim vào TableLayoutPanel
            load_Service_table();

        }

        void load_Service_table()
        {
            DataTable dt = ds.Tables["DV"];
            if (dt == null || dt.Rows.Count == 0) return;



            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.ColumnCount = 4;
            tableLayoutPanel.RowCount = (int)Math.Ceiling(dt.Rows.Count / 4.0);
            tableLayoutPanel.Dock = DockStyle.Top;
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.Padding = new Padding(20);
            tableLayoutPanel.AutoScroll = true;

            tableLayoutPanel.ColumnStyles.Clear();
            for (int i = 0; i < 4; i++)
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            tableLayoutPanel.RowStyles.Clear();
            for (int r = 0; r < tableLayoutPanel.RowCount; r++)
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            int row = 0, col = 0;
            foreach (DataRow dataRow in dt.Rows)
            {
                Panel panel = new Panel();
                panel.Width = 150;
                panel.Height = 300;
                panel.Margin = new Padding(10);

                string projectRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\.."));
                string destinationPath = Path.Combine(projectRoot, "ServiceForm", "Images", "Services");

                PictureBox pb = new PictureBox();
                pb.Width = 150;
                pb.Height = 180;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.ImageLocation = Path.Combine(destinationPath, dataRow["HINH_ANH"].ToString());

                Label lblName = new Label();
                lblName.Text = dataRow["TENSP"].ToString();
                lblName.Top = 185;
                lblName.Width = 150;
                lblName.TextAlign = ContentAlignment.MiddleCenter;

                Label lblGenre = new Label();
                lblGenre.Text = dataRow["DONGIA"].ToString();
                lblGenre.Top = 205;
                lblGenre.Width = 150;
                lblGenre.TextAlign = ContentAlignment.MiddleCenter;

                Button btnBuy = new Button();
                btnBuy.Text = "Đặt ngay";
                btnBuy.Top = 230;
                btnBuy.Width = 150;
                btnBuy.Height = 50;
                btnBuy.BackColor = Color.Yellow;
                btnBuy.Click += (s, e) =>
                {
                    if (MessageBox.Show("Đăng ký dịch vụ: " + dataRow["TENSP"].ToString(), "Mua vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SelectedServiceName = dataRow["TENSP"].ToString();
                        SelectedServiceID = dataRow["MASP"].ToString();
                        SelectedPrice = dataRow["DONGIA"].ToString();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    };
                };

                panel.Controls.Add(pb);
                panel.Controls.Add(lblName);
                panel.Controls.Add(lblGenre);
                panel.Controls.Add(btnBuy);

                tableLayoutPanel.Controls.Add(panel, col, row);

                col++;
                if (col >= 4)
                {
                    col = 0;
                    row++;
                }

            }
        }

    }


}
