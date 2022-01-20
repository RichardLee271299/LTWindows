namespace _17_PhuongDong_12_HienDuy
{
    partial class frmTraPhong
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.btnTraPhong = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaoHoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDanhSach);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin thuê phòng";
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSach.Location = new System.Drawing.Point(3, 28);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.Size = new System.Drawing.Size(753, 228);
            this.dgvDanhSach.TabIndex = 0;
            // 
            // btnTraPhong
            // 
            this.btnTraPhong.BorderRadius = 7;
            this.btnTraPhong.CheckedState.Parent = this.btnTraPhong;
            this.btnTraPhong.CustomImages.Parent = this.btnTraPhong;
            this.btnTraPhong.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnTraPhong.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraPhong.ForeColor = System.Drawing.Color.White;
            this.btnTraPhong.HoverState.Parent = this.btnTraPhong;
            this.btnTraPhong.Location = new System.Drawing.Point(15, 313);
            this.btnTraPhong.Name = "btnTraPhong";
            this.btnTraPhong.ShadowDecoration.Parent = this.btnTraPhong;
            this.btnTraPhong.Size = new System.Drawing.Size(180, 45);
            this.btnTraPhong.TabIndex = 1;
            this.btnTraPhong.Text = "Trả phòng";
            // 
            // btnTaoHoaDon
            // 
            this.btnTaoHoaDon.BorderRadius = 7;
            this.btnTaoHoaDon.CheckedState.Parent = this.btnTaoHoaDon;
            this.btnTaoHoaDon.CustomImages.Parent = this.btnTaoHoaDon;
            this.btnTaoHoaDon.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnTaoHoaDon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnTaoHoaDon.HoverState.Parent = this.btnTaoHoaDon;
            this.btnTaoHoaDon.Location = new System.Drawing.Point(302, 313);
            this.btnTaoHoaDon.Name = "btnTaoHoaDon";
            this.btnTaoHoaDon.ShadowDecoration.Parent = this.btnTaoHoaDon;
            this.btnTaoHoaDon.Size = new System.Drawing.Size(180, 45);
            this.btnTaoHoaDon.TabIndex = 1;
            this.btnTaoHoaDon.Text = "Tạo hóa đơn";
            // 
            // btnThoat
            // 
            this.btnThoat.BorderRadius = 7;
            this.btnThoat.CheckedState.Parent = this.btnThoat;
            this.btnThoat.CustomImages.Parent = this.btnThoat;
            this.btnThoat.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnThoat.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.HoverState.Parent = this.btnThoat;
            this.btnThoat.Location = new System.Drawing.Point(591, 313);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ShadowDecoration.Parent = this.btnThoat;
            this.btnThoat.Size = new System.Drawing.Size(180, 45);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            // 
            // frmTraPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 399);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTaoHoaDon);
            this.Controls.Add(this.btnTraPhong);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTraPhong";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private Guna.UI2.WinForms.Guna2Button btnTraPhong;
        private Guna.UI2.WinForms.Guna2Button btnTaoHoaDon;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
    }
}