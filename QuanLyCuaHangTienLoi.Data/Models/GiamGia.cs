using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class GiamGia : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int PhanTramGiamGia { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public Guid SanPhamId { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
