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
        SqlConnection connect = ClassKetnoi.connect;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adap;
        DataSet dskh;
        Label IDtt = new Label();
        string imglogoloc = "";
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
            txtTenNV.Clear();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdNV.Text))
            {
                MessageBox.Show("Trống!");
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
    }
}
