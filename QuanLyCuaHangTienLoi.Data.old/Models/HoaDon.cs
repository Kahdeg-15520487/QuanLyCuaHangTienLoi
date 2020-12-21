using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class HoaDon
    {
        public Guid Id { get; set; }
        public ICollection<Guid> ChiTietHoaDon { get; set; }
    }
}
