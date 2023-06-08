namespace THITRACNGHIEM
{
    partial class frmDangNhap
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
            this.cbSinhVien = new System.Windows.Forms.CheckBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtMatMa = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.cmbCoSo = new System.Windows.Forms.ComboBox();
            this.lbMatMa = new System.Windows.Forms.Label();
            this.lbTaiKhoan = new System.Windows.Forms.Label();
            this.lbCoSo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSinhVien);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnDangNhap);
            this.groupBox1.Controls.Add(this.txtMatMa);
            this.groupBox1.Controls.Add(this.txtTaiKhoan);
            this.groupBox1.Controls.Add(this.cmbCoSo);
            this.groupBox1.Controls.Add(this.lbMatMa);
            this.groupBox1.Controls.Add(this.lbTaiKhoan);
            this.groupBox1.Controls.Add(this.lbCoSo);
            this.groupBox1.Location = new System.Drawing.Point(61, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 187);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbSinhVien
            // 
            this.cbSinhVien.AutoSize = true;
            this.cbSinhVien.Location = new System.Drawing.Point(343, 53);
            this.cbSinhVien.Name = "cbSinhVien";
            this.cbSinhVien.Size = new System.Drawing.Size(71, 17);
            this.cbSinhVien.TabIndex = 8;
            this.cbSinhVien.Text = "Sinh Viên";
            this.cbSinhVien.UseVisualStyleBackColor = true;
            this.cbSinhVien.CheckedChanged += new System.EventHandler(this.cbSinhVien_CheckedChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(278, 134);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(91, 134);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btnDangNhap.TabIndex = 6;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtMatMa
            // 
            this.txtMatMa.Location = new System.Drawing.Point(112, 92);
            this.txtMatMa.Name = "txtMatMa";
            this.txtMatMa.PasswordChar = '*';
            this.txtMatMa.Size = new System.Drawing.Size(213, 20);
            this.txtMatMa.TabIndex = 5;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(112, 51);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(213, 20);
            this.txtTaiKhoan.TabIndex = 4;
            // 
            // cmbCoSo
            // 
            this.cmbCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoSo.FormattingEnabled = true;
            this.cmbCoSo.Location = new System.Drawing.Point(112, 14);
            this.cmbCoSo.Name = "cmbCoSo";
            this.cmbCoSo.Size = new System.Drawing.Size(213, 21);
            this.cmbCoSo.TabIndex = 3;
            this.cmbCoSo.SelectedIndexChanged += new System.EventHandler(this.cmbCoSo_SelectedIndexChanged);
            // 
            // lbMatMa
            // 
            this.lbMatMa.AutoSize = true;
            this.lbMatMa.Location = new System.Drawing.Point(44, 96);
            this.lbMatMa.Name = "lbMatMa";
            this.lbMatMa.Size = new System.Drawing.Size(45, 13);
            this.lbMatMa.TabIndex = 2;
            this.lbMatMa.Text = "Mật mã:";
            // 
            // lbTaiKhoan
            // 
            this.lbTaiKhoan.AutoSize = true;
            this.lbTaiKhoan.Location = new System.Drawing.Point(31, 55);
            this.lbTaiKhoan.Name = "lbTaiKhoan";
            this.lbTaiKhoan.Size = new System.Drawing.Size(58, 13);
            this.lbTaiKhoan.TabIndex = 1;
            this.lbTaiKhoan.Text = "Tài khoản:";
            // 
            // lbCoSo
            // 
            this.lbCoSo.AutoSize = true;
            this.lbCoSo.Location = new System.Drawing.Point(52, 18);
            this.lbCoSo.Name = "lbCoSo";
            this.lbCoSo.Size = new System.Drawing.Size(37, 13);
            this.lbCoSo.TabIndex = 0;
            this.lbCoSo.Text = "Cơ sở:";
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 301);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbMatMa;
        private System.Windows.Forms.Label lbTaiKhoan;
        private System.Windows.Forms.Label lbCoSo;
        private System.Windows.Forms.ComboBox cmbCoSo;
        private System.Windows.Forms.TextBox txtMatMa;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.CheckBox cbSinhVien;
    }
}