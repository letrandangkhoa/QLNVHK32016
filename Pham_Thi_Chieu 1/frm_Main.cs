using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pham_Thi_Chieu.Class_XuLi;

namespace Pham_Thi_Chieu
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        double PCCV_TruongKhoa;
        double PCCV_PhoKhoa;
        double PCCV_TruongBM;
        double PCCV_BT;
        double PCUD;
        Class_HeSoCoBan hscb = new Class_HeSoCoBan();
        Class_NhanVien nv = new Class_NhanVien();
        Class_BangCap bc = new Class_BangCap();
        Class_TienThuong tt = new Class_TienThuong();
        Class_ChiPhiKhac cpk = new Class_ChiPhiKhac();
        PhuCap pc = new PhuCap();
        Class_TinhLuong TL = new Class_TinhLuong();

        DataTable dtb_TongPC = new DataTable();
        DataTable dtb_nv = new System.Data.DataTable();
        DataTable dtb_HSCB = new DataTable();
        DataTable dtb_BC = new DataTable();
        DataTable dtb_TT = new DataTable();
        DataTable dtb_CPK = new DataTable();

        #region From Load
        private void frm_Main_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "xin chào " + Login.taiKhoan;
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

        #region event btn_NhanVien_Click
        private void btn_NhanVien_Click(object sender, EventArgs e)
                {

                    Panel_Main.Controls.Clear();
                    _User_Control.User_NhanVien Us = new _User_Control.User_NhanVien();
                    Panel_Main.Controls.Add(Us);
                    Us.Dock = System.Windows.Forms.DockStyle.Fill;
                }
         #endregion

        #region Tính Lương Nhân viên

        double getHSL(int id_bc)
        {
            for (int i = 0; i < dtb_BC.Rows.Count; i++)
            {
                if (int.Parse(dtb_BC.Rows[i][0].ToString()) == id_bc)
                {
                    return double.Parse(dtb_BC.Rows[i][2].ToString()) / 10;
                }
            }

            return 0;
        }

        double getPCCV(int id_CV)
        {
            if (id_CV == 2)  //Trưởng Khoa
                return PCCV_TruongKhoa;
            if (id_CV == 13) //phó khoa
                return PCCV_PhoKhoa;
            if (id_CV == 14) //trưởng bộ môn
                return PCCV_TruongBM;
            return 0;
        }

        double TongTienThuong(int id)
        {
            double sum = 0;
            for (int i = 0; i < dtb_TT.Rows.Count; i++)
            {
                if (int.Parse(dtb_TT.Rows[i][1].ToString()) == id)
                {
                    sum += double.Parse(dtb_TT.Rows[i][2].ToString());
                }
            }
            return sum;
        }
        double TongTienCPK(int id)
        {
            double sum = 0;
            for (int i = 0; i < dtb_CPK.Rows.Count; i++)
            {
                if (int.Parse(dtb_CPK.Rows[i][0].ToString()) == id)
                {
                    sum += double.Parse(dtb_CPK.Rows[i][2].ToString());
                }
            }
            return sum;
        }

        double GetTongTienPC(int id_nv)
        {
            for (int i = 0; i < dtb_TongPC.Rows.Count; i++)
            {
                if (int.Parse(dtb_TongPC.Rows[i][0].ToString()) == id_nv)
                {
                    return double.Parse(dtb_TongPC.Rows[i][1].ToString());
                }
            }
            return 0;
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Hôm Nay Ngày: " + DateTime.Now.ToString("mm:HH - DD/MM/YYYY") + "Bạn Có Thực Sự Muốn Tính Lương", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                
                dtb_HSCB = hscb.Load_HSCB();
                dtb_nv = nv.Load_NhanVien();
                dtb_BC = bc.Load_BangCap();
                dtb_TT = tt.Load_TienThuong(DateTime.Now.Month, DateTime.Now.Year);
                dtb_CPK = cpk.Load_CPK(DateTime.Now.Month, DateTime.Now.Year);
                dtb_TongPC = pc.Load_TongPhuCapNV();


                int LuongTT = int.Parse(dtb_HSCB.Rows[0][2].ToString());
                PCCV_TruongKhoa = int.Parse(dtb_HSCB.Rows[1][2].ToString()) / 100.0;
                PCCV_PhoKhoa = int.Parse(dtb_HSCB.Rows[2][2].ToString()) / 100.0;
                PCCV_TruongBM = int.Parse(dtb_HSCB.Rows[3][2].ToString()) / 100.0;
                PCCV_BT = int.Parse(dtb_HSCB.Rows[4][2].ToString()) / 100.0;
                PCUD = int.Parse(dtb_HSCB.Rows[8][2].ToString()) / 100.0;
                double BHYT = int.Parse(dtb_HSCB.Rows[5][2].ToString()) / 100.0;
                double BHXH = int.Parse(dtb_HSCB.Rows[6][2].ToString()) / 100.0;
                double BHTN = int.Parse(dtb_HSCB.Rows[7][2].ToString()) / 100.0;
                double TrichNop = BHYT + BHXH + BHTN;

                double LCB , Luong , PCTN, Thuong, ChiPhiKhac, MucPC;
                double HSL, PCCV;
                string ghiChu = "Chi Phí Khác = Các Khoản Thu Bảo Hiểm và các tiền phụ khác";
                for (int i = 0; i < dtb_nv.Rows.Count; i++)
                {
                    HSL = getHSL(int.Parse(dtb_nv.Rows[i][6].ToString()));
                    PCCV = getPCCV(int.Parse(dtb_nv.Rows[i][7].ToString()));
                    LCB = LuongTT * (HSL + PCCV);

                    PCTN = DateTime.Now.Year - ((DateTime)dtb_nv.Rows[i][10]).Year;
                    if (PCTN < 5)
                        PCTN = 0;
                    else
                        PCTN = (PCTN / 100.0) * LCB;

                    LCB = LCB + PCTN;



                    Thuong = TongTienThuong(int.Parse(dtb_nv.Rows[i][0].ToString()));
                    ChiPhiKhac = TongTienCPK(int.Parse(dtb_nv.Rows[i][0].ToString())) - ((LCB * TrichNop) / 100.0);

                    MucPC = GetTongTienPC(int.Parse(dtb_nv.Rows[i][0].ToString()));

                    Luong = LCB + Thuong + ChiPhiKhac + MucPC ;

                    TL.ThemLuongNhanVien(int.Parse(dtb_nv.Rows[i][0].ToString()), LCB, Thuong, MucPC, ChiPhiKhac, Luong, DateTime.Now, ghiChu);
                }
                MessageBox.Show("Tính Lương Hoàn Tất", "Thông Báo");

            }
        }
        #endregion
        private void ribbonTabItem3_Click(object sender, EventArgs e)
        {
            Panel_Main.Controls.Clear();

            _User_Control.User_TinhLuong Us = new _User_Control.User_TinhLuong();
            Panel_Main.Controls.Add(Us);
            Us.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            Panel_Main.Controls.Clear();

            _User_Control.User_Report Us = new _User_Control.User_Report();
            Panel_Main.Controls.Add(Us);
            Us.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            Login.coHieu_Reset = true;  //
            this.Close();
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            Panel_Main.Controls.Clear();

            _User_Control.UserDoiMatKhau Us = new _User_Control.UserDoiMatKhau();
            Panel_Main.Controls.Add(Us);
            Us.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            Panel_Main.Controls.Clear();

            _User_Control.User_HeSoCoBan Us = new _User_Control.User_HeSoCoBan();
            Panel_Main.Controls.Add(Us);
            Us.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void btn_QLMPCap_Click(object sender, EventArgs e)
        {

        }

        private void btn_PCCNV_Click(object sender, EventArgs e)
        {
            Panel_Main.Controls.Clear();

            _User_Control.QLPhuCap Us = new _User_Control.QLPhuCap();
            Panel_Main.Controls.Add(Us);
            Us.Dock = System.Windows.Forms.DockStyle.Fill;  // định dạng đẻ usercontrol  show full phần màu trăng ở form main panel
        }

        private void ribbonTabItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
