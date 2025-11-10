namespace Cinema_Management
{
    partial class ChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnXacThuc = new Button();
            txtMail = new TextBox();
            txtUsername = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            lblTitle = new Label();
            txtXacThuc = new TextBox();
            label1 = new Label();
            btnCancel = new Button();
            button1 = new Button();
            grpXacThuc = new GroupBox();
            lblTime = new Label();
            timer = new System.Windows.Forms.Timer(components);
            errorProvider = new ErrorProvider(components);
            grpXacThuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // btnXacThuc
            // 
            btnXacThuc.Location = new Point(155, 200);
            btnXacThuc.Name = "btnXacThuc";
            btnXacThuc.Size = new Size(148, 56);
            btnXacThuc.TabIndex = 16;
            btnXacThuc.Text = "Gửi mail yêu cầu đổi mật khẩu";
            btnXacThuc.UseVisualStyleBackColor = true;
            btnXacThuc.Click += btnXacThuc_Click;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(155, 144);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(278, 27);
            txtMail.TabIndex = 17;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(155, 94);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(278, 27);
            txtUsername.TabIndex = 18;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(25, 147);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(102, 20);
            lblPassword.TabIndex = 19;
            lblPassword.Text = "Email đăng ký";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(25, 97);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(110, 20);
            lblUsername.TabIndex = 20;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(78, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(296, 37);
            lblTitle.TabIndex = 21;
            lblTitle.Text = "THAY ĐỔI MẬT KHẨU";
            // 
            // txtXacThuc
            // 
            txtXacThuc.Location = new Point(143, 45);
            txtXacThuc.Name = "txtXacThuc";
            txtXacThuc.Size = new Size(159, 27);
            txtXacThuc.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 48);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 23;
            label1.Text = "Mã xác thực";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(323, 204);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 52);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Thoát";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(317, 40);
            button1.Name = "button1";
            button1.Size = new Size(76, 36);
            button1.TabIndex = 24;
            button1.Text = "Gửi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // grpXacThuc
            // 
            grpXacThuc.Controls.Add(lblTime);
            grpXacThuc.Controls.Add(button1);
            grpXacThuc.Controls.Add(label1);
            grpXacThuc.Controls.Add(txtXacThuc);
            grpXacThuc.Location = new Point(10, 279);
            grpXacThuc.Name = "grpXacThuc";
            grpXacThuc.Size = new Size(423, 134);
            grpXacThuc.TabIndex = 25;
            grpXacThuc.TabStop = false;
            grpXacThuc.Text = "Xác thực";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.ForeColor = Color.Red;
            lblTime.Location = new Point(145, 90);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(42, 20);
            lblTime.TabIndex = 26;
            lblTime.Text = "Time";
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 447);
            Controls.Add(grpXacThuc);
            Controls.Add(btnCancel);
            Controls.Add(btnXacThuc);
            Controls.Add(txtMail);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            Name = "ChangePassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangePassword";
            Load += ChangePassword_Load;
            grpXacThuc.ResumeLayout(false);
            grpXacThuc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnXacThuc;
        private TextBox txtMail;
        private TextBox txtUsername;
        private Label lblPassword;
        private Label lblUsername;
        private Label lblTitle;
        private TextBox txtXacThuc;
        private Label label1;
        private Button btnCancel;
        private Button button1;
        private GroupBox grpXacThuc;
        private Label lblTime;
        private System.Windows.Forms.Timer timer;
        private ErrorProvider errorProvider;
    }
}