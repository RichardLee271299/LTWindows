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
        Boolean lp = false;
        Boolean dgvClick = false;
        frmKhachHang kh = new frmKhachHang();
        string maphong;
        string makhachhang;
        Boolean loaiphong = false;
        int flag;
        Boolean mt;
        string madatphong;
        string mp;
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
            if (loaiphong && cboLoaiPhong.SelectedIndex != -1 && dgvClick == false && mt == true)
            {
                string a = cboLoaiPhong.SelectedValue.ToString();
                dsPhong = c.LayDuLieu("select * from Phong where TinhTrang = 0 AND MaLoai ='" + a + "'");
                HienThiComboBox(dsPhong, "MaPhong", "MaPhong", cboMaPhong);
                
      
            }
        }
        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            mt = false;
            lp = false;
            Xuly_Textbox(false);
            string sql = "select MaDatPhong,KhachHang.HoTen,KhachHang.GioiTinh,KhachHang.NgaySinh,KhachHang.DiaChi,LoaiPhong,MaPH,KhachHang.SDT,NgayNhan,NgayTra,N'TinhTrangDatPhong' = case when TinhTrangDatPhong='1' then N'Đã nhận' when TinhTrangDatPhong='0' then N'Chưa nhận' when TinhTrangDatPhong='3' then N'Đã trả' else N'Đã hủy' end,CMND,Gia,MoTa,SoDem from DatPhong inner join KhachHang on DatPhong.MaKH = KhachHang.MaKH inner join Phong on DatPhong.MaPH = Phong.MaPhong";
            HienThiDuLieu(sql, dgvDanhSach, ref ds);
            t = true;
            Xuly_Chucnang(true);
            hienthitextbox(ds, 0);
       
           
        }

        void hienthimota()
        {
         
               string sql = "select Gia,MoTa from Phong where MaPhong ='" + cboMaPhong.SelectedValue.ToString() + "'";
               dsMoTa = c.LayDuLieu(sql);
               if(dsMoTa.Tables[0].Rows.Count != 0)
               {
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
          
            if(t && dgvClick == false && loaiphong == true && mt)
            if(cboMaPhong.SelectedIndex != -1)
            {       
                hienthimota();

            }
                
                
               
        }

        private void frmDatPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm1.Show();
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {

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
        void cleartextbox()
        {
            dsLoaiPhong = c.LayDuLieu("select * from LoaiPhong");
            HienThiComboBox(dsLoaiPhong, "LoaiPhong", "MaPhong", cboLoaiPhong);
            txtHoTen.Text="";
            txtDiaChi.Clear();
            txtSoCMND.Clear();
            txtSoDienThoai.Clear();
            cboGioiTinh.SelectedIndex = 0;
            lblGiaPhong.Text = "";
            rtbMoTa.Text = "";
        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            lp = true;
            dgvClick = false;
            loaiphong = true;
            mt = true;
            flag = 1;
            Xuly_Chucnang(false);
            cleartextbox();
            cboTinhTrang.SelectedIndex = 0;
       
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
            string loai = ds.Tables[0].Rows[vt]["LoaiPhong"].ToString();

            DataView dvmMaPhong = new DataView();
            dvmMaPhong.Table = ds.Tables[0];
            cboMaPhong.DataSource = dvmMaPhong;
            cboMaPhong.DisplayMember = "MaPH";
            cboMaPhong.ValueMember = "MaPH";
            dvmMaPhong.RowFilter = "MaPH ='" + maphong + "'";
            //laymaphong
            mp = ds.Tables[0].Rows[vt]["MaPH"].ToString();
            //madatphong
            madatphong = ds.Tables[0].Rows[vt]["MaDatPhong"].ToString();
            //Sodem
            dtpNgayDen.Value = (DateTime)ds.Tables[0].Rows[vt]["NgayNhan"];
            dtpNgayTra.Value = (DateTime)ds.Tables[0].Rows[vt]["NgayTra"];
            lblSoDem.Text = ds.Tables[0].Rows[vt]["SoDem"].ToString();
            string loaiphong = ds.Tables[0].Rows[vt]["LoaiPhong"].ToString();
            //loai phong
        
            DataSet dsLP = c.LayDuLieu("select * from LoaiPhong where MaPhong ='"+loaiphong+"'");      
            HienThiComboBox(dsLP, "LoaiPhong", "MaPhong", cboLoaiPhong);
            cboLoaiPhong.SelectedIndex = 0;
            DataView dvmGioiTinh = new DataView();
            dvmGioiTinh.Table = ds.Tables[0];
            cboGioiTinh.DataSource = dvmGioiTinh;
            cboGioiTinh.DisplayMember = "GioiTinh";
            cboGioiTinh.ValueMember = "GioiTinh";
            dvmGioiTinh.RowFilter = "GioiTinh ='" + gt + "'";
            dtpNgaySinh.Value = (DateTime)ds.Tables[0].Rows[vt]["NgaySinh"];
            string tt = ds.Tables[0].Rows[vt]["TinhTrangDatPhong"].ToString();
            if (tt.ToLower() == "chưa nhận")
                cboTinhTrang.SelectedIndex = 0;
            else if (tt.ToLower() == "đã nhận")
                cboTinhTrang.SelectedIndex = 1;
            else if (tt.ToLower() == "đã hủy")
                cboTinhTrang.SelectedIndex = 2;
            else
                cboTinhTrang.SelectedIndex = 3;
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvClick = true;
            loaiphong = false;
            int vt = dgvDanhSach.CurrentCell.RowIndex;
            hienthitextbox(ds, vt);
            lp = false;
        
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
            if (cboLoaiPhong.SelectedIndex == -1 || cboGioiTinh.SelectedIndex == -1 || cboMaPhong.SelectedIndex == -1 || txtHoTen.Text == "" || txtSoCMND.Text == "" || lblSoDem.Text == "" || txtSoDienThoai.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
            }
            else
            {
                string sql = "";
                if (flag == 1)
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn thêm đặt phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        sql = "insert into DatPhong values ('" + phatSinhMa(ds, "DP") + "','" + makhachhang + "',N'" + txtHoTen.Text + "','" + cboMaPhong.SelectedValue.ToString() + "',N'" + cboLoaiPhong.SelectedValue.ToString() + "','" + txtSoDienThoai.Text + "','" + dtpNgayDen.Value.ToString() + "','" + dtpNgayTra.Value.ToString() + "'," + cboTinhTrang.SelectedIndex + ","+lblSoDem.Text+")";
                        string sql2;
                        if(cboTinhTrang.SelectedIndex == 2)
                             sql2 = "update Phong set TinhTrang = 0 where MaPhong ='"+cboMaPhong.SelectedValue+"'";
                        else
                            sql2 = "update Phong set TinhTrang = 1 where MaPhong ='" + cboMaPhong.SelectedValue + "'";
                        c.CapNhatDuLieu(sql2);
                    }
                    
                }
                else if (flag == 2)
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn sửa đặt phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        sql = "update DatPhong set MaDatPhong = '"+ madatphong +"',HoTen = N'"+ txtHoTen.Text + "',MaPH = '"+cboMaPhong.SelectedValue.ToString()+"',LoaiPhong =N'"+cboLoaiPhong.SelectedValue.ToString()+"',SDT = '"+txtSoDienThoai.Text+"',NgayNhan ='"+dtpNgayDen.Value+"', NgayTra = '"+dtpNgayTra.Value+"',TinhTrangDatPhong ="+ cboTinhTrang.SelectedIndex +",SoDem = "+lblSoDem.Text+" where MaDatPhong = '"+madatphong+"'";
                        string sql2;
                        if (cboTinhTrang.SelectedIndex == 2)
                            sql2 = "update Phong set TinhTrang = 0 where MaPhong ='" + cboMaPhong.SelectedValue + "'";
                        else
                            sql2 = "update Phong set TinhTrang = 1 where MaPhong ='" + cboMaPhong.SelectedValue + "'";
                        c.CapNhatDuLieu(sql2);
                    }
                }
                else
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn xóa phòng vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        sql = "delete from DatPhong where MaDatPhong = '" + madatphong + "'";
                    }

                }
                if (c.CapNhatDuLieu(sql) != 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    frmDatPhong_Load(sender, e);
                }
                flag = 0;
                mt = false;
            }
        }

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaiphong = true;
            dgvClick = false;    
            mt = true;
            if(lp)
            xulyMaPhong();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            if (flag == 1)
            { MessageBox.Show("Bạn có muốn hủy thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            if (flag == 2)
            { MessageBox.Show("Bạn có muốn hủy sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            if (flag == 3)
            { MessageBox.Show("Bạn có muốn hủy xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xuly_Chucnang(false);
            flag = 3;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Xuly_Chucnang(false);
            flag = 2;
        }

        private void btnHuyPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
           DialogResult kq = MessageBox.Show("Bạn có muốn trả phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           if (kq == DialogResult.Yes)
           {
              string sql = "update DatPhong set TinhTrangDatPhong = 3 where MaDatPhong ='"+madatphong+"'";
              string sql2 = "update Phong set TinhTrang = 0 where MaPhong = '"+mp+"'";
              if (c.CapNhatDuLieu(sql) != 0)
              {
                  c.CapNhatDuLieu(sql2);
                  MessageBox.Show("Cập nhật thành công, mời bạn thanh toán!", "Thông báo");
                  frmHoaDon frm = new frmHoaDon();
                  frm.Show();
                  frmDatPhong_Load(sender, e);
              }
           }
        }
    }
}
