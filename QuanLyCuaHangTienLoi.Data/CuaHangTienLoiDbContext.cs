using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Collections.Generic;
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
                else
                {
                    connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=chtl;Integrated Security=True";
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mockSanPham = "[{\r\n  \"Id\": \"75fbb1ed-bdd0-403c-8d24-e85d74e11945\",\r\n  \"TenSanPham\": \"Beans - Wax\",\r\n  \"GiaTien\": 37000\r\n}, {\r\n  \"Id\": \"62e4e3d4-6534-4a95-b243-a81732f9a74e\",\r\n  \"TenSanPham\": \"Swordfish Loin Portions\",\r\n  \"GiaTien\": 13000\r\n}, {\r\n  \"Id\": \"13e407fc-a55d-4c56-8f2a-85ea63a48523\",\r\n  \"TenSanPham\": \"Bagels Poppyseed\",\r\n  \"GiaTien\": 11000\r\n}, {\r\n  \"Id\": \"d2646916-48aa-4e65-9974-3c8356681d0d\",\r\n  \"TenSanPham\": \"Tofu - Firm\",\r\n  \"GiaTien\": 38000\r\n}, {\r\n  \"Id\": \"49edbe65-ddf6-44ad-8a62-78b45a530ee0\",\r\n  \"TenSanPham\": \"Wine - Jaboulet Cotes Du Rhone\",\r\n  \"GiaTien\": 25000\r\n}, {\r\n  \"Id\": \"0113a4dc-2390-4ad1-b909-66f89e2352fb\",\r\n  \"TenSanPham\": \"Spice - Onion Powder Granulated\",\r\n  \"GiaTien\": 33000\r\n}, {\r\n  \"Id\": \"ed6cb8d4-429a-4fb8-8291-4fc3fae8b74d\",\r\n  \"TenSanPham\": \"Evaporated Milk - Skim\",\r\n  \"GiaTien\": 31000\r\n}, {\r\n  \"Id\": \"8383c50d-9583-4d5b-a253-fe3f9199bf36\",\r\n  \"TenSanPham\": \"Squash - Guords\",\r\n  \"GiaTien\": 13000\r\n}, {\r\n  \"Id\": \"9fac33d0-dae0-4d88-84f7-ea5bca2254b3\",\r\n  \"TenSanPham\": \"Filter - Coffee\",\r\n  \"GiaTien\": 45000\r\n}, {\r\n  \"Id\": \"f57153a0-2f1f-4733-a332-97ee6961e4f3\",\r\n  \"TenSanPham\": \"Beer - Paulaner Hefeweisse\",\r\n  \"GiaTien\": 47000\r\n}]";
            var mockLoaiSanPham = "[{\r\n  \"Id\": \"347d242a-7028-4b64-9165-7fa0334050a9\",\r\n  \"TenLoaiSanPham\": \"Nước ngọt\"\r\n}, {\r\n  \"Id\": \"4f8976b6-770f-4c92-84aa-730d013ac187\",\r\n  \"TenLoaiSanPham\": \"Bánh kẹo\"\r\n}, {\r\n  \"Id\": \"f378b558-0e08-4db4-9d44-fd7efebc849e\",\r\n  \"TenLoaiSanPham\": \"Rau quả\"\r\n}, {\r\n  \"Id\": \"3482ac8c-9dea-4727-aa16-2ad90182457d\",\r\n  \"TenLoaiSanPham\": \"Thịt\"\r\n}, {\r\n  \"Id\": \"530293c4-bca8-4429-9df4-d0827c3a83b7\",\r\n  \"TenLoaiSanPham\": \"Đồ sữa\"\r\n}]";
            var mockNhaCungCap = "[{\r\n  \"Id\": \"0ec1ab8f-8d70-409b-9b11-efb27284c4a0\",\r\n  \"TenNhaCungCap\": \"Topiczoom\"\r\n}, {\r\n  \"Id\": \"02418cb3-ed16-469d-869b-37aead548c84\",\r\n  \"TenNhaCungCap\": \"Thoughtmix\"\r\n}, {\r\n  \"Id\": \"fbc4aff7-1b71-4f29-9d04-6e5a2030cdc9\",\r\n  \"TenNhaCungCap\": \"Gigaclub\"\r\n}, {\r\n  \"Id\": \"03a9cf4f-6efa-480e-b3c8-c298298df715\",\r\n  \"TenNhaCungCap\": \"Vinder\"\r\n}, {\r\n  \"Id\": \"ae5fc190-a606-4e3d-a96e-2c6dd22dacc1\",\r\n  \"TenNhaCungCap\": \"Dynazzy\"\r\n}]";
            var mockNhanVien = "[{\r\n  \"Id\": \"7b5c2d90-7798-4227-9f1c-637bb3a19bda\",\r\n  \"TenNhanVien\": \"admin\",\r\n  \"UserName\": \"admin\",\r\n  \"MatKhau\": \"1a2eb4b4\"\r\n}, {\r\n  \"Id\": \"741faa63-e6ac-4cce-b0c9-4676ba4d78fe\",\r\n  \"TenNhanVien\": \"Minette Eallis\",\r\n  \"UserName\": \"minetteeallis\",\r\n  \"MatKhau\": \"14165849\"\r\n}, {\r\n  \"Id\": \"879603fe-211d-41f4-b877-78795c40d423\",\r\n  \"TenNhanVien\": \"Kacie Phettis\",\r\n  \"UserName\": \"kaciephettis\",\r\n  \"MatKhau\": \"83b3acf6\"\r\n}, {\r\n  \"Id\": \"af251ac8-a93b-4e7f-aef3-900d8298fc2e\",\r\n  \"TenNhanVien\": \"Erinn King\",\r\n  \"UserName\": \"erinnking\",\r\n  \"MatKhau\": \"fc4fb722\"\r\n}, {\r\n  \"Id\": \"527f86c2-520f-4a0c-803f-6dc9a68438a8\",\r\n  \"TenNhanVien\": \"Nanci Pain\",\r\n  \"UserName\": \"nancipain\",\r\n  \"MatKhau\": \"6aaac2a0\"\r\n}]";
            var mockKhachHang = "[{\r\n  \"Id\": \"00000000-0000-0000-0000-000000000001\",\r\n  \"TenKhachHang\": \"Ko co khach hang\",\r\n  \"SoDienThoai\": \"\",\r\n  \"Email\": \"\"\r\n},{\r\n  \"Id\": \"7e3a16bf-ff86-4569-9f85-ae74990635de\",\r\n  \"TenKhachHang\": \"Budd Blackston\",\r\n  \"SoDienThoai\": \"450-52-6781\",\r\n  \"Email\": \"buddblackston@email.com\"\r\n}, {\r\n  \"Id\": \"8b702d4f-a0b5-4615-a3a6-df2ddeeba7f7\",\r\n  \"TenKhachHang\": \"Alida Sommerled\",\r\n  \"SoDienThoai\": \"798-91-4772\",\r\n  \"Email\": \"alidasommerled@email.com\"\r\n}, {\r\n  \"Id\": \"1c2df9bb-1133-44a4-9e85-781032e8e43e\",\r\n  \"TenKhachHang\": \"Georas Craggs\",\r\n  \"SoDienThoai\": \"455-12-4139\",\r\n  \"Email\": \"georascraggs@email.com\"\r\n}, {\r\n  \"Id\": \"668fed87-4abd-49c9-a414-78194421e705\",\r\n  \"TenKhachHang\": \"Aguistin Stembridge\",\r\n  \"SoDienThoai\": \"162-12-4841\",\r\n  \"Email\": \"aguistinstembridge@email.com\"\r\n}, {\r\n  \"Id\": \"4e463bff-8b71-4af9-97bb-f4b4af591632\",\r\n  \"TenKhachHang\": \"Demott Enevold\",\r\n  \"SoDienThoai\": \"737-02-8831\",\r\n  \"Email\": \"demottenevold@email.com\"\r\n}]";
            var mockDonViSanPham = "[{\r\n  \"Id\": \"592657c2-c52f-4014-a671-e6483232de44\",\r\n  \"TenDonViSanPham\": \"H\u1ED9p\"\r\n}, {\r\n  \"Id\": \"e56b3513-7b1d-4951-867b-8c7532390a7b\",\r\n  \"TenDonViSanPham\": \"Chai\"\r\n}, {\r\n  \"Id\": \"25e5bb3a-0bc8-4ec1-b0f2-388a69ae5b33\",\r\n  \"TenDonViSanPham\": \"Lon\"\r\n}, {\r\n  \"Id\": \"3433f265-232d-4e0c-bcdd-91d4de6454ed\",\r\n  \"TenDonViSanPham\": \"Th\u00F9ng\"\r\n}, {\r\n  \"Id\": \"65e8e640-bee2-4772-9eec-811132d09c62\",\r\n  \"TenDonViSanPham\": \"G\u00F3i\"\r\n}]";

            var serializedSanPham = JsonConvert.DeserializeObject<SanPham[]>(mockSanPham);
            var serializedLoaiSanPham = JsonConvert.DeserializeObject<LoaiSanPham[]>(mockLoaiSanPham);
            var serializedDonViSanPham = JsonConvert.DeserializeObject<DonViSanPham[]>(mockDonViSanPham);
            var serializedNhaCungCap = JsonConvert.DeserializeObject<NhaCungCap[]>(mockNhaCungCap);

            serializedSanPham = serializedSanPham.Select((sp, count) =>
            {
                sp.LoaiSanPhamId = serializedLoaiSanPham[(count / 2)].Id;
                sp.DonViSanPhamId = serializedDonViSanPham[(count / 2)].Id;
                return sp;
            }).ToArray();

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
