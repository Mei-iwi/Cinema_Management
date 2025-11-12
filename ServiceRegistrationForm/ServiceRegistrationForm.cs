using Common;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ServiceRegistrationForm
{
    public partial class ServiceRegistrationForm : Form
    {

        string connectionString = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, "NV00000001", "Abc12345!");

        SqlConnection con;

        SqlDataAdapter da_res;

        SqlDataAdapter da_Ser;

        SqlDataAdapter da_Tik;

        DataSet ds;

        DataColumn[] key_res = new DataColumn[2];

        DataColumn[] key_Ser = new DataColumn[1];

        DataColumn[] key_Tik = new DataColumn[1];

        DataView dataView;

        BindingSource bsView = new BindingSource();

        bool load = false;

        public ServiceRegistrationForm()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.Services;

            foreach (Button btn in grpChucnag.Controls.OfType<Button>())
            {
                //btn.FlatStyle = FlatStyle.Flat;
                //btn.FlatAppearance.BorderSize = 1;
                //btn.BackColor = Color.FromArgb(240, 240, 240);
                //btn.Cursor = Cursors.Hand;
                btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(200, 200, 200); };

                btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(240, 240, 240); };

                btn.TextAlign = ContentAlignment.BottomCenter;

                btn.ImageAlign = ContentAlignment.TopCenter;
            }
            btnAdd.Image = new Bitmap(Properties.Resources.bill1.ToBitmap(), new Size(30, 30));

            btnDelete.Image = new Bitmap(Properties.Resources.deletebill.ToBitmap(), new Size(30, 30));

            btnUpdate.Image = new Bitmap(Properties.Resources.updatebill.ToBitmap(), new Size(30, 30));

            btnSave.Image = new Bitmap(Properties.Resources.save.ToBitmap(), new Size(30, 30));


            con = new SqlConnection(connectionString);

            string sqlRes = "SELECT DK.MASP, MAVE, SOLUONG, DONGIA, HINH_ANH  FROM DANGKY DK INNER JOIN DICHVU DV ON DV.MASP = DK.MASP";

            string sqlSer = "SELECT * FROM DICHVU";

            string sqlTik = "SELECT * FROM VE";

            da_res = new SqlDataAdapter(sqlRes, con);

            da_Ser = new SqlDataAdapter(sqlSer, con);

            da_Tik = new SqlDataAdapter(sqlTik, con);

            ds = new DataSet();

            da_res.Fill(ds, "DANGKY");

            da_Ser.Fill(ds, "DICHVU");

            da_Tik.Fill(ds, "VE");

            key_res[0] = ds.Tables["DANGKY"].Columns["MaVE"];

            key_res[1] = ds.Tables["DANGKY"].Columns["MaSP"];

            ds.Tables["DANGKY"].PrimaryKey = key_res;

            key_Ser[0] = ds.Tables["DICHVU"].Columns["MaSP"];

            ds.Tables["DICHVU"].PrimaryKey = key_Ser;

            key_Tik[0] = ds.Tables["VE"].Columns["MaVE"];

            ds.Tables["VE"].PrimaryKey = key_Tik;


            SqlCommandBuilder cb = new SqlCommandBuilder(da_res);

            dgv_Service.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv_Service.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv_Service.AllowUserToAddRows = false;
        }

        void EnableTextBox(bool enable = false)
        {
            foreach (TextBox txt in grpChucnag.Controls.OfType<TextBox>())
            {
                txt.Enabled = enable;
            }
            cboDV.Enabled = enable;

            numSL.Enabled = enable;
        }

        void EnableButotn(bool enable = false)
        {
            foreach (Button btn in grpChucnag.Controls.OfType<Button>())
            {
                btn.Enabled = enable;
            }
        }

        void Load_Service()
        {
            cboDV.DataSource = ds.Tables["DICHVU"];

            cboDV.DisplayMember = "TENSP";

            cboDV.ValueMember = "MaSP";

            load = true;
        }


        void load_dgv()
        {

            dataView = new DataView(ds.Tables["DANGKY"]);
            bsView.DataSource = dataView;
            dgv_Service.DataSource = bsView;


            dgv_Service.Columns["MaVE"].HeaderText = "Mã vé";

            dgv_Service.Columns["MaSP"].HeaderText = "Mã dịch vụ";

            dgv_Service.Columns["SOLUONG"].HeaderText = "Số lượng";

            dgv_Service.Columns["HINH_ANH"].Visible = false;

            dataView = new DataView(ds.Tables["DANGKY"]);

            dataView.RowFilter = string.Format("MaVE LIKE '%{0}%'", txtMaVE.Text);


        }

        void Bingdings(DataTable dv)
        {

            txtMaVE.DataBindings.Clear();

            txtMaVE.DataBindings.Add("Text", dv, "MaVE");

            cboDV.DataBindings.Clear();

            cboDV.DataBindings.Add("SelectedValue", dv, "MaSP");

            numSL.DataBindings.Clear();

            numSL.DataBindings.Add("Value", dv, "SOLUONG");

            txtDonGia.DataBindings.Clear();

            txtDonGia.DataBindings.Add("Text", dv, "DONGIA");

            txtTongTien.Clear();

            if (!string.IsNullOrEmpty(txtDonGia.Text))
            {
                txtTongTien.Text = (numSL.Value * Convert.ToDecimal(txtDonGia.Text)).ToString("N0") + " VNĐ";
            }
            else
            {
                txtTongTien.Text = "0";
            }

        }

        void Bingdings_View(DataView dv)
        {
            txtMaVE.DataBindings.Clear();

            txtMaVE.DataBindings.Add("Text", dv, "MaVE");

            cboDV.DataBindings.Clear();

            cboDV.DataBindings.Add("SelectedValue", dv, "MaSP");

            numSL.DataBindings.Clear();

            numSL.DataBindings.Add("Value", dv, "SOLUONG");

            txtDonGia.DataBindings.Clear();

            txtDonGia.DataBindings.Add("Text", dv, "DONGIA");

            txtTongTien.Clear();

            txtTongTien.Text = (numSL.Value * Convert.ToDecimal(txtDonGia.Text)).ToString("N0") + " VNĐ";


        }
        private void ServiceRegistrationForm_Load(object sender, EventArgs e)
        {

            EnableTextBox();

            EnableButotn();

            txtMaVE.Enabled = true;

            btnTim.Enabled = true;

            Load_Service();

            load_dgv();

            // Tạo DataView từ DataTable
            dataView = new DataView(ds.Tables["DANGKY"]);

            // Gán DataView làm nguồn cho BindingSource
            bsView.DataSource = dataView;

            // Gán BindingSource cho DataGridView
            dgv_Service.DataSource = bsView;

        }

        private void dgv_Service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bind controls 1 lần
            BindControls(bsView);
            btnAdd.Enabled = true;

            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnChitiet.Enabled = true;
        }

        void Reload()
        {
            if (ds.Tables.Contains("DANGKY"))
            {
                ds.Tables["DANGKY"].Clear();
            }

            da_res.Fill(ds, "DANGKY");

            dgv_Service.DataSource = ds.Tables["DANGKY"];

        }

        private void txtMaVE_TextChanged(object sender, EventArgs e)
        {




        }

        private void BindControls(BindingSource bs)
        {
            txtMaVE.DataBindings.Clear();
            cboDV.DataBindings.Clear();
            numSL.DataBindings.Clear();
            txtDonGia.DataBindings.Clear();
            txtLink.DataBindings.Clear();

            txtMaVE.DataBindings.Add("Text", bs, "MaVE", true, DataSourceUpdateMode.OnPropertyChanged);
            cboDV.DataBindings.Add("SelectedValue", bs, "MaSP", true, DataSourceUpdateMode.OnPropertyChanged);
            numSL.DataBindings.Add("Value", bs, "SOLUONG", true, DataSourceUpdateMode.OnPropertyChanged, 0);
            txtDonGia.DataBindings.Add("Text", bs, "DONGIA", true, DataSourceUpdateMode.OnPropertyChanged);
            txtLink.DataBindings.Add("Text", bs, "HINH_ANH", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMaVE.Text))
            {
                return;
            }
            else
            {
                dataView.RowFilter = $"MaVE LIKE '%{txtMaVE.Text}%'";
            }

            // Cập nhật tổng tiền
            decimal sum = 0;
            foreach (DataRowView dr in dataView)
            {
                if (dr["MaVE"].ToString().Contains(txtMaVE.Text))
                {
                    sum += Convert.ToInt32(dr["SOLUONG"]) * Convert.ToDecimal(dr["DONGIA"]);
                }
            }
            txtTotal.Text = sum.ToString("N0") + " VNĐ";

        }

        private void numSL_ValueChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMaVE.Text))
            {
                txtTotal.Clear();
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                txtTotal.Clear();
                return;
            }

            decimal newSum = numSL.Value * donGia;

            txtTongTien.Text = newSum.ToString("N0") + " VNĐ";

            decimal sum = 0;
            foreach (DataRowView dr in dataView)
            {
                if (dr["MaVE"].ToString() == txtMaVE.Text && dr["MASP"].ToString() != cboDV.SelectedValue.ToString())
                {
                    sum += Convert.ToDecimal(dr["SOLUONG"]) * Convert.ToDecimal(dr["DONGIA"]);
                }
            }

            sum += newSum;

            txtTotal.Text = sum.ToString("N0") + " VNĐ";


        }

        private void btnReaload_Click(object sender, EventArgs e)
        {
            dataView.RowFilter = string.Empty;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cboDV.Enabled = true;

            numSL.Value = 0;

            btnSave.Enabled = true;

            numSL.Enabled = true;
        }

        private void cboDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!load) return;
                DataRow dr = ds.Tables["DICHVU"].Rows.Find(cboDV.SelectedValue);

                txtDonGia.Text = dr["DONGIA"].ToString();

            }
            catch (Exception ex)
            {
                txtDonGia.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;

            cboDV.Enabled = false;

            numSL.Enabled = true;
        }

        private void btnChitiet_Click(object sender, EventArgs e)
        {

            string sqlDetails = "SELECT DV.MASP AS MASP, TENSP, DONGIA, SOLUONG, SOLUONG*DONGIA AS TT, HINH_ANH FROM DICHVU DV INNER JOIN DANGKY DK ON DV.MASP = DK.MASP WHERE DV.MASP = @MASP";
            DataTable dtDetails = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlDetails, con))
                {
                    cmd.Parameters.Add("@MASP", SqlDbType.NVarChar, 50).Value = cboDV.SelectedValue.ToString().Trim();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    adapter.Fill(dtDetails);


                }
            }
            Details detials = new Details(dtDetails);
            detials.ShowDialog();
        }

        private void txtLink_TextChanged(object sender, EventArgs e)
        {
            string imagePath = txtLink.Text;

            string SolutionFolder = Path.Combine(Application.StartupPath, @"..\..\..\..");

            string DestinationFoler = Path.Combine(SolutionFolder, "ServiceForm", "Images", "Services");

            string fullImagePath = Path.Combine(DestinationFoler, imagePath);

            if (File.Exists(fullImagePath))
            {
                using (FileStream fs = new FileStream(fullImagePath, FileMode.Open, FileAccess.Read))
                {
                    pictureBox1.Image = Image.FromStream(fs);
                }
            }
            else
            {
                DestinationFoler = Path.Combine(SolutionFolder, "ServiceForm", "Images", "Default");
                fullImagePath = Path.Combine(DestinationFoler, "default.png");
                using (FileStream fs = new FileStream(fullImagePath, FileMode.Open, FileAccess.Read))
                {
                    pictureBox1.Image = Image.FromStream(fs);
                }
            }
        }
        private void MergeDataDangKy()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM DANGKY"; // hoặc lọc theo MaVE nếu muốn
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                DataTable dtNew = new DataTable();
                adapter.Fill(dtNew);

                // Đảm bảo DataTable hiện tại có PrimaryKey
                DataTable dtCurrent = ds.Tables["DANGKY"];
                if (dtCurrent.PrimaryKey.Length == 0)
                {
                    dtCurrent.PrimaryKey = new DataColumn[] { dtCurrent.Columns["MaVE"], dtCurrent.Columns["MaSP"] };
                }

                // Merge dữ liệu mới
                dtCurrent.Merge(dtNew);

                // DataView tự động cập nhật, DataGridView giữ binding
                dgv_Service.Refresh();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            if (string.IsNullOrEmpty(txtMaVE.Text))
            {
                errorProvider.SetError(txtMaVE, "Mã vé không được để trống!");
                cnt++;
            }
            else
            {
                errorProvider.SetError(txtMaVE, "");
            }
            if (numSL.Value <= 0)
            {
                errorProvider.SetError(numSL, "Số lượng phải lớn hơn 0!");
                cnt++;
            }
            else
            {
                errorProvider.SetError(numSL, "");
            }
            if (cnt > 0) return;

            CheckKey check = new CheckKey();

            string sqlVe = "SELECT COUNT(*) FROM VE WHERE MaVE = @key";

            string sqlDV = "SELECT COUNT(*) FROM DICHVU WHERE MaSP = @key";

            if (check.CheckPrimaryKey(connectionString, sqlVe, txtMaVE.Text.Trim()) == 0)
            {
                MessageBox.Show("Mã vé không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (check.CheckPrimaryKey(connectionString, sqlDV, cboDV.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("Mã dịch vụ không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sqlDK = "SELECT COUNT(*) FROM DANGKY WHERE MaVE = @key1 AND MaSP = @key2";
            if (check.CheckDoublePrimaryKey(connectionString, txtMaVE.Text, cboDV.SelectedValue.ToString(), sqlDK) == 1)
            {

                try
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string sqlUpdate = "UPDATE DANGKY SET SOLUONG = @SL WHERE MASP = @MASP AND MAVE = @MAVE";
                        con.Open();

                        foreach (DataRow row in dataView.Table.Rows)
                        {
                            if (row["MaVE"].ToString() == txtMaVE.Text)
                            {
                                int newSL = Convert.ToInt32(row["SOLUONG"]);
                                string maSP = row["MASP"].ToString();


                                using (SqlCommand cmd = new SqlCommand(sqlUpdate, con))
                                {
                                    cmd.Parameters.Add("@SL", SqlDbType.Int).Value = newSL;
                                    cmd.Parameters.Add("@MAVE", SqlDbType.NVarChar, 50).Value = txtMaVE.Text;
                                    cmd.Parameters.Add("@MASP", SqlDbType.NVarChar, 50).Value = maSP;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        MessageBox.Show("Cập nhật số lượng thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                try
                {
                    string sqlAdd = "INSERT INTO DANGKY(MASP, MAVE, SOLUONG) VALUES(@MASP, @MAVE, @SOLUONG)";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand(sqlAdd, con))
                        {
                            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar, 50).Value = cboDV.SelectedValue.ToString();
                            cmd.Parameters.Add("@MAVE", SqlDbType.NVarChar, 50).Value = txtMaVE.Text;
                            cmd.Parameters.Add("@SOLUONG", SqlDbType.Int).Value = Convert.ToInt32(numSL.Value);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Thêm dịch vụ thành công!");
                    }

                    // Thêm vào DataSet
                    DataRow newRow = ds.Tables["DANGKY"].NewRow();
                    newRow["MaSP"] = cboDV.SelectedValue.ToString();
                    newRow["MaVE"] = txtMaVE.Text;
                    newRow["SOLUONG"] = Convert.ToInt32(numSL.Value);
                    DataRow drDV = ds.Tables["DICHVU"].Rows.Find(cboDV.SelectedValue.ToString());
                    newRow["DONGIA"] = drDV["DONGIA"];
                    newRow["HINH_ANH"] = drDV["HINH_ANH"];
                    ds.Tables["DANGKY"].Rows.Add(newRow);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // MergeDataDangKy();

            this.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaVE.Text))
            {
                MessageBox.Show("Vui lòng chọn mã vé !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow dr = ds.Tables["DANGKY"].Rows.Find(new object[] { txtMaVE.Text, cboDV.SelectedValue.ToString() });

            if (dr == null)
            {
                MessageBox.Show("Dịch vụ đăng ký không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ đăng ký này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string sqlDelete = "DELETE  DANGKY WHERE MASP = @MASP AND MAVE = @MAVE";
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand(sqlDelete, con))
                        {
                            cmd.Parameters.Add("@MAVE", SqlDbType.NVarChar, 50).Value = txtMaVE.Text;
                            cmd.Parameters.Add("@MASP", SqlDbType.NVarChar, 50).Value = cboDV.SelectedValue.ToString();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Xóa dịch vụ đăng ký thành công!");

                    // Xóa khỏi DataSet
                    dr.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Refresh();
        }
    }
}
