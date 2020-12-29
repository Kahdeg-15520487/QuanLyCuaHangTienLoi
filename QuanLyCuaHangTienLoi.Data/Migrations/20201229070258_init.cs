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
                values: new object[] { new Guid("25e5bb3a-0bc8-4ec1-b0f2-388a69ae5b33"), "Lon" });

            migrationBuilder.InsertData(
                table: "DonViSanPhams",
                columns: new[] { "Id", "TenDonViSanPham" },
                values: new object[] { new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"), "Thùng" });

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
                values: new object[] { new Guid("7e3a16bf-ff86-4569-9f85-ae74990635de"), null, "buddblackston@email.com", false, "450-52-6781", "Budd Blackston" });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "IsActive", "SoDienThoai", "TenKhachHang" },
                values: new object[] { new Guid("8b702d4f-a0b5-4615-a3a6-df2ddeeba7f7"), null, "alidasommerled@email.com", false, "798-91-4772", "Alida Sommerled" });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "IsActive", "SoDienThoai", "TenKhachHang" },
                values: new object[] { new Guid("1c2df9bb-1133-44a4-9e85-781032e8e43e"), null, "georascraggs@email.com", false, "455-12-4139", "Georas Craggs" });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "IsActive", "SoDienThoai", "TenKhachHang" },
                values: new object[] { new Guid("668fed87-4abd-49c9-a414-78194421e705"), null, "aguistinstembridge@email.com", false, "162-12-4841", "Aguistin Stembridge" });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "IsActive", "SoDienThoai", "TenKhachHang" },
                values: new object[] { new Guid("4e463bff-8b71-4af9-97bb-f4b4af591632"), null, "demottenevold@email.com", false, "737-02-8831", "Demott Enevold" });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "Id", "TenLoaiSanPham" },
                values: new object[] { new Guid("530293c4-bca8-4429-9df4-d0827c3a83b7"), "Đồ sữa" });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "Id", "TenLoaiSanPham" },
                values: new object[] { new Guid("3482ac8c-9dea-4727-aa16-2ad90182457d"), "Thịt" });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "Id", "TenLoaiSanPham" },
                values: new object[] { new Guid("4f8976b6-770f-4c92-84aa-730d013ac187"), "Bánh kẹo" });

            migrationBuilder.InsertData(
                table: "LoaiSanPhams",
                columns: new[] { "Id", "TenLoaiSanPham" },
                values: new object[] { new Guid("347d242a-7028-4b64-9165-7fa0334050a9"), "Nước ngọt" });

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
                values: new object[] { new Guid("af251ac8-a93b-4e7f-aef3-900d8298fc2e"), false, "fc4fb722", "Erinn King", "erinnking" });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "IsActive", "Matkhau", "TenNhanVien", "Username" },
                values: new object[] { new Guid("7b5c2d90-7798-4227-9f1c-637bb3a19bda"), false, "1a2eb4b4", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "IsActive", "Matkhau", "TenNhanVien", "Username" },
                values: new object[] { new Guid("741faa63-e6ac-4cce-b0c9-4676ba4d78fe"), false, "14165849", "Minette Eallis", "minetteeallis" });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "IsActive", "Matkhau", "TenNhanVien", "Username" },
                values: new object[] { new Guid("879603fe-211d-41f4-b877-78795c40d423"), false, "83b3acf6", "Kacie Phettis", "kaciephettis" });

            migrationBuilder.InsertData(
                table: "NhanViens",
                columns: new[] { "Id", "IsActive", "Matkhau", "TenNhanVien", "Username" },
                values: new object[] { new Guid("527f86c2-520f-4a0c-803f-6dc9a68438a8"), false, "6aaac2a0", "Nanci Pain", "nancipain" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("75fbb1ed-bdd0-403c-8d24-e85d74e11945"), new Guid("592657c2-c52f-4014-a671-e6483232de44"), 37000.0, new Guid("347d242a-7028-4b64-9165-7fa0334050a9"), "Beans - Wax" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("62e4e3d4-6534-4a95-b243-a81732f9a74e"), new Guid("592657c2-c52f-4014-a671-e6483232de44"), 13000.0, new Guid("347d242a-7028-4b64-9165-7fa0334050a9"), "Swordfish Loin Portions" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("13e407fc-a55d-4c56-8f2a-85ea63a48523"), new Guid("e56b3513-7b1d-4951-867b-8c7532390a7b"), 11000.0, new Guid("4f8976b6-770f-4c92-84aa-730d013ac187"), "Bagels Poppyseed" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("d2646916-48aa-4e65-9974-3c8356681d0d"), new Guid("e56b3513-7b1d-4951-867b-8c7532390a7b"), 38000.0, new Guid("4f8976b6-770f-4c92-84aa-730d013ac187"), "Tofu - Firm" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("49edbe65-ddf6-44ad-8a62-78b45a530ee0"), new Guid("25e5bb3a-0bc8-4ec1-b0f2-388a69ae5b33"), 25000.0, new Guid("f378b558-0e08-4db4-9d44-fd7efebc849e"), "Wine - Jaboulet Cotes Du Rhone" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("0113a4dc-2390-4ad1-b909-66f89e2352fb"), new Guid("25e5bb3a-0bc8-4ec1-b0f2-388a69ae5b33"), 33000.0, new Guid("f378b558-0e08-4db4-9d44-fd7efebc849e"), "Spice - Onion Powder Granulated" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("ed6cb8d4-429a-4fb8-8291-4fc3fae8b74d"), new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"), 31000.0, new Guid("3482ac8c-9dea-4727-aa16-2ad90182457d"), "Evaporated Milk - Skim" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("8383c50d-9583-4d5b-a253-fe3f9199bf36"), new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"), 13000.0, new Guid("3482ac8c-9dea-4727-aa16-2ad90182457d"), "Squash - Guords" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("9fac33d0-dae0-4d88-84f7-ea5bca2254b3"), new Guid("65e8e640-bee2-4772-9eec-811132d09c62"), 45000.0, new Guid("530293c4-bca8-4429-9df4-d0827c3a83b7"), "Filter - Coffee" });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "DonViSanPhamId", "GiaTien", "LoaiSanPhamId", "TenSanPham" },
                values: new object[] { new Guid("f57153a0-2f1f-4733-a332-97ee6961e4f3"), new Guid("65e8e640-bee2-4772-9eec-811132d09c62"), 47000.0, new Guid("530293c4-bca8-4429-9df4-d0827c3a83b7"), "Beer - Paulaner Hefeweisse" });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("5a4095f3-412c-4b7e-b587-0d03fe954ea6"), new DateTime(2020, 12, 27, 14, 2, 57, 945, DateTimeKind.Local).AddTicks(306), new Guid("0ec1ab8f-8d70-409b-9b11-efb27284c4a0"), new Guid("75fbb1ed-bdd0-403c-8d24-e85d74e11945"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("c51d32c9-7dcc-4a28-9a65-2602c22974be"), new DateTime(2020, 12, 27, 14, 2, 57, 946, DateTimeKind.Local).AddTicks(2183), new Guid("0ec1ab8f-8d70-409b-9b11-efb27284c4a0"), new Guid("62e4e3d4-6534-4a95-b243-a81732f9a74e"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("a9ce0c9d-6da8-43ed-9588-04e872ad2425"), new DateTime(2020, 12, 27, 14, 2, 57, 946, DateTimeKind.Local).AddTicks(2264), new Guid("02418cb3-ed16-469d-869b-37aead548c84"), new Guid("13e407fc-a55d-4c56-8f2a-85ea63a48523"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("cccf979c-09dc-4128-9c30-7f13a27b5236"), new DateTime(2020, 12, 27, 14, 2, 57, 946, DateTimeKind.Local).AddTicks(2268), new Guid("02418cb3-ed16-469d-869b-37aead548c84"), new Guid("d2646916-48aa-4e65-9974-3c8356681d0d"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("071f7866-5bb4-451b-aa01-3dd75e914dc1"), new DateTime(2020, 12, 27, 14, 2, 57, 946, DateTimeKind.Local).AddTicks(2271), new Guid("fbc4aff7-1b71-4f29-9d04-6e5a2030cdc9"), new Guid("49edbe65-ddf6-44ad-8a62-78b45a530ee0"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("0e7fd30f-7095-484e-9b5e-ca1a673a3d14"), new DateTime(2020, 12, 27, 14, 2, 57, 946, DateTimeKind.Local).AddTicks(2278), new Guid("fbc4aff7-1b71-4f29-9d04-6e5a2030cdc9"), new Guid("0113a4dc-2390-4ad1-b909-66f89e2352fb"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("3025d854-7f97-483b-a209-e5405c0f3055"), new DateTime(2020, 12, 27, 14, 2, 57, 946, DateTimeKind.Local).AddTicks(2281), new Guid("03a9cf4f-6efa-480e-b3c8-c298298df715"), new Guid("ed6cb8d4-429a-4fb8-8291-4fc3fae8b74d"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("b003639d-feb6-4da8-a775-7cdd68687883"), new DateTime(2020, 12, 27, 14, 2, 57, 946, DateTimeKind.Local).AddTicks(2299), new Guid("03a9cf4f-6efa-480e-b3c8-c298298df715"), new Guid("8383c50d-9583-4d5b-a253-fe3f9199bf36"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("f9f6a4d6-393d-4b92-bc02-a2462ef86fe0"), new DateTime(2020, 12, 27, 14, 2, 57, 946, DateTimeKind.Local).AddTicks(2302), new Guid("ae5fc190-a606-4e3d-a96e-2c6dd22dacc1"), new Guid("9fac33d0-dae0-4d88-84f7-ea5bca2254b3"), 20 });

            migrationBuilder.InsertData(
                table: "LoSanPhams",
                columns: new[] { "Id", "NgayNhap", "NhaCungCapId", "SanPhamId", "SoLuong" },
                values: new object[] { new Guid("a97ded23-5481-4cf7-9ede-c88b90c46935"), new DateTime(2020, 12, 27, 14, 2, 57, 946, DateTimeKind.Local).AddTicks(2305), new Guid("ae5fc190-a606-4e3d-a96e-2c6dd22dacc1"), new Guid("f57153a0-2f1f-4733-a332-97ee6961e4f3"), 20 });

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
