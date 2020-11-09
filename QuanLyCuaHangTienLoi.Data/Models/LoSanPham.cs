using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class LoSanPham
    {
        public Guid Id { get; set; }
        public SanPham SanPham { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
    }
}
