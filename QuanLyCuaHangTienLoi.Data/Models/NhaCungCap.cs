using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class NhaCungCap : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string TenNhaCungCap { get; set; }
        public string ThongTinLienHe { get; set; }

        [JsonIgnore]
        public virtual ICollection<SanPham> SanPhams { get; set; }
        [JsonIgnore]
        public virtual ICollection<LoSanPham> LoSanPhams { get; set; }

        public override string ToString() => TenNhaCungCap;
    }
}
