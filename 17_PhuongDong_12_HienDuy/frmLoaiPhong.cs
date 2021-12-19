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
    public partial class frmLoaiPhong : Form
    {
        DataSet ds = new DataSet();
        public frmLoaiPhong()
        {
            InitializeComponent();
        }

        clsQuanLyKhachSan c = new clsQuanLyKhachSan();

        void HienThiDuLieu(String sql, DataGridView dgs)
        {
            ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        void HienThiTextBox(DataSet d, int vt)
        {
            txtMaPH.Text = d.Tables[0].Rows[vt]["MaPhong"].ToString();
            string LoaiPhong = d.Tables[0].Rows[vt]["LoaiPhong"].ToString();
            txtGiaPhong.Text = d.Tables[0].Rows[vt]["Gia"].ToString();
            if (LoaiPhong.ToLower() == "thường")
                cmbLoaiPhong.SelectedIndex = 0;
            else
                cmbLoaiPhong.SelectedIndex = 1;

        }
        void Xuly_Textbox(Boolean t)
        {
            txtMaPH.ReadOnly = t;            
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
            txtMaPH.ReadOnly = false;   
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
        }

        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            HienThiDuLieu("select LoaiPhong.MaPhong,LoaiPhong.LoaiPhong,Gia from LoaiPhong inner join Phong on LoaiPhong.MaPhong = Phong.MaLoai", dgvDanhSach);            
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSach.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);
        }
    }
}
