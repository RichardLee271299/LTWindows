using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _17_PhuongDong_12_HienDuy
{
    internal class clsQuanLyKhachSan
    {
        SqlConnection con = new SqlConnection();
        void ketnoi()
        {
            //DESKTOP-69QU9MT\SQLEXPRESS1
            //DESKTOP-TN19T8F
            con.ConnectionString = @"data source = DESKTOP-69QU9MT\SQLEXPRESS1; initial catalog= QLKhachSan; Integrated Security = true";
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
     
       public clsQuanLyKhachSan()
        {
           ketnoi();
        }
        public DataSet LayDuLieu(String sql)
       {
           DataSet ds = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter(sql,con);
           da.Fill(ds);
           return ds;
       }
    }
}
