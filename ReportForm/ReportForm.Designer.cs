namespace ReportForm
{
    partial class ReportForm
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
            label1 = new Label();
            label2 = new Label();
            tableLayout = new TableLayoutPanel();
            cboloaive = new ComboBox();
            cboMovie = new ComboBox();
            dateEnd = new DateTimePicker();
            dataStart = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            label3 = new Label();
            label6 = new Label();
            dgv = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtTotal = new TextBox();
            label7 = new Label();
            btnIn = new Button();
            btnFilter = new Button();
            btnreload = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(916, 38);
            label1.TabIndex = 0;
            label1.Text = "THỐNG KÊ DOANH THU";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(75, 23);
            label2.TabIndex = 1;
            label2.Text = "Từ ngày";
            // 
            // tableLayout
            // 
            tableLayout.Anchor = AnchorStyles.Top;
            tableLayout.ColumnCount = 4;
            tableLayout.ColumnStyles.Add(new ColumnStyle());
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayout.ColumnStyles.Add(new ColumnStyle());
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayout.Controls.Add(cboloaive, 3, 1);
            tableLayout.Controls.Add(cboMovie, 1, 1);
            tableLayout.Controls.Add(dateEnd, 3, 0);
            tableLayout.Controls.Add(dataStart, 1, 0);
            tableLayout.Controls.Add(label4, 2, 1);
            tableLayout.Controls.Add(label2, 0, 0);
            tableLayout.Controls.Add(label5, 2, 0);
            tableLayout.Controls.Add(label3, 0, 1);
            tableLayout.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tableLayout.ForeColor = SystemColors.ActiveCaptionText;
            tableLayout.Location = new Point(12, 41);
            tableLayout.Name = "tableLayout";
            tableLayout.RowCount = 2;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayout.Size = new Size(892, 89);
            tableLayout.TabIndex = 2;
            // 
            // cboloaive
            // 
            cboloaive.FormattingEnabled = true;
            cboloaive.Location = new Point(535, 47);
            cboloaive.Name = "cboloaive";
            cboloaive.Size = new Size(329, 31);
            cboloaive.TabIndex = 7;
            // 
            // cboMovie
            // 
            cboMovie.FormattingEnabled = true;
            cboMovie.Location = new Point(84, 47);
            cboMovie.Name = "cboMovie";
            cboMovie.Size = new Size(329, 31);
            cboMovie.TabIndex = 3;
            // 
            // dateEnd
            // 
            dateEnd.CustomFormat = "dd/MM/yyyy";
            dateEnd.Format = DateTimePickerFormat.Custom;
            dateEnd.Location = new Point(535, 3);
            dateEnd.Name = "dateEnd";
            dateEnd.Size = new Size(329, 30);
            dateEnd.TabIndex = 6;
            // 
            // dataStart
            // 
            dataStart.CustomFormat = "dd/MM/yyyy";
            dataStart.Format = DateTimePickerFormat.Custom;
            dataStart.Location = new Point(84, 3);
            dataStart.Name = "dataStart";
            dataStart.Size = new Size(329, 30);
            dataStart.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(443, 44);
            label4.Name = "label4";
            label4.Size = new Size(66, 23);
            label4.TabIndex = 5;
            label4.Text = "Loại vé";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(443, 0);
            label5.Name = "label5";
            label5.Size = new Size(86, 23);
            label5.TabIndex = 4;
            label5.Text = "Đến ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 44);
            label3.Name = "label3";
            label3.Size = new Size(56, 23);
            label3.TabIndex = 3;
            label3.Text = "Phim ";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Blue;
            label6.Location = new Point(0, 133);
            label6.Name = "label6";
            label6.Size = new Size(916, 38);
            label6.TabIndex = 3;
            label6.Text = "KẾT QUẢ";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(12, 174);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(892, 246);
            dgv.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(txtTotal, 1, 0);
            tableLayoutPanel1.Controls.Add(label7, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 426);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(892, 43);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTotal.ForeColor = Color.Blue;
            txtTotal.Location = new Point(449, 3);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(440, 30);
            txtTotal.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(149, 25);
            label7.TabIndex = 6;
            label7.Text = "Tổng doanh thu";
            // 
            // btnIn
            // 
            btnIn.Location = new Point(251, 475);
            btnIn.Name = "btnIn";
            btnIn.Size = new Size(206, 56);
            btnIn.TabIndex = 6;
            btnIn.Text = "In dữ liệu Excel";
            btnIn.UseVisualStyleBackColor = true;
            btnIn.Click += btnIn_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(12, 136);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 9;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnreload
            // 
            btnreload.Location = new Point(123, 133);
            btnreload.Name = "btnreload";
            btnreload.Size = new Size(113, 29);
            btnreload.TabIndex = 10;
            btnreload.Text = "Tải lại tất cả";
            btnreload.UseVisualStyleBackColor = true;
            btnreload.Click += btnreload_Click;
            // 
            // button1
            // 
            button1.Location = new Point(667, 475);
            button1.Name = "button1";
            button1.Size = new Size(206, 56);
            button1.TabIndex = 11;
            button1.Text = "Đóng";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(43, 475);
            button2.Name = "button2";
            button2.Size = new Size(206, 56);
            button2.TabIndex = 12;
            button2.Text = "In dữ liệu PDF";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(459, 475);
            button3.Name = "button3";
            button3.Size = new Size(206, 56);
            button3.TabIndex = 13;
            button3.Text = "Xem In";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 562);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnreload);
            Controls.Add(btnFilter);
            Controls.Add(btnIn);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(dgv);
            Controls.Add(label6);
            Controls.Add(tableLayout);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReportForm";
            Load += ReportForm_Load;
            tableLayout.ResumeLayout(false);
            tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private TableLayoutPanel tableLayout;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cboloaive;
        private ComboBox cboMovie;
        private DateTimePicker dateEnd;
        private DateTimePicker dataStart;
        private Label label6;
        private DataGridView dgv;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox txtTotal;
        private Label label7;
        private Button btnIn;
        private Button btnFilter;
        private Button btnreload;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
