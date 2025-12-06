using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Common;
namespace TheaterRoomForm
{
    public partial class TheaterRoom : Form
    {
        public string Strcon;

        public string ID = "";

        public string Name = "";

        SqlConnection con;

        public DataSet listTable;

        public SqlDataAdapter readRooms;

        DataColumn[] keyRooms = new DataColumn[1];

        public TheaterRoom()
        {
            InitializeComponent();

            

            this.Icon = Properties.Resources.TheaterRoom;

            //Thêm ảnh vào button

            foreach (Button btn in grpDetails.Controls.OfType<Button>())
            {
                btn.TextAlign = ContentAlignment.MiddleRight;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
            }

            btnAdd.Image = new Bitmap(Properties.Resources.addnew.ToBitmap(), new Size(40, 40));

            btnDelete.Image = new Bitmap(Properties.Resources.delete.ToBitmap(), new Size(40, 40));

            btnUpdate.Image = new Bitmap(Properties.Resources.change.ToBitmap(), new Size(40, 40));

            btnSave.Image = new Bitmap(Properties.Resources.save.ToBitmap(), new Size(40, 40));

            btnDetails.Image = new Bitmap(Properties.Resources.info.ToBitmap(), new Size(40, 40));

            btnClose.Image = new Bitmap(Properties.Resources.close.ToBitmap(), new Size(40, 40));

            numAmount.TextAlign = HorizontalAlignment.Right;

            //Strcon = ConnectionHelper.GetconnectionString();

            Strcon = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, GlobalData.UserID, GlobalData.Password);

            //Khởi tạo kết nối
            con = new SqlConnection(Strcon);

            //Khởi tạo DataSet

            listTable = new DataSet();

            //Khởi tạo DataAdapter

            string sql = "SELECT * FROM PHONGCHIEU";

            readRooms = new SqlDataAdapter(sql, con);


            readRooms.Fill(listTable, "PHONGCHIEU");

            //Khởi tạo khóa chính

            keyRooms[0] = listTable.Tables["PHONGCHIEU"].Columns[0];
            listTable.Tables["PHONGCHIEU"].PrimaryKey = keyRooms;

            dgv_TheaterRoom.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv_TheaterRoom.AllowUserToAddRows = false;

            numAmount.Minimum = 0;
            numAmount.Maximum = 250;


        }

        void load_datagridview()
        {
            dgv_TheaterRoom.DataSource = listTable.Tables["PHONGCHIEU"];

            dgv_TheaterRoom.Columns[0].HeaderText = "Mã phòng chiếu";
            dgv_TheaterRoom.Columns[1].HeaderText = "Tên phòng chiếu";
            dgv_TheaterRoom.Columns[2].HeaderText = "Số lượng ghế";
        }


        void Bingdings(DataTable dt)
        {

            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            numAmount.DataBindings.Clear();

            txtID.DataBindings.Add("Text", dt, "MAPHONG");
            txtName.DataBindings.Add("Text", dt, "TENPHONG");
            numAmount.DataBindings.Add("Value", dt, "TONGSOGHE");

        }

        void EnableButton(bool status = false)
        {
            foreach (Button btn in grpDetails.Controls.OfType<Button>())
            {
                if (btn == btnAdd || btn == btnClose) continue;

                btn.Enabled = status;
            }
        }

        void EnableTextBox(bool status = false)
        {
            foreach (TextBox txt in grpDetails.Controls.OfType<TextBox>())
            {
                txt.Enabled = status;
            }
            numAmount.Enabled = status;
        }
        private void TheaterRoom_Load(object sender, EventArgs e)
        {


            EnableButton();

            EnableTextBox();

            load_datagridview();
        }

        private void dgv_TheaterRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Bingdings(listTable.Tables["PHONGCHIEU"]);

            EnableButton(true);
            btnSave.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TheaterRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có chắc chắn muốn đóng cửa sổ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableTextBox(true);
            btnSave.Enabled = true;

            txtID.Text = "PC";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            EnableTextBox(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            //Kiểm tra ràng buộc dữ liệu mã phòng
            if (string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                errorProvider.SetError(txtID, "Mã phòng chiếu không được để trống");
                cnt++;
            }
            else if (txtID.Text.Trim().Length > 10 || txtID.Text.Trim().Length < 10)
            {
                errorProvider.SetError(txtID, "Mã phòng chiếu phải có 10 ký tự");
                cnt++;
            }
            else if (!txtID.Text.Trim().StartsWith("PC"))
            {
                errorProvider.SetError(txtID, "Mã phòng chiếu phải bắt đầu bằng 'PC'");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }
            //Kiểm tra ràng buộc dữ liệu tên phòng
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                errorProvider.SetError(txtName, "Tên phòng chiếu không được để trống");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }
            //Kiểm tra ràng buộc dữ liệu số lượng ghế
            if (numAmount.Value <= 0)
            {
                errorProvider.SetError(numAmount, "Số lượng ghế phải lớn hơn 0");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }
            //Nếu có lỗi thì dừng
            if (cnt > 0) return;

            //Xử lý lưu trữ vào csdl

            CheckKey check = new CheckKey();

            string sql = "SELECT COUNT(*) FROM PHONGCHIEU WHERE MAPHONG = @key";

            int kq = check.CheckPrimaryKey(Strcon, sql, txtID.Text.Trim());

            //Đã tồn tại khóa chính -> cập nhật
            if (kq == 1)
            {
                try
                {
                    DataRow row = listTable.Tables["PHONGCHIEU"].Rows.Find(txtID.Text.Trim());

                    row["TENPHONG"] = txtName.Text.Trim();
                    row["TONGSOGHE"] = Convert.ToInt32(numAmount.Value);
                    SqlCommandBuilder build = new SqlCommandBuilder(readRooms);
                    readRooms.Update(listTable, "PHONGCHIEU");

                    DataTable temp = new DataTable();

                    readRooms.Fill(temp);

                    listTable.Tables["PHONGCHIEU"].Merge(temp);

                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không thể cập nhật", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Chưa tồn tại -> thêm 
            else if (kq == 0)
            {
                try
                {
                    DataRow newRow = listTable.Tables["PHONGCHIEU"].NewRow();

                    newRow["MAPHONG"] = txtID.Text.Trim();
                    newRow["TENPHONG"] = txtName.Text.Trim();
                    newRow["TONGSOGHE"] = Convert.ToInt32(numAmount.Value);

                    listTable.Tables["PHONGCHIEU"].Rows.Add(newRow);

                    SqlCommandBuilder build = new SqlCommandBuilder(readRooms);
                    readRooms.Update(listTable, "PHONGCHIEU");

                    DataTable temp = new DataTable();
                    readRooms.Fill(temp);
                    listTable.Tables["PHONGCHIEU"].Merge(temp);

                    MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không thể thêm mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lỗi kết nối đến database", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Lưu trữ thành công

            EnableButton();
            EnableTextBox();

            foreach (TextBox txt in grpDetails.Controls.OfType<TextBox>())
            {
                txt.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng chiếu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sqlSuatChieu = "SELECT COUNT(*) FROM SUATCHIEU WHERE MAPHONG = @key";

                string sqlGhe = "SELECT COUNT(*) FROM GHE WHERE MAPHONG = @key";

                int kq = 0;

                CheckKey check = new CheckKey();

                kq = check.CheckForeignKey(Strcon, sqlSuatChieu, txtID.Text.Trim());

                if (kq == 1)
                {
                    MessageBox.Show("Phòng chiếu này đã được sử dụng trong suất chiếu, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                kq = check.CheckForeignKey(Strcon, sqlGhe, txtID.Text.Trim());

                if (kq == 1)
                {
                    MessageBox.Show("Phòng chiếu này đã có ghế được tạo, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    DataRow row = listTable.Tables["PHONGCHIEU"].Rows.Find(txtID.Text.Trim());

                    row.Delete();

                    SqlCommandBuilder build = new SqlCommandBuilder(readRooms);
                    readRooms.Update(listTable, "PHONGCHIEU");

                    DataTable temp = new DataTable();
                    readRooms.Fill(temp);
                    listTable.Tables["PHONGCHIEU"].Merge(temp);

                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi không thể xóa phòng chiếu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                EnableButton();
                EnableTextBox();

                foreach (TextBox txt in grpDetails.Controls.OfType<TextBox>())
                {
                    txt.Clear();
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            ID = txtID.Text.Trim();

            Name = txtName.Text.Trim();

            TheaterRoomDetails details = new TheaterRoomDetails(ID, Name, listTable);

            details.Show();

            this.Hide();
        }
    }
}
