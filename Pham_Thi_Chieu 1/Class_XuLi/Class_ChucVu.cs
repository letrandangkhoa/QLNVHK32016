using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Pham_Thi_Chieu.Class_XuLi
{
    class Class_ChucVu
    {
        Database DB = new Database();

        #region Load thông tin phòng ban
        public DataTable LoadChucVu()
        {
            string sql = "select * from ChucVu";
            return DB.Excute(sql);
        }
        #endregion

        #region Thêm chức vụ
        public  void ChucVu_Them(string tenchucvu,string mota)
        {
            string sql = "insert into ChucVu values (N'" + tenchucvu + "',N'" + mota.ToString() + "')";
            DB.ExcuteNonQuery(sql);
        }
        #endregion

        #region Xóa chức vụ
        public bool ChucVu_Xoa(string ID)
        {
            try
            {
                string sql = "delete ChucVu where ID='" + ID + "'";
                DB.ExcuteNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region sửa thông tin chức vụ
        public void SuaThongTinChucVu(int id, string TenChucVu, string MoTa)
        {
            string sql = "update ChucVu set Ten_CV=N'" + TenChucVu + "',MoTa=N'" + MoTa + "' WHERE ID='" + id + "";
            DB.ExcuteNonQuery(sql);
        }
        #endregion
    }
}
