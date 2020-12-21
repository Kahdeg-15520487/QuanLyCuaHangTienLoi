using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using QuanLyCuaHangTienLoi.UI.MenuTab;
using System.Data.SqlClient;
using System.IO;

namespace QuanLyCuaHangTienLoi.UI
{
    public partial class CuaSoChinh : Form
    {
        SqlConnection connect = ClassKetnoi.connect;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader rdr;

        private IconButton currentbtn;
        private Panel lefborderbtn;
        private Form currentchildform;

        public static string tennv = "";

        private List<IconButton> iconButtons;

        public CuaSoChinh()
        {
            InitializeComponent();
            lefborderbtn = new Panel();
            lefborderbtn.Size = new Size(7, 50);
            PanelMenu.Controls.Add(lefborderbtn);
            timer1.Start();//dong ho

            iconButtons = new List<IconButton>()
            {
                this.btndashboard,
                this.btnhome,
                this.btnDonHang,
                this.btnNhapKho,
                this.btnTonKho,
            };
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(145, 151, 154);

        }

        private void ActivateButton(object senderbtn, Color color)
        {
            if (senderbtn != null)
            {
                DisableButton();
                //button
                currentbtn = (IconButton)senderbtn;
                currentbtn.BackColor = Color.FromArgb(37, 36, 81);
                currentbtn.ForeColor = color;
                currentbtn.TextAlign = ContentAlignment.MiddleCenter;
                currentbtn.IconColor = color;
                currentbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentbtn.ImageAlign = ContentAlignment.MiddleRight;

                //left border btn
                lefborderbtn.BackColor = color;
                lefborderbtn.Location = new Point(0, currentbtn.Location.Y);
                lefborderbtn.Visible = true;
                lefborderbtn.BringToFront();

                //icon small
                iconmenusmall.IconChar = currentbtn.IconChar;
                iconmenusmall.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentbtn != null)
            {
                DisableButton(currentbtn);
            }
        }

        private void DisableButton(IconButton button)
        {
            button.BackColor = Color.FromArgb(40, 60, 70);
            button.ForeColor = Color.Gainsboro;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.IconColor = Color.Gainsboro;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
            button.ImageAlign = ContentAlignment.MiddleLeft;
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentchildform != null)
            {
                currentchildform.Close();

            }
            currentchildform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            paneltrangcon.Controls.Add(childForm);
            paneltrangcon.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelcon.Text = childForm.Text;
        }
        private void btnhome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new BanHang());
        }

        private void btndonhang_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new DonHang());
        }

        private void btnsanpham_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);

        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            //motrangcon(new Dashboard());
            MessageBox.Show("Chức năng này chưa được hoàn thành!");
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new SanPham());
        }

        private void btnluong_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new tonkho());
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            this.DialogResult = DialogResult.OK;
        }

        private void Reset()
        {
            this.iconButtons.ForEach(DisableButton);
            lefborderbtn.Visible = false;
            iconmenusmall.IconChar = IconChar.Home;
            iconmenusmall.IconColor = Color.Gainsboro;
            labelcon.Text = "Home";
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitlebar_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            currentchildform.Close();
            Reset();
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconZoom_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }

        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            PanelDropDownSP.Height = 50;
            try
            {
                //todo db nhan vien
                connect.Open();
                cmd.CommandText = "select usernv,tennv from nhanvien where usernv='" + DangNhap.usernv + "'";
                cmd.Connection = connect;
                rdr = cmd.ExecuteReader();
                bool temp = false;
                while (rdr.Read())
                {
                    LabelUser.Text = rdr.GetString(1);
                    tennv = rdr.GetString(1);
                    temp = true;
                }
                if (temp == false)
                    MessageBox.Show("not found");
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // hien thi logo
            try
            {
                //todo db logo
                SqlCommand command;
                string sqllogo = "select logo from ThongTinShop where ID=1 ";
                if (connect.State != ConnectionState.Open)
                    connect.Open();
                command = new SqlCommand(sqllogo, connect);
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                if (reader.HasRows)
                {
                    byte[] img = (byte[])(reader[0]);
                    //if (img == null)
                    //{
                    //    picLogo.Image = null;
                    //}
                    //else
                    //{
                    //    MemoryStream ms = new MemoryStream(img);
                    //    picLogo.Image = Image.FromStream(ms);

                    //}
                    connect.Close();
                }
                else
                {
                    connect.Close();
                    MessageBox.Show("bi loi");
                }

            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show("loi logo: " + ex.Message);
            }
        }

        private void iconButtonSP_Click(object sender, EventArgs e)
        {
            if (PanelDropDownSP.Height == 200)
            {
                PanelDropDownSP.Height = 50;
            }
            else
            {
                PanelDropDownSP.Height = 200;
            }
        }

        private void iconButtonSPLoai_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LoaiSP());
        }

        private void iconButtonSPDonvi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DonViSP());
        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Setting());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.lbDateTime.Text = datetime.ToString("dd/MM/yyyy HH:mm:ss");
            this.labelGioBig.Text = datetime.ToString("HH:mm:ss");
            this.lbNgayThangBig.Text = datetime.ToString("dd/MM/yyyy");
            this.lbDateBig.Text = datetime.ToString("dddd");
        }

        private void iconmenusmall_Click(object sender, EventArgs e)
        {
            currentchildform?.Close();
            Reset();
        }

        private void PanelLogo_Click(object sender, EventArgs e)
        {
            currentchildform?.Close();
            Reset();
        }
    }
}
