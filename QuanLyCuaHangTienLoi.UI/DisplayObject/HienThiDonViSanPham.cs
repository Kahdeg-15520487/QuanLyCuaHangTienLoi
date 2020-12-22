
using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI.DisplayObject
{
    public class HienThiDonViSanPham
    {
        [CollumName("Mã đơn vị sản phẩm")]
        public Guid Id { get; set; }
        [CollumName("Tên đơn vị sản phẩm")]
        public string TenDonViSanPham { get; set; }
    }
}
