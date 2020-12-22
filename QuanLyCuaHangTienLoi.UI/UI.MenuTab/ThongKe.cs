using Microsoft.EntityFrameworkCore;

using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;


namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    public partial class ThongKe : Form
    {
        SqlConnection connect = ClassKetnoi.connect;

        private Form currentchildform;
        string CurrentMonth = DateTime.Now.ToString("MM");
        public ThongKe()
        {
            InitializeComponent();
        }
        private void motrangcon(Form trangcon)
        {
            if (currentchildform != null)
            {
                currentchildform.Close();

            }
            currentchildform = trangcon;
            trangcon.TopLevel = false;
            trangcon.FormBorderStyle = FormBorderStyle.None;
            trangcon.Dock = DockStyle.Fill;
            PanelChart.Controls.Add(trangcon);
            PanelChart.Tag = trangcon;
            trangcon.BringToFront();
            trangcon.Show();

        }
        private void doanhsobanhang()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<HoaDon> hoadonRepo = new Repository<HoaDon>(dbCxt);

                var hdThangNay = hoadonRepo.Query(hd => hd.NgayLap.Month == DateTime.Now.Month)
                    .Include(hd => hd.ChiTietHoaDon)
                    .ThenInclude(cthd => cthd.LoSanPham)
                    .ThenInclude(lsp => lsp.NhaCungCap)
                    .Include(hd => hd.KhachHang)
                    .ToList()
                    ;
                var hdHomNay = hoadonRepo.Query(hd => hd.NgayLap.Day == DateTime.Now.Day)
                    .Include(hd => hd.ChiTietHoaDon)
                    .ThenInclude(cthd => cthd.LoSanPham)
                    .ThenInclude(lsp => lsp.NhaCungCap)
                    .Include(hd => hd.KhachHang)
                    .ToList()
                    ;

                int CountTongHD = hdThangNay.Count;
                int CountHDtoday = hdHomNay.Count; ;
                double CountTongTienThangNay = hdThangNay.SelectMany(hd => hd.ChiTietHoaDon.Select(cthd => cthd.DonGia)).Sum();
                var CountTienToday = hdHomNay.SelectMany(hd => hd.ChiTietHoaDon.Select(cthd => cthd.DonGia * cthd.SoLuong)).Sum();
                int CountDistinctMasp = hdThangNay.SelectMany(hd => hd.ChiTietHoaDon.Select(cthd => cthd.LoSanPham.SanPhamId)).Distinct().Count();
                int CountDistinctMaspToday = hdHomNay.SelectMany(hd => hd.ChiTietHoaDon.Select(cthd => cthd.LoSanPham.SanPhamId)).Distinct().Count();

                lbDoanhSoToday.Text = "Hôm nay: " + CountTienToday.ToString();
                lbTongDoanhSo.Text = CountTongTienThangNay.ToString();
                lbSumHD.Text = CountTongHD.ToString();
                lbHDtoday.Text = "Hôm nay: " + CountHDtoday.ToString();
                lbSumSP.Text = CountDistinctMasp.ToString();
                lbSPtoday.Text = "Hôm nay: " + CountDistinctMaspToday.ToString();

            }
        }

        private void tongslsptrongkho()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<LoSanPham> lspRepo = new Repository<LoSanPham>(dbCxt);

                var tongLuongSanPham = lspRepo.GetAll().Sum(lsp => lsp.SoLuong);
                var loSanPhamNhapKhoHomNay = lspRepo.Query(lsp => lsp.NgayNhap.Day == DateTime.Now.Day).Sum(lsp => lsp.SoLuong);

                lbTongSP.Text = tongLuongSanPham.ToString();
                lbNhapKhoToday.Text = "Nhập kho hôm nay: " + loSanPhamNhapKhoHomNay.ToString() + " sản phẩm";
            }
        }
        private void loaisptrongkho()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<SanPham> spRepo = new Repository<SanPham>(dbCxt);

                var soLoaiSanPhamTrongKho = spRepo.GetAll().Count();
                lbTongLoaiSp.Text = soLoaiSanPhamTrongKho.ToString();
            }
        }
        private void khachno()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<HoaDon> hoadonRepo = new Repository<HoaDon>(dbCxt);

                var noThangNay = hoadonRepo.Query(hd => hd.NgayLap.Month == DateTime.Now.Month).Sum(hd => hd.No);
                var noHomNay = hoadonRepo.Query(hd => hd.NgayLap.Day == DateTime.Now.Day).Sum(hd => hd.No);

                lbKhachNoToday.Text = "Hôm nay: " + noHomNay.ToString();
                lbKhachNoThang.Text = noThangNay.ToString();
            }
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            motrangcon(new ChartMoney());
            doanhsobanhang();
            tongslsptrongkho();
            loaisptrongkho();
            khachno();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            motrangcon(new ChartMoney());

        }

        private void btnChartSL_Click(object sender, EventArgs e)
        {
            motrangcon(new ChartSLSP());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            motrangcon(new ChartSanPhamHet());
        }
    }
}
