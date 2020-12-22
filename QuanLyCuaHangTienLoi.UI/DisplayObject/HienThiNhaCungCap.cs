using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI.DisplayObject
{
    public class HienThiNhaCungCap
    {
        [CollumName("Mã nhà cung cấp")]
        public Guid Id { get; set; }
        [CollumName("Tên nhà cung cấp")]
        public string TenNhaCungCap { get; set; }
    }
}
