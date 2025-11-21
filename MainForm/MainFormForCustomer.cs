using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.Diagnostics;
using CustomerServiceForm;

namespace MainForm
{
    public partial class MainFormForCustomer : Form
    {

        string connectionString = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

        SqlConnection con;

        DataSet ds;

        SqlDataAdapter da;

        DataColumn[] key = new DataColumn[1];

        public MainFormForCustomer()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.house;


            con = new SqlConnection(connectionString);

            string sql = "SELECT MAPHIM, TENPHIM, NHASX, HINH_ANH, TENTHELOAI FROM PHIM P INNER JOIN THELOAIPHIM TL ON TL.MATHELOAI = P.MATHELOAI";

            da = new SqlDataAdapter(sql, con);

            ds = new DataSet();

            da.Fill(ds, "PHIM");

            key[0] = ds.Tables["PHIM"].Columns[0];

            ds.Tables["PHIM"].PrimaryKey = key;

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
            load_phim_table();



        }


        void load_phim_table()
        {
            DataTable dt = ds.Tables["PHIM"];
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
                string destinationPath = Path.Combine(projectRoot, "MainForm", "Images");

                PictureBox pb = new PictureBox();
                pb.Width = 150;
                pb.Height = 180;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.ImageLocation = Path.Combine(destinationPath, dataRow["HINH_ANH"].ToString());

                Label lblName = new Label();
                lblName.Text = dataRow["TENPHIM"].ToString();
                lblName.Top = 185;
                lblName.Width = 150;
                lblName.TextAlign = ContentAlignment.MiddleCenter;

                Label lblGenre = new Label();
                lblGenre.Text = dataRow["TENTHELOAI"].ToString();
                lblGenre.Top = 205;
                lblGenre.Width = 150;
                lblGenre.TextAlign = ContentAlignment.MiddleCenter;

                Button btnBuy = new Button();
                btnBuy.Text = "Mua vé";
                btnBuy.Top = 230;
                btnBuy.Width = 150;
                btnBuy.Height = 50;
                btnBuy.BackColor = Color.Yellow;
                btnBuy.Click += (s, e) =>
                {
                   if (MessageBox.Show("Mua vé: " + dataRow["TENPHIM"].ToString(), "Mua vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                    {
                        BuyServiceAndFilm buyServiceAndFilmForm = new BuyServiceAndFilm(dataRow["MAPHIM"].ToString(), dataRow["TENPHIM"].ToString());
                        buyServiceAndFilmForm.Show();
                    }


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


        private void MainFormForCustomer_Load(object sender, EventArgs e)
        {
            // Thêm tiêu đề
            Label lblTitle = new Label();
            lblTitle.Text = "Danh sách phim";
            lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 50;
            this.Controls.Add(lblTitle);
            lblTitle.BringToFront();

            // Load phim vào TableLayoutPanel
            load_phim_table();

        }

        private void gửiGópYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormSupportCustomer.FormSupportCustomer supportForm = new FormSupportCustomer.FormSupportCustomer();
                supportForm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn không có quyền truy cập");
            }
        }

        private void Logout(object sender, EventArgs e)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // Truy đến folder solution
            string root = Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\.."));

            // Đường dẫn chính xác đến LoginForm.exe
            string exePath = Path.Combine(root, "Cinema_Management", "bin", "Debug", "net8.0-windows", "Cinema_Management.exe");

            if (File.Exists(exePath))
            {
                Process.Start(exePath);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lỗi đăng xuất, vui lòng chạy lại ứng dụng");
                this.Close();
            }

        }

        private void dịchVụKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerServiceForm.CustomerServiceForm serviceForm = new CustomerServiceForm.CustomerServiceForm();
            serviceForm.ShowDialog();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Authentication authForm = new Authentication();

            Customer cus = authForm.getCustomerInfomation(connectionString, GlobalData.UserID);

            Employee em = null;

            ProfileForm.ProfileForm profileForm = new ProfileForm.ProfileForm(cus, em, 0);
            profileForm.ShowDialog();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePasswordUser changePasswordUser = new ChangePasswordUser(0);
            changePasswordUser.ShowDialog();
        }
    }
}

