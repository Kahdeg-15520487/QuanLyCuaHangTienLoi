using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    public partial class LoaiSP : Form
    {
        SqlConnection connect = ClassKetnoi.connect;
        //SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-A0E9NLI\MSSQLSERVER2019;Initial Catalog=doan-3;Integrated Security=True");

        public LoaiSP()
        {
            InitializeComponent();

        }
        private void autoidSPLoai()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(IDloai) from loaisp", connect);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            i++;
            textBoxID.Text = i.ToString();
            connect.Close();
        }
        private void clear()
        {
            textBoxTenLoai.Clear();
            textBoxID.Clear();
        }
        private void gridviewsploai()
        {
            connect.Open();
            string querysploai = @"select IDloai as 'Mã loại', TenLoai as 'Tên loại' from loaisp";
            SqlDataAdapter sqldatasp = new SqlDataAdapter(querysploai, connect);
            DataTable datatbsploai = new DataTable();
            sqldatasp.Fill(datatbsploai);
            dataGridViewLoaiSPloai.DataSource = datatbsploai;
            connect.Close();
        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            clear();
            autoidSPLoai();
        }

        private void dataGridViewLoaiSP_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewLoaiSPloai.CurrentRow.Index != -1)
            {
                clear();
                textBoxID.Text = dataGridViewLoaiSPloai.CurrentRow.Cells[0].Value.ToString();
                textBoxTenLoai.Text = dataGridViewLoaiSPloai.CurrentRow.Cells[1].Value.ToString();
                // lam toi day roi ne
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {
                try
                {
                    connect.Open();
                    using (var cmd = new SqlCommand("update loaisp set TenLoai=@TenLoai where IDloai=@IDloai"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@IDloai", textBoxID.Text);
                        cmd.Parameters.AddWithValue("@TenLoai", textBoxTenLoai.Text);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã lựu");
                            connect.Close();
                            gridviewsploai();
                        }
                        else
                        {
                            MessageBox.Show("Lưu không thành công!");
                            connect.Close();
                        }
                        connect.Close();
                    }
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show("Error during update: " + ex.Message);
                }
            }
            clear();
            autoidSPLoai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("Thông tin trống!");
            }
            else
            {


                try
                {
                    using (var cmd = new SqlCommand("delete loaisp where IDloai=@IDloai"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@IDloai", textBoxID.Text);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã xóa");
                            connect.Close();
                            clear();
                            gridviewsploai();
                            
                        }
                        else
                        {
                            MessageBox.Show("Lưu không thành công!");
                        }
                        connect.Close();
                    }
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show("Error during delete: " + ex.Message);
                }

            }
            clear();
            autoidSPLoai(); 
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxID.Text))
            {
                MessageBox.Show("Trống mã loại!");
                textBoxID.Select();
            }
            else
            {
                using (var cmd = new SqlCommand("INSERT INTO loaisp (IDloai,TenLoai) VALUES (@IDloai,@TenLoai)"))
                {
                    cmd.Connection = connect;
                    cmd.Parameters.AddWithValue("@IDloai", textBoxID.Text);
                    cmd.Parameters.AddWithValue("@TenLoai", textBoxTenLoai.Text);

                    connect.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã thêm");
                        connect.Close();
                        clear();
                        gridviewsploai();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công!");
                        connect.Close();
                    }
                    connect.Close();

                }
            }
            autoidSPLoai();
        }


        private void LoaiSP_Load(object sender, EventArgs e)
        {
            autoidSPLoai();
            gridviewsploai();
        }
    }
}
