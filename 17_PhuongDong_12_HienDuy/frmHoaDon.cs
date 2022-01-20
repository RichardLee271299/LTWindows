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
        DataSet dsLoaiDV = new DataSet();
        int flag = 0;
        string makh;
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
            btnAdd.Enabled = false;
            Xuly_Chucnang(true);
            HienThiDuLieu("select MaHD,HoaDon.MaKH,KhachHang.SDT,DatPhong.MaPH,MaNV,NgayTao,DatPhong.SoDem,ThanhTien,N'TrangThai' = case when HoaDon.TrangThai='1' then N'Đã thanh toán' else N'Chưa thanh toán' end from HoaDon inner join KhachHang on HoaDon.MaKH = KhachHang.MaKH inner join DatPhong on HoaDon.MaKH = DatPhong.MaKH ORDER BY MaHD ASC", dgvHD, ref ds);
            
        }
        void HienThiComboBox(DataSet ds, string ten, string ma, ComboBox c)
        {
            c.DataSource = ds.Tables[0];
            c.DisplayMember = ten;
            c.ValueMember = ma;
            c.SelectedIndex = -1;
        }
        void Xuly_Chucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnHuy.Enabled = !t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
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
            lblGia.Text = "";
            txtSoLuong.Clear();
            txtKhuyenMai.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            cleartextbox();
            btnAdd.Enabled = true;
           lblMaHD.Text = phatSinhMa(ds, "HD");
           dgvCTHD.DataSource = null;
           dgvCTHD.Rows.Clear();
           taocot_cthd();
           flag = 1;
           Xuly_Chucnang(false);
        }
        void taocot_cthd()
        {
            dgvCTHD.Columns.Add("MaDV", "Mã DV");
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
                string sql = "";
                if (flag == 1)
                {
                    sql = "insert HoaDon values ('" + lblMaHD.Text + "','" + makh + "','" + cboNhanVien.SelectedValue + "','" + dtpNgayLapHD.Value + "'," + lblTongTien.Text + "," + cboTrangThai.SelectedIndex + ")";
                }
                if (c.CapNhatDuLieu(sql) != 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông Báo");
                    DataSet dsHoaDon = c.LayDuLieu("Select * from HoaDon");
                    dgvHD.DataSource = dsHoaDon.Tables[0];

                    //CTHD
                    for (int i = 0; i < dgvCTHD.Rows.Count - 1; i++)
                    {
                        string madv = dgvCTHD.Rows[i].Cells[0].Value.ToString();
                        string gia = dgvCTHD.Rows[i].Cells[1].Value.ToString();
                        string sl = dgvCTHD.Rows[i].Cells[2].Value.ToString();
                        string gg = dgvCTHD.Rows[i].Cells[3].Value.ToString();
                        string tt = dgvCTHD.Rows[i].Cells[4].Value.ToString();

                        string s = "insert into ChiTietHoaDon values ('"+ lblMaHD.Text + "','" + madv + "'," + gia + "," + sl + "," + gg + "," + tt + ")";
                        if (c.CapNhatDuLieu(s) != 0)
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông Báo");
                        }
                    }
                    frmHoaDon_Load(sender, e);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
         float tongtien = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string km;
            float tt = 0;
            string[] gia = lblGia.Text.Split(new char[] { '.' });
            if (txtKhuyenMai.Text == "")
                km = "0";
            else
                km =txtKhuyenMai.Text;
            tt = int.Parse(gia[0]) * int.Parse(txtSoLuong.Text) - int.Parse(km);  
            tongtien += tt;
            lblTongTien.Text = tongtien.ToString();
            string ctkm;
            if (txtKhuyenMai.Text == "")
                ctkm = "0";
            else
               ctkm = txtKhuyenMai.Text;
            object[] t = { cboTenDV.SelectedValue.ToString(), lblGia.Text, txtSoLuong.Text, ctkm,tt.ToString() };
            dgvCTHD.Rows.Add(t);
        }

        private void txtSdt_KeyDown(object sender, KeyEventArgs e)
        {

          if(e.KeyCode == Keys.Enter)
          {
              if (txtSdt.Text != "")
              {
                  string sql = "select MaKH,HoTen from KhachHang where SDT ='" + txtSdt.Text + "'";
                  timkhachhang = c.LayDuLieu(sql);
                  if (timkhachhang.Tables[0].Rows.Count != 0)
                  {
                      lblTenKH.Text = timkhachhang.Tables[0].Rows[0]["HoTen"].ToString();
                      makh =timkhachhang.Tables[0].Rows[0]["MaKH"].ToString();
                  }
                  else
                      MessageBox.Show("Khách hàng không tồn tại!", "Thông Báo");
              }
              else
                  MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông Báo");
          }
        }
        Boolean loaidv = false;
        void xulyloaidv()
        {
            if(cboSuDungDv.SelectedIndex == 0)
            {
                dsLoaiDV = c.LayDuLieu("select * from DichVu");
                HienThiComboBox(dsLoaiDV, "TenDV", "MaDV", cboTenDV);
            }
            else if (cboSuDungDv.SelectedIndex == 1)
            {
                dsLoaiDV = c.LayDuLieu("select * from SanPham");
                HienThiComboBox(dsLoaiDV, "TenSp", "MaSP", cboTenDV);
            }
            else
            {
                dsLoaiDV = c.LayDuLieu("Select * from Phong where TinhTrang = 1");
                lblTen.Text = "Mã Phòng";
                HienThiComboBox(dsLoaiDV, "MaPhong", "MaPhong", cboTenDV);
            }
               
        }
        private void cboSuDungDv_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblGia.Text = "";
            txtKhuyenMai.Clear();
            txtSoLuong.Clear();
            xulyloaidv();
            loaidv = true;
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Xuly_Chucnang(false);
            flag = 2;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xuly_Chucnang(false);
            flag = 3;
        }
        void hienthigia()
        {
           if(loaidv)
           {
               if (cboSuDungDv.SelectedIndex == 0)
               {
                   string sql = "select Gia from DichVu where MaDV ='" + cboTenDV.SelectedValue.ToString() + "'";
                   DataSet dsgia = c.LayDuLieu(sql);
                   lblGia.Text = dsgia.Tables[0].Rows[0]["Gia"].ToString();
                   loaidv = false;
               }
               else if (cboSuDungDv.SelectedIndex == 1)
               {
                   string sql = "select GiaBan from SanPham where MaSP ='" + cboTenDV.SelectedValue.ToString() + "'";
                   DataSet dsgia = c.LayDuLieu(sql);
                   lblGia.Text = dsgia.Tables[0].Rows[0]["GiaBan"].ToString();
                   loaidv = false;
               }
               else
               {
                   string sql = "select Gia from Phong where MaPhong ='" + cboTenDV.SelectedValue.ToString() + "'";
                   DataSet dsgia = c.LayDuLieu(sql);
                   lblGia.Text = dsgia.Tables[0].Rows[0]["Gia"].ToString();
                   loaidv = false;
               }
           }
        }
        private void cboTenDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienthigia();
        }

        private void dgvCTHD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex>=1 && e.ColumnIndex<=3)
            {
                float gia ,km, tt;
                int sl;
                gia = float.Parse(dgvCTHD.CurrentRow.Cells[1].Value.ToString());
                km = float.Parse(dgvCTHD.CurrentRow.Cells[3].Value.ToString());
                sl = int.Parse(dgvCTHD.CurrentRow.Cells[2].Value.ToString());
                tt = gia * sl - km;
                dgvCTHD.CurrentRow.Cells[4].Value = tt.ToString();         
            }
            float tinhtongtien =0;
            for(int i = 0; i < dgvCTHD.Rows.Count-1; i++)
            {
                  tinhtongtien += float.Parse(dgvCTHD.Rows[i].Cells[4].Value.ToString());
            }
            lblTongTien.Text = tinhtongtien.ToString();
        }
    }
}
