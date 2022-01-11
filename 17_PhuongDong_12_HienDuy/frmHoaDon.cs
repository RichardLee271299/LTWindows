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
        frmGiaoDienChinh frm1;
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();
        string maKH;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm1.Show();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            cboTimKiem.SelectedIndex = 0;
        }
        string phatsinhma()
        {
            DataSet ds = new DataSet();
            ds = c.LayDuLieu("select MaHD from HoaDon");
            if (ds.Tables[0].Rows.Count <= 0)
                return "HD01";
            else if (ds.Tables[0].Rows.Count < 10)
                return "HD0" + (ds.Tables[0].Rows.Count + 1).ToString();
            else
                return "HD" + (ds.Tables[0].Rows.Count + 1).ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = phatsinhma();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(cboTimKiem.SelectedIndex == 0)
            {
                if (txtNhapTuKhoa.Text != "")
                {
                    DataSet dsKhachHang = new DataSet();
                    dsKhachHang = c.LayDuLieu("select MaKH,HoTen,SDT,DiaChi from KhachHang where SDT = '" + txtNhapTuKhoa.Text + "'");
                    if (dsKhachHang.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("Không có SDT trùng khớp!");
                    }
                    else
                    {
                        maKH = dsKhachHang.Tables[0].Rows[0]["MaKH"].ToString();
                        txtMaKH.Text = maKH;
                    }

                }
            }
            else if(cboTimKiem.SelectedIndex == 1)
            {
                    if (txtNhapTuKhoa.Text != "")
                    {
                        DataSet dsKhachHang = new DataSet();
                        dsKhachHang = c.LayDuLieu("select MaKH,HoTen,SDT,DiaChi from KhachHang where HOTEN = '" + txtNhapTuKhoa.Text + "'");
                        if (dsKhachHang.Tables[0].Rows.Count == 0)
                        {
                            MessageBox.Show("Không có SDT trùng khớp!");
                        }
                        else
                        {
                            maKH = dsKhachHang.Tables[0].Rows[0]["MaKH"].ToString();
                            txtMaKH.Text = maKH;
                        }

                    }
            }
           
        }
    }
}
