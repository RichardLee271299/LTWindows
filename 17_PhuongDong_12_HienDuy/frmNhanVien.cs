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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        void Xuly_Textbox(Boolean t)
        {
            txtMaNv.ReadOnly = t;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(false);
            Xuly_Chucnang(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(false);
            txtMaNv.ReadOnly = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Xuly_Textbox(true);
            Xuly_Chucnang(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
