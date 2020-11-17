using QuanLyCuaHangTienLoi.UI.MenuTab;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangTienLoi.UI
{
    class ClassKetnoi
    {
       public static SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=doan-3;Integrated Security=True");

    }
}
