using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class LoaiSanPham
    {
        public Guid Id { get; set; }
        public string TenLoaiSanPham { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
