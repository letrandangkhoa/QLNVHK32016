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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string taiKhoan, matKhau;
        public static bool coHieu_Reset;
        Class_XuLi.Class_DangNhap nv = new Class_XuLi.Class_DangNhap();

        frm_Main _frm;
        #region thoát chương trình
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region đăng nhập hệ thống
        private void btn_Dangnhap_Click(object sender, EventArgs e)
        {
            #region Kiểm tra dữ liệu nhập
            if (txt_MatKhau.Text.CompareTo("")==0 || txt_TenDN.Text.CompareTo("")==0)
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin");
                return;
            }
            #endregion

            #region nếu thông tin nhập chính xác thì Login
            if(nv.Login_DangNhap(txt_TenDN.Text,txt_MatKhau.Text)==true)
            {
                _frm = new frm_Main();
                this.Hide();
                Login.taiKhoan = txt_TenDN.Text;
                Login.matKhau = txt_MatKhau.Text;
                _frm.ShowDialog();
                if (Login.coHieu_Reset == true)
                {
                    txt_MatKhau.Text = "";
                    txt_TenDN.Text = "";
                    this.Show();
                }
                else
                    this.Close();
                
            }
            else
            {
                MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            #endregion
        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            Login.coHieu_Reset = false;
        }

    }
}
