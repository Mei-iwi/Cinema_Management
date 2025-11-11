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
using Common;

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

        SqlDataAdapter readListChairs;


        TheaterRoom room;

        DataView dv;

        DataSet list;

        DataColumn[] keyRooms = new DataColumn[2];

        DataColumn[] keyCategory = new DataColumn[1];

        DataColumn[] keyLIstChair = new DataColumn[1];

        SqlDataAdapter sqlDataAdapter;

        DataColumn[] keyDetails = new DataColumn[2];


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

            string sql = "SELECT CT.MAGHE, P.MAPHONG, TENPHONG, TRANGTHAI, TONGSOGHE, LOAIGHE  FROM CT_GHE_PHONG CT INNER JOIN PHONGCHIEU P ON P.MAPHONG = CT.MAPHONG INNER JOIN GHE G ON G.MAGHE = CT.MAGHE\r\n WHERE 1 = 1";

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


            string Query = "SELECT * FROM CT_GHE_PHONG";

            sqlDataAdapter = new SqlDataAdapter(Query, con);

            SqlCommandBuilder cmbListChairs = new SqlCommandBuilder(sqlDataAdapter);


            sqlDataAdapter.Fill(listTable, "CT_GHE_PHONG");

            keyDetails[0] = listTable.Tables["CT_GHE_PHONG"].Columns[0];

            keyDetails[1] = listTable.Tables["CT_GHE_PHONG"].Columns[1];

            listTable.Tables["CT_GHE_PHONG"].PrimaryKey = keyDetails;

        }

        void load_datagridview()
        {

            dgv_Chair.DataSource = dv;


            dgv_Chair.Columns[0].HeaderText = "Mã ghế";
            dgv_Chair.Columns[1].HeaderText = "Mã phòng";
            dgv_Chair.Columns[2].HeaderText = "Tên phòng";
            dgv_Chair.Columns[3].HeaderText = "Trạng thái";
            dgv_Chair.Columns[4].Visible = false;
            dgv_Chair.Columns[5].HeaderText = "Loại ghê";

        }

   
        void load_phong()
        {
            cboMaPHong.DataSource = list.Tables["PHONGCHIEU"];

            cboMaPHong.DisplayMember = "TENPHONG";
            cboMaPHong.ValueMember = "MAPHONG";
        }

        void Bingding(DataView dv)
        {
            cboMaGhe.DataBindings.Clear();
            cboMaPHong.DataBindings.Clear();
            txtTrangThai.DataBindings.Clear();

            cboMaGhe.DataBindings.Add("SelectedValue", dv, "MAGHE");
            cboMaPHong.DataBindings.Add("SelectedValue", dv, "MAPHONG");
            txtTrangThai.DataBindings.Add("Text", dv, "TRANGTHAI");
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

        void load_maGhe()
        {
            cboMaGhe.DataSource = listTable.Tables["CT_GHE_PHONG"];

            cboMaGhe.DisplayMember = "MAGHE";
            cboMaGhe.ValueMember = "MAGHE";
        }
        private void TheaterRoomDetails_Load(object sender, EventArgs e)
        {
            load_datagridview();

            load_maGhe();

            load_phong();

            EnableButton();

            EnableTextBox();

            enableCbo();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            room = new TheaterRoom();
            room.Show();
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

                int checkFK = check.CheckForeignKey(Str, sql, cboMaGhe.SelectedValue.ToString().Trim());

                if (checkFK == 1)
                {
                    MessageBox.Show("Ghế đăng được sử dụng không thể xóa", sql, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRow dr = listTable.Tables["CT_GHE_PHONG"].Rows.Find(new object[] { cboMaGhe.SelectedValue.ToString().Trim(), cboMaPHong.SelectedValue.ToString().Trim()});

                if(dr != null)
                {
                    dr.Delete();
                }

                sqlDataAdapter.Update(listTable, "CT_GHE_PHONG");

                // Load lại bảng GHE từ database
                DataTable temp = new DataTable();
                readChairs.Fill(temp);

                // Chỉ lấy ghế của phòng hiện tại
                DataView dvTemp = new DataView(temp);
                dvTemp.RowFilter = $"MAPHONG = '{IDRooms}'";
                DataTable filtered = dvTemp.ToTable();

                // Xóa bảng GHE cũ và thêm dữ liệu mới
                listTable.Tables["GHE"].Clear();
                listTable.Tables["GHE"].Merge(filtered);

                // Refresh DataView hiển thị
                dv = new DataView(listTable.Tables["GHE"]);
                dv.RowFilter = $"MAPHONG = '{IDRooms}'";
                dgv_Chair.DataSource = dv;


                MessageBox.Show("Xóa ghế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrEmpty(cboMaGhe.SelectedValue.ToString().Trim()))
            {
                errorProvider.SetError(cboMaGhe, "Mã ghế không được để trống");
                cnt++;
            }
            else if (cboMaGhe.SelectedValue.ToString().Trim().Length > 10 || cboMaGhe.SelectedValue.ToString().Trim().Length < 9)
            {
                errorProvider.SetError(cboMaGhe, "Mã ghế phải có 10 ký tự");
                cnt++;
            }
            else if (!cboMaGhe.SelectedValue.ToString().Trim().StartsWith("G"))
            {
                errorProvider.SetError(cboMaGhe, "Mã ghế phải bắt đầu bằng 'G'");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }
            // Kiểm tra loại ghế
            if (string.IsNullOrEmpty(txtTrangThai.Text) == null)
            {
                errorProvider.SetError(txtTrangThai, "Trạng thái ghế không được để trống");
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
                string sql = "SELECT COUNT(*) FROM CT_GHE_PHONG WHERE MAGHE = @key1 AND MAPHONG = @key2";

                CheckKey check = new CheckKey();

                int checkPK = check.CheckDoublePrimaryKey(Str, cboMaGhe.SelectedValue.ToString().Trim(), cboMaPHong.SelectedValue.ToString().Trim(), sql);

              
                if (checkPK == 1)
                {
                    // Cập nhật ghế
                    DataRow dr = listTable.Tables["CT_GHE_PHONG"].Rows.Find(
                        new object[] { cboMaGhe.SelectedValue.ToString().Trim(), cboMaPHong.SelectedValue.ToString().Trim() });

                    if(dr != null)
                    {
                        dr["MAPHONG"] = cboMaPHong.SelectedValue.ToString().Trim();
                        dr["TRANGTHAI"] = txtTrangThai.Text;
                    }


                    sqlDataAdapter.Update(listTable, "CT_GHE_PHONG");


                    MessageBox.Show("Cập nhật ghế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int exists = 0;

                    string chairs = "SELECT COUNT(*) FROM GHE WHERE MAGHE = @key";

                    string rooms = "SELECT COUNT(*) FROM PHONGCHIEU WHERE MAPHONG = @key";

                    exists = check.CheckForeignKey(Str, chairs, cboMaGhe.SelectedValue.ToString().Trim());

                    if(exists  == 0) {
                        MessageBox.Show("Ghế không tồn tại trong hệ thống. Vui lòng thêm ghế vào danh mục ghế trước khi thêm vào phòng chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    exists = check.CheckForeignKey(Str, rooms, cboMaPHong.SelectedValue.ToString().Trim());
                    if(exists == 0) {
                        MessageBox.Show("Phòng chiếu không tồn tại trong hệ thống. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DataRow dr = listTable.Tables["CT_GHE_PHONG"].NewRow();

                    dr["MAGHE"] = cboMaGhe.SelectedValue.ToString().Trim();

                    dr["MAPHONG"] = cboMaPHong.SelectedValue.ToString().Trim();

                    dr["TRANGTHAI"] = "Trống";

                    listTable.Tables["CT_GHE_PHONG"].Rows.Add(dr);


                    sqlDataAdapter.Update(listTable, "CT_GHE_PHONG");

                    MessageBox.Show("Thêm ghế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            // Load lại bảng GHE từ database
            DataTable temp = new DataTable();
            readChairs.Fill(temp);

            // Chỉ lấy ghế của phòng hiện tại
            DataView dvTemp = new DataView(temp);
            dvTemp.RowFilter = $"MAPHONG = '{IDRooms}'";
            DataTable filtered = dvTemp.ToTable();

            // Xóa bảng GHE cũ và thêm dữ liệu mới
            listTable.Tables["GHE"].Clear();
            listTable.Tables["GHE"].Merge(filtered);

            // Refresh DataView hiển thị
            dv = new DataView(listTable.Tables["GHE"]);
            dv.RowFilter = $"MAPHONG = '{IDRooms}'";
            dgv_Chair.DataSource = dv;


          
        }
    }
}
