namespace FormSupportCustomer
{
    partial class FormSupportCustomer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtEmail = new TextBox();
            txtSDT = new TextBox();
            txtTenKH = new TextBox();
            txtMaKH = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            groupBox2 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label6 = new Label();
            cboLoaiPH = new ComboBox();
            groupBox3 = new GroupBox();
            rchNoiDung = new RichTextBox();
            groupBox4 = new GroupBox();
            btnDong = new Button();
            btnXoa = new Button();
            btnGui = new Button();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 38);
            label1.TabIndex = 1;
            label1.Text = "Ý KIẾN KHÁCH HÀNG";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            groupBox1.Location = new Point(0, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 147);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin khách hàng";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(txtEmail, 3, 1);
            tableLayoutPanel1.Controls.Add(txtSDT, 1, 1);
            tableLayoutPanel1.Controls.Add(txtTenKH, 3, 0);
            tableLayoutPanel1.Controls.Add(txtMaKH, 1, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 2, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 2, 1);
            tableLayoutPanel1.Location = new Point(12, 36);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(776, 92);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(543, 49);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(230, 30);
            txtEmail.TabIndex = 6;
            // 
            // txtSDT
            // 
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Location = new Point(141, 49);
            txtSDT.Name = "txtSDT";
            txtSDT.ReadOnly = true;
            txtSDT.Size = new Size(229, 30);
            txtSDT.TabIndex = 5;
            // 
            // txtTenKH
            // 
            txtTenKH.BorderStyle = BorderStyle.FixedSingle;
            txtTenKH.Location = new Point(543, 3);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.ReadOnly = true;
            txtTenKH.Size = new Size(230, 30);
            txtTenKH.TabIndex = 4;
            // 
            // txtMaKH
            // 
            txtMaKH.BorderStyle = BorderStyle.FixedSingle;
            txtMaKH.Location = new Point(141, 3);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.ReadOnly = true;
            txtMaKH.Size = new Size(229, 30);
            txtMaKH.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(132, 23);
            label3.TabIndex = 1;
            label3.Text = "Mã khách hàng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(376, 0);
            label2.Name = "label2";
            label2.Size = new Size(161, 23);
            label2.TabIndex = 0;
            label2.Text = "Họ tên khách hàng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 46);
            label4.Name = "label4";
            label4.Size = new Size(116, 23);
            label4.TabIndex = 2;
            label4.Text = "Số điện thoại";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(376, 46);
            label5.Name = "label5";
            label5.Size = new Size(54, 23);
            label5.TabIndex = 3;
            label5.Text = "Email";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel2);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            groupBox2.Location = new Point(38, 194);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(700, 84);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Loại phản hồi";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(label6, 0, 0);
            tableLayoutPanel2.Controls.Add(cboLoaiPH, 1, 0);
            tableLayoutPanel2.Location = new Point(81, 26);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(544, 41);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(118, 23);
            label6.TabIndex = 1;
            label6.Text = "Loại phản hồi";
            // 
            // cboLoaiPH
            // 
            cboLoaiPH.FormattingEnabled = true;
            cboLoaiPH.Location = new Point(127, 3);
            cboLoaiPH.Name = "cboLoaiPH";
            cboLoaiPH.Size = new Size(414, 31);
            cboLoaiPH.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rchNoiDung);
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            groupBox3.Location = new Point(38, 284);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(700, 192);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Nội dung";
            // 
            // rchNoiDung
            // 
            rchNoiDung.Location = new Point(18, 29);
            rchNoiDung.Name = "rchNoiDung";
            rchNoiDung.Size = new Size(667, 157);
            rchNoiDung.TabIndex = 0;
            rchNoiDung.Text = "";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnDong);
            groupBox4.Controls.Add(btnXoa);
            groupBox4.Controls.Add(btnGui);
            groupBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            groupBox4.Location = new Point(38, 482);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(700, 84);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Chức năng";
            // 
            // btnDong
            // 
            btnDong.Location = new Point(465, 29);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(140, 47);
            btnDong.TabIndex = 2;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(273, 29);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(140, 47);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "Xóa thông tin";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnGui
            // 
            btnGui.Location = new Point(81, 29);
            btnGui.Name = "btnGui";
            btnGui.Size = new Size(140, 47);
            btnGui.TabIndex = 0;
            btnGui.Text = "Gửi ý kiến";
            btnGui.UseVisualStyleBackColor = true;
            btnGui.Click += btnGui_Click;
            // 
            // FormSupportCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 594);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "FormSupportCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormSupportCustomer";
            Load += FormSupportCustomer_Load;
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label5;
        private TextBox txtEmail;
        private TextBox txtSDT;
        private TextBox txtTenKH;
        private TextBox txtMaKH;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label6;
        private ComboBox cboLoaiPH;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private RichTextBox rchNoiDung;
        private Button btnDong;
        private Button btnXoa;
        private Button btnGui;
    }
}
