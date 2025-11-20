namespace StaffForm
{
    partial class TimNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimNhanVien));
            label1 = new Label();
            dgvNhanVien = new DataGridView();
            txtMa = new TextBox();
            label2 = new Label();
            btnTim = new Button();
            btnLoadAll = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(505, 19);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(248, 41);
            label1.TabIndex = 0;
            label1.Text = "Tìm Nhân Viên";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(13, 160);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 62;
            dgvNhanVien.Size = new Size(1189, 241);
            dgvNhanVien.TabIndex = 1;
            // 
            // txtMa
            // 
            txtMa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMa.Location = new Point(369, 108);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(482, 35);
            txtMa.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(13, 111);
            label2.Name = "label2";
            label2.Size = new Size(325, 26);
            label2.TabIndex = 3;
            label2.Text = "Nhập Mã Nhân Viên Cần Tìm:";
            // 
            // btnTim
            // 
            btnTim.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Location = new Point(897, 107);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(246, 33);
            btnTim.TabIndex = 4;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnLoadAll
            // 
            btnLoadAll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLoadAll.Location = new Point(956, 406);
            btnLoadAll.Name = "btnLoadAll";
            btnLoadAll.Size = new Size(246, 65);
            btnLoadAll.TabIndex = 5;
            btnLoadAll.Text = "Load lại dữ liệu";
            btnLoadAll.UseVisualStyleBackColor = true;
            btnLoadAll.Click += btnLoadAll_Click;
            // 
            // TimNhanVien
            // 
            AutoScaleDimensions = new SizeF(14F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1215, 468);
            Controls.Add(btnLoadAll);
            Controls.Add(btnTim);
            Controls.Add(label2);
            Controls.Add(txtMa);
            Controls.Add(dgvNhanVien);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "TimNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TimNhanVien";
            FormClosing += TimNhanVien_FormClosing;
            Load += TimNhanVien_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvNhanVien;
        private TextBox txtMa;
        private Label label2;
        private Button btnTim;
        private Button btnLoadAll;
    }
}