namespace MainForm
{
    partial class ChangePasswordUser
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
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnPassOld = new Button();
            txtnewPassAgian = new TextBox();
            txtnewPass = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtPassOld = new TextBox();
            btnPass = new Button();
            btnPassAgain = new Button();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(-1, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(252, 471);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(btnPassOld, 2, 0);
            tableLayoutPanel1.Controls.Add(txtnewPassAgian, 1, 2);
            tableLayoutPanel1.Controls.Add(txtnewPass, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(txtPassOld, 1, 0);
            tableLayoutPanel1.Controls.Add(btnPass, 2, 1);
            tableLayoutPanel1.Controls.Add(btnPassAgain, 2, 2);
            tableLayoutPanel1.Location = new Point(262, 84);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(357, 287);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnPassOld
            // 
            btnPassOld.Location = new Point(318, 3);
            btnPassOld.Name = "btnPassOld";
            btnPassOld.Size = new Size(36, 29);
            btnPassOld.TabIndex = 12;
            btnPassOld.UseVisualStyleBackColor = true;
            btnPassOld.Click += btnPassOld_Click;
            // 
            // txtnewPassAgian
            // 
            txtnewPassAgian.Location = new Point(157, 193);
            txtnewPassAgian.Name = "txtnewPassAgian";
            txtnewPassAgian.Size = new Size(155, 27);
            txtnewPassAgian.TabIndex = 9;
            // 
            // txtnewPass
            // 
            txtnewPass.Location = new Point(157, 98);
            txtnewPass.Name = "txtnewPass";
            txtnewPass.Size = new Size(155, 27);
            txtnewPass.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 4;
            label2.Text = "Nhập mật khẩu cũ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(3, 95);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 5;
            label3.Text = "Nhập mật khẩu mới";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(3, 190);
            label4.Name = "label4";
            label4.Size = new Size(137, 20);
            label4.TabIndex = 6;
            label4.Text = "Nhập lại mật khẩu";
            // 
            // txtPassOld
            // 
            txtPassOld.Location = new Point(157, 3);
            txtPassOld.Name = "txtPassOld";
            txtPassOld.Size = new Size(155, 27);
            txtPassOld.TabIndex = 7;
            // 
            // btnPass
            // 
            btnPass.Location = new Point(318, 98);
            btnPass.Name = "btnPass";
            btnPass.Size = new Size(36, 29);
            btnPass.TabIndex = 10;
            btnPass.UseVisualStyleBackColor = true;
            btnPass.Click += btnPass_Click;
            // 
            // btnPassAgain
            // 
            btnPassAgain.Location = new Point(318, 193);
            btnPassAgain.Name = "btnPassAgain";
            btnPassAgain.Size = new Size(36, 29);
            btnPassAgain.TabIndex = 11;
            btnPassAgain.UseVisualStyleBackColor = true;
            btnPassAgain.Click += btnPassAgain_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(313, 27);
            label1.Name = "label1";
            label1.Size = new Size(306, 28);
            label1.TabIndex = 2;
            label1.Text = "Thay đổi mật khẩu người dùng";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(384, 446);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(129, 20);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Quay lại trang chủ";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button1
            // 
            button1.Location = new Point(374, 389);
            button1.Name = "button1";
            button1.Size = new Size(139, 41);
            button1.TabIndex = 4;
            button1.Text = "Đổi mật khẩu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ChangePasswordUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 475);
            Controls.Add(button1);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pictureBox1);
            MaximizeBox = false;
            Name = "ChangePasswordUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangePasswordUser";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtnewPassAgian;
        private TextBox txtnewPass;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtPassOld;
        private Label label1;
        private LinkLabel linkLabel1;
        private Button btnPassOld;
        private Button btnPass;
        private Button btnPassAgain;
        private Button button1;
    }
}