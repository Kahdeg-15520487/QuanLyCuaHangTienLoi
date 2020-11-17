using System.Windows.Forms;

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    partial class Dashboard : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbHDtoday = new System.Windows.Forms.Label();
            this.lbSumHD = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbSPtoday = new System.Windows.Forms.Label();
            this.lbSumSP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbDoanhSoToday = new System.Windows.Forms.Label();
            this.lbTongDoanhSo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnChartMoney = new System.Windows.Forms.Button();
            this.btnChartSL = new System.Windows.Forms.Button();
            this.btnSanPhamSapHet = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbKhachNoToday = new System.Windows.Forms.Label();
            this.lbKhachNoThang = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbNhapKhoToday = new System.Windows.Forms.Label();
            this.lbTongSP = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbTongLoaiSp = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PanelChart = new System.Windows.Forms.Panel();
            this.iconDBMoney = new FontAwesome.Sharp.IconPictureBox();
            this.iconDBProduct = new FontAwesome.Sharp.IconPictureBox();
            this.iconDBHoaDon = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconDBMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconDBProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconDBHoaDon)).BeginInit();
            //this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.iconDBHoaDon);
            this.panel1.Controls.Add(this.lbHDtoday);
            this.panel1.Controls.Add(this.lbSumHD);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 136);
            this.panel1.TabIndex = 0;
            // 
            // lbHDtoday
            // 
            this.lbHDtoday.AutoSize = true;
            this.lbHDtoday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHDtoday.ForeColor = System.Drawing.Color.White;
            this.lbHDtoday.Location = new System.Drawing.Point(16, 91);
            this.lbHDtoday.Name = "lbHDtoday";
            this.lbHDtoday.Size = new System.Drawing.Size(89, 20);
            this.lbHDtoday.TabIndex = 2;
            this.lbHDtoday.Text = "99.000.000";
            // 
            // lbSumHD
            // 
            this.lbSumHD.AutoSize = true;
            this.lbSumHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSumHD.ForeColor = System.Drawing.Color.White;
            this.lbSumHD.Location = new System.Drawing.Point(11, 44);
            this.lbSumHD.Name = "lbSumHD";
            this.lbSumHD.Size = new System.Drawing.Size(159, 33);
            this.lbSumHD.TabIndex = 1;
            this.lbSumHD.Text = "10.000.000";
            this.lbSumHD.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa đơn (tháng)";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkMagenta;
            this.panel2.Controls.Add(this.iconDBProduct);
            this.panel2.Controls.Add(this.lbSPtoday);
            this.panel2.Controls.Add(this.lbSumSP);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(310, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 136);
            this.panel2.TabIndex = 4;
            // 
            // lbSPtoday
            // 
            this.lbSPtoday.AutoSize = true;
            this.lbSPtoday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSPtoday.ForeColor = System.Drawing.Color.White;
            this.lbSPtoday.Location = new System.Drawing.Point(16, 91);
            this.lbSPtoday.Name = "lbSPtoday";
            this.lbSPtoday.Size = new System.Drawing.Size(89, 20);
            this.lbSPtoday.TabIndex = 2;
            this.lbSPtoday.Text = "99.000.000";
            // 
            // lbSumSP
            // 
            this.lbSumSP.AutoSize = true;
            this.lbSumSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSumSP.ForeColor = System.Drawing.Color.White;
            this.lbSumSP.Location = new System.Drawing.Point(8, 44);
            this.lbSumSP.Name = "lbSumSP";
            this.lbSumSP.Size = new System.Drawing.Size(159, 33);
            this.lbSumSP.TabIndex = 1;
            this.lbSumSP.Text = "10.000.000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(16, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mặt hàng (tháng)";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Crimson;
            this.panel3.Controls.Add(this.iconDBMoney);
            this.panel3.Controls.Add(this.lbDoanhSoToday);
            this.panel3.Controls.Add(this.lbTongDoanhSo);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(606, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(290, 136);
            this.panel3.TabIndex = 5;
            // 
            // lbDoanhSoToday
            // 
            this.lbDoanhSoToday.AutoSize = true;
            this.lbDoanhSoToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDoanhSoToday.ForeColor = System.Drawing.Color.White;
            this.lbDoanhSoToday.Location = new System.Drawing.Point(16, 91);
            this.lbDoanhSoToday.Name = "lbDoanhSoToday";
            this.lbDoanhSoToday.Size = new System.Drawing.Size(89, 20);
            this.lbDoanhSoToday.TabIndex = 2;
            this.lbDoanhSoToday.Text = "99.000.000";
            // 
            // lbTongDoanhSo
            // 
            this.lbTongDoanhSo.AutoSize = true;
            this.lbTongDoanhSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongDoanhSo.ForeColor = System.Drawing.Color.White;
            this.lbTongDoanhSo.Location = new System.Drawing.Point(8, 44);
            this.lbTongDoanhSo.Name = "lbTongDoanhSo";
            this.lbTongDoanhSo.Size = new System.Drawing.Size(159, 33);
            this.lbTongDoanhSo.TabIndex = 1;
            this.lbTongDoanhSo.Text = "10.000.000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(16, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Doanh số (tháng)";
            // 
            // btnChartMoney
            // 
            this.btnChartMoney.Location = new System.Drawing.Point(717, 261);
            this.btnChartMoney.Name = "btnChartMoney";
            this.btnChartMoney.Size = new System.Drawing.Size(184, 43);
            this.btnChartMoney.TabIndex = 7;
            this.btnChartMoney.Text = "Thống kê theo tổng tiền";
            this.btnChartMoney.UseVisualStyleBackColor = true;
            this.btnChartMoney.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChartSL
            // 
            this.btnChartSL.Location = new System.Drawing.Point(717, 310);
            this.btnChartSL.Name = "btnChartSL";
            this.btnChartSL.Size = new System.Drawing.Size(184, 43);
            this.btnChartSL.TabIndex = 9;
            this.btnChartSL.Text = "Thống kê theo số lượng";
            this.btnChartSL.UseVisualStyleBackColor = true;
            this.btnChartSL.Click += new System.EventHandler(this.btnChartSL_Click);
            // 
            // btnSanPhamSapHet
            // 
            this.btnSanPhamSapHet.Location = new System.Drawing.Point(717, 359);
            this.btnSanPhamSapHet.Name = "btnSanPhamSapHet";
            this.btnSanPhamSapHet.Size = new System.Drawing.Size(184, 43);
            this.btnSanPhamSapHet.TabIndex = 10;
            this.btnSanPhamSapHet.Text = "Sản phẩm sắp hết hàng";
            this.btnSanPhamSapHet.UseVisualStyleBackColor = true;
            this.btnSanPhamSapHet.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumOrchid;
            this.panel4.Controls.Add(this.lbKhachNoToday);
            this.panel4.Controls.Add(this.lbKhachNoThang);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(606, 155);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(290, 94);
            this.panel4.TabIndex = 6;
            // 
            // lbKhachNoToday
            // 
            this.lbKhachNoToday.AutoSize = true;
            this.lbKhachNoToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKhachNoToday.ForeColor = System.Drawing.Color.White;
            this.lbKhachNoToday.Location = new System.Drawing.Point(18, 63);
            this.lbKhachNoToday.Name = "lbKhachNoToday";
            this.lbKhachNoToday.Size = new System.Drawing.Size(89, 20);
            this.lbKhachNoToday.TabIndex = 2;
            this.lbKhachNoToday.Text = "99.000.000";
            // 
            // lbKhachNoThang
            // 
            this.lbKhachNoThang.AutoSize = true;
            this.lbKhachNoThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKhachNoThang.ForeColor = System.Drawing.Color.White;
            this.lbKhachNoThang.Location = new System.Drawing.Point(13, 34);
            this.lbKhachNoThang.Name = "lbKhachNoThang";
            this.lbKhachNoThang.Size = new System.Drawing.Size(129, 29);
            this.lbKhachNoThang.TabIndex = 1;
            this.lbKhachNoThang.Text = "10.000.000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tiền khách nợ (tháng)";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel5.Controls.Add(this.lbNhapKhoToday);
            this.panel5.Controls.Add(this.lbTongSP);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(12, 154);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(290, 94);
            this.panel5.TabIndex = 7;
            // 
            // lbNhapKhoToday
            // 
            this.lbNhapKhoToday.AutoSize = true;
            this.lbNhapKhoToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNhapKhoToday.ForeColor = System.Drawing.Color.White;
            this.lbNhapKhoToday.Location = new System.Drawing.Point(18, 63);
            this.lbNhapKhoToday.Name = "lbNhapKhoToday";
            this.lbNhapKhoToday.Size = new System.Drawing.Size(89, 20);
            this.lbNhapKhoToday.TabIndex = 2;
            this.lbNhapKhoToday.Text = "99.000.000";
            // 
            // lbTongSP
            // 
            this.lbTongSP.AutoSize = true;
            this.lbTongSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongSP.ForeColor = System.Drawing.Color.White;
            this.lbTongSP.Location = new System.Drawing.Point(13, 34);
            this.lbTongSP.Name = "lbTongSP";
            this.lbTongSP.Size = new System.Drawing.Size(129, 29);
            this.lbTongSP.TabIndex = 1;
            this.lbTongSP.Text = "10.000.000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(16, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(254, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tổng số lượng sản phẩm trong kho";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SteelBlue;
            this.panel6.Controls.Add(this.lbTongLoaiSp);
            this.panel6.Controls.Add(this.label12);
            this.panel6.Location = new System.Drawing.Point(308, 155);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(290, 94);
            this.panel6.TabIndex = 8;
            // 
            // lbTongLoaiSp
            // 
            this.lbTongLoaiSp.AutoSize = true;
            this.lbTongLoaiSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongLoaiSp.ForeColor = System.Drawing.Color.White;
            this.lbTongLoaiSp.Location = new System.Drawing.Point(13, 34);
            this.lbTongLoaiSp.Name = "lbTongLoaiSp";
            this.lbTongLoaiSp.Size = new System.Drawing.Size(129, 29);
            this.lbTongLoaiSp.TabIndex = 1;
            this.lbTongLoaiSp.Text = "10.000.000";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(16, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(184, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "Loại sản phẩm trong kho";
            // 
            // PanelChart
            // 
            this.PanelChart.Location = new System.Drawing.Point(13, 261);
            this.PanelChart.Name = "PanelChart";
            this.PanelChart.Size = new System.Drawing.Size(698, 247);
            this.PanelChart.TabIndex = 11;
            // 
            // iconDBMoney
            // 
            this.iconDBMoney.BackColor = System.Drawing.Color.Crimson;
            this.iconDBMoney.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.iconDBMoney.IconColor = System.Drawing.Color.White;
            this.iconDBMoney.IconSize = 111;
            this.iconDBMoney.Location = new System.Drawing.Point(183, -11);
            this.iconDBMoney.Name = "iconDBMoney";
            this.iconDBMoney.Size = new System.Drawing.Size(123, 111);
            this.iconDBMoney.TabIndex = 3;
            this.iconDBMoney.TabStop = false;
            // 
            // iconDBProduct
            // 
            this.iconDBProduct.BackColor = System.Drawing.Color.DarkMagenta;
            this.iconDBProduct.IconChar = FontAwesome.Sharp.IconChar.Cubes;
            this.iconDBProduct.IconColor = System.Drawing.Color.White;
            this.iconDBProduct.IconSize = 111;
            this.iconDBProduct.Location = new System.Drawing.Point(185, 1);
            this.iconDBProduct.Name = "iconDBProduct";
            this.iconDBProduct.Size = new System.Drawing.Size(123, 111);
            this.iconDBProduct.TabIndex = 3;
            this.iconDBProduct.TabStop = false;
            // 
            // iconDBHoaDon
            // 
            this.iconDBHoaDon.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.iconDBHoaDon.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            this.iconDBHoaDon.IconColor = System.Drawing.Color.White;
            this.iconDBHoaDon.IconSize = 111;
            this.iconDBHoaDon.Location = new System.Drawing.Point(185, 14);
            this.iconDBHoaDon.Name = "iconDBHoaDon";
            this.iconDBHoaDon.Size = new System.Drawing.Size(123, 111);
            this.iconDBHoaDon.TabIndex = 3;
            this.iconDBHoaDon.TabStop = false;
            this.iconDBHoaDon.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 511);
            this.Controls.Add(this.PanelChart);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnSanPhamSapHet);
            this.Controls.Add(this.btnChartSL);
            this.Controls.Add(this.btnChartMoney);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconDBMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconDBProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconDBHoaDon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbHDtoday;
        private System.Windows.Forms.Label lbSumHD;
        private FontAwesome.Sharp.IconPictureBox iconDBHoaDon;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconPictureBox iconDBProduct;
        private System.Windows.Forms.Label lbSPtoday;
        private System.Windows.Forms.Label lbSumSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconPictureBox iconDBMoney;
        private System.Windows.Forms.Label lbDoanhSoToday;
        private System.Windows.Forms.Label lbTongDoanhSo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnChartMoney;
        private System.Windows.Forms.Button btnChartSL;
        private System.Windows.Forms.Button btnSanPhamSapHet;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbKhachNoToday;
        private System.Windows.Forms.Label lbKhachNoThang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbNhapKhoToday;
        private System.Windows.Forms.Label lbTongSP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbTongLoaiSp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel PanelChart;
    }
}