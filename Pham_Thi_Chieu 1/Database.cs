using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Pham_Thi_Chieu
{
    class Database
    {
       // public static string Sever = @"MAYTINH-2TJJG6M\SQLEXPRESS";
        public static string Sever = @".\SQLEXPRESS";
        public static string Data = "QL_LuongNV_DHM";
        public static bool intergratedMode = true;
        public static string Username = "";
        public static string Password = "";
        public SqlConnection sqlcon = new SqlConnection();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader sqlda = null;
        SqlCommand sqlcmd = new SqlCommand();
        public Database()
        {
            string sqlconn;
            if (intergratedMode == true)
            {
                sqlconn = "server=" + Sever + ";Database=" + Data + ";Integrated Security=True";
            }
            else
            {
                sqlconn = "server=" + Sever + ";Database=" + Data + ";Integrated Security=True" + ";uid=" + Username + ";pwd=" + Password;
            }
            sqlcon = new SqlConnection(sqlconn);

        }
        public DataTable Excute(string sql)
        {
            da = new SqlDataAdapter(sql, sqlcon);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public object ExcuteSacala(string sql)
        {
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            object ob = sqlcom.ExecuteScalar();            
            sqlcon.Close();
            return ob;
        }
        public void ExcuteNonQuery(string sql)
        {
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcom.Dispose();
            sqlcon.Close();
        }
        public void ExcuteNonQuery(string sql, SqlParameter prm)
        {
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            sqlcom.Parameters.Add(prm);
            sqlcom.ExecuteNonQuery();
            sqlcom.Dispose();
            sqlcon.Close();
        }
        public void Update(string sql, DataTable table)
        {
            da = new SqlDataAdapter(sql, sqlcon);
            SqlCommandBuilder combuid = new SqlCommandBuilder(da);
            da.Update(table);
        }
        public void Update()
        {
            da.Update(ds);
        }

        public DataTable Load_proc(string sql)
        {
            DataTable dt_loadproc = new DataTable ();
            try
            {
                sqlcon = new SqlConnection();
                sqlcon.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = sql;
                sqlda = sqlcmd.ExecuteReader();
                dt_loadproc.Load(sqlda);
                sqlda.Close();               

            }
            catch
            {

            }
            return dt_loadproc;
        }

        public DataTable Load_proc_parameter(string procname)
        {
            DataTable dt_loadproc = new DataTable();
            try
            {
                sqlcon = new SqlConnection();
                sqlcon.Open();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                //sqlcmd.CommandText = sql;
                sqlda = sqlcmd.ExecuteReader();
                dt_loadproc.Load(sqlda);
                sqlda.Close();

            }
            catch
            {

            }
            return dt_loadproc;
        }





    }
}
