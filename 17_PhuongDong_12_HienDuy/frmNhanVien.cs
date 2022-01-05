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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        int flag = 0;
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();
        DataSet ds = new DataSet();
        void HienThiDuLieu(String sql, DataGridView dgs)
        {
            ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        void HienThiTextBox(DataSet d, int vt)
        {
            txtHoTen.Text = d.Tables[0].Rows[vt]["HoTen"].ToString();
            txtMaNv.Text = d.Tables[0].Rows[vt]["MaNV"].ToString();
            txtDiaChi.Text = d.Tables[0].Rows[vt]["DiaChi"].ToString();
            txtSoCMND.Text = d.Tables[0].Rows[vt]["CMND"].ToString();
            txtSoDienThoai.Text = d.Tables[0].Rows[vt]["SDT"].ToString();
            string TinhTrang = d.Tables[0].Rows[vt]["TinhTrang"].ToString();
            if (TinhTrang.ToLower() == "Đi Làm")
                cboTinhTrang.SelectedIndex = 1;
            else
                cboTinhTrang.SelectedIndex = 0;
            string QuyenHan = d.Tables[0].Rows[vt]["QuyenHan"].ToString();
            if (QuyenHan.ToLower() == "Nhân Viên")
                cboQuyenHan.SelectedIndex = 1;
            else
                cboQuyenHan.SelectedIndex = 0;
            string GioiTinh = d.Tables[0].Rows[vt]["GioiTinh"].ToString();
            if (GioiTinh.ToLower() == "Nam")
                cboGioiTinh.SelectedIndex = 1;
            else
                cboGioiTinh.SelectedIndex = 0;

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        void Xuly_Textbox(Boolean t)
        {
            txtMaNv.ReadOnly = t;
            txtHoTen.ReadOnly = t;
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            HienThiDuLieu("select * from NhanVien", dgvDanhSachNhanVien);
        }

        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSachNhanVien.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            txtMaNv.Text = phatSinhMa(ds, "NV").ToString();
            txtMaNv.ReadOnly = true;
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            flag = 1;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            int tinhtrang;
            if ((string)cboTinhTrang.Items[cboTinhTrang.SelectedIndex] == "Hoạt động")
                tinhtrang = 1;
            else
                tinhtrang = 0;
            string sql = "";
            if (flag == 1)
            {
                sql = "insert into NhanVien values ('" + txtMaNv.Text + "',N'" + txtHoTen.Text + "','"+ txtSoCMND.Text +"',N'"+ txtDiaChi.Text + "','"+ txtSoDienThoai.Text +"',"+ tinhtrang + ",N'"+ cboGioiTinh.Items[cboGioiTinh.SelectedIndex] + "',N'" +cboQuyenHan.Items[cboQuyenHan.SelectedIndex] +"')";

            }
            else if (flag == 2)
            {
                sql = "update NhanVien set MaNv = '" + txtMaNv.Text + "', HoTen = N'" + txtHoTen.Text + "', TinhTrang = " + tinhtrang + ", SDT = '" + txtSoDienThoai.Text + "', CMND = '" + txtSoCMND.Text + "',DiaChi= N'" + txtDiaChi.Text + "', GioiTinh = N'" + cboGioiTinh.Items[cboGioiTinh.SelectedIndex] + "', QuyenHan = N'" + cboQuyenHan.Items[cboQuyenHan.SelectedIndex] + "' where MaNv = '" + txtMaNv.Text + "'";

            }
            else
            {
                sql = "delete from NhanVien where MaNv = '" + txtMaNv.Text + "'";

            }
            if (c.CapNhatDuLieu(sql) != 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                frmNhanVien_Load(sender, e);
            }


            flag = 0;

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(false);
            txtMaNv.ReadOnly = false;
            flag = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xuly_Chucnang(false);
            flag = 3;
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
        }
    }
}
