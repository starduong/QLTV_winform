namespace AppLibrary
{
    partial class FormDocGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDocGia));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhSach = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ds_QLTV = new AppLibrary.QLTVDataSet();
            this.bds_DocGia = new System.Windows.Forms.BindingSource(this.components);
            this.ta_DocGia = new AppLibrary.QLTVDataSetTableAdapters.DOCGIATableAdapter();
            this.tam_DocGia = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.dOCGIAGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMADG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHODG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMAILDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOCMND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIOITINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYSINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIENTHOAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYLAMTHE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYHETHAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOATDONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_QLTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_DocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCGIAGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
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
            this.btnPhucHoi,
            this.btnRefresh,
            this.btnDanhSach,
            this.btnThoat,
            this.barButtonItem9});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSua, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPhucHoi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDanhSach, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThem.ImageOptions.SvgImage")));
            this.btnThem.Name = "btnThem";
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 1;
            this.btnSua.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSua.ImageOptions.SvgImage")));
            this.btnSua.Name = "btnSua";
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGhi.ImageOptions.SvgImage")));
            this.btnGhi.Name = "btnGhi";
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 3;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.ImageOptions.SvgImageSize = new System.Drawing.Size(17, 17);
            this.btnXoa.Name = "btnXoa";
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Caption = "Phục hồi";
            this.btnPhucHoi.Id = 4;
            this.btnPhucHoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhucHoi.ImageOptions.SvgImage")));
            this.btnPhucHoi.Name = "btnPhucHoi";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnDanhSach
            // 
            this.btnDanhSach.Caption = "Danh sách đầu sách";
            this.btnDanhSach.Id = 6;
            this.btnDanhSach.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDanhSach.ImageOptions.SvgImage")));
            this.btnDanhSach.Name = "btnDanhSach";
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 7;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
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
            this.barDockControlTop.Size = new System.Drawing.Size(1357, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 648);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1357, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 607);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1357, 41);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 607);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "barButtonItem9";
            this.barButtonItem9.Id = 8;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 41);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(17, 18, 17, 18);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1357, 60);
            this.panelControl1.TabIndex = 4;
            // 
            // ds_QLTV
            // 
            this.ds_QLTV.DataSetName = "QLTVDataSet";
            this.ds_QLTV.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bds_DocGia
            // 
            this.bds_DocGia.DataMember = "DOCGIA";
            this.bds_DocGia.DataSource = this.ds_QLTV;
            // 
            // ta_DocGia
            // 
            this.ta_DocGia.ClearBeforeFill = true;
            // 
            // tam_DocGia
            // 
            this.tam_DocGia.BackupDataSetBeforeUpdate = false;
            this.tam_DocGia.CT_PHIEUMUONTableAdapter = null;
            this.tam_DocGia.DAUSACHTableAdapter = null;
            this.tam_DocGia.DOCGIATableAdapter = this.ta_DocGia;
            this.tam_DocGia.NGANTUTableAdapter = null;
            this.tam_DocGia.NGONNGUTableAdapter = null;
            this.tam_DocGia.NHANVIENTableAdapter = null;
            this.tam_DocGia.PHIEUMUONTableAdapter = null;
            this.tam_DocGia.SACHTableAdapter = null;
            this.tam_DocGia.TACGIA_SACHTableAdapter = null;
            this.tam_DocGia.TACGIATableAdapter = null;
            this.tam_DocGia.THELOAITableAdapter = null;
            this.tam_DocGia.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dOCGIAGridControl
            // 
            this.dOCGIAGridControl.DataSource = this.bds_DocGia;
            this.dOCGIAGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.dOCGIAGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(17, 18, 17, 18);
            this.dOCGIAGridControl.Location = new System.Drawing.Point(0, 101);
            this.dOCGIAGridControl.MainView = this.gridView1;
            this.dOCGIAGridControl.Margin = new System.Windows.Forms.Padding(17, 18, 17, 18);
            this.dOCGIAGridControl.MenuManager = this.barManager1;
            this.dOCGIAGridControl.Name = "dOCGIAGridControl";
            this.dOCGIAGridControl.Size = new System.Drawing.Size(1357, 466);
            this.dOCGIAGridControl.TabIndex = 6;
            this.dOCGIAGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridView1.DetailHeight = 1529;
            this.gridView1.GridControl = this.dOCGIAGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 3314;
            // 
            // colMADG
            // 
            this.colMADG.Caption = "Mã độc giả";
            this.colMADG.FieldName = "MADG";
            this.colMADG.MinWidth = 37;
            this.colMADG.Name = "colMADG";
            this.colMADG.Visible = true;
            this.colMADG.VisibleIndex = 0;
            this.colMADG.Width = 137;
            // 
            // colHODG
            // 
            this.colHODG.Caption = "Họ";
            this.colHODG.FieldName = "HODG";
            this.colHODG.MinWidth = 37;
            this.colHODG.Name = "colHODG";
            this.colHODG.Visible = true;
            this.colHODG.VisibleIndex = 1;
            this.colHODG.Width = 137;
            // 
            // colTENDG
            // 
            this.colTENDG.Caption = "Tên";
            this.colTENDG.FieldName = "TENDG";
            this.colTENDG.MinWidth = 37;
            this.colTENDG.Name = "colTENDG";
            this.colTENDG.Visible = true;
            this.colTENDG.VisibleIndex = 2;
            this.colTENDG.Width = 137;
            // 
            // colEMAILDG
            // 
            this.colEMAILDG.Caption = "Email";
            this.colEMAILDG.FieldName = "EMAILDG";
            this.colEMAILDG.MinWidth = 37;
            this.colEMAILDG.Name = "colEMAILDG";
            this.colEMAILDG.Visible = true;
            this.colEMAILDG.VisibleIndex = 3;
            this.colEMAILDG.Width = 137;
            // 
            // colSOCMND
            // 
            this.colSOCMND.Caption = "Số CMND";
            this.colSOCMND.FieldName = "SOCMND";
            this.colSOCMND.MinWidth = 37;
            this.colSOCMND.Name = "colSOCMND";
            this.colSOCMND.Visible = true;
            this.colSOCMND.VisibleIndex = 4;
            this.colSOCMND.Width = 137;
            // 
            // colGIOITINH
            // 
            this.colGIOITINH.Caption = "Giới tính";
            this.colGIOITINH.FieldName = "GIOITINH";
            this.colGIOITINH.MinWidth = 37;
            this.colGIOITINH.Name = "colGIOITINH";
            this.colGIOITINH.Visible = true;
            this.colGIOITINH.VisibleIndex = 5;
            this.colGIOITINH.Width = 137;
            // 
            // colNGAYSINH
            // 
            this.colNGAYSINH.Caption = "Ngày sinh";
            this.colNGAYSINH.FieldName = "NGAYSINH";
            this.colNGAYSINH.MinWidth = 37;
            this.colNGAYSINH.Name = "colNGAYSINH";
            this.colNGAYSINH.Visible = true;
            this.colNGAYSINH.VisibleIndex = 6;
            this.colNGAYSINH.Width = 137;
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "Địa chỉ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 37;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 7;
            this.colDIACHI.Width = 137;
            // 
            // colDIENTHOAI
            // 
            this.colDIENTHOAI.Caption = "Điện thoại";
            this.colDIENTHOAI.FieldName = "DIENTHOAI";
            this.colDIENTHOAI.MinWidth = 37;
            this.colDIENTHOAI.Name = "colDIENTHOAI";
            this.colDIENTHOAI.Visible = true;
            this.colDIENTHOAI.VisibleIndex = 8;
            this.colDIENTHOAI.Width = 137;
            // 
            // colNGAYLAMTHE
            // 
            this.colNGAYLAMTHE.Caption = "Ngày làm thẻ";
            this.colNGAYLAMTHE.FieldName = "NGAYLAMTHE";
            this.colNGAYLAMTHE.MinWidth = 37;
            this.colNGAYLAMTHE.Name = "colNGAYLAMTHE";
            this.colNGAYLAMTHE.Visible = true;
            this.colNGAYLAMTHE.VisibleIndex = 9;
            this.colNGAYLAMTHE.Width = 137;
            // 
            // colNGAYHETHAN
            // 
            this.colNGAYHETHAN.Caption = "Ngày hết hạn";
            this.colNGAYHETHAN.FieldName = "NGAYHETHAN";
            this.colNGAYHETHAN.MinWidth = 37;
            this.colNGAYHETHAN.Name = "colNGAYHETHAN";
            this.colNGAYHETHAN.Visible = true;
            this.colNGAYHETHAN.VisibleIndex = 10;
            this.colNGAYHETHAN.Width = 137;
            // 
            // colHOATDONG
            // 
            this.colHOATDONG.Caption = "Hoạt động";
            this.colHOATDONG.FieldName = "HOATDONG";
            this.colHOATDONG.MinWidth = 37;
            this.colHOATDONG.Name = "colHOATDONG";
            this.colHOATDONG.Visible = true;
            this.colHOATDONG.VisibleIndex = 11;
            this.colHOATDONG.Width = 137;
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 567);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(17, 18, 17, 18);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1357, 81);
            this.panelControl2.TabIndex = 7;
            // 
            // FormDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 672);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.dOCGIAGridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormDocGia";
            this.Text = "Danh sách Độc giả";
            this.Load += new System.EventHandler(this.FormDocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_QLTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_DocGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOCGIAGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnDanhSach;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource bds_DocGia;
        private QLTVDataSet ds_QLTV;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private QLTVDataSetTableAdapters.DOCGIATableAdapter ta_DocGia;
        private QLTVDataSetTableAdapters.TableAdapterManager tam_DocGia;
        private DevExpress.XtraGrid.GridControl dOCGIAGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
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
    }
}