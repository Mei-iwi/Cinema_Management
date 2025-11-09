using System;
using System.Windows.Forms;
using System.Data;

namespace QL_RAP_PHIM
{
    public partial class CustomerProfileForm : Form
    {
        private int currentCustomerId = 1; 

        public CustomerProfileForm()
        {
            InitializeComponent();
            this.Load += CustomerProfileForm_Load;
        }

        private void CustomerProfileForm_Load(object sender, EventArgs e)
        {
            LoadProfileData(currentCustomerId);
        }

        private void LoadProfileData(int customerId)
        {
            
            txtName.Text = "Nguyễn Văn A";
            txtPhone.Text = "090xxxxxxx";
            txtEmail.Text = "a.nguyen@email.com";
            lblRank.Text = "Vàng";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             
            MessageBox.Show("Cập nhật hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}