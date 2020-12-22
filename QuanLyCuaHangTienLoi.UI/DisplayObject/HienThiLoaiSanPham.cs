using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI.DisplayObject
{
    public class HienThiLoaiSanPham
    {
        [CollumName("Mã loại sản phẩm")]
        public Guid Id { get; set; }
        [CollumName("Tên loại sản phẩm")]
        public string TenLoaiSanPham { get; set; }
    }
}
