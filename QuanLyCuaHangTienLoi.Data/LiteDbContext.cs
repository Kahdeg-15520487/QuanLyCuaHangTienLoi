using LiteDB;

using Microsoft.Extensions.Options;

using QuanLyCuaHangTienLoi.Data.Models;

using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace QuanLyCuaHangTienLoi.Data
{
    public class LiteDbConfig
    {
        public string ConnectionString { get; set; }
    }
    public class LiteDbContext
    {
        public readonly ILiteDatabase Context;
        public LiteDbContext(IOptions<LiteDbConfig> configs)
        {
            try
            {
                LiteDatabase db = new LiteDatabase(configs.Value.ConnectionString);
                if (db != null)
                {
                    Context = db;
                    StringBuilder sb = new StringBuilder();
                    foreach (string collectionName in db.GetCollectionNames())
                    {
                        sb.AppendLine("=====");
                        sb.AppendLine(collectionName);
                        sb.AppendLine(JsonSerializer.Serialize(new BsonArray(db.GetCollection(collectionName).FindAll())));
                        sb.AppendLine("=====");
                    }

                    ConfigureMapper();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }

        public LiteDbContext(string connectionString)
        {
            try
            {
                LiteDatabase db = new LiteDatabase(connectionString);
                if (db != null)
                {
                    Context = db;
                    StringBuilder sb = new StringBuilder();
                    foreach (string collectionName in db.GetCollectionNames())
                    {
                        sb.AppendLine("=====");
                        sb.AppendLine(collectionName);
                        sb.AppendLine(JsonSerializer.Serialize(new BsonArray(db.GetCollection(collectionName).FindAll())));
                        sb.AppendLine("=====");
                    }

                    ConfigureMapper();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }

        private void ConfigureMapper()
        {
            BsonMapper mapper = BsonMapper.Global;

            mapper.Entity<SanPham>()
                  .DbRef(x => x.LoaiSanPhams, "loaisanphams")
                  .DbRef(x => x.LoSanPhams, "losanphams")
                  .DbRef(x => x.NhaCungCap, "nhacungcaps");

            mapper.Entity<LoSanPham>()
                  .DbRef(x => x.NhaCungCap, "nhacungcaps");

        }
    }
}
