using Common;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ServiceRegistrationForm
{
    public partial class ServiceRegistrationForm : Form
    {

        string connectionString = ConnectionHelper.CreateConnectionString(GlobalData.DataSource, GlobalData.InitialCatalog, "NV00000008", "Abc12345!");

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

            string sqlRes = "SELECT DK.MASP, MAVE, SOLUONG, DONGIA  FROM DANGKY DK INNER JOIN DICHVU DV ON DV.MASP = DK.MASP";

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

            //dataView = new DataView(ds.Tables["DANGKY"]);

            //dataView.RowFilter = string.Format("MaVE LIKE '%{0}%'", txtMaVE.Text);

        }

        void EnableTextBox(bool enable = false)
        {
            foreach (TextBox txt in grpChucnag.Controls.OfType<TextBox>())
            {
                txt.Enabled = enable;
            }
            cboDV.Enabled = enable;
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
        }


        void load_dgv()
        {

            dataView = new DataView(ds.Tables["DANGKY"]);
            bsView.DataSource = dataView;
            dgv_Service.DataSource = bsView;


            dgv_Service.Columns["MaVE"].HeaderText = "Mã vé";

            dgv_Service.Columns["MaSP"].HeaderText = "Mã dịch vụ";

            dgv_Service.Columns["SOLUONG"].HeaderText = "Số lượng";

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

            txtTongTien.Text = (numSL.Value * Convert.ToDecimal(txtDonGia.Text)).ToString("N0") + " VNĐ";

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

            txtMaVE.DataBindings.Add("Text", bs, "MaVE", true, DataSourceUpdateMode.OnPropertyChanged);
            cboDV.DataBindings.Add("SelectedValue", bs, "MaSP", true, DataSourceUpdateMode.OnPropertyChanged);
            numSL.DataBindings.Add("Value", bs, "SOLUONG", true, DataSourceUpdateMode.OnPropertyChanged, 0);
            txtDonGia.DataBindings.Add("Text", bs, "DONGIA", true, DataSourceUpdateMode.OnPropertyChanged);
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
    }
}
