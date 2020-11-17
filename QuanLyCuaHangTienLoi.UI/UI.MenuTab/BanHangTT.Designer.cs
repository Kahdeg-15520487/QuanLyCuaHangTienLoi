namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    partial class BanHangTT
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTTOK = new System.Windows.Forms.TextBox();
            this.txtTienThoiLai = new System.Windows.Forms.TextBox();
            this.txtTienKhachDua = new System.Windows.Forms.TextBox();
            this.btnHuyTT = new FontAwesome.Sharp.IconButton();
            this.btnOKTT = new FontAwesome.Sharp.IconButton();
            this.btn500k = new FontAwesome.Sharp.IconButton();
            this.btn200k = new FontAwesome.Sharp.IconButton();
            this.btn100k = new FontAwesome.Sharp.IconButton();
            this.btn50k = new FontAwesome.Sharp.IconButton();
            this.btnTraDu = new FontAwesome.Sharp.IconButton();
            this.btnNo = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thanh toán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Khách đưa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tiền thối lại";
            // 
            // txtTTOK
            // 
            this.txtTTOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTTOK.Location = new System.Drawing.Point(139, 23);
            this.txtTTOK.Name = "txtTTOK";
            this.txtTTOK.Size = new System.Drawing.Size(334, 44);
            this.txtTTOK.TabIndex = 3;
            // 
            // txtTienThoiLai
            // 
            this.txtTienThoiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienThoiLai.Location = new System.Drawing.Point(139, 245);
            this.txtTienThoiLai.Name = "txtTienThoiLai";
            this.txtTienThoiLai.Size = new System.Drawing.Size(334, 44);
            this.txtTienThoiLai.TabIndex = 4;
            // 
            // txtTienKhachDua
            // 
            this.txtTienKhachDua.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienKhachDua.Location = new System.Drawing.Point(139, 177);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.Size = new System.Drawing.Size(334, 44);
            this.txtTienKhachDua.TabIndex = 5;
            this.txtTienKhachDua.TextChanged += new System.EventHandler(this.txtTienKhachDua_TextChanged);
            // 
            // btnHuyTT
            // 
            this.btnHuyTT.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnHuyTT.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnHuyTT.IconColor = System.Drawing.Color.Black;
            this.btnHuyTT.IconSize = 16;
            this.btnHuyTT.Location = new System.Drawing.Point(139, 294);
            this.btnHuyTT.Name = "btnHuyTT";
            this.btnHuyTT.Rotation = 0D;
            this.btnHuyTT.Size = new System.Drawing.Size(160, 60);
            this.btnHuyTT.TabIndex = 11;
            this.btnHuyTT.Text = "Hủy";
            this.btnHuyTT.UseVisualStyleBackColor = true;
            this.btnHuyTT.Click += new System.EventHandler(this.btnHuyTT_Click);
            // 
            // btnOKTT
            // 
            this.btnOKTT.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnOKTT.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnOKTT.IconColor = System.Drawing.Color.Black;
            this.btnOKTT.IconSize = 16;
            this.btnOKTT.Location = new System.Drawing.Point(313, 294);
            this.btnOKTT.Name = "btnOKTT";
            this.btnOKTT.Rotation = 0D;
            this.btnOKTT.Size = new System.Drawing.Size(160, 60);
            this.btnOKTT.TabIndex = 10;
            this.btnOKTT.Text = "Đồng ý";
            this.btnOKTT.UseVisualStyleBackColor = true;
            this.btnOKTT.Click += new System.EventHandler(this.btnOKTT_Click);
            // 
            // btn500k
            // 
            this.btn500k.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn500k.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btn500k.IconColor = System.Drawing.Color.Black;
            this.btn500k.IconSize = 16;
            this.btn500k.Location = new System.Drawing.Point(396, 73);
            this.btn500k.Name = "btn500k";
            this.btn500k.Rotation = 0D;
            this.btn500k.Size = new System.Drawing.Size(79, 46);
            this.btn500k.TabIndex = 9;
            this.btn500k.Text = "500.000";
            this.btn500k.UseVisualStyleBackColor = true;
            this.btn500k.Click += new System.EventHandler(this.btn500k_Click);
            // 
            // btn200k
            // 
            this.btn200k.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn200k.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btn200k.IconColor = System.Drawing.Color.Black;
            this.btn200k.IconSize = 16;
            this.btn200k.Location = new System.Drawing.Point(311, 73);
            this.btn200k.Name = "btn200k";
            this.btn200k.Rotation = 0D;
            this.btn200k.Size = new System.Drawing.Size(79, 46);
            this.btn200k.TabIndex = 8;
            this.btn200k.Text = "200.000";
            this.btn200k.UseVisualStyleBackColor = true;
            this.btn200k.Click += new System.EventHandler(this.btn200k_Click);
            // 
            // btn100k
            // 
            this.btn100k.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn100k.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btn100k.IconColor = System.Drawing.Color.Black;
            this.btn100k.IconSize = 16;
            this.btn100k.Location = new System.Drawing.Point(226, 73);
            this.btn100k.Name = "btn100k";
            this.btn100k.Rotation = 0D;
            this.btn100k.Size = new System.Drawing.Size(79, 46);
            this.btn100k.TabIndex = 7;
            this.btn100k.Text = "100.000";
            this.btn100k.UseVisualStyleBackColor = true;
            this.btn100k.Click += new System.EventHandler(this.btn100k_Click);
            // 
            // btn50k
            // 
            this.btn50k.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn50k.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btn50k.IconColor = System.Drawing.Color.Black;
            this.btn50k.IconSize = 16;
            this.btn50k.Location = new System.Drawing.Point(141, 73);
            this.btn50k.Name = "btn50k";
            this.btn50k.Rotation = 0D;
            this.btn50k.Size = new System.Drawing.Size(79, 46);
            this.btn50k.TabIndex = 6;
            this.btn50k.Text = "50.000";
            this.btn50k.UseVisualStyleBackColor = true;
            this.btn50k.Click += new System.EventHandler(this.btn50k_Click);
            // 
            // btnTraDu
            // 
            this.btnTraDu.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnTraDu.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTraDu.IconColor = System.Drawing.Color.Black;
            this.btnTraDu.IconSize = 16;
            this.btnTraDu.Location = new System.Drawing.Point(141, 125);
            this.btnTraDu.Name = "btnTraDu";
            this.btnTraDu.Rotation = 0D;
            this.btnTraDu.Size = new System.Drawing.Size(164, 46);
            this.btnTraDu.TabIndex = 12;
            this.btnTraDu.Text = "Trả đủ";
            this.btnTraDu.UseVisualStyleBackColor = true;
            this.btnTraDu.Click += new System.EventHandler(this.btnTraDu_Click);
            // 
            // btnNo
            // 
            this.btnNo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnNo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnNo.IconColor = System.Drawing.Color.Black;
            this.btnNo.IconSize = 16;
            this.btnNo.Location = new System.Drawing.Point(313, 125);
            this.btnNo.Name = "btnNo";
            this.btnNo.Rotation = 0D;
            this.btnNo.Size = new System.Drawing.Size(160, 46);
            this.btnNo.TabIndex = 13;
            this.btnNo.Text = "Nợ";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // BanHangTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 370);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnTraDu);
            this.Controls.Add(this.btnHuyTT);
            this.Controls.Add(this.btnOKTT);
            this.Controls.Add(this.btn500k);
            this.Controls.Add(this.btn200k);
            this.Controls.Add(this.btn100k);
            this.Controls.Add(this.btn50k);
            this.Controls.Add(this.txtTienKhachDua);
            this.Controls.Add(this.txtTienThoiLai);
            this.Controls.Add(this.txtTTOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "BanHangTT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán";
            this.Load += new System.EventHandler(this.BanHangTT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTTOK;
        private System.Windows.Forms.TextBox txtTienThoiLai;
        private System.Windows.Forms.TextBox txtTienKhachDua;
        private FontAwesome.Sharp.IconButton btn50k;
        private FontAwesome.Sharp.IconButton btn100k;
        private FontAwesome.Sharp.IconButton btn200k;
        private FontAwesome.Sharp.IconButton btn500k;
        private FontAwesome.Sharp.IconButton btnOKTT;
        private FontAwesome.Sharp.IconButton btnHuyTT;
        private FontAwesome.Sharp.IconButton btnTraDu;
        private FontAwesome.Sharp.IconButton btnNo;
    }
}