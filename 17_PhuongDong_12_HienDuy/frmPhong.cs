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
        DataSet dsLoaiPhong = new DataSet(); 
          void HienThiDuLieu(String sql,DataGridView dgs, ref DataSet ds)
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
              else if (LoaiPhong.ToLower() == "vip")
                  cboLoaiPhong.SelectedIndex = 1;
              else
                  cboLoaiPhong.SelectedIndex = 2;
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
            HienThiDuLieu("select Phong.MaPhong,LoaiPhong,LoaiPhong.Gia,N'Tình Trạng' = case when TinhTrang='1' then N'Đã thuê' else N'Trống' end  from Phong inner join LoaiPhong on Phong.MaLoai = LoaiPhong.MaPhong", dgvDanhSach,ref ds);
            dsLoaiPhong = c.LayDuLieu("select * from LoaiPhong");
            HienThiComboBox(dsLoaiPhong, "LoaiPhong", "MaPhong", cboLoaiPhong);
            HienThiTextBox(ds, 0);
        }
        string phatSinhMa(DataSet d, string kytu)
        {
            string ma = "";
            int sodong = d.Tables[0].Rows.Count;
            sodong++;
            if (sodong < 10)
                ma = kytu + "0" + sodong.ToString();
            else
                ma = kytu + sodong.ToString();
            return ma;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            cboTinhTrang.SelectedIndex = 0;
            txtMaPhong.ReadOnly = true;
            txtMaPhong.Text = phatSinhMa(ds, "PH");
            txtGiaPhong.ReadOnly = true;
            flag = 1;
        }
        int flag = 0;
        void HienThiComboBox(DataSet ds, string ten, string ma, ComboBox c)
        {
            c.DataSource = ds.Tables[0];
            c.DisplayMember = ten;
            c.ValueMember = ma;
            c.SelectedIndex = 0;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            int tinhtrang;
            if ((string)cboTinhTrang.Items[cboTinhTrang.SelectedIndex] == "Trống")
                tinhtrang = 0;
            else
                tinhtrang = 1;

          
            string sql = "";
            if (flag == 1)
            {

                sql = "insert into Phong values('" + txtMaPhong.Text+ "','" + cboLoaiPhong.SelectedValue +  "'," + tinhtrang + ")";


            }
            else if (flag == 2)
            {
                sql = "update Phong set MaPhong = '" + txtMaPhong.Text + "', MaLoai = '" + cboLoaiPhong.SelectedValue + "',TinhTrang = " + tinhtrang + " where MaPhong = '" + txtMaPhong.Text + "'";

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiPhong.Items[cboLoaiPhong.SelectedIndex] == "Thường")
                txtGiaPhong.Text = "120000";
            else if (cboLoaiPhong.Items[cboLoaiPhong.SelectedIndex] == "Vip")
                txtGiaPhong.Text = "240000";
            else
                txtGiaPhong.Text = "460000";
        }
    }
}
