using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class HoaDon : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime NgayLap { get; set; }
        public Guid NhanVienId { get; set; }
        public Guid KhachHangId { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        [JsonIgnore]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }
    }
}
