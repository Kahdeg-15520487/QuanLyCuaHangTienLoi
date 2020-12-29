using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class SanPham : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string TenSanPham { get; set; }
        public double GiaTien { get; set; }
        public Guid LoaiSanPhamId { get; set; }
        public Guid DonViSanPhamId { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual DonViSanPham DonViSanPham { get; set; }
        [JsonIgnore]
        public virtual ICollection<NhaCungCap> NhaCungCaps { get; set; }
        [JsonIgnore]
        public virtual ICollection<LoSanPham> LoSanPhams { get; set; }

        public override string ToString() => TenSanPham;
    }
}
