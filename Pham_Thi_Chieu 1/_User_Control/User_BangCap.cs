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
    public partial class User_BangCap : UserControl
    {
        public User_BangCap()
        {
            InitializeComponent();
        }
        #region Khai báo biến
        Class_XuLi.Class_BangCap nv = new Class_XuLi.Class_BangCap();
        public string Ten_BangCap = null;
        public string HeSoLuong = null;
        public string LuongNgayNghi = null;
        #endregion

        #region Khai báo hàm
        #region settextbox
        public void Settextbox()   
            // khi luu bang cấp xong thì xóa hết thông tin cux reset  về null
        {
            txt_ten.Text = null;
            txt_hsl.Text = null;
            txt_luongngaynghi.Text = null;
            txt_mota.Text = null;
            txt_ten.Focus();
        }
        #endregion
        #endregion

        #region UserBangCap_Load
        private void User_BangCap_Load(object sender, EventArgs e)
        {
            dgv_BangCap.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;      
            dgv_BangCap.DataSource = nv.Load_BangCap();     
            // cái datasouce là dữ liệu cuaaur datagridview đó = datatable  bện kia

        }
        #endregion

        #region Lưu dữ liệu
        private void btn_Luu_Click(object sender, EventArgs e)         
        {
            double a = 0;  // gán =0 để kiểm tra xem txt_luongngaynghi.Text có phải là nhập số hay không 
            // nếu không nhập số thì mesage và kết thúc
            if(txt_ten.Text.CompareTo("")==0 || txt_hsl.Text.CompareTo("")==0||txt_luongngaynghi.Text.CompareTo("")==0)
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông  tin","Thêm Mới");
                return;
            }
            #region kiểm tra mức lương và hệ số lương phải là số
            try
            {
                a = double.Parse(txt_luongngaynghi.Text);
            }
            catch
            {
                MessageBox.Show("Lương ngày nghỉ phải là số","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                txt_luongngaynghi.Focus();
                return;
            }
            try
            {
                a=double.Parse(txt_hsl.Text);
            }
            catch
            {
                MessageBox.Show("Hệ số lương phải là số","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                txt_hsl.Focus();
                return;
            }
            #endregion

            #region Kiểm tra xem đã có tên bằng cấp này trong hệ thống chưa
            if(nv.BangCap_KiemTraTen(txt_ten.Text)==true)
            {
                MessageBox.Show("Đã có tên bằng cấp : "+  txt_ten.Text+" trong hệ thống","Thông báo");
                return;
            }
            #endregion

            #region Nếu thỏa điều kiện thì thêm mới
            nv.BangCapThem(txt_ten.Text, txt_hsl.Text, txt_luongngaynghi.Text, txt_mota.Text);
            dgv_BangCap.DataSource= nv.Load_BangCap();
            Settextbox();
            MessageBox.Show("Thêm thành công");
            
            #endregion
        }
        #endregion

        #region Xóa Bằng Cấp
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgv_BangCap.CurrentRow;
           if(nv.Xoa(int.Parse(dr.Cells[0].Value.ToString()))==true)
           {
               dgv_BangCap.DataSource = nv.Load_BangCap();
               MessageBox.Show("Xóa thành công","Xóa");

           }
            else
           {
               MessageBox.Show("Lỗi", "Xóa",MessageBoxButtons.OK,MessageBoxIcon.Error);
           }


        }
        #endregion

        #region Khi Click vào datagridview
        private void dgv_BangCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgv_BangCap.CurrentRow;
            txt_ten.Text = dr.Cells[1].Value.ToString();
            txt_hsl.Text = dr.Cells[2].Value.ToString();
            txt_luongngaynghi.Text = dr.Cells[3].Value.ToString();
            txt_mota.Text = dr.Cells[4].Value.ToString();
        }
        #endregion

        #region CellEndEdit
        private void dgv_BangCap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgv_BangCap.CurrentRow;
            double a = 0;
            if(e.ColumnIndex==1) // nếu như chọn sửa tên bằng cấp
            {
                if(nv.BangCap_KiemTraTen(dr.Cells[1].Value.ToString())==true)
                {
                    MessageBox.Show("Tên bằng cấp đã có trong hệ thống","Thông báo");
                    dr.Cells[1].Value = Ten_BangCap.ToString();
                    return;
                }
            }
            if (e.ColumnIndex == 2) // nếu như chọn sửa hệ số lương
            {
                try
                {
                    a = double.Parse(dr.Cells[2].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Phải nhập số","Thông báo");
                    dr.Cells[2].Value = HeSoLuong.ToString();
                    return;
                }
            }
            if (e.ColumnIndex == 3) // nếu như chọn sửa lương ngày nghỉ
            {
                try
                {
                    a = double.Parse(dr.Cells[3].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Phải nhập số", "Thông báo");
                    dr.Cells[3].Value = LuongNgayNghi.ToString();
                    return;
                }
            }
            #region Sửa thông tin thay đổi
            if (nv.BangCap_Sua(int.Parse(dr.Cells[0].Value.ToString()), dr.Cells[1].Value.ToString(), dr.Cells[2].Value.ToString(), dr.Cells[3].Value.ToString(), dr.Cells[4].Value.ToString())==true)
            {
                try
                {
                    dgv_BangCap.DataSource = nv.Load_BangCap();
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                }
                catch
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Không thành công","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                return;
            }
            #endregion
        }
        #endregion

        #region CellBeginEdit
        private void dgv_BangCap_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dr = dgv_BangCap.CurrentRow;
            Ten_BangCap = dr.Cells[1].Value.ToString();
            HeSoLuong = dr.Cells[2].Value.ToString();
            LuongNgayNghi = dr.Cells[3].Value.ToString();
        }
        #endregion



    }
}
