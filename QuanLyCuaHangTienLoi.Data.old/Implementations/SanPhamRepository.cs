using LiteDB;

using QuanLyCuaHangTienLoi.Data.Interfaces;
using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Implementations
{
    public class SanPhamRepository : BaseRepository<SanPham>, IBaseRepository<SanPham>
    {
        public SanPhamRepository(LiteDbContext db) : base(db)
        {
        }

        internal override ILiteCollection<SanPham> ResolveInclude()
        {
            return base.ResolveInclude().Include(x => x.LoaiSanPhams)
                                        .Include(x => x.LoSanPhams)
                                        .Include(x => x.NhaCungCap);
        }
    }
}
