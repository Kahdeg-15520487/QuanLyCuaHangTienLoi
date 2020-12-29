﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyCuaHangTienLoi.Data;

namespace QuanLyCuaHangTienLoi.Data.Migrations
{
    [DbContext(typeof(CuaHangTienLoiDbContext))]
    [Migration("20201229144759_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("NhaCungCapSanPham", b =>
                {
                    b.Property<Guid>("NhaCungCapsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SanPhamsId")
                        .HasColumnType("TEXT");

                    b.HasKey("NhaCungCapsId", "SanPhamsId");

                    b.HasIndex("SanPhamsId");

                    b.ToTable("NhaCungCapSanPham");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.ChiTietHoaDon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("DonGia")
                        .HasColumnType("REAL");

                    b.Property<Guid>("HoaDonId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LoSanPhamId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SoLuong")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HoaDonId");

                    b.HasIndex("LoSanPhamId");

                    b.ToTable("ChiTietHoaDons");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.DonViSanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenDonViSanPham")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DonViSanPhams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("592657c2-c52f-4014-a671-e6483232de44"),
                            TenDonViSanPham = "Hộp"
                        },
                        new
                        {
                            Id = new Guid("e56b3513-7b1d-4951-867b-8c7532390a7b"),
                            TenDonViSanPham = "Chai"
                        },
                        new
                        {
                            Id = new Guid("25e5bb3a-0bc8-4ec1-b0f2-388a69ae5b33"),
                            TenDonViSanPham = "Cái"
                        },
                        new
                        {
                            Id = new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"),
                            TenDonViSanPham = "Lạng"
                        },
                        new
                        {
                            Id = new Guid("65e8e640-bee2-4772-9eec-811132d09c62"),
                            TenDonViSanPham = "Gói"
                        });
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.GiamGia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("TEXT");

                    b.Property<int>("PhanTramGiamGia")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SanPhamId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SanPhamId");

                    b.ToTable("GiamGias");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.HoaDon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("KhachHangId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("NhanVienId")
                        .HasColumnType("TEXT");

                    b.Property<double>("No")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("KhachHangId");

                    b.HasIndex("NhanVienId");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.KeHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Cot")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Hang")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Ke")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SanPhamId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SanPhamId");

                    b.ToTable("KeHangs");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.KhachHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenKhachHang")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("KhachHangs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            Email = "",
                            IsActive = false,
                            SoDienThoai = "",
                            TenKhachHang = "Ko co khach hang"
                        },
                        new
                        {
                            Id = new Guid("7e3a16bf-ff86-4569-9f85-ae74990635de"),
                            Email = "klinh@email.com",
                            IsActive = false,
                            SoDienThoai = "450526781",
                            TenKhachHang = "Nguyễn Khánh Linh"
                        },
                        new
                        {
                            Id = new Guid("8b702d4f-a0b5-4615-a3a6-df2ddeeba7f7"),
                            Email = "ttan@email.com",
                            IsActive = false,
                            SoDienThoai = "798914772",
                            TenKhachHang = "Hoàng Thanh Tân"
                        },
                        new
                        {
                            Id = new Guid("1c2df9bb-1133-44a4-9e85-781032e8e43e"),
                            Email = "mhoang@email.com",
                            IsActive = false,
                            SoDienThoai = "455124139",
                            TenKhachHang = "Nguyễn Minh Hoàng"
                        },
                        new
                        {
                            Id = new Guid("668fed87-4abd-49c9-a414-78194421e705"),
                            Email = "lminh@email.com",
                            IsActive = false,
                            SoDienThoai = "162124841",
                            TenKhachHang = "Nguyễn Lê Minh"
                        },
                        new
                        {
                            Id = new Guid("4e463bff-8b71-4af9-97bb-f4b4af591632"),
                            Email = "ttin@email.com",
                            IsActive = false,
                            SoDienThoai = "737-02-8831",
                            TenKhachHang = "Nguyễn Trọng Tin"
                        });
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.LoSanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("NhaCungCapId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SanPhamId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SoLuong")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NhaCungCapId");

                    b.HasIndex("SanPhamId");

                    b.ToTable("LoSanPhams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bb7d6840-6114-4268-a675-84c7d226b804"),
                            NgayNhap = new DateTime(2020, 12, 27, 21, 47, 59, 195, DateTimeKind.Local).AddTicks(9081),
                            NhaCungCapId = new Guid("0ec1ab8f-8d70-409b-9b11-efb27284c4a0"),
                            SanPhamId = new Guid("75fbb1ed-bdd0-403c-8d24-e85d74e11945"),
                            SoLuong = 20
                        },
                        new
                        {
                            Id = new Guid("26e82286-7bae-43ae-bb3c-dd65c01e25a0"),
                            NgayNhap = new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9641),
                            NhaCungCapId = new Guid("0ec1ab8f-8d70-409b-9b11-efb27284c4a0"),
                            SanPhamId = new Guid("62e4e3d4-6534-4a95-b243-a81732f9a74e"),
                            SoLuong = 20
                        },
                        new
                        {
                            Id = new Guid("c12662ef-3752-44a1-ae48-1e0fc6902c3f"),
                            NgayNhap = new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9716),
                            NhaCungCapId = new Guid("02418cb3-ed16-469d-869b-37aead548c84"),
                            SanPhamId = new Guid("13e407fc-a55d-4c56-8f2a-85ea63a48523"),
                            SoLuong = 20
                        },
                        new
                        {
                            Id = new Guid("1a34815d-63b7-4679-824e-981eaa3720e7"),
                            NgayNhap = new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9721),
                            NhaCungCapId = new Guid("02418cb3-ed16-469d-869b-37aead548c84"),
                            SanPhamId = new Guid("d2646916-48aa-4e65-9974-3c8356681d0d"),
                            SoLuong = 20
                        },
                        new
                        {
                            Id = new Guid("e117ab27-0991-47fa-8b2d-e273a80bcefa"),
                            NgayNhap = new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9725),
                            NhaCungCapId = new Guid("fbc4aff7-1b71-4f29-9d04-6e5a2030cdc9"),
                            SanPhamId = new Guid("49edbe65-ddf6-44ad-8a62-78b45a530ee0"),
                            SoLuong = 20
                        },
                        new
                        {
                            Id = new Guid("ba933db5-5a7e-4f72-b5f9-c6ab4f0da73e"),
                            NgayNhap = new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9743),
                            NhaCungCapId = new Guid("fbc4aff7-1b71-4f29-9d04-6e5a2030cdc9"),
                            SanPhamId = new Guid("0113a4dc-2390-4ad1-b909-66f89e2352fb"),
                            SoLuong = 20
                        },
                        new
                        {
                            Id = new Guid("5e516ffc-4763-4f0d-817d-5b1bf17dc433"),
                            NgayNhap = new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9746),
                            NhaCungCapId = new Guid("03a9cf4f-6efa-480e-b3c8-c298298df715"),
                            SanPhamId = new Guid("ed6cb8d4-429a-4fb8-8291-4fc3fae8b74d"),
                            SoLuong = 20
                        },
                        new
                        {
                            Id = new Guid("45745215-a79b-4b62-bf43-b79ffaac3cd8"),
                            NgayNhap = new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9749),
                            NhaCungCapId = new Guid("03a9cf4f-6efa-480e-b3c8-c298298df715"),
                            SanPhamId = new Guid("8383c50d-9583-4d5b-a253-fe3f9199bf36"),
                            SoLuong = 20
                        },
                        new
                        {
                            Id = new Guid("297ba37c-db72-4c3a-9796-b84b6d575c5d"),
                            NgayNhap = new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9752),
                            NhaCungCapId = new Guid("ae5fc190-a606-4e3d-a96e-2c6dd22dacc1"),
                            SanPhamId = new Guid("9fac33d0-dae0-4d88-84f7-ea5bca2254b3"),
                            SoLuong = 20
                        },
                        new
                        {
                            Id = new Guid("00f44079-c173-40d3-a416-4a6dd86ed05a"),
                            NgayNhap = new DateTime(2020, 12, 27, 21, 47, 59, 196, DateTimeKind.Local).AddTicks(9755),
                            NhaCungCapId = new Guid("ae5fc190-a606-4e3d-a96e-2c6dd22dacc1"),
                            SanPhamId = new Guid("f57153a0-2f1f-4733-a332-97ee6961e4f3"),
                            SoLuong = 20
                        });
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.LoaiSanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenLoaiSanPham")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LoaiSanPhams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("347d242a-7028-4b64-9165-7fa0334050a9"),
                            TenLoaiSanPham = "Nước ngọt"
                        },
                        new
                        {
                            Id = new Guid("4f8976b6-770f-4c92-84aa-730d013ac187"),
                            TenLoaiSanPham = "Bánh kẹo"
                        },
                        new
                        {
                            Id = new Guid("f378b558-0e08-4db4-9d44-fd7efebc849e"),
                            TenLoaiSanPham = "Rau quả"
                        },
                        new
                        {
                            Id = new Guid("3482ac8c-9dea-4727-aa16-2ad90182457d"),
                            TenLoaiSanPham = "Thịt"
                        },
                        new
                        {
                            Id = new Guid("530293c4-bca8-4429-9df4-d0827c3a83b7"),
                            TenLoaiSanPham = "Sữa"
                        },
                        new
                        {
                            Id = new Guid("c02ac222-1ff5-42e0-8f7c-ae55e5bf8835"),
                            TenLoaiSanPham = "Đồ dùng gia dụng"
                        });
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.NhaCungCap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNhaCungCap")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThongTinLienHe")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NhaCungCaps");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ec1ab8f-8d70-409b-9b11-efb27284c4a0"),
                            TenNhaCungCap = "Topiczoom"
                        },
                        new
                        {
                            Id = new Guid("02418cb3-ed16-469d-869b-37aead548c84"),
                            TenNhaCungCap = "Thoughtmix"
                        },
                        new
                        {
                            Id = new Guid("fbc4aff7-1b71-4f29-9d04-6e5a2030cdc9"),
                            TenNhaCungCap = "Gigaclub"
                        },
                        new
                        {
                            Id = new Guid("03a9cf4f-6efa-480e-b3c8-c298298df715"),
                            TenNhaCungCap = "Vinder"
                        },
                        new
                        {
                            Id = new Guid("ae5fc190-a606-4e3d-a96e-2c6dd22dacc1"),
                            TenNhaCungCap = "Dynazzy"
                        });
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.NhanVien", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Matkhau")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenNhanVien")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NhanViens");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7b5c2d90-7798-4227-9f1c-637bb3a19bda"),
                            IsActive = false,
                            Matkhau = "admin",
                            TenNhanVien = "admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("741faa63-e6ac-4cce-b0c9-4676ba4d78fe"),
                            IsActive = false,
                            Matkhau = "123456",
                            TenNhanVien = "Đặng Quang Khải",
                            Username = "qkhai"
                        });
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.SanPham", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DonViSanPhamId")
                        .HasColumnType("TEXT");

                    b.Property<double>("GiaTien")
                        .HasColumnType("REAL");

                    b.Property<Guid>("LoaiSanPhamId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenSanPham")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DonViSanPhamId");

                    b.HasIndex("LoaiSanPhamId");

                    b.ToTable("SanPhams");

                    b.HasData(
                        new
                        {
                            Id = new Guid("75fbb1ed-bdd0-403c-8d24-e85d74e11945"),
                            DonViSanPhamId = new Guid("65e8e640-bee2-4772-9eec-811132d09c62"),
                            GiaTien = 10000.0,
                            LoaiSanPhamId = new Guid("f378b558-0e08-4db4-9d44-fd7efebc849e"),
                            TenSanPham = "Đậu xanh"
                        },
                        new
                        {
                            Id = new Guid("62e4e3d4-6534-4a95-b243-a81732f9a74e"),
                            DonViSanPhamId = new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"),
                            GiaTien = 13000.0,
                            LoaiSanPhamId = new Guid("f378b558-0e08-4db4-9d44-fd7efebc849e"),
                            TenSanPham = "Cà rốt"
                        },
                        new
                        {
                            Id = new Guid("13e407fc-a55d-4c56-8f2a-85ea63a48523"),
                            DonViSanPhamId = new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"),
                            GiaTien = 55000.0,
                            LoaiSanPhamId = new Guid("3482ac8c-9dea-4727-aa16-2ad90182457d"),
                            TenSanPham = "Thịt bằm"
                        },
                        new
                        {
                            Id = new Guid("d2646916-48aa-4e65-9974-3c8356681d0d"),
                            DonViSanPhamId = new Guid("3433f265-232d-4e0c-bcdd-91d4de6454ed"),
                            GiaTien = 40000.0,
                            LoaiSanPhamId = new Guid("3482ac8c-9dea-4727-aa16-2ad90182457d"),
                            TenSanPham = "Đùi gà góc tư"
                        },
                        new
                        {
                            Id = new Guid("49edbe65-ddf6-44ad-8a62-78b45a530ee0"),
                            DonViSanPhamId = new Guid("e56b3513-7b1d-4951-867b-8c7532390a7b"),
                            GiaTien = 20000.0,
                            LoaiSanPhamId = new Guid("347d242a-7028-4b64-9165-7fa0334050a9"),
                            TenSanPham = "Cocacola 1.5l"
                        },
                        new
                        {
                            Id = new Guid("0113a4dc-2390-4ad1-b909-66f89e2352fb"),
                            DonViSanPhamId = new Guid("e56b3513-7b1d-4951-867b-8c7532390a7b"),
                            GiaTien = 19000.0,
                            LoaiSanPhamId = new Guid("347d242a-7028-4b64-9165-7fa0334050a9"),
                            TenSanPham = "7Up 1.5l"
                        },
                        new
                        {
                            Id = new Guid("ed6cb8d4-429a-4fb8-8291-4fc3fae8b74d"),
                            DonViSanPhamId = new Guid("e56b3513-7b1d-4951-867b-8c7532390a7b"),
                            GiaTien = 24000.0,
                            LoaiSanPhamId = new Guid("530293c4-bca8-4429-9df4-d0827c3a83b7"),
                            TenSanPham = "Vinamilk 1l"
                        },
                        new
                        {
                            Id = new Guid("8383c50d-9583-4d5b-a253-fe3f9199bf36"),
                            DonViSanPhamId = new Guid("592657c2-c52f-4014-a671-e6483232de44"),
                            GiaTien = 80000.0,
                            LoaiSanPhamId = new Guid("4f8976b6-770f-4c92-84aa-730d013ac187"),
                            TenSanPham = "Bánh quy Danissa"
                        },
                        new
                        {
                            Id = new Guid("9fac33d0-dae0-4d88-84f7-ea5bca2254b3"),
                            DonViSanPhamId = new Guid("25e5bb3a-0bc8-4ec1-b0f2-388a69ae5b33"),
                            GiaTien = 45000.0,
                            LoaiSanPhamId = new Guid("c02ac222-1ff5-42e0-8f7c-ae55e5bf8835"),
                            TenSanPham = "Dao"
                        },
                        new
                        {
                            Id = new Guid("f57153a0-2f1f-4733-a332-97ee6961e4f3"),
                            DonViSanPhamId = new Guid("65e8e640-bee2-4772-9eec-811132d09c62"),
                            GiaTien = 47000.0,
                            LoaiSanPhamId = new Guid("c02ac222-1ff5-42e0-8f7c-ae55e5bf8835"),
                            TenSanPham = "Túi lọc nước"
                        });
                });

            modelBuilder.Entity("NhaCungCapSanPham", b =>
                {
                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.NhaCungCap", null)
                        .WithMany()
                        .HasForeignKey("NhaCungCapsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.SanPham", null)
                        .WithMany()
                        .HasForeignKey("SanPhamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.ChiTietHoaDon", b =>
                {
                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.HoaDon", "HoaDon")
                        .WithMany("ChiTietHoaDon")
                        .HasForeignKey("HoaDonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.LoSanPham", "LoSanPham")
                        .WithMany()
                        .HasForeignKey("LoSanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("LoSanPham");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.GiamGia", b =>
                {
                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.SanPham", "SanPham")
                        .WithMany("GiamGias")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.HoaDon", b =>
                {
                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.KhachHang", "KhachHang")
                        .WithMany("HoaDons")
                        .HasForeignKey("KhachHangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.NhanVien", "NhanVien")
                        .WithMany("HoaDons")
                        .HasForeignKey("NhanVienId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.KeHang", b =>
                {
                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.LoSanPham", b =>
                {
                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.NhaCungCap", "NhaCungCap")
                        .WithMany("LoSanPhams")
                        .HasForeignKey("NhaCungCapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.SanPham", "SanPham")
                        .WithMany("LoSanPhams")
                        .HasForeignKey("SanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaCungCap");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.SanPham", b =>
                {
                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.DonViSanPham", "DonViSanPham")
                        .WithMany("SanPhams")
                        .HasForeignKey("DonViSanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyCuaHangTienLoi.Data.Models.LoaiSanPham", "LoaiSanPham")
                        .WithMany("SanPhams")
                        .HasForeignKey("LoaiSanPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonViSanPham");

                    b.Navigation("LoaiSanPham");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.DonViSanPham", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.HoaDon", b =>
                {
                    b.Navigation("ChiTietHoaDon");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.KhachHang", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.LoaiSanPham", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.NhaCungCap", b =>
                {
                    b.Navigation("LoSanPhams");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.NhanVien", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("QuanLyCuaHangTienLoi.Data.Models.SanPham", b =>
                {
                    b.Navigation("GiamGias");

                    b.Navigation("LoSanPhams");
                });
#pragma warning restore 612, 618
        }
    }
}