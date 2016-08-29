using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pham_Thi_Chieu.Class_XuLi
{
    class Class_PhuCap
    {

        Database db = new Database();
        DataTable dt;

        #region Load thông tin lên DataGridView
        public DataTable Load_BangCap()
        {
            string sql = "select * from PhuCap";
            return db.Excute(sql);

        }
        #endregion

        #region Thêm phụ cấp
        public bool PhuCapThem(string tenPC, string MucPhuCap, string NgayNghi, string Mota)
        {
            try
            {
                string sql = "insert into BangCap values (N'" + tenPC + "',N'" + MucPhuCap + "',N'" + NgayNghi + "',N'" + Mota + "')";
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