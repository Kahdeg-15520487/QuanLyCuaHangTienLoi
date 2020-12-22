using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class LoSanPham : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayNhap { get; set; }
        public Guid NhaCungCapId { get; set; }
        public Guid SanPhamId { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
