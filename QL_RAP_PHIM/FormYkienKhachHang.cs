using System;
using System.Windows.Forms;

namespace QL_RAP_PHIM
{
    public partial class FormYkienKhachHang : Form
    {
        public FormYkienKhachHang()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string feedback = txtFeedback.Text.Trim();
            if (string.IsNullOrEmpty(feedback))
            {
                MessageBox.Show("Vui lòng nhập ý kiến của bạn trước khi gửi.", "Cảnh báo");
                return;
            }

            if (FeedbackDAL.SaveFeedback(feedback))
            {
                MessageBox.Show("Cảm ơn bạn đã đóng góp ý kiến! Phản hồi của bạn đã được ghi nhận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}