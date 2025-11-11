using Common;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ServiceForm
{
    public partial class ServiceForm : Form
    {
        string str = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, "sqlserver", "123456789");

        SqlConnection con;

        SqlDataAdapter da_Service;

        DataSet ds;

        DataColumn[] key = new DataColumn[1];

        OpenFileDialog openFile;

        public ServiceForm()
        {
            InitializeComponent();



            dgv_Service.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv_Service.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_Service.AllowUserToAddRows = false;

            //Thêm ảnh vào button

            foreach (Button btn in grpChucnag.Controls.OfType<Button>())
            {
                btn.TextAlign = ContentAlignment.MiddleRight;
                btn.ImageAlign = ContentAlignment.MiddleLeft;
            }

            btnAdd.Image = new Bitmap(Properties.Resources.Addnew.ToBitmap(), new Size(40, 40));

            btnDelete.Image = new Bitmap(Properties.Resources.delete.ToBitmap(), new Size(40, 40));

            btnUpdate.Image = new Bitmap(Properties.Resources.change.ToBitmap(), new Size(40, 40));

            btnSave.Image = new Bitmap(Properties.Resources.save.ToBitmap(), new Size(40, 40));

            btnDuyet.TextAlign = ContentAlignment.MiddleCenter;

            con = new SqlConnection(str);

            da_Service = new SqlDataAdapter("SELECT * FROM DICHVU", con);

            ds = new DataSet();

            da_Service.Fill(ds, "Service");

            key[0] = ds.Tables["Service"].Columns[0];

            ds.Tables["Service"].PrimaryKey = key;

            SqlCommandBuilder build = new SqlCommandBuilder(da_Service);
        }

        void loadData()
        {
            dgv_Service.DataSource = ds.Tables["Service"];

            dgv_Service.Columns[0].HeaderText = "Mã dịch vụ";
            dgv_Service.Columns[1].HeaderText = "Tên dịch vụ";
            dgv_Service.Columns[2].HeaderText = "Đơn giá";
            dgv_Service.Columns[3].HeaderText = "Hình Ảnh";


        }

        void EnableTextBox(bool enable = false)
        {
            foreach (Control ctrl in grpChucnag.Controls.OfType<TextBox>())
            {
                ctrl.Enabled = enable;
            }
        }

        void enableButton(bool enable = false)
        {
            foreach (Control ctrl in grpChucnag.Controls.OfType<Button>())
            {
                ctrl.Enabled = enable;
            }
            btnAdd.Enabled = true;
            btnDuyet.Enabled = enable;
        }
        private void ServiceForm_Load(object sender, EventArgs e)
        {
            loadData();

            EnableTextBox();

            enableButton();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = ds.Tables["Service"].DefaultView;
            dv.RowFilter = string.Format("TENSP LIKE '%{0}%'", txtSearch.Text);
            dgv_Service.DataSource = dv;

        }
        private void ReloadTable()
        {
            if (ds.Tables.Contains("Service"))
            {
                ds.Tables["Service"].Clear();
            }

            da_Service.Fill(ds, "Service");

            dgv_Service.DataSource = ds.Tables["Service"];
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView();
            dv = ds.Tables["Service"].DefaultView;
            dv.RowFilter = string.Format("TENSP LIKE '%%'");
            dgv_Service.DataSource = dv;
        }

        void Bingding(DataTable dt)
        {
            txtMaDV.DataBindings.Clear();
            txtTenDV.DataBindings.Clear();
            txtDonGia.DataBindings.Clear();
            txtAh.DataBindings.Clear();

            txtMaDV.DataBindings.Add("Text", dt, "MASP");
            txtTenDV.DataBindings.Add("Text", dt, "TENSP");
            txtDonGia.DataBindings.Add("Text", dt, "DONGIA");
            txtAh.DataBindings.Add("Text", dt, "HINH_ANH");

        }

        private void dgv_Service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Bingding(ds.Tables["Service"]);
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            EnableTextBox(true);
            btnDuyet.Enabled = true;
            txtMaDV.Enabled = false;
            txtMaDV.Text = createdID();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            EnableTextBox(true);
            txtMaDV.Enabled = false;
            btnDuyet.Enabled = true;
        }

        string createdID()
        {
            int max = 0;

            foreach (DataRow row in ds.Tables["Service"].Rows)
            {
                string currentID = row["MASP"].ToString();
                if (currentID.Length > 2 && int.TryParse(currentID.Substring(4), out int num))
                {
                    if (num > max)
                        max = num;
                }
            }

            max++;

            return "DV" + max.ToString("D8");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            if (string.IsNullOrEmpty(txtMaDV.Text))
            {
                errorProvider.SetError(txtMaDV, "Mã dịch vụ không được để trống");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }
            if (string.IsNullOrEmpty(txtTenDV.Text))
            {
                errorProvider.SetError(txtTenDV, "Tên dịch vụ không được để trống");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }
            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                errorProvider.SetError(txtDonGia, "Đơn giá không được để trống");
                cnt++;
            }
            else
            {
                errorProvider.Clear();
            }
            if (cnt > 0) return;

            string sql = "SELECT COUNT(*) FROM DICHVU WHERE MASP = @key";

            Common.CheckKey checkKey = new CheckKey();

            int exists = checkKey.CheckPrimaryKey(str, sql, txtMaDV.Text);

            if (exists == 1)
            {

                try
                {
                    using (SqlConnection con = new SqlConnection(str))
                    {
                        con.Open();

                        string sqlDV = "UPDATE DICHVU " +
                                     "SET TENSP=@TENSP, DONGIA=@DONGIA, HINH_ANH=@HINH_ANH " +
                                     "WHERE MASP=@MASP";

                        using (SqlCommand cmd = new SqlCommand(sqlDV, con))
                        {
                            cmd.Parameters.AddWithValue("@TENSP", txtTenDV.Text.Trim());
                            cmd.Parameters.AddWithValue("@DONGIA", decimal.Parse(txtDonGia.Text.Trim()));
                            cmd.Parameters.AddWithValue("@HINH_ANH", openFile.FileName);
                            cmd.Parameters.AddWithValue("@MASP", txtMaDV.Text.Trim());

                            int result = cmd.ExecuteNonQuery();

                            saveImageIntoFolder(openFile.FileName);


                            if (result > 0)
                                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            else
                                MessageBox.Show("Không tìm thấy dịch vụ cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (exists == 0)
            {
                try
                {

                    DataRow row = ds.Tables["Service"].NewRow();

                    row["MASP"] = txtMaDV.Text.Trim();

                    row["TENSP"] = txtTenDV.Text.Trim();

                    row["DONGIA"] = txtDonGia.Text.Trim();

                    row["HINH_ANH"] = openFile.FileName;

                    ds.Tables["Service"].Rows.Add(row);

                    saveImageIntoFolder(openFile.FileName);


                    da_Service.Update(ds, "Service");


                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lỗi kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ReloadTable();
            EnableTextBox(false);
            enableButton();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDV.Text))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    DataRow row = ds.Tables["Service"].Rows.Find(txtMaDV.Text.Trim());

                    if (row != null)
                    {
                        row.Delete();

                        da_Service.Update(ds, "Service");

                        MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy dịch vụ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dịch vụ đang được sử dụng không thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ReloadTable();
                EnableTextBox(false);
                enableButton();
            }
        }

        void saveImageIntoFolder(string sourcePath)
        {
            try
            {
                string fileName = Path.GetFileName(sourcePath);

                // đi lên 3 cấp tới thư mục chứa .sln
                string solutionFolder = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\.."));
                string destinationFolder = Path.Combine(solutionFolder, "Images", "Services");

                if (!Directory.Exists(destinationFolder))
                    Directory.CreateDirectory(destinationFolder);

                string destinationPath = Path.Combine(destinationFolder, fileName);

                if (File.Exists(destinationPath))
                    File.Delete(destinationPath);

                File.Copy(sourcePath, destinationPath);

                txtAh.Text = destinationPath;
                pictureBox1.Image = Image.FromFile(destinationPath);

                MessageBox.Show("Đã lưu hình ảnh vào: " + destinationPath, "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hình ảnh: " + ex.Message);
            }
        }



        private void btnDuyet_Click(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFile.Title = "Chọn hình ảnh";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtAh.Text = openFile.FileName;
            }

        }

        private void txtAh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtAh.Text))
                {
                    pictureBox1.Image = Image.FromFile(txtAh.Text);
                }
                else
                {
                    string imagePath = Path.Combine(Application.StartupPath, "Resources", "xrp35snr.png");
                    if (File.Exists(imagePath))
                        pictureBox1.Image = Image.FromFile(imagePath);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
