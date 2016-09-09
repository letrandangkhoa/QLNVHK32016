using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace BaiTapNhom
{
    public partial class Quanlynhanvien : Form
    {
        string cnStr;
        SqlConnection cn;
        DataTable dt;
    
        public Quanlynhanvien()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cnStr = @"Data Source=KHOA-PC\SQLEXPRESS;Initial Catalog=QL_LuongNV_DHM;Integrated Security=True";
             cn = new SqlConnection(cnStr);
            dataGridView1.DataSource = GetEmployee();
           
        }
        private DataTable GetEmployee()
        {
            string sql = "Select * From NhanVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, cn);
            dt = new DataTable();
            da.Fill(dt);
            /*textBox1.DataBindings.Add("Text", dt, "ID");
            textBox2.DataBindings.Add("Text", dt, "Ten_NV");
            textBox3.DataBindings.Add("Text", dt, "NgaySinh");
            textBox4.DataBindings.Add("Text", dt, "DiaChi");
            textBox5.DataBindings.Add("Text", dt, "So_CMND");
            textBox6.DataBindings.Add("Text", dt, "Email");
            textBox7.DataBindings.Add("Text", dt, "BangCap");
            textBox8.DataBindings.Add("Text", dt, "ChucVu");
            textBox9.DataBindings.Add("Text", dt, "PhongBan");
            textBox10.DataBindings.Add("Text", dt, "NgayVaoLam");*/
            return dt;
        }
         
         private void Insert()
         {
             string ins = "Insert into NhanVien(DiaChi, Ten_NV,NgayVaoLam,NgaySinh,So_CMND ) values(@AR, @Name,@day,@dob,@so)";
             SqlCommand cmd = new SqlCommand(ins, cn);
             cmd.Parameters.Add("@AR", SqlDbType.NVarChar,200,"DiaChi");
             cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 200, "Ten_NV");
             cmd.Parameters.Add("@day", SqlDbType.Date,200,"NgayVaoLam");
             cmd.Parameters.Add("@dob", SqlDbType.Date, 200, "NgaySinh");
             cmd.Parameters.Add("@so", SqlDbType.NVarChar, 200, "So_CMND");
             SqlDataAdapter da = new SqlDataAdapter();
             da.InsertCommand = cmd;
             da.Update(dt);

         }
        
         private void Delete()
         {
             string del = "DELETE from NhanVien WHERE ID =@ID";
             SqlCommand cmd = new SqlCommand(del, cn);
             cmd.Parameters.Add("@ID", SqlDbType.Int, 4, "ID");
             SqlDataAdapter da = new SqlDataAdapter();
             da.DeleteCommand = cmd;
             da.Update(dt);

         }

         private void btn_Luu_Click(object sender, EventArgs e)
         {
            // Insert();
             DataRow newRow = dt.NewRow();
             //newRow["ID"] = textBox1.Text;
             newRow["Ten_NV"] = textBox2.Text;
             newRow["NgaySinh"] = textBox3.Text;
             newRow["DiaChi"] = textBox4.Text;
             newRow["So_CMND"] = textBox5.Text;
             newRow["Email"] = textBox6.Text;
             newRow["BangCap"] = textBox7.Text;
             newRow["ChucVu"] = textBox8.Text;
             newRow["PhongBan"] = textBox9.Text;
             newRow["NgayVaoLam"] = textBox10.Text;
             dt.Rows.Add(newRow);
             string ins = "Insert  NhanVien (DiaChi, Ten_NV,NgayVaoLam,NgaySinh,So_CMND,Email,BangCap,ChucVu,PhongBan ) values (@AR, @Name,@day,@dob,@so,@m,@b,@c,@p)";
             SqlCommand cmd = new SqlCommand(ins, cn);
             SqlDataAdapter da = new SqlDataAdapter();
             cmd.Parameters.Add("@AR", SqlDbType.NVarChar, 200, "DiaChi");
             cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 200, "Ten_NV");
             cmd.Parameters.Add("@day", SqlDbType.Date, 200, "NgayVaoLam");
             cmd.Parameters.Add("@dob", SqlDbType.Date, 200, "NgaySinh");
             cmd.Parameters.Add("@so", SqlDbType.NVarChar, 200, "So_CMND");
             cmd.Parameters.Add("@m", SqlDbType.NVarChar, 200, "Email");
             //cmd.Parameters.Add("@id", SqlDbType.Int, 4, "ID");
             cmd.Parameters.Add("@b", SqlDbType.Int, 200, "BangCap");
             cmd.Parameters.Add("@c", SqlDbType.Int, 200, "ChucVu");
             cmd.Parameters.Add("@p", SqlDbType.Int, 200, "PhongBan");
             da.InsertCommand = cmd;
             da.Update(dt);
         }

         private void btn_Xoa_Click(object sender, EventArgs e)
         {
             Delete();
         }

         private void bntthoat_Click(object sender, EventArgs e)
         {
             DialogResult = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
         }

         

         

         

        
       

         

         
         

         

        
         
    }
}
