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

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{

    public partial class tonkho : Form
    {
        SqlConnection connect = ClassKetnoi.connect;

        SqlCommand command;
        public void gridviewsp()
        {
            string querysp = @"select masp as 'Mã sản phẩm', tensp as 'Tên sản phẩm', soluongsp as 'Số lượng', gianhapsp as 'Giá nhập', giabansp as 'Giá bán', loaisp as 'Loại', donvisp as 'Đơn vị',giamgia as 'Giảm giá' from tonkho";
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
            // pictureBox1.Image = null;
            pictureBox1.Image = Properties.Resources._default;
        }
        private void autoid()
        {
            if (comboloai.SelectedIndex == -1)
            {
                //    MessageBox.Show("nhập thông tin!");
            }
            else
            {
                string comboselected = this.comboloai.GetItemText(this.comboloai.SelectedItem);
                // string s1 = comboselected.Substring(0, comboselected.IndexOf(" "));
                string s1 = comboselected.Substring(0, 1);
                string s2 = comboselected.Substring(comboselected.IndexOf(" ") + 1);
                if (s2 == null)
                {
                    string s1a = s1.Substring(0, 1).ToUpper();
                    string s2a = s1.Substring(0, 1).ToUpper();
                    String s3 = String.Concat(s1a, s2a);

                    connect.Open();
                    SqlCommand cmd = new SqlCommand("select count(masp) from tonkho", connect);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    connect.Close();
                    i++;
                    txtid.Text = s3 + i.ToString();
                }
                else
                {
                    string s1a = s1.Substring(0, 1).ToUpper();
                    string s2a = s2.Substring(0, 1).ToUpper();
                    String s3 = String.Concat(s1a, s2a);

                    connect.Open();
                    SqlCommand cmd = new SqlCommand("select count(masp) from tonkho", connect);
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    connect.Close();
                    i++;
                    txtid.Text = s3 + i.ToString();
                }

            }
        }

        public tonkho()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridviewsp();

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
            //table
            // dataGridView1.DataSource = datatbsp;
        }



        private void sanpham_Load(object sender, EventArgs e)
        {


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
                txtGiamGia.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

                try
                {
                    string sql1 = "select anhsp from tonkho where masp='" + txtid.Text + "' ";

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
                        //  MessageBox.Show(img.ToString());
                        connect.Close();
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
                //=====================

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
                    using (var cmd = new SqlCommand("update tonkho set tensp=@tensp,soluongsp=@soluongsp,gianhapsp=@gianhapsp,giabansp=@giabansp,loaisp=@loaisp,donvisp=@donvisp where masp=@masp"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@masp", txtid.Text);
                        cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
                        cmd.Parameters.AddWithValue("@soluongsp", txtsl.Text);
                        cmd.Parameters.AddWithValue("@gianhapsp", txtgianhap.Text);
                        cmd.Parameters.AddWithValue("@giabansp", txtgiaban.Text);
                        cmd.Parameters.AddWithValue("@loaisp", comboloai.GetItemText(comboloai.SelectedItem));
                        cmd.Parameters.AddWithValue("@donvisp", combodonvi.GetItemText(combodonvi.SelectedItem));
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã lưu");
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
                    using (var cmd = new SqlCommand("delete tonkho where masp=@masp"))
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

        private void btnButtonChooseIMG_Click(object sender, EventArgs e)
        {
        }

        private void btnDeleteIMG_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cmd = new SqlCommand("update tonkho set anhsp=null where masp=@masp"))
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
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("select masp,tensp,soluongsp,gianhapsp,giabansp,loaisp,donvisp from tonkho where ( masp like '" + txtsearch.Text + "%' or tensp like N'" + txtsearch.Text + "%' or soluongsp like '" + txtsearch.Text + "%' or gianhapsp like '" + txtsearch.Text + "%' or giabansp like '" + txtsearch.Text + "%'  or loaisp like N'" + txtsearch.Text + "%'  or donvisp like N'" + txtsearch.Text + "%'     )", connect))
                {
                    DataTable dtsearch = new DataTable("tonkho");
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

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }



        private void comboloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                autoid();
            }
            else
            {

            }

        }

        private void ButtonAutoid_Click(object sender, EventArgs e)
        {

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
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
    }
}
