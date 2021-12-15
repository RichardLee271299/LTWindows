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
    public partial class frmSanPham : Form
    {
        DataSet ds = new DataSet();
        public frmSanPham()
        {
            InitializeComponent();
        }

        clsQuanLyKhachSan c = new clsQuanLyKhachSan();

        void HienThiDuLieu(String sql,DataGridView dgs)
        {
            DataSet ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        void HienThiTextBox(DataSet d, int vt)
        {
            txtMaSP.Text = d.Tables[0].Rows[vt]["MaSP"].ToString();
            txtTenSP.Text = d.Tables[0].Rows[vt]["TenSp"].ToString();
            txtGiaBan.Text = d.Tables[0].Rows[vt]["GiaBan"].ToString();
            txtSoLuong.Text = d.Tables[0].Rows[vt]["SoLuongTon"].ToString();
            txtGiaNhap.Text = d.Tables[0].Rows[vt]["GiaNhap"].ToString();
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            HienThiDuLieu("select * from SanPham", dgvDanhSach);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        } 
        void Xuly_Textbox(Boolean t)
        {
            txtMaSP.ReadOnly = t;
            txtGiaBan.ReadOnly = t;
            txtGiaNhap.ReadOnly = t;
            txtSoLuong.ReadOnly = t;
            txtTenSP.ReadOnly = t;
        }
        void Xuly_Chucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnHuy.Enabled = !t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
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
            txtTenSP.ReadOnly = false;
            txtGiaNhap.ReadOnly = false;
            txtGiaBan.ReadOnly = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSach.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);
        }
    }
}
