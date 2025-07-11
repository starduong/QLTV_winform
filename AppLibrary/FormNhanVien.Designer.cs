﻿namespace AppLibrary
{
    partial class FormNhanVien
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
            System.Windows.Forms.Label gIOITINHLabel;
            System.Windows.Forms.Label TTXLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanVien));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ds_QLTV = new AppLibrary.QLTVDataSet();
            this.bds_NhanVien = new System.Windows.Forms.BindingSource(this.components);
            this.ta_NhanVien = new AppLibrary.QLTVDataSetTableAdapters.NHANVIENTableAdapter();
            this.tam_NhanVien = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.nHANVIENGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHONV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIOITINH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIENTHOAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRANGTHAIXOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.radioButtonNGHI = new System.Windows.Forms.RadioButton();
            this.tRANGTHAIXOARadioButton = new System.Windows.Forms.RadioButton();
            this.checkEditNu = new DevExpress.XtraEditors.CheckEdit();
            this.gIOITINHCheckEditNAM = new DevExpress.XtraEditors.CheckEdit();
            this.textEditEMAIL = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textEditHO = new DevExpress.XtraEditors.TextEdit();
            this.textEditTEN = new DevExpress.XtraEditors.TextEdit();
            this.textEditDIENTHOAI = new DevExpress.XtraEditors.TextEdit();
            this.textEditDIACHI = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textEditMANV = new DevExpress.XtraEditors.TextEdit();
            gIOITINHLabel = new System.Windows.Forms.Label();
            TTXLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_QLTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_NhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditNu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIOITINHCheckEditNAM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEMAIL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTEN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDIENTHOAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDIACHI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMANV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gIOITINHLabel
            // 
            gIOITINHLabel.AutoSize = true;
            gIOITINHLabel.Location = new System.Drawing.Point(79, 145);
            gIOITINHLabel.Name = "gIOITINHLabel";
            gIOITINHLabel.Size = new System.Drawing.Size(63, 16);
            gIOITINHLabel.TabIndex = 16;
            gIOITINHLabel.Text = "Giới tính :";
            // 
            // TTXLabel
            // 
            TTXLabel.AutoSize = true;
            TTXLabel.Location = new System.Drawing.Point(70, 175);
            TTXLabel.Name = "TTXLabel";
            TTXLabel.Size = new System.Drawing.Size(72, 16);
            TTXLabel.TabIndex = 18;
            TTXLabel.Text = "Trạng thái :";
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
            this.btnGhi,
            this.btnXoa,
            this.btnPhucHoi,
            this.btnRefresh,
            this.btnThoat,
            this.barButtonItem9,
            this.barButtonItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 17;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGhi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPhucHoi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
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
            this.btnXoa.Caption = "Cho nghỉ";
            this.btnXoa.Id = 3;
            this.btnXoa.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXoa.ImageOptions.SvgImage")));
            this.btnXoa.ImageOptions.SvgImageSize = new System.Drawing.Size(17, 17);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Caption = "Undo";
            this.btnPhucHoi.Id = 4;
            this.btnPhucHoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPhucHoi.ImageOptions.SvgImage")));
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhucHoi_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(1419, 35);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 927);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1419, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 35);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 892);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1419, 35);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 892);
            // 
            // btnThoat
            // 
            this.btnThoat.Id = 14;
            this.btnThoat.Name = "btnThoat";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "barButtonItem9";
            this.barButtonItem9.Id = 8;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 35);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1419, 38);
            this.panelControl1.TabIndex = 4;
            // 
            // ds_QLTV
            // 
            this.ds_QLTV.DataSetName = "QLTVDataSet";
            this.ds_QLTV.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bds_NhanVien
            // 
            this.bds_NhanVien.DataMember = "NHANVIEN";
            this.bds_NhanVien.DataSource = this.ds_QLTV;
            // 
            // ta_NhanVien
            // 
            this.ta_NhanVien.ClearBeforeFill = true;
            // 
            // tam_NhanVien
            // 
            this.tam_NhanVien.BackupDataSetBeforeUpdate = false;
            this.tam_NhanVien.CHITIETNGANTUTableAdapter = null;
            this.tam_NhanVien.CT_PHIEUMUONTableAdapter = null;
            this.tam_NhanVien.DAUSACHTableAdapter = null;
            this.tam_NhanVien.DOCGIATableAdapter = null;
            this.tam_NhanVien.NGANTUTableAdapter = null;
            this.tam_NhanVien.NGONNGUTableAdapter = null;
            this.tam_NhanVien.NHANVIENTableAdapter = this.ta_NhanVien;
            this.tam_NhanVien.PHIEUMUONTableAdapter = null;
            this.tam_NhanVien.SACHTableAdapter = null;
            this.tam_NhanVien.sp_DanhSachBackupTableAdapter = null;
            this.tam_NhanVien.TACGIA_SACHTableAdapter = null;
            this.tam_NhanVien.TACGIATableAdapter = null;
            this.tam_NhanVien.THELOAITableAdapter = null;
            this.tam_NhanVien.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nHANVIENGridControl
            // 
            this.nHANVIENGridControl.DataSource = this.bds_NhanVien;
            this.nHANVIENGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nHANVIENGridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.nHANVIENGridControl.Location = new System.Drawing.Point(0, 73);
            this.nHANVIENGridControl.MainView = this.gridView1;
            this.nHANVIENGridControl.Margin = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.nHANVIENGridControl.MenuManager = this.barManager1;
            this.nHANVIENGridControl.Name = "nHANVIENGridControl";
            this.nHANVIENGridControl.Size = new System.Drawing.Size(1419, 643);
            this.nHANVIENGridControl.TabIndex = 6;
            this.nHANVIENGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMANV,
            this.colHONV,
            this.colTENNV,
            this.colGIOITINH,
            this.colDIACHI,
            this.colDIENTHOAI,
            this.colEMAIL,
            this.colTRANGTHAIXOA});
            this.gridView1.DetailHeight = 1810;
            this.gridView1.GridControl = this.nHANVIENGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 3866;
            // 
            // colMANV
            // 
            this.colMANV.Caption = "Mã nhân viên";
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 159;
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 0;
            this.colMANV.Width = 176;
            // 
            // colHONV
            // 
            this.colHONV.Caption = "Họ";
            this.colHONV.FieldName = "HONV";
            this.colHONV.MinWidth = 159;
            this.colHONV.Name = "colHONV";
            this.colHONV.Visible = true;
            this.colHONV.VisibleIndex = 1;
            this.colHONV.Width = 255;
            // 
            // colTENNV
            // 
            this.colTENNV.Caption = "Tên";
            this.colTENNV.FieldName = "TENNV";
            this.colTENNV.MinWidth = 159;
            this.colTENNV.Name = "colTENNV";
            this.colTENNV.Visible = true;
            this.colTENNV.VisibleIndex = 2;
            this.colTENNV.Width = 220;
            // 
            // colGIOITINH
            // 
            this.colGIOITINH.Caption = "Giới tính";
            this.colGIOITINH.FieldName = "GIOITINH";
            this.colGIOITINH.MinWidth = 159;
            this.colGIOITINH.Name = "colGIOITINH";
            this.colGIOITINH.Visible = true;
            this.colGIOITINH.VisibleIndex = 3;
            this.colGIOITINH.Width = 159;
            // 
            // colDIACHI
            // 
            this.colDIACHI.Caption = "Địa chỉ";
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.MinWidth = 159;
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 4;
            this.colDIACHI.Width = 197;
            // 
            // colDIENTHOAI
            // 
            this.colDIENTHOAI.Caption = "Điện thoại";
            this.colDIENTHOAI.FieldName = "DIENTHOAI";
            this.colDIENTHOAI.MinWidth = 159;
            this.colDIENTHOAI.Name = "colDIENTHOAI";
            this.colDIENTHOAI.Visible = true;
            this.colDIENTHOAI.VisibleIndex = 5;
            this.colDIENTHOAI.Width = 159;
            // 
            // colEMAIL
            // 
            this.colEMAIL.Caption = "Email";
            this.colEMAIL.FieldName = "EMAIL";
            this.colEMAIL.MinWidth = 159;
            this.colEMAIL.Name = "colEMAIL";
            this.colEMAIL.Visible = true;
            this.colEMAIL.VisibleIndex = 6;
            this.colEMAIL.Width = 159;
            // 
            // colTRANGTHAIXOA
            // 
            this.colTRANGTHAIXOA.Caption = "Trạng thái ";
            this.colTRANGTHAIXOA.FieldName = "TRANGTHAIXOA";
            this.colTRANGTHAIXOA.MinWidth = 25;
            this.colTRANGTHAIXOA.Name = "colTRANGTHAIXOA";
            this.colTRANGTHAIXOA.Visible = true;
            this.colTRANGTHAIXOA.VisibleIndex = 7;
            this.colTRANGTHAIXOA.Width = 73;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.radioButtonNGHI);
            this.panelControl2.Controls.Add(TTXLabel);
            this.panelControl2.Controls.Add(this.tRANGTHAIXOARadioButton);
            this.panelControl2.Controls.Add(this.checkEditNu);
            this.panelControl2.Controls.Add(gIOITINHLabel);
            this.panelControl2.Controls.Add(this.gIOITINHCheckEditNAM);
            this.panelControl2.Controls.Add(this.textEditEMAIL);
            this.panelControl2.Controls.Add(this.label7);
            this.panelControl2.Controls.Add(this.label5);
            this.panelControl2.Controls.Add(this.textEditHO);
            this.panelControl2.Controls.Add(this.textEditTEN);
            this.panelControl2.Controls.Add(this.textEditDIENTHOAI);
            this.panelControl2.Controls.Add(this.textEditDIACHI);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.textEditMANV);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 716);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1419, 211);
            this.panelControl2.TabIndex = 7;
            // 
            // radioButtonNGHI
            // 
            this.radioButtonNGHI.AutoSize = true;
            this.radioButtonNGHI.Location = new System.Drawing.Point(258, 172);
            this.radioButtonNGHI.Name = "radioButtonNGHI";
            this.radioButtonNGHI.Size = new System.Drawing.Size(79, 20);
            this.radioButtonNGHI.TabIndex = 20;
            this.radioButtonNGHI.TabStop = true;
            this.radioButtonNGHI.Text = "Nghỉ làm";
            this.radioButtonNGHI.UseVisualStyleBackColor = true;
            this.radioButtonNGHI.CheckedChanged += new System.EventHandler(this.radioButtonNGHI_CheckedChanged);
            // 
            // tRANGTHAIXOARadioButton
            // 
            this.tRANGTHAIXOARadioButton.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bds_NhanVien, "TRANGTHAIXOA", true));
            this.tRANGTHAIXOARadioButton.Location = new System.Drawing.Point(148, 170);
            this.tRANGTHAIXOARadioButton.Name = "tRANGTHAIXOARadioButton";
            this.tRANGTHAIXOARadioButton.Size = new System.Drawing.Size(104, 24);
            this.tRANGTHAIXOARadioButton.TabIndex = 19;
            this.tRANGTHAIXOARadioButton.TabStop = true;
            this.tRANGTHAIXOARadioButton.Text = "Bình thường";
            this.tRANGTHAIXOARadioButton.UseVisualStyleBackColor = true;
            this.tRANGTHAIXOARadioButton.CheckedChanged += new System.EventHandler(this.tRANGTHAIXOARadioButton_CheckedChanged);
            // 
            // checkEditNu
            // 
            this.checkEditNu.Location = new System.Drawing.Point(198, 143);
            this.checkEditNu.MenuManager = this.barManager1;
            this.checkEditNu.Name = "checkEditNu";
            this.checkEditNu.Properties.Caption = "Nữ";
            this.checkEditNu.Size = new System.Drawing.Size(94, 20);
            this.checkEditNu.TabIndex = 18;
            this.checkEditNu.CheckedChanged += new System.EventHandler(this.checkEditNu_CheckedChanged);
            // 
            // gIOITINHCheckEditNAM
            // 
            this.gIOITINHCheckEditNAM.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bds_NhanVien, "GIOITINH", true));
            this.gIOITINHCheckEditNAM.Location = new System.Drawing.Point(148, 143);
            this.gIOITINHCheckEditNAM.MenuManager = this.barManager1;
            this.gIOITINHCheckEditNAM.Name = "gIOITINHCheckEditNAM";
            this.gIOITINHCheckEditNAM.Properties.Caption = "Nam";
            this.gIOITINHCheckEditNAM.Size = new System.Drawing.Size(180, 19);
            this.gIOITINHCheckEditNAM.TabIndex = 17;
            this.gIOITINHCheckEditNAM.CheckedChanged += new System.EventHandler(this.gIOITINHCheckEditNAM_CheckedChanged);
            // 
            // textEditEMAIL
            // 
            this.textEditEMAIL.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bds_NhanVien, "EMAIL", true));
            this.textEditEMAIL.Location = new System.Drawing.Point(812, 137);
            this.textEditEMAIL.MenuManager = this.barManager1;
            this.textEditEMAIL.Name = "textEditEMAIL";
            this.textEditEMAIL.Properties.MaxLength = 50;
            this.textEditEMAIL.Size = new System.Drawing.Size(472, 23);
            this.textEditEMAIL.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(710, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Số điện thoại :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(743, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Địa chỉ :";
            // 
            // textEditHO
            // 
            this.textEditHO.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bds_NhanVien, "HONV", true));
            this.textEditHO.Location = new System.Drawing.Point(148, 47);
            this.textEditHO.MenuManager = this.barManager1;
            this.textEditHO.Name = "textEditHO";
            this.textEditHO.Properties.MaxLength = 50;
            this.textEditHO.Size = new System.Drawing.Size(472, 23);
            this.textEditHO.TabIndex = 10;
            // 
            // textEditTEN
            // 
            this.textEditTEN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bds_NhanVien, "TENNV", true));
            this.textEditTEN.Location = new System.Drawing.Point(148, 94);
            this.textEditTEN.MenuManager = this.barManager1;
            this.textEditTEN.Name = "textEditTEN";
            this.textEditTEN.Properties.MaxLength = 50;
            this.textEditTEN.Size = new System.Drawing.Size(472, 23);
            this.textEditTEN.TabIndex = 9;
            // 
            // textEditDIENTHOAI
            // 
            this.textEditDIENTHOAI.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bds_NhanVien, "DIENTHOAI", true));
            this.textEditDIENTHOAI.Location = new System.Drawing.Point(812, 94);
            this.textEditDIENTHOAI.MenuManager = this.barManager1;
            this.textEditDIENTHOAI.Name = "textEditDIENTHOAI";
            this.textEditDIENTHOAI.Properties.MaxLength = 15;
            this.textEditDIENTHOAI.Size = new System.Drawing.Size(472, 23);
            this.textEditDIENTHOAI.TabIndex = 8;
            // 
            // textEditDIACHI
            // 
            this.textEditDIACHI.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bds_NhanVien, "DIACHI", true));
            this.textEditDIACHI.Location = new System.Drawing.Point(812, 47);
            this.textEditDIACHI.MenuManager = this.barManager1;
            this.textEditDIACHI.Name = "textEditDIACHI";
            this.textEditDIACHI.Properties.MaxLength = 100;
            this.textEditDIACHI.Size = new System.Drawing.Size(472, 23);
            this.textEditDIACHI.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Họ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(752, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã nhân viên :";
            // 
            // textEditMANV
            // 
            this.textEditMANV.Location = new System.Drawing.Point(148, 9);
            this.textEditMANV.MenuManager = this.barManager1;
            this.textEditMANV.Name = "textEditMANV";
            this.textEditMANV.Size = new System.Drawing.Size(89, 23);
            this.textEditMANV.TabIndex = 0;

            // 
            // FormNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1419, 949);
            this.Controls.Add(this.nHANVIENGridControl);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormNhanVien";
            this.Text = "Danh sách Nhân viên";
            this.Load += new System.EventHandler(this.FormNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_QLTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bds_NhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditNu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIOITINHCheckEditNAM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEMAIL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTEN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDIENTHOAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDIACHI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMANV.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource bds_NhanVien;
        private QLTVDataSet ds_QLTV;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private QLTVDataSetTableAdapters.NHANVIENTableAdapter ta_NhanVien;
        private QLTVDataSetTableAdapters.TableAdapterManager tam_NhanVien;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl nHANVIENGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraGrid.Columns.GridColumn colHONV;
        private DevExpress.XtraGrid.Columns.GridColumn colTENNV;
        private DevExpress.XtraGrid.Columns.GridColumn colGIOITINH;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colDIENTHOAI;
        private DevExpress.XtraGrid.Columns.GridColumn colEMAIL;
        private DevExpress.XtraEditors.TextEdit textEditMANV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit textEditHO;
        private DevExpress.XtraEditors.TextEdit textEditTEN;
        private DevExpress.XtraEditors.TextEdit textEditDIENTHOAI;
        private DevExpress.XtraEditors.TextEdit textEditDIACHI;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.TextEdit textEditEMAIL;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.CheckEdit gIOITINHCheckEditNAM;
        private DevExpress.XtraEditors.CheckEdit checkEditNu;
        private DevExpress.XtraGrid.Columns.GridColumn colTRANGTHAIXOA;
        private System.Windows.Forms.RadioButton radioButtonNGHI;
        private System.Windows.Forms.RadioButton tRANGTHAIXOARadioButton;

    }
}