using QuanLyCuaHangTienLoi.UI.Utilities;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI
{
    public static class ExtensionMethod
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            return ToDataTable(data.ToList());
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                var name = (prop.Attributes[typeof(CollumNameAttribute)] as CollumNameAttribute)?.CollumName ?? prop.Name;
                table.Columns.Add(name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    var name = (prop.Attributes[typeof(CollumNameAttribute)] as CollumNameAttribute)?.CollumName ?? prop.Name;
                    row[name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
