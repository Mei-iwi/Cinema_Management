using System;
using System.Windows.Forms;

namespace QL_RAP_PHIM
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.Text = "Hệ thống Quản lý Rạp Phim";
        }

        private void customerProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerProfileForm profileForm = new CustomerProfileForm();
            profileForm.MdiParent = this;
            profileForm.Show();
        }

        private void customerServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerServiceForm serviceForm = new CustomerServiceForm();
            serviceForm.MdiParent = this;
            serviceForm.Show();
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormYkienKhachHang feedbackForm = new FormYkienKhachHang();
            feedbackForm.MdiParent = this;
            feedbackForm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}