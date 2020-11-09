using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangTienLoi.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data
{
    public class MainDbContext : DbContext
    {
        public DbSet<SanPham> SanPhams  { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<LoSanPham> LoSanPhams { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=chtl.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
