using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI.DisplayObject
{
    public class HienThiNhanVien
    {
        [CollumName("Mã nhân viên")]
        public Guid Id { get; set; }
        [CollumName("Tên nhân viên")]
        public string TenNhanVien { get; set; }
        [CollumName("Tên đăng nhập")]
        public string UserName { get; set; }
    }
}
