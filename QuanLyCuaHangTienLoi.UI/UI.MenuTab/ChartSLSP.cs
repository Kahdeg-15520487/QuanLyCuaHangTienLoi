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
//using System.Windows.Forms.DataVisualization.Charting;

//namespace QuanLyCuaHangTienLoi.UI.MenuTab
//{
//    public partial class ChartSLSP : Form
//    {
//        SqlConnection connect = ClassKetnoi.connect;
//        //SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-A0E9NLI\MSSQLSERVER2019;Initial Catalog=doan-3;Integrated Security=True");
//        string CurrentMonth = DateTime.Now.ToString("MM");
//        public ChartSLSP()
//        {
//            InitializeComponent();
//            ChartSLSPdaybydate();
//        }
//        private void ChartSLSPdaybydate()
//        {
//            chart1.Series["Series1"].XValueType = ChartValueType.DateTime;
//            chart1.Series["Series1"].YValueType = ChartValueType.Int32;
//            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";
//            DataSet ds = new DataSet();
//            connect.Open();
//            //SqlDataAdapter adapt = new SqlDataAdapter("SELECT CAST(HDtime AS DATE) AS Ngay,COUNT(value) as slsp, HDthanhtoan as tien FROM HoaDon CROSS APPLY STRING_SPLIT(HDmasp, ',') where MONTH(HDtime) = '"+ CurrentMonth + "' group by HDtime, HDthanhtoan ORDER BY HDtime", connect);
//            SqlDataAdapter adapt = new SqlDataAdapter("SELECT CAST(HDtime AS DATE) AS Ngay, sum(cast(value as int) ) as slsp FROM HoaDon CROSS APPLY STRING_SPLIT(HDsl, ',') where MONTH(HDtime) = '" + CurrentMonth + "' group by CAST(HDtime AS DATE)", connect);

//            adapt.Fill(ds);
//            chart1.DataSource = ds;
//            //set the member of the chart data source used to data bind to the X-values of the series  
//            chart1.Series["Series1"].XValueMember = "Ngay";
//            //set the member columns of the chart data source used to data bind to the X-values of the series  
//            chart1.Series["Series1"].YValueMembers = "slsp";
//            chart1.Series["Series1"].IsValueShownAsLabel = true;
//            //ChartSlspDayByDay.Titles.Add("Salary Chart");
//            connect.Close();
//        }
//    }
//}
