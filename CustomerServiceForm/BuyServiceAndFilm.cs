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
using System.Drawing;
using QRCoder;


namespace CustomerServiceForm
{

    public partial class BuyServiceAndFilm : Form
    {
        string connectionString = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da_Phong, da_Ghe, da_CTPG, da_lve;

        private string selectedSeat = null;

        private string maPhongHienTai = null;

        private string maGheHienTaiDaMua = null;

        string suatchieu = null;

        string maphim = "";
        string tenphim = "";

        // Cấu hình ghế
        private int seatSize = 50;
        private int rowSpacing = 60;
        private int[] seatsPerRow = new int[] { 15, 10, 10, 10, 15 };
        public BuyServiceAndFilm(string maphim, string tenphim)
        {
            InitializeComponent();


            this.maphim = maphim;

            this.tenphim = tenphim;


            con = new SqlConnection(connectionString);
            da_Phong = new SqlDataAdapter("SELECT DISTINCT * FROM SUATCHIEU WHERE MAPHIM = @maphim", con);
            da_Phong.SelectCommand.Parameters.AddWithValue("@maphim", this.maphim);
            da_Ghe = new SqlDataAdapter("SELECT * FROM GHE", con);
            da_CTPG = new SqlDataAdapter("SELECT * FROM CT_GHE_PHONG", con);

            da_lve = new SqlDataAdapter("SELECT * FROM LOAIVE", con);

            ds = new DataSet();
            da_Phong.Fill(ds, "PHONGCHIEU");
            da_Ghe.Fill(ds, "GHE");
            da_CTPG.Fill(ds, "CT_GHE_PHONG");
            da_lve.Fill(ds, "LOAIVE");


            ds.Tables["GHE"].PrimaryKey = new DataColumn[] { ds.Tables["GHE"].Columns["MAGHE"] };

            ds.Tables["CT_GHE_PHONG"].PrimaryKey = new DataColumn[]
            {
                ds.Tables["CT_GHE_PHONG"].Columns["MAGHE"],
                ds.Tables["CT_GHE_PHONG"].Columns["MAPHONG"]
            };
            ds.Tables["PHONGCHIEU"].PrimaryKey = new DataColumn[] { ds.Tables["PHONGCHIEU"].Columns["MASUAT"] };
            ds.Tables["LOAIVE"].PrimaryKey = new DataColumn[] { ds.Tables["LOAIVE"].Columns["MALV"] };


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

            if (cboPhong.SelectedValue == null) return;

            string maphong = cboPhong.SelectedValue.ToString();

            // Lấy các suất chiếu theo MAPHONG
            DataRow[] rows = ds.Tables["PHONGCHIEU"].Select($"MAPHONG = '{maphong}'");

            if (rows.Length > 0)
            {
                // Nếu có nhiều suất chiếu, lấy suất đầu tiên (hoặc xử lý theo nhu cầu)

                int cnt = cboPhong.SelectedIndex;

                DataRow row = rows[cnt];

                suatchieu = row["MASUAT"].ToString();

                string start = row["GIOBATDAU"].ToString();

                string end = row["GIOKETTHUC"].ToString();

                lblSuatChieu.Text = string.Format("Suất chiếu: {0} - {1}", start, end);
            }
            else
            {
                lblSuatChieu.Text = "Không có suất chiếu";
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

        private void BuyServiceAndFilm_Load(object sender, EventArgs e)
        {
            cboPhong.DataSource = ds.Tables["PHONGCHIEU"];
            cboPhong.DisplayMember = "TENPHONG";
            cboPhong.ValueMember = "MAPHONG";

            cboLoave.DataSource = ds.Tables["LOAIVE"];
            cboLoave.DisplayMember = "TENLV";
            cboLoave.ValueMember = "MALV";

            cboLoave.SelectedIndex = 0;

            txtDG.Text = "50000.0";

            txtTenPhim.Text = tenphim;
            txtMaphim.Text = maphim;

            string maphong = ((DataRowView)cboPhong.Items[0])["MAPHONG"].ToString();

            // Lấy các suất chiếu theo MAPHONG
            DataRow[] rows = ds.Tables["PHONGCHIEU"].Select($"MAPHONG = '{maphong}'");



            if (rows.Length > 0)
            {
                // Nếu có nhiều suất chiếu, lấy suất đầu tiên (hoặc xử lý theo nhu cầu)
                DataRow row = rows[0];

                suatchieu = row[0].ToString();


                string start = row["GIOBATDAU"].ToString();
                string end = row["GIOKETTHUC"].ToString();

                lblSuatChieu.Text = string.Format("Suất chiếu: {0} - {1}", start, end);
            }
            else
            {
                lblSuatChieu.Text = "Không có suất chiếu";
            }

        }

        private void cboLoave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoave.SelectedValue == null) return;

            DataTable tb = ds.Tables["LOAIVE"];

            if (tb == null) return;

            // Tìm hàng theo khóa chính
            DataRow row = tb.Rows.Find(cboLoave.SelectedValue);



            if (row != null)
            {
                txtDG.Text = row["DONGIA"].ToString();
            }
            else
            {
                txtDG.Text = "";
            }

            //double total = numSL.Value * double.Parse(txtDG.Text);

            if (!string.IsNullOrEmpty(txtDG.Text))
            {
                if (!string.IsNullOrEmpty(txtDGSP.Text))
                {
                    lblMoney.Text = (decimal.Parse(txtDG.Text) + decimal.Parse(txtDGSP.Text) * numSL.Value).ToString() + "VNĐ";
                }
                else
                {
                    lblMoney.Text = (decimal.Parse(txtDG.Text)).ToString() + "VNĐ";
                }
            }

        }

        private void txtChonPhim_Click(object sender, EventArgs e)
        {

        }

        private void txtChonDichVu_Click(object sender, EventArgs e)
        {
            using (CustomerServiceForm serviceForm = new CustomerServiceForm())
            {
                // Mở modal, chờ người dùng chọn dịch vụ
                if (serviceForm.ShowDialog() == DialogResult.OK)
                {
                    // Lấy giá trị đã chọn
                    txtMaSP.Text = serviceForm.SelectedServiceID;
                    txtTenSP.Text = serviceForm.SelectedServiceName;
                    txtDGSP.Text = serviceForm.SelectedPrice;
                }
            }
            lblMoney.Text = (decimal.Parse(txtDG.Text) + decimal.Parse(txtDGSP.Text) * numSL.Value).ToString() + "VNĐ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }


        private string createdID()
        {
            string sql = "SELECT TOP 1 MAVE FROM VE ORDER BY MAVE DESC";

            SqlConnection con = new SqlConnection(ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, "sa", "123"));

            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            string currentcode = null;

            if (reader.Read())
            {
                currentcode = reader["MAVE"].ToString();
            }

            con.Close();



            int newID = 1;

            if (!string.IsNullOrEmpty(currentcode))
            {
                string currentID = currentcode;

                // Định dạng KH + 8 số
                if (currentID.Length == 9 && currentID.StartsWith("V") &&
                    int.TryParse(currentID.Substring(1, 8), out int num))
                {
                    newID = num + 1;
                }
            }


            return "V" + newID.ToString("D8");
        }

        string currentTransactionId;
        private void SaveTicketToDatabase()
        {
            SqlConnection con = new SqlConnection(
                ConnectionHelper.CreateConnectionString(
                    GlobalData.DataSource,
                    GlobalData.InitialCatalog,
                    "sa", "123"));

            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            try
            {
                string mave = createdID();

                string sqlVe = @"
        INSERT INTO VE (MASUAT, MALV, MAKH, MAVE, MAGHE, NGAYBANVE)
        VALUES (@masuat, @malv, @makh, @mave, @maghe, @ngaybanve)";

                SqlCommand cmdVe = new SqlCommand(sqlVe, con, tran);
                cmdVe.Parameters.AddWithValue("@masuat", suatchieu);
                cmdVe.Parameters.AddWithValue("@malv", cboLoave.SelectedValue);
                cmdVe.Parameters.AddWithValue("@makh", GlobalData.UserID);
                cmdVe.Parameters.AddWithValue("@mave", mave);
                cmdVe.Parameters.AddWithValue("@maghe", selectedSeat);
                cmdVe.Parameters.AddWithValue("@ngaybanve", DateTime.Now);
                cmdVe.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(txtMaSP.Text)
                    && int.TryParse(numSL.Value.ToString(), out int soLuong)
                    && soLuong > 0)
                {
                    string sqlDK = @"
            INSERT INTO DANGKY (MASP, MAVE, SOLUONG)
            VALUES (@masp, @mave, @soluong)";

                    SqlCommand cmdDK = new SqlCommand(sqlDK, con, tran);
                    cmdDK.Parameters.AddWithValue("@masp", txtMaSP.Text);
                    cmdDK.Parameters.AddWithValue("@mave", mave);
                    cmdDK.Parameters.AddWithValue("@soluong", soLuong);
                    cmdDK.ExecuteNonQuery();
                }

                string sqlUpdateGhe = @"
        UPDATE CT_GHE_PHONG
        SET TRANGTHAI = 'true'
        WHERE MAGHE = @maghe AND MAPHONG = @maphong";

                SqlCommand cmdUpdateGhe = new SqlCommand(sqlUpdateGhe, con, tran);
                cmdUpdateGhe.Parameters.AddWithValue("@maghe", selectedSeat);
                cmdUpdateGhe.Parameters.AddWithValue("@maphong", maPhongHienTai);
                cmdUpdateGhe.ExecuteNonQuery();

                tran.Commit();

                MessageBox.Show("Mua vé thành công! Mã vé: " + mave);

                selectedSeat = null;
                maPhongHienTai = null;
                lblGheHienTai.Text = "Ghế đang chọn: None";
                da_CTPG.Fill(ds, "CT_GHE_PHONG");
                pnlSeats.Invalidate();
            }
            catch
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        private void ShowQRCode(string qrText)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData data = generator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(data);

            Bitmap qrImage = qrCode.GetGraphic(20);
            picQR.Image = qrImage;
        }

        private static Dictionary<string, bool> fakeConfirmStorage = new Dictionary<string, bool>();
        private Task CreatePendingTransaction(string tx)
        {
            if (!fakeConfirmStorage.ContainsKey(tx))
                fakeConfirmStorage.Add(tx, false);

            return Task.CompletedTask;
        }

     
       
        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSeat) || string.IsNullOrEmpty(maPhongHienTai))
            {
                MessageBox.Show("Vui lòng chọn ghế trước khi mua.");
                return;
            }

            if (MessageBox.Show(
                $"Thanh toán hóa đơn phim {txtTenPhim.Text} với chi phí {lblMoney.Text}",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            SaveTicketToDatabase();
        }

        private void cboPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numSL_ValueChanged(object sender, EventArgs e)
        {
            if(numSL.Value > 0)
            {
                lblMoney.Text = (decimal.Parse(txtDG.Text) + decimal.Parse(txtDGSP.Text) * numSL.Value).ToString() + "VNĐ";
            }
        }
    }
}
