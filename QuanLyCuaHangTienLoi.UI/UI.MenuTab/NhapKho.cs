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
using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.DisplayObject;

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{

    public partial class NhapKho : Form
    {
        SqlConnection connect = ClassKetnoi.connect;

        SqlCommand command;

        public NhapKho()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RefreshGridview();

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
                combonhaCungCap.Items.Clear();
                foreach (var loaiSp in loaiSanPhamRepo.GetAll())
                {
                    comboloai.Items.Add(loaiSp);
                }
                foreach (var donviSp in donViSanPhamRepo.GetAll())
                {
                    combodonvi.Items.Add(donviSp);
                }
                foreach (var ncc in nccRepo.GetAll())
                {
                    combonhaCungCap.Items.Add(ncc);
                }
            }
        }

        public void RefreshGridview()
        {
            //todo db sanpham
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<SanPham> sanPhamRepo = new Repository<SanPham>(dbCxt);
                Repository<LoSanPham> loSanPhamRepo = new Repository<LoSanPham>(dbCxt);

                DataTable datatbsp;
                var spQuery = loSanPhamRepo.GetAll().Select(lsp => new HienThiLoSanPham
                {
                    Id = lsp.Id,
                    SanPhamId = lsp.SanPhamId,
                    TenSanPham = lsp.SanPham.TenSanPham,
                    GiaTien = lsp.SanPham.GiaTien,
                    SoLuong = lsp.SoLuong,
                    LoaiSanPham = lsp.SanPham.LoaiSanPham,
                    DonViSanPham = lsp.SanPham.DonViSanPham,
                    NhaCungCap = lsp.NhaCungCap
                });

                datatbsp = spQuery.ToDataTable();

                dataGridView1.DataSource = datatbsp;
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
            combonhaCungCap.SelectedItem = null;
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            txtid.ReadOnly = true;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                clearsp();

                txtid.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtlspId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txttensp.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtsl.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtgiaban.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                var loaiSanPham = dataGridView1.CurrentRow.Cells[5].Value as LoaiSanPham;
                var donViSanPham = dataGridView1.CurrentRow.Cells[6].Value as DonViSanPham;
                var ncc = dataGridView1.CurrentRow.Cells[7].Value as NhaCungCap;
                comboloai.Text = loaiSanPham.TenLoaiSanPham;
                combodonvi.Text = donViSanPham.TenDonViSanPham;
                combonhaCungCap.Text = ncc.TenNhaCungCap;

                txtid.ReadOnly = true;
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
            else if (combonhaCungCap.SelectedIndex == -1)
            {
                comboloai.Select();
            }
            else
            {
                return true;
            }
            return false;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtid.Text))
            {
                MessageBox.Show("Xin nhập sản phẩm mới, bấm nút Nhập lại để xoá các field.");
                return;
            }

            if (!ValidateInput())
            {
                MessageBox.Show("Lỗi dữ liệu!");
            }
            else
            {
                //todo db sanpham nhap kho
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<SanPham> sanPhamRepo = new Repository<SanPham>(dbCxt);
                    Repository<LoSanPham> loSanPhamRepo = new Repository<LoSanPham>(dbCxt);
                    Repository<LoaiSanPham> loaiSanPhamRepo = new Repository<LoaiSanPham>(dbCxt);
                    Repository<DonViSanPham> donViSanPhamRepo = new Repository<DonViSanPham>(dbCxt);
                    Repository<NhaCungCap> nccRepo = new Repository<NhaCungCap>(dbCxt);

                    var sanphamMoi = new SanPham
                    {
                        Id = Guid.NewGuid(),
                        TenSanPham = txttensp.Text,
                        GiaTien = double.Parse(txtgiaban.Text),
                        LoaiSanPhamId = (comboloai.SelectedItem as LoaiSanPham).Id,
                        DonViSanPhamId = (combodonvi.SelectedItem as DonViSanPham).Id,
                    };

                    var loSanPhamMoi = new LoSanPham
                    {
                        Id = Guid.NewGuid(),
                        SanPhamId = sanphamMoi.Id,
                        NhaCungCapId = (combonhaCungCap.SelectedItem as NhaCungCap).Id,
                        NgayNhap = DateTime.Now,
                        SoLuong = int.Parse(txtsl.Text)
                    };

                    sanPhamRepo.Insert(sanphamMoi);
                    loSanPhamRepo.Insert(loSanPhamMoi);

                    MessageBox.Show("Đã nhập xong");
                }

                txtid.ReadOnly = true;
                RefreshGridview();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                MessageBox.Show("Trống mã sản phẩm!");
                txtid.Select();
                return;
            }


            if (!ValidateInput())
            {
                MessageBox.Show("Lỗi dữ liệu!");
            }
            else
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<SanPham> sanPhamRepo = new Repository<SanPham>(dbCxt);
                    Repository<LoSanPham> loSanPhamRepo = new Repository<LoSanPham>(dbCxt);
                    Repository<LoaiSanPham> loaiSanPhamRepo = new Repository<LoaiSanPham>(dbCxt);
                    Repository<DonViSanPham> donViSanPhamRepo = new Repository<DonViSanPham>(dbCxt);
                    Repository<NhaCungCap> nccRepo = new Repository<NhaCungCap>(dbCxt);

                    var loSanPhamMoi = new LoSanPham
                    {
                        Id = Guid.NewGuid(),
                        SanPhamId = Guid.Parse(txtid.Text),
                        NhaCungCapId = (combonhaCungCap.SelectedItem as NhaCungCap).Id,
                        NgayNhap = DateTime.Now,
                        SoLuong = int.Parse(txtsl.Text)
                    };
                    loSanPhamRepo.Insert(loSanPhamMoi);

                    MessageBox.Show("Đã nhập xong");
                }

                RefreshGridview();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }

            if (ValidateInput())
            {
                if (MessageBox.Show(
                    "Có chắc là muốn xoá lô sản phẩm" + Environment.NewLine +
                    txttensp.Text,
                    "Cảnh báo",
                     MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<SanPham> sanPhamRepo = new Repository<SanPham>(dbCxt);
                    Repository<LoSanPham> loSanPhamRepo = new Repository<LoSanPham>(dbCxt);
                    Repository<LoaiSanPham> loaiSanPhamRepo = new Repository<LoaiSanPham>(dbCxt);
                    Repository<DonViSanPham> donViSanPhamRepo = new Repository<DonViSanPham>(dbCxt);
                    Repository<NhaCungCap> nccRepo = new Repository<NhaCungCap>(dbCxt);

                    var loSanPham = loSanPhamRepo.Get(Guid.Parse(txtlspId.Text));

                    loSanPhamRepo.Delete(loSanPham);

                    MessageBox.Show("Đã xoá xong");
                }

                RefreshGridview();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearsp();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //todo db sanpham nhap kho
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    string searchText = txtsearch.Text;
                    Repository<SanPham> sanPhamRepo = new Repository<SanPham>(dbCxt);
                    Repository<LoSanPham> loSanPhamRepo = new Repository<LoSanPham>(dbCxt);

                    DataTable datatbsp;
                    var spQuery = loSanPhamRepo
                        .Query(lsp =>
                            lsp.Id.ToString().Contains(searchText)
                         || lsp.SanPham.TenSanPham.Contains(searchText))
                        .Select(lsp => new HienThiLoSanPham
                        {
                            Id = lsp.Id,
                            SanPhamId = lsp.SanPhamId,
                            TenSanPham = lsp.SanPham.TenSanPham,
                            GiaTien = lsp.SanPham.GiaTien,
                            SoLuong = lsp.SoLuong,
                            LoaiSanPham = lsp.SanPham.LoaiSanPham,
                            DonViSanPham = lsp.SanPham.DonViSanPham,
                            NhaCungCap = lsp.NhaCungCap
                        });

                    datatbsp = spQuery.ToDataTable();

                    dataGridView1.DataSource = datatbsp;
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
