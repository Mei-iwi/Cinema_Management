namespace QL_RAP_PHIM
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.businessManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.systemToolStripMenuItem,
                this.userManagementToolStripMenuItem,
                this.businessManagementToolStripMenuItem,
                this.reportToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.logoutToolStripMenuItem,
                this.exitToolStripMenuItem
            });
            this.systemToolStripMenuItem.Text = "Hệ thống";

            this.logoutToolStripMenuItem.Text = "Đăng xuất";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);

            this.exitToolStripMenuItem.Text = "Thoát";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);

            this.userManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.customerProfileToolStripMenuItem,
                this.customerServiceToolStripMenuItem,
                this.feedbackToolStripMenuItem
            });
            this.userManagementToolStripMenuItem.Text = "Giao diện & Người dùng (Nhóm 1)";

            this.customerProfileToolStripMenuItem.Text = "Hồ sơ Khách hàng";
            this.customerProfileToolStripMenuItem.Click += new System.EventHandler(this.customerProfileToolStripMenuItem_Click);

            this.customerServiceToolStripMenuItem.Text = "Đăng ký Dịch vụ";
            this.customerServiceToolStripMenuItem.Click += new System.EventHandler(this.customerServiceToolStripMenuItem_Click);

            this.feedbackToolStripMenuItem.Text = "Form Ý kiến khách hàng";
            this.feedbackToolStripMenuItem.Click += new System.EventHandler(this.feedbackToolStripMenuItem_Click);

            this.businessManagementToolStripMenuItem.Text = "Nghiệp vụ (Nhóm 2)";

            this.reportToolStripMenuItem.Text = "Báo cáo (Nhóm 3)";

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Hệ thống Quản lý Rạp Phim";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);

            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem businessManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedbackToolStripMenuItem;
    }
}