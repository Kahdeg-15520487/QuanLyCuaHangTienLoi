using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI.DisplayObject
{
    public class HienThiHoaDon
    {
        [CollumName("Mã hóa đơn")]
        public Guid Id { get; set; }
        [CollumName("Ngày lập")]
        public DateTime NgayLap { get; set; }
        [CollumName("Nhân viên")]
        public string TenNhanVien { get; set; }
        [CollumName("Khách hàng")]
        public string TenKhachHang { get; set; }
        [CollumName("Nợ")]
        public double No { get; set; }
    }
}
