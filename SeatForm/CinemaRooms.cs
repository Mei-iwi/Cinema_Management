using Common;
using System.Data;
using System.Data.SqlClient;
namespace SeatForm
{
    public partial class CinemaRooms : Form
    {
        string connectionString = ConnectionHelper.CreateConnectionString("34.133.93.201", "QL_RAP_PHIM", "sqlserver", "123456789");
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da_Phong, da_Ghe, da_CTPG;

        private string selectedSeat = null;

        private string maPhongHienTai = null;

        private string maGheHienTaiDaMua = null;

        // Cấu hình ghế
        private int seatSize = 50;
        private int rowSpacing = 60;
        private int[] seatsPerRow = new int[] { 15, 10, 10, 10, 15 };

        public CinemaRooms()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.CinemaRooms;

            con = new SqlConnection(connectionString);
            da_Phong = new SqlDataAdapter("SELECT * FROM PHONGCHIEU", con);
            da_Ghe = new SqlDataAdapter("SELECT * FROM GHE", con);
            da_CTPG = new SqlDataAdapter("SELECT * FROM CT_GHE_PHONG", con);

            ds = new DataSet();
            da_Phong.Fill(ds, "PHONGCHIEU");
            da_Ghe.Fill(ds, "GHE");
            da_CTPG.Fill(ds, "CT_GHE_PHONG");

            ds.Tables["GHE"].PrimaryKey = new DataColumn[] { ds.Tables["GHE"].Columns["MAGHE"] };
            ds.Tables["CT_GHE_PHONG"].PrimaryKey = new DataColumn[]
            {
                ds.Tables["CT_GHE_PHONG"].Columns["MAGHE"],
                ds.Tables["CT_GHE_PHONG"].Columns["MAPHONG"]
            };

            //pnlSeats.Paint += pnlSeats_Paint;
            //pnlSeats.MouseClick += pnlSeats_MouseClick;
        }

        private void CinemaRooms_Load(object sender, EventArgs e)
        {
            cboPhong.DataSource = ds.Tables["PHONGCHIEU"];
            cboPhong.DisplayMember = "TENPHONG";
            cboPhong.ValueMember = "MAPHONG";
        }

        private void pnlSeats_Paint(object sender, PaintEventArgs e)
        {
            if (cboPhong.SelectedValue == null) return;

            Graphics g = e.Graphics;
            g.Clear(pnlSeats.BackColor);

            int panelWidth = pnlSeats.Width;
            int centerX = panelWidth / 2;

            // Vẽ màn hình cong
            int topY = 10;
            int radius = panelWidth / 2 - 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(centerX - radius, topY, 2 * radius, 80, 180, 180);
            g.FillPath(Brushes.LightGray, path);
            g.DrawPath(Pens.Black, path);
            g.DrawString("SCREEN", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, centerX - 45, topY + 5);

            string maphong = cboPhong.SelectedValue.ToString();

            // Lấy danh sách ghế theo phòng
            var ghePhong = ds.Tables["CT_GHE_PHONG"].Select($"MAPHONG = '{maphong}'");
            List<DataRow> listGhe = new List<DataRow>();

            foreach (var dr in ghePhong)
            {
                var ghe = ds.Tables["GHE"].Rows.Find(dr["MAGHE"]);
                if (ghe != null)
                    listGhe.Add(ghe);
            }

            // Sắp xếp loại ghế: THƯỜNG trước, VIP giữa, COUPLE cuối
            //listGhe = listGhe
            //    .OrderBy(r => r["LOAIGHE"].ToString() == "THUONG" ? 0 :
            //                 r["LOAIGHE"].ToString() == "VIP" ? 1 : 2)
            //    .ToList();

            // Vẽ theo từng hàng
            int startY = 150;
            int seatIndex = 0;

            for (int row = 0; row < seatsPerRow.Length; row++)
            {
                int seatsInRow = seatsPerRow[row];
                int totalWidth = seatsInRow * seatSize + (seatsInRow - 1) * 10;
                int startX = centerX - totalWidth / 2;
                int y = startY + row * rowSpacing;

                for (int i = 0; i < seatsInRow && seatIndex < listGhe.Count; i++, seatIndex++)
                {
                    int x = startX + i * (seatSize + 10);
                    var ghe = listGhe[seatIndex];
                    string seatID = ghe["MAGHE"].ToString();
                    string seatType = ghe["LOAIGHE"].ToString();

                    DataRow drCT = ds.Tables["CT_GHE_PHONG"].Rows.Find(new object[] { seatID, maphong });

                    bool isBooked = drCT != null && bool.TryParse(drCT["TRANGTHAI"].ToString(), out bool b) && b;

                    Color seatColor = isBooked ? Color.Gray :
                                      seatType == "VIP" ? Color.Gold :
                                      seatType == "COUPLE" ? Color.LightPink :
                                      Color.Green;

                    if (seatID == selectedSeat) seatColor = Color.Blue;

                    g.FillRectangle(new SolidBrush(seatColor), x, y, seatSize, seatSize);
                    g.DrawRectangle(Pens.Black, x, y, seatSize, seatSize);
                    string shortSeatID = seatID.Length > 4
                        ? seatID.Substring(0, 1) + seatID.Substring(seatID.Length - 3)
                        : seatID;
                    g.DrawString(shortSeatID, this.Font, Brushes.Black, x + 10, y + 15);
                }
            }
        }

        private void pnlSeats_MouseClick(object sender, MouseEventArgs e)
        {
            if (cboPhong.SelectedValue == null) return;
            string maphong = cboPhong.SelectedValue.ToString();

            int panelWidth = pnlSeats.Width;
            int centerX = panelWidth / 2;
            int startY = 150;

            // Tính lại vị trí ghế như phần vẽ
            var ghePhong = ds.Tables["CT_GHE_PHONG"].Select($"MAPHONG = '{maphong}'");
            List<DataRow> listGhe = new List<DataRow>();
            foreach (var dr in ghePhong)
            {
                var ghe = ds.Tables["GHE"].Rows.Find(dr["MAGHE"]);
                if (ghe != null)
                    listGhe.Add(ghe);
            }
            //listGhe = listGhe
            //    .OrderBy(r => r["LOAIGHE"].ToString() == "THUONG" ? 0 :
            //                 r["LOAIGHE"].ToString() == "VIP" ? 1 : 2)
            //    .ToList();

            int seatIndex = 0;
            for (int row = 0; row < seatsPerRow.Length; row++)
            {
                int seatsInRow = seatsPerRow[row];
                int totalWidth = seatsInRow * seatSize + (seatsInRow - 1) * 10;
                int startX = centerX - totalWidth / 2;
                int y = startY + row * rowSpacing;

                for (int i = 0; i < seatsInRow && seatIndex < listGhe.Count; i++, seatIndex++)
                {
                    int x = startX + i * (seatSize + 10);
                    Rectangle seatRect = new Rectangle(x, y, seatSize, seatSize);

                    if (seatRect.Contains(e.Location))
                    {
                        string seatID = listGhe[seatIndex]["MAGHE"].ToString();

                        DataRow drCT = ds.Tables["CT_GHE_PHONG"].Rows.Find(new object[] { seatID, maphong });

                        if (drCT == null || drCT["TRANGTHAI"].ToString() == "False")
                        {
                            selectedSeat = seatID;
                            pnlSeats.Invalidate();
                            lblGheHienTai.Text = "Ghế đang chọn: " + seatID;
                        }
                        else if (drCT["TRANGTHAI"].ToString() == "True")
                        {
                            MessageBox.Show("Ghế đã được bán!");
                            lblGheHienTai.Text = "Hủy ghế đang chọn: " + seatID;
                            maGheHienTaiDaMua = seatID;

                        }
                        maPhongHienTai = maphong;
                        return;
                    }
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            pnlSeats.Invalidate();
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn cập nhật lại trạng thái ghế trống không?",
    "Cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataRow row in ds.Tables["CT_GHE_PHONG"].Rows)
                    {
                        if (row["MAPHONG"].ToString() == cboPhong.SelectedValue.ToString().Trim())
                        {
                            row["TRANGTHAI"] = "False"; 
                        }
                    }

                    SqlCommandBuilder builder = new SqlCommandBuilder(da_CTPG);
                    da_CTPG.Update(ds, "CT_GHE_PHONG");

                    MessageBox.Show("Cập nhật trạng thái ghế thành công.");
                    pnlSeats.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
                }
            }

        }

        private void btnMua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSeat))
            {
                MessageBox.Show("Vui lòng chọn ghế trước khi mua.");
                return;
            }

            if (string.IsNullOrEmpty(maPhongHienTai))
            {
                MessageBox.Show("Lỗi: Không xác định được phòng chiếu.");
                return;
            }

            DataRow drCT = ds.Tables["CT_GHE_PHONG"].Rows.Find(new object[] { selectedSeat, maPhongHienTai });

            if (drCT != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn bán ghế này", "Hủy mua", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    drCT["TRANGTHAI"] = "True"; // Đánh dấu ghế là đã bán
                    SqlCommandBuilder builder = new SqlCommandBuilder(da_CTPG);
                    da_CTPG.Update(ds, "CT_GHE_PHONG");

                    MessageBox.Show($"Mua ghế {selectedSeat} thành công!");

                    // Xóa ghế đã chọn
                    selectedSeat = null;
                    maPhongHienTai = null;
                    lblGheHienTai.Text = "Ghế đang chọn: None";
                    pnlSeats.Invalidate();
                }
                return;
            }
            else
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin ghế trong phòng.");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maGheHienTaiDaMua))
            {
                MessageBox.Show("Vui lòng chọn ghế đã mua để hủy.");
                return;
            }
            if (string.IsNullOrEmpty(maPhongHienTai))
            {
                MessageBox.Show("Lỗi: Không xác định được phòng chiếu.");
                return;
            }
            DataRow drCT = ds.Tables["CT_GHE_PHONG"].Rows.Find(new object[] { maGheHienTaiDaMua, maPhongHienTai });
            if (drCT != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn hủy mua ghế này", "Hủy mua", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    drCT["TRANGTHAI"] = "False"; // Đánh dấu ghế là chưa bán
                    SqlCommandBuilder builder = new SqlCommandBuilder(da_CTPG);
                    da_CTPG.Update(ds, "CT_GHE_PHONG");

                    MessageBox.Show($"Hủy ghế {maGheHienTaiDaMua} thành công!");

                    // Xóa ghế đã chọn
                    maGheHienTaiDaMua = null;
                    maPhongHienTai = null;
                    lblGheHienTai.Text = "Ghế đang chọn: None";
                    pnlSeats.Invalidate();
                }
                return;
            }
            else
            {
                MessageBox.Show("Lỗi: Không tìm thấy thông tin ghế trong phòng.");
            }
        }

        private void CinemaRooms_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                pnlSeats.Invalidate();
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                pnlSeats.Invalidate();
            }
        }
    }
}
