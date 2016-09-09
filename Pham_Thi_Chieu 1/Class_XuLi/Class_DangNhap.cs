using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Pham_Thi_Chieu.Class_XuLi
{
    class Class_DangNhap
    {
        Database db = new Database();
        DataTable dt;
        #region Form đăng nhập
        #region Kiểm tra thông tin đăng nhập
        public bool Login_DangNhap(string TenDN, string MatKhau)
        {
            string sql = "select * from User_Admin1 where UserName='" + TenDN + "' and Pass='" + MatKhau + "'";
            dt = db.Excute(sql);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #endregion

        #region Đổi Mật Khẩu
        public bool DoiMatKhau(string id, string pass)
        {
            try
            {
                string sql = "update User_Admin1 set Pass= N'" + pass + "' where UserName = '" + id + "'";
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
