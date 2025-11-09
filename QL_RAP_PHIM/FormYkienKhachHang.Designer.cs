namespace QL_RAP_PHIM
{
    partial class FormYkienKhachHang
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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.txtFeedback = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.lblTitle.Text = "FORM Ý KIẾN KHÁCH HÀNG";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.AutoSize = true;

            this.lblInstructions.Text = "Vui lòng nhập phản hồi, góp ý của bạn về dịch vụ của chúng tôi:";
            this.lblInstructions.Location = new System.Drawing.Point(50, 70);
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Name = "lblInstructions";

            this.txtFeedback.Multiline = true;
            this.txtFeedback.Location = new System.Drawing.Point(50, 95);
            this.txtFeedback.Size = new System.Drawing.Size(500, 200);
            this.txtFeedback.Name = "txtFeedback";

            this.btnSubmit.Text = "Gửi ý kiến";
            this.btnSubmit.Location = new System.Drawing.Point(400, 310);
            this.btnSubmit.Size = new System.Drawing.Size(150, 40);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 380);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.txtFeedback);
            this.Controls.Add(this.btnSubmit);
            this.Name = "FormYkienKhachHang";
            this.Text = "Ý kiến khách hàng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.TextBox txtFeedback;
        private System.Windows.Forms.Button btnSubmit;
    }
}