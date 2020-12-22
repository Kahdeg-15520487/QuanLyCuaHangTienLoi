using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI.DisplayObject
{
    public class HienThiChiTietHoaDon
    {
        [CollumName("Mã sản phẩm")]
        public Guid SanPhamId { get; set; }
        [CollumName("Tên sản phẩm")]
        public string TenSanPham { get; set; }
        [CollumName("Số lượng")]
        public int SoLuong { get; set; }
        [CollumName("Đơn giá")]
        public double DonGia { get; set; }
    }
}
