using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyCuaHangTienLoi.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonViSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenDonViSanPham = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViSanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenKhachHang = table.Column<string>(type: "TEXT", nullable: true),
                    SoDienThoai = table.Column<string>(type: "TEXT", nullable: true),
                    DiaChi = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenLoaiSanPham = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenNhaCungCap = table.Column<string>(type: "TEXT", nullable: true),
                    ThongTinLienHe = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenNhanVien = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Matkhau = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenSanPham = table.Column<string>(type: "TEXT", nullable: true),
                    GiaTien = table.Column<double>(type: "REAL", nullable: false),
                    LoaiSanPhamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DonViSanPhamId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhams_DonViSanPhams_DonViSanPhamId",
                        column: x => x.DonViSanPhamId,
                        principalTable: "DonViSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhams_LoaiSanPhams_LoaiSanPhamId",
                        column: x => x.LoaiSanPhamId,
                        principalTable: "LoaiSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "TEXT", nullable: false),
                    KhachHangId = table.Column<Guid>(type: "TEXT", nullable: false),
                    No = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDons_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiamGias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PhanTramGiamGia = table.Column<int>(type: "INTEGER", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SanPhamId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiamGias_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Hang = table.Column<uint>(type: "INTEGER", nullable: false),
                    Cot = table.Column<uint>(type: "INTEGER", nullable: false),
                    Ke = table.Column<uint>(type: "INTEGER", nullable: false),
                    SanPhamId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeHangs_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoSanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoLuong = table.Column<int>(type: "INTEGER", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NhaCungCapId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SanPhamId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoSanPhams_NhaCungCaps_NhaCungCapId",
                        column: x => x.NhaCungCapId,
                        principalTable: "NhaCungCaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoSanPhams_SanPhams_SanPhamId",
                        column: x => x.SanPhamId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCapSanPham",
                columns: table => new
                {
                    NhaCungCapsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SanPhamsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCapSanPham", x => new { x.NhaCungCapsId, x.SanPhamsId });
                    table.ForeignKey(
                        name: "FK_NhaCungCapSanPham_NhaCungCaps_NhaCungCapsId",
                        column: x => x.NhaCungCapsId,
                        principalTable: "NhaCungCaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhaCungCapSanPham_SanPhams_SanPhamsId",
                        column: x => x.SanPhamsId,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HoaDonId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoSanPhamId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoLuong = table.Column<int>(type: "INTEGER", nullable: false),
                    DonGia = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDons_LoSanPhams_LoSanPhamId",
                        column: x => x.LoSanPhamId,
                        principalTable: "LoSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DonViSanPhams",
                columns: new[] { "Id", "TenDonViSanPham" },
                values: new object[] { new Guid("592657c2-c52f-4014-a671-e6483232de44"), "Hộp" });

            migrationBuilder.InsertData(
                table: "DonViSanPhams",
                columns: new[] { "Id", "TenDonViSanPham" },
                values: new object[] { new Guid("e56b3513-7b1d-4951-867b-8c7532390a7b"), "Chai" });

            migrationBuilder.InsertData(
                table: "DonViSanPhams",
                columns: new[] { "Id", "TenDonViSanPham" },
                values: new object[] { new Guid("25e5bb3a-0bc8-4ec1-b0f2-388a69ae5b33"), "Cái" });

            migrationBuilder.InsertData(
                table: "DonViSanPhams",
                columns: new[] { "Id", "TenDonViSanPham" },
                values: new object[] { new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"), "Lạng" });

            migrationBuilder.InsertData(
                table: "DonViSanPhams",
                columns: new[] { "Id", "TenDonViSanPham" },
                values: new object[] { new Guid("65e8e640-bee2-4772-9eec-811132d09c62"), "Gói" });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "IsActive", "SoDienThoai", "TenKhachHang" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), null, "", false, "", "Ko co khach hang" });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "IsActive", "SoDienThoai", "TenKhachHang" },
                values: new object[] { new Guid("7e3a16bf-ff86-4569-9f85-ae74990635de"), null, "klinh@email.com", false, "450526781", "Nguyễn Khánh Linh" });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "IsActive", "SoDienThoai", "TenKhachHang" },
                values: new object[] { new Guid("8b702d4f-a0b5-4615-a3a6-df2ddeeba7f7"), null, "ttan@email.com", false, "798914772", "Hoàng Thanh Tân" });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "IsActive", "SoDienThoai", "TenKhachHang" },
                values: new object[] { new Guid("1c2df9bb-1133-44a4-9e85-781032e8e43e"), null, "mhoang@email.com", false, "455124139", "Nguyễn Minh Hoàng" });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "IsActive", "SoDienThoai", "TenKhachHang" },
                values: new object[] { new Guid("668fed87-4abd-49c9-a414-78194421e705"), null, "lminh@email.com", false, "162124841", "Nguyễn Lê Minh" });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "IsActive", "SoDienThoai", "TenKhachHang" },
                values: new object[] { new Guid("4e463bff-8b71-4af9-97bb-f4b4af591632"), null, "ttin@email.com", false, "737-02-8831", "Nguyễn Trọng Tin" });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "Id", "TenLoaiSanPham" },
                values: new object[] { new Guid("c02ac222-1ff5-42e0-8f7c-ae55e5bf8835"), "Đồ dùng gia dụng" });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "Id", "TenLoaiSanPham" },
                values: new object[] { new Guid("530293c4-bca8-4429-9df4-d0827c3a83b7"), "Sữa" });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "Id", "TenLoaiSanPham" },
                values: new object[] { new Guid("3482ac8c-9dea-4727-aa16-2ad90182457d"), "Thịt" });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "Id", "TenLoaiSanPham" },
                values: new object[] { new Guid("347d242a-7028-4b64-9165-7fa0334050a9"), "Nước ngọt" });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "Id", "TenLoaiSanPham" },
                values: new object[] { new Guid("4f8976b6-770f-4c92-84aa-730d013ac187"), "Bánh kẹo" });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "Id", "TenLoaiSanPham" },
                values: new object[] { new Guid("f378b558-0e08-4db4-9d44-fd7efebc849e"), "Rau quả" });

            migrationBuilder.InsertData(
                table: "NhaCungCaps",
                columns: new[] { "Id", "TenNhaCungCap", "ThongTinLienHe" },
                values: new object[] { new Guid("0ec1ab8f-8d70-409b-9b11-efb27284c4a0"), "Topiczoom", null });

            migrationBuilder.InsertData(
                table: "NhaCungCaps",
                columns: new[] { "Id", "TenNhaCungCap", "ThongTinLienHe" },
                values: new object[] { new Guid("02418cb3-ed16-469d-869b-37aead548c84"), "Thoughtmix", null });

            migrationBuilder.InsertData(
                table: "NhaCungCaps",
                columns: new[] { "Id", "TenNhaCungCap", "ThongTinLienHe" },
                values: new object[] { new Guid("fbc4aff7-1b71-4f29-9d04-6e5a2030cdc9"), "Gigaclub", null });

            migrationBuilder.InsertData(
                table: "NhaCungCaps",
                columns: new[] { "Id", "TenNhaCungCap", "ThongTinLienHe" },
                values: new object[] { new Guid("03a9cf4f-6efa-480e-b3c8-c298298df715"), "Vinder", null });

            migrationBuilder.InsertData(
                table: "NhaCungCaps",
                columns: new[] { "Id", "TenNhaCungCap", "ThongTinLienHe" },
                values: new object[] { new Guid("ae5fc190-a606-4e3d-a96e-2c6dd22dacc1"), "Dynazzy", null });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "IsActive", "Matkhau", "TenNhanVien", "Username" },
                values: new object[] { new Guid("7b5c2d90-7798-4227-9f1c-637bb3a19bda"), false, "admin", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "IsActive", "Matkhau", "TenNhanVien", "Username" },
                values: new object[] { new Guid("741faa63-e6ac-4cce-b0c9-4676ba4d78fe"), false, "123456", "Đặng Quang Khải", "qkhai" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("49edbe65-ddf6-44ad-8a62-78b45a530ee0"), new Guid("e56b3513-7b1d-4951-867b-8c7532390a7b"), 20000.0, new Guid("347d242a-7028-4b64-9165-7fa0334050a9"), "Cocacola 1.5l" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("0113a4dc-2390-4ad1-b909-66f89e2352fb"), new Guid("e56b3513-7b1d-4951-867b-8c7532390a7b"), 19000.0, new Guid("347d242a-7028-4b64-9165-7fa0334050a9"), "7Up 1.5l" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("8383c50d-9583-4d5b-a253-fe3f9199bf36"), new Guid("592657c2-c52f-4014-a671-e6483232de44"), 80000.0, new Guid("4f8976b6-770f-4c92-84aa-730d013ac187"), "Bánh quy Danissa" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("75fbb1ed-bdd0-403c-8d24-e85d74e11945"), new Guid("65e8e640-bee2-4772-9eec-811132d09c62"), 10000.0, new Guid("f378b558-0e08-4db4-9d44-fd7efebc849e"), "Đậu xanh" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("62e4e3d4-6534-4a95-b243-a81732f9a74e"), new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"), 13000.0, new Guid("f378b558-0e08-4db4-9d44-fd7efebc849e"), "Cà rốt" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("13e407fc-a55d-4c56-8f2a-85ea63a48523"), new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"), 55000.0, new Guid("3482ac8c-9dea-4727-aa16-2ad90182457d"), "Thịt bằm" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("d2646916-48aa-4e65-9974-3c8356681d0d"), new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"), 40000.0, new Guid("3482ac8c-9dea-4727-aa16-2ad90182457d"), "Đùi gà góc tư" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("ed6cb8d4-429a-4fb8-8291-4fc3fae8b74d"), new Guid("e56b3513-7b1d-4951-867b-8c7532390a7b"), 24000.0, new Guid("530293c4-bca8-4429-9df4-d0827c3a83b7"), "Vinamilk 1l" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("9fac33d0-dae0-4d88-84f7-ea5bca2254b3"), new Guid("25e5bb3a-0bc8-4ec1-b0f2-388a69ae5b33"), 45000.0, new Guid("c02ac222-1ff5-42e0-8f7c-ae55e5bf8835"), "Dao" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("f57153a0-2f1f-4733-a332-97ee6961e4f3"), new Guid("65e8e640-bee2-4772-9eec-811132d09c62"), 47000.0, new Guid("c02ac222-1ff5-42e0-8f7c-ae55e5bf8835"), "Túi lọc nước" });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("e117ab27-0991-47fa-8b2d-e273a80bcefa"), new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9725), new Guid("fbc4aff7-1b71-4f29-9d04-6e5a2030cdc9"), new Guid("49edbe65-ddf6-44ad-8a62-78b45a530ee0"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("ba933db5-5a7e-4f72-b5f9-c6ab4f0da73e"), new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9743), new Guid("fbc4aff7-1b71-4f29-9d04-6e5a2030cdc9"), new Guid("0113a4dc-2390-4ad1-b909-66f89e2352fb"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("45745215-a79b-4b62-bf43-b79ffaac3cd8"), new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9749), new Guid("03a9cf4f-6efa-480e-b3c8-c298298df715"), new Guid("8383c50d-9583-4d5b-a253-fe3f9199bf36"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("bb7d6840-6114-4268-a675-84c7d226b804"), new DateTime(2020, 12, 27, 21, 47, 59, 195, DateTimeKind.Local).AddTicks(9081), new Guid("0ec1ab8f-8d70-409b-9b11-efb27284c4a0"), new Guid("75fbb1ed-bdd0-403c-8d24-e85d74e11945"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("26e82286-7bae-43ae-bb3c-dd65c01e25a0"), new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9641), new Guid("0ec1ab8f-8d70-409b-9b11-efb27284c4a0"), new Guid("62e4e3d4-6534-4a95-b243-a81732f9a74e"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("c12662ef-3752-44a1-ae48-1e0fc6902c3f"), new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9716), new Guid("02418cb3-ed16-469d-869b-37aead548c84"), new Guid("13e407fc-a55d-4c56-8f2a-85ea63a48523"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("1a34815d-63b7-4679-824e-981eaa3720e7"), new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9721), new Guid("02418cb3-ed16-469d-869b-37aead548c84"), new Guid("d2646916-48aa-4e65-9974-3c8356681d0d"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("5e516ffc-4763-4f0d-817d-5b1bf17dc433"), new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9746), new Guid("03a9cf4f-6efa-480e-b3c8-c298298df715"), new Guid("ed6cb8d4-429a-4fb8-8291-4fc3fae8b74d"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("297ba37c-db72-4c3a-9796-b84b6d575c5d"), new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9752), new Guid("ae5fc190-a606-4e3d-a96e-2c6dd22dacc1"), new Guid("9fac33d0-dae0-4d88-84f7-ea5bca2254b3"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("00f44079-c173-40d3-a416-4a6dd86ed05a"), new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9755), new Guid("ae5fc190-a606-4e3d-a96e-2c6dd22dacc1"), new Guid("f57153a0-2f1f-4733-a332-97ee6961e4f3"), 20 });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_HoaDonId",
                table: "ChiTietHoaDons",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDons_LoSanPhamId",
                table: "ChiTietHoaDons",
                column: "LoSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_GiamGias_SanPhamId",
                table: "GiamGias",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_KhachHangId",
                table: "HoaDons",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_NhanVienId",
                table: "HoaDons",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHangs_SanPhamId",
                table: "KeHangs",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_LoSanPhams_NhaCungCapId",
                table: "LoSanPhams",
                column: "NhaCungCapId");

            migrationBuilder.CreateIndex(
                name: "IX_LoSanPhams_SanPhamId",
                table: "LoSanPhams",
                column: "SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_NhaCungCapSanPham_SanPhamsId",
                table: "NhaCungCapSanPham",
                column: "SanPhamsId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_DonViSanPhamId",
                table: "SanPhams",
                column: "DonViSanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_LoaiSanPhamId",
                table: "SanPhams",
                column: "LoaiSanPhamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDons");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "KeHangs");

            migrationBuilder.DropTable(
                name: "NhaCungCapSanPham");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "LoSanPhams");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "NhaCungCaps");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "DonViSanPhams");

            migrationBuilder.DropTable(
                name: "LoaiSanPhams");
        }
    }
}
