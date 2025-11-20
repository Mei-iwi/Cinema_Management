namespace MovieForm
{
    partial class MovieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieForm));
            label1 = new Label();
            txtMa = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTenPhim = new TextBox();
            label5 = new Label();
            txtNhaSanXuat = new TextBox();
            label6 = new Label();
            cboTheLoai = new ComboBox();
            cboDangPhim = new ComboBox();
            mstNgayKhoiChieu = new MaskedTextBox();
            mstThoiLuong = new MaskedTextBox();
            label7 = new Label();
            label8 = new Label();
            mstNgayKetThuc = new MaskedTextBox();
            label9 = new Label();
            label10 = new Label();
            mstCapNhat = new MaskedTextBox();
            dgvPhim = new DataGridView();
            label11 = new Label();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLamMoi = new Button();
            btnDong = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPhim).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(605, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(225, 41);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Phim";
            // 
            // txtMa
            // 
            txtMa.Location = new Point(173, 160);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(161, 35);
            txtMa.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 163);
            label2.Name = "label2";
            label2.Size = new Size(107, 26);
            label2.TabIndex = 2;
            label2.Text = "Mã Phim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(367, 163);
            label3.Name = "label3";
            label3.Size = new Size(104, 26);
            label3.TabIndex = 3;
            label3.Text = "Thể Loại";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(801, 163);
            label4.Name = "label4";
            label4.Size = new Size(126, 26);
            label4.TabIndex = 4;
            label4.Text = "Dạng Phim";
            // 
            // txtTenPhim
            // 
            txtTenPhim.Location = new Point(1343, 149);
            txtTenPhim.Name = "txtTenPhim";
            txtTenPhim.Size = new Size(161, 35);
            txtTenPhim.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1172, 158);
            label5.Name = "label5";
            label5.Size = new Size(111, 26);
            label5.TabIndex = 6;
            label5.Text = "Tên Phim";
            // 
            // txtNhaSanXuat
            // 
            txtNhaSanXuat.Location = new Point(173, 223);
            txtNhaSanXuat.Name = "txtNhaSanXuat";
            txtNhaSanXuat.Size = new Size(161, 35);
            txtNhaSanXuat.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 221);
            label6.Name = "label6";
            label6.Size = new Size(153, 26);
            label6.TabIndex = 8;
            label6.Text = "Nhà Sản Xuất";
            // 
            // cboTheLoai
            // 
            cboTheLoai.FormattingEnabled = true;
            cboTheLoai.Location = new Point(586, 156);
            cboTheLoai.Name = "cboTheLoai";
            cboTheLoai.Size = new Size(196, 34);
            cboTheLoai.TabIndex = 11;
            // 
            // cboDangPhim
            // 
            cboDangPhim.FormattingEnabled = true;
            cboDangPhim.Location = new Point(970, 156);
            cboDangPhim.Name = "cboDangPhim";
            cboDangPhim.Size = new Size(196, 34);
            cboDangPhim.TabIndex = 12;
            // 
            // mstNgayKhoiChieu
            // 
            mstNgayKhoiChieu.Location = new Point(586, 221);
            mstNgayKhoiChieu.Mask = "00/00/0000";
            mstNgayKhoiChieu.Name = "mstNgayKhoiChieu";
            mstNgayKhoiChieu.Size = new Size(196, 35);
            mstNgayKhoiChieu.TabIndex = 13;
            // 
            // mstThoiLuong
            // 
            mstThoiLuong.Location = new Point(1343, 221);
            mstThoiLuong.Mask = "00:00:00";
            mstThoiLuong.Name = "mstThoiLuong";
            mstThoiLuong.Size = new Size(161, 35);
            mstThoiLuong.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(367, 230);
            label7.Name = "label7";
            label7.Size = new Size(184, 26);
            label7.TabIndex = 16;
            label7.Text = "Ngày Khởi chiếu";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(801, 226);
            label8.Name = "label8";
            label8.Size = new Size(154, 26);
            label8.TabIndex = 17;
            label8.Text = "Ngày kết thúc";
            // 
            // mstNgayKetThuc
            // 
            mstNgayKetThuc.Location = new Point(970, 219);
            mstNgayKetThuc.Mask = "00/00/0000";
            mstNgayKetThuc.Name = "mstNgayKetThuc";
            mstNgayKetThuc.Size = new Size(196, 35);
            mstNgayKetThuc.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1172, 226);
            label9.Name = "label9";
            label9.Size = new Size(125, 26);
            label9.TabIndex = 19;
            label9.Text = "Thời lượng";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(4, 280);
            label10.Name = "label10";
            label10.Size = new Size(159, 26);
            label10.TabIndex = 20;
            label10.Text = "Ngày câp nhật";
            // 
            // mstCapNhat
            // 
            mstCapNhat.Location = new Point(173, 273);
            mstCapNhat.Mask = "00/00/0000";
            mstCapNhat.Name = "mstCapNhat";
            mstCapNhat.Size = new Size(161, 35);
            mstCapNhat.TabIndex = 21;
            // 
            // dgvPhim
            // 
            dgvPhim.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhim.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhim.Location = new Point(79, 361);
            dgvPhim.Name = "dgvPhim";
            dgvPhim.RowHeadersWidth = 62;
            dgvPhim.Size = new Size(1402, 584);
            dgvPhim.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.MenuHighlight;
            label11.Location = new Point(536, 307);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(345, 41);
            label11.TabIndex = 23;
            label11.Text = "Hiển thị thông tin phim";
            // 
            // btnThem
            // 
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Location = new Point(13, 68);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(121, 33);
            btnThem.TabIndex = 24;
            btnThem.Text = "&Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Location = new Point(140, 68);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(121, 33);
            btnXoa.TabIndex = 25;
            btnXoa.Text = "&Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Location = new Point(267, 68);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(121, 33);
            btnSua.TabIndex = 26;
            btnSua.Text = "&Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Location = new Point(394, 68);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(121, 33);
            btnLamMoi.TabIndex = 27;
            btnLamMoi.Text = "&Làm Mới ";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnDong
            // 
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Location = new Point(521, 68);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(121, 33);
            btnDong.TabIndex = 28;
            btnDong.Text = "&Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // MovieForm
            // 
            AutoScaleDimensions = new SizeF(14F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1559, 966);
            Controls.Add(btnDong);
            Controls.Add(btnLamMoi);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(label11);
            Controls.Add(dgvPhim);
            Controls.Add(mstCapNhat);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(mstNgayKetThuc);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(mstThoiLuong);
            Controls.Add(mstNgayKhoiChieu);
            Controls.Add(cboDangPhim);
            Controls.Add(cboTheLoai);
            Controls.Add(label6);
            Controls.Add(txtNhaSanXuat);
            Controls.Add(label5);
            Controls.Add(txtTenPhim);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMa);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "MovieForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Phim";
            FormClosing += MovieForm_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPhim).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMa;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTenPhim;
        private Label label5;
        private TextBox txtNhaSanXuat;
        private Label label6;
        private ComboBox cboTheLoai;
        private ComboBox cboDangPhim;
        private MaskedTextBox mstNgayKhoiChieu;
        private MaskedTextBox mstThoiLuong;
        private Label label7;
        private Label label8;
        private MaskedTextBox mstNgayKetThuc;
        private Label label9;
        private Label label10;
        private MaskedTextBox mstCapNhat;
        private DataGridView dgvPhim;
        private Label label11;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLamMoi;
        private Button btnDong;
    }
}
