using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pham_Thi_Chieu
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        #region From Load
        private void frm_Main_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "xin chào admin";
        }
        #endregion

        #region danh sách bằng cấp
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            Panel_Main.Controls.Clear();
            _User_Control.User_BangCap Us = new _User_Control.User_BangCap();
            Panel_Main.Controls.Add(Us);
            Us.Dock = System.Windows.Forms.DockStyle.Fill;
        }
        #endregion

        #region chạy ngày giờ
        private void time_ngaygio_Tick(object sender, EventArgs e)
        {
            tolltip_NgayGio.Text = "Ngày:   " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() +
               "     "+  DateTime.Now.Hour.ToString() + " : " + DateTime.Now.Minute.ToString() + " : " + DateTime.Now.Second.ToString();
            
        }
        #endregion

        #region Danh sách phòng ban
                private void btn_PhongBan_Click(object sender, EventArgs e)
                {
                    Panel_Main.Controls.Clear();
                    _User_Control.User_PhongBan Us = new _User_Control.User_PhongBan();
                    Panel_Main.Controls.Add(Us);
                    Us.Dock = System.Windows.Forms.DockStyle.Fill;

                }
        #endregion

        #region Danh sách chức  vụ
                private void btn_ChucVu_Click(object sender, EventArgs e)
                {
                    Panel_Main.Controls.Clear();
                    _User_Control.User_ChucVu Us = new _User_Control.User_ChucVu();
                    Panel_Main.Controls.Add(Us);
                    Us.Dock = System.Windows.Forms.DockStyle.Fill;
                }
                #endregion

        #region
        private void btn_NhanVien_Click(object sender, EventArgs e)
                {

                    Panel_Main.Controls.Clear();
                    _User_Control.User_NhanVien Us = new _User_Control.User_NhanVien();
                    Panel_Main.Controls.Add(Us);
                    Us.Dock = System.Windows.Forms.DockStyle.Fill;
                }
         #endregion
    }
}
