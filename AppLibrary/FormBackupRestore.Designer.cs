namespace AppLibrary
{
    partial class FormBackupRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBackupRestore));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnSaoLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.ckbThoiGian = new DevExpress.XtraBars.BarCheckItem();
            this.btnTaoDevice = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.gcDB = new DevExpress.XtraEditors.GroupControl();
            this.dATABASESGridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsDB = new System.Windows.Forms.BindingSource(this.components);
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.gvDB = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.defaultToolTipController1 = new DevExpress.Utils.DefaultToolTipController(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.sp_DanhSachBackupGridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsDSBACKUP = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewDSBACKUP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colposition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colname1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbackup_start_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltype = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coluser_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldevice_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pcINPUTTG = new DevExpress.XtraEditors.PanelControl();
            this.lblThongBao = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeTGPHUCHOI = new DevExpress.XtraEditors.DateTimeOffsetEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fillToolStrip = new System.Windows.Forms.ToolStrip();
            this.dB_NAMEToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.dB_NAMEToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.gcBackup = new DevExpress.XtraEditors.GroupControl();
            this.bdsDSBACKUP_LOG = new System.Windows.Forms.BindingSource(this.components);
            this.dATABASESTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.DATABASESTableAdapter();
            this.tableAdapterManager = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.sp_DanhSachBackupTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.sp_DanhSachBackupTableAdapter();
            this.sp_DanhSachBackupLogTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.sp_DanhSachBackupLogTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDB)).BeginInit();
            this.gcDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dATABASESGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_DanhSachBackupGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSBACKUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSBACKUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcINPUTTG)).BeginInit();
            this.pcINPUTTG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeTGPHUCHOI.Properties)).BeginInit();
            this.fillToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBackup)).BeginInit();
            this.gcBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSBACKUP_LOG)).BeginInit();
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
            this.btnSaoLuu,
            this.btnPhucHoi,
            this.ckbThoiGian,
            this.btnTaoDevice,
            this.barButtonItem4,
            this.btnThoat});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSaoLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPhucHoi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.ckbThoiGian, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTaoDevice, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.Caption = "SAO LƯU";
            this.btnSaoLuu.Id = 0;
            this.btnSaoLuu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSaoLuu.ImageOptions.SvgImage")));
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaoLuu_ItemClick);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Caption = "PHỤC HỒI";
            this.btnPhucHoi.Id = 1;
            this.btnPhucHoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhucHoi.ImageOptions.SvgImage")));
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhucHoi_ItemClick);
            // 
            // ckbThoiGian
            // 
            this.ckbThoiGian.Caption = "THAM SỐ PHỤC HỒI THEO THỜI GIAN";
            this.ckbThoiGian.CheckBoxVisibility = DevExpress.XtraBars.CheckBoxVisibility.BeforeText;
            this.ckbThoiGian.Id = 3;
            this.ckbThoiGian.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ckbThoiGian.ImageOptions.SvgImage")));
            this.ckbThoiGian.Name = "ckbThoiGian";
            this.ckbThoiGian.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.ckbThoiGian_CheckedChanged);
            // 
            // btnTaoDevice
            // 
            this.btnTaoDevice.Caption = "TẠO DEVICE SAO LƯU";
            this.btnTaoDevice.Id = 4;
            this.btnTaoDevice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTaoDevice.ImageOptions.SvgImage")));
            this.btnTaoDevice.Name = "btnTaoDevice";
            this.btnTaoDevice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoDevice_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "THOÁT";
            this.btnThoat.Id = 6;
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
            this.barDockControlTop.Size = new System.Drawing.Size(1388, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 531);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1388, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 491);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1388, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 491);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "THOÁT";
            this.barButtonItem4.Id = 5;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // gcDB
            // 
            this.gcDB.Controls.Add(this.dATABASESGridControl);
            this.gcDB.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcDB.Location = new System.Drawing.Point(0, 40);
            this.gcDB.Name = "gcDB";
            this.gcDB.Size = new System.Drawing.Size(278, 491);
            this.gcDB.TabIndex = 4;
            this.gcDB.ToolTipController = this.defaultToolTipController1.DefaultController;
            // 
            // dATABASESGridControl
            // 
            this.dATABASESGridControl.DataSource = this.bdsDB;
            this.dATABASESGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dATABASESGridControl.Location = new System.Drawing.Point(2, 32);
            this.dATABASESGridControl.MainView = this.gvDB;
            this.dATABASESGridControl.MenuManager = this.barManager1;
            this.dATABASESGridControl.Name = "dATABASESGridControl";
            this.dATABASESGridControl.Size = new System.Drawing.Size(274, 457);
            this.dATABASESGridControl.TabIndex = 0;
            this.dATABASESGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDB});
            // 
            // bdsDB
            // 
            this.bdsDB.DataMember = "DATABASES";
            this.bdsDB.DataSource = this.qLTVDataSet;
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gvDB
            // 
            this.gvDB.Appearance.FocusedCell.BackColor = System.Drawing.Color.Gold;
            this.gvDB.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvDB.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colname});
            this.gvDB.GridControl = this.dATABASESGridControl;
            this.gvDB.Name = "gvDB";
            this.gvDB.OptionsBehavior.Editable = false;
            this.gvDB.OptionsDetail.EnableMasterViewMode = false;
            this.gvDB.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDB_FocusedRowChanged);
            // 
            // colname
            // 
            this.colname.Caption = "CƠ SỞ DỮ LIỆU";
            this.colname.FieldName = "name";
            this.colname.MinWidth = 30;
            this.colname.Name = "colname";
            this.colname.Visible = true;
            this.colname.VisibleIndex = 0;
            this.colname.Width = 112;
            // 
            // defaultToolTipController1
            // 
            // 
            // 
            // 
            this.defaultToolTipController1.DefaultController.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultToolTipController1.DefaultController.Appearance.Options.UseFont = true;
            // 
            // panelControl2
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.panelControl2, DevExpress.Utils.DefaultBoolean.Default);
            this.panelControl2.Controls.Add(this.sp_DanhSachBackupGridControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 77);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1106, 412);
            this.panelControl2.TabIndex = 2;
            // 
            // sp_DanhSachBackupGridControl
            // 
            this.sp_DanhSachBackupGridControl.DataSource = this.bdsDSBACKUP;
            this.sp_DanhSachBackupGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_DanhSachBackupGridControl.Location = new System.Drawing.Point(2, 2);
            this.sp_DanhSachBackupGridControl.MainView = this.gridViewDSBACKUP;
            this.sp_DanhSachBackupGridControl.MenuManager = this.barManager1;
            this.sp_DanhSachBackupGridControl.Name = "sp_DanhSachBackupGridControl";
            this.sp_DanhSachBackupGridControl.Size = new System.Drawing.Size(1102, 408);
            this.sp_DanhSachBackupGridControl.TabIndex = 0;
            this.sp_DanhSachBackupGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDSBACKUP});
            // 
            // bdsDSBACKUP
            // 
            this.bdsDSBACKUP.DataMember = "sp_DanhSachBackup";
            this.bdsDSBACKUP.DataSource = this.qLTVDataSet;
            // 
            // gridViewDSBACKUP
            // 
            this.gridViewDSBACKUP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colposition,
            this.colname1,
            this.coldescription,
            this.colbackup_start_date,
            this.coltype,
            this.coluser_name,
            this.coldevice_name});
            this.gridViewDSBACKUP.GridControl = this.sp_DanhSachBackupGridControl;
            this.gridViewDSBACKUP.Name = "gridViewDSBACKUP";
            this.gridViewDSBACKUP.OptionsBehavior.Editable = false;
            this.gridViewDSBACKUP.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDBBACKUP_FocusedRowChanged);
            this.gridViewDSBACKUP.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridViewDBBACKUP_CustomColumnDisplayText);
            this.gridViewDSBACKUP.DataSourceChanged += new System.EventHandler(this.gridViewDSBACKUP_DataSourceChanged);
            // 
            // colposition
            // 
            this.colposition.Caption = "Bản sao lưu thứ";
            this.colposition.FieldName = "position";
            this.colposition.MinWidth = 30;
            this.colposition.Name = "colposition";
            this.colposition.Visible = true;
            this.colposition.VisibleIndex = 0;
            this.colposition.Width = 113;
            // 
            // colname1
            // 
            this.colname1.Caption = "Tên ";
            this.colname1.FieldName = "name";
            this.colname1.MinWidth = 30;
            this.colname1.Name = "colname1";
            this.colname1.Visible = true;
            this.colname1.VisibleIndex = 1;
            this.colname1.Width = 192;
            // 
            // coldescription
            // 
            this.coldescription.Caption = "Mô tả";
            this.coldescription.FieldName = "description";
            this.coldescription.MinWidth = 30;
            this.coldescription.Name = "coldescription";
            this.coldescription.Visible = true;
            this.coldescription.VisibleIndex = 2;
            this.coldescription.Width = 184;
            // 
            // colbackup_start_date
            // 
            this.colbackup_start_date.Caption = "Ngày sao lưu";
            this.colbackup_start_date.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.colbackup_start_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colbackup_start_date.FieldName = "backup_start_date";
            this.colbackup_start_date.MinWidth = 30;
            this.colbackup_start_date.Name = "colbackup_start_date";
            this.colbackup_start_date.Visible = true;
            this.colbackup_start_date.VisibleIndex = 3;
            this.colbackup_start_date.Width = 177;
            // 
            // coltype
            // 
            this.coltype.Caption = "Loại sao lưu";
            this.coltype.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.coltype.FieldName = "type";
            this.coltype.MinWidth = 30;
            this.coltype.Name = "coltype";
            this.coltype.Visible = true;
            this.coltype.VisibleIndex = 4;
            this.coltype.Width = 244;
            // 
            // coluser_name
            // 
            this.coluser_name.Caption = "User sao lưu";
            this.coluser_name.FieldName = "user_name";
            this.coluser_name.MinWidth = 30;
            this.coluser_name.Name = "coluser_name";
            this.coluser_name.Visible = true;
            this.coluser_name.VisibleIndex = 5;
            this.coluser_name.Width = 111;
            // 
            // coldevice_name
            // 
            this.coldevice_name.Caption = "Tên Device";
            this.coldevice_name.FieldName = "device_name";
            this.coldevice_name.MinWidth = 30;
            this.coldevice_name.Name = "coldevice_name";
            this.coldevice_name.Visible = true;
            this.coldevice_name.VisibleIndex = 6;
            this.coldevice_name.Width = 144;
            // 
            // pcINPUTTG
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.pcINPUTTG, DevExpress.Utils.DefaultBoolean.Default);
            this.pcINPUTTG.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pcINPUTTG.Appearance.Options.UseBackColor = true;
            this.pcINPUTTG.Controls.Add(this.lblThongBao);
            this.pcINPUTTG.Controls.Add(this.dateTimeTGPHUCHOI);
            this.pcINPUTTG.Controls.Add(this.labelControl1);
            this.pcINPUTTG.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcINPUTTG.Location = new System.Drawing.Point(2, 32);
            this.pcINPUTTG.Name = "pcINPUTTG";
            this.pcINPUTTG.Size = new System.Drawing.Size(1106, 45);
            this.pcINPUTTG.TabIndex = 1;
            // 
            // lblThongBao
            // 
            this.lblThongBao.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblThongBao.ImageOptions.Image")));
            this.lblThongBao.Location = new System.Drawing.Point(735, 5);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(32, 32);
            this.lblThongBao.TabIndex = 3;
            this.lblThongBao.ToolTipController = this.defaultToolTipController1.DefaultController;
            this.lblThongBao.MouseHover += new System.EventHandler(this.lblThongBao_MouseHover);
            // 
            // dateTimeTGPHUCHOI
            // 
            this.dateTimeTGPHUCHOI.EditValue = null;
            this.dateTimeTGPHUCHOI.Location = new System.Drawing.Point(420, 5);
            this.dateTimeTGPHUCHOI.MenuManager = this.barManager1;
            this.dateTimeTGPHUCHOI.Name = "dateTimeTGPHUCHOI";
            this.dateTimeTGPHUCHOI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTimeTGPHUCHOI.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt";
            this.dateTimeTGPHUCHOI.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTimeTGPHUCHOI.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTimeTGPHUCHOI.Properties.MaskSettings.Set("mask", "dd/MM/yyyy hh:mm:ss tt");
            this.dateTimeTGPHUCHOI.Size = new System.Drawing.Size(309, 27);
            this.dateTimeTGPHUCHOI.TabIndex = 1;
            this.dateTimeTGPHUCHOI.ToolTipController = this.defaultToolTipController1.DefaultController;
            this.dateTimeTGPHUCHOI.EditValueChanged += new System.EventHandler(this.dateTimeTGPHUCHOI_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(104, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(310, 23);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Vui lòng nhập mốc thời gian phục hồi:";
            // 
            // fillToolStrip
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this.fillToolStrip, DevExpress.Utils.DefaultBoolean.Default);
            this.fillToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.fillToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dB_NAMEToolStripLabel,
            this.dB_NAMEToolStripTextBox,
            this.fillToolStripButton});
            this.fillToolStrip.Location = new System.Drawing.Point(278, 40);
            this.fillToolStrip.Name = "fillToolStrip";
            this.fillToolStrip.Size = new System.Drawing.Size(1110, 38);
            this.fillToolStrip.TabIndex = 10;
            this.fillToolStrip.Text = "fillToolStrip";
            // 
            // dB_NAMEToolStripLabel
            // 
            this.dB_NAMEToolStripLabel.Name = "dB_NAMEToolStripLabel";
            this.dB_NAMEToolStripLabel.Size = new System.Drawing.Size(137, 29);
            this.dB_NAMEToolStripLabel.Text = "TÊN DATABASE:";
            // 
            // dB_NAMEToolStripTextBox
            // 
            this.dB_NAMEToolStripTextBox.Enabled = false;
            this.dB_NAMEToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dB_NAMEToolStripTextBox.Name = "dB_NAMEToolStripTextBox";
            this.dB_NAMEToolStripTextBox.Size = new System.Drawing.Size(300, 34);
            // 
            // fillToolStripButton
            // 
            this.fillToolStripButton.BackColor = System.Drawing.Color.Gold;
            this.fillToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillToolStripButton.Name = "fillToolStripButton";
            this.fillToolStripButton.Size = new System.Drawing.Size(88, 29);
            this.fillToolStripButton.Text = "REFRESH";
            this.fillToolStripButton.Click += new System.EventHandler(this.fillToolStripButton_Click);
            // 
            // gcBackup
            // 
            this.gcBackup.Controls.Add(this.panelControl2);
            this.gcBackup.Controls.Add(this.pcINPUTTG);
            this.gcBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcBackup.Location = new System.Drawing.Point(278, 40);
            this.gcBackup.Name = "gcBackup";
            this.gcBackup.Size = new System.Drawing.Size(1110, 491);
            this.gcBackup.TabIndex = 5;
            this.gcBackup.ToolTipController = this.defaultToolTipController1.DefaultController;
            // 
            // bdsDSBACKUP_LOG
            // 
            this.bdsDSBACKUP_LOG.DataMember = "sp_DanhSachBackupLog";
            this.bdsDSBACKUP_LOG.DataSource = this.qLTVDataSet;
            // 
            // dATABASESTableAdapter
            // 
            this.dATABASESTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHITIETNGANTUTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.CT_PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.DAUSACHTableAdapter = null;
            this.tableAdapterManager.DOCGIATableAdapter = null;
            this.tableAdapterManager.NGANTUTableAdapter = null;
            this.tableAdapterManager.NGONNGUTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.SACHTableAdapter = null;
            this.tableAdapterManager.sp_DanhSachBackupTableAdapter = null;
            this.tableAdapterManager.TACGIA_SACHTableAdapter = null;
            this.tableAdapterManager.TACGIATableAdapter = null;
            this.tableAdapterManager.THELOAITableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sp_DanhSachBackupTableAdapter
            // 
            this.sp_DanhSachBackupTableAdapter.ClearBeforeFill = true;
            // 
            // sp_DanhSachBackupLogTableAdapter
            // 
            this.sp_DanhSachBackupLogTableAdapter.ClearBeforeFill = true;
            // 
            // FormBackupRestore
            // 
            this.defaultToolTipController1.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 555);
            this.Controls.Add(this.fillToolStrip);
            this.Controls.Add(this.gcBackup);
            this.Controls.Add(this.gcDB);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormBackupRestore";
            this.Text = "Sao lưu - Phục hồi cơ sở dữ liệu";
            this.Load += new System.EventHandler(this.FormBackupRestore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDB)).EndInit();
            this.gcDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dATABASESGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_DanhSachBackupGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSBACKUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSBACKUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcINPUTTG)).EndInit();
            this.pcINPUTTG.ResumeLayout(false);
            this.pcINPUTTG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeTGPHUCHOI.Properties)).EndInit();
            this.fillToolStrip.ResumeLayout(false);
            this.fillToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBackup)).EndInit();
            this.gcBackup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSBACKUP_LOG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnSaoLuu;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarCheckItem ckbThoiGian;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnTaoDevice;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private System.Windows.Forms.BindingSource bdsDB;
        private QLTVDataSet qLTVDataSet;
        private DevExpress.XtraEditors.GroupControl gcBackup;
        private DevExpress.XtraEditors.GroupControl gcDB;
        private QLTVDataSetTableAdapters.DATABASESTableAdapter dATABASESTableAdapter;
        private QLTVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl dATABASESGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDB;
        private DevExpress.XtraGrid.Columns.GridColumn colname;
        private System.Windows.Forms.ToolStrip fillToolStrip;
        private System.Windows.Forms.ToolStripLabel dB_NAMEToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox dB_NAMEToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillToolStripButton;
        private System.Windows.Forms.BindingSource bdsDSBACKUP;
        private QLTVDataSetTableAdapters.sp_DanhSachBackupTableAdapter sp_DanhSachBackupTableAdapter;
        private DevExpress.XtraGrid.GridControl sp_DanhSachBackupGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDSBACKUP;
        private DevExpress.XtraEditors.PanelControl pcINPUTTG;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.DateTimeOffsetEdit dateTimeTGPHUCHOI;
        private DevExpress.XtraGrid.Columns.GridColumn colposition;
        private DevExpress.XtraGrid.Columns.GridColumn colname1;
        private DevExpress.XtraGrid.Columns.GridColumn coldescription;
        private DevExpress.XtraGrid.Columns.GridColumn colbackup_start_date;
        private DevExpress.XtraGrid.Columns.GridColumn coluser_name;
        private DevExpress.XtraGrid.Columns.GridColumn coltype;
        private DevExpress.XtraGrid.Columns.GridColumn coldevice_name;
        private System.Windows.Forms.BindingSource bdsDSBACKUP_LOG;
        private QLTVDataSetTableAdapters.sp_DanhSachBackupLogTableAdapter sp_DanhSachBackupLogTableAdapter;
        private DevExpress.Utils.DefaultToolTipController defaultToolTipController1;
        private DevExpress.XtraEditors.LabelControl lblThongBao;
    }
}