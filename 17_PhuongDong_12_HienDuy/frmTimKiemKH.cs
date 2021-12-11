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
    public partial class frmTimKiemKH : Form
    {
        public frmTimKiemKH()
        {
            InitializeComponent();
        }
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(cboTimKiem.SelectedIndex==-1)
            {
                MessageBox.Show("Vui lòng chọn loại tìm kiếm !");
            }
        }
        void VisibleKH(Boolean t)
        {
            lblNhapTuKhoa.Visible = t;
            txtTuKhoa.Visible = t;
        }
        private void frmTimKiemKH_Load(object sender, EventArgs e)
        {
            VisibleKH(false);
        }
        void HienThiDuLieu(String sql, DataGridView dgs)
        {
            DataSet ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            string sql;
            if(cboTimKiem.SelectedIndex==0)
            {
                string t = txtTuKhoa.Text;
                sql = "select * from KhachHang where MaKH like '%" + t + "%'";
            }
            else if (cboTimKiem.SelectedIndex == 1)
            {
                string t = txtTuKhoa.Text;
                sql = "select * from KhachHang where HoTen like '%" + t + "%'";
            }
            else if (cboTimKiem.SelectedIndex==3)
            {
                string t = txtTuKhoa.Text;
                sql = "select * from KhachHang where CMND like '%" + t + "%'";
            }
            else
            {
                string t = txtTuKhoa.Text;
                sql = "select * from KhachHang where SDT like '%" + t + "%'";
            }
            HienThiDuLieu(sql, dgvDanhSach);
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTimKiem.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại tìm kiếm!");
            }
            else
            {
                VisibleKH(true);
            }
        }
    }
}
