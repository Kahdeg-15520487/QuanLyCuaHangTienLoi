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


namespace QuanLyCuaHangTienLoi.UI
{
    public partial class DangNhap : Form
    {
        public static string usernv = "";
        SqlConnection connect = ClassKetnoi.connect;
        // SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-A0E9NLI\MSSQLSERVER2019;Initial Catalog=doan-3;Integrated Security=True");
        public DangNhap()
        {
            InitializeComponent();
            // txtuser.SelectionStart = 0;
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
            string querynv = "Select * From nhanvien where usernv ='" + txtuser.Text + "' and passnv='" + txtpass.Text + "' ";
            SqlDataAdapter sqldata = new SqlDataAdapter(querynv, connect);
            DataTable datatb1 = new DataTable();
            sqldata.Fill(datatb1);
            if (datatb1.Rows.Count == 1)
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
