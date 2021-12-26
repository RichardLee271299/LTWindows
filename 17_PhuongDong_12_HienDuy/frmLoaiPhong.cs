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
    public partial class frmLoaiPhong : Form
    {
        DataSet ds = new DataSet();
        public frmLoaiPhong()
        {
            InitializeComponent();
        }

        clsQuanLyKhachSan c = new clsQuanLyKhachSan();

        void HienThiDuLieu(String sql, DataGridView dgs)
        {
            ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        void HienThiTextBox(DataSet d, int vt)
        {
            txtMaPH.Text = d.Tables[0].Rows[vt]["MaPhong"].ToString();
            txtGiaPhong.Text = d.Tables[0].Rows[vt]["Gia"].ToString();
            string LoaiPhong = d.Tables[0].Rows[vt]["LoaiPhong"].ToString();            
            if (LoaiPhong.ToLower() == "thường")
                cmbLoaiPhong.SelectedIndex = 0;
            else
                cmbLoaiPhong.SelectedIndex = 1;

        }
        void Xuly_Textbox(Boolean t)
        {
            txtMaPH.ReadOnly = t;            
            txtGiaPhong.ReadOnly = t;      
        }
        void Xuly_Chucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnHuy.Enabled = !t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            flag = 1;
        }
        int flag = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            string sql = "";
            if (flag == 1)
            {
                sql = "insert into LoaiPhong values('" + txtMaPH.Text + "',N'" + cmbLoaiPhong.Text + "'," + txtGiaPhong.Text + ")";

            }
            else if (flag == 2)
            {
                sql = "update LoaiPhong set MaPhong = '" + txtMaPH.Text + "', LoaiPhong = N'" + cmbLoaiPhong.Text + "', Gia='" + txtGiaPhong.Text + "' where MaPhong = '" + txtMaPH.Text + "'";

            }
            else
            {
                sql = "delete from LoaiPhong where MaPhong = '" + txtMaPH.Text + "'";

            }
            if (c.CapNhatDuLieu(sql) != 0)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                frmLoaiPhong_Load(sender, e);
            }


            flag = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(false);
            txtMaPH.ReadOnly = false;
            flag = 2;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
        }

        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            HienThiDuLieu("select LoaiPhong.MaPhong,LoaiPhong.LoaiPhong,Gia from LoaiPhong inner join Phong on LoaiPhong.MaPhong = Phong.MaLoai", dgvDanhSach);            
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
        }
    }
}
