namespace TicketForm
{
    partial class TicketForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketForm));
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLuu = new Button();
            label1 = new Label();
            dgvTicket = new DataGridView();
            btnDong = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaVe = new TextBox();
            label7 = new Label();
            label8 = new Label();
            cboMaSuat = new ComboBox();
            cboMaGhe = new ComboBox();
            cboMaNhanVien = new ComboBox();
            cboMaLoaiVe = new ComboBox();
            cboMaKhachHang = new ComboBox();
            mstNgayBan = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTicket).BeginInit();
            SuspendLayout();
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnThem.Location = new Point(13, 62);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(157, 35);
            btnThem.TabIndex = 0;
            btnThem.Text = "&Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnXoa.Location = new Point(182, 62);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(157, 35);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "&Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSua.Location = new Point(347, 62);
            btnSua.Margin = new Padding(4, 3, 4, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(157, 35);
            btnSua.TabIndex = 2;
            btnSua.Text = "&Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLuu.Location = new Point(512, 62);
            btnLuu.Margin = new Padding(4, 3, 4, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(157, 35);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1032, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(202, 41);
            label1.TabIndex = 5;
            label1.Text = "Quản Lý Vé";
            label1.UseMnemonic = false;
            // 
            // dgvTicket
            // 
            dgvTicket.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTicket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTicket.Location = new Point(228, 246);
            dgvTicket.Name = "dgvTicket";
            dgvTicket.RowHeadersWidth = 62;
            dgvTicket.Size = new Size(1297, 280);
            dgvTicket.TabIndex = 6;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDong.Location = new Point(677, 62);
            btnDong.Margin = new Padding(4, 3, 4, 3);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(157, 35);
            btnDong.TabIndex = 7;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 150);
            label2.Name = "label2";
            label2.Size = new Size(91, 26);
            label2.TabIndex = 9;
            label2.Text = "MÃ VÉ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(373, 150);
            label3.Name = "label3";
            label3.Size = new Size(99, 26);
            label3.TabIndex = 10;
            label3.Text = "Mã Suất";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(727, 150);
            label4.Name = "label4";
            label4.Size = new Size(134, 26);
            label4.TabIndex = 13;
            label4.Text = "Mã Loại Vé";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1051, 150);
            label5.Name = "label5";
            label5.Size = new Size(183, 26);
            label5.TabIndex = 14;
            label5.Text = "Mã Khách Hàng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 210);
            label6.Name = "label6";
            label6.Size = new Size(161, 26);
            label6.TabIndex = 16;
            label6.Text = "Mã Nhân Viên";
            // 
            // txtMaVe
            // 
            txtMaVe.Location = new Point(217, 141);
            txtMaVe.Name = "txtMaVe";
            txtMaVe.Size = new Size(150, 35);
            txtMaVe.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(373, 204);
            label7.Name = "label7";
            label7.Size = new Size(95, 26);
            label7.TabIndex = 18;
            label7.Text = "Mã Ghế";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(727, 210);
            label8.Name = "label8";
            label8.Size = new Size(112, 26);
            label8.TabIndex = 21;
            label8.Text = "Ngày Bán";
            // 
            // cboMaSuat
            // 
            cboMaSuat.FormattingEnabled = true;
            cboMaSuat.Location = new Point(539, 142);
            cboMaSuat.Name = "cboMaSuat";
            cboMaSuat.Size = new Size(182, 34);
            cboMaSuat.TabIndex = 22;
            // 
            // cboMaGhe
            // 
            cboMaGhe.FormattingEnabled = true;
            cboMaGhe.Location = new Point(539, 201);
            cboMaGhe.Name = "cboMaGhe";
            cboMaGhe.Size = new Size(182, 34);
            cboMaGhe.TabIndex = 23;
            // 
            // cboMaNhanVien
            // 
            cboMaNhanVien.FormattingEnabled = true;
            cboMaNhanVien.Location = new Point(217, 204);
            cboMaNhanVien.Name = "cboMaNhanVien";
            cboMaNhanVien.Size = new Size(150, 34);
            cboMaNhanVien.TabIndex = 24;
            // 
            // cboMaLoaiVe
            // 
            cboMaLoaiVe.FormattingEnabled = true;
            cboMaLoaiVe.Location = new Point(882, 147);
            cboMaLoaiVe.Name = "cboMaLoaiVe";
            cboMaLoaiVe.Size = new Size(150, 34);
            cboMaLoaiVe.TabIndex = 25;
            // 
            // cboMaKhachHang
            // 
            cboMaKhachHang.FormattingEnabled = true;
            cboMaKhachHang.Location = new Point(1240, 147);
            cboMaKhachHang.Name = "cboMaKhachHang";
            cboMaKhachHang.Size = new Size(150, 34);
            cboMaKhachHang.TabIndex = 26;
            // 
            // mstNgayBan
            // 
            mstNgayBan.Location = new Point(882, 201);
            mstNgayBan.Name = "mstNgayBan";
            mstNgayBan.Size = new Size(150, 35);
            mstNgayBan.TabIndex = 27;
            // 
            // TicketForm
            // 
            AutoScaleDimensions = new SizeF(14F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1754, 538);
            Controls.Add(mstNgayBan);
            Controls.Add(cboMaKhachHang);
            Controls.Add(cboMaLoaiVe);
            Controls.Add(cboMaNhanVien);
            Controls.Add(cboMaGhe);
            Controls.Add(cboMaSuat);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtMaVe);
            Controls.Add(btnDong);
            Controls.Add(dgvTicket);
            Controls.Add(label1);
            Controls.Add(btnLuu);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "TicketForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Form";
            ((System.ComponentModel.ISupportInitialize)dgvTicket).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLuu;
        private Label label1;
        private DataGridView dgvTicket;
        private Button btnDong;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMaVe;
        private Label label7;
        private Label label8;
        private ComboBox cboMaSuat;
        private ComboBox cboMaGhe;
        private ComboBox cboMaNhanVien;
        private ComboBox cboMaLoaiVe;
        private ComboBox cboMaKhachHang;
        private MaskedTextBox mstNgayBan;
    }
}
