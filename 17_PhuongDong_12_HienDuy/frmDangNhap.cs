using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace _17_PhuongDong_12_HienDuy
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();            
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection (@"data source =ADMIN; initial catalog= QLKhachSan; Integrated Security = true");
            try
            {
                conn.Open();
                string tk = txtTaiKhoan.Text;
                string mk = txtMatKhau.Text;
                string sql = ("select * from DangNhap where Username='"+tk+"' and Password ='"+ mk +"'");
                SqlCommand cmd = new SqlCommand(sql,conn);
                SqlDataReader dta= cmd.ExecuteReader();
                if (dta.Read()== true)
                {
                    this.Hide();
                    frmGiaoDienChinh frm = new frmGiaoDienChinh();
                    frm.Show();                    
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }
            
     
        }
    }
}
