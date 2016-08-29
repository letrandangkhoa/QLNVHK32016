using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Pham_Thi_Chieu.Class_XuLi
{
    class Class_NhanVien
    {
        Database db = new Database();
        DataTable dt;

        #region Load thông tin lên DataGridView
        public DataTable Load_NhanVien()
        {
            string sql = "select nv.*, cv.Ten_CV, pb.Ten_PB, bc.Ten_BC from NhanVien nv, ChucVu cv, PhongBan pb, BangCap bc where nv.ChucVu = cv.ID and nv.PhongBan = pb.ID and nv.BangCap = bc.ID";
            return db.Excute(sql);

        }
        #endregion

        #region Thêm nhân viên
        public bool NhanVienThem(string TenNV, DateTime NgaySinh, string DiaChi, string SoCMND, string Email, int BangCap, int ChucVu, int PhongBan, byte[] HinhAnh, DateTime NVL)
        {
            try
            {
                string sql = "insert into NhanVien values (N'" + TenNV + "',N'" + NgaySinh.ToString("MM-dd-yyyy") + "',N'" + DiaChi + "',N'" + SoCMND + "',N'" + Email + "',N'" + BangCap + "',N'" + ChucVu + "',N'" + PhongBan + "',@HinhAnh, '"+ NVL.ToString("MM-dd-yyyy") +"')";
                SqlParameter prm = new SqlParameter("@HinhAnh", SqlDbType.VarBinary, HinhAnh.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, HinhAnh);
                db.ExcuteNonQuery(sql, prm);
                return true;
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
                string sql = "delete NhanVien where ID=" + ID + "";
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
        public bool NhanVien_Sua(int ID, string TenNV, DateTime NgaySinh, string DiaChi, string SoCMND, string Email, int BangCap, int ChucVu, int PhongBan, byte[] HinhAnh, DateTime NVL)
        {
            try
            {
                string sql = "update NhanVien set Ten_NV= N'" + TenNV + "',NgaySinh='" + NgaySinh.ToString("MM-dd-yyyy") 
                    + "',DiaChi=N'" + DiaChi + "',So_CMND='" + SoCMND + "',Email='" + Email + "',BangCap='"
                    + BangCap + "',ChucVu='" + ChucVu + "',PhongBan='" + PhongBan + "' ,HinhAnh= @HinhAnh, NgayVaoLam = '"+ NVL.ToString("MM-dd-yyyy") +"' where ID=" + ID + "";
                SqlParameter prm = new SqlParameter("@HinhAnh", SqlDbType.VarBinary, HinhAnh.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, HinhAnh);
                db.ExcuteNonQuery(sql, prm);

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
