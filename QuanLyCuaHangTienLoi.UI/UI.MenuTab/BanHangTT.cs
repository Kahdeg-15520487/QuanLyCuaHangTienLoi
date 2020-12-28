using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.UI.Utilities;
using System.Diagnostics;

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    public partial class BanHangTT : Form
    {
        ListBox listBox2 = new ListBox();
        public static string thoilai = "";
        double thanhtoanno; //set tiền thanh toán sql nếu có nợ
        Guid makh = BanHang.MaKH;
        string tenkh = BanHang.SDT;

        Label lbtenshop = new Label();
        Label lbdiachi = new Label();
        Label lbSDT = new Label();
        Label lbLoichao = new Label();
        private List<ChiTietHoaDon> chiTietHoaDons;

        public BanHangTT(ListBox.ObjectCollection Items, List<ChiTietHoaDon> chiTietHoaDons)
        {
            InitializeComponent();
            txtTTOK.Text = BanHang.thanhtoan;
            listBox2.Items.AddRange(Items);
            this.chiTietHoaDons = chiTietHoaDons;

            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<KhachHang> khRepo = new Repository<KhachHang>(dbCxt);
                var kh = khRepo.Get(BanHang.MaKH);
                if (kh == null)
                {
                    MessageBox.Show("Lỗi dữ liệu: Khách hàng không tồn tại.");
                    Close();
                }

                txtIdKh.Text = kh.Id.ToString();
                txtTenKh.Text = kh.TenKhachHang;
                txtSdtKh.Text = kh.SoDienThoai;
                txtDiaChiKh.Text = kh.DiaChi;
                txtEmailKh.Text = kh.Email;
            }
        }

        private void btn50k_Click(object sender, EventArgs e)
        {
            double tien50k = 50000;
            txtTienKhachDua.Text = string.Format("{0:N2}", tien50k);
        }

        private void btn100k_Click(object sender, EventArgs e)
        {
            double tien100k = 100000;
            txtTienKhachDua.Text = string.Format("{0:N2}", tien100k);
        }

        private void btn200k_Click(object sender, EventArgs e)
        {
            double tien200k = 200000;
            txtTienKhachDua.Text = string.Format("{0:N2}", tien200k);
        }

        private void btn500k_Click(object sender, EventArgs e)
        {
            double tien500k = 500000;
            txtTienKhachDua.Text = string.Format("{0:N2}", tien500k);
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            double tienTT;
            double tienkhacdua;
            double TienThoiLai;

            tienTT = double.Parse(txtTTOK.Text);
            tienkhacdua = double.Parse(txtTienKhachDua.Text);

            TienThoiLai = tienkhacdua - tienTT;
            if (TienThoiLai == 0)
            {
                txtTienThoiLai.Text = "0";
            }
            else
            {
                txtTienThoiLai.Text = string.Format("{0:N2}", TienThoiLai);
            }

        }

        private void btnHuyTT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InsertDatabase(Guid nhanVienId, Guid khachHangId, double no = 0)
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<HoaDon> hoadonRepo = new Repository<HoaDon>(dbCxt);
                Repository<ChiTietHoaDon> chitiethoadonRepo = new Repository<ChiTietHoaDon>(dbCxt);
                Repository<LoSanPham> lspRepo = new Repository<LoSanPham>(dbCxt);

                HoaDon hoaDon = new HoaDon()
                {
                    Id = Guid.NewGuid(),
                    KhachHangId = khachHangId == Guid.Empty ? Constants.DefaultUser : khachHangId,
                    NhanVienId = nhanVienId,
                    NgayLap = DateTime.Now,
                    No = no
                };

                var thayDoiSoLuongSanPhams = chiTietHoaDons.ToDictionary(cthd => cthd.LoSanPhamId, cthd => cthd.SoLuong);
                var lspCanThayDois = lspRepo.GetAll().ToList().Where(lsp => thayDoiSoLuongSanPhams.ContainsKey(lsp.Id)).ToList();
                foreach (var lsp in lspCanThayDois)
                {
                    lsp.SoLuong -= thayDoiSoLuongSanPhams[lsp.Id];
                    lspRepo.Update(lsp);
                }

                var cthds = chiTietHoaDons.Select(cthd => new ChiTietHoaDon()
                {
                    LoSanPhamId = cthd.LoSanPhamId,
                    HoaDonId = hoaDon.Id,
                    SoLuong = cthd.SoLuong,
                    DonGia = cthd.DonGia
                });

                hoadonRepo.Insert(hoaDon);
                cthds.ToList().ForEach(chitiethoadonRepo.Insert);
            }
        }

        private void btnOKTT_Click(object sender, EventArgs e)
        {
            // neu tiền thối lại âm thì sẽ tính là nợ
            if (!double.TryParse(txtTienThoiLai.Text, out double tienNo))
            {
                txtTienThoiLai.Focus();
                return;
            }
            if (!double.TryParse(txtTienKhachDua.Text, out double tienKhachDua))
            {
                MessageBox.Show("Xin nhập tiền khách đưa");
                txtTienKhachDua.Focus();
                return;
            }
            if (txtTienThoiLai.Text.StartsWith("-"))
            {
                if (makh != Guid.Empty && string.IsNullOrEmpty(tenkh))
                {
                    MessageBox.Show("Khách hàng chưa đăng kí không thể nợ");
                    Close();
                }
                else
                {
                    thanhtoanno = tienKhachDua - tienNo;

                    try
                    {
                        InsertDatabase(CuaSoChinh.manv, BanHang.MaKH, thanhtoanno);
                        CreateReceipt();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error during insert: " + ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    InsertDatabase(CuaSoChinh.manv, BanHang.MaKH);
                    CreateReceipt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during insert: " + ex.Message);
                }
            }
            Close();
        }

        public void CreateReceipt()
        {
            //--------------------------------------------//
            int total = 0;
            float cash = float.Parse(txtTienKhachDua.Text);
            float change = 0f;

            //this prints the reciept
            Bitmap bmp = new Bitmap(400, 1000);
            //Graphics graphic = e.Graphics;
            Graphics graphic = Graphics.FromImage(bmp);
            graphic.Clear(Color.White);

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString(lbtenshop.Text, new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);

            graphic.DrawString(lbdiachi.Text, font, new SolidBrush(Color.Black), startX, 40);

            graphic.DrawString(lbSDT.Text, font, new SolidBrush(Color.Black), startX, 60);
            offset = offset + 50;
            string top = "Sản phẩm".PadRight(21) + "SL".PadRight(10) + "Giá".PadRight(10);
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent


            float totalprice = 0f;

            foreach (string item in listBox2.Items)
            {
                var items = item.Split('/');
                string Ltensp = items[0].ToString();
                int Lsoluongsp = int.Parse(items[1].ToString());
                float Lgiasp = float.Parse(items[2].ToString());
                //    MessageBox.Show(productPrice.ToString());
                //create the string to print on the reciept
                //  string productDescription = item;
                //string productTotal = item.Substring(item.Length - 6, 6);
                float productTotal = float.Parse(txtTTOK.Text);
                //   float productPrice = float.Parse(item.Substring(item.Length - 5, 5));

                //totalprice += productPrice;
                totalprice = productTotal;

                string ten = Ltensp;
                string dongia = Lgiasp.ToString();
                string slsp = Lsoluongsp.ToString();
                graphic.DrawString(ten, font, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString(slsp, font, new SolidBrush(Color.Black), 230, startY + offset);
                graphic.DrawString(dongia, font, new SolidBrush(Color.Black), 320, startY + offset);
                offset = offset + (int)fontHeight + 5; //make the spacing consistent
            }

            change = float.Parse(txtTienThoiLai.Text);

            //when we have drawn all of the items add the total

            offset = offset + 20; //make some room so that the total stands out.

            graphic.DrawString("Tổng cộng ".PadRight(30) + totalprice.ToString("###,###"), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString("Tiền khách đưa ".PadRight(30) + cash.ToString("###,###"), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
            graphic.DrawString("Tiền thối lại ".PadRight(30) + change.ToString("###,###"), font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString(lbLoichao.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;

            var receiptPath = $"{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}_{txtTenKh.Text}_{makh}.png";
            bmp.Save(receiptPath);
            new Process
            {
                StartInfo = new ProcessStartInfo(receiptPath)
                {
                    UseShellExecute = true
                }
            }.Start();
            graphic.Dispose();
        }

        private void BanHangTT_Load(object dataSource, EventArgs e)
        {
            lbtenshop.Text = "Khang Chi";
            lbSDT.Text = "0907033339";
            lbdiachi.Text = "Bình phước";
            lbLoichao.Text = "Hẹn gặp lại bạn trong lần tới!";
        }

        private void btnTraDu_Click(object sender, EventArgs e)
        {
            txtTienKhachDua.Text = txtTTOK.Text;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            int tien0k = 0;
            txtTienKhachDua.Text = tien0k.ToString();
        }
    }
}
