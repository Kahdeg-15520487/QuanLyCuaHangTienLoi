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
using System.Text.RegularExpressions;
using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangTienLoi.UI.Utilities;

using AdvancedSockets.WebSockets;
using Newtonsoft.Json;

namespace QuanLyCuaHangTienLoi.UI.MenuTab
{
    public partial class BanHang : Form
    {
        public static string thanhtoan = "";//nut Tính tiền chuyển tạm thời cho form TT
        public static string SDT = "";
        public static Guid MaKH = Constants.DefaultUser;
        public static string TenKH = "";

        int checkslsp;
        int indexRow = 0;
        string maspedit;
        int slspedit;
        string masp1;
        int slsp1;
        public static WebSocketClient client;

        public BanHang()
        {
            InitializeComponent();
            InitWebsocket();
        }

        public void InitWebsocket()
        {
            if (client != null)
            {
                return;
            }
            var url = new Uri("ws://157.245.49.108:5100/push");

            client = new WebSocketClient();
            client.OnConnect += () =>
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Connected");

                client.Send(Encoding.ASCII.GetBytes("2"));
            };
            client.OnDisconnect += () =>
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Disconnected");
            };
            client.OnMessage += (message) =>
            {
                var raw = Encoding.ASCII.GetString(message);
                Console.WriteLine(raw);
                var task = JsonConvert.DeserializeObject<MqMsg>(raw);
                Guid.TryParse(task.TaskData, out Guid scannedId);

                if (!(CuaSoChinh.currentchildform is BanHang))
                {
                    return;
                }

                (CuaSoChinh.currentchildform as BanHang).Invoke((MethodInvoker)delegate { (CuaSoChinh.currentchildform as BanHang).DisplayScaned(scannedId); });
            };
            client.OnError += (string error, Exception ex) =>
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(error);

                if (ex != null)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            };
            client.Connect(url);
        }

        public void DisplayScaned(Guid scannedId)
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<Data.Models.LoSanPham> lspRepo = new Repository<Data.Models.LoSanPham>(dbCxt);
                var loSanPham = lspRepo.Query(lsp => lsp.SanPhamId == scannedId && lsp.SoLuong > 0)
                    .Include(lsp => lsp.SanPham)
                    .ThenInclude(sp => sp.LoaiSanPham)
                    .Include(lsp => lsp.SanPham)
                    .ThenInclude(sp => sp.DonViSanPham)
                    .FirstOrDefault();

                if (loSanPham == null)
                {
                    MessageBox.Show("Sản phẩm ko có trong kho");
                    return;
                }

                Repository<GiamGia> ggRepo = new Repository<GiamGia>(dbCxt);
                var gg = ggRepo.Query(gg => gg.SanPhamId == loSanPham.SanPhamId && gg.NgayBatDau < DateTime.Now && gg.NgayKetThuc > DateTime.Now).FirstOrDefault();
                int phanTramGiamGia = 0;
                if (gg == null)
                {
                    phanTramGiamGia = 0;
                }
                else
                {
                    phanTramGiamGia = gg.PhanTramGiamGia;
                }

                checkslsp = loSanPham.SoLuong;
                if (checkslsp < 1)
                {
                    MessageBox.Show("het hang");
                }
                else
                {
                    bool isSame = txtmasp.Text == loSanPham.SanPhamId.ToString();

                    txtmasp.Text = loSanPham.SanPhamId.ToString();
                    txttensp.Text = loSanPham.SanPham.TenSanPham;
                    txtdongiasp.Text = loSanPham.SanPham.GiaTien.ToString();
                    txtsoluongsp.Text = (isSame ? int.Parse(txtsoluongsp.Text) + 1 : 1).ToString();
                    txtgiamphantramsp.Text = phanTramGiamGia.ToString();
                    comboBoxdonvisp.Text = loSanPham.SanPham.LoaiSanPham.TenLoaiSanPham.ToString();
                    comboBoxloaisp.Text = loSanPham.SanPham.DonViSanPham.TenDonViSanPham.ToString();
                    //thanhtiensp = soluong * don gia
                    double slsp;
                    double dongiasp;
                    double thanhtiensp;
                    double thanhtiensp2;
                    slsp = double.Parse(txtsoluongsp.Text);
                    dongiasp = double.Parse(txtdongiasp.Text);

                    thanhtiensp = slsp * dongiasp;
                    //tien giam gia cua san pham
                    double giamgiaPhantram = double.Parse(txtgiamphantramsp.Text);
                    double giamgiasp = (giamgiaPhantram * thanhtiensp) / 100;
                    //tien san pham = (so luong * don gia ) - giam gia
                    thanhtiensp2 = thanhtiensp - giamgiasp;

                    txttiensp.Text = string.Format("{0:N2}", thanhtiensp2);
                }
            }
        }

        public void clearsp()
        {
            txtmasp.Clear();
            txttensp.Clear();
            txtsoluongsp.Clear();
            txtdongiasp.Clear();
            txtgiamphantramsp.Clear();
            txttiensp.Clear();
            comboBoxdonvisp.SelectedItem = null;
            comboBoxdonvisp.Text = null;
            comboBoxloaisp.Text = null;
        }

        public void huyhd()
        {
            txtsdhKh.Clear();
            txtTenKh.Clear();
            txtmasp.Clear();
            txttensp.Clear();
            txtsoluongsp.Clear();
            txtdongiasp.Clear();
            txtgiamphantramsp.Clear();
            txttiensp.Clear();
            comboBoxdonvisp.SelectedItem = null;
            comboBoxdonvisp.Text = null;
            txttongcongtiensp.Clear();
            txtgiamtientong.Clear();
            txtgiamphantramtong.Clear();
            txtthanhtoan.Clear();
            txtcongtientong.Clear();
            txtcongphantramtong.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void UpdateSum()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txttongcongtiensp.Text = string.Format("{0:N2}", sum);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            bool found = false;
            if (string.IsNullOrWhiteSpace(txtmasp.Text))
            {
                return;
            }

            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<LoSanPham> repo = new Repository<LoSanPham>(dbCxt);
                LoSanPham lsp = repo.Query(lsp => lsp.SanPhamId == Guid.Parse(txtmasp.Text) && lsp.SoLuong > 0).FirstOrDefault();
                if (lsp == null)
                {
                    MessageBox.Show("Sản phẩm không tồn tại hoặc đã hết hàng.");
                    return;
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToString(row.Cells[0].Value) == txtmasp.Text)
                        {
                            //neu them san pham giong nhau se cộng dồn số lượng và tiền vào ô
                            row.Cells[2].Value = (int.Parse(txtsoluongsp.Text) + Convert.ToInt16(row.Cells[2].Value.ToString()));
                            row.Cells[4].Value = (double.Parse(txttiensp.Text) + Convert.ToDouble(row.Cells[4].Value.ToString()));
                            found = true;
                            /////////////////////
                        }
                    }
                    if (!found)
                    {
                        dataGridView1.Rows.Add(txtmasp.Text, txttensp.Text, txtsoluongsp.Text, txtdongiasp.Text, txttiensp.Text, comboBoxdonvisp.Text, comboBoxloaisp.Text, txtgiamphantramsp.Text, lsp.Id);
                    }
                }
                else
                {
                    var ii = dataGridView1.Rows.Add(txtmasp.Text, txttensp.Text, txtsoluongsp.Text, txtdongiasp.Text, txttiensp.Text, comboBoxdonvisp.Text, comboBoxloaisp.Text, txtgiamphantramsp.Text, lsp.Id);
                    var tt = dataGridView1.Rows[ii];
                }
            }

            UpdateSum();
            clearsp();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            {
                Repository<LoSanPham> repo = new Repository<LoSanPham>(dbCxt);
                if (!Guid.TryParse(txtmasp.Text, out Guid masp))
                {
                    return;
                }
                LoSanPham lsp = repo.Query(lsp => lsp.SanPhamId == masp && lsp.SoLuong > 0).FirstOrDefault();
                if (lsp == null)
                {
                    MessageBox.Show("Sản phẩm không tồn tại hoặc đã hết hàng.");
                    return;
                }


                if (dataGridView1.Rows.Count == 0)
                {
                    return;
                }

                DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
                newDataRow.Cells[0].Value = txtmasp.Text;
                newDataRow.Cells[1].Value = txttensp.Text;
                newDataRow.Cells[2].Value = txtsoluongsp.Text;
                newDataRow.Cells[3].Value = txtdongiasp.Text;
                newDataRow.Cells[4].Value = txttiensp.Text;
                newDataRow.Cells[5].Value = comboBoxdonvisp.Text;
                newDataRow.Cells[6].Value = comboBoxloaisp.Text;
                newDataRow.Cells[8].Value = lsp.Id;
            }
            UpdateSum();
            clearsp();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                DataGridViewRow row = dataGridView1.Rows[item.Index];
                masp1 = row.Cells[0].Value.ToString();
                slsp1 = Convert.ToInt32(row.Cells[2].Value.ToString());
                dataGridView1.Rows.RemoveAt(item.Index); //remove row in datagridview
            }

            for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
            {
                int rowIndex = dataGridView1.SelectedCells[i].RowIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                masp1 = row.Cells[0].Value.ToString();
                dataGridView1.Rows.RemoveAt(rowIndex); //remove row in datagridview
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            clearsp();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                clearsp();

                indexRow = dataGridView1.CurrentRow.Index;

                txtmasp.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txttensp.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtsoluongsp.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtdongiasp.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txttiensp.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

                comboBoxdonvisp.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBoxloaisp.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtgiamphantramsp.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                maspedit = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                slspedit = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            }
            else
            {
                MessageBox.Show("No data!");
            }
        }

        private void txttongcongtiensp_TextChanged(object sender, EventArgs e)
        {
            txtthanhtoan.Text = txttongcongtiensp.Text;
        }

        private void txtgiamtientong_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtgiamtientong.Text))
            {
                return;
            }
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn trống!");
                txtgiamtientong.Clear();
                return;
            }

            txtgiamphantramtong.Enabled = false;
            txtcongtientong.Enabled = false;
            txtcongphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtgiamtientong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtgiamphantramtong.Enabled = true;
                txtcongtientong.Enabled = true;
                txtcongphantramtong.Enabled = true;
            }
            else if (txtgiamtientong.Text.StartsWith(","))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                double tongcongtiensp;
                double trutientongcong;
                double TCtiensaukhitru;
                tongcongtiensp = double.Parse(txttongcongtiensp.Text);
                trutientongcong = double.Parse(txtgiamtientong.Text);
                if (trutientongcong > tongcongtiensp)
                {
                    MessageBox.Show("sai tham số > tổng tiền");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else
                {
                    TCtiensaukhitru = tongcongtiensp - trutientongcong;
                    txtthanhtoan.Text = string.Format("{0:N2}", TCtiensaukhitru);
                    //pass form TT
                    //  HDthanhtoan = txtthanhtoan.Text;
                }
            }
        }

        private void txtgiamphantramtong_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtgiamphantramtong.Text))
            {
                return;
            }
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn trống!");
                txtgiamphantramtong.Clear();
                return;
            }

            txtgiamtientong.Enabled = false;
            txtcongtientong.Enabled = false;
            txtcongphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtgiamphantramtong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtgiamtientong.Enabled = true;
                txtcongtientong.Enabled = true;
                txtcongphantramtong.Enabled = true;
            }
            else if (txtgiamphantramtong.Text.StartsWith("."))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                txtgiamtientong.Enabled = false;
                double tongcongtiensp;
                double truphantramtong;
                double TCtiensaukhitruPT;
                double TCtiensaukhitruPT2;
                tongcongtiensp = double.Parse(txttongcongtiensp.Text);
                truphantramtong = double.Parse(txtgiamphantramtong.Text);

                if (truphantramtong < 0)
                {
                    MessageBox.Show("sai tham số <0");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else if (truphantramtong > 0)
                {
                    TCtiensaukhitruPT = (truphantramtong * tongcongtiensp) / 100;
                    TCtiensaukhitruPT2 = tongcongtiensp - TCtiensaukhitruPT;
                    txtthanhtoan.Text = string.Format("{0:N2}", TCtiensaukhitruPT2);
                }
                else if (truphantramtong > 100)
                {
                    MessageBox.Show("sai tham số >100");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
            }
        }

        private void txtgiamtientong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtgiamphantramtong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtcongtientong_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcongtientong.Text))
            {
                return;
            }
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn trống!");
                txtcongtientong.Clear();
                return;
            }

            txtcongphantramtong.Enabled = false;
            txtgiamtientong.Enabled = false;
            txtgiamphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtcongtientong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtcongphantramtong.Enabled = true;
                txtgiamtientong.Enabled = true;
                txtgiamphantramtong.Enabled = true;
            }
            else if (txtcongtientong.Text.StartsWith(","))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                double tongcongtiensp;
                double congtientongcong;
                double TCtiensaukhitru;
                tongcongtiensp = double.Parse(txttongcongtiensp.Text);
                congtientongcong = double.Parse(txtcongtientong.Text);
                if (congtientongcong > tongcongtiensp)
                {
                    MessageBox.Show("sai tham số > tổng tiền");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else
                {
                    TCtiensaukhitru = tongcongtiensp + congtientongcong;
                    txtthanhtoan.Text = string.Format("{0:N2}", TCtiensaukhitru);
                }
            }
        }

        private void txtcongphantramtong_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtcongphantramtong.Text))
            {
                return;
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn trống!");
                txtcongphantramtong.Text = string.Empty;
                return;
            }

            txtcongtientong.Enabled = false;
            txtgiamtientong.Enabled = false;
            txtgiamphantramtong.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtcongphantramtong.Text))
            {
                txtthanhtoan.Text = txttongcongtiensp.Text;
                txtgiamtientong.Enabled = true;
                txtgiamtientong.Enabled = true;
                txtgiamphantramtong.Enabled = true;
            }
            else if (txtcongphantramtong.Text.StartsWith("."))
            {
                MessageBox.Show("loi .");
            }
            else
            {
                //   txtcongtientong.Enabled = false;
                double tongcongtiensp;
                double congphantramtong;
                double TCtiensaukhicongPT;
                double TCtiensaukhicongPT2;

                tongcongtiensp = double.Parse(txttongcongtiensp.Text);
                congphantramtong = double.Parse(txtcongphantramtong.Text);

                if (congphantramtong < 0)
                {
                    MessageBox.Show("sai tham số <0");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
                else if (congphantramtong > 0)
                {
                    TCtiensaukhicongPT = (congphantramtong * tongcongtiensp) / 100;
                    TCtiensaukhicongPT2 = TCtiensaukhicongPT + tongcongtiensp;
                    txtthanhtoan.Text = string.Format("{0:N2}", TCtiensaukhicongPT2);
                }
                else if (congphantramtong > 100)
                {
                    MessageBox.Show("sai tham số >100");
                    txtthanhtoan.Text = txttongcongtiensp.Text;
                }
            }
        }

        private void txtcongphantramtong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtcongtientong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn trống!");
                return;
            }

            ListBox listBox1a = new ListBox();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                listBox1a.Items.Add(item.Cells[1].Value.ToString() + '/' + item.Cells[2].Value.ToString() + '/' + item.Cells[3].Value.ToString());
            }

            List<ChiTietHoaDon> chiTietHoaDons = new List<ChiTietHoaDon>();

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                var masp = item.Cells[0].Value.ToString();
                var slsp = item.Cells[2].Value.ToString();
                var dongia = item.Cells[3].Value.ToString();
                var malsp = item.Cells[8].Value.ToString();
                chiTietHoaDons.Add(new ChiTietHoaDon()
                {
                    LoSanPhamId = Guid.Parse(malsp),
                    SoLuong = int.Parse(slsp),
                    DonGia = double.Parse(dongia)
                });
            }

            thanhtoan = txtthanhtoan.Text;
            var formThanhToan = new BanHangTT(listBox1a.Items, chiTietHoaDons);
            huyhd();
            formThanhToan.Show();
        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtsdhKh.Text))
                {
                    txtTenKh.Clear();
                }
                else
                {
                    using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                    {
                        Repository<KhachHang> repo = new Repository<KhachHang>(dbCxt);
                        var kh = repo.Query(kh => kh.SoDienThoai.Contains(txtsdhKh.Text)).FirstOrDefault();
                        if (kh == null)
                        {
                            return;
                        }
                        else
                        {
                            txtTenKh.Text = (kh.TenKhachHang);
                            //luu tru cho form TT
                            MaKH = kh.Id == Guid.Empty ? Constants.DefaultUser : kh.Id;
                            TenKH = txtTenKh.Text;
                            SDT = txtsdhKh.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            try
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<Data.Models.SanPham> spRepo = new Repository<Data.Models.SanPham>(dbCxt);
                    var sps = spRepo.GetAll().Select(s => s.TenSanPham).ToList();

                    AutoCompleteStringCollection autotensp = new AutoCompleteStringCollection();
                    sps.ForEach(tsp => autotensp.Add(tsp));
                    txttensp.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txttensp.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txttensp.AutoCompleteCustomSource = autotensp;


                    Repository<Data.Models.KhachHang> khRepo = new Repository<Data.Models.KhachHang>(dbCxt);
                    var khs = khRepo.GetAll().Select(kh => kh.TenKhachHang).ToList();

                    AutoCompleteStringCollection autotenkh = new AutoCompleteStringCollection();
                    khs.ForEach(tkh => autotenkh.Add(tkh));
                    txtTenKh.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txtTenKh.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtTenKh.AutoCompleteCustomSource = autotenkh;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txttensp_KeyDown(object sender, KeyEventArgs e)
        {
            string loaisp1;
            double giamgiaTextbox;

            if (e.KeyCode == Keys.Enter)
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<Data.Models.LoSanPham> lspRepo = new Repository<Data.Models.LoSanPham>(dbCxt);
                    var loSanPham = lspRepo.Query(lsp => lsp.SanPham.TenSanPham == txttensp.Text && lsp.SoLuong > 0)
                        .Include(lsp => lsp.SanPham)
                        .ThenInclude(sp => sp.LoaiSanPham)
                        .Include(lsp => lsp.SanPham)
                        .ThenInclude(sp => sp.DonViSanPham)
                        .FirstOrDefault();

                    if (loSanPham == null)
                    {
                        MessageBox.Show("Sản phẩm ko có trong kho");
                        return;
                    }

                    Repository<GiamGia> ggRepo = new Repository<GiamGia>(dbCxt);
                    var gg = ggRepo.Query(gg => gg.SanPhamId == loSanPham.SanPhamId && gg.NgayBatDau < DateTime.Now && gg.NgayKetThuc > DateTime.Now).FirstOrDefault();
                    int phanTramGiamGia = 0;
                    if (gg == null)
                    {
                        phanTramGiamGia = 0;
                    }
                    else
                    {
                        phanTramGiamGia = gg.PhanTramGiamGia;
                    }

                    checkslsp = loSanPham.SoLuong;
                    if (checkslsp < 1)
                    {
                        MessageBox.Show("het hang");
                    }
                    else
                    {
                        txtmasp.Text = (loSanPham.SanPhamId.ToString());
                        txtdongiasp.Text = (loSanPham.SanPham.GiaTien.ToString());
                        txtsoluongsp.Text = "1";
                        txtgiamphantramsp.Text = (phanTramGiamGia.ToString());
                        comboBoxdonvisp.Text = (loSanPham.SanPham.LoaiSanPham.TenLoaiSanPham.ToString());
                        comboBoxloaisp.Text = (loSanPham.SanPham.DonViSanPham.TenDonViSanPham.ToString());
                        //thanhtiensp = soluong * don gia
                        double slsp;
                        double dongiasp;
                        double thanhtiensp;
                        double thanhtiensp2;
                        slsp = double.Parse(txtsoluongsp.Text);
                        dongiasp = double.Parse(txtdongiasp.Text);

                        thanhtiensp = slsp * dongiasp;
                        //tien giam gia cua san pham
                        giamgiaTextbox = double.Parse(txtgiamphantramsp.Text);
                        double giamgiasp = (giamgiaTextbox * thanhtiensp) / 100;
                        //tien san pham = (so luong * don gia ) - giam gia
                        thanhtiensp2 = thanhtiensp - giamgiasp;

                        txttiensp.Text = string.Format("{0:N2}", thanhtiensp2);

                        //luu tru cho from  TT
                        loaisp1 = comboBoxloaisp.Text;
                    }
                }
            }
        }

        private void txtsoluongsp_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtsoluongsp.Text)
             && !string.IsNullOrWhiteSpace(txtdongiasp.Text)
             && !string.IsNullOrWhiteSpace(txtgiamphantramsp.Text))
            {
                int slspHienTai = Convert.ToInt32(txtsoluongsp.Text);
                if (slspHienTai > checkslsp)
                {
                    txtsoluongsp.Text = checkslsp.ToString();
                }
                else
                {
                    double giamgiaTextbox;
                    double slsp;
                    double dongiasp;
                    double thanhtiensp;
                    double thanhtiensp2;
                    slsp = double.Parse(txtsoluongsp.Text);
                    dongiasp = double.Parse(txtdongiasp.Text);
                    thanhtiensp = slsp * dongiasp;

                    //tien giam gia cua san pham
                    giamgiaTextbox = double.Parse(txtgiamphantramsp.Text);
                    double giamgiasp = (giamgiaTextbox * thanhtiensp) / 100;
                    //tien san pham = (so luong * don gia ) - giam gia
                    thanhtiensp2 = thanhtiensp - giamgiasp;
                    txttiensp.Text = string.Format("{0:N2}", thanhtiensp2);
                }
            }
        }

        private void btnhuyHD_Click(object sender, EventArgs e)
        {
            huyhd();
        }

        private void txtmasp_KeyDown(object sender, KeyEventArgs e)
        {
            //using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
            //{
            //    Repository<Data.Models.LoSanPham> lspRepo = new Repository<Data.Models.LoSanPham>(dbCxt);
            //    var searchText = txtmasp.Text;
            //    var loSanPham = lspRepo.GetAll()
            //        .Include(lsp => lsp.SanPham)
            //        .ThenInclude(sp => sp.LoaiSanPham)
            //        .Include(lsp => lsp.SanPham)
            //        .ThenInclude(sp => sp.DonViSanPham)
            //        .ToList()
            //        .Where(lsp => lsp.SanPham.Id.ToString().Contains(searchText))
            //        .FirstOrDefault();

            //    if (loSanPham == null)
            //    {
            //        return;
            //    }

            //    Repository<GiamGia> ggRepo = new Repository<GiamGia>(dbCxt);
            //    var gg = ggRepo.Query(gg => gg.SanPhamId == loSanPham.SanPhamId && gg.NgayBatDau < DateTime.Now && gg.NgayKetThuc > DateTime.Now).FirstOrDefault();
            //    int phanTramGiamGia = 0;
            //    if (gg == null)
            //    {
            //        phanTramGiamGia = 0;
            //    }
            //    else
            //    {
            //        phanTramGiamGia = gg.PhanTramGiamGia;
            //    }

            //    txtmasp.Text = (loSanPham.SanPham.Id.ToString());
            //    txttensp.Text = (loSanPham.SanPham.TenSanPham.ToString());
            //    txtdongiasp.Text = (loSanPham.SanPham.GiaTien.ToString());
            //    txtsoluongsp.Text = "1";
            //    txtgiamphantramsp.Text = (phanTramGiamGia.ToString());
            //    comboBoxdonvisp.Text = (loSanPham.SanPham.DonViSanPham.TenDonViSanPham.ToString());
            //    comboBoxloaisp.Text = (loSanPham.SanPham.LoaiSanPham.TenLoaiSanPham.ToString());
            //    //thanhtiensp = soluong * don gia
            //    double slsp;
            //    double dongiasp;
            //    double thanhtiensp;
            //    double thanhtiensp2;
            //    slsp = double.Parse(txtsoluongsp.Text);
            //    dongiasp = double.Parse(txtdongiasp.Text);
            //    thanhtiensp = slsp * dongiasp;
            //    //tien giam gia cua san pham
            //    double giamgiaPhantram = double.Parse(txtgiamphantramsp.Text);
            //    double giamgiasp = (giamgiaPhantram * thanhtiensp) / 100;
            //    //tien san pham = (so luong * don gia ) - giam gia
            //    thanhtiensp2 = thanhtiensp - giamgiasp;

            //    txttiensp.Text = string.Format("{0:N2}", thanhtiensp2);
            //}
        }

        private void txtsoluongsp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtdongiasp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txttiensp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
