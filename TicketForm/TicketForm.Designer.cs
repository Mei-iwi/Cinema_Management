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
            treeView1 = new TreeView();
            mstNgayBan = new MaskedTextBox();
            cboMaKhachHang = new ComboBox();
            cboMaLoaiVe = new ComboBox();
            cboMaNhanVien = new ComboBox();
            cboMaGhe = new ComboBox();
            cboMaSuat = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtMaVe = new TextBox();
            btnDong = new Button();
            dgvTicket = new DataGridView();
            label1 = new Label();
            btnLuu = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTicket).BeginInit();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 74);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(361, 558);
            treeView1.TabIndex = 72;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // mstNgayBan
            // 
            mstNgayBan.Location = new Point(1246, 122);
            mstNgayBan.Name = "mstNgayBan";
            mstNgayBan.Size = new Size(210, 30);
            mstNgayBan.TabIndex = 71;
            // 
            // cboMaKhachHang
            // 
            cboMaKhachHang.FormattingEnabled = true;
            cboMaKhachHang.Location = new Point(537, 185);
            cboMaKhachHang.Name = "cboMaKhachHang";
            cboMaKhachHang.Size = new Size(210, 31);
            cboMaKhachHang.TabIndex = 70;
            // 
            // cboMaLoaiVe
            // 
            cboMaLoaiVe.FormattingEnabled = true;
            cboMaLoaiVe.Location = new Point(1246, 68);
            cboMaLoaiVe.Name = "cboMaLoaiVe";
            cboMaLoaiVe.Size = new Size(210, 31);
            cboMaLoaiVe.TabIndex = 69;
            // 
            // cboMaNhanVien
            // 
            cboMaNhanVien.FormattingEnabled = true;
            cboMaNhanVien.Location = new Point(537, 122);
            cboMaNhanVien.Name = "cboMaNhanVien";
            cboMaNhanVien.Size = new Size(210, 31);
            cboMaNhanVien.TabIndex = 68;
            // 
            // cboMaGhe
            // 
            cboMaGhe.FormattingEnabled = true;
            cboMaGhe.Location = new Point(867, 127);
            cboMaGhe.Name = "cboMaGhe";
            cboMaGhe.Size = new Size(242, 31);
            cboMaGhe.TabIndex = 67;
            // 
            // cboMaSuat
            // 
            cboMaSuat.FormattingEnabled = true;
            cboMaSuat.Location = new Point(867, 62);
            cboMaSuat.Name = "cboMaSuat";
            cboMaSuat.Size = new Size(242, 31);
            cboMaSuat.TabIndex = 66;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1119, 129);
            label8.Name = "label8";
            label8.Size = new Size(92, 23);
            label8.TabIndex = 65;
            label8.Text = "Ngày Bán";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(769, 135);
            label7.Name = "label7";
            label7.Size = new Size(79, 23);
            label7.TabIndex = 64;
            label7.Text = "Mã Ghế";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(391, 129);
            label6.Name = "label6";
            label6.Size = new Size(129, 23);
            label6.TabIndex = 63;
            label6.Text = "Mã Nhân Viên";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(391, 187);
            label5.Name = "label5";
            label5.Size = new Size(146, 23);
            label5.TabIndex = 62;
            label5.Text = "Mã Khách Hàng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1119, 69);
            label4.Name = "label4";
            label4.Size = new Size(109, 23);
            label4.TabIndex = 61;
            label4.Text = "Mã Loại Vé";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(769, 70);
            label3.Name = "label3";
            label3.Size = new Size(81, 23);
            label3.TabIndex = 60;
            label3.Text = "Mã Suất";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(391, 69);
            label2.Name = "label2";
            label2.Size = new Size(74, 23);
            label2.TabIndex = 59;
            label2.Text = "MÃ VÉ";
            // 
            // txtMaVe
            // 
            txtMaVe.Location = new Point(537, 57);
            txtMaVe.Name = "txtMaVe";
            txtMaVe.Size = new Size(210, 30);
            txtMaVe.TabIndex = 58;
            // 
            // btnDong
            // 
            btnDong.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDong.Location = new Point(1168, 226);
            btnDong.Margin = new Padding(4, 3, 4, 3);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(157, 35);
            btnDong.TabIndex = 57;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // dgvTicket
            // 
            dgvTicket.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTicket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTicket.Location = new Point(391, 267);
            dgvTicket.Name = "dgvTicket";
            dgvTicket.RowHeadersWidth = 62;
            dgvTicket.Size = new Size(1146, 365);
            dgvTicket.TabIndex = 56;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(792, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(168, 35);
            label1.TabIndex = 55;
            label1.Text = "Quản Lý Vé";
            label1.UseMnemonic = false;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLuu.Location = new Point(892, 226);
            btnLuu.Margin = new Padding(4, 3, 4, 3);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(157, 35);
            btnLuu.TabIndex = 54;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSua.Location = new Point(630, 226);
            btnSua.Margin = new Padding(4, 3, 4, 3);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(157, 35);
            btnSua.TabIndex = 53;
            btnSua.Text = "&Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnXoa.Location = new Point(610, 323);
            btnXoa.Margin = new Padding(4, 3, 4, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(157, 35);
            btnXoa.TabIndex = 52;
            btnXoa.Text = "&Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnThem.Location = new Point(488, 323);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(157, 35);
            btnThem.TabIndex = 51;
            btnThem.Text = "&Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click_1;
            // 
            // TicketForm
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1548, 642);
            Controls.Add(treeView1);
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

        private TreeView treeView1;
        private MaskedTextBox mstNgayBan;
        private ComboBox cboMaKhachHang;
        private ComboBox cboMaLoaiVe;
        private ComboBox cboMaNhanVien;
        private ComboBox cboMaGhe;
        private ComboBox cboMaSuat;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtMaVe;
        private Button btnDong;
        private DataGridView dgvTicket;
        private Label label1;
        private Button btnLuu;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThem;
    }
}
