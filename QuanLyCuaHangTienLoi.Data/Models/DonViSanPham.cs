using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class DonViSanPham : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string TenDonViSanPham { get; set; }

        [JsonIgnore]
        public virtual ICollection<SanPham> SanPhams { get; set; }

        public override string ToString() => TenDonViSanPham;
        public override int GetHashCode() => Id.GetHashCode();
    }
}
