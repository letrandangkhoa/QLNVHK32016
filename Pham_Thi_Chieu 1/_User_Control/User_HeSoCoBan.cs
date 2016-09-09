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
        Database bd = new Database();
        private void User_HeSoCoBan_Load(object sender, EventArgs e)
        {
            dgv_HSCB.Columns[0].ReadOnly = true;
            
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

        private void dgv_HSCB_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgv_HSCB.CurrentRow;
            if (e.ColumnIndex == 2)
            {
                
                try
                {
                double    a = double.Parse(dr.Cells[2].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Bạn phải phải số", "Sửa thông tin hệ số lương ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    return;
                }
                string sql_update = "update HeSoCoBan set ChiSo = " + dr.Cells[2].Value.ToString() + " where ID = " + dr.Cells[0].Value.ToString() + "";
                bd.ExcuteNonQuery(sql_update);
                dgv_HSCB.DataSource = hscb.Load_HSCB();
                MessageBox.Show("Cập nhật thông tin thành công", "Sửa thông tin hệ số lương ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            if (e.ColumnIndex == 1)
            {
                DataTable dt_check = bd.Excute("select * from HeSoCoBan where TenHeSo = N'"+dr.Cells[1].Value.ToString()+"'");
               if (dr.Cells[1].Value.ToString().CompareTo("")==0)// kiểm tra phải nhập
               {
                   MessageBox.Show("Bạn chưa nhập hệ số phụ cấp", "Sửa thông tin hệ số lương ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                   return;
               }

                if (dt_check.Rows.Count > 0) // nếu đã có tên trong database rồi
                {
                    MessageBox.Show("Đã tồn tại hệ số phụ cấp" + ":/n "+dr.Cells[1].Value.ToString()+" trong hệ thống", "Sửa thông tin hệ số lương ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    return;
                }
                else // chưa có
                {
                    string sql_update = "update HeSoCoBan set TenHeSo = N'" + dr.Cells[1].Value.ToString() + "' where ID = " + dr.Cells[0].Value.ToString() + "";
                    bd.ExcuteNonQuery(sql_update);
                    dgv_HSCB.DataSource = hscb.Load_HSCB();
                    MessageBox.Show("Cập nhật thông tin thành công", "Sửa thông tin hệ số lương ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
               

            }
        }

        private void txt_ChiSo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
