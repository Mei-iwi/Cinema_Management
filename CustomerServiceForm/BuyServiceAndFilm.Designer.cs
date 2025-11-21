namespace CustomerServiceForm
{
    partial class BuyServiceAndFilm
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
            groupBox1 = new GroupBox();
            label2 = new Label();
            numSL = new NumericUpDown();
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            txtDG = new TextBox();
            cboLoave = new ComboBox();
            txtTenPhim = new TextBox();
            txtMaphim = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtChonDichVu = new Button();
            label1 = new Label();
            pnlSeats = new Panel();
            lblSuatChieu = new Label();
            button2 = new Button();
            button1 = new Button();
            btnTim = new Button();
            lblGheHienTai = new Label();
            cboPhong = new ComboBox();
            label9 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSL).BeginInit();
            pnlSeats.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numSL);
            groupBox1.Controls.Add(txtMaSP);
            groupBox1.Controls.Add(txtTenSP);
            groupBox1.Controls.Add(txtDG);
            groupBox1.Controls.Add(cboLoave);
            groupBox1.Controls.Add(txtTenPhim);
            groupBox1.Controls.Add(txtMaphim);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtChonDichVu);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 42);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1062, 137);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Xác nhận thông tin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(815, 105);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 29;
            label2.Text = "Số lượng";
            // 
            // numSL
            // 
            numSL.Location = new Point(892, 103);
            numSL.Name = "numSL";
            numSL.Size = new Size(77, 27);
            numSL.TabIndex = 28;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(746, 23);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(221, 27);
            txtMaSP.TabIndex = 27;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(748, 63);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.ReadOnly = true;
            txtTenSP.Size = new Size(221, 27);
            txtTenSP.TabIndex = 26;
            // 
            // txtDG
            // 
            txtDG.Location = new Point(420, 70);
            txtDG.Name = "txtDG";
            txtDG.Size = new Size(221, 27);
            txtDG.TabIndex = 25;
            // 
            // cboLoave
            // 
            cboLoave.FormattingEnabled = true;
            cboLoave.Location = new Point(417, 23);
            cboLoave.Name = "cboLoave";
            cboLoave.Size = new Size(224, 28);
            cboLoave.TabIndex = 24;
            cboLoave.SelectedIndexChanged += cboLoave_SelectedIndexChanged;
            // 
            // txtTenPhim
            // 
            txtTenPhim.Location = new Point(104, 70);
            txtTenPhim.Name = "txtTenPhim";
            txtTenPhim.ReadOnly = true;
            txtTenPhim.Size = new Size(221, 27);
            txtTenPhim.TabIndex = 23;
            // 
            // txtMaphim
            // 
            txtMaphim.Location = new Point(104, 23);
            txtMaphim.Name = "txtMaphim";
            txtMaphim.ReadOnly = true;
            txtMaphim.Size = new Size(221, 27);
            txtMaphim.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(331, 23);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 20;
            label7.Text = "Loại vé";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(331, 70);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 19;
            label8.Text = "Đơn giá";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(642, 23);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 18;
            label5.Text = "Mã sản phẩm";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 23);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 17;
            label6.Text = "Mã phim";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(642, 70);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 16;
            label4.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 70);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 15;
            label3.Text = "Tên phim";
            // 
            // txtChonDichVu
            // 
            txtChonDichVu.Location = new Point(642, 103);
            txtChonDichVu.Name = "txtChonDichVu";
            txtChonDichVu.Size = new Size(144, 28);
            txtChonDichVu.TabIndex = 1;
            txtChonDichVu.Text = "Chọn dịch vụ đi kèm";
            txtChonDichVu.UseVisualStyleBackColor = true;
            txtChonDichVu.Click += txtChonDichVu_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1100, 28);
            label1.TabIndex = 3;
            label1.Text = "THANH TOÁN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlSeats
            // 
            pnlSeats.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSeats.BorderStyle = BorderStyle.FixedSingle;
            pnlSeats.Controls.Add(lblSuatChieu);
            pnlSeats.Location = new Point(12, 224);
            pnlSeats.Name = "pnlSeats";
            pnlSeats.Size = new Size(1062, 517);
            pnlSeats.TabIndex = 10;
            pnlSeats.Paint += pnlSeats_Paint;
            pnlSeats.MouseClick += pnlSeats_MouseClick;
            // 
            // lblSuatChieu
            // 
            lblSuatChieu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSuatChieu.AutoSize = true;
            lblSuatChieu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSuatChieu.ForeColor = Color.Blue;
            lblSuatChieu.Location = new Point(15, 36);
            lblSuatChieu.Name = "lblSuatChieu";
            lblSuatChieu.Size = new Size(155, 28);
            lblSuatChieu.TabIndex = 15;
            lblSuatChieu.Text = "Ghế đang chọn";
            // 
            // button2
            // 
            button2.Location = new Point(687, 749);
            button2.Name = "button2";
            button2.Size = new Size(172, 48);
            button2.TabIndex = 12;
            button2.Text = "Hủy";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(878, 747);
            button1.Name = "button1";
            button1.Size = new Size(177, 48);
            button1.TabIndex = 11;
            button1.Text = "Thanh toán";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(728, 186);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(118, 32);
            btnTim.TabIndex = 5;
            btnTim.Text = "Xem";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // lblGheHienTai
            // 
            lblGheHienTai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGheHienTai.AutoSize = true;
            lblGheHienTai.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGheHienTai.ForeColor = Color.Blue;
            lblGheHienTai.Location = new Point(12, 767);
            lblGheHienTai.Name = "lblGheHienTai";
            lblGheHienTai.Size = new Size(155, 28);
            lblGheHienTai.TabIndex = 13;
            lblGheHienTai.Text = "Ghế đang chọn";
            // 
            // cboPhong
            // 
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(452, 189);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(245, 28);
            cboPhong.TabIndex = 4;
            cboPhong.SelectedIndexChanged += cboPhong_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Blue;
            label9.Location = new Point(190, 189);
            label9.Name = "label9";
            label9.Size = new Size(233, 28);
            label9.TabIndex = 6;
            label9.Text = "Danh sách phòng chiếu";
            // 
            // BuyServiceAndFilm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 809);
            Controls.Add(btnTim);
            Controls.Add(cboPhong);
            Controls.Add(label9);
            Controls.Add(lblGheHienTai);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pnlSeats);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "BuyServiceAndFilm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BuyServiceAndFilm";
            Load += BuyServiceAndFilm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSL).EndInit();
            pnlSeats.ResumeLayout(false);
            pnlSeats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private Label label1;
        private Panel pnlSeats;
        private Button button2;
        private Button button1;
        private Button btnTim;
        private Label lblGheHienTai;
        private Label label7;
        private Label label8;
        private Label label5;
        private Label label6;
        private Label label4;
        private Label label3;
        private Button txtChonDichVu;
        private ComboBox cboLoave;
        private TextBox txtTenPhim;
        private TextBox txtMaphim;
        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private TextBox txtDG;
        private ComboBox cboPhong;
        private Label label9;
        private Label lblSuatChieu;
        private Label label2;
        private NumericUpDown numSL;
    }
}