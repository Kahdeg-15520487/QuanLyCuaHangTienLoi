using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class SanPham
    {
        public Guid Id { get; set; }
        public string TenSanPham { get; set; }
        public ICollection<LoaiSanPham> LoaiSanPhams { get; set; }
        public ICollection<NhaCungCap> NhaCungCap { get; set; }
        public ICollection<LoSanPham> LoSanPhams { get; set; }
        public double GiaTien { get; set; }
    }
}
