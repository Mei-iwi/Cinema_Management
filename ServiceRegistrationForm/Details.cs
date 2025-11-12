using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceRegistrationForm
{
    public partial class Details : Form
    {
        string fileName = "";
        public Details(DataTable dt)
        {
            InitializeComponent();

            lblMa.Text = dt.Rows[0]["MASP"].ToString();
            lblTen.Text = dt.Rows[0]["TENSP"].ToString();
            lblDonGia.Text = dt.Rows[0]["DonGia"].ToString();
            lblSL.Text = dt.Rows[0]["SOLUONG"].ToString();
            lblTT.Text = dt.Rows[0]["TT"].ToString();

            fileName = dt.Rows[0]["HINH_ANH"].ToString();

            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Detials_Load(object sender, EventArgs e)
        {
            string SolutionFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\.."));

            string DestinationFoler = Path.Combine(SolutionFolder, "ServiceForm", "Images", "Services");

            string fullPath = Path.Combine(DestinationFoler, fileName);

            if (File.Exists(fullPath))
            {
                using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                {
                    pic.Image = Image.FromStream(fs);
                }
            }
            else
            {
                DestinationFoler = Path.Combine(SolutionFolder, "ServiceForm", "Images", "Default", "default.png");
                using (FileStream fs = new FileStream(DestinationFoler, FileMode.Open, FileAccess.Read))
                {
                    pic.Image = Image.FromStream(fs);
                }

            }
        }
    }
}
