namespace CustomerForm
{
    partial class CustomerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            label1 = new Label();
            txtMaKhachHang = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtTen = new TextBox();
            txtSDT = new TextBox();
            txtDiaChi = new TextBox();
            txtEmail = new TextBox();
            mstNgay = new MaskedTextBox();
            dgvThongTinKhachHang = new DataGridView();
            btnThem = new Button();
            button2 = new Button();
            btnSua = new Button();
            btnLoad = new Button();
            btnDong = new Button();
            label9 = new Label();
            label10 = new Label();
            cboPhai = new ComboBox();
            cboMaHang = new ComboBox();
            txtTichDiem = new TextBox();
            label11 = new Label();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvThongTinKhachHang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(494, 8);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(481, 41);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Thông Tin Khách Hàng";
            // 
            // txtMaKhachHang
            // 
            txtMaKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaKhachHang.Location = new Point(244, 117);
            txtMaKhachHang.Name = "txtMaKhachHang";
            txtMaKhachHang.Size = new Size(216, 35);
            txtMaKhachHang.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 129);
            label2.Name = "label2";
            label2.Size = new Size(183, 26);
            label2.TabIndex = 2;
            label2.Text = "Mã Khách Hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(479, 124);
            label3.Name = "label3";
            label3.Size = new Size(113, 26);
            label3.TabIndex = 3;
            label3.Text = "Tên Hạng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(826, 129);
            label4.Name = "label4";
            label4.Size = new Size(187, 26);
            label4.TabIndex = 4;
            label4.Text = "Tên Khách Hàng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1193, 129);
            label5.Name = "label5";
            label5.Size = new Size(156, 26);
            label5.TabIndex = 5;
            label5.Text = "Số Điện Thoại";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(479, 204);
            label6.Name = "label6";
            label6.Size = new Size(91, 26);
            label6.TabIndex = 6;
            label6.Text = "Địa Chỉ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(826, 204);
            label7.Name = "label7";
            label7.Size = new Size(73, 26);
            label7.TabIndex = 7;
            label7.Text = "Email";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 210);
            label8.Name = "label8";
            label8.Size = new Size(117, 26);
            label8.TabIndex = 8;
            label8.Text = "Ngày Sinh";
            // 
            // txtTen
            // 
            txtTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTen.Location = new Point(1021, 115);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(161, 35);
            txtTen.TabIndex = 10;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(1360, 120);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(161, 35);
            txtSDT.TabIndex = 11;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDiaChi.Location = new Point(606, 198);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(196, 35);
            txtDiaChi.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Location = new Point(1021, 196);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(161, 35);
            txtEmail.TabIndex = 13;
            // 
            // mstNgay
            // 
            mstNgay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mstNgay.Location = new Point(244, 201);
            mstNgay.Mask = "00/00/0000";
            mstNgay.Name = "mstNgay";
            mstNgay.Size = new Size(216, 35);
            mstNgay.TabIndex = 14;
            // 
            // dgvThongTinKhachHang
            // 
            dgvThongTinKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvThongTinKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongTinKhachHang.Location = new Point(71, 349);
            dgvThongTinKhachHang.Name = "dgvThongTinKhachHang";
            dgvThongTinKhachHang.RowHeadersWidth = 62;
            dgvThongTinKhachHang.Size = new Size(1390, 273);
            dgvThongTinKhachHang.TabIndex = 15;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Location = new Point(3, 52);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(121, 33);
            btnThem.TabIndex = 16;
            btnThem.Text = "&Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(130, 52);
            button2.Name = "button2";
            button2.Size = new Size(121, 33);
            button2.TabIndex = 17;
            button2.Text = "&Xóa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Location = new Point(257, 52);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(121, 33);
            btnSua.TabIndex = 18;
            btnSua.Text = "&Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLoad
            // 
            btnLoad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Location = new Point(512, 52);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(121, 33);
            btnLoad.TabIndex = 19;
            btnLoad.Text = "&Làm Mới";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Location = new Point(639, 52);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(121, 33);
            btnDong.TabIndex = 20;
            btnDong.Text = "&Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(580, 303);
            label9.Name = "label9";
            label9.Size = new Size(318, 26);
            label9.TabIndex = 21;
            label9.Text = "Hiển thị thông tin khách hàng";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1193, 201);
            label10.Name = "label10";
            label10.Size = new Size(59, 26);
            label10.TabIndex = 22;
            label10.Text = "Phái";
            // 
            // cboPhai
            // 
            cboPhai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboPhai.FormattingEnabled = true;
            cboPhai.Location = new Point(1360, 196);
            cboPhai.Name = "cboPhai";
            cboPhai.Size = new Size(161, 34);
            cboPhai.TabIndex = 23;
            // 
            // cboMaHang
            // 
            cboMaHang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboMaHang.FormattingEnabled = true;
            cboMaHang.Location = new Point(606, 116);
            cboMaHang.Name = "cboMaHang";
            cboMaHang.Size = new Size(196, 34);
            cboMaHang.TabIndex = 24;
            // 
            // txtTichDiem
            // 
            txtTichDiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTichDiem.Location = new Point(244, 265);
            txtTichDiem.Name = "txtTichDiem";
            txtTichDiem.Size = new Size(216, 35);
            txtTichDiem.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(28, 274);
            label11.Name = "label11";
            label11.Size = new Size(114, 26);
            label11.TabIndex = 26;
            label11.Text = "Tích điểm";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(385, 52);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(121, 33);
            btnSave.TabIndex = 27;
            btnSave.Text = "&Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(14F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1546, 634);
            Controls.Add(btnSave);
            Controls.Add(label11);
            Controls.Add(txtTichDiem);
            Controls.Add(cboMaHang);
            Controls.Add(cboPhai);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(btnDong);
            Controls.Add(btnLoad);
            Controls.Add(btnSua);
            Controls.Add(button2);
            Controls.Add(btnThem);
            Controls.Add(dgvThongTinKhachHang);
            Controls.Add(mstNgay);
            Controls.Add(txtEmail);
            Controls.Add(txtDiaChi);
            Controls.Add(txtSDT);
            Controls.Add(txtTen);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMaKhachHang);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormQuanLyKhachHang";
            TopMost = true;
            FormClosing += CustomerForm_FormClosing;
            Load += CustomerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvThongTinKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMaKhachHang;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtTen;
        private TextBox txtSDT;
        private TextBox txtDiaChi;
        private TextBox txtEmail;
        private MaskedTextBox mstNgay;
        private DataGridView dgvThongTinKhachHang;
        private Button btnThem;
        private Button button2;
        private Button btnSua;
        private Button btnLoad;
        private Button btnDong;
        private Label label9;
        private Label label10;
        private ComboBox cboPhai;
        private ComboBox cboMaHang;
        private TextBox txtTichDiem;
        private Label label11;
        private Button btnSave;
    }
}
