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

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    public partial class DonHang : Form
    {
        SqlConnection connect = ClassKetnoi.connect;
        //SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-A0E9NLI\MSSQLSERVER2019;Initial Catalog=doan-3;Integrated Security=True");
        public static string hdid = "";
        public static string hdmasp = "";
        public static string hdtensp = "";
        public static string hdsl = "";
        public static string hddongia = "";
        public static string hdloai = "";
        public static string hddonvi = "";
        public static string hdthanhtoan = "";
        public static string sdt = "";
        public static string tenkh = "";
        public static string hdtime = "";
        public static string hdno = "";
        public static string nvtt = "";

        public DonHang()
        {
            InitializeComponent();
            gridviewsp();
        }
        public void gridviewsp()
        {
            //todo db hoadon sanpham
            string querysp = @"select IDhoadon as 'Mã hóa đơn',HDmasp as 'Mã sản phẩm' , HDtensp as 'Tên sản phẩm', TenKH as 'Tên KH', HDsl as 'Số lượng',HDdongia as 'Đơn giá' ,HDthanhtoan as 'Thanh toán',HDtime as 'Thời gian', HDloai as 'Loại', HDdonvi as 'Đơn vị',SDT as 'SĐT',HDno as 'Nợ',nvthanhtoan as 'Nhân viên thanh toán' from HoaDon";
            SqlDataAdapter sqldatasp = new SqlDataAdapter(querysp, connect);
            DataTable datatbsp = new DataTable();
            sqldatasp.Fill(datatbsp);
            dataGridView1.DataSource = datatbsp;
            connect.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                hdid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                hdmasp = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                hdtensp = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                hdsl = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                hddongia = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                hdloai = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                hddonvi = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                hdthanhtoan = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                sdt = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                tenkh = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                hdtime = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                hdno = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                nvtt = dataGridView1.CurrentRow.Cells[12].Value.ToString();

                var childForm = new HoaDonChiTiet();
                childForm.Show();
            }
            else
            {
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                //todo db hoadon
                using (SqlDataAdapter da = new SqlDataAdapter("select * from HoaDon where ( IDhoadon like '" + textBoxSearch.Text + "%' or HDthanhtoan like N'" + textBoxSearch.Text + "%' or SDT like '" + textBoxSearch.Text + "%' or TenKH like '" + textBoxSearch.Text + "%' or HDtime like '" + textBoxSearch.Text + "%'       )", connect))
                {
                    DataTable dtsearch = new DataTable("HoaDon");
                    da.Fill(dtsearch);
                    dataGridView1.DataSource = dtsearch;

                }
                connect.Close();
                if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows != null)
                {
                    labelSearch.Text = "Đã tìm thấy";
                }
                else
                {
                    labelSearch.Text = "Không tìm thấy...";
                }

                if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
                {
                    labelSearch.Text = "Tìm kiếm theo: ID hóa đơn, Tổng tiền thanh toán, " +
                        "SĐT khách hàng, Tên khách hàng.";
                }
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string getdate = dateTimePicker1.Value.Date.ToString("MM/dd/yyyy");
            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                //todo db hoadon
                using (SqlDataAdapter da = new SqlDataAdapter("select * from HoaDon where cast ([HDtime] as date) = '" + getdate + "'      ", connect))
                {
                    DataTable dtsearch = new DataTable("HoaDon");
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

        private void ButtonReloadTable_Click(object sender, EventArgs e)
        {
            gridviewsp();
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

        private void donhang_Load(object sender, EventArgs e)
        {
            //thay the o trong trong datagridview = " "
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                for (int i = 0; i < item.Cells.Count; i++)
                {
                    if (item.Cells[i].Value == null || item.Cells[i].Value == DBNull.Value)
                    {
                        for (int n = 1; n < dataGridView1.Rows.Count; n++)
                        {
                            dataGridView1.Rows[n].Cells[i].Value = " ";
                        }
                    }
                }
            }
        }
    }
}
