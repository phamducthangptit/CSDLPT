namespace THITRACNGHIEM
{
    partial class frmChuanBiThiSV
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
            System.Windows.Forms.Label mAMHLabel;
            System.Windows.Forms.Label mALOPLabel;
            System.Windows.Forms.Label tRINHDOLabel;
            System.Windows.Forms.Label tENMHLabel;
            System.Windows.Forms.Label tENLOPLabel;
            System.Windows.Forms.Label nGAYTHILabel;
            System.Windows.Forms.Label lANLabel;
            System.Windows.Forms.Label tHOIGIANLabel;
            System.Windows.Forms.Label sOCAUTHILabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChuanBiThiSV));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dSChuanBiThi = new THITRACNGHIEM.DSChuanBiThi();
            this.bdsGVDK = new System.Windows.Forms.BindingSource(this.components);
            this.GIAOVIEN_DANGKYTableAdapter = new THITRACNGHIEM.DSChuanBiThiTableAdapters.GIAOVIEN_DANGKYTableAdapter();
            this.tableAdapterManager = new THITRACNGHIEM.DSChuanBiThiTableAdapters.TableAdapterManager();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGVDK = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMALOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRINHDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOCAUTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTHOIGIAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoCauThi = new System.Windows.Forms.TextBox();
            this.txtTG = new System.Windows.Forms.TextBox();
            this.txtLan = new System.Windows.Forms.TextBox();
            this.txtNgayThi = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.bdsLop = new System.Windows.Forms.BindingSource(this.components);
            this.txtTenMH = new System.Windows.Forms.TextBox();
            this.bdsMonHoc = new System.Windows.Forms.BindingSource(this.components);
            this.tRINHDOTextBox = new System.Windows.Forms.TextBox();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.btnXemLaiKQ = new System.Windows.Forms.Button();
            this.btnVaoThi = new System.Windows.Forms.Button();
            this.MONHOCTableAdapter = new THITRACNGHIEM.DSChuanBiThiTableAdapters.MONHOCTableAdapter();
            this.LOPTableAdapter = new THITRACNGHIEM.DSChuanBiThiTableAdapters.LOPTableAdapter();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            mAMHLabel = new System.Windows.Forms.Label();
            mALOPLabel = new System.Windows.Forms.Label();
            tRINHDOLabel = new System.Windows.Forms.Label();
            tENMHLabel = new System.Windows.Forms.Label();
            tENLOPLabel = new System.Windows.Forms.Label();
            nGAYTHILabel = new System.Windows.Forms.Label();
            lANLabel = new System.Windows.Forms.Label();
            tHOIGIANLabel = new System.Windows.Forms.Label();
            sOCAUTHILabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSChuanBiThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGVDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGVDK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mAMHLabel
            // 
            mAMHLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            mAMHLabel.AutoSize = true;
            mAMHLabel.Location = new System.Drawing.Point(25, 46);
            mAMHLabel.Name = "mAMHLabel";
            mAMHLabel.Size = new System.Drawing.Size(78, 22);
            mAMHLabel.TabIndex = 2;
            mAMHLabel.Text = "Mã MH:";
            // 
            // mALOPLabel
            // 
            mALOPLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            mALOPLabel.AutoSize = true;
            mALOPLabel.Location = new System.Drawing.Point(18, 150);
            mALOPLabel.Name = "mALOPLabel";
            mALOPLabel.Size = new System.Drawing.Size(74, 22);
            mALOPLabel.TabIndex = 4;
            mALOPLabel.Text = "Mã lớp:";
            // 
            // tRINHDOLabel
            // 
            tRINHDOLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            tRINHDOLabel.AutoSize = true;
            tRINHDOLabel.Location = new System.Drawing.Point(740, 113);
            tRINHDOLabel.Name = "tRINHDOLabel";
            tRINHDOLabel.Size = new System.Drawing.Size(83, 22);
            tRINHDOLabel.TabIndex = 6;
            tRINHDOLabel.Text = "Trình độ:";
            // 
            // tENMHLabel
            // 
            tENMHLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            tENMHLabel.AutoSize = true;
            tENMHLabel.Location = new System.Drawing.Point(18, 96);
            tENMHLabel.Name = "tENMHLabel";
            tENMHLabel.Size = new System.Drawing.Size(82, 22);
            tENMHLabel.TabIndex = 16;
            tENMHLabel.Text = "Tên MH:";
            // 
            // tENLOPLabel
            // 
            tENLOPLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            tENLOPLabel.AutoSize = true;
            tENLOPLabel.Location = new System.Drawing.Point(18, 204);
            tENLOPLabel.Name = "tENLOPLabel";
            tENLOPLabel.Size = new System.Drawing.Size(78, 22);
            tENLOPLabel.TabIndex = 18;
            tENLOPLabel.Text = "Tên lớp:";
            // 
            // nGAYTHILabel
            // 
            nGAYTHILabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            nGAYTHILabel.AutoSize = true;
            nGAYTHILabel.Location = new System.Drawing.Point(412, 51);
            nGAYTHILabel.Name = "nGAYTHILabel";
            nGAYTHILabel.Size = new System.Drawing.Size(82, 22);
            nGAYTHILabel.TabIndex = 19;
            nGAYTHILabel.Text = "Ngày thi:";
            // 
            // lANLabel
            // 
            lANLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            lANLabel.AutoSize = true;
            lANLabel.Location = new System.Drawing.Point(451, 113);
            lANLabel.Name = "lANLabel";
            lANLabel.Size = new System.Drawing.Size(45, 22);
            lANLabel.TabIndex = 20;
            lANLabel.Text = "Lần:";
            // 
            // tHOIGIANLabel
            // 
            tHOIGIANLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            tHOIGIANLabel.AutoSize = true;
            tHOIGIANLabel.Location = new System.Drawing.Point(402, 183);
            tHOIGIANLabel.Name = "tHOIGIANLabel";
            tHOIGIANLabel.Size = new System.Drawing.Size(92, 22);
            tHOIGIANLabel.TabIndex = 21;
            tHOIGIANLabel.Text = "Thời gian:";
            // 
            // sOCAUTHILabel
            // 
            sOCAUTHILabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            sOCAUTHILabel.AutoSize = true;
            sOCAUTHILabel.Location = new System.Drawing.Point(730, 51);
            sOCAUTHILabel.Name = "sOCAUTHILabel";
            sOCAUTHILabel.Size = new System.Drawing.Size(94, 22);
            sOCAUTHILabel.TabIndex = 22;
            sOCAUTHILabel.Text = "Số câu thi:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 55);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(410, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH MÔN THI";
            // 
            // dSChuanBiThi
            // 
            this.dSChuanBiThi.DataSetName = "DSChuanBiThi";
            this.dSChuanBiThi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsGVDK
            // 
            this.bdsGVDK.DataMember = "GIAOVIEN_DANGKY";
            this.bdsGVDK.DataSource = this.dSChuanBiThi;
            // 
            // GIAOVIEN_DANGKYTableAdapter
            // 
            this.GIAOVIEN_DANGKYTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.GIAOVIEN_DANGKYTableAdapter = this.GIAOVIEN_DANGKYTableAdapter;
            this.tableAdapterManager.LOPTableAdapter = null;
            this.tableAdapterManager.MONHOCTableAdapter = null;
            this.tableAdapterManager.SINHVIENTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = THITRACNGHIEM.DSChuanBiThiTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Chọn Thi";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Chọn Thi";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Width = 94;
            // 
            // gcGVDK
            // 
            this.gcGVDK.DataSource = this.bdsGVDK;
            this.gcGVDK.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcGVDK.Location = new System.Drawing.Point(0, 106);
            this.gcGVDK.MainView = this.gridView1;
            this.gcGVDK.Name = "gcGVDK";
            this.gcGVDK.Size = new System.Drawing.Size(1171, 242);
            this.gcGVDK.TabIndex = 1;
            this.gcGVDK.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcGVDK.Click += new System.EventHandler(this.gcGVDK_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAMH,
            this.colMALOP,
            this.colTRINHDO,
            this.colNGAYTHI,
            this.colLAN,
            this.colSOCAUTHI,
            this.colTHOIGIAN});
            this.gridView1.GridControl = this.gcGVDK;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colMAMH
            // 
            this.colMAMH.FieldName = "MAMH";
            this.colMAMH.MinWidth = 25;
            this.colMAMH.Name = "colMAMH";
            this.colMAMH.Visible = true;
            this.colMAMH.VisibleIndex = 0;
            this.colMAMH.Width = 94;
            // 
            // colMALOP
            // 
            this.colMALOP.FieldName = "MALOP";
            this.colMALOP.MinWidth = 25;
            this.colMALOP.Name = "colMALOP";
            this.colMALOP.Visible = true;
            this.colMALOP.VisibleIndex = 1;
            this.colMALOP.Width = 94;
            // 
            // colTRINHDO
            // 
            this.colTRINHDO.FieldName = "TRINHDO";
            this.colTRINHDO.MinWidth = 25;
            this.colTRINHDO.Name = "colTRINHDO";
            this.colTRINHDO.Visible = true;
            this.colTRINHDO.VisibleIndex = 2;
            this.colTRINHDO.Width = 94;
            // 
            // colNGAYTHI
            // 
            this.colNGAYTHI.FieldName = "NGAYTHI";
            this.colNGAYTHI.MinWidth = 25;
            this.colNGAYTHI.Name = "colNGAYTHI";
            this.colNGAYTHI.Visible = true;
            this.colNGAYTHI.VisibleIndex = 3;
            this.colNGAYTHI.Width = 94;
            // 
            // colLAN
            // 
            this.colLAN.FieldName = "LAN";
            this.colLAN.MinWidth = 25;
            this.colLAN.Name = "colLAN";
            this.colLAN.Visible = true;
            this.colLAN.VisibleIndex = 4;
            this.colLAN.Width = 94;
            // 
            // colSOCAUTHI
            // 
            this.colSOCAUTHI.FieldName = "SOCAUTHI";
            this.colSOCAUTHI.MinWidth = 25;
            this.colSOCAUTHI.Name = "colSOCAUTHI";
            this.colSOCAUTHI.Visible = true;
            this.colSOCAUTHI.VisibleIndex = 5;
            this.colSOCAUTHI.Width = 94;
            // 
            // colTHOIGIAN
            // 
            this.colTHOIGIAN.FieldName = "THOIGIAN";
            this.colTHOIGIAN.MinWidth = 25;
            this.colTHOIGIAN.Name = "colTHOIGIAN";
            this.colTHOIGIAN.Visible = true;
            this.colTHOIGIAN.VisibleIndex = 6;
            this.colTHOIGIAN.Width = 94;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(sOCAUTHILabel);
            this.groupBox1.Controls.Add(this.txtSoCauThi);
            this.groupBox1.Controls.Add(tHOIGIANLabel);
            this.groupBox1.Controls.Add(this.txtTG);
            this.groupBox1.Controls.Add(lANLabel);
            this.groupBox1.Controls.Add(this.txtLan);
            this.groupBox1.Controls.Add(nGAYTHILabel);
            this.groupBox1.Controls.Add(this.txtNgayThi);
            this.groupBox1.Controls.Add(tENLOPLabel);
            this.groupBox1.Controls.Add(this.txtTenLop);
            this.groupBox1.Controls.Add(tENMHLabel);
            this.groupBox1.Controls.Add(this.txtTenMH);
            this.groupBox1.Controls.Add(tRINHDOLabel);
            this.groupBox1.Controls.Add(this.tRINHDOTextBox);
            this.groupBox1.Controls.Add(mALOPLabel);
            this.groupBox1.Controls.Add(this.txtMaLop);
            this.groupBox1.Controls.Add(mAMHLabel);
            this.groupBox1.Controls.Add(this.txtMaMH);
            this.groupBox1.Controls.Add(this.btnXemLaiKQ);
            this.groupBox1.Controls.Add(this.btnVaoThi);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 348);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1171, 223);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // txtSoCauThi
            // 
            this.txtSoCauThi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSoCauThi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "SOCAUTHI", true));
            this.txtSoCauThi.Location = new System.Drawing.Point(830, 48);
            this.txtSoCauThi.Name = "txtSoCauThi";
            this.txtSoCauThi.ReadOnly = true;
            this.txtSoCauThi.Size = new System.Drawing.Size(100, 30);
            this.txtSoCauThi.TabIndex = 23;
            // 
            // txtTG
            // 
            this.txtTG.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTG.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "THOIGIAN", true));
            this.txtTG.Location = new System.Drawing.Point(512, 175);
            this.txtTG.Name = "txtTG";
            this.txtTG.ReadOnly = true;
            this.txtTG.Size = new System.Drawing.Size(173, 30);
            this.txtTG.TabIndex = 22;
            // 
            // txtLan
            // 
            this.txtLan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLan.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "LAN", true));
            this.txtLan.Location = new System.Drawing.Point(512, 110);
            this.txtLan.Name = "txtLan";
            this.txtLan.ReadOnly = true;
            this.txtLan.Size = new System.Drawing.Size(173, 30);
            this.txtLan.TabIndex = 21;
            // 
            // txtNgayThi
            // 
            this.txtNgayThi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNgayThi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "NGAYTHI", true));
            this.txtNgayThi.Location = new System.Drawing.Point(512, 48);
            this.txtNgayThi.Name = "txtNgayThi";
            this.txtNgayThi.ReadOnly = true;
            this.txtNgayThi.Size = new System.Drawing.Size(173, 30);
            this.txtNgayThi.TabIndex = 20;
            // 
            // txtTenLop
            // 
            this.txtTenLop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTenLop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsLop, "TENLOP", true));
            this.txtTenLop.Location = new System.Drawing.Point(109, 201);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.ReadOnly = true;
            this.txtTenLop.Size = new System.Drawing.Size(261, 30);
            this.txtTenLop.TabIndex = 19;
            // 
            // bdsLop
            // 
            this.bdsLop.DataMember = "LOP";
            this.bdsLop.DataSource = this.dSChuanBiThi;
            // 
            // txtTenMH
            // 
            this.txtTenMH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTenMH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsMonHoc, "TENMH", true));
            this.txtTenMH.Location = new System.Drawing.Point(109, 93);
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.ReadOnly = true;
            this.txtTenMH.Size = new System.Drawing.Size(261, 30);
            this.txtTenMH.TabIndex = 17;
            // 
            // bdsMonHoc
            // 
            this.bdsMonHoc.DataMember = "MONHOC";
            this.bdsMonHoc.DataSource = this.dSChuanBiThi;
            // 
            // tRINHDOTextBox
            // 
            this.tRINHDOTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tRINHDOTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "TRINHDO", true));
            this.tRINHDOTextBox.Location = new System.Drawing.Point(829, 110);
            this.tRINHDOTextBox.Name = "tRINHDOTextBox";
            this.tRINHDOTextBox.ReadOnly = true;
            this.tRINHDOTextBox.Size = new System.Drawing.Size(100, 30);
            this.tRINHDOTextBox.TabIndex = 7;
            // 
            // txtMaLop
            // 
            this.txtMaLop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMaLop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "MALOP", true));
            this.txtMaLop.Location = new System.Drawing.Point(109, 147);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.ReadOnly = true;
            this.txtMaLop.Size = new System.Drawing.Size(130, 30);
            this.txtMaLop.TabIndex = 5;
            // 
            // txtMaMH
            // 
            this.txtMaMH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMaMH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsGVDK, "MAMH", true));
            this.txtMaMH.Location = new System.Drawing.Point(109, 43);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.ReadOnly = true;
            this.txtMaMH.Size = new System.Drawing.Size(130, 30);
            this.txtMaMH.TabIndex = 3;
            // 
            // btnXemLaiKQ
            // 
            this.btnXemLaiKQ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXemLaiKQ.Location = new System.Drawing.Point(997, 175);
            this.btnXemLaiKQ.Name = "btnXemLaiKQ";
            this.btnXemLaiKQ.Size = new System.Drawing.Size(150, 37);
            this.btnXemLaiKQ.TabIndex = 1;
            this.btnXemLaiKQ.Text = "Xem lại bài thi";
            this.btnXemLaiKQ.UseVisualStyleBackColor = true;
            this.btnXemLaiKQ.Click += new System.EventHandler(this.btnXemLaiKQ_Click);
            // 
            // btnVaoThi
            // 
            this.btnVaoThi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVaoThi.Location = new System.Drawing.Point(993, 86);
            this.btnVaoThi.Name = "btnVaoThi";
            this.btnVaoThi.Size = new System.Drawing.Size(154, 37);
            this.btnVaoThi.TabIndex = 0;
            this.btnVaoThi.Text = "Vào thi";
            this.btnVaoThi.UseVisualStyleBackColor = true;
            this.btnVaoThi.Click += new System.EventHandler(this.btnVaoThi_Click);
            // 
            // MONHOCTableAdapter
            // 
            this.MONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // LOPTableAdapter
            // 
            this.LOPTableAdapter.ClearBeforeFill = true;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Reload";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem1.ImageOptions.SvgImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
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
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1171, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 571);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1171, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 520);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1171, 51);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 520);
            // 
            // frmChuanBiThiSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 591);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gcGVDK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChuanBiThiSV";
            this.Text = "Chuẩn bị thi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChuanBiThi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dSChuanBiThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsGVDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGVDK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DSChuanBiThi dSChuanBiThi;
        private System.Windows.Forms.BindingSource bdsGVDK;
        private DSChuanBiThiTableAdapters.GIAOVIEN_DANGKYTableAdapter GIAOVIEN_DANGKYTableAdapter;
        private DSChuanBiThiTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gcGVDK;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colMALOP;
        private DevExpress.XtraGrid.Columns.GridColumn colTRINHDO;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colLAN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOCAUTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTHOIGIAN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tRINHDOTextBox;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.Button btnXemLaiKQ;
        private System.Windows.Forms.Button btnVaoThi;
        private System.Windows.Forms.BindingSource bdsMonHoc;
        private DSChuanBiThiTableAdapters.MONHOCTableAdapter MONHOCTableAdapter;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.BindingSource bdsLop;
        private DSChuanBiThiTableAdapters.LOPTableAdapter LOPTableAdapter;
        private System.Windows.Forms.TextBox txtSoCauThi;
        private System.Windows.Forms.TextBox txtTG;
        private System.Windows.Forms.TextBox txtLan;
        private System.Windows.Forms.TextBox txtNgayThi;
        private System.Windows.Forms.TextBox txtTenLop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}