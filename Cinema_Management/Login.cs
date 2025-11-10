using Common;
namespace Cinema_Management
{
    public partial class Login : Form
    {

        public static string DataSource = "34.133.93.201";

        public static string InitialCatalog = "QL_RAP_PHIM";

        public static string UserID = "";

        public static string Password = "";

        private static int position = 0;

        public Login()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';

        }


        private void Login_Load(object sender, EventArgs e)
        {

            this.Icon = Properties.Resources.IconLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string strcon = Common.ConnectionHelper.CreateConnectionString(DataSource, InitialCatalog, txtUsername.Text.Trim(), txtPassword.Text.Trim());

            bool checkUser = DataAccess.DataProvider.TestConnection(strcon);

            if (checkUser)
            {


                Authentication auth = new Authentication(username, password, strcon);

                if (auth.UserType == 0)
                {

                    Customer customer = auth.getCustomerInfomation(strcon, username);

                    position = 0; //Khách hàng
                    MessageBox.Show($"Xin chào khách hàng {customer.FullName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    Employee em = auth.getInfomation(strcon, username);
                    if (auth.UserType == 1)
                    {
                        position = 1; // Nhân viên bán vé
                        MessageBox.Show($"Xin chào {em.FullName} Chức vụ nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (auth.UserType == 2)
                    {
                        position = 2; // Nhân viên quản lý
                        MessageBox.Show($"Xin chào {em.FullName} Chức vụ quản lý.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Người dùng không có quyền truy cập hệ thống.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //this.Hide();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc Mật khẩu không đúng. Vui lòng thử lại.", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            ChangePassword change = new ChangePassword();

            change.Show();
        }
    }
}
