using Newtonsoft.Json;

using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class HienThiKhachHang
    {
        [CollumName("Mã khách hàng")]
        public Guid Id { get; set; }
        [CollumName("Tên khách hàng")]
        public string TenKhachHang { get; set; }
        [CollumName("Số điện thoại")]
        public string SoDienThoai { get; set; }
        [CollumName("Địa chỉ")]
        public string DiaChi { get; set; }
        [CollumName("Email")]
        public string Email { get; set; }
    }
}
