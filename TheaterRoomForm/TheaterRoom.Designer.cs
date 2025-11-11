namespace TheaterRoomForm
{
    partial class TheaterRoom
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
            label1 = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnDetails = new Button();
            txtName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            numAmount = new NumericUpDown();
            btnClose = new Button();
            grpDetails = new GroupBox();
            txtID = new TextBox();
            btnSave = new Button();
            dgv_TheaterRoom = new DataGridView();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numAmount).BeginInit();
            grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_TheaterRoom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(971, 41);
            label1.TabIndex = 0;
            label1.Text = "DANH SÁCH CÁC PHÒNG CHIẾU";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnAdd.Location = new Point(6, 145);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(168, 50);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "&Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnDelete.Location = new Point(189, 145);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(168, 50);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "&Xóa phòng";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnUpdate.Location = new Point(374, 145);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(180, 50);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "&Cập nhật phòng";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDetails
            // 
            btnDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnDetails.Location = new Point(734, 145);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(193, 50);
            btnDetails.TabIndex = 7;
            btnDetails.Text = "&Thông tin chi tiết";
            btnDetails.UseVisualStyleBackColor = true;
            btnDetails.Click += btnDetails_Click;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Location = new Point(122, 96);
            txtName.Name = "txtName";
            txtName.Size = new Size(329, 30);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(24, 39);
            label2.Name = "label2";
            label2.Size = new Size(92, 23);
            label2.TabIndex = 8;
            label2.Text = "Mã phòng";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label3.Location = new Point(24, 96);
            label3.Name = "label3";
            label3.Size = new Size(94, 23);
            label3.TabIndex = 9;
            label3.Text = "Tên phòng";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label4.Location = new Point(469, 41);
            label4.Name = "label4";
            label4.Size = new Size(118, 23);
            label4.TabIndex = 10;
            label4.Text = "Số lượng ghế";
            // 
            // numAmount
            // 
            numAmount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            numAmount.BorderStyle = BorderStyle.FixedSingle;
            numAmount.Location = new Point(598, 41);
            numAmount.Name = "numAmount";
            numAmount.Size = new Size(329, 30);
            numAmount.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnClose.Location = new Point(799, 89);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(128, 50);
            btnClose.TabIndex = 12;
            btnClose.Text = "&Thoát";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // grpDetails
            // 
            grpDetails.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpDetails.Controls.Add(txtID);
            grpDetails.Controls.Add(btnSave);
            grpDetails.Controls.Add(btnDetails);
            grpDetails.Controls.Add(btnClose);
            grpDetails.Controls.Add(btnAdd);
            grpDetails.Controls.Add(numAmount);
            grpDetails.Controls.Add(btnDelete);
            grpDetails.Controls.Add(label4);
            grpDetails.Controls.Add(btnUpdate);
            grpDetails.Controls.Add(label3);
            grpDetails.Controls.Add(label2);
            grpDetails.Controls.Add(txtName);
            grpDetails.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDetails.Location = new Point(12, 57);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(947, 217);
            grpDetails.TabIndex = 1;
            grpDetails.TabStop = false;
            grpDetails.Text = "Thông tin phòng chiếu";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            txtID.BorderStyle = BorderStyle.FixedSingle;
            txtID.Location = new Point(122, 36);
            txtID.Name = "txtID";
            txtID.Size = new Size(329, 30);
            txtID.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btnSave.Location = new Point(560, 145);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(168, 50);
            btnSave.TabIndex = 6;
            btnSave.Text = "&Lưu thông tin";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dgv_TheaterRoom
            // 
            dgv_TheaterRoom.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_TheaterRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_TheaterRoom.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_TheaterRoom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_TheaterRoom.Location = new Point(12, 294);
            dgv_TheaterRoom.Name = "dgv_TheaterRoom";
            dgv_TheaterRoom.RowHeadersWidth = 51;
            dgv_TheaterRoom.Size = new Size(947, 282);
            dgv_TheaterRoom.TabIndex = 2;
            dgv_TheaterRoom.CellClick += dgv_TheaterRoom_CellClick;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // TheaterRoom
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(971, 588);
            Controls.Add(dgv_TheaterRoom);
            Controls.Add(grpDetails);
            Controls.Add(label1);
            Name = "TheaterRoom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TheaterRoom";
            FormClosing += TheaterRoom_FormClosing;
            Load += TheaterRoom_Load;
            ((System.ComponentModel.ISupportInitialize)numAmount).EndInit();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_TheaterRoom).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnDetails;
        private TextBox txtName;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnClose;
        private GroupBox grpDetails;
        private DataGridView dgv_TheaterRoom;
        private Button btnSave;
        private TextBox txtID;
        private ErrorProvider errorProvider;
        public NumericUpDown numAmount;
    }
}
