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
            string cs = null;
            try
            {
                cs = File.ReadAllText("cs.config");
                if (string.IsNullOrWhiteSpace(cs))
                {
                    cs = DefaultConnectionString;
                }
            }
            catch (Exception)
            {
                cs = DefaultConnectionString;
            }


            contextOptions = new DbContextOptionsBuilder<CuaHangTienLoiDbContext>().UseSqlite(cs).Options;
        }
        //public static readonly string DefaultConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=chtl;Integrated Security=True";
        public static readonly string DefaultConnectionString = $"Data Source={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "chtl.db")}";
        public static DbContextOptions<CuaHangTienLoiDbContext> contextOptions = null;
    }
}
