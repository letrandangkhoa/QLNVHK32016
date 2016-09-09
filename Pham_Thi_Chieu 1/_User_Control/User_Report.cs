using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Pham_Thi_Chieu.Class_XuLi;
namespace Pham_Thi_Chieu._User_Control
{
    public partial class User_Report : UserControl
    {
        public User_Report()
        {
            InitializeComponent();
        }
        Class_TinhLuong tl = new Class_TinhLuong();
        private void btnTaoRp_Click(object sender, EventArgs e)
        {
            ReportDataSource rds;
            if (string.IsNullOrEmpty(textBox1.Text) == true)                 // nếu textbox1 không rỗng thì gán datasource = dataset....
            {
                rds = new ReportDataSource("DataSet1", tl.Load_TinhLuong(dateTimePicker1.Value));
            }
            else
            {
                rds = new ReportDataSource("DataSet1", tl.Load_TinhLuong(textBox1.Text, dateTimePicker1.Value));     // ngược lại
            }
            report.LocalReport.DataSources.Clear();      // xóa hết data hiện có
            report.LocalReport.DataSources.Add(rds);                            // gán data cho reprot
            report.RefreshReport();                                                                   // refresh 
        }
                                                                           
        private void report_Load(object sender, EventArgs e)
        {

        }
    }
}
