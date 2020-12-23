using Microsoft.EntityFrameworkCore;

using QuanLyCuaHangTienLoi.Data;
using QuanLyCuaHangTienLoi.Data.Implementation;
using QuanLyCuaHangTienLoi.Data.Models;

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
    public partial class ChartMoney : Form
    {
        string CurrentMonth = DateTime.Now.ToString("MM");
        public ChartMoney()
        {
            InitializeComponent();
            ChartMoneydaybydate();
        }

        private void ChartMoneydaybydate()
        {
            try
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<HoaDon> hoadonRepo = new Repository<HoaDon>(dbCxt);
                    var hoadonThangNay = hoadonRepo.Query(hd => hd.NgayLap.Month == DateTime.Now.Month).OrderBy(hd => hd.NgayLap).Include(hd => hd.ChiTietHoaDon).ToList();
                    double[] dataX = hoadonThangNay.Select(hd => hd.NgayLap.ToOADate()).ToArray();
                    double[] dataY = hoadonThangNay.Select(hd => hd.ChiTietHoaDon.Sum(cthd => cthd.DonGia * cthd.SoLuong)).ToArray();
                    formsPlot1.plt.PlotScatter(dataX, dataY);
                    formsPlot1.plt.Ticks(dateTimeX: true);
                    formsPlot1.Render();
                }
            }
            catch (Exception) { }
        }
    }
}
