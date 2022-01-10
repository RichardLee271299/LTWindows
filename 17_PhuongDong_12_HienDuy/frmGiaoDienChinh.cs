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
            this.CenterToScreen();
        }
        private void mnuNhapSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.Show();
        }

        private void mnuNhapLoaiSanPham_Click(object sender, EventArgs e)
        {
            frmLoaiPhong frm = new frmLoaiPhong();
            frm.Show();
        }

        private void nhậpDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDichVu frm = new frmDichVu();
            frm.Show();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
        }

        private void mnuTimKiemKhacHang_Click(object sender, EventArgs e)
        {
            frmTimKiemKH frm = new frmTimKiemKH();
            frm.Show();
        }

        private void mnuTimKiemPhong_Click(object sender, EventArgs e)
        {
            frmTimKiemPhong frm = new frmTimKiemPhong();
            frm.Show();
        }

        private void mnuTimKiemSanPham_Click(object sender, EventArgs e)
        {
            frmTimKiemSanPham frm = new frmTimKiemSanPham();
            frm.Show();
        }

        private void mnuQuanLyPhong_Click(object sender, EventArgs e)
        {
            frmPhong frm = new frmPhong();
            frm.Show();
        }

        private void mnuQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.Show();
        }

        private void QuanLyHoaDonDichVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon(this);
            this.Hide(); //ẩn form1
            frm.Show(); //sử dụng Show thôi
             
        }

        private void đặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatPhong frm = new frmDatPhong();
            frm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSuDungDichVu_Click(object sender, EventArgs e)
        {
            frmSuDungDichVu frm = new frmSuDungDichVu();
            frm.Show();
        }
        
    }
}
