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
        DataSet dsLoaiPhong = new DataSet();
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
            txtLoaiPhong.Text = d.Tables[0].Rows[vt]["LoaiPhong"].ToString();
            

        }
        void Xuly_Textbox(Boolean t)
        {
            txtMaPH.ReadOnly = t;
            txtLoaiPhong.ReadOnly = t;
        }
        void clearTextBox()
        {
            txtMaPH.Clear();
            txtLoaiPhong.Clear();           
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
            int max = 0;
            int sodong = d.Tables[0].Rows.Count;
            if (sodong < 0)
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
                    string row1 = d.Tables[0].Rows[i]["MaPhong"].ToString();
                    int newrow1 = Convert.ToInt32(row1.Substring(2, 2));
                    string row2 = d.Tables[0].Rows[i + 1]["MaPhong"].ToString();
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            txtMaPH.ReadOnly = true;
            clearTextBox();
            txtMaPH.Text = phatSinhMa(ds, "LP");
            flag = 1;
            txtLoaiPhong.Clear();
        }
        int flag = 0;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            string sql = "";
            if(txtLoaiPhong.Text=="" || txtMaPH.Text=="")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
            }
            else
            {
                if (flag == 1)
                {
                    sql = "insert into LoaiPhong values('" + txtMaPH.Text + "',N'" + txtLoaiPhong.Text + "')";
                    MessageBox.Show("Bạn có muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else if (flag == 2)
                {
                    sql = "update LoaiPhong set MaPhong = '" + txtMaPH.Text + "', LoaiPhong = N'" + txtLoaiPhong.Text + "' where MaPhong = '" + txtMaPH.Text + "'";
                    MessageBox.Show("Bạn có muốn sửa phòng vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    sql = "delete from LoaiPhong where MaPhong = '" + txtMaPH.Text + "'";
                    MessageBox.Show("Bạn có muốn xóa phòng vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (c.CapNhatDuLieu(sql) != 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    frmLoaiPhong_Load(sender, e);
                }


                flag = 0;
            }
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
            if (flag == 1)
            { MessageBox.Show("Bạn có muốn hủy thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            if (flag == 2)
            { MessageBox.Show("Bạn có muốn hủy sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            if (flag == 3)
            { MessageBox.Show("Bạn có muốn hủy xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
        }
        void HienThiComboBox(DataSet ds, string ten, string ma, ComboBox c)
        {
            c.DataSource = ds.Tables[0];
            c.DisplayMember = ten;
            c.ValueMember = ma;
            c.SelectedIndex = 0;
        }
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            HienThiDuLieu("select * from LoaiPhong", dgvDanhSach);
            dsLoaiPhong = c.LayDuLieu("select * from LoaiPhong");
            HienThiTextBox(ds, 0);

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

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtGiaPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void frmLoaiPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
