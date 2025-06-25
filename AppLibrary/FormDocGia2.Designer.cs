namespace AppLibrary
{
    partial class FormDocGia2
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
            System.Windows.Forms.Label hODGLabel;
            System.Windows.Forms.Label tENDGLabel;
            System.Windows.Forms.Label eMAILDGLabel;
            System.Windows.Forms.Label sOCMNDLabel;
            System.Windows.Forms.Label nGAYSINHLabel;
            System.Windows.Forms.Label dIACHILabel;
            System.Windows.Forms.Label dIENTHOAILabel;
            System.Windows.Forms.Label nGAYLAMTHELabel;
            System.Windows.Forms.Label nGAYHETHANLabel;
            System.Windows.Forms.Label hOATDONGLabel;
            System.Windows.Forms.Label gIOITINHLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDocGia2));
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnINPUT = new DevExpress.XtraEditors.PanelControl();
            this.lblMA = new DevExpress.XtraEditors.LabelControl();
            this.rbNU = new System.Windows.Forms.RadioButton();
            this.rbNAM = new System.Windows.Forms.RadioButton();
            this.dOCGIABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.nGAYHETHANDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.nGAYLAMTHEDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.dIENTHOAITextEdit = new DevExpress.XtraEditors.TextEdit();
            this.nGAYSINHDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.sOCMNDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.eMAILDGTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tENDGTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.hODGTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.mADGTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dIACHITextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.hOATDONGCheckEdit = new DevExpress.XtraEditors.ToggleSwitch();
            this.pnDOCGIA = new DevExpress.XtraEditors.PanelControl();
            this.gcDOCGIA = new DevExpress.XtraGrid.GridControl();
            this.gvDOCGIA = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMADG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHODG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMAILDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIOITINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gIOITINHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNGAYSINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIENTHOAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYLAMTHE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYHETHAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOATDONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.hOATDONGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dOCGIATableAdapter = new AppLibrary.QLTVDataSetTableAdapters.DOCGIATableAdapter();
            this.tableAdapterManager = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.gIOITINHTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.GIOITINHTableAdapter();
            this.hOATDONGTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.HOATDONGTableAdapter();
            this.pHIEUMUONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pHIEUMUONTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.PHIEUMUONTableAdapter();
            hODGLabel = new System.Windows.Forms.Label();
            tENDGLabel = new System.Windows.Forms.Label();
            eMAILDGLabel = new System.Windows.Forms.Label();
            sOCMNDLabel = new System.Windows.Forms.Label();
            nGAYSINHLabel = new System.Windows.Forms.Label();
            dIACHILabel = new System.Windows.Forms.Label();
            dIENTHOAILabel = new System.Windows.Forms.Label();
            nGAYLAMTHELabel = new System.Windows.Forms.Label();
            nGAYHETHANLabel = new System.Windows.Forms.Label();
            hOATDONGLabel = new System.Windows.Forms.Label();
            gIOITINHLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnINPUT)).BeginInit();
            this.pnINPUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dOCGIABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYHETHANDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYHETHANDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYLAMTHEDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYLAMTHEDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dIENTHOAITextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYSINHDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYSINHDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sOCMNDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMAILDGTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tENDGTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hODGTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mADGTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dIACHITextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOATDONGCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnDOCGIA)).BeginInit();
            this.pnDOCGIA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDOCGIA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDOCGIA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIOITINHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOATDONGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUMUONBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // hODGLabel
            // 
            hODGLabel.AutoSize = true;
            hODGLabel.Location = new System.Drawing.Point(77, 64);
            hODGLabel.Name = "hODGLabel";
            hODGLabel.Size = new System.Drawing.Size(35, 19);
            hODGLabel.TabIndex = 2;
            hODGLabel.Text = "HỌ:";
            // 
            // tENDGLabel
            // 
            tENDGLabel.AutoSize = true;
            tENDGLabel.Location = new System.Drawing.Point(70, 108);
            tENDGLabel.Name = "tENDGLabel";
            tENDGLabel.Size = new System.Drawing.Size(42, 19);
            tENDGLabel.TabIndex = 4;
            tENDGLabel.Text = "TÊN:";
            // 
            // eMAILDGLabel
            // 
            eMAILDGLabel.AutoSize = true;
            eMAILDGLabel.Location = new System.Drawing.Point(52, 158);
            eMAILDGLabel.Name = "eMAILDGLabel";
            eMAILDGLabel.Size = new System.Drawing.Size(60, 19);
            eMAILDGLabel.TabIndex = 6;
            eMAILDGLabel.Text = "EMAIL:";
            // 
            // sOCMNDLabel
            // 
            sOCMNDLabel.AutoSize = true;
            sOCMNDLabel.Location = new System.Drawing.Point(27, 208);
            sOCMNDLabel.Name = "sOCMNDLabel";
            sOCMNDLabel.Size = new System.Drawing.Size(85, 19);
            sOCMNDLabel.TabIndex = 8;
            sOCMNDLabel.Text = "SỐ CMND:";
            // 
            // nGAYSINHLabel
            // 
            nGAYSINHLabel.AutoSize = true;
            nGAYSINHLabel.Location = new System.Drawing.Point(529, 64);
            nGAYSINHLabel.Name = "nGAYSINHLabel";
            nGAYSINHLabel.Size = new System.Drawing.Size(97, 19);
            nGAYSINHLabel.TabIndex = 12;
            nGAYSINHLabel.Text = "NGÀY SINH:";
            // 
            // dIACHILabel
            // 
            dIACHILabel.AutoSize = true;
            dIACHILabel.Location = new System.Drawing.Point(557, 153);
            dIACHILabel.Name = "dIACHILabel";
            dIACHILabel.Size = new System.Drawing.Size(69, 19);
            dIACHILabel.TabIndex = 14;
            dIACHILabel.Text = "ĐỊA CHỈ:";
            // 
            // dIENTHOAILabel
            // 
            dIENTHOAILabel.AutoSize = true;
            dIENTHOAILabel.Location = new System.Drawing.Point(525, 108);
            dIENTHOAILabel.Name = "dIENTHOAILabel";
            dIENTHOAILabel.Size = new System.Drawing.Size(101, 19);
            dIENTHOAILabel.TabIndex = 16;
            dIENTHOAILabel.Text = "ĐIỆN THOẠI:";
            // 
            // nGAYLAMTHELabel
            // 
            nGAYLAMTHELabel.AutoSize = true;
            nGAYLAMTHELabel.Location = new System.Drawing.Point(1061, 64);
            nGAYLAMTHELabel.Name = "nGAYLAMTHELabel";
            nGAYLAMTHELabel.Size = new System.Drawing.Size(127, 19);
            nGAYLAMTHELabel.TabIndex = 18;
            nGAYLAMTHELabel.Text = "NGÀY LÀM THẺ:";
            // 
            // nGAYHETHANLabel
            // 
            nGAYHETHANLabel.AutoSize = true;
            nGAYHETHANLabel.Location = new System.Drawing.Point(1061, 108);
            nGAYHETHANLabel.Name = "nGAYHETHANLabel";
            nGAYHETHANLabel.Size = new System.Drawing.Size(127, 19);
            nGAYHETHANLabel.TabIndex = 20;
            nGAYHETHANLabel.Text = "NGÀY HẾT HẠN:";
            // 
            // hOATDONGLabel
            // 
            hOATDONGLabel.AutoSize = true;
            hOATDONGLabel.Location = new System.Drawing.Point(1083, 161);
            hOATDONGLabel.Name = "hOATDONGLabel";
            hOATDONGLabel.Size = new System.Drawing.Size(105, 19);
            hOATDONGLabel.TabIndex = 22;
            hOATDONGLabel.Text = "HOẠT ĐỘNG:";
            // 
            // gIOITINHLabel1
            // 
            gIOITINHLabel1.AutoSize = true;
            gIOITINHLabel1.Location = new System.Drawing.Point(540, 24);
            gIOITINHLabel1.Name = "gIOITINHLabel1";
            gIOITINHLabel1.Size = new System.Drawing.Size(86, 19);
            gIOITINHLabel1.TabIndex = 24;
            gIOITINHLabel1.Text = "GIỚI TÍNH:";
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
            this.barDockControlTop.Size = new System.Drawing.Size(1468, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 538);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1468, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 497);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1468, 41);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 497);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pnINPUT);
            this.panelControl1.Controls.Add(this.pnDOCGIA);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 41);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1468, 497);
            this.panelControl1.TabIndex = 4;
            // 
            // pnINPUT
            // 
            this.pnINPUT.Controls.Add(this.lblMA);
            this.pnINPUT.Controls.Add(this.rbNU);
            this.pnINPUT.Controls.Add(gIOITINHLabel1);
            this.pnINPUT.Controls.Add(this.rbNAM);
            this.pnINPUT.Controls.Add(hOATDONGLabel);
            this.pnINPUT.Controls.Add(nGAYHETHANLabel);
            this.pnINPUT.Controls.Add(this.nGAYHETHANDateEdit);
            this.pnINPUT.Controls.Add(nGAYLAMTHELabel);
            this.pnINPUT.Controls.Add(this.nGAYLAMTHEDateEdit);
            this.pnINPUT.Controls.Add(dIENTHOAILabel);
            this.pnINPUT.Controls.Add(this.dIENTHOAITextEdit);
            this.pnINPUT.Controls.Add(dIACHILabel);
            this.pnINPUT.Controls.Add(nGAYSINHLabel);
            this.pnINPUT.Controls.Add(this.nGAYSINHDateEdit);
            this.pnINPUT.Controls.Add(sOCMNDLabel);
            this.pnINPUT.Controls.Add(this.sOCMNDTextEdit);
            this.pnINPUT.Controls.Add(eMAILDGLabel);
            this.pnINPUT.Controls.Add(this.eMAILDGTextEdit);
            this.pnINPUT.Controls.Add(tENDGLabel);
            this.pnINPUT.Controls.Add(this.tENDGTextEdit);
            this.pnINPUT.Controls.Add(hODGLabel);
            this.pnINPUT.Controls.Add(this.hODGTextEdit);
            this.pnINPUT.Controls.Add(this.mADGTextEdit);
            this.pnINPUT.Controls.Add(this.dIACHITextEdit);
            this.pnINPUT.Controls.Add(this.hOATDONGCheckEdit);
            this.pnINPUT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnINPUT.Location = new System.Drawing.Point(2, 247);
            this.pnINPUT.Name = "pnINPUT";
            this.pnINPUT.Size = new System.Drawing.Size(1464, 248);
            this.pnINPUT.TabIndex = 1;
            // 
            // lblMA
            // 
            this.lblMA.Location = new System.Drawing.Point(74, 21);
            this.lblMA.Name = "lblMA";
            this.lblMA.Size = new System.Drawing.Size(28, 19);
            this.lblMA.TabIndex = 28;
            this.lblMA.Text = "MÃ:";
            // 
            // rbNU
            // 
            this.rbNU.AutoSize = true;
            this.rbNU.Location = new System.Drawing.Point(750, 20);
            this.rbNU.Name = "rbNU";
            this.rbNU.Size = new System.Drawing.Size(58, 23);
            this.rbNU.TabIndex = 26;
            this.rbNU.TabStop = true;
            this.rbNU.Text = "NỮ";
            this.rbNU.UseVisualStyleBackColor = true;
            this.rbNU.CheckedChanged += new System.EventHandler(this.rbNU_CheckedChanged);
            // 
            // rbNAM
            // 
            this.rbNAM.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.dOCGIABindingSource, "GIOITINH", true));
            this.rbNAM.Location = new System.Drawing.Point(640, 21);
            this.rbNAM.Name = "rbNAM";
            this.rbNAM.Size = new System.Drawing.Size(104, 24);
            this.rbNAM.TabIndex = 25;
            this.rbNAM.TabStop = true;
            this.rbNAM.Text = "NAM";
            this.rbNAM.UseVisualStyleBackColor = true;
            this.rbNAM.CheckedChanged += new System.EventHandler(this.rbNAM_CheckedChanged);
            // 
            // dOCGIABindingSource
            // 
            this.dOCGIABindingSource.DataMember = "DOCGIA";
            this.dOCGIABindingSource.DataSource = this.qLTVDataSet;
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nGAYHETHANDateEdit
            // 
            this.nGAYHETHANDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "NGAYHETHAN", true));
            this.nGAYHETHANDateEdit.EditValue = null;
            this.nGAYHETHANDateEdit.Location = new System.Drawing.Point(1195, 105);
            this.nGAYHETHANDateEdit.MenuManager = this.barManager1;
            this.nGAYHETHANDateEdit.Name = "nGAYHETHANDateEdit";
            this.nGAYHETHANDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nGAYHETHANDateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.nGAYHETHANDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nGAYHETHANDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.nGAYHETHANDateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.nGAYHETHANDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.nGAYHETHANDateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.nGAYHETHANDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.nGAYHETHANDateEdit.Properties.MaskSettings.Set("mask", "dd/MM/yyyy HH:mm");
            this.nGAYHETHANDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.nGAYHETHANDateEdit.Size = new System.Drawing.Size(219, 27);
            this.nGAYHETHANDateEdit.TabIndex = 21;
            // 
            // nGAYLAMTHEDateEdit
            // 
            this.nGAYLAMTHEDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "NGAYLAMTHE", true));
            this.nGAYLAMTHEDateEdit.EditValue = null;
            this.nGAYLAMTHEDateEdit.Location = new System.Drawing.Point(1194, 61);
            this.nGAYLAMTHEDateEdit.MenuManager = this.barManager1;
            this.nGAYLAMTHEDateEdit.Name = "nGAYLAMTHEDateEdit";
            this.nGAYLAMTHEDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nGAYLAMTHEDateEdit.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.nGAYLAMTHEDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nGAYLAMTHEDateEdit.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.nGAYLAMTHEDateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.nGAYLAMTHEDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.nGAYLAMTHEDateEdit.Properties.MaskSettings.Set("mask", "dd/MM/yyyy HH:mm");
            this.nGAYLAMTHEDateEdit.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.nGAYLAMTHEDateEdit.Size = new System.Drawing.Size(219, 27);
            this.nGAYLAMTHEDateEdit.TabIndex = 19;
            // 
            // dIENTHOAITextEdit
            // 
            this.dIENTHOAITextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "DIENTHOAI", true));
            this.dIENTHOAITextEdit.Location = new System.Drawing.Point(640, 105);
            this.dIENTHOAITextEdit.MenuManager = this.barManager1;
            this.dIENTHOAITextEdit.Name = "dIENTHOAITextEdit";
            this.dIENTHOAITextEdit.Size = new System.Drawing.Size(368, 27);
            this.dIENTHOAITextEdit.TabIndex = 17;
            // 
            // nGAYSINHDateEdit
            // 
            this.nGAYSINHDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "NGAYSINH", true));
            this.nGAYSINHDateEdit.EditValue = null;
            this.nGAYSINHDateEdit.Location = new System.Drawing.Point(640, 61);
            this.nGAYSINHDateEdit.MenuManager = this.barManager1;
            this.nGAYSINHDateEdit.Name = "nGAYSINHDateEdit";
            this.nGAYSINHDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nGAYSINHDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nGAYSINHDateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.nGAYSINHDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.nGAYSINHDateEdit.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.nGAYSINHDateEdit.Size = new System.Drawing.Size(368, 27);
            this.nGAYSINHDateEdit.TabIndex = 13;
            // 
            // sOCMNDTextEdit
            // 
            this.sOCMNDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "SOCMND", true));
            this.sOCMNDTextEdit.Location = new System.Drawing.Point(118, 205);
            this.sOCMNDTextEdit.MenuManager = this.barManager1;
            this.sOCMNDTextEdit.Name = "sOCMNDTextEdit";
            this.sOCMNDTextEdit.Size = new System.Drawing.Size(362, 27);
            this.sOCMNDTextEdit.TabIndex = 9;
            // 
            // eMAILDGTextEdit
            // 
            this.eMAILDGTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "EMAILDG", true));
            this.eMAILDGTextEdit.Location = new System.Drawing.Point(118, 155);
            this.eMAILDGTextEdit.MenuManager = this.barManager1;
            this.eMAILDGTextEdit.Name = "eMAILDGTextEdit";
            this.eMAILDGTextEdit.Size = new System.Drawing.Size(362, 27);
            this.eMAILDGTextEdit.TabIndex = 7;
            // 
            // tENDGTextEdit
            // 
            this.tENDGTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "TENDG", true));
            this.tENDGTextEdit.Location = new System.Drawing.Point(118, 105);
            this.tENDGTextEdit.MenuManager = this.barManager1;
            this.tENDGTextEdit.Name = "tENDGTextEdit";
            this.tENDGTextEdit.Size = new System.Drawing.Size(362, 27);
            this.tENDGTextEdit.TabIndex = 5;
            // 
            // hODGTextEdit
            // 
            this.hODGTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "HODG", true));
            this.hODGTextEdit.Location = new System.Drawing.Point(118, 61);
            this.hODGTextEdit.MenuManager = this.barManager1;
            this.hODGTextEdit.Name = "hODGTextEdit";
            this.hODGTextEdit.Size = new System.Drawing.Size(362, 27);
            this.hODGTextEdit.TabIndex = 3;
            // 
            // mADGTextEdit
            // 
            this.mADGTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "MADG", true));
            this.mADGTextEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.mADGTextEdit.Enabled = false;
            this.mADGTextEdit.Location = new System.Drawing.Point(118, 16);
            this.mADGTextEdit.MenuManager = this.barManager1;
            this.mADGTextEdit.Name = "mADGTextEdit";
            this.mADGTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.mADGTextEdit.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.mADGTextEdit.Size = new System.Drawing.Size(362, 27);
            this.mADGTextEdit.TabIndex = 1;
            // 
            // dIACHITextEdit
            // 
            this.dIACHITextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "DIACHI", true));
            this.dIACHITextEdit.Location = new System.Drawing.Point(640, 145);
            this.dIACHITextEdit.MenuManager = this.barManager1;
            this.dIACHITextEdit.Name = "dIACHITextEdit";
            this.dIACHITextEdit.Size = new System.Drawing.Size(368, 82);
            this.dIACHITextEdit.TabIndex = 15;
            // 
            // hOATDONGCheckEdit
            // 
            this.hOATDONGCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOCGIABindingSource, "HOATDONG", true));
            this.hOATDONGCheckEdit.Location = new System.Drawing.Point(1194, 158);
            this.hOATDONGCheckEdit.MenuManager = this.barManager1;
            this.hOATDONGCheckEdit.Name = "hOATDONGCheckEdit";
            this.hOATDONGCheckEdit.Properties.OffText = "Đã khóa";
            this.hOATDONGCheckEdit.Properties.OnText = "Đang hoạt động";
            this.hOATDONGCheckEdit.Size = new System.Drawing.Size(219, 31);
            this.hOATDONGCheckEdit.TabIndex = 23;
            // 
            // pnDOCGIA
            // 
            this.pnDOCGIA.Controls.Add(this.gcDOCGIA);
            this.pnDOCGIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDOCGIA.Location = new System.Drawing.Point(2, 2);
            this.pnDOCGIA.Name = "pnDOCGIA";
            this.pnDOCGIA.Size = new System.Drawing.Size(1464, 493);
            this.pnDOCGIA.TabIndex = 0;
            // 
            // gcDOCGIA
            // 
            this.gcDOCGIA.DataSource = this.dOCGIABindingSource;
            this.gcDOCGIA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDOCGIA.Location = new System.Drawing.Point(2, 2);
            this.gcDOCGIA.MainView = this.gvDOCGIA;
            this.gcDOCGIA.MenuManager = this.barManager1;
            this.gcDOCGIA.Name = "gcDOCGIA";
            this.gcDOCGIA.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemGridLookUpEdit2});
            this.gcDOCGIA.Size = new System.Drawing.Size(1460, 489);
            this.gcDOCGIA.TabIndex = 0;
            this.gcDOCGIA.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDOCGIA});
            // 
            // gvDOCGIA
            // 
            this.gvDOCGIA.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMADG,
            this.colHODG,
            this.colTENDG,
            this.colEMAILDG,
            this.colSOCMND,
            this.colGIOITINH,
            this.colNGAYSINH,
            this.colDIACHI,
            this.colDIENTHOAI,
            this.colNGAYLAMTHE,
            this.colNGAYHETHAN,
            this.colHOATDONG});
            this.gvDOCGIA.GridControl = this.gcDOCGIA;
            this.gvDOCGIA.Name = "gvDOCGIA";
            this.gvDOCGIA.OptionsBehavior.Editable = false;
            this.gvDOCGIA.OptionsDetail.EnableMasterViewMode = false;
            // 
            // colMADG
            // 
            this.colMADG.Caption = "MÃ";
            this.colMADG.FieldName = "MADG";
            this.colMADG.MinWidth = 30;
            this.colMADG.Name = "colMADG";
            this.colMADG.Visible = true;
            this.colMADG.VisibleIndex = 0;
            this.colMADG.Width = 60;
            // 
            // colHODG
            // 
            this.colHODG.Caption = "HỌ";
            this.colHODG.FieldName = "HODG";
            this.colHODG.MinWidth = 30;
            this.colHODG.Name = "colHODG";
            this.colHODG.Visible = true;
            this.colHODG.VisibleIndex = 1;
            this.colHODG.Width = 109;
            // 
            // colTENDG
            // 
            this.colTENDG.Caption = "TÊN";
            this.colTENDG.FieldName = "TENDG";
            this.colTENDG.MinWidth = 30;
            this.colTENDG.Name = "colTENDG";
            this.colTENDG.Visible = true;
            this.colTENDG.VisibleIndex = 2;
            this.colTENDG.Width = 60;
            // 
            // colEMAILDG
            // 
            this.colEMAILDG.Caption = "EMAIL";
            this.colEMAILDG.FieldName = "EMAILDG";
            this.colEMAILDG.MinWidth = 30;
            this.colEMAILDG.Name = "colEMAILDG";
            this.colEMAILDG.Visible = true;
            this.colEMAILDG.VisibleIndex = 3;
            this.colEMAILDG.Width = 138;
            // 
            // colSOCMND
            // 
            this.colSOCMND.Caption = "SỐ CMND";
            this.colSOCMND.FieldName = "SOCMND";
            this.colSOCMND.MinWidth = 30;
            this.colSOCMND.Name = "colSOCMND";
            this.colSOCMND.Visible = true;
            this.colSOCMND.VisibleIndex = 4;
            this.colSOCMND.Width = 109;
            // 
            // colGIOITINH
            // 
            this.colGIOITINH.Caption = "GIỚI TÍNH";
            this.colGIOITINH.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.colGIOITINH.FieldName = "GIOITINH";
            this.colGIOITINH.MinWidth = 30;
            this.colGIOITINH.Name = "colGIOITINH";
            this.colGIOITINH.Visible = true;
            this.colGIOITINH.VisibleIndex = 5;
            this.colGIOITINH.Width = 73;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.DataSource = this.gIOITINHBindingSource;
            this.repositoryItemGridLookUpEdit1.DisplayMember = "TEXT";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemGridLookUpEdit1.ValueMember = "VALUE";
            // 
            // gIOITINHBindingSource
            // 
            this.gIOITINHBindingSource.DataMember = "GIOITINH";
            this.gIOITINHBindingSource.DataSource = this.qLTVDataSet;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colNGAYSINH
            // 
            this.colNGAYSINH.Caption = "NGÀY SINH";
            this.colNGAYSINH.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNGAYSINH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAYSINH.FieldName = "NGAYSINH";
            this.colNGAYSINH.MinWidth = 30;
            this.colNGAYSINH.Name = "colNGAYSINH";
            this.colNGAYSINH.Visible = true;
            this.colNGAYSINH.VisibleIndex = 6;
            this.colNGAYSINH.Width = 115;
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "ĐỊA CHỈ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 30;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 7;
            this.colDIACHI.Width = 150;
            // 
            // colDIENTHOAI
            // 
            this.colDIENTHOAI.Caption = "ĐIỆN THOẠI";
            this.colDIENTHOAI.FieldName = "DIENTHOAI";
            this.colDIENTHOAI.MinWidth = 30;
            this.colDIENTHOAI.Name = "colDIENTHOAI";
            this.colDIENTHOAI.Visible = true;
            this.colDIENTHOAI.VisibleIndex = 8;
            this.colDIENTHOAI.Width = 107;
            // 
            // colNGAYLAMTHE
            // 
            this.colNGAYLAMTHE.Caption = "NGÀY LÀM THẺ";
            this.colNGAYLAMTHE.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colNGAYLAMTHE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAYLAMTHE.FieldName = "NGAYLAMTHE";
            this.colNGAYLAMTHE.MinWidth = 30;
            this.colNGAYLAMTHE.Name = "colNGAYLAMTHE";
            this.colNGAYLAMTHE.Visible = true;
            this.colNGAYLAMTHE.VisibleIndex = 9;
            this.colNGAYLAMTHE.Width = 107;
            // 
            // colNGAYHETHAN
            // 
            this.colNGAYHETHAN.Caption = "NGÀY HẾT HẠN";
            this.colNGAYHETHAN.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.colNGAYHETHAN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAYHETHAN.FieldName = "NGAYHETHAN";
            this.colNGAYHETHAN.MinWidth = 30;
            this.colNGAYHETHAN.Name = "colNGAYHETHAN";
            this.colNGAYHETHAN.Visible = true;
            this.colNGAYHETHAN.VisibleIndex = 10;
            this.colNGAYHETHAN.Width = 107;
            // 
            // colHOATDONG
            // 
            this.colHOATDONG.Caption = "HOẠT ĐỘNG";
            this.colHOATDONG.ColumnEdit = this.repositoryItemGridLookUpEdit2;
            this.colHOATDONG.FieldName = "HOATDONG";
            this.colHOATDONG.MinWidth = 30;
            this.colHOATDONG.Name = "colHOATDONG";
            this.colHOATDONG.Visible = true;
            this.colHOATDONG.VisibleIndex = 11;
            this.colHOATDONG.Width = 126;
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.AutoHeight = false;
            this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit2.DataSource = this.hOATDONGBindingSource;
            this.repositoryItemGridLookUpEdit2.DisplayMember = "TEXT";
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.PopupView = this.repositoryItemGridLookUpEdit2View;
            this.repositoryItemGridLookUpEdit2.ValueMember = "VALUE";
            // 
            // hOATDONGBindingSource
            // 
            this.hOATDONGBindingSource.DataMember = "HOATDONG";
            this.hOATDONGBindingSource.DataSource = this.qLTVDataSet;
            // 
            // repositoryItemGridLookUpEdit2View
            // 
            this.repositoryItemGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit2View.Name = "repositoryItemGridLookUpEdit2View";
            this.repositoryItemGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // dOCGIATableAdapter
            // 
            this.dOCGIATableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHITIETNGANTUTableAdapter = null;
            this.tableAdapterManager.CT_PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.DAUSACHTableAdapter = null;
            this.tableAdapterManager.DOCGIATableAdapter = this.dOCGIATableAdapter;
            this.tableAdapterManager.NGANTUTableAdapter = null;
            this.tableAdapterManager.NGONNGUTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.SACHTableAdapter = null;
            this.tableAdapterManager.sp_DanhSachBackupTableAdapter = null;
            this.tableAdapterManager.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter = null;
            this.tableAdapterManager.sp_GetSachDangMuon_ByDocGiaTableAdapter = null;
            this.tableAdapterManager.TACGIA_SACHTableAdapter = null;
            this.tableAdapterManager.TACGIATableAdapter = null;
            this.tableAdapterManager.THELOAITableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gIOITINHTableAdapter
            // 
            this.gIOITINHTableAdapter.ClearBeforeFill = true;
            // 
            // hOATDONGTableAdapter
            // 
            this.hOATDONGTableAdapter.ClearBeforeFill = true;
            // 
            // pHIEUMUONBindingSource
            // 
            this.pHIEUMUONBindingSource.DataMember = "FK_PHIEUMUON_DOCGIA";
            this.pHIEUMUONBindingSource.DataSource = this.dOCGIABindingSource;
            // 
            // pHIEUMUONTableAdapter
            // 
            this.pHIEUMUONTableAdapter.ClearBeforeFill = true;
            // 
            // FormDocGia2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1468, 562);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormDocGia2";
            this.Text = "Quản lý độc giả";
            this.Load += new System.EventHandler(this.FormDocGia2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnINPUT)).EndInit();
            this.pnINPUT.ResumeLayout(false);
            this.pnINPUT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dOCGIABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYHETHANDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYHETHANDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYLAMTHEDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYLAMTHEDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dIENTHOAITextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYSINHDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYSINHDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sOCMNDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eMAILDGTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tENDGTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hODGTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mADGTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dIACHITextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOATDONGCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnDOCGIA)).EndInit();
            this.pnDOCGIA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDOCGIA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDOCGIA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIOITINHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOATDONGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUMUONBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource dOCGIABindingSource;
        private QLTVDataSet qLTVDataSet;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl pnINPUT;
        private DevExpress.XtraEditors.PanelControl pnDOCGIA;
        private QLTVDataSetTableAdapters.DOCGIATableAdapter dOCGIATableAdapter;
        private QLTVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.DateEdit nGAYHETHANDateEdit;
        private DevExpress.XtraEditors.DateEdit nGAYLAMTHEDateEdit;
        private DevExpress.XtraEditors.TextEdit dIENTHOAITextEdit;
        private DevExpress.XtraEditors.DateEdit nGAYSINHDateEdit;
        private DevExpress.XtraEditors.TextEdit sOCMNDTextEdit;
        private DevExpress.XtraEditors.TextEdit eMAILDGTextEdit;
        private DevExpress.XtraEditors.TextEdit tENDGTextEdit;
        private DevExpress.XtraEditors.TextEdit hODGTextEdit;
        private DevExpress.XtraGrid.GridControl gcDOCGIA;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDOCGIA;
        private DevExpress.XtraEditors.TextEdit mADGTextEdit;
        private System.Windows.Forms.RadioButton rbNAM;
        private DevExpress.XtraEditors.MemoEdit dIACHITextEdit;
        private DevExpress.XtraEditors.ToggleSwitch hOATDONGCheckEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colMADG;
        private DevExpress.XtraGrid.Columns.GridColumn colHODG;
        private DevExpress.XtraGrid.Columns.GridColumn colTENDG;
        private DevExpress.XtraGrid.Columns.GridColumn colEMAILDG;
        private DevExpress.XtraGrid.Columns.GridColumn colSOCMND;
        private DevExpress.XtraGrid.Columns.GridColumn colGIOITINH;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYSINH;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colDIENTHOAI;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYLAMTHE;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYHETHAN;
        private DevExpress.XtraGrid.Columns.GridColumn colHOATDONG;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private System.Windows.Forms.BindingSource gIOITINHBindingSource;
        private QLTVDataSetTableAdapters.GIOITINHTableAdapter gIOITINHTableAdapter;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit2View;
        private System.Windows.Forms.BindingSource hOATDONGBindingSource;
        private QLTVDataSetTableAdapters.HOATDONGTableAdapter hOATDONGTableAdapter;
        private System.Windows.Forms.BindingSource pHIEUMUONBindingSource;
        private QLTVDataSetTableAdapters.PHIEUMUONTableAdapter pHIEUMUONTableAdapter;
        private System.Windows.Forms.RadioButton rbNU;
        private DevExpress.XtraEditors.LabelControl lblMA;
    }
}