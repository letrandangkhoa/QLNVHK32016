using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Pham_Thi_Chieu._User_Control
{
    class ChucVu
    {
        Database DB = new Database();
        public DataTable LoadChucVu()
        {
            string sql = @"select * from ChucVu";
            return DB.Excute(sql);
        }
    }
}
