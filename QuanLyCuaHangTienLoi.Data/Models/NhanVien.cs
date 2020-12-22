using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class NhanVien : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string TenNhanVien { get; set; }
        public string Username { get; set; }
        public string Matkhau { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
