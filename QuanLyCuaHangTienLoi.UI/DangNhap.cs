using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;

namespace QuanLyCuaHangTienLoi.UI
{
    public partial class DangNhap : Form
    {
        public static string usernv = "";
        public DangNhap()
        {
            InitializeComponent();
            // txtuser.SelectionStart = 0;

            //dump database
            //string[] tables = new string[]
            //{
            //    "donvisp",
            //    "HoaDon",
            //    "KhachHang",
            //    "loaisp",
            //    "nhanvien",
            //    "nhapkho",
            //    "ThongTinShop",
            //    "tonkho"
            //};

            //foreach (var t in tables)
            //{
            //    using (var cmd = new SqlCommand("select * from " + t))
            //    {
            //        cmd.Connection = connect;
            //        connect.Open();

            //        using (var dataReader = cmd.ExecuteReader())
            //        {
            //            var dt = new DataTable();
            //            dt.Load(dataReader);
            //            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            //            Dictionary<string, object> row;
            //            foreach (DataRow dataRow in dt.Rows)
            //            {
            //                row = new Dictionary<string, object>();
            //                foreach (DataColumn col in dt.Columns)
            //                {
            //                    row.Add(col.ColumnName, dataRow[col]);
            //                }
            //                rows.Add(row);
            //            }
            //            var serialized = JsonConvert.SerializeObject(rows, Formatting.Indented);
            //            File.WriteAllText(t + ".txt", serialized);
            //        }

            //        connect.Close();
            //    }
            //}

            //Console.WriteLine();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlCommand command;
            //    string sqllogo = "select logo from ThongTinShop where ID=1 ";
            //    if (connect.State != ConnectionState.Open)
            //        connect.Open();
            //    command = new SqlCommand(sqllogo, connect);
            //    SqlDataReader reader = command.ExecuteReader();

            //    reader.Read();
            //    if (reader.HasRows)
            //    {
            //        byte[] img = (byte[])(reader[0]);
            //        if (img == null)
            //        {
            //            pictureBox2.Image = null;
            //        }
            //        else
            //        {
            //            MemoryStream ms = new MemoryStream(img);
            //            pictureBox2.Image = Image.FromStream(ms);

            //        }
            //        //  MessageBox.Show(img.ToString());
            //        connect.Close();
            //    }
            //    else
            //    {
            //        connect.Close();
            //        MessageBox.Show("bi loi");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    connect.Close();
            //    MessageBox.Show("loi logo: " + ex.Message);
            //}
        }

        private void txtuser_Click(object sender, EventArgs e)
        {
            txtuser.Clear();

        }

        private void txtpass_Click(object sender, EventArgs e)
        {
            txtpass.Clear();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbmini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            usernv = txtuser.Text;
            bool isValid = false;
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<NhanVien> repo = new Repository<NhanVien>(dbCxt);
                isValid = repo.Query(nv => nv.Username == txtuser.Text && nv.Matkhau == txtpass.Text) != null;
            }

            if (isValid)
            {
                CuaSoChinh mainmenu = new CuaSoChinh();
                this.Hide();
                mainmenu.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}
