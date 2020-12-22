namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    partial class tonkho
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txttensp = new System.Windows.Forms.TextBox();
            this.txtsl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtgiaban = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.comboloai = new System.Windows.Forms.ComboBox();
            this.combodonvi = new System.Windows.Forms.ComboBox();
            this.LabelSearch = new System.Windows.Forms.Label();
            this.btnExportExcel = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(360, 102);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(657, 359);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(133, 14);
            this.txtid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(209, 23);
            this.txtid.TabIndex = 1;
            // 
            // txttensp
            // 
            this.txttensp.Location = new System.Drawing.Point(133, 45);
            this.txttensp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txttensp.Name = "txttensp";
            this.txttensp.Size = new System.Drawing.Size(209, 23);
            this.txttensp.TabIndex = 2;
            // 
            // txtsl
            // 
            this.txtsl.Location = new System.Drawing.Point(133, 77);
            this.txtsl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtsl.Name = "txtsl";
            this.txtsl.Size = new System.Drawing.Size(209, 23);
            this.txtsl.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mã sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(20, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Loại";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(20, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Giá bán";
            // 
            // txtgiaban
            // 
            this.txtgiaban.Location = new System.Drawing.Point(133, 106);
            this.txtgiaban.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtgiaban.Name = "txtgiaban";
            this.txtgiaban.Size = new System.Drawing.Size(209, 23);
            this.txtgiaban.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(20, 169);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Đơn vị";
            // 
            // txtsearch
            // 
            this.txtsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearch.Location = new System.Drawing.Point(360, 67);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(228, 23);
            this.txtsearch.TabIndex = 25;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // comboloai
            // 
            this.comboloai.FormattingEnabled = true;
            this.comboloai.Items.AddRange(new object[] {
            "Nước ngọt",
            "Bánh",
            "Mì",
            "Nước suối",
            "Xúc xích"});
            this.comboloai.Location = new System.Drawing.Point(133, 135);
            this.comboloai.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboloai.Name = "comboloai";
            this.comboloai.Size = new System.Drawing.Size(209, 23);
            this.comboloai.TabIndex = 27;
            this.comboloai.SelectedIndexChanged += new System.EventHandler(this.comboloai_SelectedIndexChanged);
            // 
            // combodonvi
            // 
            this.combodonvi.FormattingEnabled = true;
            this.combodonvi.Items.AddRange(new object[] {
            "Chai",
            "Lon",
            "Gói",
            "Hộp",
            "Thùng"});
            this.combodonvi.Location = new System.Drawing.Point(133, 167);
            this.combodonvi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.combodonvi.Name = "combodonvi";
            this.combodonvi.Size = new System.Drawing.Size(209, 23);
            this.combodonvi.TabIndex = 28;
            // 
            // LabelSearch
            // 
            this.LabelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelSearch.AutoSize = true;
            this.LabelSearch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelSearch.Location = new System.Drawing.Point(597, 69);
            this.LabelSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSearch.Name = "LabelSearch";
            this.LabelSearch.Size = new System.Drawing.Size(63, 17);
            this.LabelSearch.TabIndex = 30;
            this.LabelSearch.Text = "Tìm kiếm";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnExportExcel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnExportExcel.IconColor = System.Drawing.Color.Black;
            this.btnExportExcel.IconSize = 16;
            this.btnExportExcel.Location = new System.Drawing.Point(784, 46);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Rotation = 0D;
            this.btnExportExcel.Size = new System.Drawing.Size(233, 43);
            this.btnExportExcel.TabIndex = 36;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // tonkho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 474);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.LabelSearch);
            this.Controls.Add(this.combodonvi);
            this.Controls.Add(this.comboloai);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtgiaban);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtsl);
            this.Controls.Add(this.txttensp);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "tonkho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tồn kho";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txttensp;
        private System.Windows.Forms.TextBox txtsl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtgiaban;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.ComboBox comboloai;
        private System.Windows.Forms.ComboBox combodonvi;
        private System.Windows.Forms.Label LabelSearch;
        private FontAwesome.Sharp.IconButton btnExportExcel;
    }
}