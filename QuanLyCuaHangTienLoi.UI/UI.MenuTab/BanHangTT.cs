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


namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    public partial class BanHangTT : Form
    {
        SqlConnection connect = ClassKetnoi.connect;

        ListBox listBox2 = new ListBox();
        public static string thoilai = "";
        int TienOK; //textbox thanh toán
        int txtno; // tien no neu co
        int thanhtoanno; //set tiền thanh toán sql nếu có nợ
        string sdtkh = BanHang.TenKH;
        string tenkh = BanHang.SDT;

        SqlCommand cmd = new SqlCommand();
        SqlDataReader rdr;

        Label lbtenshop = new Label();
        Label lbdiachi = new Label();
        Label lbSDT = new Label();
        Label lbLoichao = new Label();

        public BanHangTT(ListBox.ObjectCollection Items)
        {
            InitializeComponent();
            txtTTOK.Text = BanHang.thanhtoan;
            listBox2.Items.AddRange(Items);
        }

        private void btn50k_Click(object sender, EventArgs e)
        {
            double tien50k = 50000;
            txtTienKhachDua.Text = tien50k.ToString("###,###");
        }

        private void btn100k_Click(object sender, EventArgs e)
        {
            double tien100k = 100000;
            txtTienKhachDua.Text = tien100k.ToString("###,###");
        }

        private void btn200k_Click(object sender, EventArgs e)
        {
            double tien200k = 200000;
            txtTienKhachDua.Text = tien200k.ToString("###,###");
        }

        private void btn500k_Click(object sender, EventArgs e)
        {
            double tien500k = 500000;
            txtTienKhachDua.Text = tien500k.ToString("###,###");
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
                txtTienThoiLai.Text = TienThoiLai.ToString("###,###");
            }

        }

        private void btnHuyTT_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnOKTT_Click(object sender, EventArgs e)
        {
            // neu tiền thối lại âm thì sẽ tính là nợ
            string txttienthoi = txtTienThoiLai.Text;
            if (txtTienThoiLai.Text.StartsWith("-"))
            {
                if (string.IsNullOrEmpty(sdtkh) && string.IsNullOrEmpty(tenkh))
                {
                    MessageBox.Show("Khách hàng chưa đăng kí không thể nợ");
                    Close();
                }
                else
                {
                    string RemovetxtTienthoi = Regex.Replace(txttienthoi, @"[^0-9a-zA-Z]+", "");
                    MessageBox.Show(RemovetxtTienthoi);
                    txtno = int.Parse(RemovetxtTienthoi);
                    thanhtoanno = int.Parse(txtTienKhachDua.Text);//tien no trong sql
                    TienOK = thanhtoanno; //tienthanhtoan trong sql = tiền khách đưa khi nợ


                    try
                    {
                        using (var cmd = new SqlCommand("INSERT INTO HoaDon (HDmasp,HDtensp,HDsl,HDdongia,HDloai,HDthanhtoan,HDdonvi,HDno,SDT,TenKH,HDtime,nvthanhtoan) VALUES (@HDmasp,@HDtensp,@HDsl,@HDdongia,@HDloai, @HDthanhtoan,@HDdonvi,@HDno,@SDT,@TenKH,@HDtime,@nvthanhtoan)"))
                        {
                            cmd.Connection = connect;
                            //  cmd.Parameters.AddWithValue("@IDhoadon", BanHang.IDhoadon);
                            cmd.Parameters.AddWithValue("@HDmasp", BanHang.HDmasp);
                            cmd.Parameters.AddWithValue("@HDtensp", BanHang.HDtensp);
                            cmd.Parameters.AddWithValue("@HDsl", BanHang.HDsl);
                            cmd.Parameters.AddWithValue("@HDdongia", BanHang.HDdongia);
                            cmd.Parameters.AddWithValue("@HDloai", BanHang.HDloai);
                            cmd.Parameters.AddWithValue("@HDthanhtoan", TienOK);//

                            cmd.Parameters.AddWithValue("@HDdonvi", BanHang.HDdonvi);
                            cmd.Parameters.AddWithValue("@HDno", txtno);

                            cmd.Parameters.AddWithValue("@SDT", BanHang.SDT);
                            cmd.Parameters.AddWithValue("@TenKH", BanHang.TenKH);
                            cmd.Parameters.Add("@HDtime", SqlDbType.DateTime);
                            cmd.Parameters["@HDtime"].Value = DateTime.Now;
                            cmd.Parameters.AddWithValue("@nvthanhtoan", CuaSoChinh.tennv);
                            connect.Open();
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                // MessageBox.Show("Đã thêm");
                                connect.Close();
                                PrintDialog printDialog = new PrintDialog();

                                PrintDocument printDocument = new PrintDocument();

                                printDialog.Document = printDocument; //add the document to the dialog box...        

                                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

                                //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

                                DialogResult result = printDialog.ShowDialog();

                                if (result == DialogResult.OK)
                                {
                                    printDocument.Print();

                                }
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Thêm không thành công!");
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
            else
            {
                ////them vao sql khi khach không nợ
                txtno = 0;
                string tienthanhtoan = txtTTOK.Text;
                string CutTien = Regex.Replace(tienthanhtoan, @"[^0-9a-zA-Z]+", "");
                TienOK = int.Parse(CutTien);//tienthanhtoan trong sql = tiền thánh toán

                try
                {
                    using (var cmd = new SqlCommand("INSERT INTO HoaDon (HDmasp,HDtensp,HDsl,HDdongia,HDloai,HDthanhtoan,HDdonvi,HDno,SDT,TenKH,HDtime,nvthanhtoan) VALUES (@HDmasp,@HDtensp,@HDsl,@HDdongia,@HDloai, @HDthanhtoan,@HDdonvi,@HDno,@SDT,@TenKH,@HDtime,@nvthanhtoan)"))
                    {
                        cmd.Connection = connect;
                        //  cmd.Parameters.AddWithValue("@IDhoadon", BanHang.IDhoadon);
                        cmd.Parameters.AddWithValue("@HDmasp", BanHang.HDmasp);
                        cmd.Parameters.AddWithValue("@HDtensp", BanHang.HDtensp);
                        cmd.Parameters.AddWithValue("@HDsl", BanHang.HDsl);
                        cmd.Parameters.AddWithValue("@HDdongia", BanHang.HDdongia);
                        cmd.Parameters.AddWithValue("@HDloai", BanHang.HDloai);
                        cmd.Parameters.AddWithValue("@HDthanhtoan", TienOK);//

                        cmd.Parameters.AddWithValue("@HDdonvi", BanHang.HDdonvi);
                        cmd.Parameters.AddWithValue("@HDno", txtno);

                        cmd.Parameters.AddWithValue("@SDT", BanHang.SDT);
                        cmd.Parameters.AddWithValue("@TenKH", BanHang.TenKH);
                        cmd.Parameters.Add("@HDtime", SqlDbType.DateTime);
                        cmd.Parameters["@HDtime"].Value = DateTime.Now;
                        cmd.Parameters.AddWithValue("@nvthanhtoan", CuaSoChinh.tennv);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            // MessageBox.Show("Đã thêm");
                            connect.Close();

                            //update sql so luong
                            //using (var cmd2 = new SqlCommand("update sanpham set soluongsp = soluongsp - 1 where masp=@masp"))
                            //{
                            //    cmd2.Connection = connect;
                            //    cmd2.Parameters.AddWithValue("@masp", txtid.Text);
                            //    connect.Open();
                            //    if (cmd2.ExecuteNonQuery() > 0)
                            //    {
                            //        MessageBox.Show("Đã xóa");                               
                            //    }
                            //    else
                            //    {
                            //        MessageBox.Show("Không thành công!");
                            //    }
                            //    connect.Close();
                            //}

                            ///print hoa don
                            PrintDialog printDialog = new PrintDialog();

                            PrintDocument printDocument = new PrintDocument();

                            printDialog.Document = printDocument; //add the document to the dialog box...        

                            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

                            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

                            DialogResult result = printDialog.ShowDialog();

                            if (result == DialogResult.OK)
                            {
                                printDocument.Print();

                            }
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Thêm không thành công!");
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


            Close();
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //--------------------------------------------//
            int total = 0;
            float cash = float.Parse(txtTienKhachDua.Text);
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
        }

        private void BanHangTT_Load(object dataSource, EventArgs e)
        {

            try
            {
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
