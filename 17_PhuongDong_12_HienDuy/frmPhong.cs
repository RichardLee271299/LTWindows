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
              int TinhTrang = (int)d.Tables[0].Rows[vt]["TinhTrang"];
              cboTinhTrang.SelectedIndex = TinhTrang;
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
            HienThiDuLieu("select Phong.MaPhong,Gia,LoaiPhong,TinhTrang from Phong inner join LoaiPhong on Phong.MaLoai = LoaiPhong.MaPhong ", dgvDanhSach);
      
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            cboTinhTrang.SelectedIndex = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(false);
            txtGiaPhong.ReadOnly = false;
           
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
    }
}
