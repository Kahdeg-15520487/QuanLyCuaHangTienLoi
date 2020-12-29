namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    partial class GiamGiaForm
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
            this.dataGridView_sp = new System.Windows.Forms.DataGridView();
            this.txt_id_giamgia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new FontAwesome.Sharp.IconButton();
            this.btnSua = new FontAwesome.Sharp.IconButton();
            this.btnHuy = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_id_sp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_tensp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_giasp = new System.Windows.Forms.TextBox();
            this.txt_giasp_giam = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker_batdau = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_ketthuc = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_loaisp = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView_gg = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown_phantramgiam = new System.Windows.Forms.NumericUpDown();
            this.btnXoa = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_gg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_phantramgiam)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_sp
            // 
            this.dataGridView_sp.AllowUserToAddRows = false;
            this.dataGridView_sp.AllowUserToDeleteRows = false;
            this.dataGridView_sp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sp.Location = new System.Drawing.Point(650, 12);
            this.dataGridView_sp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView_sp.Name = "dataGridView_sp";
            this.dataGridView_sp.ReadOnly = true;
            this.dataGridView_sp.Size = new System.Drawing.Size(374, 245);
            this.dataGridView_sp.TabIndex = 0;
            this.dataGridView_sp.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSp_CellContentDoubleClick);
            // 
            // txt_id_giamgia
            // 
            this.txt_id_giamgia.Location = new System.Drawing.Point(135, 15);
            this.txt_id_giamgia.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_id_giamgia.Name = "txt_id_giamgia";
            this.txt_id_giamgia.ReadOnly = true;
            this.txt_id_giamgia.Size = new System.Drawing.Size(174, 23);
            this.txt_id_giamgia.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID giảm giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Phần trăm giảm giá";
            // 
            // btnThem
            // 
            this.btnThem.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnThem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThem.IconColor = System.Drawing.Color.Black;
            this.btnThem.IconSize = 16;
            this.btnThem.Location = new System.Drawing.Point(13, 196);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Rotation = 0D;
            this.btnThem.Size = new System.Drawing.Size(135, 50);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSua.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSua.IconColor = System.Drawing.Color.Black;
            this.btnSua.IconSize = 16;
            this.btnSua.Location = new System.Drawing.Point(156, 196);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Rotation = 0D;
            this.btnSua.Size = new System.Drawing.Size(153, 50);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnHuy.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnHuy.IconColor = System.Drawing.Color.Black;
            this.btnHuy.IconSize = 16;
            this.btnHuy.Location = new System.Drawing.Point(478, 196);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Rotation = 0D;
            this.btnHuy.Size = new System.Drawing.Size(153, 50);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(372, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Id sản phẩm";
            // 
            // txt_id_sp
            // 
            this.txt_id_sp.Location = new System.Drawing.Point(468, 17);
            this.txt_id_sp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_id_sp.Name = "txt_id_sp";
            this.txt_id_sp.ReadOnly = true;
            this.txt_id_sp.Size = new System.Drawing.Size(174, 23);
            this.txt_id_sp.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(13, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ngày bắt đầu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(372, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Loại sản phẩm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(372, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tên sản phẩm";
            // 
            // txt_tensp
            // 
            this.txt_tensp.Location = new System.Drawing.Point(468, 75);
            this.txt_tensp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_tensp.Name = "txt_tensp";
            this.txt_tensp.Size = new System.Drawing.Size(174, 23);
            this.txt_tensp.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(372, 104);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Giá gốc";
            // 
            // txt_giasp
            // 
            this.txt_giasp.Location = new System.Drawing.Point(468, 104);
            this.txt_giasp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_giasp.Name = "txt_giasp";
            this.txt_giasp.ReadOnly = true;
            this.txt_giasp.Size = new System.Drawing.Size(174, 23);
            this.txt_giasp.TabIndex = 2;
            // 
            // txt_giasp_giam
            // 
            this.txt_giasp_giam.Location = new System.Drawing.Point(468, 133);
            this.txt_giasp_giam.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_giasp_giam.Name = "txt_giasp_giam";
            this.txt_giasp_giam.ReadOnly = true;
            this.txt_giasp_giam.Size = new System.Drawing.Size(174, 23);
            this.txt_giasp_giam.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(354, 135);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Giá sau khi giảm";
            // 
            // dateTimePicker_batdau
            // 
            this.dateTimePicker_batdau.Location = new System.Drawing.Point(135, 73);
            this.dateTimePicker_batdau.Name = "dateTimePicker_batdau";
            this.dateTimePicker_batdau.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker_batdau.TabIndex = 9;
            // 
            // dateTimePicker_ketthuc
            // 
            this.dateTimePicker_ketthuc.Location = new System.Drawing.Point(135, 102);
            this.dateTimePicker_ketthuc.Name = "dateTimePicker_ketthuc";
            this.dateTimePicker_ketthuc.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker_ketthuc.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(13, 109);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Ngày kết thúc";
            // 
            // comboBox_loaisp
            // 
            this.comboBox_loaisp.FormattingEnabled = true;
            this.comboBox_loaisp.Location = new System.Drawing.Point(474, 46);
            this.comboBox_loaisp.Name = "comboBox_loaisp";
            this.comboBox_loaisp.Size = new System.Drawing.Size(121, 23);
            this.comboBox_loaisp.TabIndex = 10;
            this.comboBox_loaisp.SelectedIndexChanged += new System.EventHandler(this.comboBox_loaisp_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(198, 48);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "%";
            // 
            // dataGridView_gg
            // 
            this.dataGridView_gg.AllowUserToAddRows = false;
            this.dataGridView_gg.AllowUserToDeleteRows = false;
            this.dataGridView_gg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_gg.Location = new System.Drawing.Point(13, 282);
            this.dataGridView_gg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView_gg.Name = "dataGridView_gg";
            this.dataGridView_gg.ReadOnly = true;
            this.dataGridView_gg.Size = new System.Drawing.Size(1011, 273);
            this.dataGridView_gg.TabIndex = 0;
            this.dataGridView_gg.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGiamGia_CellContentDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(13, 263);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(211, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "Chương trình giảm giá đang xảy ra:";
            // 
            // numericUpDown_phantramgiam
            // 
            this.numericUpDown_phantramgiam.Location = new System.Drawing.Point(142, 46);
            this.numericUpDown_phantramgiam.Name = "numericUpDown_phantramgiam";
            this.numericUpDown_phantramgiam.Size = new System.Drawing.Size(49, 23);
            this.numericUpDown_phantramgiam.TabIndex = 11;
            // 
            // btnXoa
            // 
            this.btnXoa.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnXoa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnXoa.IconColor = System.Drawing.Color.Black;
            this.btnXoa.IconSize = 16;
            this.btnXoa.Location = new System.Drawing.Point(317, 196);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Rotation = 0D;
            this.btnXoa.Size = new System.Drawing.Size(153, 50);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // GiamGiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 567);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.numericUpDown_phantramgiam);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridView_gg);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox_loaisp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker_ketthuc);
            this.Controls.Add(this.dateTimePicker_batdau);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_giasp_giam);
            this.Controls.Add(this.txt_giasp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_tensp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_id_sp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_id_giamgia);
            this.Controls.Add(this.dataGridView_sp);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GiamGiaForm";
            this.Text = "Loại sản phẩm";
            this.Load += new System.EventHandler(this.LoaiSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_gg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_phantramgiam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_sp;
        private System.Windows.Forms.TextBox txt_id_giamgia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnThem;
        private FontAwesome.Sharp.IconButton btnSua;
        private FontAwesome.Sharp.IconButton btnHuy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_id_sp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_tensp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_giasp;
        private System.Windows.Forms.TextBox txt_giasp_giam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker_batdau;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ketthuc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_loaisp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dataGridView_gg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown_phantramgiam;
        private FontAwesome.Sharp.IconButton btnXoa;
    }
}