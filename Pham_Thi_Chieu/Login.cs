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
        Class_XuLi.Class_DangNhap nv = new Class_XuLi.Class_DangNhap();
        frm_Main _frm;
        #region thoát chương trình
        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                //this.Close();
                _frm.ShowDialog();
                
            }
            else
            {

            }
            #endregion
        }
        #endregion

    }
}
