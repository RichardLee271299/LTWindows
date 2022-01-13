using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _17_PhuongDong_12_HienDuy
{
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
        }
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();
        DataSet ds = new DataSet();
        DataSet dsLoaiPhong = new DataSet();

          void HienThiDuLieu(String sql,DataGridView dgs, ref DataSet ds)
        {
            ds = c.LayDuLieu(sql);
            dgs.DataSource = ds.Tables[0];
        }

        void chuyenfileanhsanganh(string filename)
          {
              Bitmap a = new Bitmap(filename);
              picHinhPhong.Image = a;
              picHinhPhong.SizeMode = PictureBoxSizeMode.StretchImage;
          }
          void HienThiTextBox(DataSet d, int vt)
          {
              txtMaPhong.Text = d.Tables[0].Rows[vt]["MaPhong"].ToString();
              txtGiaPhong.Text = d.Tables[0].Rows[vt]["Gia"].ToString();
              txtKichThuoc.Text = d.Tables[0].Rows[vt]["KichThuoc"].ToString();
              rtbMoTa.Text = d.Tables[0].Rows[vt]["MoTa"].ToString();
              txtHinhAnh.Text = d.Tables[0].Rows[vt]["Image"].ToString();
              string TinhTrang = d.Tables[0].Rows[vt]["Tình Trạng"].ToString();
              if(TinhTrang.ToLower() == "trống")
              {
                  cboTinhTrang.SelectedIndex = 0;
              }
              else
              {
                  cboTinhTrang.SelectedIndex = 1;
              }       
              string LoaiPhong = d.Tables[0].Rows[vt]["LoaiPhong"].ToString();
              DataView dvmLoaiPhong = new DataView();
              dvmLoaiPhong.Table = dsLoaiPhong.Tables[0];
              cboLoaiPhong.DataSource = dvmLoaiPhong;
              cboLoaiPhong.DisplayMember = "LoaiPhong";
              cboLoaiPhong.ValueMember = "MaPhong";
              dvmLoaiPhong.RowFilter = "LoaiPhong ='" + LoaiPhong + "'";

              //xuly hinh anh
              string h = d.Tables[0].Rows[vt]["Image"].ToString();
              string filename = Path.GetFullPath("hinh") + @"\";
              filename += h;
              //load anh len
              chuyenfileanhsanganh(filename);
              
          }
      
        void Xuly_Textbox(Boolean t)
        {
            txtMaPhong.ReadOnly = t;
            txtHinhAnh.ReadOnly = t;
            txtKichThuoc.ReadOnly = t;
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
        private void frmPhong_Load(object sender, EventArgs e)
        {
            btnLoadHinh.Visible = false;
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            HienThiDuLieu("select Phong.MaPhong,LoaiPhong,Gia,N'Tình Trạng' = case when TinhTrang='1' then N'Đã thuê' else N'Trống' end,Image,KichThuoc,MoTa  from Phong inner join LoaiPhong on Phong.MaLoai = LoaiPhong.MaPhong ORDER BY MaPhong ASC", dgvDanhSach, ref ds);
            dsLoaiPhong = c.LayDuLieu("select * from LoaiPhong");
            HienThiComboBox(dsLoaiPhong, "LoaiPhong", "MaPhong", cboLoaiPhong);
            HienThiTextBox(ds, 0);
        }
        string phatSinhMa(DataSet d, string kytu)
        {
            int max=0;
            int sodong = d.Tables[0].Rows.Count;
            for(int i = 0; i< sodong-1;i++)
            {
                string row1 = d.Tables[0].Rows[i]["MaPhong"].ToString();
                int newrow1 = Convert.ToInt32(row1.Substring(2, 2));
                string row2 = d.Tables[0].Rows[i+1]["MaPhong"].ToString();
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLoadHinh.Visible = true;
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            cboTinhTrang.SelectedIndex = 0;
            txtMaPhong.ReadOnly = true;
            txtMaPhong.Text = phatSinhMa(ds, "PH");
            flag = 1;
            HienThiComboBox(dsLoaiPhong, "LoaiPhong", "MaPhong", cboLoaiPhong);
            clearTextbox();
        }
        int flag = 0;
        void HienThiComboBox(DataSet ds, string ten, string ma, ComboBox c)
        {
            c.DataSource = ds.Tables[0];
            c.DisplayMember = ten;
            c.ValueMember = ma;
            c.SelectedIndex = 0;
        }
        void clearTextbox()
        {
            txtHinhAnh.Clear();
            txtKichThuoc.Clear();
            txtGiaPhong.Clear();
            rtbMoTa.Clear();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            int tinhtrang;
            if ((string)cboTinhTrang.Items[cboTinhTrang.SelectedIndex] == "Trống")
                tinhtrang = 0;
            else
                tinhtrang = 1;

            if (txtGiaPhong.Text == "" || txtHinhAnh.Text == "" || txtKichThuoc.Text == "" || txtMaPhong.Text == "" || cboLoaiPhong.SelectedIndex == -1 || cboTinhTrang.SelectedIndex == -1 || rtbMoTa.Text=="")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
                Xuly_Chucnang(false);
            }
            else
            {
                string sql = "";
                if (flag == 1)
                {                
                   DialogResult kq =  MessageBox.Show("Bạn có muốn thêm phòng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (kq == DialogResult.Yes)
                    {
                        sql = "insert into Phong values('" + txtMaPhong.Text + "','" + cboLoaiPhong.SelectedValue + "'," + tinhtrang + ",'" + txtGiaPhong.Text + "','" + txtKichThuoc.Text + "','" + txtHinhAnh.Text + "',N'" + rtbMoTa.Text + "')";
                    }

                }
                else if (flag == 2)
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn sửa phòng vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                         sql = "update Phong set MaPhong = '" + txtMaPhong.Text + "', MaLoai = '" + cboLoaiPhong.SelectedValue + "',TinhTrang = " + tinhtrang + ",Gia = " + txtGiaPhong.Text + ",KichThuoc ='" + txtKichThuoc.Text + "',Image = '" + txtHinhAnh.Text + "',MoTa = N'" + rtbMoTa.Text + "' where MaPhong = '" + txtMaPhong.Text + "'";
                    }
                }
                else
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn xóa phòng vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                         sql = "delete from Phong where MaPhong = '" + txtMaPhong.Text + "'";
                    }
                   
                }
                if(sql != "")
                if (c.CapNhatDuLieu(sql) != 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    frmPhong_Load(sender, e);
                }


                flag = 0;
            }
        }
        string tachchuoi(string f)
        {
            string[] mangchuoi = f.Split('\\');
            return mangchuoi[mangchuoi.Length-1];
        }
        private void btnLoadHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = Path.GetFullPath("hinh") + @"\";
            o.ShowDialog();
            if (o.FileName.Contains("hinh"))
            {
                chuyenfileanhsanganh(o.FileName);
                txtHinhAnh.Text = tachchuoi(o.FileName);
            }
           
         
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            txtMaPhong.ReadOnly = true;
            btnLoadHinh.Visible = true;
            flag = 2;
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            btnLoadHinh.Visible = false;
            if (flag == 1)
            { MessageBox.Show("Bạn có muốn hủy thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            if (flag == 2)
            { MessageBox.Show("Bạn có muốn hủy sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            if (flag == 3)
            { MessageBox.Show("Bạn có muốn hủy xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
        }

        private void dgvLoaiPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cboLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void txtGiaPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Bạn không được nhập chứ vào đây!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmPhong_FormClosing(object sender, FormClosingEventArgs e)
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
