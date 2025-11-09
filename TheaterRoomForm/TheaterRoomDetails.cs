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

namespace TheaterRoomForm
{
    public partial class TheaterRoomDetails : Form
    {

        public string Str;

        private string IDRooms = "";

        private string nameRooms = "";

        SqlConnection con;

        DataSet listTable;

        SqlDataAdapter readChairs;

        SqlDataAdapter readCategory;


        TheaterRoom room;

        DataView dv;

        DataSet list;

        DataColumn[] keyRooms = new DataColumn[2];

        DataColumn[] keyCategory = new DataColumn[1];

        public TheaterRoomDetails(string id, string name, DataSet list)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.TheaterRoom;

            IDRooms = id;

            nameRooms = name;

            this.list = list;

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


            btnClose.Image = new Bitmap(Properties.Resources.close.ToBitmap(), new Size(40, 40));

            room = new TheaterRoom();

            lblName.Text = "Danh sách ghế của phòng: " + nameRooms;
            Str = room.Strcon;
            //Khởi tạo kết nối
            con = new SqlConnection(Str);

            //Khởi tạo DataSet

            listTable = new DataSet();

            //Khởi tạo DataAdapter

            string sql = "SELECT MAGHE, MAPHONG, LOAIGHE, TRANGTHAI FROM GHE WHERE 1 = 1";

            string sqlcategory = "SELECT DISTINCT LOAIGHE FROM GHE";

            readChairs = new SqlDataAdapter(sql, con);

            readCategory = new SqlDataAdapter(sqlcategory, con);

            if (listTable.Tables.Contains("GHE"))
                listTable.Tables.Remove("GHE");

            readChairs.Fill(listTable, "GHE");

            readCategory.Fill(listTable, "Category");
            //Khởi tạo khóa chính

            keyRooms[0] = listTable.Tables["GHE"].Columns[0];
            keyRooms[1] = listTable.Tables["GHE"].Columns[1];

            listTable.Tables["GHE"].PrimaryKey = keyRooms;

            keyCategory[0] = listTable.Tables["Category"].Columns[0];

            listTable.Tables["Category"].PrimaryKey = keyCategory;

            dgv_Chair.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv_Chair.AllowUserToAddRows = false;

            dv = new DataView(listTable.Tables["GHE"]);
            dv.RowFilter = $"MAPHONG = '{IDRooms}'";

        }

        void load_datagridview()
        {

            dgv_Chair.DataSource = dv;


            dgv_Chair.Columns[0].HeaderText = "Mã ghế";
            dgv_Chair.Columns[1].HeaderText = "Mã phòng";
            dgv_Chair.Columns[2].HeaderText = "Loại ghê";
            dgv_Chair.Columns[3].HeaderText = "Trạng thái ghế";
        }

        void load_cbo()
        {

            cboLoaiGhe.DataSource = listTable.Tables["Category"];

            cboLoaiGhe.DisplayMember = "LOAIGHE";

            cboLoaiGhe.ValueMember = "LOAIGHE";
        }

        void load_phong()
        {
            cboMaPHong.DataSource = list.Tables["PHONGCHIEU"];

            cboMaPHong.DisplayMember = "TENPHONG";
            cboMaPHong.ValueMember = "MAPHONG";
        }

        void Bingding(DataView dv)
        {
            txtMaGhe.DataBindings.Clear();
            cboMaPHong.DataBindings.Clear();
            cboLoaiGhe.DataBindings.Clear();

            txtMaGhe.DataBindings.Add("Text", dv, "MAGHE");
            cboMaPHong.DataBindings.Add("SelectedValue", dv, "MAPHONG");
            cboLoaiGhe.DataBindings.Add("SelectedValue", dv, "LOAIGHE");
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
        }

        void enableCbo(bool status = false)
        {
            foreach (ComboBox cbo in grpDetails.Controls.OfType<ComboBox>())
            {
                cbo.Enabled = status;
            }
        }

        private void TheaterRoomDetails_Load(object sender, EventArgs e)
        {
            load_datagridview();

            load_cbo();

            load_phong();

            EnableButton();

            EnableTextBox();

            enableCbo();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgv_Chair_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Bingding(dv);
            enableCbo(true);
            EnableTextBox(true);
            EnableButton(true);
            btnSave.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enableCbo(true);
            EnableTextBox(true);
            btnSave.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa ghế này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string sql = "SELECT COUNT(*) FROM VE WHERE MAGHE = @key";

                CheckKey check = new CheckKey();

                int checkFK = check.CheckForeignKey(Str, sql, txtMaGhe.Text.Trim());

                if (checkFK == 1)
                {
                    MessageBox.Show("Ghế đăng được sử dụng không thể xóa", sql, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow dr = listTable.Tables["GHE"].Rows.Find(txtMaGhe.Text.Trim());

                dr.Delete();

                SqlCommandBuilder cmb = new SqlCommandBuilder(readChairs);

                readChairs.Update(listTable, "GHE");

                MessageBox.Show("Xóa ghế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(txtMaGhe.Text))
            {
                errorProvider.SetError(txtMaGhe, "Mã ghế không được để trống");
                cnt++;
            }
            else if (txtMaGhe.Text.Trim().Length > 10 || txtMaGhe.Text.Trim().Length < 9)
            {
                errorProvider.SetError(txtMaGhe, "Mã ghế phải có 10 ký tự");
                cnt++;
            }
            else if (!txtMaGhe.Text.Trim().StartsWith("G"))
            {
                errorProvider.SetError(txtMaGhe, "Mã ghế phải bắt đầu bằng 'G'");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }
            // Kiểm tra loại ghế
            if (cboLoaiGhe.SelectedValue == null)
            {
                errorProvider.SetError(cboLoaiGhe, "Loại ghế không được để trống");
                cnt++;
            }
            else if (cboLoaiGhe.SelectedValue.ToString().ToUpper() != "THƯỜNG" && cboLoaiGhe.SelectedValue.ToString().ToUpper() != "VIP" && cboLoaiGhe.SelectedValue.ToString().ToUpper() != "COUPLE")
            {
                errorProvider.SetError(cboLoaiGhe, "Loại ghế không hợp lệ");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }
            //Kiêm tra phòng
            if (cboMaPHong.SelectedValue == null)
            {
                errorProvider.SetError(cboMaPHong, "Phòng chiếu không được để trống");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }

            if (cnt > 0)
            {
                return;
            }

            try
            {
                string sql = "SELECT COUNT(*) FROM GHE WHERE MAGHE = @key1 AND MAPHONG = @key2";

                CheckKey check = new CheckKey();

                int checkPK = check.CheckDoublePrimaryKey(Str, txtMaGhe.Text.Trim(), cboMaPHong.SelectedValue.ToString().Trim(), sql);

                if (checkPK == 1)
                {
                    // Cập nhật ghế
                    DataRow dr = listTable.Tables["GHE"].Rows.Find(
                        new object[] { txtMaGhe.Text.Trim(), cboMaPHong.SelectedValue.ToString().Trim() });

                    dr["MAPHONG"] = cboMaPHong.SelectedValue.ToString().Trim();
                    dr["LOAIGHE"] = cboLoaiGhe.SelectedValue;

                    SqlCommandBuilder cmb = new SqlCommandBuilder(readChairs);

                    readChairs.Update(listTable, "GHE");


                    DataTable temp = new DataTable();
                    readChairs.Fill(temp);
                    listTable.Tables["GHE"].Merge(temp);

                    MessageBox.Show("Cập nhật ghế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataRow dr = listTable.Tables["GHE"].NewRow();

                    dr["MAGHE"] = txtMaGhe.Text.Trim();

                    dr["MAPHONG"] = cboMaPHong.SelectedValue.ToString().Trim();

                    dr["LOAIGHE"] = cboLoaiGhe.SelectedValue;

                    dr["TRANGTHAI"] = "Trống";

                    listTable.Tables["GHE"].Rows.Add(dr);


                    SqlCommandBuilder cmb = new SqlCommandBuilder(readChairs);


                    readChairs.Update(listTable, "GHE");

                    DataTable temp = new DataTable();
                    readChairs.Fill(temp);
                    listTable.Tables["GHE"].Merge(temp);

                    MessageBox.Show("Thêm ghế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
