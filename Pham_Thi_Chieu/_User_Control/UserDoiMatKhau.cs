using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pham_Thi_Chieu._User_Control
{
    public partial class UserDoiMatKhau : UserControl
    {
        public UserDoiMatKhau()
        {
            InitializeComponent();
        }
        Class_XuLi.Class_DangNhap nv = new Class_XuLi.Class_DangNhap();
        private void button1_Click(object sender, EventArgs e)
        {
            #region Kiểm tra dữ liệu nhập
            if (txtMKC.Text.CompareTo("") == 0 || txtMKM1.Text.CompareTo("") == 0 || txtMKM2.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin");
                return;
            }
            if (txtMKM1.Text.CompareTo(txtMKM2.Text) != 0)
            {
                MessageBox.Show("Mật Khẩu Mới Không Khớp");
                return;
            }
            #endregion

            #region nếu thông tin nhập chính xác thì Login
            if (Login.matKhau.CompareTo(txtMKC.Text) == 0)
            {
                if (nv.DoiMatKhau(Login.taiKhoan, txtMKM1.Text) == true)
                {
                    Login.matKhau = txtMKM1.Text;
                    txtMKC.Text = "";
                    txtMKM1.Text = "";
                    txtMKM2.Text = "";
                    MessageBox.Show("Mật Khẩu đã được đổi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                    MessageBox.Show("Thây đổi thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Mật Khẩu Không Đúng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            #endregion
        }
    }
}
