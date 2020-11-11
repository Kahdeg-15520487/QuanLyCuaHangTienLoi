using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class SanPham : BaseEntity
    {
        public string TenSanPham { get; set; }
        public List<LoaiSanPham> LoaiSanPhams { get; set; }
        public List<NhaCungCap> NhaCungCap { get; set; }
        public List<LoSanPham> LoSanPhams { get; set; }
        public double GiaTien { get; set; }
    }
}
