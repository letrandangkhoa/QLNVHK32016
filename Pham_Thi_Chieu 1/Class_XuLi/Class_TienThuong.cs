using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Pham_Thi_Chieu.Class_XuLi
{
    class Class_TienThuong
    {
        Database db = new Database();
        DataTable dt;

        #region Load thông tin lên DataGridView
        public DataTable Load_TienThuong(int id, int mm, int yyyy)
        {
            string sql = "select * from TienThuong where ID_NhanVien = " + id + " AND MONTH(ThoiGian) = " + mm + " AND YEAR(ThoiGian) = " + yyyy;;
            return db.Excute(sql);

        }

        public DataTable Load_TienThuong(int mm, int yyyy)
        {
            string sql = "Select * From TienThuong where MONTH(ThoiGian) = "+ mm +" AND YEAR(ThoiGian) = "+ yyyy;
            return db.Excute(sql);

        }

        #endregion

        #region Thêm Tiền Thưởng
        public bool TienThuongThem(int id_nv, int chiPhi, DateTime dt, string moTa)
        {
                try
                {
                    string sql = "insert into TienThuong values ( " + id_nv + ", " + chiPhi + ",N'" + dt.ToString("DD/MM/YYYY") + "',N'" + moTa + "')";
                    db.ExcuteNonQuery(sql);
                    return true;
                }
                catch

                {
                    return false;
                }
            
        }
        #endregion

        #region Load thông tin lên DataGridView
        public int TongTienThuong(int id, int mm, int yyyy)
        {
            string sql = "select SUM(ChiPhi) from TienThuong where ID_NhanVien = " + id + " AND MONTH(ThoiGian) = " + mm + " AND YEAR(ThoiGian) = " + yyyy;
            return (int)db.ExcuteSacala(sql);

        }
        #endregion

    }
}
