using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17_PhuongDong_12_HienDuy
{
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
        }
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();
        DataSet ds = new DataSet();
          void HienThiDuLieu(String sql,DataGridView dgs)
        {
            ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }


          void HienThiTextBox(DataSet d, int vt)
          {
              txtMaPhong.Text = d.Tables[0].Rows[vt]["MaPhong"].ToString();
              txtGiaPhong.Text = d.Tables[0].Rows[vt]["Gia"].ToString();
              string TinhTrang = d.Tables[0].Rows[vt]["Tình Trạng"].ToString();
              if(TinhTrang.ToLower() == "hoạt động")
              {
                  cboTinhTrang.SelectedIndex = 0;
              }
              else
                  cboTinhTrang.SelectedIndex = 1;
              string LoaiPhong = d.Tables[0].Rows[vt]["LoaiPhong"].ToString();
              if(LoaiPhong.ToLower()=="thường")
                  cboLoaiPhong.SelectedIndex = 0;
              else
                  cboLoaiPhong.SelectedIndex = 1;

          }
       
        void Xuly_Textbox(Boolean t)
        {
            txtMaPhong.ReadOnly = t;
            txtGiaPhong.ReadOnly = t;
        }
         
        void Xuly_Chucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnHuy.Enabled = !t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }
        private void frmPhong_Load(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            HienThiDuLieu("select Phong.MaPhong,LoaiPhong,Gia,N'Tình Trạng' = case when TinhTrang='1' then N'Hoạt động' else N'Ngừng hoạt động' end  from Phong inner join LoaiPhong on Phong.MaLoai = LoaiPhong.MaPhong", dgvDanhSach);
      
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            cboTinhTrang.SelectedIndex = 0;
            flag = 1;
        }
        int flag = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            string sql = "";
            if (flag == 1)
            {
                sql = "insert into Phong values('" + txtMaPhong.Text + "',N'" + cboLoaiPhong.Text + "',N'" + txtGiaPhong.Text + "'," + cboTinhTrang.Text + ")";

            }
            else if (flag == 2)
            {
                sql = "update Phong set MaPhong = '" + txtMaPhong.Text + "', LoaiPhong = N'" + cboLoaiPhong.Text + "',TinhTrang = N'" + cboTinhTrang.Text + "' where MaPhong = '" + txtMaPhong.Text + "'";

            }
            else
            {
                sql = "delete from Phong where MaPhong = '" + txtMaPhong.Text + "'";

            }
            if (c.CapNhatDuLieu(sql) != 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                frmPhong_Load(sender, e);
            }


            flag = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(false);
            txtGiaPhong.ReadOnly = false;
            flag = 2;
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
        }

        private void dgvLoaiPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSach.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xuly_Chucnang(false);
            flag = 3;
        }
    }
}
