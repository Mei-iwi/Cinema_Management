namespace ServiceRegistrationForm
{
    partial class ServiceRegistrationForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceRegistrationForm));
            openFileDialog = new OpenFileDialog();
            label1 = new Label();
            errorProvider = new ErrorProvider(components);
            grpChucnag = new GroupBox();
            pictureBox1 = new PictureBox();
            txtLink = new TextBox();
            numSL = new NumericUpDown();
            lbl = new Label();
            txtMaVE = new TextBox();
            txtVe = new Label();
            btnTim = new Button();
            cboDV = new ComboBox();
            btnChitiet = new Button();
            txtTongTien = new TextBox();
            txtDonGia = new TextBox();
            txtSum = new Label();
            lblDG = new Label();
            label2 = new Label();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            dgv_Service = new DataGridView();
            txtTotal = new TextBox();
            label3 = new Label();
            btnReaload = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            grpChucnag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSL).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Service).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(919, 42);
            label1.TabIndex = 9;
            label1.Text = "ĐĂNG KÝ DỊCH VỤ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // grpChucnag
            // 
            grpChucnag.Anchor = AnchorStyles.Top;
            grpChucnag.Controls.Add(numSL);
            grpChucnag.Controls.Add(lbl);
            grpChucnag.Controls.Add(txtMaVE);
            grpChucnag.Controls.Add(txtVe);
            grpChucnag.Controls.Add(btnTim);
            grpChucnag.Controls.Add(cboDV);
            grpChucnag.Controls.Add(btnChitiet);
            grpChucnag.Controls.Add(txtTongTien);
            grpChucnag.Controls.Add(txtDonGia);
            grpChucnag.Controls.Add(txtSum);
            grpChucnag.Controls.Add(lblDG);
            grpChucnag.Controls.Add(label2);
            grpChucnag.Controls.Add(btnSave);
            grpChucnag.Controls.Add(btnUpdate);
            grpChucnag.Controls.Add(btnDelete);
            grpChucnag.Controls.Add(btnAdd);
            grpChucnag.Controls.Add(pictureBox1);
            grpChucnag.Controls.Add(txtLink);
            grpChucnag.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpChucnag.Location = new Point(19, 45);
            grpChucnag.Name = "grpChucnag";
            grpChucnag.Size = new Size(881, 327);
            grpChucnag.TabIndex = 14;
            grpChucnag.TabStop = false;
            grpChucnag.Text = "Chức năng";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Enabled = false;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(533, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(304, 192);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // txtLink
            // 
            txtLink.Location = new Point(632, 115);
            txtLink.Name = "txtLink";
            txtLink.Size = new Size(125, 30);
            txtLink.TabIndex = 27;
            txtLink.TextChanged += txtLink_TextChanged;
            // 
            // numSL
            // 
            numSL.Location = new Point(367, 134);
            numSL.Name = "numSL";
            numSL.Size = new Size(78, 30);
            numSL.TabIndex = 26;
            numSL.ValueChanged += numSL_ValueChanged;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(287, 136);
            lbl.Name = "lbl";
            lbl.Size = new Size(83, 23);
            lbl.TabIndex = 25;
            lbl.Text = "Số lượng";
            // 
            // txtMaVE
            // 
            txtMaVE.BorderStyle = BorderStyle.FixedSingle;
            txtMaVE.Location = new Point(120, 38);
            txtMaVE.Name = "txtMaVE";
            txtMaVE.Size = new Size(325, 30);
            txtMaVE.TabIndex = 24;
            txtMaVE.TextChanged += txtMaVE_TextChanged;
            // 
            // txtVe
            // 
            txtVe.AutoSize = true;
            txtVe.Location = new Point(18, 40);
            txtVe.Name = "txtVe";
            txtVe.Size = new Size(29, 23);
            txtVe.TabIndex = 23;
            txtVe.Text = "Vé";
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Top;
            btnTim.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnTim.ForeColor = Color.Blue;
            btnTim.Location = new Point(454, 40);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(70, 29);
            btnTim.TabIndex = 22;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // cboDV
            // 
            cboDV.FormattingEnabled = true;
            cboDV.Location = new Point(120, 85);
            cboDV.Name = "cboDV";
            cboDV.Size = new Size(325, 31);
            cboDV.TabIndex = 21;
            cboDV.SelectedIndexChanged += cboDV_SelectedIndexChanged;
            // 
            // btnChitiet
            // 
            btnChitiet.Anchor = AnchorStyles.Top;
            btnChitiet.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnChitiet.ForeColor = Color.Blue;
            btnChitiet.Location = new Point(758, 182);
            btnChitiet.Name = "btnChitiet";
            btnChitiet.Size = new Size(70, 29);
            btnChitiet.TabIndex = 5;
            btnChitiet.Text = "Chi tiết";
            btnChitiet.UseVisualStyleBackColor = true;
            btnChitiet.Click += btnChitiet_Click;
            // 
            // txtTongTien
            // 
            txtTongTien.BorderStyle = BorderStyle.FixedSingle;
            txtTongTien.Location = new Point(120, 184);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(158, 30);
            txtTongTien.TabIndex = 19;
            // 
            // txtDonGia
            // 
            txtDonGia.BorderStyle = BorderStyle.FixedSingle;
            txtDonGia.Location = new Point(120, 136);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(158, 30);
            txtDonGia.TabIndex = 18;
            // 
            // txtSum
            // 
            txtSum.AutoSize = true;
            txtSum.Location = new Point(18, 184);
            txtSum.Name = "txtSum";
            txtSum.Size = new Size(87, 23);
            txtSum.TabIndex = 15;
            txtSum.Text = "Tổng tiền";
            // 
            // lblDG
            // 
            lblDG.AutoSize = true;
            lblDG.Location = new Point(18, 136);
            lblDG.Name = "lblDG";
            lblDG.Size = new Size(74, 23);
            lblDG.TabIndex = 14;
            lblDG.Text = "Đơn giá";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 93);
            label2.Name = "label2";
            label2.Size = new Size(70, 23);
            label2.TabIndex = 12;
            label2.Text = "Dịch vụ";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(654, 243);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(186, 61);
            btnSave.TabIndex = 11;
            btnSave.Text = "Lưu hóa đơn";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(454, 243);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(186, 61);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Cập nhật hóa đơn";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(249, 243);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(186, 61);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa hóa đơn";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(41, 243);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(186, 61);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Lập hóa đơn";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgv_Service
            // 
            dgv_Service.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Service.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Service.Location = new Point(19, 378);
            dgv_Service.Name = "dgv_Service";
            dgv_Service.RowHeadersWidth = 51;
            dgv_Service.Size = new Size(881, 339);
            dgv_Service.TabIndex = 13;
            dgv_Service.CellClick += dgv_Service_CellClick;
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTotal.ForeColor = Color.Blue;
            txtTotal.Location = new Point(689, 726);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(211, 27);
            txtTotal.TabIndex = 28;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(510, 730);
            label3.Name = "label3";
            label3.Size = new Size(178, 23);
            label3.TabIndex = 27;
            label3.Text = "Tổng chi phí dịch vụ:";
            // 
            // btnReaload
            // 
            btnReaload.Anchor = AnchorStyles.Top;
            btnReaload.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            btnReaload.ForeColor = Color.Blue;
            btnReaload.Location = new Point(19, 726);
            btnReaload.Name = "btnReaload";
            btnReaload.Size = new Size(70, 29);
            btnReaload.TabIndex = 29;
            btnReaload.Text = "Tải lại";
            btnReaload.UseVisualStyleBackColor = true;
            btnReaload.Click += btnReaload_Click;
            // 
            // ServiceRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 762);
            Controls.Add(btnReaload);
            Controls.Add(txtTotal);
            Controls.Add(label3);
            Controls.Add(grpChucnag);
            Controls.Add(dgv_Service);
            Controls.Add(label1);
            Name = "ServiceRegistrationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServiceRegistrationForm";
            Load += ServiceRegistrationForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            grpChucnag.ResumeLayout(false);
            grpChucnag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSL).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Service).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog;
        private Label label1;
        private ErrorProvider errorProvider;
        private GroupBox grpChucnag;
        private Button btnChitiet;
        private PictureBox pictureBox1;
        private TextBox txtDonGia;
        private Label lblDG;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private DataGridView dgv_Service;
        private TextBox txtTongTien;
        private Label txtSum;
        private Label label2;
        private ComboBox cboDV;
        private TextBox txtMaVE;
        private Label txtVe;
        private Button btnTim;
        private NumericUpDown numSL;
        private Label lbl;
        private TextBox txtTotal;
        private Label label3;
        private Button btnReaload;
        private TextBox txtLink;
    }
}
