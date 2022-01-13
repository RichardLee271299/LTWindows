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
    public partial class frmDatPhong : Form
    {
        public frmDatPhong(frmGiaoDienChinh frm)
        {
            InitializeComponent();
            frm1 = frm;
            this.CenterToScreen();
        }
        frmGiaoDienChinh frm1;
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();
        DataSet ds = new DataSet();
        DataSet dsLoaiPhong = new DataSet();
        DataSet dsPhong = new DataSet();
        DataSet dsMoTa = new DataSet();
        DataSet dsKhachHang = new DataSet();
        Boolean t = false;
        Boolean dgvClick = false;
        string maphong;
        string makhachhang;
        Boolean loaiphong = false;
        int flag;
        void HienThiComboBox(DataSet ds, string ten, string ma, ComboBox c)
        {
            c.DataSource = ds.Tables[0];
            c.DisplayMember = ten;
            c.ValueMember = ma;
            c.SelectedIndex = -1;
        }
        void Xuly_Textbox(Boolean t)
        {
          
            
        }
         
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void tinhngay(DateTimePicker a, DateTimePicker b)
        {
           if(a.Value > b.Value)
           {
               MessageBox.Show("Ngày đến phải nhỏ hơn ngày trả!", "Thông báo");
               dtpNgayDen.Value = dtpNgayTra.Value;
           }
           else
           {
               DateTime ngayden = a.Value;
               DateTime ngaytra = b.Value;
               TimeSpan Time = ngaytra - ngayden;
               int TongSoNgay = Time.Days;
               lblSoDem.Text = TongSoNgay.ToString();
           }
        }
        void HienThiDuLieu(String sql, DataGridView dgs, ref DataSet ds)
        {
            ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
         void xulyMaPhong()
        {
            if (loaiphong && cboLoaiPhong.SelectedIndex != -1 && dgvClick == false)
            {
                string a = cboLoaiPhong.SelectedValue.ToString();
                dsPhong = c.LayDuLieu("select * from Phong where TinhTrang = 0 AND MaLoai ='" + a + "'");
                HienThiComboBox(dsPhong, "MaPhong", "MaPhong", cboMaPhong);
                
            }
        }
        private void frmDatPhong_Load(object sender, EventArgs e)
        {
           
            Xuly_Textbox(false);
            dsLoaiPhong = c.LayDuLieu("select * from LoaiPhong");
            HienThiComboBox(dsLoaiPhong, "LoaiPhong", "MaPhong", cboLoaiPhong);
            string sql = "select MaDatPhong,KhachHang.HoTen,KhachHang.GioiTinh,KhachHang.NgaySinh,KhachHang.DiaChi,LoaiPhong.LoaiPhong,MaPH,KhachHang.SDT,NgayNhan,NgayTra,N'TinhTrangDatPhong' = case when TinhTrangDatPhong='1' then N'Đã nhận' else N'Chưa nhận' end,CMND,Gia,MoTa from DatPhong inner join LoaiPhong on LoaiPhong.MaPhong = DatPhong.LoaiPhong inner join KhachHang on DatPhong.MaKH = KhachHang.MaKH inner join Phong on DatPhong.MaPH = Phong.MaPhong";
            HienThiDuLieu(sql, dgvDanhSach, ref ds);
            t = true;
            Xuly_Chucnang(true);
            xulyMaPhong();
        }

        void hienthimota()
        {
           if(cboMaPhong.SelectedIndex != -1)
           {
               string sql = "select Gia,MoTa from Phong where MaPhong ='" + cboMaPhong.SelectedValue.ToString() + "'";
               dsMoTa = c.LayDuLieu(sql);
               rtbMoTa.Text = dsMoTa.Tables[0].Rows[0]["MoTa"].ToString();
               lblGiaPhong.Text = dsMoTa.Tables[0].Rows[0]["Gia"].ToString();
           }
        }
        private void dtpNgayDen_ValueChanged(object sender, EventArgs e)
        {
            tinhngay(dtpNgayDen,dtpNgayTra);
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            tinhngay(dtpNgayDen, dtpNgayTra);
        }
      
        private void cboMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(t && dgvClick == false)
            if(cboMaPhong.SelectedIndex != -1)
                 hienthimota();
        }

        private void frmDatPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm1.Show();
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;  
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang kh = new frmKhachHang();
            kh.ShowDialog();
            if(kh.GT != null)
            {
                makhachhang = kh.KH;
                txtHoTen.Text = kh.HT;
                txtSoCMND.Text = kh.CM;
                txtSoDienThoai.Text = kh.DT;
                txtDiaChi.Text = kh.DC;
                dtpNgaySinh.Value = kh.NS;
                if (kh.GT.ToLower() == "nam")
                    cboGioiTinh.SelectedIndex = 0;
                else
                    cboGioiTinh.SelectedIndex = 1;
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtCmnd.Text != "")
            {
                 string sql = "select * from KhachHang where CMND ='" + txtCmnd.Text +"'";
                 dsKhachHang = c.LayDuLieu(sql);
                 if (dsKhachHang.Tables[0].Rows.Count != 0)
                 {
                     makhachhang = dsKhachHang.Tables[0].Rows[0]["MaKH"].ToString();
                     txtHoTen.Text = dsKhachHang.Tables[0].Rows[0]["HoTen"].ToString();
                     txtSoCMND.Text = dsKhachHang.Tables[0].Rows[0]["CMND"].ToString();
                     txtSoDienThoai.Text = dsKhachHang.Tables[0].Rows[0]["SDT"].ToString();
                     txtDiaChi.Text = dsKhachHang.Tables[0].Rows[0]["DiaChi"].ToString();
                     dtpNgaySinh.Value = (DateTime)dsKhachHang.Tables[0].Rows[0]["NgaySinh"];

                     //commbobox
                     HienThiComboBox(dsKhachHang, "GioiTinh", "GioiTinh", cboGioiTinh);
                     cboGioiTinh.SelectedIndex = 0;

                 }
                 else
                     MessageBox.Show("Khách hàng không tồn tại!", "Thông Báo");
            }
           
        }
        string phatSinhMa(DataSet d, string kytu)
        {
            int max = 0;
            int sodong = d.Tables[0].Rows.Count;
            if(sodong <0)
            {
                return kytu + "01";
            }
            else if (sodong < 2)
            {
                return kytu + "02";
            }
            else
            {
                for (int i = 0; i < sodong - 1; i++)
                {
                    string row1 = d.Tables[0].Rows[i]["MaDatPhong"].ToString();
                    int newrow1 = Convert.ToInt32(row1.Substring(2, 2));
                    string row2 = d.Tables[0].Rows[i + 1]["MaDatPhong"].ToString();
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
        void cleartextbox(Boolean t)
        {
            cboMaPhong.SelectedIndex = -1;

        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            flag = 1;
            Xuly_Chucnang(false);
            cleartextbox(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCmnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)               
            {
                e.Handled = true;
                MessageBox.Show("Bạn không được nhập chứ vào đây!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtHoTen_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtSoCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Bạn không được nhập chứ vào đây!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Bạn không được nhập chứ vào đây!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Bạn không được nhập Số vào đây!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

     /*   private void chkNhanPhong_CheckedChanged(object sender, EventArgs e)
        {

           if(chkNhanPhong.Checked)
           {
               string sql = "update Phong set TinhTrang = 1 where MaPhong = '" + maphong + "'";
               string sql2 = "update DatPhong set TinhTrang = 1 where MaPH = '" + maphong + "'";
               if (c.CapNhatDuLieu(sql) != 0 && c.CapNhatDuLieu(sql2) != 0)
               {
                   MessageBox.Show("Cập nhật thành công!", "Thông báo");
                   frmDatPhong_Load(sender, e);
               }
           }

        }*/
        void hienthitextbox(DataSet ds, int vt)
        {
            
            txtHoTen.Text = ds.Tables[0].Rows[vt]["HoTen"].ToString();
            txtSoCMND.Text = ds.Tables[0].Rows[vt]["CMND"].ToString();
            txtSoDienThoai.Text = ds.Tables[0].Rows[vt]["SDT"].ToString();
            txtDiaChi.Text = ds.Tables[0].Rows[vt]["DiaChi"].ToString();
            lblGiaPhong.Text = ds.Tables[0].Rows[vt]["Gia"].ToString();
            rtbMoTa.Text = ds.Tables[0].Rows[vt]["MoTa"].ToString();
            string gt = ds.Tables[0].Rows[vt]["GioiTinh"].ToString();
            maphong = ds.Tables[0].Rows[vt]["MaPH"].ToString();
            DataView dvmMaPhong = new DataView();
            dvmMaPhong.Table = ds.Tables[0];
            cboMaPhong.DataSource = dvmMaPhong;
            cboMaPhong.DisplayMember = "MaPH";
            cboMaPhong.ValueMember = "MaPH";
            dvmMaPhong.RowFilter = "MaPH ='" + maphong + "'";
            //Sodem
            dtpNgayDen.Value = (DateTime)ds.Tables[0].Rows[vt]["NgayNhan"];
            dtpNgayTra.Value = (DateTime)ds.Tables[0].Rows[vt]["NgayTra"];
            tinhngay(dtpNgayDen, dtpNgayTra);
            string loaiphong = ds.Tables[0].Rows[vt]["LoaiPhong"].ToString();
            //loai phong
            DataSet dsLoai = new DataSet();
            dsLoai = c.LayDuLieu("select * from LoaiPhong where LoaiPhong ='" + loaiphong + "'");
            HienThiComboBox(dsLoai, "LoaiPhong", "MaPhong", cboLoaiPhong);
            cboLoaiPhong.SelectedIndex = 0;
            if (gt.ToLower() == "nam")
               cboGioiTinh.SelectedIndex = 0;
            else
                cboGioiTinh.SelectedIndex = 1;
            dtpNgaySinh.Value = (DateTime)ds.Tables[0].Rows[vt]["NgaySinh"];
            string tt = ds.Tables[0].Rows[vt]["TinhTrangDatPhong"].ToString();
            if (tt.ToLower() == "chưa nhận")
                cboTinhTrang.SelectedIndex = 0;
            else
                cboTinhTrang.SelectedIndex = 1;
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvClick = true;
            int vt = dgvDanhSach.CurrentCell.RowIndex;
            hienthitextbox(ds, vt);

        
        }
        void Xuly_Chucnang(Boolean t)
        {
            btnDatPhong.Enabled = t;
            btnSua.Enabled = t;
            btnHuy.Enabled = !t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(flag == 1)
            {
                if (cboLoaiPhong.SelectedIndex == -1 || cboGioiTinh.SelectedIndex == -1 || cboMaPhong.SelectedIndex == -1 || txtHoTen.Text == "" || txtSoCMND.Text == "" || lblSoDem.Text == "" || txtSoDienThoai.Text == "" || txtDiaChi.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
                }
                else
                {

                    string sql = "insert into DatPhong values ('" + phatSinhMa(ds, "DP") + "','" + makhachhang + "',N'" + txtHoTen.Text + "','" + cboMaPhong.SelectedValue.ToString() + "','" + cboLoaiPhong.SelectedValue.ToString() + "','" + txtSoDienThoai.Text + "','" + dtpNgayDen.Value.ToString() + "','" + dtpNgayTra.Value.ToString() + "'," + cboTinhTrang.SelectedIndex + ")";
                    if (c.CapNhatDuLieu(sql) != 0)
                    {
                        MessageBox.Show("Cập nhật thành công!", "Thông báo");
                        frmDatPhong_Load(sender, e);
                    }
                }
            }
        }

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaiphong = true;

            xulyMaPhong();
            
        }
    }
}
