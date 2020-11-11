using LiteDB;

using QuanLyCuaHangTienLoi.Data.Interfaces;
using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ILiteDatabase db;

        public BaseRepository(LiteDbContext db)
        {
            this.db = db.Context;
        }

        internal virtual ILiteCollection<T> ResolveInclude()
        {
            return db.GetCollection<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            ILiteCollection<T> collection = ResolveInclude();
            return collection.FindAll().ToList();
        }

        public virtual T Get(ObjectId id)
        {
            ILiteCollection<T> collection = ResolveInclude();
            T get = collection.FindOne(x => x.Id == id);
            return get;
        }

        public virtual IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return this.GetAll().AsQueryable().Where(predicate);
        }

        public virtual ObjectId Save(T document)
        {
            if (!db.BeginTrans())
            {
                throw new Exception("Already in a transaction");
            }
            ILiteCollection<T> collection = ResolveInclude();
            ObjectId result = null;

            if (!collection.Exists(x => x.Id == document.Id))
            {
                result = collection.Insert(document);
            }
            else
            {
                collection.Update(document);
                result = document.Id;
            }
            db.Commit();
            return result;
        }

        public virtual void Delete(T document)
        {
            ILiteCollection<T> collection = ResolveInclude();
            collection.DeleteMany(x => x.Id == document.Id);
        }
    }
}
