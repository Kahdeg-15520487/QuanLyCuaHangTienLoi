using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class ChiTietHoaDon : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HoaDonId { get; set; }
        public Guid LoSanPhamId { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public virtual HoaDon HoaDon { get; set; }
        public virtual LoSanPham LoSanPham { get; set; }
    }
}
