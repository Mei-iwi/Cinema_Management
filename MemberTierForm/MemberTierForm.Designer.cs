namespace MemberTierForm
{
    partial class MemberTierForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberTierForm));
            dgvHienThi = new DataGridView();
            txtMaHang = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtTenHang = new TextBox();
            label3 = new Label();
            txtUuDai = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtDiem = new TextBox();
            label6 = new Label();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnLoad = new Button();
            btnDong = new Button();
            label7 = new Label();
            txtMoTa = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvHienThi).BeginInit();
            SuspendLayout();
            // 
            // dgvHienThi
            // 
            dgvHienThi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHienThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHienThi.Location = new Point(62, 240);
            dgvHienThi.Margin = new Padding(4, 3, 4, 3);
            dgvHienThi.Name = "dgvHienThi";
            dgvHienThi.RowHeadersWidth = 62;
            dgvHienThi.Size = new Size(1410, 271);
            dgvHienThi.TabIndex = 0;
            // 
            // txtMaHang
            // 
            txtMaHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMaHang.Location = new Point(335, 131);
            txtMaHang.Margin = new Padding(4, 3, 4, 3);
            txtMaHang.Name = "txtMaHang";
            txtMaHang.Size = new Size(209, 35);
            txtMaHang.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 134);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(109, 26);
            label1.TabIndex = 2;
            label1.Text = "Mã Hạng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(596, 128);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(113, 26);
            label2.TabIndex = 3;
            label2.Text = "Tên Hạng";
            // 
            // txtTenHang
            // 
            txtTenHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtTenHang.Location = new Point(718, 120);
            txtTenHang.Margin = new Padding(4, 3, 4, 3);
            txtTenHang.Name = "txtTenHang";
            txtTenHang.Size = new Size(209, 35);
            txtTenHang.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(811, 113);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 26);
            label3.TabIndex = 5;
            // 
            // txtUuDai
            // 
            txtUuDai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUuDai.Location = new Point(718, 199);
            txtUuDai.Margin = new Padding(4, 3, 4, 3);
            txtUuDai.Name = "txtUuDai";
            txtUuDai.Size = new Size(209, 35);
            txtUuDai.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(100, 199);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(171, 26);
            label4.TabIndex = 7;
            label4.Text = "Điểm Tối Thiểu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(596, 207);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(82, 26);
            label5.TabIndex = 8;
            label5.Text = "Ưu đãi";
            // 
            // txtDiem
            // 
            txtDiem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDiem.Location = new Point(335, 199);
            txtDiem.Margin = new Padding(4, 3, 4, 3);
            txtDiem.Name = "txtDiem";
            txtDiem.Size = new Size(209, 35);
            txtDiem.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.Highlight;
            label6.Location = new Point(535, 9);
            label6.Name = "label6";
            label6.Size = new Size(428, 41);
            label6.TabIndex = 10;
            label6.Text = "Quản Lý Hạng Thành Viên";
            // 
            // btnThem
            // 
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Location = new Point(12, 72);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(121, 33);
            btnThem.TabIndex = 11;
            btnThem.Text = "&Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Location = new Point(139, 72);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(121, 33);
            btnXoa.TabIndex = 12;
            btnXoa.Text = "&Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Location = new Point(266, 72);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(121, 33);
            btnSua.TabIndex = 13;
            btnSua.Text = "&Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLoad
            // 
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Location = new Point(393, 72);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(121, 33);
            btnLoad.TabIndex = 14;
            btnLoad.Text = "&Làm mới";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDong
            // 
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Location = new Point(520, 72);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(121, 33);
            btnDong.TabIndex = 15;
            btnDong.Text = "&Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(972, 123);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(73, 26);
            label7.TabIndex = 16;
            label7.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            txtMoTa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMoTa.Location = new Point(1053, 123);
            txtMoTa.Margin = new Padding(4, 3, 4, 3);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(222, 108);
            txtMoTa.TabIndex = 17;
            // 
            // MemberTierForm
            // 
            AutoScaleDimensions = new SizeF(14F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1549, 517);
            Controls.Add(txtMoTa);
            Controls.Add(label7);
            Controls.Add(btnDong);
            Controls.Add(btnLoad);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(label6);
            Controls.Add(txtDiem);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtUuDai);
            Controls.Add(label3);
            Controls.Add(txtTenHang);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtMaHang);
            Controls.Add(dgvHienThi);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "MemberTierForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Hạng Thành Viên";
            FormClosing += MemberTierForm_FormClosing;
            Load += MemberTierForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHienThi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHienThi;
        private TextBox txtMaHang;
        private Label label1;
        private Label label2;
        private TextBox txtTenHang;
        private Label label3;
        private TextBox txtUuDai;
        private Label label4;
        private Label label5;
        private TextBox txtDiem;
        private Label label6;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnLoad;
        private Button btnDong;
        private Label label7;
        private TextBox txtMoTa;
    }
}
