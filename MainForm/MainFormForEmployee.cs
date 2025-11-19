using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace MainForm
{
    public partial class MainFormForEmployee : Form
    {
        public MainFormForEmployee()
        {
            InitializeComponent();
        }

        private void phimĐangChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TicketForm.TicketForm ticketForm = new TicketForm.TicketForm();
            ticketForm.ShowDialog();
        }

        private void dịchVụKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceRegistrationForm.ServiceRegistrationForm serviceRegistrationForm = new ServiceRegistrationForm.ServiceRegistrationForm();
            serviceRegistrationForm.ShowDialog();
        }

        private void liênHệHỗTrợToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đóngGópÝKiếnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
