using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pham_Thi_Chieu.Class_XuLi;

namespace Pham_Thi_Chieu._User_Control
{
    public partial class User_ChucVu : UserControl
    {
        public User_ChucVu()
        {
            InitializeComponent();
        }
        #region khai báo biên
        Class_ChucVu nv = new Class_ChucVu();
        DataTable dt = new DataTable();
        #endregion
        private void User_ChucVu_Load(object sender, EventArgs e)
        {
            dgvChucVu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChucVu.DataSource = nv.LoadChucVu();
        }

        #region settextbox
        public void Settextbox()
        {
            txt_ChucVu.Text = null;
            txt_GhiChu.Text = null;

            txt_ChucVu.Focus();
        }
        #endregion

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            double a = 0;
            if (txt_ChucVu.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông  tin", "Thêm Mới");
                return;
            }

            #region Nếu thỏa điều kiện thì thêm mới
            nv.ChucVu_Them(txt_ChucVu.Text, txt_GhiChu.Text);
            dgvChucVu.DataSource = nv.LoadChucVu();
            Settextbox();
            MessageBox.Show("Thêm thành công");

            #endregion
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvChucVu.CurrentRow;
            if (nv.ChucVu_Xoa(dr.Cells[0].Value.ToString()) == true) 
            {
                dgvChucVu.DataSource = nv.LoadChucVu();
                MessageBox.Show("Xóa thành công", "Xóa");

            }
            else
            {
                MessageBox.Show("Lỗi", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChucVu_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChucVu.SelectedRows.Count > 0)
            {
                txt_ChucVu.Text = dgvChucVu.SelectedCells[1].Value.ToString();
                txt_GhiChu.Text = dgvChucVu.SelectedCells[2].Value.ToString();
            }
        }


    }
}
