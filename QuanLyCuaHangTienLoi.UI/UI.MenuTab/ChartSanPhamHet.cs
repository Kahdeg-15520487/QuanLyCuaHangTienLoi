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
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.UI.DisplayObject;
using Microsoft.EntityFrameworkCore;

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{

    public partial class ChartSanPhamHet : Form
    {
        public void RefreshGridView()
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<SanPham> spRepo = new Repository<SanPham>(dbCxt);
                dataGridView1.DataSource = spRepo
                    .GetAll()
                    .Include(sp => sp.LoSanPhams).ToList()
                    .Select(sp => new HienThiSanPham
                    {
                        Id = sp.Id,
                        TenSanPham = sp.TenSanPham,
                        SoLuong = sp.LoSanPhams.Sum(lsp => lsp.SoLuong)
                    })
                    .Where(sp => sp.SoLuong < 10)
                    .ToDataTable();
            }
        }

        public ChartSanPhamHet()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            RefreshGridView();
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
                    .Where(sp => sp.SoLuong < 10)
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
    }
}
