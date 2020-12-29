using Microsoft.EntityFrameworkCore;

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
    public partial class GiamGiaForm : Form
    {
        public GiamGiaForm()
        {
            InitializeComponent();
            dataGridView_sp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_gg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RefreshGridViewGiamGia();
            RefreshGridViewSanPham();

            //todo db sanpham
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<LoaiSanPham> loaiSanPhamRepo = new Repository<LoaiSanPham>(dbCxt);

                comboBox_loaisp.Items.Clear();
                foreach (var loaiSp in loaiSanPhamRepo.GetAll())
                {
                    comboBox_loaisp.Items.Add(loaiSp);
                }
                comboBox_loaisp.Refresh();

                Repository<Data.Models.SanPham> repo = new Repository<Data.Models.SanPham>(dbCxt);
                var sp = repo.GetAll().Select(s => s.TenSanPham).ToList();

                AutoCompleteStringCollection autotensp = new AutoCompleteStringCollection();
                sp.ForEach(tsp => autotensp.Add(tsp));
                txt_tensp.AutoCompleteMode = AutoCompleteMode.Suggest;
                txt_tensp.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_tensp.AutoCompleteCustomSource = autotensp;
            }
        }

        private void clear()
        {
            numericUpDown_phantramgiam.Value = 0;
            txt_id_giamgia.Clear();
        }

        private void RefreshGridViewGiamGia()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<GiamGia> ggRepo = new Repository<GiamGia>(dbCxt);

                DataTable dt = ggRepo.Query(gg => gg.NgayBatDau < DateTime.Now && gg.NgayKetThuc > DateTime.Now).Select(gg => new HienThiGiamGia
                {
                    Id = gg.Id,
                    SanPham = gg.SanPham,
                    PhanTramGiamGia = gg.PhanTramGiamGia,
                    NgayBatDau = gg.NgayBatDau,
                    NgayKetThuc = gg.NgayKetThuc,
                }).ToDataTable();
                dataGridView_gg.DataSource = dt;
            }
        }

        private void RefreshGridViewSanPham()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<SanPham> spRepo = new Repository<SanPham>(dbCxt);

                var loaiSanpham = comboBox_loaisp.SelectedItem as LoaiSanPham;
                if (loaiSanpham == null)
                {
                    DataTable dt = spRepo.GetAll().Select(sp => new HienThiSanPhamGiamGia
                    {
                        Id = sp.Id,
                        TenSanPham = sp.TenSanPham,
                        GiaTien = sp.GiaTien,
                        LoaiSanPham = sp.LoaiSanPham,
                    }).ToDataTable();
                    dataGridView_sp.DataSource = dt;
                }
                else
                {
                    DataTable dt = spRepo.Query(sp => sp.LoaiSanPhamId == loaiSanpham.Id).Select(sp => new HienThiSanPhamGiamGia
                    {
                        Id = sp.Id,
                        TenSanPham = sp.TenSanPham,
                        GiaTien = sp.GiaTien,
                        LoaiSanPham = sp.LoaiSanPham,
                    }).ToDataTable();
                    dataGridView_sp.DataSource = dt;
                }
            }
        }

        private double CalculateGiamGia(double giaGoc, decimal phanTram)
        {
            return giaGoc - (giaGoc * (double)phanTram / 100);
        }

        private void dataGridViewSp_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_sp.CurrentRow.Index != -1)
            {
                txt_id_sp.Text = dataGridView_sp.CurrentRow.Cells[0].Value.ToString();
                txt_tensp.Text = dataGridView_sp.CurrentRow.Cells[1].Value.ToString();
                double giaGoc = double.Parse(dataGridView_sp.CurrentRow.Cells[2].Value.ToString());
                txt_giasp.Text = giaGoc.ToString();
                txt_giasp_giam.Text = CalculateGiamGia(giaGoc, numericUpDown_phantramgiam.Value).ToString();
            }
        }

        private void dataGridViewGiamGia_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_gg.CurrentRow.Index != -1)
            {
                txt_id_giamgia.Text = dataGridView_gg.CurrentRow.Cells[0].Value.ToString();
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<GiamGia> ggRepo = new Repository<GiamGia>(dbCxt);

                    Guid.TryParse(txt_id_giamgia.Text, out Guid ggId);

                    var gg = ggRepo.Query(g => g.Id == ggId).Include(gg => gg.SanPham).ThenInclude(sp => sp.LoaiSanPham).FirstOrDefault();
                    numericUpDown_phantramgiam.Value = gg.PhanTramGiamGia;
                    dateTimePicker_batdau.Value = gg.NgayBatDau;
                    dateTimePicker_ketthuc.Value = gg.NgayKetThuc;
                    txt_id_sp.Text = gg.SanPhamId.ToString();
                    txt_tensp.Text = gg.SanPham.TenSanPham;
                    txt_giasp.Text = gg.SanPham.GiaTien.ToString();
                    txt_giasp_giam.Text = CalculateGiamGia(gg.SanPham.GiaTien, gg.PhanTramGiamGia).ToString();
                    comboBox_loaisp.Text = gg.SanPham.LoaiSanPham.TenLoaiSanPham;
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txt_id_sp.Text))
            {
                MessageBox.Show("Xin chọn sản phẩm!");
                return false;
            }
            else if (numericUpDown_phantramgiam.Value == 0)
            {
                MessageBox.Show($"Không thể tạo giảm giá với giá trị {numericUpDown_phantramgiam.Value}%!");
                return false;
            }
            return true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_id_giamgia.Text))
            {
                MessageBox.Show("Thông tin trống!");
                return;
            }

            if (!ValidateInput())
            {
                return;
            }
            else
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<GiamGia> ggRepo = new Repository<GiamGia>(dbCxt);

                    Guid.TryParse(txt_id_giamgia.Text, out Guid ggId);

                    var gg = ggRepo.Get(ggId);
                    gg.PhanTramGiamGia = (int)numericUpDown_phantramgiam.Value;
                    gg.SanPhamId = Guid.Parse(txt_id_sp.Text);
                    gg.NgayBatDau = dateTimePicker_batdau.Value;
                    gg.NgayKetThuc = dateTimePicker_ketthuc.Value;

                    ggRepo.Update(gg);

                    MessageBox.Show("Sửa chương trình giảm giá xong.");
                }
                RefreshGridViewGiamGia();
            }
            clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_id_giamgia.Text))
            {
                MessageBox.Show("Thông tin trống!");
                return;
            }
            else
            {
                if (MessageBox.Show(
                       "Có chắc là muốn xoá giảm giá cho sản phẩm" + Environment.NewLine +
                       txt_tensp.Text,
                       "Cảnh báo",
                        MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<GiamGia> ggRepo = new Repository<GiamGia>(dbCxt);

                    Guid.TryParse(txt_id_giamgia.Text, out Guid ggId);

                    var gg = ggRepo.Get(ggId);
                    ggRepo.Delete(gg);

                    MessageBox.Show("Xoá chương trình giảm giá xong.");
                }
                RefreshGridViewGiamGia();
            }
            clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_id_giamgia.Text))
            {
                MessageBox.Show("Xin nhập mới, bấm nút Nhập lại để xoá các field.");
                return;
            }

            if (!ValidateInput())
            {
                return;
            }
            else
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<GiamGia> ggRepo = new Repository<GiamGia>(dbCxt);

                    var ggMoi = new GiamGia
                    {
                        Id = Guid.NewGuid(),
                        SanPhamId = Guid.Parse(txt_id_sp.Text),
                        PhanTramGiamGia = (int)numericUpDown_phantramgiam.Value,
                        NgayBatDau = dateTimePicker_batdau.Value,
                        NgayKetThuc = dateTimePicker_ketthuc.Value
                    };

                    ggRepo.Insert(ggMoi);

                    MessageBox.Show("Thêm chương trình giảm giá xong.");
                }
                RefreshGridViewGiamGia();
            }
        }


        private void LoaiSP_Load(object sender, EventArgs e)
        {
            RefreshGridViewGiamGia();
        }

        private void comboBox_loaisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGridViewSanPham();
        }

        private void txt_tensp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<SanPham> spRepo = new Repository<SanPham>(dbCxt);
                    SanPham sanpham = spRepo.Query(sp => sp.TenSanPham == txt_tensp.Text).Include(sp => sp.LoaiSanPham).FirstOrDefault();

                    if (sanpham == null)
                    {
                        MessageBox.Show("Sản phẩm ko tồn tại");
                    }

                    txt_id_sp.Text = sanpham.Id.ToString();
                    txt_tensp.Text = sanpham.TenSanPham;
                    txt_giasp.Text = sanpham.GiaTien.ToString();
                    txt_giasp_giam.Text = CalculateGiamGia(sanpham.GiaTien, numericUpDown_phantramgiam.Value).ToString();
                    comboBox_loaisp.Text = sanpham.LoaiSanPham.TenLoaiSanPham;
                }
            }
        }
    }
}
