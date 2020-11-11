using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class LoSanPham : BaseEntity
    {
        public NhaCungCap NhaCungCap { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
    }
}
