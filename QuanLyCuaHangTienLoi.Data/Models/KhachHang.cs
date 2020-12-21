using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class KhachHang : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        [JsonIgnore]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
