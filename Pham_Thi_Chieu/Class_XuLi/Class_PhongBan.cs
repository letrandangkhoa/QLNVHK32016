using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Pham_Thi_Chieu
{
    class Class_PhongBan
    {
       // DataTable DT;
        Database DB = new Database();

        #region Load danh sách phòng ban
        public DataTable Load_PB()
        {
            string sql = "select * from PhongBan"; 
           return DB.Excute(sql);
        }
        #endregion

        #region Kiểm tra thông tin phòng ban
        public bool kiemtra_PhongBan(string tenphong)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region thêm phòng ban
        public  void PhongBan_Them(string tenphongban,string mota)
        {
            string sql = "insert into PhongBan values (N'"+tenphongban+"',N'"+mota.ToString()+"')";
            DB.ExcuteNonQuery(sql);
        }
        #endregion

        #region xóa danh sách phòng
        public void PhongBan_Xoa(int ID)
        {
            string sql = "delete PhongBan where ID='" + ID + "'";
            DB.ExcuteNonQuery(sql);
        }
        #endregion

        #region sửa thông tin phòng ban
        public void SuaThongTinPhongBan(int id,string TenPhongBan,string MoTa)
        {
            string sql = "update PhongBan set Ten_PB=N'"+TenPhongBan+"',MoTa=N'"+MoTa+"' WHERE ID='"+id+"";
            DB.ExcuteNonQuery(sql);
        }
        #endregion
    }
}
