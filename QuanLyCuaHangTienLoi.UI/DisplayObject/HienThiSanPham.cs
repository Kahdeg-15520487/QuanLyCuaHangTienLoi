using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI.DisplayObject
{
    public class HienThiSanPham
    {
        [CollumName("Mã sản phẩm")]
        public Guid Id { get; set; }
        [CollumName("Tên sản phẩm")]
        public string TenSanPham { get; set; }
        [CollumName("Số lượng")]
        public int SoLuong { get; set; }
        [CollumName("Giá niêm yết")]
        public double GiaTien { get; set; }
        [CollumName("Loại")]
        public LoaiSanPham LoaiSanPham { get; set; }
        [CollumName("Đơn vị")]
        public DonViSanPham DonViSanPham { get; set; }
    }
}
