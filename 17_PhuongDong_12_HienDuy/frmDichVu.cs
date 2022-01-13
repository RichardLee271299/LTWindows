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
    public partial class frmDichVu : Form
    {
        public frmDichVu()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();

        void HienThiDuLieu(String sql, DataGridView dgs)
        {
            ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        void HienThiTextBox(DataSet d, int vt)
        {

            txtMaDichVu.Text = d.Tables[0].Rows[vt]["MaDV"].ToString();
            txtTenDichVu.Text = d.Tables[0].Rows[vt]["TenDV"].ToString();
            txtDonViTinh.Text = d.Tables[0].Rows[vt]["DonViTinh"].ToString();
            txtGia.Text = d.Tables[0].Rows[vt]["Gia"].ToString();
        }
        void XuLy_Textbox(Boolean t)
        {
            txtMaDichVu.ReadOnly = t;
            txtTenDichVu.ReadOnly = t;
            txtGia.ReadOnly = t;
            txtDonViTinh.ReadOnly = t;
        }
        void XuLy_ChucNang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
            btnHuy.Enabled = !t;
        }
        void clearTextBox()
        {
            txtTenDichVu.Clear();
            txtDonViTinh.Clear();
            txtMaDichVu.Clear();
            txtGia.Clear();            
        }
        int flag = 0;
        private void frmDichVu_Load(object sender, EventArgs e)
        {
            XuLy_ChucNang(true);
            XuLy_Textbox(true);
            HienThiDuLieu("select * from DichVu", dgvDanhSach);
            HienThiTextBox(ds, 0);
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
                    string row1 = d.Tables[0].Rows[i]["MaDv"].ToString();
                    int newrow1 = Convert.ToInt32(row1.Substring(2, 2));
                    string row2 = d.Tables[0].Rows[i + 1]["MaDv"].ToString();
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
     
            XuLy_Textbox(false);
            clearTextBox();
            XuLy_ChucNang(false);
            txtMaDichVu.ReadOnly = true;
            txtMaDichVu.Text = phatSinhMa(ds, "DV");
            flag = 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XuLy_Textbox(false);
            XuLy_ChucNang(false);
            txtMaDichVu.ReadOnly = true;
            flag = 2;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XuLy_ChucNang(false);
            flag = 3;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            XuLy_ChucNang(true);
            XuLy_Textbox(true);
            string sql= "";
            if (txtMaDichVu.Text == "" || txtTenDichVu.Text == "" || txtDonViTinh.Text == "" || txtGia.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
            }
            else
            {
                if (flag == 1)
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn lưu dịch vụ vừa thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        sql = "insert into DichVu values('" + txtMaDichVu.Text + "',N'" + txtTenDichVu.Text + "',N'" + txtDonViTinh.Text + "'," + txtGia.Text + ")";
                    }
                }
                else if (flag == 2)
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn sửa dịch vụ vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (kq == DialogResult.Yes)
                    {
                        sql = "update DichVu set MaDV = '" + txtMaDichVu.Text + "', TenDV = N'" + txtTenDichVu.Text + "',DonViTinh = N'" + txtDonViTinh.Text + "',Gia ='" + txtGia.Text + "' where MaDV = '" + txtMaDichVu.Text + "'";
                    }           
                }
                else
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn xóa dịch vụ vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (kq == DialogResult.Yes)
                    {
                        sql = "delete from DichVu where MaDV = '" + txtMaDichVu.Text + "'";
                    }         
                }
                if (sql != "")
                if (c.CapNhatDuLieu(sql) != 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    frmDichVu_Load(sender, e);
                }
                flag = 0;
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XuLy_ChucNang(true);
            XuLy_Textbox(true);
            if (flag == 1)
            { MessageBox.Show("Bạn có muốn hủy thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            if (flag == 2)
            { MessageBox.Show("Bạn có muốn hủy sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            if (flag == 3)
            { MessageBox.Show("Bạn có muốn hủy xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSach.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);
        }

        private void frmDichVu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;  
          
            //if(flag == 1)
                // ban có muốn thoát không
          //  else if(flag == 2)
                //ban co muon luu khong
            // else
            //ban co muon xoa khong
            //flag = 0;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Bạn không được nhập Số vào đây!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Bạn không được nhập chứ vào đây!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
