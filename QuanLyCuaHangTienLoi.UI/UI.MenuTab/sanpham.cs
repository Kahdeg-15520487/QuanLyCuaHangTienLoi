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
using System.IO;
using System.Text.RegularExpressions;

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{

    public partial class SanPham : Form
    {
        SqlConnection connect = ClassKetnoi.connect;

        SqlCommand command;

        public SanPham()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridviewsp();

            //todo db sanpham
            // string querysp = @"select masp as 'Mã sản phẩm', tensp as 'Tên sản phẩm', soluongsp as 'Số lượng', gianhapsp as 'Giá nhập', giabansp as 'Giá bán', loaisp as 'Loại', donvisp as 'Đơn vị'from sanpham;";
            string queryloai = @"select * from loaisp";
            string querydonvi = @"select * from donvisp";

            // SqlDataAdapter sqldatasp = new SqlDataAdapter(querysp, connect);
            SqlDataAdapter sqldataloai = new SqlDataAdapter(queryloai, connect);
            SqlDataAdapter sqldatadonvi = new SqlDataAdapter(querydonvi, connect);

            // DataTable datatbsp = new DataTable();
            DataTable datatbloai = new DataTable();
            DataTable datatbdonvi = new DataTable();

            // sqldatasp.Fill(datatbsp);
            sqldataloai.Fill(datatbloai);
            sqldatadonvi.Fill(datatbdonvi);

            //combobox
            comboloai.Items.Clear();
            combodonvi.Items.Clear();
            foreach (DataRow dr in datatbloai.Rows)
            {
                comboloai.Items.Add(dr["TenLoai"].ToString());
            }
            foreach (DataRow dr2 in datatbdonvi.Rows)
            {
                combodonvi.Items.Add(dr2["TenDonvi"].ToString());
            }
            connect.Close();
        }

        public void gridviewsp()
        {
            //todo db sanpham
            string querysp = @"select masp as 'Mã sản phẩm', tensp as 'Tên sản phẩm', soluongsp as 'Số lượng', gianhapsp as 'Giá nhập', giabansp as 'Giá bán', loaisp as 'Loại', donvisp as 'Đơn vị', ngaynhapkho as 'Ngày nhập kho', nvnhapkho as 'Nhân viên' from nhapkho";
            SqlDataAdapter sqldatasp = new SqlDataAdapter(querysp, connect);
            DataTable datatbsp = new DataTable();
            sqldatasp.Fill(datatbsp);
            dataGridView1.DataSource = datatbsp;
            connect.Close();
        }

        public void clearsp()
        {
            txtid.Clear();
            txttensp.Clear();
            txtsl.Clear();
            txtgianhap.Clear();
            txtgiaban.Clear();
            comboloai.SelectedItem = null;
            combodonvi.SelectedItem = null;
            pictureBox1.Image = Properties.Resources._default;
        }


        private void autoid()
        {
            if (comboloai.SelectedIndex == -1)
            {
                MessageBox.Show("Xin chọn loại sản phẩm");
                return;
            }
            else
            {
                string s3;
                string comboselected = this.comboloai.GetItemText(this.comboloai.SelectedItem);

                string s1 = comboselected.Substring(0, 1);
                string s2 = comboselected.Substring(comboselected.IndexOf(" ") + 1);

                if (s2 == null)
                {
                    string s1a = s1.Substring(0, 1).ToUpper();
                    string s2a = s1.Substring(0, 1).ToUpper();
                    s3 = String.Concat(s1a, s2a);

                    //todo db sanpham
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("select count(masp) from nhapkho", connect);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    connect.Close();

                    i++;
                    //  MessageBox.Show(s3);
                    txtid.Text = s3 + i.ToString();
                }
                else
                {
                    //todo wtf
                    bool timA; bool timE; bool TimI; bool TimO; bool TimU; bool TimY; bool TimD;
                    string s1a = s1.Substring(0, 1).ToUpper();
                    string s2a = s2.Substring(0, 1).ToLower();
                    Regex a1 = new Regex("à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ");
                    Regex e1 = new Regex("è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ");
                    Regex i1 = new Regex("ì|í|ị|ỉ|ĩ");
                    Regex o1 = new Regex("ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ");
                    Regex u1 = new Regex("ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ");
                    Regex y1 = new Regex("ỳ|ý|ỵ|ỷ|ỹ");
                    Regex d1 = new Regex("đ");
                    if (timA = a1.IsMatch(s2a))
                    {
                        s3 = String.Concat(s1a, "A");
                    }
                    else if (timE = e1.IsMatch(s2a))
                    {
                        s3 = String.Concat(s1a, "E");
                    }
                    else if (TimI = i1.IsMatch(s2a))
                    {
                        s3 = String.Concat(s1a, "I");
                    }
                    else if (TimO = o1.IsMatch(s2a))
                    {
                        s3 = String.Concat(s1a, "O");
                    }
                    else if (TimU = u1.IsMatch(s2a))
                    {
                        s3 = String.Concat(s1a, "U");
                    }
                    else if (TimY = y1.IsMatch(s2a))
                    {
                        s3 = String.Concat(s1a, "Y");
                    }
                    else if (TimD = d1.IsMatch(s2a))
                    {
                        s3 = String.Concat(s1a, "D");
                    }
                    else
                    {
                        MessageBox.Show("ko tim thay");
                        s3 = String.Concat(s1a, s2a);
                    }

                    //todo db sanpham
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("select count(masp) from nhapkho", connect);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    connect.Close();
                    i++;
                    txtid.Text = s3 + i.ToString();
                }
            }
        }
        private void sanpham_Load(object sender, EventArgs e)
        {
            txtKhuyenmai.Text = "0";
            txtid.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                MessageBox.Show("Trống mã sản phẩm!");
                txtid.Select();
            }

            if (string.IsNullOrWhiteSpace(txttensp.Text))
            {
                txttensp.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtsl.Text))
            {
                txtsl.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtgianhap.Text))
            {
                txtgianhap.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtgiaban.Text))
            {
                txtgiaban.Select();
            }
            else if (comboloai.SelectedIndex == -1)
            {
                comboloai.Select();
            }
            else
            {
                //todo db sanpham nhap kho
                //---------------- nhap kho ---------------------//
                using (var cmd = new SqlCommand("INSERT INTO nhapkho (masp,tensp,soluongsp,gianhapsp,giabansp,loaisp,donvisp,ngaynhapkho,nvnhapkho) VALUES (@masp,@tensp,@soluongsp,@gianhapsp, @giabansp,@loaisp,@donvisp,@ngaynhapkho,@nvnhapkho)"))
                {
                    cmd.Connection = connect;
                    cmd.Parameters.AddWithValue("@masp", txtid.Text);
                    cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
                    cmd.Parameters.AddWithValue("@soluongsp", txtsl.Text);
                    cmd.Parameters.AddWithValue("@gianhapsp", txtgianhap.Text);
                    cmd.Parameters.AddWithValue("@giabansp", txtgiaban.Text);
                    cmd.Parameters.AddWithValue("@loaisp", comboloai.GetItemText(comboloai.SelectedItem));
                    cmd.Parameters.AddWithValue("@donvisp", combodonvi.GetItemText(combodonvi.SelectedItem));
                    cmd.Parameters.Add("@ngaynhapkho", SqlDbType.DateTime);
                    cmd.Parameters["@ngaynhapkho"].Value = DateTime.Now;
                    cmd.Parameters.AddWithValue("@nvnhapkho", DangNhap.usernv);
                    connect.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã thêm");
                        connect.Close();
                        // clearsp();
                        gridviewsp();

                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công!");
                        connect.Close();
                    }
                    connect.Close();

                }

                //todo db sanpham ton kho
                //---------------- ton kho ---------------------//
                using (var cmd3 = new SqlCommand("select masp from tonkho where masp=@masp"))
                {
                    cmd3.Connection = connect;
                    cmd3.Parameters.AddWithValue("@masp", txtid.Text);
                    connect.Open();
                    // cmd3.ExecuteNonQuery();

                    SqlDataReader reader = cmd3.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //  connect.Close();
                        // da ton tai
                        using (var cmd4 = new SqlCommand("update tonkho set tensp=@tensp,soluongsp=@soluongsp,gianhapsp=@gianhapsp,giabansp=@giabansp,loaisp=@loaisp,donvisp=@donvisp,giamgia=@giamgia where masp=@masp"))
                        {
                            cmd4.Connection = connect;
                            cmd4.Parameters.AddWithValue("@masp", txtid.Text);
                            cmd4.Parameters.AddWithValue("@tensp", txttensp.Text);
                            cmd4.Parameters.AddWithValue("@soluongsp", txtsl.Text);
                            cmd4.Parameters.AddWithValue("@gianhapsp", txtgianhap.Text);
                            cmd4.Parameters.AddWithValue("@giabansp", txtgiaban.Text);
                            cmd4.Parameters.AddWithValue("@loaisp", comboloai.GetItemText(comboloai.SelectedItem));
                            cmd4.Parameters.AddWithValue("@donvisp", combodonvi.GetItemText(combodonvi.SelectedItem));
                            cmd4.Parameters.AddWithValue("@giamgia", txtKhuyenmai.Text);
                            connect.Close();
                            connect.Open();
                            if (cmd4.ExecuteNonQuery() > 0)
                            {
                                connect.Close();
                                //  MessageBox.Show("Đã thêm");
                                //  gridviewsp();
                                clearsp();
                            }
                            else
                            {
                                connect.Close();
                                // MessageBox.Show("Thêm không thành công!");
                            }
                            connect.Close();
                        }
                        connect.Close();
                    }

                    else
                    {
                        connect.Close();
                        //khong ton tai
                        //todo db sanpham ton kho
                        using (var cmd2 = new SqlCommand("INSERT INTO tonkho (masp,tensp,soluongsp,gianhapsp,giabansp,loaisp,donvisp,giamgia) VALUES (@masp,@tensp,@soluongsp,@gianhapsp, @giabansp,@loaisp,@donvisp,@giamgia)"))
                        {
                            cmd2.Connection = connect;
                            cmd2.Parameters.AddWithValue("@masp", txtid.Text);
                            cmd2.Parameters.AddWithValue("@tensp", txttensp.Text);
                            cmd2.Parameters.AddWithValue("@soluongsp", txtsl.Text);
                            cmd2.Parameters.AddWithValue("@gianhapsp", txtgianhap.Text);
                            cmd2.Parameters.AddWithValue("@giabansp", txtgiaban.Text);
                            cmd2.Parameters.AddWithValue("@loaisp", comboloai.GetItemText(comboloai.SelectedItem));
                            cmd2.Parameters.AddWithValue("@donvisp", combodonvi.GetItemText(combodonvi.SelectedItem));
                            cmd2.Parameters.AddWithValue("@giamgia", txtKhuyenmai.Text);

                            connect.Open();
                            if (cmd2.ExecuteNonQuery() > 0)
                            {
                                connect.Close();
                                //MessageBox.Show("Đã thêm");
                                //gridviewsp();
                                clearsp();
                            }
                            else
                            {
                                connect.Close();
                                //   MessageBox.Show("Thêm không thành công!");
                            }
                            connect.Close();
                        }
                        connect.Close();
                    }
                    reader.Close();
                    connect.Close();
                }
                //---------------- ton kho ---------------------//

                txtid.ReadOnly = true;
            }

        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                clearsp();

                txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txttensp.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtsl.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtgianhap.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtgiaban.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                comboloai.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                combodonvi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

                try
                {
                    //todo db sanpham anhsp
                    string sql1 = "select anhsp from nhapkho where masp='" + txtid.Text + "' ";

                    if (connect.State != ConnectionState.Open)
                        connect.Open();
                    command = new SqlCommand(sql1, connect);
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();
                    if (reader.HasRows)
                    {
                        //byte[] img = (byte[])(reader[0]);
                        //if (img == null)
                        //{
                        //    pictureBox1.Image = null;
                        //}
                        //else
                        //{
                        //    MemoryStream ms = new MemoryStream(img);
                        //    pictureBox1.Image = Image.FromStream(ms);

                        //}
                        ////  MessageBox.Show(img.ToString());
                        //connect.Close();
                    }
                    else
                    {
                        connect.Close();
                        MessageBox.Show("bi loi");
                    }

                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show("loi bang: " + ex.Message);
                }
                txtid.ReadOnly = true;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {
                try
                {
                    //todo db sanpham nhap kho
                    using (var cmd = new SqlCommand("update nhapkho set tensp=@tensp,soluongsp=@soluongsp,gianhapsp=@gianhapsp,giabansp=@giabansp,loaisp=@loaisp,donvisp=@donvisp,ngaynhapkho=@ngaynhapkho,nvnhapkho=@nvnhapkho where masp=@masp"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@masp", txtid.Text);
                        cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
                        cmd.Parameters.AddWithValue("@soluongsp", txtsl.Text);
                        cmd.Parameters.AddWithValue("@gianhapsp", txtgianhap.Text);
                        cmd.Parameters.AddWithValue("@giabansp", txtgiaban.Text);
                        cmd.Parameters.AddWithValue("@loaisp", comboloai.GetItemText(comboloai.SelectedItem));
                        cmd.Parameters.AddWithValue("@donvisp", combodonvi.GetItemText(combodonvi.SelectedItem));
                        cmd.Parameters.Add("@ngaynhapkho", SqlDbType.DateTime);
                        cmd.Parameters["@ngaynhapkho"].Value = DateTime.Now;
                        cmd.Parameters.AddWithValue("@nvnhapkho", DangNhap.usernv);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã lựu");
                            gridviewsp();
                            txtid.ReadOnly = true;
                        }
                        else
                        {
                            MessageBox.Show("Lưu không thành công!");
                            txtid.ReadOnly = true;
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {
                try
                {
                    //todo db sanpham nhap kho
                    using (var cmd = new SqlCommand("delete nhapkho where masp=@masp"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@masp", txtid.Text);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã xóa");
                            clearsp();
                            gridviewsp();
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

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearsp();
        }

        private void btnDeleteIMG_Click(object sender, EventArgs e)
        {
            try
            {
                //todo db sanpham nhap kho
                using (var cmd = new SqlCommand("update nhapkho set anhsp=null where masp=@masp"))
                {
                    cmd.Connection = connect;
                    cmd.Parameters.AddWithValue("@masp", txtid.Text);
                    connect.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã xóa");
                        clearsp();
                        gridviewsp();
                    }
                    else
                    {
                        MessageBox.Show("Không thành công!");
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //todo db sanpham nhap kho
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("select masp,tensp,soluongsp,gianhapsp,giabansp,loaisp,donvisp from nhapkho where ( masp like '" + txtsearch.Text + "%' or tensp like N'" + txtsearch.Text + "%' or soluongsp like '" + txtsearch.Text + "%' or gianhapsp like '" + txtsearch.Text + "%' or giabansp like '" + txtsearch.Text + "%'  or loaisp like N'" + txtsearch.Text + "%'  or donvisp like N'" + txtsearch.Text + "%'     )", connect))
                {
                    DataTable dtsearch = new DataTable("nhapkho");
                    da.Fill(dtsearch);
                    dataGridView1.DataSource = dtsearch;

                }
                connect.Close();
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows != null)
                {
                    LabelSearch.Text = "Đã tìm thấy";
                }
                else
                {
                    LabelSearch.Text = "Không tìm thấy...";
                }

                if (string.IsNullOrWhiteSpace(txtsearch.Text))
                {
                    LabelSearch.Text = "Tìm kiếm";
                }


            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);
            }

        }

        private void comboloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                autoid();
                txtid.ReadOnly = false;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
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
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            //  workbook.SaveAs("C:\\Users\\lionel\\Desktop\\Test\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //  app.Quit(); 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string getdate = dateTimePicker1.Value.Date.ToString("MM/dd/yyyy");
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }

                //todo db sanpham nhap kho
                using (SqlDataAdapter da = new SqlDataAdapter("select masp,tensp,soluongsp,gianhapsp,giabansp,loaisp,donvisp,ngaynhapkho,nvnhapkho from nhapkho where cast ([ngaynhapkho] as date) = '" + getdate + "'      ", connect))
                {
                    DataTable dtsearch = new DataTable("nhapkho");
                    da.Fill(dtsearch);
                    dataGridView1.DataSource = dtsearch;

                }
                connect.Close();
                if (dataGridView1.Rows.Count > 1 && dataGridView1.Rows != null)
                {
                    // labelSearch.Text = "Đã tìm thấy";
                }
                else
                {
                    //  labelSearch.Text = "Không tìm thấy...";
                }
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
