using Microsoft.EntityFrameworkCore;

using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.DisplayObject;
using QuanLyCuaHangTienLoi.UI.Utilities;

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
        public static Guid hdid = Guid.Empty;

        public DonHang()
        {
            InitializeComponent();
            RefreshGridview();
        }
        public void RefreshGridview()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<HoaDon> hdRepo = new Repository<HoaDon>(dbCxt);
                Repository<ChiTietHoaDon> cthdRepo = new Repository<ChiTietHoaDon>(dbCxt);

                var hoadons = hdRepo.GetAll().Select(hd => new HienThiHoaDon
                {
                    Id = hd.Id,
                    NgayLap = hd.NgayLap,
                    TenKhachHang = hd.KhachHang.TenKhachHang,
                    TenNhanVien = hd.NhanVien.TenNhanVien,
                    No = hd.No
                });
                dataGridView1.DataSource = hoadons.ToList().ToDataTable<HienThiHoaDon>();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                hdid = Guid.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                var chiTietHoaDon = new HoaDonChiTiet();
                chiTietHoaDon.Show();
                RefreshGridview();
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<HoaDon> hdRepo = new Repository<HoaDon>(dbCxt);
                    Repository<ChiTietHoaDon> cthdRepo = new Repository<ChiTietHoaDon>(dbCxt);
                    var searchText = textBoxSearch.Text;
                    var hoadons = hdRepo.Query(hd =>
                        hd.Id.ToString().Contains(searchText)
                     || hd.KhachHang.SoDienThoai.Contains(searchText)
                     || hd.KhachHang.TenKhachHang.Contains(searchText)
                    ).Select(hd => new HienThiHoaDon
                    {
                        Id = hd.Id,
                        NgayLap = hd.NgayLap,
                        TenKhachHang = hd.KhachHang.TenKhachHang,
                        TenNhanVien = hd.NhanVien.TenNhanVien
                    });
                    dataGridView1.DataSource = hoadons.ToList().ToDataTable<HienThiHoaDon>();
                }

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
                    labelSearch.Text = "Tìm kiếm theo: ID hóa đơn, SĐT khách hàng, Tên khách hàng";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string getdate = dateTimePicker1.Value.Date.ToShortDateString();
            try
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<HoaDon> hdRepo = new Repository<HoaDon>(dbCxt);
                    Repository<ChiTietHoaDon> cthdRepo = new Repository<ChiTietHoaDon>(dbCxt);
                    var searchText = textBoxSearch.Text;
                    var hoadons = hdRepo.GetAll()
                        .Include(hd => hd.KhachHang).Include(hd => hd.NhanVien)
                        .AsEnumerable().Where(hd => hd.NgayLap.ToShortDateString() == getdate)
                        .Select(hd => new HienThiHoaDon
                        {
                            Id = hd.Id,
                            NgayLap = hd.NgayLap,
                            TenKhachHang = hd.KhachHang.TenKhachHang,
                            TenNhanVien = hd.NhanVien.TenNhanVien
                        });
                    dataGridView1.DataSource = hoadons.ToList().ToDataTable<HienThiHoaDon>();
                }

                //using (SqlDataAdapter da = new SqlDataAdapter("select * from HoaDon where cast ([HDtime] as date) = '" + getdate + "'      ", connect))
                //{
                //    DataTable dtsearch = new DataTable("HoaDon");
                //    da.Fill(dtsearch);
                //    dataGridView1.DataSource = dtsearch;

                //}
                //connect.Close();

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
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonReloadTable_Click(object sender, EventArgs e)
        {
            RefreshGridview();
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
