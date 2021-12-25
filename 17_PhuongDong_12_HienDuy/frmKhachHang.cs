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
        DataSet ds = new DataSet();
        public frmKhachHang()
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
            txtHoTen.Text = d.Tables[0].Rows[vt]["HoTen"].ToString();           
            txtDiaChi.Text = d.Tables[0].Rows[vt]["DiaChi"].ToString();
            txtSoCMND.Text = d.Tables[0].Rows[vt]["CMND"].ToString();
            txtSoDienThoai.Text = d.Tables[0].Rows[vt]["SDT"].ToString();
            txtNgayDen.Text = d.Tables[0].Rows[vt]["NgayDen"].ToString();
            txtMaKH.Text = d.Tables[0].Rows[vt]["MaKH"].ToString();
            txtMaPhong.Text = d.Tables[0].Rows[vt]["MaPH"].ToString();
            string GioiTinh = d.Tables[0].Rows[vt]["GioiTinh"].ToString();
            if (GioiTinh.ToLower() == "Nam")
                cbmGioiTinh.SelectedIndex = 0;
            else
                cbmGioiTinh.SelectedIndex = 1;

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
        int flag = 0;
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
            flag = 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            string sql = "";
            if (flag == 1)
            {
                sql = "insert into khachHang values('" + txtMaKH.Text + "',N'" + txtHoTen.Text + "',N'" + txtSoCMND.Text + "'," + txtNgayDen.Text + "," + cbmGioiTinh.Text + "," + txtSoDienThoai.Text + "," + txtDiaChi.Text + "," + txtMaPhong.Text + ")";

            }
            else if (flag == 2)
            {
                sql = "update KhachHang set MaKH = '" + txtMaKH.Text + "', HoTen = N'" + txtHoTen.Text + "'GioiTinh = N'" + cbmGioiTinh.Text + "' where MaKH = '" + txtMaKH.Text + "'";

            }
            else
            {
                sql = "delete from KhachHang where MaDV = '" + txtMaKH.Text + "'";

            }
            if (c.CapNhatDuLieu(sql) != 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                frmKhachHang_Load(sender, e);
            }


            flag = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(false);
            txtMaKH.ReadOnly = false;
            flag = 2;
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

        private void dgvDanhSachKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSachKhachHang.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xuly_Chucnang(false);
            flag = 3;
        }

       
    }
}
