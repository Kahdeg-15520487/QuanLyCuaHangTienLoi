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
    public partial class ChartSLSP : Form
    {
        string CurrentMonth = DateTime.Now.ToString("MM");
        public ChartSLSP()
        {
            InitializeComponent();
            ChartSLSPdaybydate();
        }
        private void ChartSLSPdaybydate()
        {
            try
            {
                using (CuaHangTienLoiDbContext dbCxt = new CuaHangTienLoiDbContext(ClassKetnoi.contextOptions))
                {
                    Repository<SanPham> sanphamRepo = new Repository<SanPham>(dbCxt);
                    Repository<LoSanPham> losanphamRepo = new Repository<LoSanPham>(dbCxt);
                    var sanphams = sanphamRepo.GetAll().ToList();
                    foreach (var sp in sanphams)
                    {
                        var sanphamThangNay = losanphamRepo.Query(lsp => lsp.NgayNhap.Month == DateTime.Now.Month).OrderBy(hd => hd.NgayNhap).ToList().GroupBy(hd => hd.NgayNhap.ToShortDateString()).ToList();
                        if (sanphamThangNay.Count == 0)
                        {
                            continue;
                        }

                        var query = sanphamThangNay.Select((grp) => new
                        {
                            ngay = DateTime.Parse(grp.Key).ToOADate(),
                            sl = grp.Sum(lsp => (double)lsp.SoLuong)
                        });

                        double[] dataX = query.Select(q => q.ngay).ToArray();
                        double[] dataY = query.Select(q => q.sl).ToArray();
                        formsPlot1.plt.PlotScatter(dataX, dataY);
                        formsPlot1.plt.Ticks(dateTimeX: true);
                    }
                    formsPlot1.Render();
                }
            }
            catch (Exception) { }
        }
    }
}
