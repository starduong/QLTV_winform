namespace AppLibrary
{
    partial class FormTheLoai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTheLoai));
            System.Windows.Forms.Label lblMATL;
            System.Windows.Forms.Label lblTHELOAI;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barChucNang = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnRedo = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.btnIn = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhSach = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.pnINPUTTL = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.bdsTHELOAI = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterTHELOAI = new AppLibrary.QLTVDataSetTableAdapters.THELOAITableAdapter();
            this.tableAdapterManager = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.gcTHELOAI = new DevExpress.XtraGrid.GridControl();
            this.gvTHELOAI = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMATL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTHELOAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtMATL = new DevExpress.XtraEditors.TextEdit();
            this.txtTHELOAI = new DevExpress.XtraEditors.TextEdit();
            this.bdsDAUSACH_TL = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterDAUSACH = new AppLibrary.QLTVDataSetTableAdapters.DAUSACHTableAdapter();
            lblMATL = new System.Windows.Forms.Label();
            lblTHELOAI = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnINPUTTL)).BeginInit();
            this.pnINPUTTL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTHELOAI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTHELOAI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTHELOAI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMATL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHELOAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDAUSACH_TL)).BeginInit();
            this.SuspendLayout();
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
            this.btnIn,
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
            // btnIn
            // 
            this.btnIn.Caption = "In";
            this.btnIn.Id = 9;
            this.btnIn.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIn.ImageOptions.SvgImage")));
            this.btnIn.Name = "btnIn";
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
            this.barDockControlTop.Size = new System.Drawing.Size(1267, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 627);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1267, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 586);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1267, 41);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 586);
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
            // pnINPUTTL
            // 
            this.pnINPUTTL.Controls.Add(lblTHELOAI);
            this.pnINPUTTL.Controls.Add(this.txtTHELOAI);
            this.pnINPUTTL.Controls.Add(lblMATL);
            this.pnINPUTTL.Controls.Add(this.txtMATL);
            this.pnINPUTTL.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnINPUTTL.Location = new System.Drawing.Point(0, 41);
            this.pnINPUTTL.Name = "pnINPUTTL";
            this.pnINPUTTL.Size = new System.Drawing.Size(1267, 73);
            this.pnINPUTTL.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcTHELOAI);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 114);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1267, 513);
            this.panelControl2.TabIndex = 0;
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsTHELOAI
            // 
            this.bdsTHELOAI.DataMember = "THELOAI";
            this.bdsTHELOAI.DataSource = this.qLTVDataSet;
            // 
            // tableAdapterTHELOAI
            // 
            this.tableAdapterTHELOAI.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHITIETNGANTUTableAdapter = null;
            this.tableAdapterManager.CT_PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.DAUSACHTableAdapter = this.tableAdapterDAUSACH;
            this.tableAdapterManager.DOCGIATableAdapter = null;
            this.tableAdapterManager.NGANTUTableAdapter = null;
            this.tableAdapterManager.NGONNGUTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.SACHTableAdapter = null;
            this.tableAdapterManager.sp_DanhSachBackupTableAdapter = null;
            this.tableAdapterManager.TACGIA_SACHTableAdapter = null;
            this.tableAdapterManager.TACGIATableAdapter = null;
            this.tableAdapterManager.THELOAITableAdapter = this.tableAdapterTHELOAI;
            this.tableAdapterManager.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gcTHELOAI
            // 
            this.gcTHELOAI.DataSource = this.bdsTHELOAI;
            this.gcTHELOAI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTHELOAI.Location = new System.Drawing.Point(2, 2);
            this.gcTHELOAI.MainView = this.gvTHELOAI;
            this.gcTHELOAI.MenuManager = this.barManager1;
            this.gcTHELOAI.Name = "gcTHELOAI";
            this.gcTHELOAI.Size = new System.Drawing.Size(1263, 509);
            this.gcTHELOAI.TabIndex = 0;
            this.gcTHELOAI.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTHELOAI});
            // 
            // gvTHELOAI
            // 
            this.gvTHELOAI.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMATL,
            this.colTHELOAI});
            this.gvTHELOAI.GridControl = this.gcTHELOAI;
            this.gvTHELOAI.Name = "gvTHELOAI";
            this.gvTHELOAI.OptionsBehavior.Editable = false;
            this.gvTHELOAI.OptionsDetail.EnableMasterViewMode = false;
            // 
            // colMATL
            // 
            this.colMATL.Caption = "Mã thể loại";
            this.colMATL.FieldName = "MATL";
            this.colMATL.MinWidth = 30;
            this.colMATL.Name = "colMATL";
            this.colMATL.Visible = true;
            this.colMATL.VisibleIndex = 0;
            this.colMATL.Width = 336;
            // 
            // colTHELOAI
            // 
            this.colTHELOAI.Caption = "Thể loại";
            this.colTHELOAI.FieldName = "THELOAI";
            this.colTHELOAI.MinWidth = 30;
            this.colTHELOAI.Name = "colTHELOAI";
            this.colTHELOAI.Visible = true;
            this.colTHELOAI.VisibleIndex = 1;
            this.colTHELOAI.Width = 915;
            // 
            // lblMATL
            // 
            lblMATL.AutoSize = true;
            lblMATL.Location = new System.Drawing.Point(122, 28);
            lblMATL.Name = "lblMATL";
            lblMATL.Size = new System.Drawing.Size(111, 19);
            lblMATL.TabIndex = 0;
            lblMATL.Text = "MÃ THỂ LOẠI:";
            // 
            // txtMATL
            // 
            this.txtMATL.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsTHELOAI, "MATL", true));
            this.txtMATL.Location = new System.Drawing.Point(239, 20);
            this.txtMATL.MenuManager = this.barManager1;
            this.txtMATL.Name = "txtMATL";
            this.txtMATL.Size = new System.Drawing.Size(150, 27);
            this.txtMATL.TabIndex = 1;
            // 
            // lblTHELOAI
            // 
            lblTHELOAI.AutoSize = true;
            lblTHELOAI.Location = new System.Drawing.Point(458, 28);
            lblTHELOAI.Name = "lblTHELOAI";
            lblTHELOAI.Size = new System.Drawing.Size(82, 19);
            lblTHELOAI.TabIndex = 2;
            lblTHELOAI.Text = "THỂ LOẠI:";
            // 
            // txtTHELOAI
            // 
            this.txtTHELOAI.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsTHELOAI, "THELOAI", true));
            this.txtTHELOAI.Location = new System.Drawing.Point(546, 20);
            this.txtTHELOAI.MenuManager = this.barManager1;
            this.txtTHELOAI.Name = "txtTHELOAI";
            this.txtTHELOAI.Size = new System.Drawing.Size(371, 27);
            this.txtTHELOAI.TabIndex = 3;
            // 
            // bdsDAUSACH_TL
            // 
            this.bdsDAUSACH_TL.DataMember = "FK_DAUSACH_THELOAI";
            this.bdsDAUSACH_TL.DataSource = this.bdsTHELOAI;
            // 
            // tableAdapterDAUSACH
            // 
            this.tableAdapterDAUSACH.ClearBeforeFill = true;
            // 
            // FormTheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 651);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.pnINPUTTL);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormTheLoai";
            this.Text = "Danh sách thể loại";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTHELOAI_FormClosing);
            this.Load += new System.EventHandler(this.FormTheLoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnINPUTTL)).EndInit();
            this.pnINPUTTL.ResumeLayout(false);
            this.pnINPUTTL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTHELOAI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTHELOAI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTHELOAI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMATL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTHELOAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDAUSACH_TL)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnIn;
        private DevExpress.XtraEditors.PanelControl pnINPUTTL;
        private System.Windows.Forms.BindingSource bdsTHELOAI;
        private QLTVDataSet qLTVDataSet;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private QLTVDataSetTableAdapters.THELOAITableAdapter tableAdapterTHELOAI;
        private QLTVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcTHELOAI;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTHELOAI;
        private DevExpress.XtraGrid.Columns.GridColumn colMATL;
        private DevExpress.XtraGrid.Columns.GridColumn colTHELOAI;
        private DevExpress.XtraEditors.TextEdit txtTHELOAI;
        private DevExpress.XtraEditors.TextEdit txtMATL;
        private QLTVDataSetTableAdapters.DAUSACHTableAdapter tableAdapterDAUSACH;
        private System.Windows.Forms.BindingSource bdsDAUSACH_TL;
    }
}