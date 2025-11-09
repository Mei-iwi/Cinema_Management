using System;
using System.Windows.Forms;
using System.Data;

namespace QL_RAP_PHIM
{
    public partial class CustomerServiceForm : Form
    {
        private DataTable dtServices;
        private int currentCustomerId = 1;

        public CustomerServiceForm()
        {
            InitializeComponent();
            this.Load += CustomerServiceForm_Load;
        }

        private void CustomerServiceForm_Load(object sender, EventArgs e)
        {
            LoadAvailableServices();
        }

        private void LoadAvailableServices()
        {
             
            lstServices.Items.Add("Gói Bắp Nước Ưu Đãi");
            lstServices.Items.Add("Ưu đãi Sinh nhật");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (lstServices.SelectedItem != null)
            {
                 
                MessageBox.Show($"Đăng ký dịch vụ: {lstServices.SelectedItem.ToString()} thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ để đăng ký.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}