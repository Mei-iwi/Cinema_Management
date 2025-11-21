namespace ShowtimeForm
{
    partial class ShowtimeForm
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
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            btnDong = new Button();
            dgvShowTime = new DataGridView();
            txtMaSuat = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cboPhim = new ComboBox();
            label4 = new Label();
            cboPhong = new ComboBox();
            mskGioBatDau = new MaskedTextBox();
            label5 = new Label();
            mskGioKetThuc = new MaskedTextBox();
            label6 = new Label();
            mskNgayChieu = new MaskedTextBox();
            label7 = new Label();
            txtSoLuong = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvShowTime).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(630, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(329, 41);
            label1.TabIndex = 0;
            label1.Text = "Quản Lý Suất Chiếu";
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnThem.Location = new Point(1, 69);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(112, 34);
            btnThem.TabIndex = 1;
            btnThem.Text = "&Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnXoa.Location = new Point(119, 69);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(112, 34);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "&Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSua.Location = new Point(237, 69);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(112, 34);
            btnSua.TabIndex = 3;
            btnSua.Text = "&Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLuu.Location = new Point(355, 69);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(112, 34);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "&Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDong.Location = new Point(473, 69);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(112, 34);
            btnDong.TabIndex = 5;
            btnDong.Text = "&Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // dgvShowTime
            // 
            dgvShowTime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvShowTime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvShowTime.Location = new Point(141, 313);
            dgvShowTime.Name = "dgvShowTime";
            dgvShowTime.RowHeadersWidth = 62;
            dgvShowTime.Size = new Size(1113, 260);
            dgvShowTime.TabIndex = 6;
            // 
            // txtMaSuat
            // 
            txtMaSuat.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaSuat.Location = new Point(190, 132);
            txtMaSuat.Name = "txtMaSuat";
            txtMaSuat.Size = new Size(188, 35);
            txtMaSuat.TabIndex = 7;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(12, 141);
            label2.Name = "label2";
            label2.Size = new Size(156, 26);
            label2.TabIndex = 8;
            label2.Text = "Mã suất chiếu";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(401, 141);
            label3.Name = "label3";
            label3.Size = new Size(66, 26);
            label3.TabIndex = 9;
            label3.Text = "Phim";
            // 
            // cboPhim
            // 
            cboPhim.FormattingEnabled = true;
            cboPhim.Location = new Point(534, 132);
            cboPhim.Name = "cboPhim";
            cboPhim.Size = new Size(208, 34);
            cboPhim.TabIndex = 10;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(769, 141);
            label4.Name = "label4";
            label4.Size = new Size(138, 26);
            label4.TabIndex = 11;
            label4.Text = "Phòng chiếu";
            // 
            // cboPhong
            // 
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(922, 133);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(182, 34);
            cboPhong.TabIndex = 12;
            // 
            // mskGioBatDau
            // 
            mskGioBatDau.Location = new Point(1260, 131);
            mskGioBatDau.Mask = "00:00:00";
            mskGioBatDau.Name = "mskGioBatDau";
            mskGioBatDau.Size = new Size(164, 35);
            mskGioBatDau.TabIndex = 13;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(1116, 140);
            label5.Name = "label5";
            label5.Size = new Size(133, 26);
            label5.TabIndex = 14;
            label5.Text = "Giờ bắt đầu";
            // 
            // mskGioKetThuc
            // 
            mskGioKetThuc.Location = new Point(190, 204);
            mskGioKetThuc.Mask = "00:00:00";
            mskGioKetThuc.Name = "mskGioKetThuc";
            mskGioKetThuc.Size = new Size(188, 35);
            mskGioKetThuc.TabIndex = 15;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(12, 213);
            label6.Name = "label6";
            label6.Size = new Size(139, 26);
            label6.TabIndex = 16;
            label6.Text = "Giờ kết thúc";
            // 
            // mskNgayChieu
            // 
            mskNgayChieu.Location = new Point(534, 204);
            mskNgayChieu.Mask = "00/00/0000";
            mskNgayChieu.Name = "mskNgayChieu";
            mskNgayChieu.Size = new Size(208, 35);
            mskNgayChieu.TabIndex = 17;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(384, 207);
            label7.Name = "label7";
            label7.Size = new Size(126, 26);
            label7.TabIndex = 18;
            label7.Text = "Ngày chiếu";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(922, 204);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(182, 35);
            txtSoLuong.TabIndex = 19;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(769, 213);
            label8.Name = "label8";
            label8.Size = new Size(102, 26);
            label8.TabIndex = 20;
            label8.Text = "Số lượng";
            // 
            // ShowtimeForm
            // 
            AutoScaleDimensions = new SizeF(14F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1517, 585);
            Controls.Add(label8);
            Controls.Add(txtSoLuong);
            Controls.Add(label7);
            Controls.Add(mskNgayChieu);
            Controls.Add(label6);
            Controls.Add(mskGioKetThuc);
            Controls.Add(label5);
            Controls.Add(mskGioBatDau);
            Controls.Add(cboPhong);
            Controls.Add(label4);
            Controls.Add(cboPhim);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMaSuat);
            Controls.Add(dgvShowTime);
            Controls.Add(btnDong);
            Controls.Add(btnLuu);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(5, 4, 5, 4);
            Name = "ShowtimeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "&Thêm";
            FormClosing += ShowtimeForm_FormClosing;
            Load += btnXoa_Click;
            ((System.ComponentModel.ISupportInitialize)dgvShowTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLuu;
        private Button btnDong;
        private DataGridView dgvShowTime;
        private TextBox txtMaSuat;
        private Label label2;
        private Label label3;
        private ComboBox cboPhim;
        private Label label4;
        private ComboBox cboPhong;
        private MaskedTextBox mskGioBatDau;
        private Label label5;
        private MaskedTextBox mskGioKetThuc;
        private Label label6;
        private MaskedTextBox mskNgayChieu;
        private Label label7;
        private TextBox txtSoLuong;
        private Label label8;
    }
}
