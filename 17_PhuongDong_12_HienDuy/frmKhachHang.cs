﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _17_PhuongDong_12_HienDuy
{
    public partial class frmKhachHang : Form
    {
      




        DataSet ds = new DataSet();
        public frmKhachHang()
        {
            InitializeComponent();
        }
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();
        public string HT, GT, CM, DC , DT ,KH;
        public DateTime NS;
        
        void HienThiDuLieu(String sql, DataGridView dgs)
        {
             ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }
        void HienThiTextBox(DataSet d, int vt)
        {
            txtHoTen.Text = d.Tables[0].Rows[vt]["HoTen"].ToString();           
            txtDiaChi.Text = d.Tables[0].Rows[vt]["DiaChi"].ToString();
            txtSoCMND.Text = d.Tables[0].Rows[vt]["CMND"].ToString();
            txtSoDienThoai.Text = d.Tables[0].Rows[vt]["SDT"].ToString();
            txtSoDienThoai.Text = d.Tables[0].Rows[vt]["SDT"].ToString();
            dtpNgayDen.Value =(DateTime)d.Tables[0].Rows[vt]["NgayDen"];
            txtMaKH.Text = d.Tables[0].Rows[vt]["MaKH"].ToString();
            string GioiTinh = d.Tables[0].Rows[vt]["GioiTinh"].ToString();
            if (GioiTinh.ToLower() == "nam")
                cbmGioiTinh.SelectedIndex = 0;
            else
                cbmGioiTinh.SelectedIndex = 1;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        void Xuly_Textbox(Boolean t)
        {
            txtMaKH.ReadOnly = t;            
            txtHoTen.ReadOnly = t;
            txtSoCMND.ReadOnly = t;
            txtSoDienThoai.ReadOnly = t;
            txtDiaChi.ReadOnly = t;
        }

        void Xuly_Chucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnHuy.Enabled = !t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }
        int flag = 0;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            HienThiDuLieu("select * from KhachHang", dgvDanhSachKhachHang);
            HienThiTextBox(ds, 0);
        }
        void clearTextBox()
        {
            txtDiaChi.Clear();
            txtHoTen.Clear();
            txtSoCMND.Clear();
            txtSoDienThoai.Clear();
            cbmGioiTinh.SelectedIndex = 0;
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
                    string row1 = d.Tables[0].Rows[i]["MaKH"].ToString();
                    int newrow1 = Convert.ToInt32(row1.Substring(2, 2));
                    string row2 = d.Tables[0].Rows[i + 1]["MaKH"].ToString();
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
            
            txtMaKH.Text = phatSinhMa(ds, "kH");
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            txtMaKH.ReadOnly = true;
            clearTextBox();
            flag = 1;
        }
        void HienThiComboBox(ref DataSet ds , string ten, string ma, ComboBox c)
        {
            c.DataSource = ds.Tables[0];
            c.DisplayMember = ten;
            c.ValueMember = ma;
            c.SelectedIndex = 0;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            string sql = "";
            if(txtDiaChi.Text=="" || txtHoTen.Text=="" || txtMaKH.Text=="" || txtSoCMND.Text=="" || txtSoDienThoai.Text=="" || cbmGioiTinh.SelectedIndex==-1  )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
            }
            else 
            { 
                if (flag == 1)
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (kq == DialogResult.Yes)
                    {
                        sql = "insert into KhachHang values ('" + txtMaKH.Text + "',N'" + txtHoTen.Text + "','" + dtpNgaySinh.Text + "','" + txtSoDienThoai.Text + "', '" + txtSoCMND.Text + "',N'" + txtDiaChi.Text + "',N'" + cbmGioiTinh.Items[cbmGioiTinh.SelectedIndex] + "','" + dtpNgayDen.Text + "')";
                    }                 
                }
                else if (flag == 2)
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn sửa thông tin khách hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        sql = "update KhachHang set MaKH = '" + txtMaKH.Text + "', HoTen = N'" + txtHoTen.Text + "', NgaySinh = '" + dtpNgaySinh.Text + "', SDT = '" + txtSoDienThoai.Text + "', CMND = '" + txtSoCMND.Text + "',DiaChi= N'" + txtDiaChi.Text + "', GioiTinh = N'" + cbmGioiTinh.Items[cbmGioiTinh.SelectedIndex] + "', NgayDen = '" + dtpNgayDen.Text + "' where MaKH = '" + txtMaKH.Text + "'";
                    }                 
                }
                else
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn xóa thông tin khách hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (kq == DialogResult.Yes)
                    {
                        sql = "delete from KhachHang where MaKH = '" + txtMaKH.Text + "'";
                    }
                    
                    
                }
                if (sql != "")
                if (c.CapNhatDuLieu(sql) != 0)
                {
                    KH = txtMaKH.Text;
                    HT = txtHoTen.Text;
                    DC = txtDiaChi.Text;
                    NS = dtpNgaySinh.Value;
                    GT = cbmGioiTinh.Items[cbmGioiTinh.SelectedIndex].ToString();
                    CM = txtSoCMND.Text;
                    DT = txtSoDienThoai.Text;

                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    frmKhachHang_Load(sender, e);
                }


                flag = 0;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            txtMaKH.ReadOnly = true;
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSachKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSachKhachHang.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xuly_Chucnang(false);
            flag = 3;
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Bạn không được nhập Số vào đây!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSoCMND_KeyDown(object sender, KeyEventArgs e)
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

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Bạn không được nhập chứ vào đây!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       
    }
}
