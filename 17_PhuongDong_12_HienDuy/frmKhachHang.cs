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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();

        void HienThiDuLieu(String sql, DataGridView dgs)
        {
            DataSet ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void Xuly_Textbox(Boolean t)
        {
            txtMaPhong.ReadOnly = t;
            txtMaKH.ReadOnly = t;
            txtHoTen.ReadOnly = t;
            txtNgayDen.ReadOnly = t;
            txtSoCMND.ReadOnly = t;
            txtSoDienThoai.ReadOnly = t;
            txtDiaChi.ReadOnly = t;
        }

        void Xuly_Chucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnHuy.Enabled = !t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            HienThiDuLieu("select * from KhachHang", dgvDanhSachKhachHang);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
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
            txtMaKH.ReadOnly = false;            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
