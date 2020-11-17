using LiteDB;

using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace QuanLyCuaHangTienLoi.Data.Interfaces
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(ObjectId id);
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
        ObjectId Save(T document);
        void Delete(T document);
    }
}
