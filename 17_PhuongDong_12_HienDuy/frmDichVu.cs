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
    public partial class frmDichVu : Form
    {
        public frmDichVu()
        {
            InitializeComponent();
        }

        clsQuanLyKhachSan c = new clsQuanLyKhachSan();

        void HienThiDuLieu(String sql, DataGridView dgs)
        {
            DataSet ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }

        void XuLy_Textbox(Boolean t)
        {
            txtMaDichVu.ReadOnly = t;
            txtTenDichVu.ReadOnly = t;
            txtGia.ReadOnly = t;
            txtSoLuong.ReadOnly = t;
        }
        void XuLy_ChucNang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            XuLy_ChucNang(true);
            XuLy_Textbox(true);
            HienThiDuLieu("select * from DichVu", dgvDanhSach);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XuLy_Textbox(false);
            XuLy_ChucNang(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XuLy_Textbox(false);
            XuLy_ChucNang(false);
            txtMaDichVu.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XuLy_ChucNang(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            XuLy_ChucNang(true);
            XuLy_Textbox(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XuLy_ChucNang(true);
            XuLy_Textbox(true);
        }
    }
}
