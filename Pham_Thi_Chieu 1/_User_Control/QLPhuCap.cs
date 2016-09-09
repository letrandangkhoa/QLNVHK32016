using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Pham_Thi_Chieu._User_Control
{
    public partial class QLPhuCap : UserControl
    {
        public QLPhuCap()
        {
            InitializeComponent();
        }
        #region Khai báo biên
        Database db = new Database();
        DataTable dt = new DataTable();
        SqlCommand sqlcommand = new SqlCommand();
        #endregion

        #region hàm xử  lý dữ liệu

                 #region ham load phong ban
        public void F_Load_Phong()
                {
                    string sql_Phong = "selecT ID, Ten_PB from PhongBan";
                    //cbb_phong.DataSource = db.Excute(sql_Phong);
                    cbb_phong.ValueMember = "ID" ;
                    cbb_phong.DisplayMember = "Ten_PB";
                    cbb_phong.DataSource = db.Excute(sql_Phong);

                }
        #endregion

                 #region Hàm load nhân viên
        public void F_Load_NV(int ID_PB)
        {
            string sql_NV = "select a.ID,a.Ten_NV from NhanVien a where  a.PhongBan = "+ID_PB+"";
            cbb_nhanvien.ValueMember = "ID";
            cbb_nhanvien.DisplayMember = "Ten_NV";
            cbb_nhanvien.DataSource = db.Excute(sql_NV);
        }
        #endregion

                 #region hàm load phụ cấp
                public void F_Load_PhuCap()
                   {
                       string sql_load_PhuCap = "select * from PhuCap";
                       dgv_phucap.DataSource = db.Excute(sql_load_PhuCap);

                        

                   }
                #endregion

                #region Hmà Load danh sách phụ cấp nhân viên
        
                public void F_PhuCap_NhanVien()
                {
                    db.sqlcon.Open();
                    sqlcommand = new SqlCommand("Proc_Get_PCNV", db.sqlcon);
                    sqlcommand.CommandType = CommandType.StoredProcedure;
                     sqlcommand.ExecuteNonQuery();
                    sqlcommand.Dispose();
                }
                #endregion


        #endregion

                #region form load
                private void QLPhuCap_Load(object sender, EventArgs e)
                {
                    F_Load_Phong();
                    F_Load_PhuCap();
                    F_PhuCap_NhanVien();
                }


        #endregion



        #region Khi chọn phòng ban thì load lên danh sách trong phòng ban đó
        private void cbb_phong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                F_Load_NV(int.Parse(cbb_phong.SelectedValue.ToString()));
            }
            catch
            {

            }
        }
        #endregion
    }
}

