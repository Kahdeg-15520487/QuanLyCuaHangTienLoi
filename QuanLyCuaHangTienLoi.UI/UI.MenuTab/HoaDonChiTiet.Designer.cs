namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    partial class HoaDonChiTiet
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
            this.dataGridViewct = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxttNo = new System.Windows.Forms.TextBox();
            this.btnthanhtoanno = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewct)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewct
            // 
            this.dataGridViewct.AllowUserToAddRows = false;
            this.dataGridViewct.AllowUserToDeleteRows = false;
            this.dataGridViewct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewct.Location = new System.Drawing.Point(27, 76);
            this.dataGridViewct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewct.Name = "dataGridViewct";
            this.dataGridViewct.ReadOnly = true;
            this.dataGridViewct.RowHeadersVisible = false;
            this.dataGridViewct.Size = new System.Drawing.Size(974, 367);
            this.dataGridViewct.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(819, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "In hóa đơn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(640, 14);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 55);
            this.button3.TabIndex = 4;
            this.button3.Text = "Xuất file Excel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // textBoxttNo
            // 
            this.textBoxttNo.Location = new System.Drawing.Point(226, 46);
            this.textBoxttNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxttNo.Name = "textBoxttNo";
            this.textBoxttNo.Size = new System.Drawing.Size(219, 23);
            this.textBoxttNo.TabIndex = 5;
            // 
            // btnthanhtoanno
            // 
            this.btnthanhtoanno.Location = new System.Drawing.Point(460, 15);
            this.btnthanhtoanno.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnthanhtoanno.Name = "btnthanhtoanno";
            this.btnthanhtoanno.Size = new System.Drawing.Size(172, 55);
            this.btnthanhtoanno.TabIndex = 6;
            this.btnthanhtoanno.Text = "Thanh toán";
            this.btnthanhtoanno.UseVisualStyleBackColor = true;
            this.btnthanhtoanno.Click += new System.EventHandler(this.btnthanhtoanno_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số tiền khách đưa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Số tiền khách nợ";
            // 
            // txtBoxNo
            // 
            this.txtBoxNo.Location = new System.Drawing.Point(27, 47);
            this.txtBoxNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxNo.Name = "txtBoxNo";
            this.txtBoxNo.Size = new System.Drawing.Size(191, 23);
            this.txtBoxNo.TabIndex = 9;
            // 
            // HoaDonChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 474);
            this.Controls.Add(this.txtBoxNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnthanhtoanno);
            this.Controls.Add(this.textBoxttNo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewct);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "HoaDonChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa đơn chi tiết";
            this.Load += new System.EventHandler(this.HoaDonChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewct;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxttNo;
        private System.Windows.Forms.Button btnthanhtoanno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxNo;
    }
}