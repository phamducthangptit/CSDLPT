namespace THITRACNGHIEM
{
    partial class frmTaoTK
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label tENGVLabel;
            System.Windows.Forms.Label mAGVLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaoTK));
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.bar6 = new DevExpress.XtraBars.Bar();
            this.btnHieuChinh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbGV = new System.Windows.Forms.ComboBox();
            this.txtMaGV = new DevExpress.XtraEditors.TextEdit();
            this.bdsThongTinDK = new System.Windows.Forms.BindingSource(this.components);
            this.DSTKTaiKhoan = new THITRACNGHIEM.DSTKTaiKhoan();
            this.btnTTK = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.cmbNhom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMatMa = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.cmbCoSo = new System.Windows.Forms.ComboBox();
            this.lbMatMa = new System.Windows.Forms.Label();
            this.lbTaiKhoan = new System.Windows.Forms.Label();
            this.lbCoSo = new System.Windows.Forms.Label();
            this.SP_THONG_TIN_DK_TKTableAdapter = new THITRACNGHIEM.DSTKTaiKhoanTableAdapters.SP_THONG_TIN_DK_TKTableAdapter();
            this.tableAdapterManager = new THITRACNGHIEM.DSTKTaiKhoanTableAdapters.TableAdapterManager();
            tENGVLabel = new System.Windows.Forms.Label();
            mAGVLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaGV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsThongTinDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSTKTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // tENGVLabel
            // 
            tENGVLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            tENGVLabel.AutoSize = true;
            tENGVLabel.Location = new System.Drawing.Point(159, 212);
            tENGVLabel.Name = "tENGVLabel";
            tENGVLabel.Size = new System.Drawing.Size(61, 13);
            tENGVLabel.TabIndex = 11;
            tENGVLabel.Text = "Giảng viên:";
            // 
            // mAGVLabel
            // 
            mAGVLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            mAGVLabel.AutoSize = true;
            mAGVLabel.Location = new System.Drawing.Point(468, 212);
            mAGVLabel.Name = "mAGVLabel";
            mAGVLabel.Size = new System.Drawing.Size(77, 13);
            mAGVLabel.TabIndex = 16;
            mAGVLabel.Text = "Mã giảng viên:";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Main menu";
            // 
            // bar4
            // 
            this.bar4.BarName = "Tools";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 1;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.Text = "Tools";
            // 
            // bar5
            // 
            this.bar5.BarName = "Main menu";
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar5.OptionsBar.MultiLine = true;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Main menu";
            // 
            // bar6
            // 
            this.bar6.BarName = "Tools";
            this.bar6.DockCol = 0;
            this.bar6.DockRow = 1;
            this.bar6.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar6.Text = "Tools";
            // 
            // btnHieuChinh
            // 
            this.btnHieuChinh.Caption = "Hiệu chỉnh";
            this.btnHieuChinh.Id = 1;
            this.btnHieuChinh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnHieuChinh.ImageOptions.SvgImage")));
            this.btnHieuChinh.Name = "btnHieuChinh";
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Caption = "Phục hồi";
            this.btnPhucHoi.Id = 4;
            this.btnPhucHoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhucHoi.ImageOptions.SvgImage")));
            this.btnPhucHoi.Name = "btnPhucHoi";
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Reload";
            this.btnReload.Id = 5;
            this.btnReload.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReload.ImageOptions.SvgImage")));
            this.btnReload.Name = "btnReload";
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(801, 0);
            this.barDockControlRight.Manager = null;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 421);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.cmbGV);
            this.panelControl1.Controls.Add(mAGVLabel);
            this.panelControl1.Controls.Add(this.txtMaGV);
            this.panelControl1.Controls.Add(this.btnTTK);
            this.panelControl1.Controls.Add(this.btnHuy);
            this.panelControl1.Controls.Add(this.cmbNhom);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(tENGVLabel);
            this.panelControl1.Controls.Add(this.txtMatMa);
            this.panelControl1.Controls.Add(this.txtTaiKhoan);
            this.panelControl1.Controls.Add(this.cmbCoSo);
            this.panelControl1.Controls.Add(this.lbMatMa);
            this.panelControl1.Controls.Add(this.lbTaiKhoan);
            this.panelControl1.Controls.Add(this.lbCoSo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(801, 421);
            this.panelControl1.TabIndex = 2;
            // 
            // cmbGV
            // 
            this.cmbGV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbGV.FormattingEnabled = true;
            this.cmbGV.Location = new System.Drawing.Point(244, 207);
            this.cmbGV.Name = "cmbGV";
            this.cmbGV.Size = new System.Drawing.Size(213, 21);
            this.cmbGV.TabIndex = 18;
            this.cmbGV.SelectedIndexChanged += new System.EventHandler(this.cmbGV_SelectedIndexChanged);
            // 
            // txtMaGV
            // 
            this.txtMaGV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMaGV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsThongTinDK, "MAGV", true));
            this.txtMaGV.Enabled = false;
            this.txtMaGV.Location = new System.Drawing.Point(551, 209);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(100, 20);
            this.txtMaGV.TabIndex = 17;
            // 
            // bdsThongTinDK
            // 
            this.bdsThongTinDK.DataMember = "SP_THONG_TIN_DK_TK";
            this.bdsThongTinDK.DataSource = this.DSTKTaiKhoan;
            // 
            // DSTKTaiKhoan
            // 
            this.DSTKTaiKhoan.DataSetName = "DSTKTaiKhoan";
            this.DSTKTaiKhoan.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnTTK
            // 
            this.btnTTK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTTK.Location = new System.Drawing.Point(380, 308);
            this.btnTTK.Name = "btnTTK";
            this.btnTTK.Size = new System.Drawing.Size(90, 23);
            this.btnTTK.TabIndex = 16;
            this.btnTTK.Text = "Tạo tài khoản";
            this.btnTTK.UseVisualStyleBackColor = true;
            this.btnTTK.Click += new System.EventHandler(this.btnTTK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHuy.Location = new System.Drawing.Point(213, 308);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 15;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // cmbNhom
            // 
            this.cmbNhom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbNhom.FormattingEnabled = true;
            this.cmbNhom.Location = new System.Drawing.Point(244, 254);
            this.cmbNhom.Name = "cmbNhom";
            this.cmbNhom.Size = new System.Drawing.Size(213, 21);
            this.cmbNhom.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nhóm quyền:";
            // 
            // txtMatMa
            // 
            this.txtMatMa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMatMa.Location = new System.Drawing.Point(244, 167);
            this.txtMatMa.Name = "txtMatMa";
            this.txtMatMa.PasswordChar = '*';
            this.txtMatMa.Size = new System.Drawing.Size(213, 21);
            this.txtMatMa.TabIndex = 11;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTaiKhoan.Location = new System.Drawing.Point(244, 126);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(213, 21);
            this.txtTaiKhoan.TabIndex = 10;
            // 
            // cmbCoSo
            // 
            this.cmbCoSo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCoSo.FormattingEnabled = true;
            this.cmbCoSo.Location = new System.Drawing.Point(244, 89);
            this.cmbCoSo.Name = "cmbCoSo";
            this.cmbCoSo.Size = new System.Drawing.Size(213, 21);
            this.cmbCoSo.TabIndex = 9;
            this.cmbCoSo.SelectedIndexChanged += new System.EventHandler(this.cmbCoSo_SelectedIndexChanged);
            // 
            // lbMatMa
            // 
            this.lbMatMa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbMatMa.AutoSize = true;
            this.lbMatMa.Location = new System.Drawing.Point(174, 168);
            this.lbMatMa.Name = "lbMatMa";
            this.lbMatMa.Size = new System.Drawing.Size(46, 13);
            this.lbMatMa.TabIndex = 8;
            this.lbMatMa.Text = "Mật mã:";
            // 
            // lbTaiKhoan
            // 
            this.lbTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTaiKhoan.AutoSize = true;
            this.lbTaiKhoan.Location = new System.Drawing.Point(163, 132);
            this.lbTaiKhoan.Name = "lbTaiKhoan";
            this.lbTaiKhoan.Size = new System.Drawing.Size(57, 13);
            this.lbTaiKhoan.TabIndex = 7;
            this.lbTaiKhoan.Text = "Tài khoản:";
            // 
            // lbCoSo
            // 
            this.lbCoSo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCoSo.AutoSize = true;
            this.lbCoSo.Location = new System.Drawing.Point(182, 91);
            this.lbCoSo.Name = "lbCoSo";
            this.lbCoSo.Size = new System.Drawing.Size(38, 13);
            this.lbCoSo.TabIndex = 6;
            this.lbCoSo.Text = "Cơ sở:";
            // 
            // SP_THONG_TIN_DK_TKTableAdapter
            // 
            this.SP_THONG_TIN_DK_TKTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = THITRACNGHIEM.DSTKTaiKhoanTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // frmTaoTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 421);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlRight);
            this.Name = "frmTaoTK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TAOTK";
            this.Load += new System.EventHandler(this.TAOTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaGV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsThongTinDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSTKTaiKhoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.Bar bar6;
        private DevExpress.XtraBars.BarButtonItem btnHieuChinh;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnTTK;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.ComboBox cmbNhom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatMa;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.ComboBox cmbCoSo;
        private System.Windows.Forms.Label lbMatMa;
        private System.Windows.Forms.Label lbTaiKhoan;
        private System.Windows.Forms.Label lbCoSo;
        private DSTKTaiKhoan DSTKTaiKhoan;
        private System.Windows.Forms.BindingSource bdsThongTinDK;
        private DSTKTaiKhoanTableAdapters.SP_THONG_TIN_DK_TKTableAdapter SP_THONG_TIN_DK_TKTableAdapter;
        private DSTKTaiKhoanTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbGV;
        private DevExpress.XtraEditors.TextEdit txtMaGV;
    }
}