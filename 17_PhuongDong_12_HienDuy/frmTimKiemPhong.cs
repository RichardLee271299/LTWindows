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
    public partial class frmTimKiemPhong : Form
    {
        public frmTimKiemPhong()
        {
            InitializeComponent();
        }
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();
        private void frmTimKiemPhong_Load(object sender, EventArgs e)
        {
            VisibleKH(false);
            lblDaThue.Visible = false;
            lblTrong.Visible = false;
        }
        void VisibleKH(Boolean t)
        {
            lblNhapTuKhoa.Visible = t;
            txtTuKhoa.Visible = t;
        }

        void HienThiDuLieu(String sql, DataGridView dgs)
        {
            DataSet ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboTimKiem.SelectedIndex == 0)
            {
                string t = txtTuKhoa.Text;
                sql = "select * from Phong where MaPhong like '%" + t + "%'";
            }
            else if (cboTimKiem.SelectedIndex == 1)
            {
                string t = txtTuKhoa.Text;
                sql = "select Phong.MaPhong,Gia,LoaiPhong,TinhTrang from Phong inner join LoaiPhong on Phong.MaLoai = LoaiPhong.MaPhong where LoaiPhong like '%" + t + "%'";
            }
            else
            {
                string t = txtTuKhoa.Text;
                sql = "select * from Phong where TinhTrang like '%" + t + "%'";
               
            }
            HienThiDuLieu(sql, dgvDanhSach);
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTimKiem.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại tìm kiếm!");
            }
            if (cboTimKiem.SelectedIndex == 2)
            {
                lblDaThue.Visible = true;
                lblTrong.Visible = true;
            }
                
            else
            {
                VisibleKH(true);
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimKiemPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}
