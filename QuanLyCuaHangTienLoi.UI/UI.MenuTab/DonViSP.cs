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
    public partial class DonViSP : Form
    {
        SqlConnection connect = ClassKetnoi.connect;
        //SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-A0E9NLI\MSSQLSERVER2019;Initial Catalog=doan-3;Integrated Security=True");
        public DonViSP()
        {
            InitializeComponent();
            autoidSPLoai();
            gridviewsp();
        }
        private void autoidSPLoai()
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(IDdonvi) from donvisp", connect);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            i++;
            textBoxID.Text = i.ToString();

        }
        private void clear()
        {
            textBoxTenDV.Clear();

        }
        private void gridviewsp()
        {
            string querydv = @"select IDdonvi as 'ID đơn vị', TenDonvi as 'Tên đơn vị' from donvisp";
            SqlDataAdapter sqldatasp = new SqlDataAdapter(querydv, connect);
            DataTable datatbdv = new DataTable();
            sqldatasp.Fill(datatbdv);
            dataGridViewDVsp.DataSource = datatbdv;
            connect.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
            autoidSPLoai();
        }

        private void dataGridViewDVsp_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
            if (dataGridViewDVsp.CurrentRow.Index != -1)
            {
                textBoxID.Text = dataGridViewDVsp.CurrentRow.Cells[0].Value.ToString();
                textBoxTenDV.Text = dataGridViewDVsp.CurrentRow.Cells[1].Value.ToString();
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
                    using (var cmd = new SqlCommand("update donvisp set TenDonVi=@TenDonvi where IDdonvi=@IDdonvi"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@IDdonvi", textBoxID.Text);
                        cmd.Parameters.AddWithValue("@TenDonvi", textBoxTenDV.Text);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã lựu");
                            connect.Close();
                            clear();
                            gridviewsp();
                            autoidSPLoai();
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
                    using (var cmd = new SqlCommand("delete donvisp where IDdonvi=@IDdonvi"))
                    {
                        cmd.Connection = connect;
                        cmd.Parameters.AddWithValue("@IDdonvi", textBoxID.Text);
                        connect.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Đã xóa");
                            connect.Close();
                            clear();
                            gridviewsp();
                            autoidSPLoai();
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
                    MessageBox.Show("Error during delete: " + ex.Message);
                }

            }
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
                using (var cmd = new SqlCommand("INSERT INTO donvisp (IDdonvi,TenDonvi) VALUES (@IDdonvi,@TenDonvi)"))
                {
                    cmd.Connection = connect;
                    cmd.Parameters.AddWithValue("@IDdonvi", textBoxID.Text);
                    cmd.Parameters.AddWithValue("@TenDonvi", textBoxTenDV.Text);

                    connect.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã thêm");
                        connect.Close();
                        clear();
                        gridviewsp();
                        autoidSPLoai();
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công!");
                        connect.Close();
                    }
                    connect.Close();

                }
            }

        }

    }
}
