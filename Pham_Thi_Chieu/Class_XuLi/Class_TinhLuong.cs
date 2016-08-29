using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Pham_Thi_Chieu.Class_XuLi
{
    public class Class_TinhLuong
    {
        Database db = new Database();
        DataTable dt;

        #region Load thông tin lên DataGridView
        public DataTable Load_TinhLuong()
        {
            string sql = "select lnv.ID, nv.Ten_NV, nv.So_CMND, lnv.LuongCoBan, lnv.Thuong, lnv.MucPhuCap, lnv.ChiPhiKhac, lnv.TongLuong, lnv.NgayTinhLuong, lnv.GhiChu, nv.HinhAnh from LuongNhanVien lnv, NhanVien nv, BangCap bc where lnv.ID_NhanVien = nv.ID and bc.ID = nv.BangCap";
            return db.Excute(sql);
        }
        public DataTable Load_TinhLuong(string CMND)
        {
            string sql = "select lnv.ID, nv.Ten_NV, nv.So_CMND, lnv.LuongCoBan, lnv.Thuong, lnv.MucPhuCap, lnv.ChiPhiKhac, lnv.TongLuong, lnv.NgayTinhLuong, lnv.GhiChu, nv.HinhAnh from LuongNhanVien lnv, NhanVien nv, BangCap bc where nv.So_CMND = '"+ CMND +"' AND lnv.ID_NhanVien = nv.ID and bc.ID = nv.BangCap";
            return db.Excute(sql);
        }
        public DataTable Load_TinhLuong(string CMND, DateTime dt)
        {
            string sql = "select lnv.ID, nv.Ten_NV, nv.So_CMND, lnv.LuongCoBan, lnv.Thuong, lnv.MucPhuCap, lnv.ChiPhiKhac, lnv.TongLuong, lnv.NgayTinhLuong, lnv.GhiChu, nv.HinhAnh from LuongNhanVien lnv, NhanVien nv, BangCap bc where nv.So_CMND = '" + CMND + "' AND lnv.ID_NhanVien = nv.ID and bc.ID = nv.BangCap AND YEAR(lnv.NgayTinhLuong) = " + dt.Year + " AND MONTH(lnv.NgayTinhLuong) = "+ dt.Month;
            return db.Excute(sql);
        }
        public DataTable Load_TinhLuong(DateTime dt)
        {
            string sql = "select lnv.ID, nv.Ten_NV, nv.So_CMND, lnv.LuongCoBan, lnv.Thuong, lnv.MucPhuCap, lnv.ChiPhiKhac, lnv.TongLuong, lnv.NgayTinhLuong, lnv.GhiChu, nv.HinhAnh from LuongNhanVien lnv, NhanVien nv, BangCap bc where lnv.ID_NhanVien = nv.ID and bc.ID = nv.BangCap AND YEAR(lnv.NgayTinhLuong) = " + dt.Year + " AND MONTH(lnv.NgayTinhLuong) = " + dt.Month;
            return db.Excute(sql);
        }
        #endregion
        #region Xóa Dữ liệu
        public bool Xoa(int ID)
        {
            try
            {
                string sql = "delete LuongNhanVien where ID=" + ID + "";
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
        public bool TinhLuong_Sua(int ID, int LuongCoBan, int SoNgayNghi, int Thuong, int Phat, int MucPhuCap, string TongLuong, string GhiChu)
        {
            try
            {
                string sql = "update LuongNhanVien set LuongCoBan='" + LuongCoBan + "',SoNgayNghi='" + SoNgayNghi + "',Thuong='" + Thuong + "',Phat='" + Phat + "',MucPhuCap='" + MucPhuCap + "',TongLuong='" + TongLuong + "',GhiChu='" + GhiChu + "' where ID=" + ID + "";
                db.ExcuteNonQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Thêm Luong Nhân Viên
        public bool ThemLuongNhanVien(int ID_NV, double LuongCB, double Thuong, double MucPC, double CPK, double TongLuong, DateTime Ngay, string GhiChu)
        {
            try
            {
                string sql = "insert into LuongNhanVien values (" + ID_NV + ", " + (int)LuongCB + ", " + (int)Thuong + ", " + (int)MucPC + ", " + (int)CPK + ", " + (int)TongLuong + ", '" + Ngay.ToString("MM-dd-yyyy") + "', N'" + GhiChu + "' )";
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
