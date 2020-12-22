using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.DisplayObject;

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
    public partial class LoaiSP : Form
    {
        public LoaiSP()
        {
            InitializeComponent();
        }

        private void clear()
        {
            textBoxTenLoai.Clear();
            textBoxID.Clear();
        }

        private void RefreshGridView()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<LoaiSanPham> loaiSpRepo = new Repository<LoaiSanPham>(dbCxt);
                DataTable datatbsploai = loaiSpRepo.GetAll().Select(lsp => new HienThiLoaiSanPham
                {
                    Id = lsp.Id,
                    TenLoaiSanPham = lsp.TenLoaiSanPham
                }).ToDataTable();

                dataGridViewLoaiSPloai.DataSource = datatbsploai;
            }
        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridViewLoaiSP_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewLoaiSPloai.CurrentRow.Index != -1)
            {
                clear();
                textBoxID.Text = dataGridViewLoaiSPloai.CurrentRow.Cells[0].Value.ToString();
                textBoxTenLoai.Text = dataGridViewLoaiSPloai.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<LoaiSanPham> loaiSpRepo = new Repository<LoaiSanPham>(dbCxt);
                    var lsp = loaiSpRepo.Get(Guid.Parse(textBoxID.Text));
                    lsp.TenLoaiSanPham = textBoxTenLoai.Text;
                    loaiSpRepo.Update(lsp);

                    MessageBox.Show("Sửa loại sản phẩm xong.");
                }
                RefreshGridView();
            }
            clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {
                if (MessageBox.Show(
                    "Có chắc là muốn xoá loại sản phẩm" + Environment.NewLine +
                    textBoxTenLoai.Text,
                    "Cảnh báo",
                     MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<LoaiSanPham> loaiSpRepo = new Repository<LoaiSanPham>(dbCxt);
                    var lsp = loaiSpRepo.Get(Guid.Parse(textBoxID.Text));
                    loaiSpRepo.Delete(lsp);

                    MessageBox.Show("Xoá loại sản phẩm xong.");
                }
                RefreshGridView();
            }
            clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("Xin nhập loại sản phẩm mới, bấm nút Nhập lại để xoá các field.");
                return;
            }
            else
            {

                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<LoaiSanPham> loaiSpRepo = new Repository<LoaiSanPham>(dbCxt);

                    LoaiSanPham lspMoi = new LoaiSanPham
                    {
                        Id = Guid.NewGuid(),
                        TenLoaiSanPham = textBoxTenLoai.Text
                    };

                    loaiSpRepo.Insert(lspMoi);

                    MessageBox.Show("Thêm loại sản phẩm xong.");
                }
                RefreshGridView();
            }
        }


        private void LoaiSP_Load(object sender, EventArgs e)
        {
            RefreshGridView();
        }
    }
}
