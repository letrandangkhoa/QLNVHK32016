using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pham_Thi_Chieu._User_Control
{
    public partial class User_PhongBan : UserControl
    {
        public User_PhongBan()
        {
            InitializeComponent();
        }
        #region khai báo biên
        Class_PhongBan nv = new Class_PhongBan();
        DataTable dt = new DataTable();
        #endregion

        #region form Load phòng ban
        private void User_PhongBan_Load(object sender, EventArgs e)
        {
            dgv_PhongBan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_PhongBan.DataSource = nv.Load_PB();
        }
        #endregion

        #region hiển thị thông tin lên textbx CellClick
        private void dgv_PhongBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgv_PhongBan.CurrentRow;
            txt_Ten.Text = dr.Cells[1].Value.ToString();
            txt_GhiChu.Text = dr.Cells[2].Value.ToString();

        }
        #endregion

        #region Thêm Phòng ban
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if(txt_Ten.Text.CompareTo("")==0)
            {
                MessageBox.Show("bạn chưa nhập tên: Phòng Ban");
                txt_Ten.Focus();
                return;
            }
            if(nv.kiemtra_PhongBan(txt_Ten.Text)==true)
            {
                MessageBox.Show("Đã có tên phòng ban này trong hệ thống rồi\n\n Kiểm tra lại thông tin","Thông báo");
                txt_Ten.Text = null;
                txt_Ten.Focus();
                return;
            }
            nv.PhongBan_Them(txt_Ten.Text, txt_GhiChu.Text);
            dgv_PhongBan.DataSource = nv.Load_PB();
        }
        #endregion

        #region Xóa Phòng ban
        private void btn_Xoa_Click(object sender, EventArgs e)
        {

        }
#endregion

        #region sủa thông tin phòng  ban
        private void dgv_PhongBan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region lấy dữ liệu phòng ban trước khi sửa
        private void dgv_PhongBan_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }
        #endregion



    }
}
