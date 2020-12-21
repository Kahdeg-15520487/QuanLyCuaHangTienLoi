using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        SqlConnection connect = ClassKetnoi.connect;

        SqlCommand cmd = new SqlCommand();
        SqlDataReader rdr;
        Label lbtenshop = new Label();
        Label lbdiachi = new Label();
        Label lbSDT = new Label();
        Label lbLoichao = new Label();

        public HoaDonChiTiet()
        {
            InitializeComponent();

            try
            {
                //todo db thongtinshop
                connect.Open();
                cmd.CommandText = "select TenShop,Diachi,SDT,Loichao from ThongTinShop where ID='1'";
                cmd.Connection = connect;
                rdr = cmd.ExecuteReader();
                bool temp = false;
                while (rdr.Read())
                {
                    lbtenshop.Text = rdr.GetString(0);
                    lbSDT.Text = rdr.GetString(2);
                    lbdiachi.Text = rdr.GetString(1);
                    lbLoichao.Text = rdr.GetString(3);
                    temp = true;
                }
                if (temp == false)
                    MessageBox.Show("not found");
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HoaDonChiTiet_Load(object sender, EventArgs e)
        {
            string StringID = DonHang.hdid;
            string StringMasp = DonHang.hdmasp;
            string StringHDtensp = DonHang.hdtensp;
            string StringHDsl = DonHang.hdsl;
            string StringHDdongia = DonHang.hddongia;
            string StringHDloai = DonHang.hdloai;
            string StringHDdonvi = DonHang.hddonvi;
            string StringHDthanhtoan = DonHang.hdthanhtoan;
            string StringHDsdt = DonHang.sdt;
            string StringHDtenKH = DonHang.tenkh;
            string StringHDtime = DonHang.hdtime;
            string StringHDno = DonHang.hdno;
            string StringHDnvtt = DonHang.nvtt;

            string[] item0 = StringID.Split(',');
            string[] item1 = StringMasp.Split(',');
            string[] item2 = StringHDtensp.Split(',');
            string[] item3 = StringHDsl.Split(',');
            string[] item4 = StringHDdongia.Split(',');
            string[] item5 = StringHDloai.Split(',');
            string[] item6 = StringHDdonvi.Split(',');
            string[] item7 = StringHDthanhtoan.Split(',');
            string[] item8 = StringHDsdt.Split(',');
            string[] item9 = StringHDtenKH.Split(',');
            string[] item10 = StringHDtime.Split(',');


            //masp
            foreach (string x1 in item1)
            {
                int n = dataGridViewct.Rows.Add();
                dataGridViewct.Rows[n].Cells[2].Value = x1;
                //dataGridView1.Rows[index].Cells[1].Value = x1;
                //index++;
                //MessageBox.Show(x1);
            }
            // ID
            dataGridViewct.Rows[0].Cells[0].Value = StringID;

            //ten KH
            dataGridViewct.Rows[0].Cells[1].Value = StringHDtenKH;

            //ten sp
            int index = 0;
            foreach (string x3 in item2)
            {
                dataGridViewct.Rows[index].Cells[3].Value = x3;
                index++;
            }
            // sl san pham
            int index1 = 0;
            foreach (string x4 in item3)
            {
                //  MessageBox.Show(x4);
                dataGridViewct.Rows[index1].Cells[5].Value = x4;
                index1++;
            }
            // don gia
            int index2 = 0;
            foreach (string x5 in item4)
            {
                dataGridViewct.Rows[index2].Cells[7].Value = x5;
                index2++;
            }
            // tien thanh toan
            dataGridViewct.Rows[0].Cells[8].Value = StringHDthanhtoan;

            //thoi gian thanh toan
            dataGridViewct.Rows[0].Cells[9].Value = StringHDtime;
            // loai sp
            int index3 = 0;
            foreach (string x8 in item5)
            {
                dataGridViewct.Rows[index3].Cells[4].Value = x8;
                index3++;
            }
            int index4 = 0;
            // don vi sp
            foreach (string x9 in item6)
            {
                dataGridViewct.Rows[index4].Cells[6].Value = x9;
                index4++;
            }
            //sdt
            dataGridViewct.Rows[0].Cells[10].Value = StringHDsdt;

            dataGridViewct.Rows[0].Cells[11].Value = StringHDno;//no
            dataGridViewct.Rows[0].Cells[12].Value = StringHDnvtt;//nhan vien thanh toan 

            //thay the o trong trong datagridview = " "
            foreach (DataGridViewRow item in dataGridViewct.Rows)
            {
                for (int i = 0; i < item.Cells.Count; i++)
                {
                    if (item.Cells[i].Value == null || item.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(item.Cells[i].Value.ToString()))
                    {
                        for (int n = 1; n < dataGridViewct.Rows.Count; n++)
                        {
                            dataGridViewct.Rows[n].Cells[i].Value = " ";
                        }
                    }
                    else
                    {
                        ////    listBox1test.Items.Add(item.Cells[0].Value.ToString() + '/');

                    }

                }
                // listBoxHD2.Items.Add(item.Cells[0].Value.ToString() + '/' + item.Cells[1].Value.ToString() + '/' + item.Cells[2].Value.ToString() + '/' + item.Cells[3].Value.ToString() + '/' + item.Cells[4].Value.ToString() + '/' + item.Cells[5].Value.ToString() + '/' + item.Cells[6].Value.ToString() + '/' + item.Cells[7].Value.ToString() + '/' + item.Cells[8].Value.ToString() + '/' + item.Cells[9].Value.ToString() + '/' + item.Cells[10].Value.ToString() + '/' + item.Cells[11].Value.ToString() + '/' + item.Cells[12].Value.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //todo replace print
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            PaperSize pageSize = new PaperSize();
            pageSize.Width = 284;
            printDocument.DefaultPageSettings.PaperSize = pageSize;

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(HDthuong); //add an event handler that will do the printing
            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();

            }
            Close();
        }
        public void HDthuong(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //todo replace print
            ListBox listBoxHD1 = new ListBox();
            foreach (DataGridViewRow item in dataGridViewct.Rows)
            {
                listBoxHD1.Items.Add(item.Cells[3].Value.ToString() + '/' + item.Cells[5].Value.ToString() + '/' + item.Cells[7].Value.ToString());
            }
            //--------------------------------------------//

            int total = 0;
            //float cash = float.Parse(txtTienKhachDua.Text);
            float change = 0f;

            //this prints the reciept

            Graphics graphic = e.Graphics;
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
                float productTotal = float.Parse(dataGridViewct.Rows[0].Cells[8].Value.ToString());
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
            int tienno = Convert.ToInt32(dataGridViewct.Rows[0].Cells[11].Value);
            int tientrano = Convert.ToInt32(textBoxttNo.Text);
            int updatetienno;
            int tienthoilai;
            //MessageBox.Show(tienno.ToString());
            //MessageBox.Show(tientrano.ToString());

            updatetienno = tienno - tientrano;
            //MessageBox.Show(updatetienno.ToString());
            if (tientrano > tienno)
            {
                tienthoilai = tientrano - tienno;
                updatetienno = 0;
                dataGridViewct.Rows[0].Cells[11].Value = 0;
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
                    dataGridViewct.Rows[0].Cells[11].Value = updatetienno;
                    //todo db hoadon
                    using (var cmd = new SqlCommand("update HoaDon set HDno=@HDno,nvthanhtoan=@nvthanhtoan where IDhoadon=@IDhoadon"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@IDhoadon", mahoadon);
                        cmd.Parameters.AddWithValue("@HDno", updatetienno);
                        cmd.Parameters.AddWithValue("@nvthanhtoan", CuaSoChinh.tennv);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã lưu");
                        }
                        else
                        {
                            MessageBox.Show("Lưu không thành công!");
                        }
                        connect.Close();
                    }
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show("Error during insert: " + ex.Message);
                }
            }
        }
    }
}
