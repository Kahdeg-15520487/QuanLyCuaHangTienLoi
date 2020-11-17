//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace QuanLyCuaHangTienLoi.UI.MenuTab
//{
//    public partial class ChartSPHet : Form
//    {
//        SqlConnection connect = ClassKetnoi.connect;
//        //SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-A0E9NLI\MSSQLSERVER2019;Initial Catalog=doan-3;Integrated Security=True");
//        string CurrentMonth = DateTime.Now.ToString("MM");
//        public ChartSPHet()
//        {
//            InitializeComponent();
//            SanphamSapHet();
//        }
//        private void SanphamSapHet()
//        {
//            // ChartSlspDayByDay.Series["SeriesHH"].XValueType = ChartValueType.DateTime;

//            //ChartSlspDayByDay.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";
//            DataSet ds = new DataSet();
//            connect.Open();
//            //SqlDataAdapter adapt = new SqlDataAdapter("SELECT CAST(HDtime AS DATE) AS Ngay,COUNT(value) as slsp, HDthanhtoan as tien FROM HoaDon CROSS APPLY STRING_SPLIT(HDmasp, ',') where MONTH(HDtime) = '"+ CurrentMonth + "' group by HDtime, HDthanhtoan ORDER BY HDtime", connect);
//            SqlDataAdapter adapt = new SqlDataAdapter("select tensp as Ten,soluongsp as SL from tonkho where  soluongsp <= 30", connect);

//            adapt.Fill(ds);
//            chart1.DataSource = ds;
//            //set the member of the chart data source used to data bind to the X-values of the series  
//            chart1.Series["Series1"].XValueMember = "Ten";
//            //set the member columns of the chart data source used to data bind to the X-values of the series  
//            chart1.Series["Series1"].YValueMembers = "SL";
//            chart1.Series["Series1"].IsValueShownAsLabel = true;
//            //ChartSlspDayByDay.Titles.Add("Salary Chart");
//            connect.Close();
//        }
//    }
//}
