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
    public partial class DonViSP : Form
    {
        public DonViSP()
        {
            InitializeComponent();
            RefreshGridView();
        }

        private void clear()
        {
            textBoxTenDV.Clear();
        }
        private void RefreshGridView()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<DonViSanPham> dvSpRepo = new Repository<DonViSanPham>(dbCxt);
                DataTable datatbdv = dvSpRepo.GetAll().Select(dvsp => new HienThiDonViSanPham
                {
                    Id = dvsp.Id,
                    TenDonViSanPham = dvsp.TenDonViSanPham
                }).ToDataTable();

                dataGridViewDVsp.DataSource = datatbdv;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void dataGridViewDVsp_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
            if (dataGridViewDVsp.CurrentRow.Index != -1)
            {
                textBoxID.Text = dataGridViewDVsp.CurrentRow.Cells[0].Value.ToString();
                textBoxTenDV.Text = dataGridViewDVsp.CurrentRow.Cells[1].Value.ToString();
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
                    Repository<DonViSanPham> dvSpRepo = new Repository<DonViSanPham>(dbCxt);
                    var dv = dvSpRepo.Get(Guid.Parse(textBoxID.Text));
                    dv.TenDonViSanPham = textBoxTenDV.Text;
                    dvSpRepo.Update(dv);

                    MessageBox.Show("Sửa đơn vị sản phẩm xong.");
                }
                RefreshGridView();
            }
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
                    textBoxTenDV.Text,
                    "Cảnh báo",
                     MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<DonViSanPham> dvSpRepo = new Repository<DonViSanPham>(dbCxt);
                    var dv = dvSpRepo.Get(Guid.Parse(textBoxID.Text));
                    dvSpRepo.Delete(dv);

                    MessageBox.Show("Xoá đơn vị sản phẩm xong.");
                }
                RefreshGridView();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("Xin nhập đơn vị sản phẩm mới, bấm nút Nhập lại để xoá các field.");
                return;
            }
            else
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<DonViSanPham> dvSpRepo = new Repository<DonViSanPham>(dbCxt);
                    var dvMoi = new DonViSanPham()
                    {
                        Id = Guid.NewGuid(),
                        TenDonViSanPham = textBoxTenDV.Text
                    };
                    dvSpRepo.Insert(dvMoi);

                    MessageBox.Show("Sửa đơn vị sản phẩm xong.");
                }
                RefreshGridView();
            }
        }
    }
}
