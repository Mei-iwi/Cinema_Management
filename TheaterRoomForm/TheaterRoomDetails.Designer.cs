namespace TheaterRoomForm
{
    partial class TheaterRoomDetails
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
            components = new System.ComponentModel.Container();
            btnDelete = new Button();
            label4 = new Label();
            btnUpdate = new Button();
            btnAdd = new Button();
            label3 = new Label();
            label2 = new Label();
            btnSave = new Button();
            btnClose = new Button();
            grpDetails = new GroupBox();
            txtMaGhe = new TextBox();
            cboLoaiGhe = new ComboBox();
            dgv_Chair = new DataGridView();
            lblName = new Label();
            errorProvider = new ErrorProvider(components);
            cboMaPHong = new ComboBox();
            grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Chair).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnDelete.Location = new Point(186, 166);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(143, 51);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "&Xóa ghế";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(432, 48);
            label4.Name = "label4";
            label4.Size = new Size(78, 23);
            label4.TabIndex = 23;
            label4.Text = "Loại ghế";
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnUpdate.Location = new Point(353, 166);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(168, 51);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "&Cập nhật ghế";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnAdd.Location = new Point(18, 166);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 51);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "&Thêm ghế";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(50, 101);
            label3.Name = "label3";
            label3.Size = new Size(61, 23);
            label3.TabIndex = 22;
            label3.Text = "Phòng";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(50, 44);
            label2.Name = "label2";
            label2.Size = new Size(70, 23);
            label2.TabIndex = 21;
            label2.Text = "Mã ghế";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnSave.Location = new Point(545, 166);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(168, 51);
            btnSave.TabIndex = 19;
            btnSave.Text = "&Lưu thông tin";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnClose.Location = new Point(744, 166);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(122, 51);
            btnClose.TabIndex = 24;
            btnClose.Text = "&Quay lại";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // grpDetails
            // 
            grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpDetails.Controls.Add(cboMaPHong);
            grpDetails.Controls.Add(txtMaGhe);
            grpDetails.Controls.Add(cboLoaiGhe);
            grpDetails.Controls.Add(btnClose);
            grpDetails.Controls.Add(btnSave);
            grpDetails.Controls.Add(label2);
            grpDetails.Controls.Add(label3);
            grpDetails.Controls.Add(btnAdd);
            grpDetails.Controls.Add(btnUpdate);
            grpDetails.Controls.Add(label4);
            grpDetails.Controls.Add(btnDelete);
            grpDetails.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDetails.Location = new Point(11, 44);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(889, 233);
            grpDetails.TabIndex = 26;
            grpDetails.TabStop = false;
            grpDetails.Text = "Thông tin ghế'";
            // 
            // txtMaGhe
            // 
            txtMaGhe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtMaGhe.BorderStyle = BorderStyle.FixedSingle;
            txtMaGhe.Location = new Point(148, 41);
            txtMaGhe.Name = "txtMaGhe";
            txtMaGhe.Size = new Size(262, 30);
            txtMaGhe.TabIndex = 28;
            // 
            // cboLoaiGhe
            // 
            cboLoaiGhe.FormattingEnabled = true;
            cboLoaiGhe.Location = new Point(528, 36);
            cboLoaiGhe.Name = "cboLoaiGhe";
            cboLoaiGhe.Size = new Size(262, 31);
            cboLoaiGhe.TabIndex = 27;
            // 
            // dgv_Chair
            // 
            dgv_Chair.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Chair.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Chair.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_Chair.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Chair.Location = new Point(14, 283);
            dgv_Chair.Name = "dgv_Chair";
            dgv_Chair.RowHeadersWidth = 51;
            dgv_Chair.Size = new Size(886, 324);
            dgv_Chair.TabIndex = 27;
            dgv_Chair.CellClick += dgv_Chair_CellClick;
            // 
            // lblName
            // 
            lblName.Dock = DockStyle.Top;
            lblName.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.Blue;
            lblName.Location = new Point(0, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(912, 41);
            lblName.TabIndex = 28;
            lblName.Text = "Unknown";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // cboMaPHong
            // 
            cboMaPHong.FormattingEnabled = true;
            cboMaPHong.Location = new Point(148, 101);
            cboMaPHong.Name = "cboMaPHong";
            cboMaPHong.Size = new Size(262, 31);
            cboMaPHong.TabIndex = 29;
            // 
            // TheaterRoomDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 624);
            Controls.Add(lblName);
            Controls.Add(dgv_Chair);
            Controls.Add(grpDetails);
            Name = "TheaterRoomDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TheaterRoomDetails";
            Load += TheaterRoomDetails_Load;
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Chair).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDelete;
        private Label label4;
        private NumericUpDown numAmount;
        private Button btnUpdate;
        private Button btnAdd;
        private Label label3;
        private Label label2;
        private Button btnSave;
        private Button btnClose;
        private GroupBox grpDetails;
        private DataGridView dgv_Chair;
        private Label lblName;
        private ComboBox cboLoaiGhe;
        private ErrorProvider errorProvider;
        private TextBox txtMaGhe;
        private ComboBox cboMaPHong;
    }
}