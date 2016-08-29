using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Pham_Thi_Chieu.Class_XuLi;
namespace Pham_Thi_Chieu._User_Control
{
    public partial class User_HeSoCoBan : UserControl
    {
        public User_HeSoCoBan()
        {
            InitializeComponent();
        }
        Class_HeSoCoBan hscb = new Class_HeSoCoBan();
        private void User_HeSoCoBan_Load(object sender, EventArgs e)
        {
            dgv_HSCB.Columns[1].ReadOnly = true;
            dgv_HSCB.DataSource = hscb.Load_HSCB();

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                hscb.Update();
                dgv_HSCB.DataSource = hscb.Load_HSCB();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo");    
                return;
            }
            catch
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo");
                return;
            }
            
        }

        private void dgv_HSCB_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv_HSCB.SelectedRows.Count > 0)
                {
                    txtTenhS.Text = dgv_HSCB.SelectedCells[1].Value.ToString();
                    txt_ChiSo.Text = dgv_HSCB.SelectedCells[2].Value.ToString();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
