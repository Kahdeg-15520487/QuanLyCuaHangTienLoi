namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    partial class Setting
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
            this.dataGridViewNV = new System.Windows.Forms.DataGridView();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.BtnThem = new FontAwesome.Sharp.IconButton();
            this.BtnSua = new FontAwesome.Sharp.IconButton();
            this.BtnXoa = new FontAwesome.Sharp.IconButton();
            this.BtnHuy = new FontAwesome.Sharp.IconButton();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtTenShop = new System.Windows.Forms.TextBox();
            this.txtLoiChao = new System.Windows.Forms.TextBox();
            this.BtnSaveThongtin = new FontAwesome.Sharp.IconButton();
            this.txtIdNV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewKH = new System.Windows.Forms.DataGridView();
            this.btnUpdateKH = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKH)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewNV
            // 
            this.dataGridViewNV.AllowUserToAddRows = false;
            this.dataGridViewNV.AllowUserToDeleteRows = false;
            this.dataGridViewNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNV.Location = new System.Drawing.Point(603, 45);
            this.dataGridViewNV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewNV.Name = "dataGridViewNV";
            this.dataGridViewNV.ReadOnly = true;
            this.dataGridViewNV.Size = new System.Drawing.Size(414, 336);
            this.dataGridViewNV.TabIndex = 0;
            this.dataGridViewNV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNV_CellContentDoubleClick);
            // 
            // txtNameNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(408, 74);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTenNV.Name = "txtNameNV";
            this.txtTenNV.Size = new System.Drawing.Size(187, 23);
            this.txtTenNV.TabIndex = 2;
            // 
            // BtnThem
            // 
            this.BtnThem.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnThem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnThem.IconColor = System.Drawing.Color.Black;
            this.BtnThem.IconSize = 16;
            this.BtnThem.Location = new System.Drawing.Point(408, 180);
            this.BtnThem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnThem.Name = "BtnThem";
            this.BtnThem.Rotation = 0D;
            this.BtnThem.Size = new System.Drawing.Size(188, 45);
            this.BtnThem.TabIndex = 4;
            this.BtnThem.Text = "Thêm";
            this.BtnThem.UseVisualStyleBackColor = true;
            this.BtnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // BtnSua
            // 
            this.BtnSua.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnSua.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnSua.IconColor = System.Drawing.Color.Black;
            this.BtnSua.IconSize = 16;
            this.BtnSua.Location = new System.Drawing.Point(408, 232);
            this.BtnSua.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnSua.Name = "BtnSua";
            this.BtnSua.Rotation = 0D;
            this.BtnSua.Size = new System.Drawing.Size(188, 45);
            this.BtnSua.TabIndex = 5;
            this.BtnSua.Text = "Sửa";
            this.BtnSua.UseVisualStyleBackColor = true;
            this.BtnSua.Click += new System.EventHandler(this.BtnSua_Click);
            // 
            // BtnXoa
            // 
            this.BtnXoa.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnXoa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnXoa.IconColor = System.Drawing.Color.Black;
            this.BtnXoa.IconSize = 16;
            this.BtnXoa.Location = new System.Drawing.Point(408, 284);
            this.BtnXoa.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnXoa.Name = "BtnXoa";
            this.BtnXoa.Rotation = 0D;
            this.BtnXoa.Size = new System.Drawing.Size(188, 45);
            this.BtnXoa.TabIndex = 6;
            this.BtnXoa.Text = "Xóa";
            this.BtnXoa.UseVisualStyleBackColor = true;
            this.BtnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // BtnHuy
            // 
            this.BtnHuy.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnHuy.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnHuy.IconColor = System.Drawing.Color.Black;
            this.BtnHuy.IconSize = 16;
            this.BtnHuy.Location = new System.Drawing.Point(408, 336);
            this.BtnHuy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnHuy.Name = "BtnHuy";
            this.BtnHuy.Rotation = 0D;
            this.BtnHuy.Size = new System.Drawing.Size(188, 45);
            this.BtnHuy.TabIndex = 7;
            this.BtnHuy.Text = "Hủy";
            this.BtnHuy.UseVisualStyleBackColor = true;
            this.BtnHuy.Click += new System.EventHandler(this.BtnHuy_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(119, 105);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(187, 23);
            this.txtDiaChi.TabIndex = 10;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(119, 75);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(187, 23);
            this.txtSDT.TabIndex = 9;
            // 
            // txtTenShop
            // 
            this.txtTenShop.Location = new System.Drawing.Point(119, 45);
            this.txtTenShop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTenShop.Name = "txtTenShop";
            this.txtTenShop.Size = new System.Drawing.Size(187, 23);
            this.txtTenShop.TabIndex = 8;
            // 
            // txtLoiChao
            // 
            this.txtLoiChao.Location = new System.Drawing.Point(119, 135);
            this.txtLoiChao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLoiChao.Name = "txtLoiChao";
            this.txtLoiChao.Size = new System.Drawing.Size(187, 23);
            this.txtLoiChao.TabIndex = 11;
            // 
            // BtnSaveThongtin
            // 
            this.BtnSaveThongtin.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnSaveThongtin.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnSaveThongtin.IconColor = System.Drawing.Color.Black;
            this.BtnSaveThongtin.IconSize = 16;
            this.BtnSaveThongtin.Location = new System.Drawing.Point(119, 180);
            this.BtnSaveThongtin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnSaveThongtin.Name = "BtnSaveThongtin";
            this.BtnSaveThongtin.Rotation = 0D;
            this.BtnSaveThongtin.Size = new System.Drawing.Size(188, 45);
            this.BtnSaveThongtin.TabIndex = 12;
            this.BtnSaveThongtin.Text = "Lưu";
            this.BtnSaveThongtin.UseVisualStyleBackColor = true;
            this.BtnSaveThongtin.Click += new System.EventHandler(this.BtnSaveThongtin_Click);
            // 
            // txtSttNV
            // 
            this.txtIdNV.Location = new System.Drawing.Point(408, 45);
            this.txtIdNV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdNV.Name = "txtSttNV";
            this.txtIdNV.ReadOnly = true;
            this.txtIdNV.Size = new System.Drawing.Size(187, 23);
            this.txtIdNV.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(7, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tên cửa hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "SĐT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(10, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(10, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Lời chào";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(360, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "STT";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(341, 76);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Tên NV";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(581, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 18);
            this.label9.TabIndex = 29;
            this.label9.Text = "Quản lý thông tin nhân viên";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(31, 10);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 18);
            this.label10.TabIndex = 30;
            this.label10.Text = "Quản lý thông tin cửa hàng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(31, 441);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 18);
            this.label11.TabIndex = 31;
            this.label11.Text = "Quản lý thông tin khách hàng";
            // 
            // dataGridViewKH
            // 
            this.dataGridViewKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKH.Location = new System.Drawing.Point(364, 418);
            this.dataGridViewKH.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewKH.Name = "dataGridViewKH";
            this.dataGridViewKH.Size = new System.Drawing.Size(653, 175);
            this.dataGridViewKH.TabIndex = 32;
            // 
            // btnUpdateKH
            // 
            this.btnUpdateKH.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUpdateKH.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnUpdateKH.IconColor = System.Drawing.Color.Black;
            this.btnUpdateKH.IconSize = 16;
            this.btnUpdateKH.Location = new System.Drawing.Point(14, 511);
            this.btnUpdateKH.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpdateKH.Name = "btnUpdateKH";
            this.btnUpdateKH.Rotation = 0D;
            this.btnUpdateKH.Size = new System.Drawing.Size(306, 82);
            this.btnUpdateKH.TabIndex = 33;
            this.btnUpdateKH.Text = "Cập nhật thông tin";
            this.btnUpdateKH.UseVisualStyleBackColor = true;
            this.btnUpdateKH.Click += new System.EventHandler(this.btnUpdateKH_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 607);
            this.Controls.Add(this.btnUpdateKH);
            this.Controls.Add(this.dataGridViewKH);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdNV);
            this.Controls.Add(this.BtnSaveThongtin);
            this.Controls.Add(this.txtLoiChao);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtTenShop);
            this.Controls.Add(this.BtnHuy);
            this.Controls.Add(this.BtnXoa);
            this.Controls.Add(this.BtnSua);
            this.Controls.Add(this.BtnThem);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.dataGridViewNV);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Setting";
            this.Text = "Thiết lập";
            this.Load += new System.EventHandler(this.Setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private FontAwesome.Sharp.IconButton BtnThem;
        private FontAwesome.Sharp.IconButton BtnSua;
        private FontAwesome.Sharp.IconButton BtnXoa;
        private FontAwesome.Sharp.IconButton BtnHuy;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtTenShop;
        private System.Windows.Forms.TextBox txtLoiChao;
        private FontAwesome.Sharp.IconButton BtnSaveThongtin;
        private System.Windows.Forms.TextBox txtIdNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewKH;
        private FontAwesome.Sharp.IconButton btnUpdateKH;
    }
}