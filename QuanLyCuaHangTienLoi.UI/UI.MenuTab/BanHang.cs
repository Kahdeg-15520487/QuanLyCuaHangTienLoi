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

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    public partial class BanHang : Form
    {
        SqlConnection connect = ClassKetnoi.connect;

        public static string thanhtoan = "";//nut Tính tiền chuyển tạm thời cho form TT
        public static string IDhoadon = "";
        public static string HDmasp = "";
        public static string HDtensp = "";
        public static string HDdongia = "";
        public static string HDsl = "";
        public static string HDloai = "";
        //  public static string HDthanhtoan = "";
        public static string HDdonvi = "";
        public static string SDT = "";
        public static string TenKH = "";

        int checkslsp;
        int indexRow = 0;
        string maspedit;
        int slspedit;
        string masp1;
        int slsp1;
        string colmasp;
        string coltensp;
        string colslsp;
        string colloaisp;
        string coldvsp;
        string coldongiasp;

        public BanHang()
        {
            InitializeComponent();
        }

        private void autoidHD()
        {
            //todo db hoadon
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(IDhoadon) from HoaDon", connect);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            i++;
            txtsohd.Text = i.ToString();
            IDhoadon = txtsohd.Text; // luu cho form tt
        }

        public void clearsp()
        {
            txtmasp.Clear();
            txttensp.Clear();
            txtsoluongsp.Clear();
            txtdongiasp.Clear();
            txtgiamphantramsp.Clear();
            txttiensp.Clear();
            comboBoxdonvisp.SelectedItem = null;
            comboBoxdonvisp.Text = null;
            comboBoxloaisp.Text = null;
        }

        public void huyhd()
        {
            txtmakh.Clear();
            txttenkh.Clear();
            txtmasp.Clear();
            txttensp.Clear();
            txtsoluongsp.Clear();
            txtdongiasp.Clear();
            txtgiamphantramsp.Clear();
            txttiensp.Clear();
            comboBoxdonvisp.SelectedItem = null;
            comboBoxdonvisp.Text = null;
            txttongcongtiensp.Clear();
            txtgiamtientong.Clear();
            txtgiamphantramtong.Clear();
            txtthanhtoan.Clear();
            txtcongtientong.Clear();
            txtcongphantramtong.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            bool found = false;
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) == txtmasp.Text)
                    {
                        //neu them san pham giong nhau se cộng dồn số lượng và tiền vào ô
                        row.Cells[2].Value = (int.Parse(txtsoluongsp.Text) + Convert.ToInt16(row.Cells[2].Value.ToString()));
                        row.Cells[4].Value = (double.Parse(txttiensp.Text) + Convert.ToDouble(row.Cells[4].Value.ToString()));
                        found = true;
                        /////////////////////
                    }
                }
                if (!found)
                {
                    dataGridView1.Rows.Add(txtmasp.Text, txttensp.Text, txtsoluongsp.Text, txtdongiasp.Text, txttiensp.Text, comboBoxdonvisp.Text, comboBoxloaisp.Text, txtgiamphantramsp.Text);
                }
            }
            else
            {
                dataGridView1.Rows.Add(txtmasp.Text, txttensp.Text, txtsoluongsp.Text, txtdongiasp.Text, txttiensp.Text, comboBoxdonvisp.Text, comboBoxloaisp.Text, txtgiamphantramsp.Text);
            }
            /////////////////////
            //int n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = txtmasp.Text;
            //dataGridView1.Rows[n].Cells[1].Value = txttensp.Text;
            //dataGridView1.Rows[n].Cells[2].Value = txtsoluongsp.Text;
            //dataGridView1.Rows[n].Cells[3].Value = txtdongiasp.Text;
            //dataGridView1.Rows[n].Cells[4].Value = txttiensp.Text;
            //dataGridView1.Rows[n].Cells[5].Value = comboBoxdonvisp.Text;
            ////    dataGridView1.Rows[n].Cells[6].Value = txtgiamphantramsp.Text;

            //------------ tinh tong tien sp trong datagridview-------------///
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txttongcongtiensp.Text = sum.ToString("###,###");
            //------------------- update sql -----------------//
            try
            {
                //todo db hoadon tonkho
                using (var cmdupdatesl = new SqlCommand("update tonkho set soluongsp=soluongsp - '" + txtsoluongsp.Text + "' where masp='" + txtmasp.Text + "' "))
                {
                    cmdupdatesl.Connection = connect;
                    //cmd.Parameters.AddWithValue("@masp", txtmasp.Text);
                    //cmd.Parameters.AddWithValue("@slsp", txtsoluongsp.Text);
                    connect.Open();
                    if (cmdupdatesl.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã update");
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
                MessageBox.Show("loi update ne" + ex.Message);
            }
            clearsp();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            //tra lai slsp
            //todo db hoadon tonkho
            using (var cmdedit = new SqlCommand("update tonkho set soluongsp=soluongsp + '" + slspedit + "' where masp='" + maspedit + "' "))
            {
                cmdedit.Connection = connect;
                connect.Open();
                if (cmdedit.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã update");
                    connect.Close();
                }
                else
                {
                    MessageBox.Show("Không thành công!");
                    connect.Close();
                }
                connect.Close();
            }

            DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = txtmasp.Text;
            newDataRow.Cells[1].Value = txttensp.Text;
            newDataRow.Cells[2].Value = txtsoluongsp.Text;
            newDataRow.Cells[3].Value = txtdongiasp.Text;
            newDataRow.Cells[4].Value = txttiensp.Text;
            newDataRow.Cells[5].Value = comboBoxdonvisp.Text;
            newDataRow.Cells[6].Value = comboBoxloaisp.Text;

            // tru slsp
            //todo db hoadon tonkho
            using (var cmdedit2 = new SqlCommand("update tonkho set soluongsp=soluongsp - '" + txtsoluongsp.Text + "' where masp='" + txtmasp.Text + "' "))
            {
                cmdedit2.Connection = connect;
                connect.Open();
                if (cmdedit2.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã update");
                    connect.Close();
                }
                else
                {
                    MessageBox.Show("Không thành công!");
                    connect.Close();
                }
                connect.Close();
            }

            clearsp();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                clearsp();

                txtmasp.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txttensp.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtsoluongsp.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtdongiasp.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txttiensp.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                comboBoxdonvisp.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBoxloaisp.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtgiamphantramsp.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                maspedit = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                slspedit = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            }
            else
            {
                MessageBox.Show("No data!");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                DataGridViewRow row = dataGridView1.Rows[item.Index];
                masp1 = row.Cells[0].Value.ToString();
                slsp1 = Convert.ToInt32(row.Cells[2].Value.ToString());
                dataGridView1.Rows.RemoveAt(item.Index); //remove row in datagridview
            }
            //------------- tra lai soluong sp database -----------------//
            try
            {
                //todo db hoadon tonkho
                using (var cmdupdatesl2 = new SqlCommand("update tonkho set soluongsp=soluongsp + '" + slsp1 + "' where masp='" + masp1 + "' "))
                {
                    cmdupdatesl2.Connection = connect;
                    connect.Open();
                    if (cmdupdatesl2.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã update");
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
                MessageBox.Show("loi update ne" + ex.Message);
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            clearsp();
        }

        private void txttongcongtiensp_TextChanged(object sender, EventArgs e)
        {
            txtthanhtoan.Text = txttongcongtiensp.Text;
        }

        private void txtgiamtientong_TextChanged(object sender, EventArgs e)
        {
            txtgiamphantramtong.Enabled = false;
            txtcongtientong.Enabled = false;
            txtcongphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtgiamtientong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtgiamphantramtong.Enabled = true;
                txtcongtientong.Enabled = true;
                txtcongphantramtong.Enabled = true;
            }
            else if (txtgiamtientong.Text.StartsWith(","))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                double tongcongtiensp;
                double trutientongcong;
                double TCtiensaukhitru;
                tongcongtiensp = double.Parse(txttongcongtiensp.Text);
                trutientongcong = double.Parse(txtgiamtientong.Text);
                if (trutientongcong > tongcongtiensp)
                {
                    MessageBox.Show("sai tham số > tổng tiền");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else
                {
                    TCtiensaukhitru = tongcongtiensp - trutientongcong;
                    txtthanhtoan.Text = TCtiensaukhitru.ToString("###,###");
                    //pass form TT
                    //  HDthanhtoan = txtthanhtoan.Text;
                }
            }
        }

        private void txtgiamphantramtong_TextChanged(object sender, EventArgs e)
        {
            txtgiamtientong.Enabled = false;
            txtcongtientong.Enabled = false;
            txtcongphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtgiamphantramtong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtgiamtientong.Enabled = true;
                txtcongtientong.Enabled = true;
                txtcongphantramtong.Enabled = true;
            }
            else if (txtgiamphantramtong.Text.StartsWith("."))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                txtgiamtientong.Enabled = false;
                double tongcongtiensp;
                double truphantramtong;
                double TCtiensaukhitruPT;
                double TCtiensaukhitruPT2;
                tongcongtiensp = double.Parse(txttongcongtiensp.Text);
                truphantramtong = double.Parse(txtgiamphantramtong.Text);

                if (truphantramtong < 0)
                {
                    MessageBox.Show("sai tham số <0");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else if (truphantramtong > 0)
                {
                    TCtiensaukhitruPT = (truphantramtong * tongcongtiensp) / 100;
                    TCtiensaukhitruPT2 = tongcongtiensp - TCtiensaukhitruPT;
                    txtthanhtoan.Text = TCtiensaukhitruPT2.ToString("###,###");
                }
                else if (truphantramtong > 100)
                {
                    MessageBox.Show("sai tham số >100");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
            }
        }

        private void txtgiamtientong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtgiamphantramtong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtcongtientong_TextChanged(object sender, EventArgs e)
        {
            txtcongphantramtong.Enabled = false;
            txtgiamtientong.Enabled = false;
            txtgiamphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtcongtientong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtcongphantramtong.Enabled = true;
                txtgiamtientong.Enabled = true;
                txtgiamphantramtong.Enabled = true;
            }
            else if (txtcongtientong.Text.StartsWith(","))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                double tongcongtiensp;
                double congtientongcong;
                double TCtiensaukhitru;
                tongcongtiensp = double.Parse(txttongcongtiensp.Text);
                congtientongcong = double.Parse(txtcongtientong.Text);
                if (congtientongcong > tongcongtiensp)
                {
                    MessageBox.Show("sai tham số > tổng tiền");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else
                {
                    TCtiensaukhitru = tongcongtiensp + congtientongcong;
                    txtthanhtoan.Text = TCtiensaukhitru.ToString("###,###");
                }
            }
        }

        private void txtcongphantramtong_TextChanged(object sender, EventArgs e)
        {
            txtcongtientong.Enabled = false;
            txtgiamtientong.Enabled = false;
            txtgiamphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtcongphantramtong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtgiamtientong.Enabled = true;
                txtgiamtientong.Enabled = true;
                txtgiamphantramtong.Enabled = true;
            }
            else if (txtcongphantramtong.Text.StartsWith("."))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                //   txtcongtientong.Enabled = false;
                double tongcongtiensp;
                double congphantramtong;
                double TCtiensaukhicongPT;
                double TCtiensaukhicongPT2;

                tongcongtiensp = double.Parse(txttongcongtiensp.Text);
                congphantramtong = double.Parse(txtcongphantramtong.Text);

                if (congphantramtong < 0)
                {
                    MessageBox.Show("sai tham số <0");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else if (congphantramtong > 0)
                {
                    TCtiensaukhicongPT = (congphantramtong * tongcongtiensp) / 100;
                    TCtiensaukhicongPT2 = TCtiensaukhicongPT + tongcongtiensp;
                    txtthanhtoan.Text = TCtiensaukhicongPT2.ToString("###,###");
                }
                else if (congphantramtong > 100)
                {
                    MessageBox.Show("sai tham số >100");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
            }
        }

        private void txtcongphantramtong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtcongtientong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {

            //------------------------------------------------// pass datadridview to listbox formTT
            ListBox listBox1a = new ListBox();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                listBox1a.Items.Add(item.Cells[1].Value.ToString() + '/' + item.Cells[2].Value.ToString() + '/' + item.Cells[3].Value.ToString());
                //--  listBox1a.Items.Add(item.Cells[1].Value.ToString().PadRight(30) + item.Cells[4].Value.ToString());
            }
            //------------------------------------------------// datagridview masp,tensp,slsp to list
            //pass datagridview to listbox: masp,tensp,sl
            ListBox listBox3 = new ListBox();
            ListBox listBox4 = new ListBox();
            ListBox listBox5 = new ListBox();
            ListBox listBox6 = new ListBox();
            ListBox listBox7 = new ListBox();
            ListBox listBox8 = new ListBox();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                listBox3.Items.Add(item.Cells[0].Value.ToString()).ToString();//masp
                listBox4.Items.Add(item.Cells[1].Value.ToString()).ToString();//tensp
                listBox5.Items.Add(item.Cells[2].Value.ToString()).ToString();//slsp
                listBox6.Items.Add(item.Cells[6].Value.ToString()).ToString();//loai
                listBox7.Items.Add(item.Cells[5].Value.ToString()).ToString();//donvi
                listBox8.Items.Add(item.Cells[3].Value.ToString()).ToString();//dongia
                colmasp = string.Join(",", listBox3.Items.Cast<String>());
                coltensp = string.Join(",", listBox4.Items.Cast<String>());
                colslsp = string.Join(",", listBox5.Items.Cast<String>());
                colloaisp = string.Join(",", listBox6.Items.Cast<String>());
                coldvsp = string.Join(",", listBox7.Items.Cast<String>());
                coldongiasp = string.Join(",", listBox8.Items.Cast<String>());
            }

            HDmasp = colmasp;
            HDtensp = coltensp;
            HDsl = colslsp;
            HDloai = colloaisp;
            HDdonvi = coldvsp;
            HDdongia = coldongiasp;
            //---------------------------------------------------//
            //pass data form tt
            thanhtoan = txtthanhtoan.Text;
            var form2 = new BanHangTT(listBox1a.Items);
            huyhd();
            autoidHD(); // clear toan bo textbox.... và làm mới ID
            form2.Show();
            //------------------------------------------------//



            //  BanHangTT frmTT = new BanHangTT();
            //  frmTT.Show();  
        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtmakh.Text))
                {
                    txttenkh.Clear();
                }
                else
                {
                    //todo db khanghang
                    connect.Open();
                    string sqlkh = "select * from KhachHang where SDT=" + int.Parse(txtmakh.Text);
                    SqlCommand cmd = new SqlCommand(sqlkh, connect);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txttenkh.Text = (dr["TenKH"].ToString());
                        //luu tru cho form TT
                        TenKH = txttenkh.Text;
                        SDT = txtmakh.Text;
                    }
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            try
            {
                autoidHD();
                //todo db hoadon tonkho
                string sqltensp = "select tensp from tonkho";
                SqlCommand cmd = new SqlCommand(sqltensp, connect);
                connect.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                AutoCompleteStringCollection autotensp = new AutoCompleteStringCollection();
                while (dr.Read())
                {
                    autotensp.Add(dr.GetString(0));

                }
                txttensp.AutoCompleteMode = AutoCompleteMode.Suggest;
                txttensp.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txttensp.AutoCompleteCustomSource = autotensp;
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txttensp_KeyDown(object sender, KeyEventArgs e)
        {
            string loaisp1;
            double giamgiaTextbox;

            if (e.KeyCode == Keys.Enter)
            {
                //todo db sanpham tonkho
                connect.Open();
                string sqlsp = "select * from tonkho where (tensp= N'" + txttensp.Text + "') ";
                SqlCommand cmd2 = new SqlCommand(sqlsp, connect);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    checkslsp = Convert.ToInt32(dr2["soluongsp"]);
                    if (checkslsp < 1)
                    {
                        MessageBox.Show("het hang");
                    }
                    else
                    {
                        txtmasp.Text = (dr2["masp"].ToString());
                        txtdongiasp.Text = (dr2["giabansp"].ToString());
                        txtsoluongsp.Text = "1";
                        txtgiamphantramsp.Text = (dr2["giamgia"].ToString());
                        comboBoxdonvisp.Text = (dr2["donvisp"].ToString());
                        comboBoxloaisp.Text = (dr2["loaisp"].ToString());
                        //thanhtiensp = soluong * don gia
                        double slsp;
                        double dongiasp;
                        double thanhtiensp;
                        double thanhtiensp2;
                        slsp = double.Parse(txtsoluongsp.Text);
                        dongiasp = double.Parse(txtdongiasp.Text);

                        thanhtiensp = slsp * dongiasp;
                        //tien giam gia cua san pham
                        giamgiaTextbox = double.Parse(txtgiamphantramsp.Text);
                        double giamgiasp = (giamgiaTextbox * thanhtiensp) / 100;
                        //tien san pham = (so luong * don gia ) - giam gia
                        thanhtiensp2 = thanhtiensp - giamgiasp;

                        txttiensp.Text = thanhtiensp2.ToString("###,###");

                        //luu tru cho from  TT
                        loaisp1 = comboBoxloaisp.Text;//
                                                      //  HDmasp = txtmasp.Text;
                                                      //  HDdongia = txtdongiasp.Text;
                                                      //  HDsl = txtsoluongsp.Text;
                                                      //  HDdonvi = comboBoxdonvisp.Text;
                                                      //  HDtensp = txttensp.Text;
                                                      //   HDloai = loaisp1;
                    }

                }
                connect.Close();
            }
        }

        private void txtsoluongsp_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtsoluongsp.Text)
             && !string.IsNullOrWhiteSpace(txtdongiasp.Text)
             && !string.IsNullOrWhiteSpace(txtgiamphantramsp.Text))
            {
                int slspHienTai = Convert.ToInt32(txtsoluongsp.Text);
                if (slspHienTai > checkslsp)
                {
                    txtsoluongsp.Text = checkslsp.ToString();
                }
                else
                {
                    double giamgiaTextbox;
                    double slsp;
                    double dongiasp;
                    double thanhtiensp;
                    double thanhtiensp2;
                    slsp = double.Parse(txtsoluongsp.Text);
                    dongiasp = double.Parse(txtdongiasp.Text);
                    thanhtiensp = slsp * dongiasp;

                    //tien giam gia cua san pham
                    giamgiaTextbox = double.Parse(txtgiamphantramsp.Text);
                    double giamgiasp = (giamgiaTextbox * thanhtiensp) / 100;
                    //tien san pham = (so luong * don gia ) - giam gia
                    thanhtiensp2 = thanhtiensp - giamgiasp;
                    txttiensp.Text = thanhtiensp2.ToString("###,###");
                }
            }
        }

        private void btnhuyHD_Click(object sender, EventArgs e)
        {
            huyhd();
            autoidHD();
        }

        private void txtmasp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double giamgiaTextbox;
                connect.Open();
                //todo db sanpham tonkho
                string sqlsp = "select * from tonkho where (masp= '" + txtmasp.Text + "') ";
                SqlCommand cmd2 = new SqlCommand(sqlsp, connect);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    txtmasp.Text = (dr2["masp"].ToString());
                    txttensp.Text = (dr2["tensp"].ToString());
                    txtdongiasp.Text = (dr2["giabansp"].ToString());
                    txtsoluongsp.Text = "1";
                    txtgiamphantramsp.Text = (dr2["giamgia"].ToString());
                    comboBoxdonvisp.Text = (dr2["donvisp"].ToString());
                    comboBoxloaisp.Text = (dr2["loaisp"].ToString());
                    //thanhtiensp = soluong * don gia
                    double slsp;
                    double dongiasp;
                    double thanhtiensp;
                    double thanhtiensp2;
                    slsp = double.Parse(txtsoluongsp.Text);
                    dongiasp = double.Parse(txtdongiasp.Text);
                    thanhtiensp = slsp * dongiasp;
                    //tien giam gia cua san pham
                    giamgiaTextbox = double.Parse(txtgiamphantramsp.Text);
                    double giamgiasp = (giamgiaTextbox * thanhtiensp) / 100;
                    //tien san pham = (so luong * don gia ) - giam gia
                    thanhtiensp2 = thanhtiensp - giamgiasp;

                    txttiensp.Text = thanhtiensp2.ToString("###,###");
                }
                connect.Close();
            }
        }

        private void txtsoluongsp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtdongiasp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txttiensp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
