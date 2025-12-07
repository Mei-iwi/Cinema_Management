using CrystalDecisions.CrystalReports.Engine;
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
using CrystalDecisions.CrystalReports.Engine;

namespace RepoertCrystal
{
    public partial class Report : Form
    {
        string strcon = "Data Source=MEI\\SQLEXPRESS;Initial Catalog=QL_RAP_PHIM;User ID=sa;Password=123";

        SqlConnection con;

        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                crystalReport1.SetDatabaseLogon("sa", "123", "MEI\\SQLEXPRESS", "QL_RAP_PHIM");
                this.crystalReportViewer1.ReportSource = this.crystalReport1;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
