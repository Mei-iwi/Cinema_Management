namespace SeatForm
{
    partial class CinemaRooms
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
            cboPhong = new ComboBox();
            btnTim = new Button();
            label1 = new Label();
            lblGheHienTai = new Label();
            btnMua = new Button();
            btnHuy = new Button();
            btnTaiLai = new Button();
            pnlSeats = new Panel();
            SuspendLayout();
            // 
            // cboPhong
            // 
            cboPhong.FormattingEnabled = true;
            cboPhong.Location = new Point(42, 40);
            cboPhong.Name = "cboPhong";
            cboPhong.Size = new Size(245, 28);
            cboPhong.TabIndex = 0;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(306, 36);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(118, 32);
            btnTim.TabIndex = 1;
            btnTim.Text = "Xem";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(42, -2);
            label1.Name = "label1";
            label1.Size = new Size(233, 28);
            label1.TabIndex = 3;
            label1.Text = "Danh sách phòng chiếu";
            // 
            // lblGheHienTai
            // 
            lblGheHienTai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGheHienTai.AutoSize = true;
            lblGheHienTai.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGheHienTai.ForeColor = Color.Blue;
            lblGheHienTai.Location = new Point(838, 35);
            lblGheHienTai.Name = "lblGheHienTai";
            lblGheHienTai.Size = new Size(155, 28);
            lblGheHienTai.TabIndex = 4;
            lblGheHienTai.Text = "Ghế đang chọn";
            // 
            // btnMua
            // 
            btnMua.Anchor = AnchorStyles.Bottom;
            btnMua.Location = new Point(235, 590);
            btnMua.Name = "btnMua";
            btnMua.Size = new Size(174, 48);
            btnMua.TabIndex = 5;
            btnMua.Text = "Bán Ghế";
            btnMua.UseVisualStyleBackColor = true;
            btnMua.Click += btnMua_Click;
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Bottom;
            btnHuy.Location = new Point(447, 590);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(174, 48);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy Mua";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Anchor = AnchorStyles.Bottom;
            btnTaiLai.Location = new Point(658, 590);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(174, 48);
            btnTaiLai.TabIndex = 7;
            btnTaiLai.Text = "Refresh";
            btnTaiLai.UseVisualStyleBackColor = true;
            btnTaiLai.Click += btnTaiLai_Click;
            // 
            // pnlSeats
            // 
            pnlSeats.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlSeats.BorderStyle = BorderStyle.FixedSingle;
            pnlSeats.Location = new Point(36, 86);
            pnlSeats.Name = "pnlSeats";
            pnlSeats.Size = new Size(1078, 480);
            pnlSeats.TabIndex = 8;
            pnlSeats.Paint += pnlSeats_Paint;
            pnlSeats.MouseClick += pnlSeats_MouseClick;
            // 
            // CinemaRooms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 661);
            Controls.Add(pnlSeats);
            Controls.Add(btnTaiLai);
            Controls.Add(btnHuy);
            Controls.Add(btnMua);
            Controls.Add(lblGheHienTai);
            Controls.Add(label1);
            Controls.Add(btnTim);
            Controls.Add(cboPhong);
            Name = "CinemaRooms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CinemaRooms";
            Load += CinemaRooms_Load;
            Resize += CinemaRooms_Resize;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboPhong;
        private Button btnTim;
        private Label label1;
        private Label lblGheHienTai;
        private Button btnMua;
        private Button btnHuy;
        private Button btnTaiLai;
        private Panel pnlSeats;
    }
}
