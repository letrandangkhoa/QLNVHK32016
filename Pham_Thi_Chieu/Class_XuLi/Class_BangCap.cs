using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Pham_Thi_Chieu.Class_XuLi
{
    class Class_BangCap
    {
        Database db = new Database();
        DataTable dt;

        #region Load thông tin lên DataGridView
        public DataTable Load_BangCap()
        {
            string sql = "select * from BangCap";
           return db.Excute(sql);

        }
        #endregion

        #region Thêm bằng cấp
        public bool BangCapThem(string tenBC,string HeSoLuong,string NgayNghi,string Mota)
        {
                try
                {
                    string sql = "insert into BangCap values (N'"+tenBC+"',N'"+HeSoLuong+"',N'"+NgayNghi+"',N'"+Mota+"')";
                    db.ExcuteNonQuery(sql);
                    return true;
                }
                catch

                {
                    return false;
                }
            
        }
        #endregion

        #region Kiểm tra bằng cấp
        public bool BangCap_KiemTraTen(string tenBC)
        {
            try
            {
                string sql = "select a.ID from BangCap a where Ten_BC=N'" + tenBC + "'";
                dt = db.Excute(sql);
                if(dt.Rows.Count>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch
            {
                return false;
            }
            
        }
        #endregion

        #region Xóa Dữ liệu
        public bool Xoa(int ID)
        {
            try
            {
                string sql = "delete BangCap where ID="+ID+"";
                db.ExcuteNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        #endregion

        #region Cập nhật thông tin
        public bool BangCap_Sua(int ID, string tenBC,string HeSoLuong,string LuongNgayNghi,string Mota)
        {
            try
            {
                string sql = "update BangCap set Ten_BC='"+tenBC+"',HeSoLuong='"+HeSoLuong+"',LuongNgayNghi='"+LuongNgayNghi+"',Mota='"+Mota+"' where ID="+ID+"";
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
