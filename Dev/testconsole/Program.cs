using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;

using System;

namespace testconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var contextOptions = new DbContextOptionsBuilder<CuaHangTienLoiDbContext>()
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=chtl;Integrated Security=True")
                .Options;

            CuaHangTienLoiDbContext context = new CuaHangTienLoiDbContext();

            Repository<SanPham> spRepo = new Repository<SanPham>(context);

            Console.WriteLine(JsonConvert.SerializeObject(spRepo.GetAll().Include(sp => sp.LoaiSanPham), Formatting.Indented));

            Console.ReadLine();
        }
    }
}
