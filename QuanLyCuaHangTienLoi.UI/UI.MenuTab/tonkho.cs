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
using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.DisplayObject;
using Microsoft.EntityFrameworkCore;

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{

    public partial class tonkho : Form
    {
        public void RefreshGridView()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<SanPham> spRepo = new Repository<SanPham>(dbCxt);
                dataGridView1.DataSource = spRepo
                    .GetAll()
                    .Include(sp => sp.LoSanPhams)
                    .Include(sp => sp.LoaiSanPham)
                    .Include(sp => sp.DonViSanPham)
                    .ToList()
                    .Select(sp => new HienThiSanPhamTonKho
                    {
                        Id = sp.Id,
                        TenSanPham = sp.TenSanPham,
                        SoLuong = sp.LoSanPhams.Sum(lsp => lsp.SoLuong),
                        GiaTien = sp.GiaTien,
                        DonViSanPham = sp.DonViSanPham,
                        LoaiSanPham = sp.LoaiSanPham
                    })
                    .ToDataTable();
            }
        }

        public void clearsp()
        {
            txtid.Clear();
            txttensp.Clear();
            txtsl.Clear();
            txtgiaban.Clear();
            comboloai.SelectedItem = null;
            combodonvi.SelectedItem = null;
        }

        public tonkho()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RefreshGridView();
            //todo db sanpham
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<SanPham> sanPhamRepo = new Repository<SanPham>(dbCxt);
                Repository<LoSanPham> loSanPhamRepo = new Repository<LoSanPham>(dbCxt);
                Repository<LoaiSanPham> loaiSanPhamRepo = new Repository<LoaiSanPham>(dbCxt);
                Repository<DonViSanPham> donViSanPhamRepo = new Repository<DonViSanPham>(dbCxt);
                Repository<NhaCungCap> nccRepo = new Repository<NhaCungCap>(dbCxt);

                comboloai.Items.Clear();
                combodonvi.Items.Clear();
                foreach (var loaiSp in loaiSanPhamRepo.GetAll())
                {
                    comboloai.Items.Add(loaiSp);
                }
                foreach (var donviSp in donViSanPhamRepo.GetAll())
                {
                    combodonvi.Items.Add(donviSp);
                }
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
                txtgiaban.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                var loaiSanPham = dataGridView1.CurrentRow.Cells[4].Value as LoaiSanPham;
                var donViSanPham = dataGridView1.CurrentRow.Cells[5].Value as DonViSanPham;
                comboloai.Text = loaiSanPham.TenLoaiSanPham;
                combodonvi.Text = donViSanPham.TenDonViSanPham;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txttensp.Text))
            {
                txttensp.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtsl.Text))
            {
                txtsl.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtgiaban.Text))
            {
                txtgiaban.Select();
            }
            else if (comboloai.SelectedIndex == -1)
            {
                comboloai.Select();
            }
            else if (combodonvi.SelectedIndex == -1)
            {
                comboloai.Select();
            }
            else
            {
                return true;
            }
            return false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtid.Text))
            //{
            //    MessageBox.Show("Thông tin trống!");
            //    return;
            //}

            //if (ValidateInput())
            //{

            //}
            //else
            //{
            //    try
            //    {
            //        using (var cmd = new SqlCommand("update tonkho set tensp=@tensp,soluongsp=@soluongsp,gianhapsp=@gianhapsp,giabansp=@giabansp,loaisp=@loaisp,donvisp=@donvisp where masp=@masp"))
            //        {
            //            cmd.Connection = connect;
            //            cmd.Parameters.AddWithValue("@masp", txtid.Text);
            //            cmd.Parameters.AddWithValue("@tensp", txttensp.Text);
            //            cmd.Parameters.AddWithValue("@soluongsp", txtsl.Text);
            //            cmd.Parameters.AddWithValue("@gianhapsp", txtgianhap.Text);
            //            cmd.Parameters.AddWithValue("@giabansp", txtgiaban.Text);
            //            cmd.Parameters.AddWithValue("@loaisp", comboloai.GetItemText(comboloai.SelectedItem));
            //            cmd.Parameters.AddWithValue("@donvisp", combodonvi.GetItemText(combodonvi.SelectedItem));
            //            connect.Open();
            //            if (cmd.ExecuteNonQuery() > 0)
            //            {
            //                MessageBox.Show("Đã lưu");
            //                RefreshGridView();
            //                txtid.ReadOnly = true;
            //            }
            //            else
            //            {
            //                MessageBox.Show("Lưu không thành công!");
            //                txtid.ReadOnly = true;
            //            }
            //            connect.Close();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        connect.Close();
            //        MessageBox.Show("Error during insert: " + ex.Message);
            //    }
            //}
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtid.Text))
            //{
            //    MessageBox.Show("Thông tin trống!");
            //}
            //else
            //{


            //    try
            //    {
            //        using (var cmd = new SqlCommand("delete tonkho where masp=@masp"))
            //        {
            //            cmd.Connection = connect;
            //            cmd.Parameters.AddWithValue("@masp", txtid.Text);
            //            connect.Open();
            //            if (cmd.ExecuteNonQuery() > 0)
            //            {
            //                MessageBox.Show("Đã xóa");
            //                clearsp();
            //                RefreshGridView();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Lưu không thành công!");
            //            }
            //            connect.Close();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        connect.Close();
            //        MessageBox.Show("Error during insert: " + ex.Message);
            //    }

            //}
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
            //try
            //{
            //    using (var cmd = new SqlCommand("update tonkho set anhsp=null where masp=@masp"))
            //    {
            //        cmd.Connection = connect;
            //        cmd.Parameters.AddWithValue("@masp", txtid.Text);
            //        connect.Open();
            //        if (cmd.ExecuteNonQuery() > 0)
            //        {
            //            MessageBox.Show("Đã xóa");
            //            clearsp();
            //            RefreshGridView();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Không thành công!");
            //        }
            //        connect.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    connect.Close();
            //    MessageBox.Show("Error during insert: " + ex.Message);
            //}
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<SanPham> spRepo = new Repository<SanPham>(dbCxt);
                var searchText = txtsearch.Text;
                dataGridView1.DataSource = spRepo
                    .Query(
                        sp => sp.Id.ToString().Contains(searchText)
                     || sp.TenSanPham.Contains(searchText))
                    .Include(sp => sp.LoSanPhams).ToList().Select(sp => new HienThiSanPham
                    {
                        Id = sp.Id,
                        TenSanPham = sp.TenSanPham,
                        SoLuong = sp.LoSanPhams.Sum(lsp => lsp.SoLuong)
                    })
                    .ToDataTable();
            }

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

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }



        private void comboloai_SelectedIndexChanged(object sender, EventArgs e)
        {
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
