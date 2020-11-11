using Newtonsoft.Json;

using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementations;
using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace testconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LiteDbContext context = new LiteDbContext("chtl.db");
            SanPhamRepository spRepo = new SanPhamRepository(context);

            var nhacungcap = new NhaCungCap()
            {
                TenNhaCungCap = "Viet Tien",
                ThongTinLienHe = "121345"
            };
            context.Context.GetCollection<NhaCungCap>().Insert(nhacungcap);

            var loaisanpham = new LoaiSanPham()
            {
                TenLoaiSanPham = "may mac"
            };
            context.Context.GetCollection<LoaiSanPham>().Insert(loaisanpham);

            var losanpham = new LoSanPham()
            {
                NhaCungCap = nhacungcap,
                NgayNhap = DateTime.Now,
                SoLuong = 50
            };
            context.Context.GetCollection<LoSanPham>().Insert(losanpham);

            var sp = new SanPham()
            {
                TenSanPham = "Ao thun Nam",
                GiaTien = 100,
                LoaiSanPhams = new List<LoaiSanPham> { loaisanpham },
                LoSanPhams = new List<LoSanPham> { losanpham },
                NhaCungCap = new List<NhaCungCap> { nhacungcap }
            };

            spRepo.Save(sp);

            foreach (var x in context.Context.GetCollection<SanPham>().FindAll().ToList())
            {
                Console.WriteLine(JsonConvert.SerializeObject(x));
            }

            foreach (var x in context.Context.GetCollection<LoSanPham>().FindAll().ToList())
            {
                Console.WriteLine(JsonConvert.SerializeObject(x));
            }

            Console.ReadLine();
        }
    }
}
