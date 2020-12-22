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
    public partial class NhaCungCapForm : Form
    {
        public NhaCungCapForm()
        {
            InitializeComponent();
        }

        private void clear()
        {
            textBoxTenNhaCungCap.Clear();
            textBoxID.Clear();
        }

        private void RefreshGridView()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<NhaCungCap> nccRepo = new Repository<NhaCungCap>(dbCxt);
                DataTable datatbnhaCungCap = nccRepo.GetAll().Select(ncc => new HienThiNhaCungCap
                {
                    Id = ncc.Id,
                    TenNhaCungCap = ncc.TenNhaCungCap
                }).ToDataTable();

                dataGridViewLoaiSPloai.DataSource = datatbnhaCungCap;
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
                textBoxTenNhaCungCap.Text = dataGridViewLoaiSPloai.CurrentRow.Cells[1].Value.ToString();
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
                    Repository<NhaCungCap> nccRepo = new Repository<NhaCungCap>(dbCxt);
                    var ncc = nccRepo.Get(Guid.Parse(textBoxID.Text));
                    ncc.TenNhaCungCap = textBoxTenNhaCungCap.Text;
                    nccRepo.Update(ncc);

                    MessageBox.Show("Sửa nhà cung cấp xong.");
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
                    "Có chắc là muốn xoá nhà cung cấp" + Environment.NewLine +
                    textBoxTenNhaCungCap.Text,
                    "Cảnh báo",
                     MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<NhaCungCap> nccRepo = new Repository<NhaCungCap>(dbCxt);
                    var ncc = nccRepo.Get(Guid.Parse(textBoxID.Text));
                    nccRepo.Delete(ncc);

                    MessageBox.Show("Xoá nhà cung cấp xong.");
                }
                RefreshGridView();
            }
            clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("Xin nhập nhà cung cấp mới, bấm nút Nhập lại để xoá các field.");
                return;
            }
            else
            {

                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<NhaCungCap> nccRepo = new Repository<NhaCungCap>(dbCxt);

                    NhaCungCap nccMoi = new NhaCungCap
                    {
                        Id = Guid.NewGuid(),
                        TenNhaCungCap = textBoxTenNhaCungCap.Text
                    };

                    nccRepo.Insert(nccMoi);

                    MessageBox.Show("Thêm nhà cung cấp xong.");
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
