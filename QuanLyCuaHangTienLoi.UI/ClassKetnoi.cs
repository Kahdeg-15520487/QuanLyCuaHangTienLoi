using Microsoft.EntityFrameworkCore;

using QuanLyCuaHangTienLoi.Data;

using System.Data.SqlClient;

namespace QuanLyCuaHangTienLoi.UI
{
    class ClassKetnoi
    {
        public static readonly DbContextOptions<CuaHangTienLoiDbContext> contextOptions = new DbContextOptionsBuilder<CuaHangTienLoiDbContext>().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=chtl;Integrated Security=True").Options;
        internal static SqlConnection connect;
    }
}
