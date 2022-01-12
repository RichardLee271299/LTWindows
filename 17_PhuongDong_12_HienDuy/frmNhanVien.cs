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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        int flag = 0;
        clsQuanLyKhachSan c = new clsQuanLyKhachSan();
        DataSet ds = new DataSet();
        void HienThiDuLieu(String sql, DataGridView dgs)
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
            txtHoTen.Text = d.Tables[0].Rows[vt]["HoTen"].ToString();
            txtMaNv.Text = d.Tables[0].Rows[vt]["MaNV"].ToString();
            txtDiaChi.Text = d.Tables[0].Rows[vt]["DiaChi"].ToString();
            txtSoCMND.Text = d.Tables[0].Rows[vt]["CMND"].ToString();
            txtSoDienThoai.Text = d.Tables[0].Rows[vt]["SDT"].ToString();
            txtHinhAnh.Text = d.Tables[0].Rows[vt]["Image"].ToString();
            string TinhTrang = d.Tables[0].Rows[vt]["TinhTrang"].ToString();
            if (TinhTrang.ToLower() == "Đi Làm")
                cboTinhTrang.SelectedIndex = 1;
            else
                cboTinhTrang.SelectedIndex = 0;
            string QuyenHan = d.Tables[0].Rows[vt]["QuyenHan"].ToString();
            if (QuyenHan.ToLower() == "Nhân Viên")
                cboQuyenHan.SelectedIndex = 1;
            else
                cboQuyenHan.SelectedIndex = 0;
            string GioiTinh = d.Tables[0].Rows[vt]["GioiTinh"].ToString();
            if (GioiTinh.ToLower() == "Nam")
                cboGioiTinh.SelectedIndex = 1;
            else
                cboGioiTinh.SelectedIndex = 0;
            //xuly hinh anh
            string h = d.Tables[0].Rows[vt]["Image"].ToString();
            string filename = Path.GetFullPath("hinh") + @"\";
            filename += h;
            //load anh len
            chuyenfileanhsanganh(filename);

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        void Xuly_Textbox(Boolean t)
        {
            txtMaNv.ReadOnly = !t;
            txtHoTen.ReadOnly = t;
            txtSoCMND.ReadOnly = t;
            txtSoDienThoai.ReadOnly = t;
            txtDiaChi.ReadOnly = t;
        }
        void clearTextBox()
        {
            txtDiaChi.Clear();
            txtHoTen.Clear();
            txtSoCMND.Clear();
            txtSoDienThoai.Clear();
            cboGioiTinh.SelectedIndex = 0;
            cboTinhTrang.SelectedIndex = 0;
            cboQuyenHan.SelectedIndex = 0;
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
                    string row1 = d.Tables[0].Rows[i]["MaNV"].ToString();
                    int newrow1 = Convert.ToInt32(row1.Substring(2, 2));
                    string row2 = d.Tables[0].Rows[i + 1]["MaNV"].ToString();
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            btnLoadHinh.Visible = false;
            Xuly_Textbox(true);
          
            Xuly_Chucnang(true);
            HienThiDuLieu("select * from NhanVien", dgvDanhSachNhanVien);
            HienThiTextBox(ds, 0);
        }

        private void dgvDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dgvDanhSachNhanVien.CurrentCell.RowIndex;
            HienThiTextBox(ds, vt);
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            txtMaNv.Text = phatSinhMa(ds, "NV");
            txtMaNv.ReadOnly = true;
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
            clearTextBox();
            flag = 1;
            btnLoadHinh.Visible = true;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            int tinhtrang;
            if (txtDiaChi.Text == "" || txtHinhAnh.Text == "" || txtHoTen.Text == "" || txtMaNv.Text == "" || txtSoCMND.Text == "" || txtSoDienThoai.Text == "" || cboGioiTinh.SelectedIndex == -1 || cboQuyenHan.SelectedIndex == -1 || cboTinhTrang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo");
            }
            else
            {
                if ((string)cboTinhTrang.Items[cboTinhTrang.SelectedIndex] == "Hoạt động")
                    tinhtrang = 1;
                else
                    tinhtrang = 0;
                string sql = "";
                if (flag == 1)
                {
                    sql = "insert into NhanVien values ('" + txtMaNv.Text + "',N'" + txtHoTen.Text + "','" + txtSoCMND.Text + "',N'" + txtDiaChi.Text + "','" + txtSoDienThoai.Text + "'," + tinhtrang + ",N'" + cboGioiTinh.Items[cboGioiTinh.SelectedIndex] + "',N'" + cboQuyenHan.Items[cboQuyenHan.SelectedIndex] + "',N'" + txtHinhAnh.Text + "')";
                    MessageBox.Show("Bạn có thêm thông tin nhân viên vừa nhập?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else if (flag == 2)
                {
                    sql = "update NhanVien set MaNv = '" + txtMaNv.Text + "', HoTen = N'" + txtHoTen.Text + "', TinhTrang = " + tinhtrang + ", SDT = '" + txtSoDienThoai.Text + "', CMND = '" + txtSoCMND.Text + "',DiaChi= N'" + txtDiaChi.Text + "', GioiTinh = N'" + cboGioiTinh.Items[cboGioiTinh.SelectedIndex] + "', QuyenHan = N'" + cboQuyenHan.Items[cboQuyenHan.SelectedIndex] + "',Image='" + txtHinhAnh.Text + "' where MaNv = '" + txtMaNv.Text + "'";
                    MessageBox.Show("Bạn có muốn sửa thông tin nhân viên vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    sql = "delete from NhanVien where MaNv = '" + txtMaNv.Text + "'";
                    MessageBox.Show("Bạn có muốn xóa nhân viên vừa chọn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                if (c.CapNhatDuLieu(sql) != 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    frmNhanVien_Load(sender, e);
                }


                flag = 0;
            }

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(false);
            txtMaNv.ReadOnly = false;
            flag = 2;
            btnLoadHinh.Visible = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xuly_Chucnang(false);
            flag = 3;
            MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            btnLoadHinh.Visible = false;
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
            if (flag == 1)
            { MessageBox.Show("Bạn có muốn hủy thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            if (flag == 2)
            { MessageBox.Show("Bạn có muốn hủy sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
            if (flag == 3)
            { MessageBox.Show("Bạn có muốn hủy xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question); }
        }
        string tachchuoi(string f)
        {
            string[] mangchuoi = f.Split('\\');
            return mangchuoi[mangchuoi.Length - 1];
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

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Bạn không được nhập Số vào đây!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
