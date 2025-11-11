namespace TicketTypeForm
{
    partial class Form1
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
            grpInfo = new GroupBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            grpSuat = new GroupBox();
            dateTimePicker3 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            textBox9 = new TextBox();
            label10 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label9 = new Label();
            label4 = new Label();
            textBox6 = new TextBox();
            label5 = new Label();
            textBox7 = new TextBox();
            label6 = new Label();
            textBox8 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            grpChucnag = new GroupBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            dgv_Ve = new DataGridView();
            btnClose = new Button();
            label11 = new Label();
            grpInfo.SuspendLayout();
            grpSuat.SuspendLayout();
            grpChucnag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Ve).BeginInit();
            SuspendLayout();
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Top;
            grpInfo.Controls.Add(textBox3);
            grpInfo.Controls.Add(textBox2);
            grpInfo.Controls.Add(textBox1);
            grpInfo.Controls.Add(label3);
            grpInfo.Controls.Add(label2);
            grpInfo.Controls.Add(label1);
            grpInfo.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            grpInfo.Location = new Point(12, 50);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(596, 260);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin loại vé";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(101, 191);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(473, 30);
            textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(101, 117);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(473, 30);
            textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(101, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(473, 30);
            textBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 191);
            label3.Name = "label3";
            label3.Size = new Size(74, 23);
            label3.TabIndex = 2;
            label3.Text = "Đơn giá";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 117);
            label2.Name = "label2";
            label2.Size = new Size(94, 23);
            label2.TabIndex = 1;
            label2.Text = "Tên loại vé";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 40);
            label1.Name = "label1";
            label1.Size = new Size(92, 23);
            label1.TabIndex = 0;
            label1.Text = "Mã loại vé";
            // 
            // grpSuat
            // 
            grpSuat.Anchor = AnchorStyles.Top;
            grpSuat.Controls.Add(dateTimePicker3);
            grpSuat.Controls.Add(dateTimePicker2);
            grpSuat.Controls.Add(textBox9);
            grpSuat.Controls.Add(label10);
            grpSuat.Controls.Add(dateTimePicker1);
            grpSuat.Controls.Add(label9);
            grpSuat.Controls.Add(label4);
            grpSuat.Controls.Add(textBox6);
            grpSuat.Controls.Add(label5);
            grpSuat.Controls.Add(textBox7);
            grpSuat.Controls.Add(label6);
            grpSuat.Controls.Add(textBox8);
            grpSuat.Controls.Add(label8);
            grpSuat.Controls.Add(label7);
            grpSuat.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            grpSuat.Location = new Point(614, 50);
            grpSuat.Name = "grpSuat";
            grpSuat.Size = new Size(627, 260);
            grpSuat.TabIndex = 1;
            grpSuat.TabStop = false;
            grpSuat.Text = "Suất chiếu áp dụng";
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.CustomFormat = "HH:mm";
            dateTimePicker3.DropDownAlign = LeftRightAlignment.Right;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.Location = new Point(484, 160);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.RightToLeft = RightToLeft.No;
            dateTimePicker3.Size = new Size(113, 30);
            dateTimePicker3.TabIndex = 19;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "HH:mm";
            dateTimePicker2.DropDownAlign = LeftRightAlignment.Right;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(245, 166);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.RightToLeft = RightToLeft.No;
            dateTimePicker2.Size = new Size(113, 30);
            dateTimePicker2.TabIndex = 18;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(481, 211);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(116, 30);
            textBox9.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(377, 214);
            label10.Name = "label10";
            label10.Size = new Size(83, 23);
            label10.TabIndex = 16;
            label10.Text = "Số lượng";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.DropDownAlign = LeftRightAlignment.Right;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(148, 209);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(210, 30);
            dateTimePicker1.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 214);
            label9.Name = "label9";
            label9.Size = new Size(99, 23);
            label9.TabIndex = 14;
            label9.Text = "Ngày chiếu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(377, 166);
            label4.Name = "label4";
            label4.Size = new Size(109, 23);
            label4.TabIndex = 12;
            label4.Text = "Giờ kết thúc";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(138, 114);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(459, 30);
            textBox6.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(134, 166);
            label5.Name = "label5";
            label5.Size = new Size(105, 23);
            label5.TabIndex = 7;
            label5.Text = "Giờ bắt đầu";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(138, 73);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(459, 30);
            textBox7.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 117);
            label6.Name = "label6";
            label6.Size = new Size(82, 23);
            label6.TabIndex = 6;
            label6.Text = "Mã phim";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(138, 34);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(459, 30);
            textBox8.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 40);
            label8.Name = "label8";
            label8.Size = new Size(123, 23);
            label8.TabIndex = 4;
            label8.Text = "Mã Suất chiếu";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 76);
            label7.Name = "label7";
            label7.Size = new Size(92, 23);
            label7.TabIndex = 5;
            label7.Text = "Mã phòng";
            // 
            // grpChucnag
            // 
            grpChucnag.Anchor = AnchorStyles.Top;
            grpChucnag.Controls.Add(btnSave);
            grpChucnag.Controls.Add(btnUpdate);
            grpChucnag.Controls.Add(btnDelete);
            grpChucnag.Controls.Add(btnAdd);
            grpChucnag.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpChucnag.Location = new Point(215, 316);
            grpChucnag.Name = "grpChucnag";
            grpChucnag.Size = new Size(757, 76);
            grpChucnag.TabIndex = 1;
            grpChucnag.TabStop = false;
            grpChucnag.Text = "Chức năng";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(581, 26);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(145, 44);
            btnSave.TabIndex = 11;
            btnSave.Text = "Lưu trữ";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(400, 26);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(145, 44);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(218, 26);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(145, 44);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa Vé";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(40, 26);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(145, 44);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // dgv_Ve
            // 
            dgv_Ve.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Ve.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Ve.Location = new Point(12, 398);
            dgv_Ve.Name = "dgv_Ve";
            dgv_Ve.RowHeadersWidth = 51;
            dgv_Ve.Size = new Size(1229, 322);
            dgv_Ve.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(1040, 334);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(113, 52);
            btnClose.TabIndex = 6;
            btnClose.Text = "Thoát";
            btnClose.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 732);
            Controls.Add(label11);
            Controls.Add(dgv_Ve);
            Controls.Add(btnClose);
            Controls.Add(grpChucnag);
            Controls.Add(grpSuat);
            Controls.Add(grpInfo);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý loại vé";
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpSuat.ResumeLayout(false);
            grpSuat.PerformLayout();
            grpChucnag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Ve).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpInfo;
        private GroupBox grpSuat;
        private GroupBox grpChucnag;
        private DataGridView dgv_Ve;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox6;
        private Label label5;
        private TextBox textBox7;
        private Label label6;
        private TextBox textBox8;
        private Label label8;
        private Label label7;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label9;
        private Button btnClose;
        private TextBox textBox9;
        private Label label10;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnAdd;
        private Label label11;
        private DateTimePicker dateTimePicker3;
        private DateTimePicker dateTimePicker2;
    }
}
