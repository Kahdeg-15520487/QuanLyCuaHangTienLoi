using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI.DisplayObject
{
    public class HienThiSanPhamGiamGia
    {
        [CollumName("Mã sản phẩm")]
        public Guid Id { get; set; }
        [CollumName("Tên sản phẩm")]
        public string TenSanPham { get; set; }
        [CollumName("Giá gốc")]
        public double GiaTien { get; set; }
        [CollumName("Loại sản phẩm")]
        public LoaiSanPham LoaiSanPham { get; set; }
    }
}
