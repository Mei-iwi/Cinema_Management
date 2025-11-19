using System.Diagnostics;

namespace MainForm
{
    public partial class MainFormForManegement : Form
    {
        public MainFormForManegement()
        {
            InitializeComponent();
        }

        private void quảnLýPhòngChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheaterRoomForm.TheaterRoom room = new TheaterRoomForm.TheaterRoom();
            room.ShowDialog();
        }

        private void gửiGópYToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void dịchVụKháchHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ServiceForm.ServiceForm form = new ServiceForm.ServiceForm();
            form.ShowDialog();
        }

        private void cSKHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm.ReportForm form = new ReportForm.ReportForm();
            form.ShowDialog();
        }

        private void quảnLýSơĐồGhếToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SeatForm.CinemaRooms rooms = new SeatForm.CinemaRooms();
            rooms.ShowDialog();

        }

        private void menuSodoghe_Click(object sender, EventArgs e)
        {
            SeatForm.CinemaRooms rooms = new SeatForm.CinemaRooms();
            rooms.ShowDialog();
        }

        private void menuQLphim_Click(object sender, EventArgs e)
        {
            MovieForm.MovieForm form = new MovieForm.MovieForm();
            form.ShowDialog();
        }

        private void menuQLLichChieu_Click(object sender, EventArgs e)
        {
            ShowtimeForm.ShowtimeForm form = new ShowtimeForm.ShowtimeForm();
            form.ShowDialog();
        }

        private void menuQLKH_Click(object sender, EventArgs e)
        {
            CustomerForm.CustomerForm form = new CustomerForm.CustomerForm();
            form.ShowDialog();
        }

        private void menuQLHangKH_Click(object sender, EventArgs e)
        {
            MemberTierForm.MemberTierForm form = new MemberTierForm.MemberTierForm();
            form.ShowDialog();
        }

        private void menuQLNV_Click(object sender, EventArgs e)
        {
            StaffForm.StaffForm form = new StaffForm.StaffForm();
            form.ShowDialog();
        }
    }
}
