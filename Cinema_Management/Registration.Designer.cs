namespace Cinema_Management
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            picAvatar = new PictureBox();
            btnLoadImage = new Button();
            label1 = new Label();
            txtTen = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtDC = new TextBox();
            txtEmail = new TextBox();
            txtSDT = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            cboGT = new ComboBox();
            dateNS = new DateTimePicker();
            label2 = new Label();
            groupBox1 = new GroupBox();
            button2 = new Button();
            groupBox2 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnPassAgain = new Button();
            txtPassAgain = new TextBox();
            btnPass = new Button();
            txtPass = new TextBox();
            label8 = new Label();
            label9 = new Label();
            txtUser = new TextBox();
            label10 = new Label();
            button1 = new Button();
            linkLabel2 = new LinkLabel();
            txtImage = new TextBox();
            bindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // picAvatar
            // 
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Image = (Image)resources.GetObject("picAvatar.Image");
            picAvatar.Location = new Point(12, 67);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(223, 183);
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(68, 260);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(94, 29);
            btnLoadImage.TabIndex = 1;
            btnLoadImage.Text = "Tải ảnh lên";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 2;
            label1.Text = "Họ và tên";
            // 
            // txtTen
            // 
            txtTen.Location = new Point(109, 3);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(319, 27);
            txtTen.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(txtDC, 1, 5);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 4);
            tableLayoutPanel1.Controls.Add(txtSDT, 1, 3);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(txtTen, 1, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 3);
            tableLayoutPanel1.Controls.Add(label6, 0, 4);
            tableLayoutPanel1.Controls.Add(label7, 0, 5);
            tableLayoutPanel1.Controls.Add(cboGT, 1, 1);
            tableLayoutPanel1.Controls.Add(dateNS, 1, 2);
            tableLayoutPanel1.Location = new Point(15, 26);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(457, 300);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // txtDC
            // 
            txtDC.Location = new Point(109, 248);
            txtDC.Name = "txtDC";
            txtDC.Size = new Size(319, 27);
            txtDC.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(109, 199);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(319, 27);
            txtEmail.TabIndex = 11;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(109, 150);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(319, 27);
            txtSDT.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 98);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 3;
            label3.Text = "Ngày sinh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 49);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 4;
            label4.Text = "Giới tính";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 147);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 5;
            label5.Text = "Số điện thoại";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 196);
            label6.Name = "label6";
            label6.Size = new Size(47, 20);
            label6.TabIndex = 6;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 245);
            label7.Name = "label7";
            label7.Size = new Size(56, 20);
            label7.TabIndex = 7;
            label7.Text = "Địa chỉ";
            // 
            // cboGT
            // 
            cboGT.FormattingEnabled = true;
            cboGT.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGT.Location = new Point(109, 52);
            cboGT.Name = "cboGT";
            cboGT.Size = new Size(319, 28);
            cboGT.TabIndex = 13;
            // 
            // dateNS
            // 
            dateNS.CustomFormat = "dd/MM/yyyy";
            dateNS.Format = DateTimePickerFormat.Custom;
            dateNS.Location = new Point(109, 101);
            dateNS.Name = "dateNS";
            dateNS.Size = new Size(319, 27);
            dateNS.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(331, 9);
            label2.Name = "label2";
            label2.Size = new Size(341, 31);
            label2.TabIndex = 3;
            label2.Text = "Đăng ký tài khoản người dùng";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Controls.Add(button2);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(254, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(488, 388);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin cá nhân";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(161, 332);
            button2.Name = "button2";
            button2.Size = new Size(159, 44);
            button2.TabIndex = 18;
            button2.Text = "Xác nhận thông tin";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel2);
            groupBox2.Controls.Add(button1);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(254, 441);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(488, 247);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin tài khoản";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(btnPassAgain, 2, 2);
            tableLayoutPanel2.Controls.Add(txtPassAgain, 1, 2);
            tableLayoutPanel2.Controls.Add(btnPass, 2, 1);
            tableLayoutPanel2.Controls.Add(txtPass, 1, 1);
            tableLayoutPanel2.Controls.Add(label8, 0, 0);
            tableLayoutPanel2.Controls.Add(label9, 0, 2);
            tableLayoutPanel2.Controls.Add(txtUser, 1, 0);
            tableLayoutPanel2.Controls.Add(label10, 0, 1);
            tableLayoutPanel2.Location = new Point(15, 26);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(425, 148);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // btnPassAgain
            // 
            btnPassAgain.Location = new Point(386, 101);
            btnPassAgain.Name = "btnPassAgain";
            btnPassAgain.Size = new Size(36, 29);
            btnPassAgain.TabIndex = 8;
            btnPassAgain.UseVisualStyleBackColor = true;
            btnPassAgain.Click += btnPassAgain_Click;
            // 
            // txtPassAgain
            // 
            txtPassAgain.Location = new Point(146, 101);
            txtPassAgain.Name = "txtPassAgain";
            txtPassAgain.Size = new Size(234, 27);
            txtPassAgain.TabIndex = 6;
            // 
            // btnPass
            // 
            btnPass.Location = new Point(386, 52);
            btnPass.Name = "btnPass";
            btnPass.Size = new Size(36, 29);
            btnPass.TabIndex = 7;
            btnPass.UseVisualStyleBackColor = true;
            btnPass.Click += btnPass_Click;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(146, 52);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(234, 27);
            txtPass.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(83, 20);
            label8.TabIndex = 2;
            label8.Text = "UserName";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 98);
            label9.Name = "label9";
            label9.Size = new Size(137, 20);
            label9.TabIndex = 3;
            label9.Text = "Nhập lại mật khẩu";
            // 
            // txtUser
            // 
            txtUser.Enabled = false;
            txtUser.Location = new Point(146, 3);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(234, 27);
            txtUser.TabIndex = 3;
            txtUser.TextChanged += txtUser_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 49);
            label10.Name = "label10";
            label10.Size = new Size(75, 20);
            label10.TabIndex = 4;
            label10.Text = "Mật khẩu";
            // 
            // button1
            // 
            button1.Location = new Point(145, 180);
            button1.Name = "button1";
            button1.Size = new Size(169, 61);
            button1.TabIndex = 19;
            button1.Text = "Đăng ký";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(12, 556);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(177, 20);
            linkLabel2.TabIndex = 16;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Quay lại trang đăng nhập";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // txtImage
            // 
            txtImage.Location = new Point(52, 148);
            txtImage.Name = "txtImage";
            txtImage.Size = new Size(154, 27);
            txtImage.TabIndex = 9;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 700);
            Controls.Add(picAvatar);
            Controls.Add(txtImage);
            Controls.Add(linkLabel2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(btnLoadImage);
            Name = "Registration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picAvatar;
        private Button btnLoadImage;
        private Label label1;
        private TextBox txtTen;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtDC;
        private TextBox txtEmail;
        private TextBox txtSDT;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox cboGT;
        private DateTimePicker dateNS;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label8;
        private Label label9;
        private TextBox txtUser;
        private Label label10;
        private TextBox txtPassAgain;
        private TextBox txtPass;
        private Button btnPass;
        private Button btnPassAgain;
        private LinkLabel linkLabel2;
        private TextBox txtImage;
        private Button button2;
        private Button button1;
        private BindingSource bindingSource1;
    }
}