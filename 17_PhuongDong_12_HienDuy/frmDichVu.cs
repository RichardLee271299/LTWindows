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
        DataSet ds = new DataSet();
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();

        void HienThiDuLieu(String sql, DataGridView dgs)
        {
            ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        void HienThiTextBox(DataSet d, int vt)
        {

            txtMaDichVu.Text = d.Tables[0].Rows[vt]["MaDV"].ToString();
            txtTenDichVu.Text = d.Tables[0].Rows[vt]["MaDV"].ToString();
            txtSoLuong.Text = d.Tables[0].Rows[vt]["DonViTinh"].ToString();
            txtGia.Text = d.Tables[0].Rows[vt]["Gia"].ToString();
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

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSach.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);
        }
    }
}
