using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class KeHang : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public uint Hang { get; set; }
        public uint Cot { get; set; }
        public uint Ke { get; set; }
        public Guid SanPhamId { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
