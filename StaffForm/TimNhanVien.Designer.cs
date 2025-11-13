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
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(469, 20);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(248, 41);
            label1.TabIndex = 0;
            label1.Text = "Tìm Nhân Viên";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(12, 166);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 62;
            dgvNhanVien.Size = new Size(1104, 250);
            dgvNhanVien.TabIndex = 1;
            // 
            // txtMa
            // 
            txtMa.Location = new Point(343, 112);
            txtMa.Name = "txtMa";
            txtMa.Size = new Size(448, 35);
            txtMa.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 115);
            label2.Name = "label2";
            label2.Size = new Size(305, 27);
            label2.TabIndex = 3;
            label2.Text = "Nhập Mã Nhân Viên Cần Tìm:";
            // 
            // btnTim
            // 
            btnTim.FlatStyle = FlatStyle.Flat;
            btnTim.Location = new Point(833, 111);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(228, 34);
            btnTim.TabIndex = 4;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnLoadAll
            // 
            btnLoadAll.Location = new Point(888, 422);
            btnLoadAll.Name = "btnLoadAll";
            btnLoadAll.Size = new Size(228, 67);
            btnLoadAll.TabIndex = 5;
            btnLoadAll.Text = "Load lại dữ liệu";
            btnLoadAll.UseVisualStyleBackColor = true;
            btnLoadAll.Click += btnLoadAll_Click;
            // 
            // TimNhanVien
            // 
            AutoScaleDimensions = new SizeF(13F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 486);
            Controls.Add(btnLoadAll);
            Controls.Add(btnTim);
            Controls.Add(label2);
            Controls.Add(txtMa);
            Controls.Add(dgvNhanVien);
            Controls.Add(label1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 3, 4, 3);
            Name = "TimNhanVien";
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