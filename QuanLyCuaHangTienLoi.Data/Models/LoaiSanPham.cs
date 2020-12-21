using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class LoaiSanPham : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string TenLoaiSanPham { get; set; }

        [JsonIgnore]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
