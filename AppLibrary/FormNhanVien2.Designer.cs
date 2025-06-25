namespace AppLibrary
{
    partial class FormNhanVien2
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
            System.Windows.Forms.Label hONVLabel;
            System.Windows.Forms.Label tENNVLabel;
            System.Windows.Forms.Label dIACHILabel;
            System.Windows.Forms.Label dIENTHOAILabel;
            System.Windows.Forms.Label eMAILLabel;
            System.Windows.Forms.Label gIOITINHLabel;
            System.Windows.Forms.Label tRANGTHAIXOALabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanVien2));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barChucNang = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnRedo = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhSach = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.pnINPUT = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.rbHOATDONG = new System.Windows.Forms.RadioButton();
            this.nHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.rbNGHI = new System.Windows.Forms.RadioButton();
            this.lblMA = new DevExpress.XtraEditors.LabelControl();
            this.rbNU = new System.Windows.Forms.RadioButton();
            this.rbNAM = new System.Windows.Forms.RadioButton();
            this.txtEMAIL = new DevExpress.XtraEditors.TextEdit();
            this.txtDIENTHOAI = new DevExpress.XtraEditors.TextEdit();
            this.txtTEN = new DevExpress.XtraEditors.TextEdit();
            this.txtHO = new DevExpress.XtraEditors.TextEdit();
            this.txtMA = new DevExpress.XtraEditors.SpinEdit();
            this.txtDIACHI = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gcNHANVIEN = new DevExpress.XtraGrid.GridControl();
            this.gvNHANVIEN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHONV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIOITINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.nHANVIENGIOITINHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIENTHOAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRANGTHAIXOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.nHANVIENTRANGTHAIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gIOITINHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nHANVIENTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.NHANVIENTableAdapter();
            this.tableAdapterManager = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.cT_PHIEUMUONTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.CT_PHIEUMUONTableAdapter();
            this.pHIEUMUONTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.PHIEUMUONTableAdapter();
            this.gIOITINHTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.GIOITINHTableAdapter();
            this.pHIEUMUONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cT_PHIEUMUONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nHANVIEN_TRANGTHAITableAdapter = new AppLibrary.QLTVDataSetTableAdapters.NHANVIEN_TRANGTHAITableAdapter();
            this.nHANVIEN_GIOITINHTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.NHANVIEN_GIOITINHTableAdapter();
            hONVLabel = new System.Windows.Forms.Label();
            tENNVLabel = new System.Windows.Forms.Label();
            dIACHILabel = new System.Windows.Forms.Label();
            dIENTHOAILabel = new System.Windows.Forms.Label();
            eMAILLabel = new System.Windows.Forms.Label();
            gIOITINHLabel = new System.Windows.Forms.Label();
            tRANGTHAIXOALabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnINPUT)).BeginInit();
            this.pnINPUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMAIL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIENTHOAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIACHI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNHANVIEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNHANVIEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENGIOITINHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENTRANGTHAIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIOITINHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUMUONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cT_PHIEUMUONBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // hONVLabel
            // 
            hONVLabel.AutoSize = true;
            hONVLabel.Location = new System.Drawing.Point(108, 74);
            hONVLabel.Name = "hONVLabel";
            hONVLabel.Size = new System.Drawing.Size(57, 19);
            hONVLabel.TabIndex = 2;
            hONVLabel.Text = "HONV:";
            // 
            // tENNVLabel
            // 
            tENNVLabel.AutoSize = true;
            tENNVLabel.Location = new System.Drawing.Point(101, 118);
            tENNVLabel.Name = "tENNVLabel";
            tENNVLabel.Size = new System.Drawing.Size(64, 19);
            tENNVLabel.TabIndex = 4;
            tENNVLabel.Text = "TENNV:";
            // 
            // dIACHILabel
            // 
            dIACHILabel.AutoSize = true;
            dIACHILabel.Location = new System.Drawing.Point(505, 63);
            dIACHILabel.Name = "dIACHILabel";
            dIACHILabel.Size = new System.Drawing.Size(66, 19);
            dIACHILabel.TabIndex = 8;
            dIACHILabel.Text = "DIACHI:";
            // 
            // dIENTHOAILabel
            // 
            dIENTHOAILabel.AutoSize = true;
            dIENTHOAILabel.Location = new System.Drawing.Point(968, 18);
            dIENTHOAILabel.Name = "dIENTHOAILabel";
            dIENTHOAILabel.Size = new System.Drawing.Size(97, 19);
            dIENTHOAILabel.TabIndex = 10;
            dIENTHOAILabel.Text = "DIENTHOAI:";
            // 
            // eMAILLabel
            // 
            eMAILLabel.AutoSize = true;
            eMAILLabel.Location = new System.Drawing.Point(996, 68);
            eMAILLabel.Name = "eMAILLabel";
            eMAILLabel.Size = new System.Drawing.Size(60, 19);
            eMAILLabel.TabIndex = 12;
            eMAILLabel.Text = "EMAIL:";
            // 
            // gIOITINHLabel
            // 
            gIOITINHLabel.AutoSize = true;
            gIOITINHLabel.Location = new System.Drawing.Point(489, 23);
            gIOITINHLabel.Name = "gIOITINHLabel";
            gIOITINHLabel.Size = new System.Drawing.Size(82, 19);
            gIOITINHLabel.TabIndex = 13;
            gIOITINHLabel.Text = "GIOITINH:";
            // 
            // tRANGTHAIXOALabel
            // 
            tRANGTHAIXOALabel.AutoSize = true;
            tRANGTHAIXOALabel.Location = new System.Drawing.Point(930, 113);
            tRANGTHAIXOALabel.Name = "tRANGTHAIXOALabel";
            tRANGTHAIXOALabel.Size = new System.Drawing.Size(135, 19);
            tRANGTHAIXOALabel.TabIndex = 16;
            tRANGTHAIXOALabel.Text = "TRANGTHAIXOA:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barChucNang,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnSua,
            this.btnGhi,
            this.btnXoa,
            this.btnUndo,
            this.btnRefresh,
            this.btnDanhSach,
            this.btnThoat,
            this.barButtonItem9,
            this.btnRedo});
            this.barManager1.MainMenu = this.barChucNang;
            this.barManager1.MaxItemId = 12;
            this.barManager1.StatusBar = this.bar3;
            // 
            // barChucNang
            // 
            this.barChucNang.BarName = "Main menu";
            this.barChucNang.DockCol = 0;
            this.barChucNang.DockRow = 0;
            this.barChucNang.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barChucNang.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRedo, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barChucNang.OptionsBar.MultiLine = true;
            this.barChucNang.OptionsBar.UseWholeRow = true;
            this.barChucNang.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGhi.ImageOptions.SvgImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 3;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.ImageOptions.SvgImageSize = new System.Drawing.Size(17, 17);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Id = 4;
            this.btnUndo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUndo.ImageOptions.SvgImage")));
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndo_ItemClick);
            // 
            // btnRedo
            // 
            this.btnRedo.Caption = "Redo";
            this.btnRedo.Id = 10;
            this.btnRedo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRedo.ImageOptions.SvgImage")));
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRedo_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 7;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1558, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 531);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1558, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 490);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1558, 41);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 490);
            // 
            // btnSua
            // 
            this.btnSua.Id = 11;
            this.btnSua.Name = "btnSua";
            // 
            // btnDanhSach
            // 
            this.btnDanhSach.Caption = "Danh sách đầu sách";
            this.btnDanhSach.Id = 6;
            this.btnDanhSach.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDanhSach.ImageOptions.SvgImage")));
            this.btnDanhSach.Name = "btnDanhSach";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "barButtonItem9";
            this.barButtonItem9.Id = 8;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // pnINPUT
            // 
            this.pnINPUT.Controls.Add(this.panelControl1);
            this.pnINPUT.Controls.Add(tRANGTHAIXOALabel);
            this.pnINPUT.Controls.Add(this.lblMA);
            this.pnINPUT.Controls.Add(gIOITINHLabel);
            this.pnINPUT.Controls.Add(this.rbNU);
            this.pnINPUT.Controls.Add(this.rbNAM);
            this.pnINPUT.Controls.Add(eMAILLabel);
            this.pnINPUT.Controls.Add(this.txtEMAIL);
            this.pnINPUT.Controls.Add(dIENTHOAILabel);
            this.pnINPUT.Controls.Add(this.txtDIENTHOAI);
            this.pnINPUT.Controls.Add(dIACHILabel);
            this.pnINPUT.Controls.Add(tENNVLabel);
            this.pnINPUT.Controls.Add(this.txtTEN);
            this.pnINPUT.Controls.Add(hONVLabel);
            this.pnINPUT.Controls.Add(this.txtHO);
            this.pnINPUT.Controls.Add(this.txtMA);
            this.pnINPUT.Controls.Add(this.txtDIACHI);
            this.pnINPUT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnINPUT.Location = new System.Drawing.Point(2, 267);
            this.pnINPUT.Name = "pnINPUT";
            this.pnINPUT.Size = new System.Drawing.Size(1554, 221);
            this.pnINPUT.TabIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.rbHOATDONG);
            this.panelControl1.Controls.Add(this.rbNGHI);
            this.panelControl1.Location = new System.Drawing.Point(1071, 98);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(213, 100);
            this.panelControl1.TabIndex = 18;
            // 
            // rbHOATDONG
            // 
            this.rbHOATDONG.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.nHANVIENBindingSource, "TRANGTHAIXOA", true));
            this.rbHOATDONG.Location = new System.Drawing.Point(5, 12);
            this.rbHOATDONG.Name = "rbHOATDONG";
            this.rbHOATDONG.Size = new System.Drawing.Size(190, 24);
            this.rbHOATDONG.TabIndex = 17;
            this.rbHOATDONG.TabStop = true;
            this.rbHOATDONG.Text = "ĐANG HOẠT ĐỘNG";
            this.rbHOATDONG.UseVisualStyleBackColor = true;
            this.rbHOATDONG.CheckedChanged += new System.EventHandler(this.rbHOATDONG_CheckedChanged);
            // 
            // nHANVIENBindingSource
            // 
            this.nHANVIENBindingSource.DataMember = "NHANVIEN";
            this.nHANVIENBindingSource.DataSource = this.qLTVDataSet;
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rbNGHI
            // 
            this.rbNGHI.Location = new System.Drawing.Point(5, 50);
            this.rbNGHI.Name = "rbNGHI";
            this.rbNGHI.Size = new System.Drawing.Size(190, 24);
            this.rbNGHI.TabIndex = 15;
            this.rbNGHI.TabStop = true;
            this.rbNGHI.Text = "NGHỈ";
            this.rbNGHI.UseVisualStyleBackColor = true;
            this.rbNGHI.CheckedChanged += new System.EventHandler(this.rbNGHI_CheckedChanged);
            // 
            // lblMA
            // 
            this.lblMA.Location = new System.Drawing.Point(133, 23);
            this.lblMA.Name = "lblMA";
            this.lblMA.Size = new System.Drawing.Size(28, 19);
            this.lblMA.TabIndex = 16;
            this.lblMA.Text = "MA:";
            // 
            // rbNU
            // 
            this.rbNU.Location = new System.Drawing.Point(696, 15);
            this.rbNU.Name = "rbNU";
            this.rbNU.Size = new System.Drawing.Size(104, 24);
            this.rbNU.TabIndex = 14;
            this.rbNU.TabStop = true;
            this.rbNU.Text = "NỮ";
            this.rbNU.UseVisualStyleBackColor = true;
            this.rbNU.CheckedChanged += new System.EventHandler(this.rbNU_CheckedChanged);
            // 
            // rbNAM
            // 
            this.rbNAM.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.nHANVIENBindingSource, "GIOITINH", true));
            this.rbNAM.Location = new System.Drawing.Point(586, 15);
            this.rbNAM.Name = "rbNAM";
            this.rbNAM.Size = new System.Drawing.Size(104, 24);
            this.rbNAM.TabIndex = 14;
            this.rbNAM.TabStop = true;
            this.rbNAM.Text = "NAM";
            this.rbNAM.UseVisualStyleBackColor = true;
            this.rbNAM.CheckedChanged += new System.EventHandler(this.rbNAM_CheckedChanged);
            // 
            // txtEMAIL
            // 
            this.txtEMAIL.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.nHANVIENBindingSource, "EMAIL", true));
            this.txtEMAIL.Location = new System.Drawing.Point(1071, 65);
            this.txtEMAIL.MenuManager = this.barManager1;
            this.txtEMAIL.Name = "txtEMAIL";
            this.txtEMAIL.Size = new System.Drawing.Size(281, 27);
            this.txtEMAIL.TabIndex = 13;
            // 
            // txtDIENTHOAI
            // 
            this.txtDIENTHOAI.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.nHANVIENBindingSource, "DIENTHOAI", true));
            this.txtDIENTHOAI.Location = new System.Drawing.Point(1071, 15);
            this.txtDIENTHOAI.MenuManager = this.barManager1;
            this.txtDIENTHOAI.Name = "txtDIENTHOAI";
            this.txtDIENTHOAI.Size = new System.Drawing.Size(281, 27);
            this.txtDIENTHOAI.TabIndex = 11;
            // 
            // txtTEN
            // 
            this.txtTEN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.nHANVIENBindingSource, "TENNV", true));
            this.txtTEN.Location = new System.Drawing.Point(171, 115);
            this.txtTEN.MenuManager = this.barManager1;
            this.txtTEN.Name = "txtTEN";
            this.txtTEN.Size = new System.Drawing.Size(279, 27);
            this.txtTEN.TabIndex = 5;
            // 
            // txtHO
            // 
            this.txtHO.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.nHANVIENBindingSource, "HONV", true));
            this.txtHO.Location = new System.Drawing.Point(171, 71);
            this.txtHO.MenuManager = this.barManager1;
            this.txtHO.Name = "txtHO";
            this.txtHO.Size = new System.Drawing.Size(279, 27);
            this.txtHO.TabIndex = 3;
            // 
            // txtMA
            // 
            this.txtMA.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.nHANVIENBindingSource, "MANV", true));
            this.txtMA.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMA.Enabled = false;
            this.txtMA.Location = new System.Drawing.Point(171, 20);
            this.txtMA.MenuManager = this.barManager1;
            this.txtMA.Name = "txtMA";
            this.txtMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMA.Size = new System.Drawing.Size(279, 30);
            this.txtMA.TabIndex = 1;
            // 
            // txtDIACHI
            // 
            this.txtDIACHI.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.nHANVIENBindingSource, "DIACHI", true));
            this.txtDIACHI.Location = new System.Drawing.Point(586, 60);
            this.txtDIACHI.MenuManager = this.barManager1;
            this.txtDIACHI.Name = "txtDIACHI";
            this.txtDIACHI.Size = new System.Drawing.Size(307, 112);
            this.txtDIACHI.TabIndex = 9;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Controls.Add(this.pnINPUT);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 41);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1558, 490);
            this.panelControl2.TabIndex = 5;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gcNHANVIEN);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1554, 265);
            this.panelControl3.TabIndex = 5;
            // 
            // gcNHANVIEN
            // 
            this.gcNHANVIEN.DataSource = this.nHANVIENBindingSource;
            this.gcNHANVIEN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcNHANVIEN.Location = new System.Drawing.Point(2, 2);
            this.gcNHANVIEN.MainView = this.gvNHANVIEN;
            this.gcNHANVIEN.MenuManager = this.barManager1;
            this.gcNHANVIEN.Name = "gcNHANVIEN";
            this.gcNHANVIEN.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemGridLookUpEdit2});
            this.gcNHANVIEN.Size = new System.Drawing.Size(1550, 261);
            this.gcNHANVIEN.TabIndex = 0;
            this.gcNHANVIEN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNHANVIEN});
            // 
            // gvNHANVIEN
            // 
            this.gvNHANVIEN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMANV,
            this.colHONV,
            this.colTENNV,
            this.colGIOITINH,
            this.colDIACHI,
            this.colDIENTHOAI,
            this.colEMAIL,
            this.colTRANGTHAIXOA});
            this.gvNHANVIEN.GridControl = this.gcNHANVIEN;
            this.gvNHANVIEN.Name = "gvNHANVIEN";
            this.gvNHANVIEN.OptionsBehavior.Editable = false;
            this.gvNHANVIEN.OptionsDetail.EnableMasterViewMode = false;
            this.gvNHANVIEN.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvNHANVIEN_RowStyle);
            this.gvNHANVIEN.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvNHANVIEN_FocusedRowChanged);
            // 
            // colMANV
            // 
            this.colMANV.Caption = "MÃ";
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 30;
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 0;
            this.colMANV.Width = 112;
            // 
            // colHONV
            // 
            this.colHONV.Caption = "HỌ";
            this.colHONV.FieldName = "HONV";
            this.colHONV.MinWidth = 30;
            this.colHONV.Name = "colHONV";
            this.colHONV.Visible = true;
            this.colHONV.VisibleIndex = 1;
            this.colHONV.Width = 112;
            // 
            // colTENNV
            // 
            this.colTENNV.Caption = "TÊN";
            this.colTENNV.FieldName = "TENNV";
            this.colTENNV.MinWidth = 30;
            this.colTENNV.Name = "colTENNV";
            this.colTENNV.Visible = true;
            this.colTENNV.VisibleIndex = 2;
            this.colTENNV.Width = 112;
            // 
            // colGIOITINH
            // 
            this.colGIOITINH.Caption = "GIỚI TÍNH";
            this.colGIOITINH.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.colGIOITINH.FieldName = "GIOITINH";
            this.colGIOITINH.MinWidth = 30;
            this.colGIOITINH.Name = "colGIOITINH";
            this.colGIOITINH.Visible = true;
            this.colGIOITINH.VisibleIndex = 3;
            this.colGIOITINH.Width = 112;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.DataSource = this.nHANVIENGIOITINHBindingSource;
            this.repositoryItemGridLookUpEdit1.DisplayMember = "TEXT";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemGridLookUpEdit1.ValueMember = "VALUE";
            // 
            // nHANVIENGIOITINHBindingSource
            // 
            this.nHANVIENGIOITINHBindingSource.DataMember = "NHANVIEN_GIOITINH";
            this.nHANVIENGIOITINHBindingSource.DataSource = this.qLTVDataSet;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "ĐỊA CHỈ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 30;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 4;
            this.colDIACHI.Width = 112;
            // 
            // colDIENTHOAI
            // 
            this.colDIENTHOAI.Caption = "ĐIỆN THOẠI";
            this.colDIENTHOAI.FieldName = "DIENTHOAI";
            this.colDIENTHOAI.MinWidth = 30;
            this.colDIENTHOAI.Name = "colDIENTHOAI";
            this.colDIENTHOAI.Visible = true;
            this.colDIENTHOAI.VisibleIndex = 5;
            this.colDIENTHOAI.Width = 112;
            // 
            // colEMAIL
            // 
            this.colEMAIL.Caption = "EMAIL";
            this.colEMAIL.FieldName = "EMAIL";
            this.colEMAIL.MinWidth = 30;
            this.colEMAIL.Name = "colEMAIL";
            this.colEMAIL.Visible = true;
            this.colEMAIL.VisibleIndex = 6;
            this.colEMAIL.Width = 112;
            // 
            // colTRANGTHAIXOA
            // 
            this.colTRANGTHAIXOA.Caption = "TRẠNG THÁI";
            this.colTRANGTHAIXOA.ColumnEdit = this.repositoryItemGridLookUpEdit2;
            this.colTRANGTHAIXOA.FieldName = "TRANGTHAIXOA";
            this.colTRANGTHAIXOA.MinWidth = 30;
            this.colTRANGTHAIXOA.Name = "colTRANGTHAIXOA";
            this.colTRANGTHAIXOA.Visible = true;
            this.colTRANGTHAIXOA.VisibleIndex = 7;
            this.colTRANGTHAIXOA.Width = 112;
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.AutoHeight = false;
            this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit2.DataSource = this.nHANVIENTRANGTHAIBindingSource;
            this.repositoryItemGridLookUpEdit2.DisplayMember = "TEXT";
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.PopupView = this.repositoryItemGridLookUpEdit2View;
            this.repositoryItemGridLookUpEdit2.ValueMember = "VALUE";
            // 
            // nHANVIENTRANGTHAIBindingSource
            // 
            this.nHANVIENTRANGTHAIBindingSource.DataMember = "NHANVIEN_TRANGTHAI";
            this.nHANVIENTRANGTHAIBindingSource.DataSource = this.qLTVDataSet;
            // 
            // repositoryItemGridLookUpEdit2View
            // 
            this.repositoryItemGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit2View.Name = "repositoryItemGridLookUpEdit2View";
            this.repositoryItemGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // gIOITINHBindingSource
            // 
            this.gIOITINHBindingSource.DataMember = "GIOITINH";
            this.gIOITINHBindingSource.DataSource = this.qLTVDataSet;
            // 
            // nHANVIENTableAdapter
            // 
            this.nHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHITIETNGANTUTableAdapter = null;
            this.tableAdapterManager.CT_PHIEUMUONTableAdapter = this.cT_PHIEUMUONTableAdapter;
            this.tableAdapterManager.DAUSACHTableAdapter = null;
            this.tableAdapterManager.DOCGIATableAdapter = null;
            this.tableAdapterManager.NGANTUTableAdapter = null;
            this.tableAdapterManager.NGONNGUTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = this.nHANVIENTableAdapter;
            this.tableAdapterManager.PHIEUMUONTableAdapter = this.pHIEUMUONTableAdapter;
            this.tableAdapterManager.SACHTableAdapter = null;
            this.tableAdapterManager.sp_DanhSachBackupTableAdapter = null;
            this.tableAdapterManager.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter = null;
            this.tableAdapterManager.sp_GetSachDangMuon_ByDocGiaTableAdapter = null;
            this.tableAdapterManager.TACGIA_SACHTableAdapter = null;
            this.tableAdapterManager.TACGIATableAdapter = null;
            this.tableAdapterManager.THELOAITableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cT_PHIEUMUONTableAdapter
            // 
            this.cT_PHIEUMUONTableAdapter.ClearBeforeFill = true;
            // 
            // pHIEUMUONTableAdapter
            // 
            this.pHIEUMUONTableAdapter.ClearBeforeFill = true;
            // 
            // gIOITINHTableAdapter
            // 
            this.gIOITINHTableAdapter.ClearBeforeFill = true;
            // 
            // pHIEUMUONBindingSource
            // 
            this.pHIEUMUONBindingSource.DataMember = "FK_PHIEUMUON_NHANVIEN";
            this.pHIEUMUONBindingSource.DataSource = this.nHANVIENBindingSource;
            // 
            // cT_PHIEUMUONBindingSource
            // 
            this.cT_PHIEUMUONBindingSource.DataMember = "FK_CTPHIEUMUON_NHANVIEN";
            this.cT_PHIEUMUONBindingSource.DataSource = this.nHANVIENBindingSource;
            // 
            // nHANVIEN_TRANGTHAITableAdapter
            // 
            this.nHANVIEN_TRANGTHAITableAdapter.ClearBeforeFill = true;
            // 
            // nHANVIEN_GIOITINHTableAdapter
            // 
            this.nHANVIEN_GIOITINHTableAdapter.ClearBeforeFill = true;
            // 
            // FormNhanVien2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1558, 555);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormNhanVien2";
            this.Text = "Quản lý nhân viên";
            this.Load += new System.EventHandler(this.FormNhanVien2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnINPUT)).EndInit();
            this.pnINPUT.ResumeLayout(false);
            this.pnINPUT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEMAIL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIENTHOAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDIACHI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNHANVIEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNHANVIEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENGIOITINHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENTRANGTHAIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIOITINHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUMUONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cT_PHIEUMUONBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barChucNang;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnRedo;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnDanhSach;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private System.Windows.Forms.BindingSource nHANVIENBindingSource;
        private QLTVDataSet qLTVDataSet;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl pnINPUT;
        private QLTVDataSetTableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter;
        private QLTVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcNHANVIEN;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNHANVIEN;
        private DevExpress.XtraEditors.TextEdit txtEMAIL;
        private DevExpress.XtraEditors.TextEdit txtDIENTHOAI;
        private DevExpress.XtraEditors.TextEdit txtTEN;
        private DevExpress.XtraEditors.TextEdit txtHO;
        private DevExpress.XtraEditors.SpinEdit txtMA;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colHONV;
        private DevExpress.XtraGrid.Columns.GridColumn colTENNV;
        private DevExpress.XtraGrid.Columns.GridColumn colGIOITINH;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colDIENTHOAI;
        private DevExpress.XtraGrid.Columns.GridColumn colEMAIL;
        private DevExpress.XtraGrid.Columns.GridColumn colTRANGTHAIXOA;
        private System.Windows.Forms.RadioButton rbNAM;
        private System.Windows.Forms.BindingSource gIOITINHBindingSource;
        private QLTVDataSetTableAdapters.GIOITINHTableAdapter gIOITINHTableAdapter;
        private DevExpress.XtraEditors.MemoEdit txtDIACHI;
        private System.Windows.Forms.RadioButton rbNU;
        private System.Windows.Forms.RadioButton rbNGHI;
        private QLTVDataSetTableAdapters.PHIEUMUONTableAdapter pHIEUMUONTableAdapter;
        private System.Windows.Forms.BindingSource pHIEUMUONBindingSource;
        private QLTVDataSetTableAdapters.CT_PHIEUMUONTableAdapter cT_PHIEUMUONTableAdapter;
        private System.Windows.Forms.BindingSource cT_PHIEUMUONBindingSource;
        private DevExpress.XtraEditors.LabelControl lblMA;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit2View;
        private System.Windows.Forms.BindingSource nHANVIENTRANGTHAIBindingSource;
        private QLTVDataSetTableAdapters.NHANVIEN_TRANGTHAITableAdapter nHANVIEN_TRANGTHAITableAdapter;
        private System.Windows.Forms.RadioButton rbHOATDONG;
        private System.Windows.Forms.BindingSource nHANVIENGIOITINHBindingSource;
        private QLTVDataSetTableAdapters.NHANVIEN_GIOITINHTableAdapter nHANVIEN_GIOITINHTableAdapter;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}