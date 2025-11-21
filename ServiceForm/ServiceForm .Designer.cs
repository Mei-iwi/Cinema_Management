namespace ServiceForm
{
    partial class ServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceForm));
            txtSearch = new TextBox();
            btnSearch = new Button();
            label1 = new Label();
            errorProvider = new ErrorProvider(components);
            openFileDialog = new OpenFileDialog();
            dgv_Service = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnSave = new Button();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaDV = new TextBox();
            txtTenDV = new TextBox();
            txtDonGia = new TextBox();
            txtAh = new TextBox();
            pictureBox1 = new PictureBox();
            btnDuyet = new Button();
            grpChucnag = new GroupBox();
            btnRestart = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Service).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grpChucnag.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top;
            txtSearch.Location = new Point(155, 59);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(373, 27);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top;
            btnSearch.Location = new Point(553, 57);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(913, 42);
            label1.TabIndex = 2;
            label1.Text = "QUẢN LÝ DỊCH VỤ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // dgv_Service
            // 
            dgv_Service.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Service.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Service.Location = new Point(20, 425);
            dgv_Service.Name = "dgv_Service";
            dgv_Service.RowHeadersWidth = 51;
            dgv_Service.Size = new Size(881, 245);
            dgv_Service.TabIndex = 3;
            dgv_Service.CellClick += dgv_Service_CellClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(48, 243);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 61);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(256, 243);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 61);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa dịch vụ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(461, 243);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 61);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(661, 243);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(145, 61);
            btnSave.TabIndex = 11;
            btnSave.Text = "Lưu trữ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 40);
            label2.Name = "label2";
            label2.Size = new Size(98, 23);
            label2.TabIndex = 12;
            label2.Text = "Mã dịch vụ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 88);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 13;
            label3.Text = "Tên dịch vụ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 136);
            label5.Name = "label5";
            label5.Size = new Size(74, 23);
            label5.TabIndex = 14;
            label5.Text = "Đơn giá";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 184);
            label6.Name = "label6";
            label6.Size = new Size(42, 23);
            label6.TabIndex = 15;
            label6.Text = "Ảnh";
            // 
            // txtMaDV
            // 
            txtMaDV.BorderStyle = BorderStyle.FixedSingle;
            txtMaDV.Location = new Point(120, 40);
            txtMaDV.Name = "txtMaDV";
            txtMaDV.Size = new Size(346, 30);
            txtMaDV.TabIndex = 16;
            // 
            // txtTenDV
            // 
            txtTenDV.BorderStyle = BorderStyle.FixedSingle;
            txtTenDV.Location = new Point(120, 88);
            txtTenDV.Name = "txtTenDV";
            txtTenDV.Size = new Size(346, 30);
            txtTenDV.TabIndex = 17;
            // 
            // txtDonGia
            // 
            txtDonGia.BorderStyle = BorderStyle.FixedSingle;
            txtDonGia.Location = new Point(120, 136);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(346, 30);
            txtDonGia.TabIndex = 18;
            // 
            // txtAh
            // 
            txtAh.BorderStyle = BorderStyle.FixedSingle;
            txtAh.Location = new Point(120, 184);
            txtAh.Name = "txtAh";
            txtAh.Size = new Size(253, 30);
            txtAh.TabIndex = 19;
            txtAh.TextChanged += txtAh_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(533, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(304, 192);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // btnDuyet
            // 
            btnDuyet.Anchor = AnchorStyles.Top;
            btnDuyet.Location = new Point(396, 181);
            btnDuyet.Name = "btnDuyet";
            btnDuyet.Size = new Size(70, 29);
            btnDuyet.TabIndex = 5;
            btnDuyet.Text = "...";
            btnDuyet.UseVisualStyleBackColor = true;
            btnDuyet.Click += btnDuyet_Click;
            // 
            // grpChucnag
            // 
            grpChucnag.Anchor = AnchorStyles.Top;
            grpChucnag.Controls.Add(btnDuyet);
            grpChucnag.Controls.Add(pictureBox1);
            grpChucnag.Controls.Add(txtAh);
            grpChucnag.Controls.Add(txtDonGia);
            grpChucnag.Controls.Add(txtTenDV);
            grpChucnag.Controls.Add(txtMaDV);
            grpChucnag.Controls.Add(label6);
            grpChucnag.Controls.Add(label5);
            grpChucnag.Controls.Add(label3);
            grpChucnag.Controls.Add(label2);
            grpChucnag.Controls.Add(btnSave);
            grpChucnag.Controls.Add(btnUpdate);
            grpChucnag.Controls.Add(btnDelete);
            grpChucnag.Controls.Add(btnAdd);
            grpChucnag.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpChucnag.Location = new Point(20, 92);
            grpChucnag.Name = "grpChucnag";
            grpChucnag.Size = new Size(881, 327);
            grpChucnag.TabIndex = 6;
            grpChucnag.TabStop = false;
            grpChucnag.Text = "Chức năng";
            // 
            // btnRestart
            // 
            btnRestart.Anchor = AnchorStyles.Top;
            btnRestart.Location = new Point(663, 57);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(94, 29);
            btnRestart.TabIndex = 5;
            btnRestart.Text = "Tất cả";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // ServiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 682);
            Controls.Add(grpChucnag);
            Controls.Add(btnRestart);
            Controls.Add(dgv_Service);
            Controls.Add(label1);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Name = "ServiceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ServiceForm ";
            Load += ServiceForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_Service).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grpChucnag.ResumeLayout(false);
            grpChucnag.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btnSearch;
        private Label label1;
        private ErrorProvider errorProvider;
        private OpenFileDialog openFileDialog;
        private GroupBox grpChucnag;
        private Button btnDuyet;
        private PictureBox pictureBox1;
        private TextBox txtAh;
        private TextBox txtDonGia;
        private TextBox txtTenDV;
        private TextBox txtMaDV;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnRestart;
        private DataGridView dgv_Service;
    }
}
