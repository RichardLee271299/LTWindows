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
    public partial class frmSuDungDichVu : Form
    {
        public frmSuDungDichVu()
        {
            InitializeComponent();
        }
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();
        DataSet ds = new DataSet();
        DataSet dsDichVu = new DataSet();
        DataSet dsPhong = new DataSet();
        DataSet dsGia = new DataSet();
        Boolean t = false;
        void HienThiDuLieu(String sql, DataGridView dgs, ref DataSet ds)
        {
            ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        void HienThiComboBox(DataSet ds, string ten, string ma, ComboBox c)
        {
            c.DataSource = ds.Tables[0];
            c.DisplayMember = ten;
            c.ValueMember = ma;
            c.SelectedIndex = -1;
        }

        private void frmSuDungDichVu_Load(object sender, EventArgs e)
        {            
            dsDichVu = c.LayDuLieu("select * from DichVu");
            HienThiComboBox(dsDichVu, "TenDv", "TenDv", cboTenDv);
            dsPhong = c.LayDuLieu("select * from Phong");
            HienThiComboBox(dsPhong, "MaPhong", "MaPhong", cboMaPhong);
            t = true;
        }
        void HienThiGia()
        {
            string sql = "select Gia from DichVu where TenDv ='" + cboTenDv.SelectedValue.ToString() + "'";
            dsGia = c.LayDuLieu(sql);
            lblGia.Text = dsGia.Tables[0].Rows[0]["Gia"].ToString();
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSach.CurrentCell.RowIndex;
            
        }

        private void lblGia_Click(object sender, EventArgs e)
        {

        }

        private void cboTenDv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t)
                if (cboTenDv.SelectedIndex != -1)
                    HienThiGia();
        }
    }
}
