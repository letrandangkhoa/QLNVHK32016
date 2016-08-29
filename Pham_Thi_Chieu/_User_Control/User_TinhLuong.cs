using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Pham_Thi_Chieu._User_Control
{
    public partial class User_TinhLuong : UserControl
    {
        public User_TinhLuong()
        {
            InitializeComponent();
        }
        #region Khai báo biến
        Class_XuLi.Class_TinhLuong nv = new Class_XuLi.Class_TinhLuong();
        public string Ten_BangCap = null;
        public string HeSoLuong = null;
        public string LuongNgayNghi = null;
        #endregion

        #region settextbox
        public void Settextbox()
        {
            txtTenNhanVien.Text = "";
            txtCMND.Text = "";
            txtLuongCoBan.Text = "";
            txtTienThuong.Text = "";
            txtPhuCap.Text = "";
            txtKhoanPhiKhac.Text = "";
            txtTongTien.Text = "";
            txtNgayTinhLuong.Text = "";
            txtGhiChu.Text = "";
            ptb_HinhAnh.Image = null;
            
        }
        #endregion

        private void TinhLuong_Load(object sender, EventArgs e)
        {
            dgv_TinhLuong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_TinhLuong.DataSource = nv.Load_TinhLuong();
            Settextbox();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {

        }

        private void dgv_TinhLuong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_TinhLuong.SelectedRows.Count > 0)
            {
                txtTenNhanVien.Text = dgv_TinhLuong.SelectedCells[1].Value.ToString();
                txtCMND.Text = dgv_TinhLuong.SelectedCells[2].Value.ToString();
                txtLuongCoBan.Text = dgv_TinhLuong.SelectedCells[3].Value.ToString();
                txtTienThuong.Text = dgv_TinhLuong.SelectedCells[4].Value.ToString();
                txtPhuCap.Text = dgv_TinhLuong.SelectedCells[5].Value.ToString();
                txtKhoanPhiKhac.Text = dgv_TinhLuong.SelectedCells[6].Value.ToString();                
                txtTongTien.Text = dgv_TinhLuong.SelectedCells[7].Value.ToString();
                txtNgayTinhLuong.Text = dgv_TinhLuong.SelectedCells[8].Value.ToString();
                txtGhiChu.Text = dgv_TinhLuong.SelectedCells[9].Value.ToString();

                try
                {
                    byte[] Mybyte = new byte[0];
                    Mybyte = (byte[])dgv_TinhLuong.SelectedCells[10].Value;

                    MemoryStream Mstr = new MemoryStream(Mybyte);
                    ptb_HinhAnh.Image = Image.FromStream(Mstr);
                }
                catch
                {
                    return;
                }
            }
        }
    }
}
