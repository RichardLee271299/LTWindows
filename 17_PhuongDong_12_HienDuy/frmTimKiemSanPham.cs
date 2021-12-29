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
    public partial class frmTimKiemSanPham : Form
    {
        public frmTimKiemSanPham()
        {
            InitializeComponent();
        }
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboTimKiem.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại tìm kiếm !");
            }
        }
        void VisibleKH(Boolean t)
        {
            lblTuKhoa.Visible = t;
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
                sql = "select * from SanPham where MaSP like '%" + t + "%'";                
            }
            else if (cboTimKiem.SelectedIndex == 1)
            {
                string t = txtTuKhoa.Text;
                sql = "select * from SanPham where TenSP like '%" + t + "%'";                
            }
            else 
            {
                string t = txtTuKhoa.Text;
                sql = "select * from SanPham where SoLuongTon like '%" + t + "%'";
            }
            HienThiDuLieu(sql, dgvDanhSach);
        }

        private void frmTimKiemSanPham_Load_1(object sender, EventArgs e)
        {
            VisibleKH(false);
        }

        private void cboTimKiem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboTimKiem.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại tìm kiếm!");
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

        private void frmTimKiemSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }
    }
}
