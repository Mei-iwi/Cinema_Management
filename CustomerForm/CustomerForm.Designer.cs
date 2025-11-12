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
            ((System.ComponentModel.ISupportInitialize)dgvThongTinKhachHang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(463, -1);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(481, 41);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Thông Tin Khách Hàng";
            // 
            // txtMaKhachHang
            // 
            txtMaKhachHang.Location = new Point(227, 121);
            txtMaKhachHang.Name = "txtMaKhachHang";
            txtMaKhachHang.Size = new Size(201, 35);
            txtMaKhachHang.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 129);
            label2.Name = "label2";
            label2.Size = new Size(170, 27);
            label2.TabIndex = 2;
            label2.Text = "Mã Khách Hàng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(445, 129);
            label3.Name = "label3";
            label3.Size = new Size(106, 27);
            label3.TabIndex = 3;
            label3.Text = "Tên Hạng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(767, 134);
            label4.Name = "label4";
            label4.Size = new Size(175, 27);
            label4.TabIndex = 4;
            label4.Text = "Tên Khách Hàng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1108, 134);
            label5.Name = "label5";
            label5.Size = new Size(149, 27);
            label5.TabIndex = 5;
            label5.Text = "Số Điện Thoại";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(445, 212);
            label6.Name = "label6";
            label6.Size = new Size(86, 27);
            label6.TabIndex = 6;
            label6.Text = "Địa Chỉ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(767, 212);
            label7.Name = "label7";
            label7.Size = new Size(68, 27);
            label7.TabIndex = 7;
            label7.Text = "Email";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(46, 217);
            label8.Name = "label8";
            label8.Size = new Size(111, 27);
            label8.TabIndex = 8;
            label8.Text = "Ngày Sinh";
            // 
            // txtTen
            // 
            txtTen.Location = new Point(948, 129);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(150, 35);
            txtTen.TabIndex = 10;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(1263, 126);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(150, 35);
            txtSDT.TabIndex = 11;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(563, 209);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(182, 35);
            txtDiaChi.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(948, 204);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(150, 35);
            txtEmail.TabIndex = 13;
            // 
            // mstNgay
            // 
            mstNgay.Location = new Point(227, 209);
            mstNgay.Mask = "00/00/0000";
            mstNgay.Name = "mstNgay";
            mstNgay.Size = new Size(201, 35);
            mstNgay.TabIndex = 14;
            mstNgay.TypeValidationCompleted += mstNgay_TypeValidationCompleted;
            // 
            // dgvThongTinKhachHang
            // 
            dgvThongTinKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongTinKhachHang.Location = new Point(12, 362);
            dgvThongTinKhachHang.Name = "dgvThongTinKhachHang";
            dgvThongTinKhachHang.RowHeadersWidth = 62;
            dgvThongTinKhachHang.Size = new Size(1291, 284);
            dgvThongTinKhachHang.TabIndex = 15;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(30, 54);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 34);
            btnThem.TabIndex = 16;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // button2
            // 
            button2.Location = new Point(171, 54);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 17;
            button2.Text = "Xóa";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(316, 54);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 34);
            btnSua.TabIndex = 18;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(463, 54);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(112, 34);
            btnLoad.TabIndex = 19;
            btnLoad.Text = "Làm Mới";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(606, 54);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(112, 34);
            btnDong.TabIndex = 20;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(539, 315);
            label9.Name = "label9";
            label9.Size = new Size(296, 27);
            label9.TabIndex = 21;
            label9.Text = "Hiển thị thông tin khách hàng";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1119, 209);
            label10.Name = "label10";
            label10.Size = new Size(55, 27);
            label10.TabIndex = 22;
            label10.Text = "Phái";
            // 
            // cboPhai
            // 
            cboPhai.FormattingEnabled = true;
            cboPhai.Location = new Point(1263, 204);
            cboPhai.Name = "cboPhai";
            cboPhai.Size = new Size(150, 35);
            cboPhai.TabIndex = 23;
            // 
            // cboMaHang
            // 
            cboMaHang.FormattingEnabled = true;
            cboMaHang.Location = new Point(563, 121);
            cboMaHang.Name = "cboMaHang";
            cboMaHang.Size = new Size(182, 35);
            cboMaHang.TabIndex = 24;
            // 
            // txtTichDiem
            // 
            txtTichDiem.Location = new Point(227, 275);
            txtTichDiem.Name = "txtTichDiem";
            txtTichDiem.Size = new Size(201, 35);
            txtTichDiem.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(56, 283);
            label11.Name = "label11";
            label11.Size = new Size(108, 27);
            label11.TabIndex = 26;
            label11.Text = "Tích điểm";
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1436, 658);
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
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "CustomerForm";
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
    }
}
