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
    public partial class frmGiaoDienChinh : Form
    {
        public frmGiaoDienChinh()
        {
            InitializeComponent();
        }

        private void mnuNhapSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuNhapLoaiSanPham_Click(object sender, EventArgs e)
        {
            frmLoaiPhong frm = new frmLoaiPhong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void nhậpDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDichVu frm = new frmDichVu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTimKiemKhacHang_Click(object sender, EventArgs e)
        {
            frmTimKiemKH frm = new frmTimKiemKH();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTimKiemPhong_Click(object sender, EventArgs e)
        {
            frmTimKiemPhong frm = new frmTimKiemPhong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuTimKiemSanPham_Click(object sender, EventArgs e)
        {
            frmTimKiemSanPham frm = new frmTimKiemSanPham();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuQuanLyPhong_Click(object sender, EventArgs e)
        {
            frmPhong frm = new frmPhong();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuDatPhong_Click(object sender, EventArgs e)
        {
            frmDatPhong frm = new frmDatPhong();
            frm.MdiParent = this;
            frm.Show();
        }
        
    }
}
