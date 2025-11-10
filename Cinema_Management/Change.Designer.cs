namespace Cinema_Management
{
    partial class Change
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
            lblTitle = new Label();
            btnCancel = new Button();
            btnUpdate = new Button();
            txtNewPassAgain = new TextBox();
            txtNewPass = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(112, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(311, 37);
            lblTitle.TabIndex = 22;
            lblTitle.Text = "NHẬP MẬT KHẨU MỚI";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(369, 224);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 52);
            btnCancel.TabIndex = 23;
            btnCancel.Text = "Thoát";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(201, 220);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(148, 56);
            btnUpdate.TabIndex = 24;
            btnUpdate.Text = "Cập nhật mật khẩu";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtNewPassAgain
            // 
            txtNewPassAgain.Location = new Point(201, 164);
            txtNewPassAgain.Name = "txtNewPassAgain";
            txtNewPassAgain.Size = new Size(278, 27);
            txtNewPassAgain.TabIndex = 25;
            // 
            // txtNewPass
            // 
            txtNewPass.Location = new Point(201, 114);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(278, 27);
            txtNewPass.TabIndex = 26;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(40, 167);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(130, 20);
            lblPassword.TabIndex = 27;
            lblPassword.Text = "Nhập lại mật khẩu";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(40, 114);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(140, 20);
            lblUsername.TabIndex = 28;
            lblUsername.Text = "Nhập mật khẩu mới";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // Change
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 307);
            Controls.Add(btnCancel);
            Controls.Add(btnUpdate);
            Controls.Add(txtNewPassAgain);
            Controls.Add(txtNewPass);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            Name = "Change";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhập mật khẩu mới";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnCancel;
        private Button btnUpdate;
        private TextBox txtNewPassAgain;
        private TextBox txtNewPass;
        private Label lblPassword;
        private Label lblUsername;
        private ErrorProvider errorProvider;
    }
}