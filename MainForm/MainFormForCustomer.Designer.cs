namespace MainForm
{
    partial class MainFormForCustomer
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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            phimĐangChiếuToolStripMenuItem = new ToolStripMenuItem();
            dịchVụKháchHàngToolStripMenuItem = new ToolStripMenuItem();
            ngườiDùngToolStripMenuItem = new ToolStripMenuItem();
            menuNguoidung = new ToolStripMenuItem();
            menuChangePas = new ToolStripMenuItem();
            thayĐổiMâToolStripMenuItem = new ToolStripMenuItem();
            cSKHToolStripMenuItem = new ToolStripMenuItem();
            gửiGópYToolStripMenuItem = new ToolStripMenuItem();
            liênHệToolStripMenuItem = new ToolStripMenuItem();
            liênHệHỗTrợToolStripMenuItem = new ToolStripMenuItem();
            đóngGópÝKiếnToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel = new TableLayoutPanel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Blue;
            menuStrip1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, phimĐangChiếuToolStripMenuItem, dịchVụKháchHàngToolStripMenuItem, ngườiDùngToolStripMenuItem, cSKHToolStripMenuItem, liênHệToolStripMenuItem });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 31);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.ForeColor = Color.White;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 27);
            // 
            // phimĐangChiếuToolStripMenuItem
            // 
            phimĐangChiếuToolStripMenuItem.ForeColor = Color.White;
            phimĐangChiếuToolStripMenuItem.Name = "phimĐangChiếuToolStripMenuItem";
            phimĐangChiếuToolStripMenuItem.Size = new Size(158, 27);
            phimĐangChiếuToolStripMenuItem.Text = "Phim đang chiếu";
            // 
            // dịchVụKháchHàngToolStripMenuItem
            // 
            dịchVụKháchHàngToolStripMenuItem.ForeColor = Color.White;
            dịchVụKháchHàngToolStripMenuItem.Name = "dịchVụKháchHàngToolStripMenuItem";
            dịchVụKháchHàngToolStripMenuItem.Size = new Size(181, 27);
            dịchVụKháchHàngToolStripMenuItem.Text = "Dịch vụ khách hàng";
            dịchVụKháchHàngToolStripMenuItem.Click += dịchVụKháchHàngToolStripMenuItem_Click;
            // 
            // ngườiDùngToolStripMenuItem
            // 
            ngườiDùngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuNguoidung, menuChangePas, thayĐổiMâToolStripMenuItem });
            ngườiDùngToolStripMenuItem.ForeColor = Color.White;
            ngườiDùngToolStripMenuItem.Name = "ngườiDùngToolStripMenuItem";
            ngườiDùngToolStripMenuItem.Size = new Size(122, 27);
            ngườiDùngToolStripMenuItem.Text = "Người dùng";
            // 
            // menuNguoidung
            // 
            menuNguoidung.Name = "menuNguoidung";
            menuNguoidung.Size = new Size(272, 28);
            menuNguoidung.Text = "Thông tin người dùng";
            menuNguoidung.Click += đăngNhậpToolStripMenuItem_Click;
            // 
            // menuChangePas
            // 
            menuChangePas.Name = "menuChangePas";
            menuChangePas.Size = new Size(272, 28);
            menuChangePas.Text = "Đổi mật khẩu";
            menuChangePas.Click += đăngKýToolStripMenuItem_Click;
            // 
            // thayĐổiMâToolStripMenuItem
            // 
            thayĐổiMâToolStripMenuItem.Name = "thayĐổiMâToolStripMenuItem";
            thayĐổiMâToolStripMenuItem.Size = new Size(272, 28);
            thayĐổiMâToolStripMenuItem.Text = "Đăng xuất";
            thayĐổiMâToolStripMenuItem.Click += Logout;
            // 
            // cSKHToolStripMenuItem
            // 
            cSKHToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gửiGópYToolStripMenuItem });
            cSKHToolStripMenuItem.ForeColor = Color.White;
            cSKHToolStripMenuItem.Name = "cSKHToolStripMenuItem";
            cSKHToolStripMenuItem.Size = new Size(69, 27);
            cSKHToolStripMenuItem.Text = "CSKH";
            // 
            // gửiGópYToolStripMenuItem
            // 
            gửiGópYToolStripMenuItem.Name = "gửiGópYToolStripMenuItem";
            gửiGópYToolStripMenuItem.Size = new Size(240, 28);
            gửiGópYToolStripMenuItem.Text = "Ý kiến khách hàng";
            gửiGópYToolStripMenuItem.Click += gửiGópYToolStripMenuItem_Click;
            // 
            // liênHệToolStripMenuItem
            // 
            liênHệToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { liênHệHỗTrợToolStripMenuItem, đóngGópÝKiếnToolStripMenuItem });
            liênHệToolStripMenuItem.ForeColor = Color.White;
            liênHệToolStripMenuItem.Name = "liênHệToolStripMenuItem";
            liênHệToolStripMenuItem.Size = new Size(86, 27);
            liênHệToolStripMenuItem.Text = "Liên hệ ";
            // 
            // liênHệHỗTrợToolStripMenuItem
            // 
            liênHệHỗTrợToolStripMenuItem.Name = "liênHệHỗTrợToolStripMenuItem";
            liênHệHỗTrợToolStripMenuItem.Size = new Size(228, 28);
            liênHệHỗTrợToolStripMenuItem.Text = "Liên hệ hỗ trợ";
            // 
            // đóngGópÝKiếnToolStripMenuItem
            // 
            đóngGópÝKiếnToolStripMenuItem.Name = "đóngGópÝKiếnToolStripMenuItem";
            đóngGópÝKiếnToolStripMenuItem.Size = new Size(228, 28);
            đóngGópÝKiếnToolStripMenuItem.Text = "Đóng góp ý kiến";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.AutoScroll = true;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 31);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Size = new Size(800, 419);
            tableLayoutPanel.TabIndex = 2;
            // 
            // MainFormForCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainFormForCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainFormForCustomer";
            Load += MainFormForCustomer_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem phimĐangChiếuToolStripMenuItem;
        private ToolStripMenuItem dịchVụKháchHàngToolStripMenuItem;
        private ToolStripMenuItem ngườiDùngToolStripMenuItem;
        private ToolStripMenuItem menuNguoidung;
        private ToolStripMenuItem menuChangePas;
        private ToolStripMenuItem thayĐổiMâToolStripMenuItem;
        private FlowLayoutPanel flowLayout;
        private TableLayoutPanel tableLayoutPanel;
        private ToolStripMenuItem cSKHToolStripMenuItem;
        private ToolStripMenuItem gửiGópYToolStripMenuItem;
        private ToolStripMenuItem liênHệToolStripMenuItem;
        private ToolStripMenuItem liênHệHỗTrợToolStripMenuItem;
        private ToolStripMenuItem đóngGópÝKiếnToolStripMenuItem;
    }
}