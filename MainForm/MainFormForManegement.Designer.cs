namespace MainForm
{
    partial class MainFormForManegement
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
            phimĐangChiếuToolStripMenuItem = new ToolStripMenuItem();
            quảnLýPhòngChiếuToolStripMenuItem = new ToolStripMenuItem();
            menuSodoghe = new ToolStripMenuItem();
            dịchVụKháchHàngToolStripMenuItem = new ToolStripMenuItem();
            quảnLýChủTheeToolStripMenuItem = new ToolStripMenuItem();
            eToolStripMenuItem = new ToolStripMenuItem();
            menuQLKH = new ToolStripMenuItem();
            menuQLHangKH = new ToolStripMenuItem();
            menuQLNV = new ToolStripMenuItem();
            ngườiDùngToolStripMenuItem = new ToolStripMenuItem();
            menuQLphim = new ToolStripMenuItem();
            menuQLLichChieu = new ToolStripMenuItem();
            cSKHToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            ngườiDùngToolStripMenuItem1 = new ToolStripMenuItem();
            menuND = new ToolStripMenuItem();
            đổiMậtKhẩuToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // phimĐangChiếuToolStripMenuItem
            // 
            phimĐangChiếuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quảnLýPhòngChiếuToolStripMenuItem, menuSodoghe });
            phimĐangChiếuToolStripMenuItem.ForeColor = Color.White;
            phimĐangChiếuToolStripMenuItem.Name = "phimĐangChiếuToolStripMenuItem";
            phimĐangChiếuToolStripMenuItem.Size = new Size(196, 27);
            phimĐangChiếuToolStripMenuItem.Text = "Quản lý phòng, sơ đồ";
            // 
            // quảnLýPhòngChiếuToolStripMenuItem
            // 
            quảnLýPhòngChiếuToolStripMenuItem.Name = "quảnLýPhòngChiếuToolStripMenuItem";
            quảnLýPhòngChiếuToolStripMenuItem.Size = new Size(259, 28);
            quảnLýPhòngChiếuToolStripMenuItem.Text = "Quản lý phòng chiếu";
            quảnLýPhòngChiếuToolStripMenuItem.Click += quảnLýPhòngChiếuToolStripMenuItem_Click;
            // 
            // menuSodoghe
            // 
            menuSodoghe.Name = "menuSodoghe";
            menuSodoghe.Size = new Size(259, 28);
            menuSodoghe.Text = "Quản lý sơ đồ ghế";
            menuSodoghe.Click += menuSodoghe_Click;
            // 
            // dịchVụKháchHàngToolStripMenuItem
            // 
            dịchVụKháchHàngToolStripMenuItem.ForeColor = Color.White;
            dịchVụKháchHàngToolStripMenuItem.Name = "dịchVụKháchHàngToolStripMenuItem";
            dịchVụKháchHàngToolStripMenuItem.Size = new Size(108, 27);
            dịchVụKháchHàngToolStripMenuItem.Text = "Quản lý vé";
            dịchVụKháchHàngToolStripMenuItem.Click += dịchVụKháchHàngToolStripMenuItem_Click_1;
            // 
            // quảnLýChủTheeToolStripMenuItem
            // 
            quảnLýChủTheeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { eToolStripMenuItem, menuQLNV });
            quảnLýChủTheeToolStripMenuItem.ForeColor = Color.White;
            quảnLýChủTheeToolStripMenuItem.Name = "quảnLýChủTheeToolStripMenuItem";
            quảnLýChủTheeToolStripMenuItem.Size = new Size(149, 27);
            quảnLýChủTheeToolStripMenuItem.Text = "Quản lý chủ thể";
            // 
            // eToolStripMenuItem
            // 
            eToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuQLKH, menuQLHangKH });
            eToolStripMenuItem.Name = "eToolStripMenuItem";
            eToolStripMenuItem.Size = new Size(252, 28);
            eToolStripMenuItem.Text = "Quản lý khách hàng";
            // 
            // menuQLKH
            // 
            menuQLKH.Name = "menuQLKH";
            menuQLKH.Size = new Size(332, 28);
            menuQLKH.Text = "Quản lý thông tin khách hàng";
            menuQLKH.Click += menuQLKH_Click;
            // 
            // menuQLHangKH
            // 
            menuQLHangKH.Name = "menuQLHangKH";
            menuQLHangKH.Size = new Size(332, 28);
            menuQLHangKH.Text = "Quản lý hạng khách hàng";
            menuQLHangKH.Click += menuQLHangKH_Click;
            // 
            // menuQLNV
            // 
            menuQLNV.Name = "menuQLNV";
            menuQLNV.Size = new Size(252, 28);
            menuQLNV.Text = "Quản lý nhân viên";
            menuQLNV.Click += menuQLNV_Click;
            // 
            // ngườiDùngToolStripMenuItem
            // 
            ngườiDùngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuQLphim, menuQLLichChieu });
            ngườiDùngToolStripMenuItem.ForeColor = Color.White;
            ngườiDùngToolStripMenuItem.Name = "ngườiDùngToolStripMenuItem";
            ngườiDùngToolStripMenuItem.Size = new Size(132, 27);
            ngườiDùngToolStripMenuItem.Text = "Quản lý phim";
            // 
            // menuQLphim
            // 
            menuQLphim.Name = "menuQLphim";
            menuQLphim.Size = new Size(235, 28);
            menuQLphim.Text = "Quản lý phim";
            menuQLphim.Click += menuQLphim_Click;
            // 
            // menuQLLichChieu
            // 
            menuQLLichChieu.Name = "menuQLLichChieu";
            menuQLLichChieu.Size = new Size(235, 28);
            menuQLLichChieu.Text = "Quản lý lịch chiếu";
            menuQLLichChieu.Click += menuQLLichChieu_Click;
            // 
            // cSKHToolStripMenuItem
            // 
            cSKHToolStripMenuItem.ForeColor = Color.White;
            cSKHToolStripMenuItem.Name = "cSKHToolStripMenuItem";
            cSKHToolStripMenuItem.Size = new Size(86, 27);
            cSKHToolStripMenuItem.Text = "Báo cáo";
            cSKHToolStripMenuItem.Click += cSKHToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Blue;
            menuStrip1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { phimĐangChiếuToolStripMenuItem, dịchVụKháchHàngToolStripMenuItem, quảnLýChủTheeToolStripMenuItem, ngườiDùngToolStripMenuItem, cSKHToolStripMenuItem, ngườiDùngToolStripMenuItem1 });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(926, 31);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // ngườiDùngToolStripMenuItem1
            // 
            ngườiDùngToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { menuND, đổiMậtKhẩuToolStripMenuItem, đăngXuấtToolStripMenuItem });
            ngườiDùngToolStripMenuItem1.ForeColor = Color.White;
            ngườiDùngToolStripMenuItem1.Name = "ngườiDùngToolStripMenuItem1";
            ngườiDùngToolStripMenuItem1.Size = new Size(122, 27);
            ngườiDùngToolStripMenuItem1.Text = "Người dùng";
            // 
            // menuND
            // 
            menuND.Name = "menuND";
            menuND.Size = new Size(238, 28);
            menuND.Text = "Thông tin cá nhân";
            menuND.Click += menuND_Click;
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            đổiMậtKhẩuToolStripMenuItem.Size = new Size(238, 28);
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(238, 28);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(926, 456);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // MainFormForManegement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 487);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            Name = "MainFormForManegement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainFormManager";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem phimĐangChiếuToolStripMenuItem;
        private ToolStripMenuItem quảnLýPhòngChiếuToolStripMenuItem;
        private ToolStripMenuItem menuSodoghe;
        private ToolStripMenuItem dịchVụKháchHàngToolStripMenuItem;
        private ToolStripMenuItem quảnLýChủTheeToolStripMenuItem;
        private ToolStripMenuItem eToolStripMenuItem;
        private ToolStripMenuItem menuQLKH;
        private ToolStripMenuItem menuQLHangKH;
        private ToolStripMenuItem menuQLNV;
        private ToolStripMenuItem ngườiDùngToolStripMenuItem;
        private ToolStripMenuItem menuQLphim;
        private ToolStripMenuItem menuQLLichChieu;
        private ToolStripMenuItem cSKHToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ngườiDùngToolStripMenuItem1;
        private ToolStripMenuItem menuND;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private PictureBox pictureBox1;
    }
}
