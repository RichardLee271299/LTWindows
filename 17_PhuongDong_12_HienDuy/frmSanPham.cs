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
             ds = c.LayDuLieu(sql);
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
        int flag = 0;
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            HienThiDuLieu("select * from SanPham", dgvDanhSach);
            HienThiTextBox(ds, 0);
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
        string phatSinhMa(DataSet d, string kytu)
        {
            string ma = "";
            int sodong = d.Tables[0].Rows.Count;
            sodong++;
            if (sodong < 10)
                ma = kytu + "0" + sodong.ToString();
            else
                ma = kytu + sodong.ToString();
            return ma;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            clearTextBox();
            txtMaSP.Text = phatSinhMa(ds, "A");
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            txtMaSP.ReadOnly = true;
            flag = 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            string sql = "";
            if (flag == 1)
            {
                sql = "insert into SanPham values('" + txtMaSP.Text + "',N'" + txtTenSP.Text + "',N'" + txtSoLuong.Text + "'," + txtGiaNhap.Text + "," + txtGiaBan.Text + ")";

            }
            else if (flag == 2)
            {
                sql = "update SanPham set MaSP = '" + txtMaSP.Text + "', TenSP = N'" + txtTenSP.Text + "',SoLuongTon = N'" + txtSoLuong.Text + "' where MaSP = '" + txtMaSP.Text + "'";

            }
            else
            {
                sql = "delete from SanPham where MaSP = '" + txtMaSP.Text + "'";

            }
            if (c.CapNhatDuLieu(sql) != 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                frmSanPham_Load(sender, e);
            }


            flag = 0;
        }

        void clearTextBox()
        {
            txtTenSP.Clear();
            txtGiaBan.Clear();
            txtGiaNhap.Clear();
            txtSoLuong.Clear();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            txtTenSP.ReadOnly = false;
            txtGiaNhap.ReadOnly = false;
            txtGiaBan.ReadOnly = false;
            flag = 2;
            MessageBox.Show("Bạn có muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            MessageBox.Show("Bạn có muốn hủy?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSach.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xuly_Chucnang(false);
            flag = 3;
            MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void txtTenSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
