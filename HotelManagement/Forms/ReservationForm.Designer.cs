namespace HotelManagement.Forms
{
    partial class ReservationForm
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
            this.CBCustomerId = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnInsert = new System.Windows.Forms.Button();
            this.GridViewReservation = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DTIn = new System.Windows.Forms.DateTimePicker();
            this.DTOut = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.CBEmployeeId = new System.Windows.Forms.ComboBox();
            this.CBRoomId = new System.Windows.Forms.ComboBox();
            this.CBStatus = new System.Windows.Forms.ComboBox();
            this.BtnFillter = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewReservation)).BeginInit();
            this.SuspendLayout();
            // 
            // CBCustomerId
            // 
            this.CBCustomerId.FormattingEnabled = true;
            this.CBCustomerId.Location = new System.Drawing.Point(31, 301);
            this.CBCustomerId.Name = "CBCustomerId";
            this.CBCustomerId.Size = new System.Drawing.Size(279, 37);
            this.CBCustomerId.TabIndex = 67;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(31, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 31);
            this.label7.TabIndex = 64;
            this.label7.Text = "Ngày Thuê";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(31, 634);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(274, 36);
            this.button4.TabIndex = 63;
            this.button4.Text = "Trở lại";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(31, 569);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(132, 36);
            this.BtnRemove.TabIndex = 62;
            this.BtnRemove.Text = "Xóa";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(178, 515);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(132, 36);
            this.BtnEdit.TabIndex = 61;
            this.BtnEdit.Text = "Chỉnh sửa";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnInsert
            // 
            this.BtnInsert.Location = new System.Drawing.Point(31, 515);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(132, 36);
            this.BtnInsert.TabIndex = 60;
            this.BtnInsert.Text = "Thêm";
            this.BtnInsert.UseVisualStyleBackColor = true;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // GridViewReservation
            // 
            this.GridViewReservation.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GridViewReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewReservation.Location = new System.Drawing.Point(356, 138);
            this.GridViewReservation.Name = "GridViewReservation";
            this.GridViewReservation.RowHeadersWidth = 51;
            this.GridViewReservation.RowTemplate.Height = 24;
            this.GridViewReservation.Size = new System.Drawing.Size(974, 518);
            this.GridViewReservation.TabIndex = 59;
            this.GridViewReservation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GirdViewReservation_CellClick);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(31, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 31);
            this.label5.TabIndex = 58;
            this.label5.Text = "Khách Hàng";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(31, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 31);
            this.label4.TabIndex = 57;
            this.label4.Text = "Số Phòng";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(31, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 31);
            this.label3.TabIndex = 55;
            this.label3.Text = "Tên Nhân Viên";
            // 
            // TBId
            // 
            this.TBId.Location = new System.Drawing.Point(31, 97);
            this.TBId.Name = "TBId";
            this.TBId.Size = new System.Drawing.Size(279, 35);
            this.TBId.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(31, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 31);
            this.label2.TabIndex = 53;
            this.label2.Text = "Mã Đăng Ký";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(478, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 46);
            this.label1.TabIndex = 52;
            this.label1.Text = "Quản Lý Đặt Phòng";
            // 
            // DTIn
            // 
            this.DTIn.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTIn.Location = new System.Drawing.Point(31, 373);
            this.DTIn.Name = "DTIn";
            this.DTIn.Size = new System.Drawing.Size(279, 35);
            this.DTIn.TabIndex = 68;
            // 
            // DTOut
            // 
            this.DTOut.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTOut.Location = new System.Drawing.Point(31, 441);
            this.DTOut.Name = "DTOut";
            this.DTOut.Size = new System.Drawing.Size(279, 35);
            this.DTOut.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(31, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 31);
            this.label6.TabIndex = 69;
            this.label6.Text = "Ngày Trả";
            // 
            // CBEmployeeId
            // 
            this.CBEmployeeId.FormattingEnabled = true;
            this.CBEmployeeId.Location = new System.Drawing.Point(31, 165);
            this.CBEmployeeId.Name = "CBEmployeeId";
            this.CBEmployeeId.Size = new System.Drawing.Size(279, 37);
            this.CBEmployeeId.TabIndex = 71;
            // 
            // CBRoomId
            // 
            this.CBRoomId.FormattingEnabled = true;
            this.CBRoomId.Location = new System.Drawing.Point(31, 233);
            this.CBRoomId.Name = "CBRoomId";
            this.CBRoomId.Size = new System.Drawing.Size(279, 37);
            this.CBRoomId.TabIndex = 72;
            // 
            // CBStatus
            // 
            this.CBStatus.FormattingEnabled = true;
            this.CBStatus.Location = new System.Drawing.Point(356, 95);
            this.CBStatus.Name = "CBStatus";
            this.CBStatus.Size = new System.Drawing.Size(279, 37);
            this.CBStatus.TabIndex = 73;
            // 
            // BtnFillter
            // 
            this.BtnFillter.Location = new System.Drawing.Point(662, 95);
            this.BtnFillter.Name = "BtnFillter";
            this.BtnFillter.Size = new System.Drawing.Size(132, 27);
            this.BtnFillter.TabIndex = 74;
            this.BtnFillter.Text = "Lọc";
            this.BtnFillter.UseVisualStyleBackColor = true;
            this.BtnFillter.Click += new System.EventHandler(this.BtnFillter_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(822, 95);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(118, 27);
            this.BtnReset.TabIndex = 75;
            this.BtnReset.Text = "Trở Lại";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 715);
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.BtnFillter);
            this.Controls.Add(this.CBStatus);
            this.Controls.Add(this.CBRoomId);
            this.Controls.Add(this.CBEmployeeId);
            this.Controls.Add(this.DTOut);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DTIn);
            this.Controls.Add(this.CBCustomerId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnInsert);
            this.Controls.Add(this.GridViewReservation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Đặt Phòng";
            this.Load += new System.EventHandler(this.ReservationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewReservation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBCustomerId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnInsert;
        private System.Windows.Forms.DataGridView GridViewReservation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DTIn;
        private System.Windows.Forms.DateTimePicker DTOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CBEmployeeId;
        private System.Windows.Forms.ComboBox CBRoomId;
        private System.Windows.Forms.ComboBox CBStatus;
        private System.Windows.Forms.Button BtnFillter;
        private System.Windows.Forms.Button BtnReset;
    }
}