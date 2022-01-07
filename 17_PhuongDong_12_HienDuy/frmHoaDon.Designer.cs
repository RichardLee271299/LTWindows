namespace _17_PhuongDong_12_HienDuy
{
    partial class frmHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayLapHD = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNhapTuKhoa = new System.Windows.Forms.TextBox();
            this.cboTimKiem = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChiTietHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa Đơn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboNhanVien);
            this.groupBox1.Controls.Add(this.cboTrangThai);
            this.groupBox1.Controls.Add(this.dtpNgayLapHD);
            this.groupBox1.Controls.Add(this.txtThanhTien);
            this.groupBox1.Controls.Add(this.txtGiamGia);
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtTenPhong);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtMaHD);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox1.Location = new System.Drawing.Point(18, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 308);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hóa đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(20, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã hóa đơn :";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaHD.Location = new System.Drawing.Point(20, 68);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(161, 22);
            this.txtMaHD.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(20, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày lập hóa đơn :";
            // 
            // dtpNgayLapHD
            // 
            this.dtpNgayLapHD.CalendarFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpNgayLapHD.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpNgayLapHD.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtpNgayLapHD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLapHD.Location = new System.Drawing.Point(20, 232);
            this.dtpNgayLapHD.Name = "dtpNgayLapHD";
            this.dtpNgayLapHD.Size = new System.Drawing.Size(161, 22);
            this.dtpNgayLapHD.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.cboTimKiem);
            this.groupBox2.Controls.Add(this.txtNhapTuKhoa);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox2.Location = new System.Drawing.Point(18, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(454, 134);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin hóa đơn";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(20, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tìm kiếm theo:";
            // 
            // txtNhapTuKhoa
            // 
            this.txtNhapTuKhoa.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNhapTuKhoa.Location = new System.Drawing.Point(254, 37);
            this.txtNhapTuKhoa.Name = "txtNhapTuKhoa";
            this.txtNhapTuKhoa.Size = new System.Drawing.Size(177, 29);
            this.txtNhapTuKhoa.TabIndex = 1;
            // 
            // cboTimKiem
            // 
            this.cboTimKiem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboTimKiem.FormattingEnabled = true;
            this.cboTimKiem.Items.AddRange(new object[] {
            "Mã hóa đơn",
            "Tên khách hàng"});
            this.cboTimKiem.Location = new System.Drawing.Point(23, 84);
            this.cboTimKiem.Name = "cboTimKiem";
            this.cboTimKiem.Size = new System.Drawing.Size(161, 26);
            this.cboTimKiem.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.AutoRoundedCorners = true;
            this.btnTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.btnTimKiem.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnTimKiem.BorderRadius = 10;
            this.btnTimKiem.CheckedState.Parent = this.btnTimKiem;
            this.btnTimKiem.CustomImages.Parent = this.btnTimKiem;
            this.btnTimKiem.FillColor = System.Drawing.Color.ForestGreen;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.HoverState.Parent = this.btnTimKiem;
            this.btnTimKiem.Location = new System.Drawing.Point(254, 81);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.ShadowDecoration.Parent = this.btnTimKiem;
            this.btnTimKiem.Size = new System.Drawing.Size(177, 29);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(20, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên phòng :";
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenPhong.Location = new System.Drawing.Point(20, 122);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(161, 22);
            this.txtTenPhong.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(20, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhân viên tạo :";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(251, 64);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(161, 24);
            this.cboTrangThai.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(251, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Trạng thái :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(251, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Đơn giá :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(251, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Giảm giá :";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDonGia.Location = new System.Drawing.Point(251, 122);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(161, 22);
            this.txtDonGia.TabIndex = 1;
            this.txtDonGia.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtGiamGia.Location = new System.Drawing.Point(251, 176);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(161, 22);
            this.txtGiamGia.TabIndex = 1;
            this.txtGiamGia.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(251, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "Thành tiền :";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtThanhTien.Location = new System.Drawing.Point(251, 230);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(161, 22);
            this.txtThanhTien.TabIndex = 1;
            this.txtThanhTien.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(20, 176);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(161, 24);
            this.cboNhanVien.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnThoat);
            this.groupBox3.Controls.Add(this.btnChiTietHoaDon);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox3.Location = new System.Drawing.Point(18, 541);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(454, 113);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btnChiTietHoaDon
            // 
            this.btnChiTietHoaDon.AutoRoundedCorners = true;
            this.btnChiTietHoaDon.BackColor = System.Drawing.Color.Transparent;
            this.btnChiTietHoaDon.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnChiTietHoaDon.BorderRadius = 13;
            this.btnChiTietHoaDon.CheckedState.Parent = this.btnChiTietHoaDon;
            this.btnChiTietHoaDon.CustomImages.Parent = this.btnChiTietHoaDon;
            this.btnChiTietHoaDon.FillColor = System.Drawing.Color.ForestGreen;
            this.btnChiTietHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChiTietHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnChiTietHoaDon.HoverState.Parent = this.btnChiTietHoaDon;
            this.btnChiTietHoaDon.Location = new System.Drawing.Point(20, 52);
            this.btnChiTietHoaDon.Name = "btnChiTietHoaDon";
            this.btnChiTietHoaDon.ShadowDecoration.Parent = this.btnChiTietHoaDon;
            this.btnChiTietHoaDon.Size = new System.Drawing.Size(177, 29);
            this.btnChiTietHoaDon.TabIndex = 3;
            this.btnChiTietHoaDon.Text = "Chi tiết hóa đơn";
            // 
            // btnThoat
            // 
            this.btnThoat.AutoRoundedCorners = true;
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnThoat.BorderRadius = 13;
            this.btnThoat.CheckedState.Parent = this.btnThoat;
            this.btnThoat.CustomImages.Parent = this.btnThoat;
            this.btnThoat.FillColor = System.Drawing.Color.ForestGreen;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.HoverState.Parent = this.btnThoat;
            this.btnThoat.Location = new System.Drawing.Point(235, 52);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ShadowDecoration.Parent = this.btnThoat;
            this.btnThoat.Size = new System.Drawing.Size(177, 29);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvDanhSach);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox4.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox4.Location = new System.Drawing.Point(491, 55);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(750, 599);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách hóa đơn";
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSach.Location = new System.Drawing.Point(3, 28);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(744, 568);
            this.dgvDanhSach.TabIndex = 0;
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1275, 666);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmHoaDon";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.DateTimePicker dtpNgayLapHD;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Guna.UI2.WinForms.Guna2Button btnTimKiem;
        private System.Windows.Forms.ComboBox cboTimKiem;
        private System.Windows.Forms.TextBox txtNhapTuKhoa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.GroupBox groupBox3;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
        private Guna.UI2.WinForms.Guna2Button btnChiTietHoaDon;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvDanhSach;

    }
}