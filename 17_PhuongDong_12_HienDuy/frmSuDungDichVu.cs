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
            c.SelectedIndex = 0;
        }
        void HienThiTextBox(DataSet d, int vt)
        {
            string TenDv = d.Tables[0].Rows[vt]["TenDv"].ToString();
            DataView dvmDichVu = new DataView();
            dvmDichVu.Table = dsDichVu.Tables[0];
            cboTenDv.DataSource = dvmDichVu;
            cboTenDv.DisplayMember = "TenDv";
            cboTenDv.ValueMember = "MaDv";
            dvmDichVu.RowFilter = "TenDv ='" + TenDv + "'";
        }

        private void frmSuDungDichVu_Load(object sender, EventArgs e)
        {            
            dsDichVu = c.LayDuLieu("select * from DichVu");
            HienThiComboBox(dsDichVu, "TenDv", "MaDv", cboTenDv);
            HienThiTextBox(ds, 0);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSach.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);
        }
    }
}
