namespace TicketTypeForm
{
    partial class TicketTypeForm
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
            grpInfo = new GroupBox();
            txtLoaiGhe = new TextBox();
            label8 = new Label();
            txtDonGia = new TextBox();
            txtTenVe = new TextBox();
            txtMaLV = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            grpChucnag = new GroupBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            dgv_Ve = new DataGridView();
            label11 = new Label();
            errorProvider = new ErrorProvider(components);
            grpInfo.SuspendLayout();
            grpChucnag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Ve).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Top;
            grpInfo.Controls.Add(txtLoaiGhe);
            grpInfo.Controls.Add(label8);
            grpInfo.Controls.Add(txtDonGia);
            grpInfo.Controls.Add(txtTenVe);
            grpInfo.Controls.Add(txtMaLV);
            grpInfo.Controls.Add(label3);
            grpInfo.Controls.Add(label2);
            grpInfo.Controls.Add(label1);
            grpInfo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            grpInfo.Location = new Point(62, 50);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(1141, 236);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin loại vé";
            // 
            // txtLoaiGhe
            // 
            txtLoaiGhe.BorderStyle = BorderStyle.FixedSingle;
            txtLoaiGhe.Location = new Point(676, 40);
            txtLoaiGhe.Name = "txtLoaiGhe";
            txtLoaiGhe.Size = new Size(396, 30);
            txtLoaiGhe.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(562, 50);
            label8.Name = "label8";
            label8.Size = new Size(78, 23);
            label8.TabIndex = 21;
            label8.Text = "Loại ghế";
            // 
            // txtDonGia
            // 
            txtDonGia.BorderStyle = BorderStyle.FixedSingle;
            txtDonGia.Location = new Point(676, 144);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(396, 30);
            txtDonGia.TabIndex = 6;
            // 
            // txtTenVe
            // 
            txtTenVe.BorderStyle = BorderStyle.FixedSingle;
            txtTenVe.Location = new Point(132, 150);
            txtTenVe.Name = "txtTenVe";
            txtTenVe.Size = new Size(396, 30);
            txtTenVe.TabIndex = 5;
            // 
            // txtMaLV
            // 
            txtMaLV.BorderStyle = BorderStyle.FixedSingle;
            txtMaLV.Location = new Point(132, 50);
            txtMaLV.Name = "txtMaLV";
            txtMaLV.Size = new Size(396, 30);
            txtMaLV.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(562, 150);
            label3.Name = "label3";
            label3.Size = new Size(74, 23);
            label3.TabIndex = 2;
            label3.Text = "Đơn giá";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 153);
            label2.Name = "label2";
            label2.Size = new Size(94, 23);
            label2.TabIndex = 1;
            label2.Text = "Tên loại vé";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 50);
            label1.Name = "label1";
            label1.Size = new Size(92, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã loại vé";
            // 
            // grpChucnag
            // 
            grpChucnag.Anchor = AnchorStyles.Top;
            grpChucnag.Controls.Add(btnSave);
            grpChucnag.Controls.Add(btnUpdate);
            grpChucnag.Controls.Add(btnDelete);
            grpChucnag.Controls.Add(btnAdd);
            grpChucnag.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpChucnag.Location = new Point(62, 292);
            grpChucnag.Name = "grpChucnag";
            grpChucnag.Size = new Size(1141, 85);
            grpChucnag.TabIndex = 1;
            grpChucnag.TabStop = false;
            grpChucnag.Text = "Chức năng";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(804, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(145, 61);
            btnSave.TabIndex = 11;
            btnSave.Text = "Lưu trữ";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(604, 15);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 61);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(399, 15);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 61);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa Vé";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(191, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 61);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgv_Ve
            // 
            dgv_Ve.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Ve.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Ve.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Ve.Location = new Point(62, 383);
            dgv_Ve.Name = "dgv_Ve";
            dgv_Ve.RowHeadersWidth = 51;
            dgv_Ve.Size = new Size(1141, 337);
            dgv_Ve.TabIndex = 2;
            dgv_Ve.CellClick += dgv_Ve_CellClick;
            // 
            // label11
            // 
            label11.Dock = DockStyle.Top;
            label11.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Blue;
            label11.Location = new Point(0, 0);
            label11.Name = "label11";
            label11.Size = new Size(1264, 47);
            label11.TabIndex = 7;
            label11.Text = "QUẢN LÝ LOẠI VÉ";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // TicketTypeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 732);
            Controls.Add(label11);
            Controls.Add(dgv_Ve);
            Controls.Add(grpChucnag);
            Controls.Add(grpInfo);
            Name = "TicketTypeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý loại vé";
            Load += TicketTypeForm_Load;
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpChucnag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Ve).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInfo;
        private GroupBox grpChucnag;
        private DataGridView dgv_Ve;
        private TextBox txtDonGia;
        private TextBox txtTenVe;
        private TextBox txtMaLV;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private Label label11;
        private TextBox txtLoaiGhe;
        private Label label8;
        private ErrorProvider errorProvider;
    }
}
