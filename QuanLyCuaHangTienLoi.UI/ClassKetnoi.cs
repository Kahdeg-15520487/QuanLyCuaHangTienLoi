using Microsoft.EntityFrameworkCore;

using QuanLyCuaHangTienLoi.Data;
using System;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyCuaHangTienLoi.UI
{
    class ClassKetnoi
    {
        public static void GetConnectionString()
        {
            try
            {
                var cs = File.ReadAllText("cs.config");
                if (!string.IsNullOrWhiteSpace(cs))
                {
                    contextOptions = new DbContextOptionsBuilder<CuaHangTienLoiDbContext>().UseSqlServer(cs).Options;
                }
                else
                {
                    contextOptions = new DbContextOptionsBuilder<CuaHangTienLoiDbContext>().UseSqlServer(DefaultConnectionString).Options;
                }
            }
            catch (Exception)
            {
                contextOptions = new DbContextOptionsBuilder<CuaHangTienLoiDbContext>().UseSqlServer(DefaultConnectionString).Options;
            }
        }
        public static readonly string DefaultConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=chtl;Integrated Security=True";
        public static DbContextOptions<CuaHangTienLoiDbContext> contextOptions = null;
    }
}
