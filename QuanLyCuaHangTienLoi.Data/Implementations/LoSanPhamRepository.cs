using LiteDB;

using QuanLyCuaHangTienLoi.Data.Interfaces;
using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Implementations
{
    public class LoSanPhamRepository : BaseRepository<LoSanPham>, IBaseRepository<LoSanPham>
    {
        public LoSanPhamRepository(LiteDbContext db) : base(db)
        {
        }

        internal override ILiteCollection<LoSanPham> ResolveInclude()
        {
            return base.ResolveInclude().Include(x => x.NhaCungCap);
        }
    }
}
