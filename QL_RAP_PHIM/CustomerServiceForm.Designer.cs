namespace QL_RAP_PHIM
{
    partial class CustomerServiceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lstServices = new System.Windows.Forms.ListBox();
            this.btnRegister = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.lblTitle.Text = "ĐĂNG KÝ DỊCH VỤ & ƯU ĐÃI";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.AutoSize = true;

            this.lstServices.FormattingEnabled = true;
            this.lstServices.Location = new System.Drawing.Point(50, 80);
            this.lstServices.Size = new System.Drawing.Size(400, 200);
            this.lstServices.Name = "lstServices";

            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.Location = new System.Drawing.Point(470, 80);
            this.btnRegister.Size = new System.Drawing.Size(120, 40);
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 350);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstServices);
            this.Controls.Add(this.btnRegister);
            this.Name = "CustomerServiceForm";
            this.Text = "Đăng ký Dịch vụ Khách hàng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstServices;
        private System.Windows.Forms.Button btnRegister;
    }
}