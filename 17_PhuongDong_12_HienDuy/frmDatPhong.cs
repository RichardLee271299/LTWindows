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
        DataSet dsGia = new DataSet();
        void HienThiComboBox(DataSet ds, string ten, string ma, ComboBox c)
        {
            c.DataSource = ds.Tables[0];
            c.DisplayMember = ten;
            c.ValueMember = ma;
            c.SelectedIndex = 0;
        }

        void Xuly_Textbox(Boolean t)
        {
            txtSoDem.Enabled = t;
            
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
        void tinhngay ()
        {
           if(dtpNgayDen.Value > dtpNgayTra.Value)
           {
               MessageBox.Show("Ngày đến phải nhỏ hơn ngày trả!", "Thông báo");
               dtpNgayDen.Value = dtpNgayTra.Value;
           }
           else
           {
               DateTime ngayden = dtpNgayDen.Value;
               DateTime ngaytra = dtpNgayTra.Value;
               TimeSpan Time = ngaytra - ngayden;
               int TongSoNgay = Time.Days;
               txtSoDem.Text = TongSoNgay.ToString();
           }
        }
        void hienthigia()
        {
            string Phong = cboMaPhong.SelectedValue.ToString();
            DataView dvmPhong = new DataView();
            dvmPhong.Table = dsPhong.Tables[0];
            cboGia.DataSource = dvmPhong;
            cboGia.DisplayMember = "Gia";
            cboGia.ValueMember = "Gia";
            dvmPhong.RowFilter = "MaPhong ='" + cboMaPhong.SelectedValue + "'";
        }
        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            dsLoaiPhong = c.LayDuLieu("select * from LoaiPhong");
            HienThiComboBox(dsLoaiPhong, "LoaiPhong", "MaPhong", cboLoaiPhong);
            dsPhong = c.LayDuLieu("select * from Phong where TinhTrang = 0");
            HienThiComboBox(dsPhong, "MaPhong", "MaPhong", cboMaPhong);
            cboMaPhong.SelectedIndex = 0;
            hienthigia();
         

        }

        private void dtpNgayDen_ValueChanged(object sender, EventArgs e)
        {
            tinhngay();
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {
            tinhngay();
        }
        void hienthimota()
        {
             dsGia = c.LayDuLieu("select MoTa from Phong where MaPhong='" + cboMaPhong.SelectedValue + "'");
            rtbMoTa.Text = dsGia.Tables[0].Rows[0]["MoTa"].ToString();
        }
        private void cboMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            hienthigia();
            hienthimota();
        }

        private void frmDatPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm1.Show();
        }
    }
}
