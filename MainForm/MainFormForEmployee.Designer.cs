namespace MainForm
{
    partial class MainFormForEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormForEmployee));
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            MenuTicket = new ToolStripMenuItem();
            dịchVụKháchHàngToolStripMenuItem = new ToolStripMenuItem();
            liênHệToolStripMenuItem = new ToolStripMenuItem();
            liênHệHỗTrợToolStripMenuItem = new ToolStripMenuItem();
            đóngGópÝKiếnToolStripMenuItem = new ToolStripMenuItem();
            ngườiDùngToolStripMenuItem1 = new ToolStripMenuItem();
            MenuND = new ToolStripMenuItem();
            menuChangePas = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Blue;
            menuStrip1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, MenuTicket, dịchVụKháchHàngToolStripMenuItem, liênHệToolStripMenuItem, ngườiDùngToolStripMenuItem1 });
            menuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 31);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.ForeColor = Color.White;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 27);
            // 
            // MenuTicket
            // 
            MenuTicket.ForeColor = Color.White;
            MenuTicket.Name = "MenuTicket";
            MenuTicket.Size = new Size(152, 27);
            MenuTicket.Text = "Lập vé, hóa đơn";
            MenuTicket.Click += phimĐangChiếuToolStripMenuItem_Click;
            // 
            // dịchVụKháchHàngToolStripMenuItem
            // 
            dịchVụKháchHàngToolStripMenuItem.ForeColor = Color.White;
            dịchVụKháchHàngToolStripMenuItem.Name = "dịchVụKháchHàngToolStripMenuItem";
            dịchVụKháchHàngToolStripMenuItem.Size = new Size(218, 27);
            dịchVụKháchHàngToolStripMenuItem.Text = "Quản lý đăng ký dịch vụ";
            dịchVụKháchHàngToolStripMenuItem.Click += dịchVụKháchHàngToolStripMenuItem_Click;
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
            liênHệHỗTrợToolStripMenuItem.Size = new Size(244, 28);
            liênHệHỗTrợToolStripMenuItem.Text = "Hỗ trợ khách hàng";
            liênHệHỗTrợToolStripMenuItem.Click += liênHệHỗTrợToolStripMenuItem_Click;
            // 
            // đóngGópÝKiếnToolStripMenuItem
            // 
            đóngGópÝKiếnToolStripMenuItem.Name = "đóngGópÝKiếnToolStripMenuItem";
            đóngGópÝKiếnToolStripMenuItem.Size = new Size(244, 28);
            đóngGópÝKiếnToolStripMenuItem.Text = "Đóng góp ý kiến";
            đóngGópÝKiếnToolStripMenuItem.Click += đóngGópÝKiếnToolStripMenuItem_Click;
            // 
            // ngườiDùngToolStripMenuItem1
            // 
            ngườiDùngToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { MenuND, menuChangePas, đăngXuấtToolStripMenuItem });
            ngườiDùngToolStripMenuItem1.ForeColor = Color.White;
            ngườiDùngToolStripMenuItem1.Name = "ngườiDùngToolStripMenuItem1";
            ngườiDùngToolStripMenuItem1.Size = new Size(122, 27);
            ngườiDùngToolStripMenuItem1.Text = "Người dùng";
            // 
            // MenuND
            // 
            MenuND.Name = "MenuND";
            MenuND.Size = new Size(272, 28);
            MenuND.Text = "Thông tin người dùng";
            MenuND.Click += MenuND_Click;
            // 
            // menuChangePas
            // 
            menuChangePas.Name = "menuChangePas";
            menuChangePas.Size = new Size(272, 28);
            menuChangePas.Text = "Đổi mật khẩu";
            menuChangePas.Click += đổiMậtKhẩuToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(272, 28);
            đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 419);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // MainFormForEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            Name = "MainFormForEmployee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainFormForEmployee";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem MenuTicket;
        private ToolStripMenuItem dịchVụKháchHàngToolStripMenuItem;
        private ToolStripMenuItem liênHệToolStripMenuItem;
        private ToolStripMenuItem liênHệHỗTrợToolStripMenuItem;
        private ToolStripMenuItem đóngGópÝKiếnToolStripMenuItem;
        private ToolStripMenuItem ngườiDùngToolStripMenuItem1;
        private ToolStripMenuItem MenuND;
        private ToolStripMenuItem menuChangePas;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private PictureBox pictureBox1;
    }
}