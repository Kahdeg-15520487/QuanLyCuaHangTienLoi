using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using static System.Configuration.ConfigurationManager;


namespace QuanLyCuaHangTienLoi.Data
{
    public class CuaHangTienLoiDbContext : DbContext
    {
        public CuaHangTienLoiDbContext()
        {
        }

        public CuaHangTienLoiDbContext(DbContextOptions<CuaHangTienLoiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<DonViSanPham> DonViSanPhams { get; set; }
        public virtual DbSet<LoSanPham> LoSanPhams { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual DbSet<KeHang> KeHangs { get; set; }

        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<GiamGia> GiamGias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = null;
                if (AppSettings.AllKeys.Contains("ConnStr"))
                {
                    connectionString = AppSettings["ConnStr"];
                }
                else if (File.Exists("cs.config"))
                {
                    connectionString = File.ReadAllText("cs.config");
                }
                else
                {
                    connectionString = $"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "chtl.db")}";
                }

                optionsBuilder.UseSqlite(connectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mockSanPham = File.ReadAllText("SampleData\\sanpham.json");
            var mockLoaiSanPham = File.ReadAllText("SampleData\\loaisanpham.json");
            var mockNhaCungCap = File.ReadAllText("SampleData\\nhacungcap.json");
            var mockNhanVien = File.ReadAllText("SampleData\\nhanvien.json");
            var mockKhachHang = File.ReadAllText("SampleData\\khachhang.json");
            var mockDonViSanPham = File.ReadAllText("SampleData\\donvisanpham.json");

            var serializedSanPham = JsonConvert.DeserializeObject<SanPham[]>(mockSanPham);
            var serializedLoaiSanPham = JsonConvert.DeserializeObject<LoaiSanPham[]>(mockLoaiSanPham);
            var serializedDonViSanPham = JsonConvert.DeserializeObject<DonViSanPham[]>(mockDonViSanPham);
            var serializedNhaCungCap = JsonConvert.DeserializeObject<NhaCungCap[]>(mockNhaCungCap);

            //serializedSanPham = serializedSanPham.Select((sp, count) =>
            //{
            //    sp.LoaiSanPhamId = sp.LoaiSanPhamId;
            //    sp.DonViSanPhamId = sp.DonViSanPhamId;
            //    return sp;
            //}).ToArray();

            var loSanPham = new List<LoSanPham>();
            foreach ((SanPham sp, int i) in serializedSanPham.Select((sp, count) => (sp, count)))
            {
                loSanPham.Add(new LoSanPham()
                {
                    Id = Guid.NewGuid(),
                    NgayNhap = DateTime.Now.AddDays(-2),
                    NhaCungCapId = serializedNhaCungCap[i / 2].Id,
                    SanPhamId = sp.Id,
                    SoLuong = 20
                });
            }

            modelBuilder.Entity<NhaCungCap>().HasData(serializedNhaCungCap);
            modelBuilder.Entity<LoaiSanPham>().HasData(serializedLoaiSanPham);
            modelBuilder.Entity<DonViSanPham>().HasData(serializedDonViSanPham);
            modelBuilder.Entity<SanPham>().HasData(serializedSanPham);
            modelBuilder.Entity<LoSanPham>().HasData(loSanPham);
            modelBuilder.Entity<NhanVien>().HasData(JsonConvert.DeserializeObject<NhanVien[]>(mockNhanVien));
            modelBuilder.Entity<KhachHang>().HasData(JsonConvert.DeserializeObject<KhachHang[]>(mockKhachHang));

            base.OnModelCreating(modelBuilder);
        }
    }
}
