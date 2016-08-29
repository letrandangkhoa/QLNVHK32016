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
using System.IO;
using System.Drawing.Imaging;
namespace Pham_Thi_Chieu._User_Control
{
    public partial class User_NhanVien : UserControl
    {
        public User_NhanVien()
        {
            InitializeComponent();
        }
        
        #region khai báo biên
        Class_NhanVien nv = new Class_NhanVien();
        Class_BangCap bc = new Class_BangCap();
        Class_ChucVu cv = new Class_ChucVu();
        Class_PhongBan pb = new Class_PhongBan();
        DataTable dt = new DataTable();
        DataTable dt_bc = new DataTable();
        DataTable dt_cv = new DataTable();
        DataTable dt_PB = new DataTable();

        bool coHieu = false;
        #endregion
         

        private void User_NhanVien_Load(object sender, EventArgs e)
        {
            dt_bc = bc.Load_BangCap();
            
            cmbBangCap.DataSource = dt_bc;
            cmbBangCap.DisplayMember = "Ten_BC";

            dt_cv = cv.LoadChucVu();
            cmbChucVu.DataSource = dt_cv;
            cmbChucVu.DisplayMember = "Ten_CV";
            dt_PB = pb.Load_PB();
            cmbPB.DataSource = dt_PB;
            cmbPB.DisplayMember = "Ten_PB";

            dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNhanVien.DataSource = nv.Load_NhanVien();
            

            
        }
        void setCtr()
        {
            txtTen.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtCMND.Text = "";
            ptbAvatar.Image = null;

        }
        bool KiemTraNhap()
        {
            if (string.IsNullOrEmpty(txtTen.Text) == true)
            {
                MessageBox.Show("Tên Không Được Trống", "Thông Báo");
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text) == true)
            {
                MessageBox.Show("Địa Chỉ Không Được Trống", "Thông Báo");
                return false;
            }
            if (string.IsNullOrEmpty(txtCMND.Text) == true)
            {
                MessageBox.Show("Só CMND Không Được Trống", "Thông Báo");
                return false;
            }
            if (dtpkNgaySinh.Value.Year >= DateTime.Now.Year)
            {
                MessageBox.Show("Ngày Sinh Không Hợp Lệ", "Thông Báo");
                return false;
            }

            return true;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            MemoryStream MmStr = new MemoryStream();
            byte[] Mpic = new byte[0];
            try
            {

                ptbAvatar.Image.Save(MmStr, ImageFormat.Png);

                Mpic = MmStr.ToArray();
            }
            catch
            {
                MessageBox.Show("Hình Ảnh Không Hợp Lệ", "Thông Báo");
                return;
            }
            try
            {

                if (KiemTraNhap() == false)
                    return;

                int id_bc = int.Parse(dt_bc.Rows[cmbBangCap.SelectedIndex][0].ToString());
                int id_cv = int.Parse(dt_cv.Rows[cmbChucVu.SelectedIndex][0].ToString());
                int id_pb = int.Parse(dt_PB.Rows[cmbPB.SelectedIndex][0].ToString());
                if (nv.NhanVienThem(txtTen.Text, dtpkNgaySinh.Value, txtDiaChi.Text, txtCMND.Text, txtEmail.Text, id_bc, id_cv, id_pb, Mpic, dtpkNgayVaoLam.Value))
                {
                    MessageBox.Show("Thêm Thành Công", "Thông Báo");
                    dgvNhanVien.DataSource = nv.Load_NhanVien();
                }
                else
                    MessageBox.Show("Thêm Thất Bại", "Thông Báo");
            }
            catch
            {
                MessageBox.Show("Thêm Thất Bại", "Thông Báo");
                return;
            }
            
        }

        int tiemKiemDataTable(DataTable dtb, string str, int indexColum)
        {
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                if (dtb.Rows[i][indexColum].ToString() == str)
                    return i;
            }
            return 0;
        }
        private void dgvChucVu_SelectionChanged(object sender, EventArgs e)
        {
            
            if (coHieu == true && dgvNhanVien.SelectedRows.Count > 0)
            {
                txtTen.Text = dgvNhanVien.SelectedCells[1].Value.ToString();
                dtpkNgaySinh.Value = (DateTime)dgvNhanVien.SelectedCells[2].Value;
                txtDiaChi.Text = dgvNhanVien.SelectedCells[3].Value.ToString();
                txtCMND.Text = dgvNhanVien.SelectedCells[4].Value.ToString();
                txtEmail.Text = dgvNhanVien.SelectedCells[5].Value.ToString();

                dtpkNgayVaoLam.Value = (DateTime)dgvNhanVien.SelectedCells[10].Value;

                cmbBangCap.SelectedIndex = tiemKiemDataTable(dt_bc, dgvNhanVien.SelectedCells[12].Value.ToString(), 1);
                cmbChucVu.SelectedIndex = tiemKiemDataTable(dt_cv, dgvNhanVien.SelectedCells[10].Value.ToString(), 1);
                cmbPB.SelectedIndex = tiemKiemDataTable(dt_PB, dgvNhanVien.SelectedCells[11].Value.ToString(), 1);
                try
                {
                    byte[] Mybyte = new byte[0];
                    Mybyte = (byte[])dgvNhanVien.SelectedCells[9].Value;

                    MemoryStream Mstr = new MemoryStream(Mybyte);
                    ptbAvatar.Image = Image.FromStream(Mstr);
                }
                catch
                {
                    return;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string str = openFileDialog1.FileName;
                try
                {
                    ptbAvatar.Image = Image.FromFile(str);
                }
                catch
                {
                    MessageBox.Show("Hình ảnh không hợp lệ", "Thông Báo");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (coHieu == false || dgvNhanVien.SelectedRows.Count < 0)
            {
                MessageBox.Show("Chọn Nhân Viên Cần Cập Nhật Trước", "Thông Báo");
                return;
            }
            if (KiemTraNhap() == false)
                return;

            MemoryStream MmStr = new MemoryStream();
            byte[] Mpic = new byte[0];
            try
            {

                ptbAvatar.Image.Save(MmStr, ImageFormat.Png);
                
                Mpic = MmStr.ToArray();
            }
            catch
            {
                MessageBox.Show("Hình Ảnh Không Hợp Lệ", "Thông Báo");
                return;
            }
            int id = int.Parse(dgvNhanVien.SelectedCells[0].Value.ToString());
            int id_bc = int.Parse(dt_bc.Rows[cmbBangCap.SelectedIndex][0].ToString());
            int id_cv = int.Parse(dt_cv.Rows[cmbChucVu.SelectedIndex][0].ToString());
            int id_pb = int.Parse(dt_PB.Rows[cmbPB.SelectedIndex][0].ToString());
            if (nv.NhanVien_Sua(id, txtTen.Text, dtpkNgaySinh.Value, txtDiaChi.Text, txtCMND.Text, txtEmail.Text, id_bc, id_cv, id_pb, Mpic, dtpkNgayVaoLam.Value))
            {
                MessageBox.Show("Update Thành Công", "Thông Báo");
                dgvNhanVien.DataSource = nv.Load_NhanVien();
            }
            else
                MessageBox.Show("Update Thất Bại", "Thông Báo");
            
            

        }

        private void dgvNhanVien_MouseDown(object sender, MouseEventArgs e)
        {
            coHieu = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (coHieu == false || dgvNhanVien.SelectedRows.Count < 0)
            {
                MessageBox.Show("Chọn Nhân Viên Cần Cập Nhật Trước", "Thông Báo");
                return;
            }
            try
            {
                if (nv.Xoa(int.Parse(dgvNhanVien.SelectedCells[0].Value.ToString())) == true)
                {
                    dgvNhanVien.DataSource = nv.Load_NhanVien();
                    MessageBox.Show("Xóa Thành Công", "Thông Báo");
                }
                else
                {
                    MessageBox.Show("Xóa Thất Bại", "Thông Báo");
                }
            }
            catch
            {
                MessageBox.Show("Xóa Thất Bại", "Thông Báo");
            }
        }
        
    }
}
