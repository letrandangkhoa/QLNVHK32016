using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Pham_Thi_Chieu.Class_XuLi
{
    class PhuCap
    {
        Database db_pc = new Database();
        Database db_nv = new Database();
        DataTable dt;

        #region Load thông tin lên DataGridView
        public DataTable Load_PhuCap()
        {
            string sql = "select * from PhuCap";
            return db_pc.Excute(sql);
        }

        public DataTable Load_PhuCapNV()
        {
            string sql = "select * from PhuCap_NhanVien";
            return db_nv.Excute(sql);
        }

        public DataTable Load_TongPhuCapNV()
        {
            string sql = "select pc_nv.ID_NhanVien, SUM(pc.MucPhuCap) From PhuCap pc, PhuCap_NhanVien pc_nv where pc.ID = pc_nv.PhuCap GROUP BY pc_nv.ID_NhanVien";
            return db_nv.Excute(sql);
        }

        #endregion

        #region Update

        public bool Update_PCNV()
        {
            try
            {
                db_nv.Update();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update_PC()
        {
            try
            {
                db_pc.Update();
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
