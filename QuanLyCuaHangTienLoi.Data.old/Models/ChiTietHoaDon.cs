using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class ChiTietHoaDon
    {
        public Guid Id { get; set; }
        public Guid HoaDon { get; set; }
        public Guid SanPham { get; set; }
        public int SoLuong { get; set; }
    }
}
