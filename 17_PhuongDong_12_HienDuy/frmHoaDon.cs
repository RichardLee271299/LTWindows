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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon(frmGiaoDienChinh frm)
        {
            InitializeComponent();
            frm1 = frm;
            this.CenterToScreen();
        }
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();
        frmGiaoDienChinh frm1;
        DataSet timkhachhang = new DataSet();
        DataSet dsnhanvien = new DataSet();
        DataSet ds = new DataSet();
        int flag = 0;
        private void HoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm1.Show();
        }
        void HienThiDuLieu(String sql, DataGridView dgs,ref DataSet ds)
        {
            ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dsnhanvien = c.LayDuLieu("select * from NhanVien");
            HienThiComboBox(dsnhanvien, "HoTen", "MaNV", cboNhanVien);
            cboTrangThai.SelectedIndex = 0;
            HienThiDuLieu("select * from HoaDon ORDER BY MaHD ASC", dgvHD, ref ds);
            
        }
        void HienThiComboBox(DataSet ds, string ten, string ma, ComboBox c)
        {
            c.DataSource = ds.Tables[0];
            c.DisplayMember = ten;
            c.ValueMember = ma;
            c.SelectedIndex = -1;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtSdt.Text != "")
            {
                string sql = "select * from KhachHang where SDT ='" + txtSdt.Text + "'";
                timkhachhang = c.LayDuLieu(sql);
                if (timkhachhang.Tables[0].Rows.Count != 0)
                {
                    lblTenKH.Text = timkhachhang.Tables[0].Rows[0]["HoTen"].ToString();

                }
                else
                    MessageBox.Show("Khách hàng không tồn tại!", "Thông Báo");
            }
            else
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông Báo");
         }
        string phatSinhMa(DataSet d, string kytu)
        {
            int max = 0;
            int sodong = d.Tables[0].Rows.Count;
            if (sodong < 0)
            {
                return kytu + "01";
            }
            else if (sodong > 0 && sodong < 2)
            {
                return kytu + "02";
            }
            else
            {
                for (int i = 0; i < sodong - 1; i++)
                {
                    string row1 = d.Tables[0].Rows[i]["MaHD"].ToString();
                    int newrow1 = Convert.ToInt32(row1.Substring(2, 2));
                    string row2 = d.Tables[0].Rows[i + 1]["MaHD"].ToString();
                    int newrow2 = Convert.ToInt32(row2.Substring(2, 2));
                    if (newrow1 < newrow2)
                        max = newrow2;
                    else
                        max = newrow1;

                }
                string ma = "";
                sodong = max + 1;
                if (sodong < 10)
                    ma = kytu + "0" + sodong.ToString();
                else
                    ma = kytu + sodong.ToString();
                return ma;
            }
        }
        void cleartextbox()
        {
            lblTenKH.Text = "";
            txtSdt.Clear();
            cboNhanVien.SelectedIndex = -1;
            cboSuDungDv.SelectedIndex = -1;
            txtGia.Clear();
            txtSoLuong.Clear();
            txtKhuyenMai.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            cleartextbox();
           lblMaHD.Text = phatSinhMa(ds, "HD");
           flag = 1;
        }
        void taocot_cthd()
        {
            dgvCTHD.Columns.Add("TenDV", "Tên DV");
            dgvCTHD.Columns.Add("Gia", "Giá");
            dgvCTHD.Columns.Add("SoLuong", "Số Lượng");
            dgvCTHD.Columns.Add("KhuyenMai", "Khuyến Mãi");
            dgvCTHD.Columns.Add("ThanhTien", "Thành Tiền");
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSdt.Text == "" || lblTenKH.Text == "" || cboNhanVien.SelectedIndex == -1 || cboTrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
            }
            else
            {
                if(flag ==1)
                {
                    dgvCTHD.DataSource = null;
                    dgvCTHD.Rows.Clear();
                    taocot_cthd();
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
         float tongtien = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            float tt = 0;
            tt = int.Parse(txtGia.Text) * int.Parse(txtSoLuong.Text) - int.Parse(txtKhuyenMai.Text);
            tongtien += tt;
            lblTongTien.Text = tongtien.ToString();
            object[] t = { txtTenDV.Text, txtGia.Text, txtSoLuong.Text, txtKhuyenMai.Text,tt.ToString() };
            dgvCTHD.Rows.Add(t);
        }
    }
}
