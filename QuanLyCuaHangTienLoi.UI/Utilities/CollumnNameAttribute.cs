using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyCuaHangTienLoi.UI.Utilities
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class CollumNameAttribute : Attribute
    {
        readonly string collumName;

        // This is a positional argument
        public CollumNameAttribute(string collumName)
        {
            this.collumName = collumName;
        }

        public string CollumName
        {
            get { return collumName; }
        }
    }
}
