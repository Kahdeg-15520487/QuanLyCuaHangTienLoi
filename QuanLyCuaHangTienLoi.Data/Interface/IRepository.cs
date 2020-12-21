using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QuanLyCuaHangTienLoi.Data.Interface
{
    public interface IRepository<T> where T : class, BaseEntity
    {
        IQueryable<T> GetAll();
        T Get(Guid id);
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
