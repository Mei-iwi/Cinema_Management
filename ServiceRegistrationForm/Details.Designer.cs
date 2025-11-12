namespace ServiceRegistrationForm
{
    partial class Details
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Details));
            pic = new PictureBox();
            groupBox1 = new GroupBox();
            lblTT = new Label();
            lblSL = new Label();
            lblDonGia = new Label();
            lblTen = new Label();
            lblMa = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnThoat = new Button();
            ((System.ComponentModel.ISupportInitialize)pic).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pic
            // 
            pic.BorderStyle = BorderStyle.FixedSingle;
            pic.Enabled = false;
            pic.Image = (Image)resources.GetObject("pic.Image");
            pic.Location = new Point(24, 30);
            pic.Name = "pic";
            pic.Size = new Size(274, 333);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.TabIndex = 21;
            pic.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTT);
            groupBox1.Controls.Add(lblSL);
            groupBox1.Controls.Add(lblDonGia);
            groupBox1.Controls.Add(lblTen);
            groupBox1.Controls.Add(lblMa);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Red;
            groupBox1.Location = new Point(318, 30);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(515, 333);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hóa đơn";
            // 
            // lblTT
            // 
            lblTT.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblTT.ForeColor = Color.Black;
            lblTT.Location = new Point(169, 292);
            lblTT.Name = "lblTT";
            lblTT.Size = new Size(327, 25);
            lblTT.TabIndex = 51;
            lblTT.Text = "Thông tin ở đây";
            lblTT.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSL
            // 
            lblSL.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblSL.ForeColor = Color.Black;
            lblSL.Location = new Point(169, 229);
            lblSL.Name = "lblSL";
            lblSL.Size = new Size(327, 25);
            lblSL.TabIndex = 50;
            lblSL.Text = "Thông tin ở đây";
            lblSL.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDonGia
            // 
            lblDonGia.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblDonGia.ForeColor = Color.Black;
            lblDonGia.Location = new Point(169, 166);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(327, 25);
            lblDonGia.TabIndex = 49;
            lblDonGia.Text = "Thông tin ở đây";
            lblDonGia.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTen
            // 
            lblTen.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblTen.ForeColor = Color.Black;
            lblTen.Location = new Point(169, 103);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(327, 25);
            lblTen.TabIndex = 48;
            lblTen.Text = "Thông tin ở đây";
            lblTen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMa
            // 
            lblMa.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            lblMa.ForeColor = Color.Black;
            lblMa.Location = new Point(169, 40);
            lblMa.Name = "lblMa";
            lblMa.Size = new Size(327, 25);
            lblMa.TabIndex = 47;
            lblMa.Text = "Thông tin ở đây";
            lblMa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(15, 292);
            label5.Name = "label5";
            label5.Size = new Size(148, 25);
            label5.TabIndex = 46;
            label5.Text = "Thành tiền:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(15, 229);
            label4.Name = "label4";
            label4.Size = new Size(148, 25);
            label4.TabIndex = 45;
            label4.Text = "Số lượng:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(15, 166);
            label3.Name = "label3";
            label3.Size = new Size(148, 25);
            label3.TabIndex = 44;
            label3.Text = "Đơn giá: ";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(15, 103);
            label2.Name = "label2";
            label2.Size = new Size(148, 25);
            label2.TabIndex = 43;
            label2.Text = "Tên sản phẩm:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(15, 40);
            label1.Name = "label1";
            label1.Size = new Size(148, 25);
            label1.TabIndex = 42;
            label1.Text = "Mã sản phẩm:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.ForeColor = Color.Red;
            btnThoat.Location = new Point(686, 369);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(147, 44);
            btnThoat.TabIndex = 23;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // Details
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 419);
            Controls.Add(btnThoat);
            Controls.Add(groupBox1);
            Controls.Add(pic);
            MinimizeBox = false;
            Name = "Details";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detials";
            Load += Detials_Load;
            ((System.ComponentModel.ISupportInitialize)pic).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pic;
        private GroupBox groupBox1;
        private Label lblTT;
        private Label lblSL;
        private Label lblDonGia;
        private Label lblTen;
        private Label lblMa;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnThoat;
    }
}