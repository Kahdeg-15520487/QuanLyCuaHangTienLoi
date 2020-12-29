using QuanLyCuaHangTienLoi.Data.Models;
using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI.DisplayObject
{
    class HienThiGiamGia
    {
        [CollumName("Mã chương trình giảm giá")]
        public Guid Id { get; set; }
        [CollumName("Sản phẩm")]
        public SanPham SanPham { get; set; }
        [CollumName("Phần trăm")]
        public int PhanTramGiamGia { get; set; }
        [CollumName("Ngày bắt đầu")]
        public DateTime NgayBatDau { get; set; }
        [CollumName("Ngày kết thúc")]
        public DateTime NgayKetThuc { get; set; }

    }
}
