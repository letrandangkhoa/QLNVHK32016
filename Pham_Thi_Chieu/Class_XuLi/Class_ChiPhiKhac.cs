using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Pham_Thi_Chieu.Class_XuLi
{
    class Class_ChiPhiKhac
    {
        Database db = new Database();
        DataTable dt;

        #region Load thông tin lên DataGridView
        public DataTable Load_CPK(int id)
        {
            string sql = "select * from ChiPhiKhac Where ID_NhanVien = " + id;
            return db.Excute(sql);

        }

        public DataTable Load_CPK(int mm, int yyyy)
        {
            string sql = "Select * From ChiPhiKhac where MONTH(ThoiGian) = " + mm + " AND YEAR(ThoiGian) = " + yyyy + "";
            return db.Excute(sql);

        }

        #endregion

        #region Thêm Chi phí Khác
        public bool TienThuongThem(int id_nv, int chiPhi, DateTime dt, string moTa)
        {
            try
            {
                string sql = "insert into ChiPhiKhac values ( " + id_nv + ", " + chiPhi + ",N'" + dt.ToString("DD/MM/YYYY") + "',N'" + moTa + "')";
                db.ExcuteNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion
    }
}
