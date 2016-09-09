using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Pham_Thi_Chieu.Class_XuLi
{
    class Class_HeSoCoBan
    {
        Database db = new Database();
        DataTable dt;

        #region Load thông tin lên DataGridView
        public DataTable Load_HSCB()
        {
            string sql = "select * from HeSoCoBan";
            return db.Excute(sql);

        }
        #endregion
        #region Cập nhật thông tin
        public bool Update()
        {
            try
            {
                db.Update();
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
