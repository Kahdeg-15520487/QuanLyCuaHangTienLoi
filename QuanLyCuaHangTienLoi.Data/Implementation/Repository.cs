using Microsoft.EntityFrameworkCore;

using QuanLyCuaHangTienLoi.Data.Interface;
using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Implementation
{
    public class Repository<T> : IRepository<T> where T : class, BaseEntity
    {
        private readonly CuaHangTienLoiDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(CuaHangTienLoiDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return entities.AsQueryable();
        }
        public T Get(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return entities.Where(filter);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
