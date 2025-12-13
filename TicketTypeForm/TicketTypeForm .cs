using Common;
using System.Data;
using System.Data.SqlClient;
namespace TicketTypeForm
{
    public partial class TicketTypeForm : Form
    {
        string str = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, "sa", "123");

        SqlConnection con;

        DataSet ds_Ve;

        SqlDataAdapter da_Ve;

        SqlDataAdapter da_LV;

        DataColumn[] key = new DataColumn[1];

        DataColumn[] key_LV = new DataColumn[1];

        public TicketTypeForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ticket;

            dgv_Ve.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv_Ve.AllowUserToAddRows = false;


            //Thêm ảnh vào button

            foreach (Button btn in grpChucnag.Controls.OfType<Button>())
            {
                btn.TextAlign = ContentAlignment.MiddleRight;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
            }

            btnAdd.Image = new Bitmap(Properties.Resources.addnew.ToBitmap(), new Size(40, 40));

            btnDelete.Image = new Bitmap(Properties.Resources.delete.ToBitmap(), new Size(40, 40));

            btnUpdate.Image = new Bitmap(Properties.Resources.change.ToBitmap(), new Size(40, 40));

            btnSave.Image = new Bitmap(Properties.Resources.save.ToBitmap(), new Size(40, 40));

            string sqlVe = "SP_THONGTINVE";

            con = new SqlConnection(str);

            da_Ve = new SqlDataAdapter(sqlVe, con);

            da_LV = new SqlDataAdapter("SELECT * FROM LOAIVE", con);

            ds_Ve = new DataSet();

            da_Ve.Fill(ds_Ve, "VE");

            da_LV.Fill(ds_Ve, "LV");

            key[0] = ds_Ve.Tables["VE"].Columns[0];

            //ds_Ve.Tables["VE"].PrimaryKey = key;

            key_LV[0] = ds_Ve.Tables["LV"].Columns[0];

            ds_Ve.Tables["LV"].PrimaryKey = key_LV;

            SqlCommandBuilder build_Ve = new SqlCommandBuilder(da_LV);

        }

        void Load_DataGridView()
        {
            dgv_Ve.DataSource = ds_Ve.Tables["VE"];

            dgv_Ve.Columns[0].HeaderText = "Mã loại vé";

            dgv_Ve.Columns[1].HeaderText = "Tên loại vé";

            dgv_Ve.Columns[2].HeaderText = "Đơn giá";

            dgv_Ve.Columns[3].HeaderText = "Loại ghế";

            dgv_Ve.Columns[4].Visible = false; 

            dgv_Ve.Columns[5].Visible = false;

            dgv_Ve.Columns[6].Visible = false;
        }


        void Binding(DataTable dt)
        {
            if (dt == null) return;

            txtMaLV.DataBindings.Clear();

            txtMaLV.DataBindings.Add("Text", dt, "MALV");

            txtTenVe.DataBindings.Clear();

            txtTenVe.DataBindings.Add("Text", dt, "TENLV");

            txtDonGia.DataBindings.Clear();

            txtDonGia.DataBindings.Add("Text", dt, "DONGIA");

            txtLoaiGhe.DataBindings.Clear();

            txtLoaiGhe.DataBindings.Add("Text", dt, "LOAIGHE");

           

        }

        void EnableTextBox(bool enable = false)
        {
            foreach (Control ctrl in grpInfo.Controls.OfType<TextBox>())
            {
                ctrl.Enabled = enable;
            }
        }

        void EnableButton(bool enable = false)
        {
            foreach (Control ctrl in grpChucnag.Controls.OfType<Button>())
            {
                ctrl.Enabled = enable;
            }
            btnAdd.Enabled = true;
        }

        private void TicketTypeForm_Load(object sender, EventArgs e)
        {
            Load_DataGridView();

            EnableTextBox();

            EnableButton();
        }

        private void dgv_Ve_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Binding(ds_Ve.Tables["VE"]);

            btnUpdate.Enabled = true;

            btnDelete.Enabled = true;
        }

        string createdID()
        {
            int max = 0;

            foreach (DataRow row in ds_Ve.Tables["VE"].Rows)
            {
                string currentID = row["MALV"].ToString();
                if (currentID.Length > 2 && int.TryParse(currentID.Substring(4), out int num))
                {
                    if (num > max)
                        max = num;
                }
            }

            max++;

            return "LV" + max.ToString("D8");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

            txtMaLV.Text = createdID();

            txtTenVe.Enabled = true;
            txtDonGia.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

            txtTenVe.Enabled = true;
            txtDonGia.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int cnt = 0;

            if (string.IsNullOrEmpty(txtTenVe.Text))
            {
                errorProvider.SetError(txtTenVe, "Tên loại vé không được để trống!");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }

            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                errorProvider.SetError(txtDonGia, "Đơn giá không được để trống!");
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

            string sql = "SELECT COUNT(*) FROM LOAIVE WHERE MALV = @key";

            CheckKey check = new CheckKey();

            int kq = check.CheckPrimaryKey(str, sql, txtMaLV.Text.Trim());

            if (kq == 1)
            {
                DataRow row = ds_Ve.Tables["LV"].Rows.Find(txtMaLV.Text.Trim());

                row["TENLV"] = txtTenVe.Text.Trim();

                row["DONGIA"] = decimal.Parse(txtDonGia.Text.Trim());


                da_LV.Update(ds_Ve, "LV");

                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                EnableTextBox();

                EnableButton();

                btnSave.Enabled = false;

                DataTable tmp = new DataTable();

                da_Ve.Fill(tmp);

                ds_Ve.Tables["VE"].Merge(tmp);

            }
            else if (kq == 0)
            {
                DataRow row = ds_Ve.Tables["LV"].NewRow();
                row["MALV"] = txtMaLV.Text.Trim();
                row["TENLV"] = txtTenVe.Text.Trim();
                row["DONGIA"] = decimal.Parse(txtDonGia.Text.Trim());
                ds_Ve.Tables["LV"].Rows.Add(row);
                da_LV.Update(ds_Ve, "LV");
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                EnableTextBox();
                EnableButton();
                btnSave.Enabled = false;

                DataTable tmp = new DataTable();

                da_Ve.Fill(tmp);

                ds_Ve.Tables["VE"].Merge(tmp);

            }
            else
            {
                MessageBox.Show("Lỗi kết nối database!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }

        }
        private void ReloadTable()
        {
            if (ds_Ve.Tables.Contains("VE"))
            {
                ds_Ve.Tables["VE"].Clear();
            }

            da_Ve.Fill(ds_Ve, "VE");

            dgv_Ve.DataSource = ds_Ve.Tables["VE"];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLV.Text))
            {
                MessageBox.Show("Vui lòng chọn loại vé cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa loại vé này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DataTable dtLV = ds_Ve.Tables["LV"];
                    DataRow row = dtLV.Rows.Find(txtMaLV.Text.Trim());
                    if (row != null)
                    {
                        row.Delete();

                        da_LV.Update(ds_Ve, "LV");

                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ReloadTable();

                        EnableTextBox();
                        EnableButton();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thất bại! Loại vé này đang được sử dụng trong bảng Vé.\n" + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
