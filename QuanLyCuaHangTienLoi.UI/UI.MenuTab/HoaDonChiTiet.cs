using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.DisplayObject;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;
namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    public partial class HoaDonChiTiet : Form
    {
        Label lbtenshop = new Label();
        Label lbdiachi = new Label();
        Label lbSDT = new Label();
        Label lbLoichao = new Label();

        string tenKh = string.Empty;
        string maKh = string.Empty;

        public HoaDonChiTiet()
        {
            InitializeComponent();
        }

        private void HoaDonChiTiet_Load(object sender, EventArgs e)
        {
            lbtenshop.Text = "Khang Chi";
            lbSDT.Text = "0907033339";
            lbdiachi.Text = "Bình phước";
            lbLoichao.Text = "Hẹn gặp lại bạn trong lần tới!";

            try
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<HoaDon> hdRepo = new Repository<HoaDon>(dbCxt);
                    Repository<ChiTietHoaDon> cthdRepo = new Repository<ChiTietHoaDon>(dbCxt);

                    var chitiethoadons = cthdRepo.Query(cthd => cthd.HoaDonId == DonHang.hdid).Select(cthd => new HienThiChiTietHoaDon
                    {
                        SanPhamId = cthd.LoSanPham.SanPhamId,
                        TenSanPham = cthd.LoSanPham.SanPham.TenSanPham,
                        SoLuong = cthd.SoLuong,
                        DonGia = cthd.DonGia
                    });
                    dataGridViewct.DataSource = chitiethoadons.ToList().ToDataTable();

                    var hoadon = hdRepo.Query(hd => hd.Id == DonHang.hdid).Include(hd => hd.KhachHang).FirstOrDefault();
                    txtBoxNo.Text = string.Format("{0:N2}", hoadon.No);
                    tenKh = hoadon.KhachHang.TenKhachHang;
                    maKh = hoadon.KhachHangId.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //todo replace print
            //PrintDialog printDialog = new PrintDialog();
            //PrintDocument printDocument = new PrintDocument();
            //PaperSize pageSize = new PaperSize();
            //pageSize.Width = 284;
            //printDocument.DefaultPageSettings.PaperSize = pageSize;

            //printDialog.Document = printDocument; //add the document to the dialog box...        

            //printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(HDthuong); //add an event handler that will do the printing
            //DialogResult result = printDialog.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    printDocument.Print();

            //}
            HDthuong(null, null);
            Close();
        }
        public void HDthuong(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //todo replace print
            ListBox listBoxHD1 = new ListBox();
            foreach (DataGridViewRow item in dataGridViewct.Rows)
            {
                listBoxHD1.Items.Add(item.Cells[1].Value.ToString() + '/' + item.Cells[2].Value.ToString() + '/' + item.Cells[3].Value.ToString());
            }
            //--------------------------------------------//

            int total = 0;
            //float cash = float.Parse(txtTienKhachDua.Text);
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

            foreach (string item in listBoxHD1.Items)
            {
                var items = item.Split('/');
                string Ltensp = items[0].ToString();
                int Lsoluongsp = int.Parse(items[1].ToString());
                float Lgiasp = float.Parse(items[2].ToString());
                //    MessageBox.Show(productPrice.ToString());
                //create the string to print on the reciept
                //  string productDescription = item;
                //string productTotal = item.Substring(item.Length - 6, 6);
                float productTotal = Lgiasp * Lsoluongsp;
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
            //  change = float.Parse(txtTienThoiLai.Text);
            //when we have drawn all of the items add the total
            offset = offset + 20; //make some room so that the total stands out.

            graphic.DrawString("Tổng cộng ".PadRight(30) + totalprice.ToString("###,###"), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 30; //make some room so that the total stands out.
            //graphic.DrawString("Tiền khách đưa ".PadRight(30) + cash.ToString("###,###"), font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + 15;
            //graphic.DrawString("Tiền thối lại ".PadRight(30) + change.ToString("###,###"), font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString(lbLoichao.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;

            var receiptPath = $"{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}_{tenKh}_{maKh}.png";
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            //todo replace excel
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridViewct.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewct.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridViewct.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewct.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridViewct.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            //  workbook.SaveAs("C:\\Users\\lionel\\Desktop\\Test\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //  app.Quit(); 
        }

        private void btnthanhtoanno_Click(object sender, EventArgs e)
        {
            string mahoadon = dataGridViewct.Rows[0].Cells[0].Value.ToString();
            if (!double.TryParse(txtBoxNo.Text, out double tienno))
            {
                MessageBox.Show("Giá trị không hợp lệ.");
                txtBoxNo.Focus();
            }
            if (!double.TryParse(textBoxttNo.Text, out double tientrano))
            {
                MessageBox.Show("Giá trị không hợp lệ.");
                textBoxttNo.Focus();
            }
            double updatetienno;
            double tienthoilai;
            //MessageBox.Show(tienno.ToString());
            //MessageBox.Show(tientrano.ToString());

            updatetienno = tienno - tientrano;
            //MessageBox.Show(updatetienno.ToString());
            if (tientrano > tienno)
            {
                tienthoilai = tientrano - tienno;
                updatetienno = 0;

                MessageBox.Show(tienthoilai.ToString());
            }

            if (string.IsNullOrWhiteSpace(textBoxttNo.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {
                try
                {
                    txtBoxNo.Text = string.Format("{0:N2}", updatetienno);
                    //todo db hoadon
                    using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                    {
                        Repository<HoaDon> hdRepo = new Repository<HoaDon>(dbCxt);
                        var hoadon = hdRepo.Query(hd => hd.Id == DonHang.hdid).FirstOrDefault();
                        if (hoadon == null)
                        {
                            MessageBox.Show("Hóa đơn không tồn tại");
                            return;
                        }

                        hoadon.No = updatetienno;
                        hoadon.NhanVienId = CuaSoChinh.manv;
                        hdRepo.Update(hoadon);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during insert: " + ex.Message);
                }
            }
        }
    }
}
