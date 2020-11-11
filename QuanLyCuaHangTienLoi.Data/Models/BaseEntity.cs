using LiteDB;

using System;

namespace QuanLyCuaHangTienLoi.Data.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = ObjectId.NewObjectId();
        }

        [BsonId]
        public ObjectId Id { get; set; }
    }
}
