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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    public partial class Setting : Form
    {
        public Setting()
        {
            if (CuaSoChinh.tennv.ToLower() == "admin")
            {
                InitializeComponent();
                gridviewNhanVien();
                gridviewKhachHang();
            }
            else
            {
                MessageBox.Show("Chỉ có admin mới có thể truy cập chức năng này!");
            }
        }

        public void gridviewNhanVien()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<NhanVien> nvRepo = new Repository<NhanVien>(dbCxt);

                DataTable datatbnv = nvRepo.GetAll().Select(nv => new HienThiNhanVien
                {
                    Id = nv.Id,
                    TenNhanVien = nv.TenNhanVien
                }).ToDataTable();

                dataGridViewNV.DataSource = datatbnv;
            }
        }

        private void gridviewKhachHang()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<KhachHang> khRepo = new Repository<KhachHang>(dbCxt);

                DataTable datatbkh = khRepo.GetAll().Select(kh => new HienThiKhachHang
                {
                    Id = kh.Id,
                    TenKhachHang = kh.TenKhachHang,
                    SoDienThoai = kh.SoDienThoai,
                    DiaChi = kh.DiaChi,
                    Email = kh.Email
                }).ToDataTable();

                dataGridViewKH.DataSource = datatbkh;
            }
        }

        public void clearnv()
        {
            txtIdNV.Clear();
            txtTenNV.Clear();
        }

        public void clearkh()
        {
            txtTenKh.Clear();
            txtIdKh.Clear();
            txtSdtKh.Clear();
            txtDiaChiKh.Clear();
            txtEmailKh.Clear();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdNV.Text))
            {
                MessageBox.Show("Xin bấm nút nhập lại để thêm nhân viên mới.");
                txtIdNV.Select();
            }

            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                txtTenNV.Select();
            }
            else
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<NhanVien> nvRepo = new Repository<NhanVien>(dbCxt);

                    var nvMoi = new NhanVien
                    {
                        Id = Guid.NewGuid(),
                        TenNhanVien = txtTenNV.Text,
                        Username = txtTenNV.Text.Replace(" ", "").ToLower(),
                        Matkhau = "123456"
                    };
                    nvRepo.Insert(nvMoi);

                    MessageBox.Show("Đã thêm nhân viên" + Environment.NewLine + "Tên đăng nhập mới:" + nvMoi.Username);
                }
                gridviewNhanVien();
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdNV.Text))
            {
                MessageBox.Show("Xin chọn nhân viên cần sửa ở bảng bên phải!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Xin nhập tên nhân viên");
                txtTenNV.Select();
            }
            else
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<NhanVien> nvRepo = new Repository<NhanVien>(dbCxt);
                    var nv = nvRepo.Get(Guid.Parse(txtIdNV.Text));
                    nv.TenNhanVien = txtTenNV.Text;
                    nv.Username = txtTenNV.Text.Replace(" ", "").ToLower();
                    nvRepo.Update(nv);

                    MessageBox.Show("Đã sửa nhân viên" + Environment.NewLine + "Tên đăng nhập mới:" + nv.Username);
                }
                gridviewNhanVien();
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdNV.Text))
            {
                MessageBox.Show("Xin chọn nhân viên cần xoá ở bảng bên phải!");
                return;
            }
            else
            {
                if (MessageBox.Show(
                    "Có chắc là muốn xoá loại sản phẩm" + Environment.NewLine +
                    txtTenNV.Text,
                    "Cảnh báo",
                     MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<NhanVien> nvRepo = new Repository<NhanVien>(dbCxt);
                    var nv = nvRepo.Get(Guid.Parse(txtIdNV.Text));

                    nvRepo.Delete(nv);

                    MessageBox.Show("Đã xoá nhân viên: " + nv.TenNhanVien);
                }
                gridviewNhanVien();
            }
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            clearnv();
        }
        private void Setting_Load(object sender, EventArgs e)
        {
            txtTenShop.Text = "Loki";
            txtSDT.Text = "0907033339";
            txtDiaChi.Text = "135 Nguyễn Văn Cừ, TPCT";
            txtLoiChao.Text = "Hẹn gặp lại bạn trong lần tới!";
        }

        private void BtnSaveThongtin_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtTenShop.Text))
            //{
            //    MessageBox.Show("Trống!");
            //    txtTenShop.Select();
            //}
            //else if (string.IsNullOrWhiteSpace(txtSDT.Text))
            //{
            //    txtSDT.Select();
            //}
            //else if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            //{
            //    txtDiaChi.Select();
            //}
            //else if (string.IsNullOrWhiteSpace(txtLoiChao.Text))
            //{
            //    txtLoiChao.Select();
            //}
            //else
            //{
            //}
        }

        private void dataGridViewNV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewNV.CurrentRow.Index != -1)
            {
                txtIdNV.Text = dataGridViewNV.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = dataGridViewNV.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnButtonChooseIMG_Click(object sender, EventArgs e)
        {
        }

        private void SaveIMGlogo_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdateKH_Click(object sender, EventArgs e)
        {
            gridviewKhachHang();
        }

        private bool ValidateKhachhangInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenKh.Text))
            {
                txtTenKh.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtSdtKh.Text))
            {
                txtSdtKh.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtDiaChiKh.Text))
            {
                txtDiaChiKh.Select();
            }
            else if (string.IsNullOrWhiteSpace(txtEmailKh.Text))
            {
                txtEmailKh.Select();
            }
            else
            {
                return true;
            }
            return false;
        }

        private void btnAddKh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdKh.Text))
            {
                MessageBox.Show("Xin bấm nút Nhập lại để thêm khách hàng mới");
                txtIdNV.Select();
                return;
            }
            if (!ValidateKhachhangInput())
            {
                MessageBox.Show("Xin nhập dữ liệu khách hàng");
            }
            else
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<KhachHang> khRepo = new Repository<KhachHang>(dbCxt);

                    var khMoi = new KhachHang
                    {
                        Id = Guid.NewGuid(),
                        TenKhachHang = txtTenKh.Text,
                        SoDienThoai = txtSdtKh.Text,
                        DiaChi = txtDiaChiKh.Text,
                        Email = txtEmailKh.Text
                    };
                    khRepo.Insert(khMoi);

                    MessageBox.Show("Đã thêm khách hàng: " + khMoi.TenKhachHang);
                }
                gridviewKhachHang();
            }
        }

        private void btnEditKh_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtIdKh.Text))
            {
                MessageBox.Show("Xin chọn khách hàng cần sửa ở bảng bên phải!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenKh.Text))
            {
                txtTenKh.Select();
            }
            else
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<KhachHang> khRepo = new Repository<KhachHang>(dbCxt);
                    var kh = khRepo.Get(Guid.Parse(txtIdKh.Text));
                    kh.TenKhachHang = txtTenKh.Text;
                    kh.SoDienThoai = txtSdtKh.Text;
                    kh.DiaChi = txtDiaChiKh.Text;
                    kh.Email = txtEmailKh.Text;
                    khRepo.Update(kh);

                    MessageBox.Show("Đã sửa thông tin khách hàng");
                }
                gridviewKhachHang();
            }
        }

        private void btnDelKh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdKh.Text))
            {
                MessageBox.Show("Xin chọn nhân viên cần xoá ở bảng bên phải!");
                return;
            }
            else
            {
                if (MessageBox.Show(
                    "Có chắc là muốn xoá loại sản phẩm" + Environment.NewLine +
                    txtTenKh.Text,
                    "Cảnh báo",
                     MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<KhachHang> khRepo = new Repository<KhachHang>(dbCxt);
                    var kh = khRepo.Get(Guid.Parse(txtIdKh.Text));

                    khRepo.Delete(kh);

                    MessageBox.Show("Đã xoá nhân viên: " + kh.TenKhachHang);
                }
                gridviewKhachHang();
            }
        }

        private void btnClearInputKh_Click(object sender, EventArgs e)
        {
            clearkh();
        }

        private void dataGridViewKH_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewKH.CurrentRow.Index != -1)
            {
                txtIdKh.Text = dataGridViewKH.CurrentRow.Cells[0].Value.ToString();
                txtTenKh.Text = dataGridViewKH.CurrentRow.Cells[1].Value.ToString();
                txtSdtKh.Text = dataGridViewKH.CurrentRow.Cells[2].Value.ToString();
                txtDiaChiKh.Text = dataGridViewKH.CurrentRow.Cells[3].Value.ToString();
                txtEmailKh.Text = dataGridViewKH.CurrentRow.Cells[4].Value.ToString();
            }
        }
    }
}
