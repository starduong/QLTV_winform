namespace AppLibrary
{
    partial class FormTraSach2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTraSach2));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSHOWDATA = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItemTAICHO = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnDATA = new DevExpress.XtraEditors.PanelControl();
            this.gcDISPLAY = new DevExpress.XtraEditors.GroupControl();
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl = new DevExpress.XtraGrid.GridControl();
            this.sp_GetPhieuMuonChiTietTheoHinhThucBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.gvCTPMHINHTHUC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPHIEU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTENDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSACH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYMUON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRANGTHAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TRASACH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.pnINPUT = new DevExpress.XtraEditors.PanelControl();
            this.rbMAT = new System.Windows.Forms.RadioButton();
            this.rbHONG = new System.Windows.Forms.RadioButton();
            this.rbTOT = new System.Windows.Forms.RadioButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter();
            this.tableAdapterManager = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnDATA)).BeginInit();
            this.pnDATA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDISPLAY)).BeginInit();
            this.gcDISPLAY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_GetPhieuMuonChiTietTheoHinhThucBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCTPMHINHTHUC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnINPUT)).BeginInit();
            this.pnINPUT.SuspendLayout();
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
            this.barButtonItem1,
            this.btnSHOWDATA,
            this.barButtonItemTAICHO,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSHOWDATA, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem3, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnSHOWDATA
            // 
            this.btnSHOWDATA.Caption = "TẠI CHỖ CHƯA TRẢ";
            this.btnSHOWDATA.Id = 2;
            this.btnSHOWDATA.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSHOWDATA.ImageOptions.SvgImage")));
            this.btnSHOWDATA.Name = "btnSHOWDATA";
            this.btnSHOWDATA.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSHOWDATA.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSHOWDATA_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "REFRESH";
            this.barButtonItem2.Id = 5;
            this.barButtonItem2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem2.ImageOptions.SvgImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "THOÁT";
            this.barButtonItem3.Id = 6;
            this.barButtonItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItem3.ImageOptions.SvgImage")));
            this.barButtonItem3.Name = "barButtonItem3";
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
            this.barDockControlTop.Size = new System.Drawing.Size(1364, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 644);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1364, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 604);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1364, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 604);
            // 
            // barButtonItemTAICHO
            // 
            this.barButtonItemTAICHO.Caption = "Danh sách độc giả mượn tại chỗ chưa trả sách";
            this.barButtonItemTAICHO.Id = 4;
            this.barButtonItemTAICHO.Name = "barButtonItemTAICHO";
            this.barButtonItemTAICHO.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.pnDATA);
            this.panelControl1.Controls.Add(this.pnINPUT);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 40);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1364, 604);
            this.panelControl1.TabIndex = 4;
            // 
            // pnDATA
            // 
            this.pnDATA.Controls.Add(this.gcDISPLAY);
            this.pnDATA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDATA.Location = new System.Drawing.Point(0, 79);
            this.pnDATA.Name = "pnDATA";
            this.pnDATA.Size = new System.Drawing.Size(1364, 525);
            this.pnDATA.TabIndex = 2;
            // 
            // gcDISPLAY
            // 
            this.gcDISPLAY.Controls.Add(this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl);
            this.gcDISPLAY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDISPLAY.Location = new System.Drawing.Point(2, 2);
            this.gcDISPLAY.Name = "gcDISPLAY";
            this.gcDISPLAY.Size = new System.Drawing.Size(1360, 521);
            this.gcDISPLAY.TabIndex = 0;
            this.gcDISPLAY.Text = "DANH SÁCH PHIẾU MƯỢN MƯỢN VỀ CHƯA TRẢ";
            // 
            // sp_GetPhieuMuonChiTietTheoHinhThucGridControl
            // 
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl.DataSource = this.sp_GetPhieuMuonChiTietTheoHinhThucBindingSource;
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl.Location = new System.Drawing.Point(2, 32);
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl.MainView = this.gvCTPMHINHTHUC;
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl.MenuManager = this.barManager1;
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl.Name = "sp_GetPhieuMuonChiTietTheoHinhThucGridControl";
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl.Size = new System.Drawing.Size(1356, 487);
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl.TabIndex = 0;
            this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCTPMHINHTHUC});
            // 
            // sp_GetPhieuMuonChiTietTheoHinhThucBindingSource
            // 
            this.sp_GetPhieuMuonChiTietTheoHinhThucBindingSource.DataMember = "sp_GetPhieuMuonChiTietTheoHinhThuc";
            this.sp_GetPhieuMuonChiTietTheoHinhThucBindingSource.DataSource = this.qLTVDataSet;
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gvCTPMHINHTHUC
            // 
            this.gvCTPMHINHTHUC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPHIEU,
            this.colHOTENDG,
            this.colSACH,
            this.colNGAYMUON,
            this.colTRANGTHAI,
            this.TRASACH});
            this.gvCTPMHINHTHUC.GridControl = this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl;
            this.gvCTPMHINHTHUC.Name = "gvCTPMHINHTHUC";
            this.gvCTPMHINHTHUC.OptionsBehavior.Editable = false;
            // 
            // colMAPHIEU
            // 
            this.colMAPHIEU.Caption = "MÃ PHIẾU";
            this.colMAPHIEU.FieldName = "MAPHIEU";
            this.colMAPHIEU.MinWidth = 30;
            this.colMAPHIEU.Name = "colMAPHIEU";
            this.colMAPHIEU.Visible = true;
            this.colMAPHIEU.VisibleIndex = 0;
            this.colMAPHIEU.Width = 123;
            // 
            // colHOTENDG
            // 
            this.colHOTENDG.Caption = "HỌ TÊN ĐỘC GIẢ";
            this.colHOTENDG.FieldName = "HOTENDG";
            this.colHOTENDG.MinWidth = 30;
            this.colHOTENDG.Name = "colHOTENDG";
            this.colHOTENDG.Visible = true;
            this.colHOTENDG.VisibleIndex = 1;
            this.colHOTENDG.Width = 284;
            // 
            // colSACH
            // 
            this.colSACH.Caption = "TÊN SÁCH - MÃ SÁCH";
            this.colSACH.FieldName = "SACH";
            this.colSACH.MinWidth = 30;
            this.colSACH.Name = "colSACH";
            this.colSACH.Visible = true;
            this.colSACH.VisibleIndex = 2;
            this.colSACH.Width = 446;
            // 
            // colNGAYMUON
            // 
            this.colNGAYMUON.Caption = "NGÀY MƯỢN";
            this.colNGAYMUON.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.colNGAYMUON.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAYMUON.FieldName = "NGAYMUON";
            this.colNGAYMUON.MinWidth = 30;
            this.colNGAYMUON.Name = "colNGAYMUON";
            this.colNGAYMUON.Visible = true;
            this.colNGAYMUON.VisibleIndex = 3;
            this.colNGAYMUON.Width = 203;
            // 
            // colTRANGTHAI
            // 
            this.colTRANGTHAI.Caption = "TRẠNG THÁI";
            this.colTRANGTHAI.FieldName = "TRANGTHAI";
            this.colTRANGTHAI.MinWidth = 30;
            this.colTRANGTHAI.Name = "colTRANGTHAI";
            this.colTRANGTHAI.Visible = true;
            this.colTRANGTHAI.VisibleIndex = 4;
            this.colTRANGTHAI.Width = 205;
            // 
            // TRASACH
            // 
            this.TRASACH.Caption = "HÀNH ĐỘNG";
            this.TRASACH.ColumnEdit = this.repositoryItemButtonEdit1;
            this.TRASACH.MinWidth = 30;
            this.TRASACH.Name = "TRASACH";
            this.TRASACH.Visible = true;
            this.TRASACH.VisibleIndex = 5;
            this.TRASACH.Width = 112;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            editorButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions1.SvgImage")));
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "TRẢ SÁCH", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.repositoryItemButtonEdit1.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("repositoryItemButtonEdit1.ContextImageOptions.SvgImage")));
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // pnINPUT
            // 
            this.pnINPUT.Controls.Add(this.rbMAT);
            this.pnINPUT.Controls.Add(this.rbHONG);
            this.pnINPUT.Controls.Add(this.rbTOT);
            this.pnINPUT.Controls.Add(this.labelControl1);
            this.pnINPUT.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnINPUT.Location = new System.Drawing.Point(0, 0);
            this.pnINPUT.Name = "pnINPUT";
            this.pnINPUT.Size = new System.Drawing.Size(1364, 79);
            this.pnINPUT.TabIndex = 1;
            // 
            // rbMAT
            // 
            this.rbMAT.AutoSize = true;
            this.rbMAT.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMAT.Location = new System.Drawing.Point(552, 30);
            this.rbMAT.Name = "rbMAT";
            this.rbMAT.Size = new System.Drawing.Size(69, 27);
            this.rbMAT.TabIndex = 3;
            this.rbMAT.TabStop = true;
            this.rbMAT.Text = "Mất";
            this.rbMAT.UseVisualStyleBackColor = true;
            // 
            // rbHONG
            // 
            this.rbHONG.AutoSize = true;
            this.rbHONG.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHONG.Location = new System.Drawing.Point(435, 30);
            this.rbHONG.Name = "rbHONG";
            this.rbHONG.Size = new System.Drawing.Size(101, 27);
            this.rbHONG.TabIndex = 2;
            this.rbHONG.TabStop = true;
            this.rbHONG.Text = "Bị hỏng";
            this.rbHONG.UseVisualStyleBackColor = true;
            // 
            // rbTOT
            // 
            this.rbTOT.AutoSize = true;
            this.rbTOT.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTOT.Location = new System.Drawing.Point(283, 30);
            this.rbTOT.Name = "rbTOT";
            this.rbTOT.Size = new System.Drawing.Size(131, 27);
            this.rbTOT.TabIndex = 1;
            this.rbTOT.TabStop = true;
            this.rbTOT.Text = "Nguyên vẹn";
            this.rbTOT.UseVisualStyleBackColor = true;
            this.rbTOT.CheckedChanged += new System.EventHandler(this.rbTOT_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(52, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(192, 23);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "TÌNH TRẠNG SÁCH:";
            // 
            // sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter
            // 
            this.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHITIETNGANTUTableAdapter = null;
            this.tableAdapterManager.CT_PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.DAUSACHTableAdapter = null;
            this.tableAdapterManager.DOCGIATableAdapter = null;
            this.tableAdapterManager.NGANTUTableAdapter = null;
            this.tableAdapterManager.NGONNGUTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.SACHTableAdapter = null;
            this.tableAdapterManager.sp_DanhSachBackupTableAdapter = null;
            this.tableAdapterManager.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter = this.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter;
            this.tableAdapterManager.sp_GetSachDangMuon_ByDocGiaTableAdapter = null;
            this.tableAdapterManager.TACGIA_SACHTableAdapter = null;
            this.tableAdapterManager.TACGIATableAdapter = null;
            this.tableAdapterManager.THELOAITableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // FormTraSach2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 668);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormTraSach2";
            this.Text = "Quản lý trả sách";
            this.Load += new System.EventHandler(this.FormTraSach2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnDATA)).EndInit();
            this.pnDATA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDISPLAY)).EndInit();
            this.gcDISPLAY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp_GetPhieuMuonChiTietTheoHinhThucGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_GetPhieuMuonChiTietTheoHinhThucBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCTPMHINHTHUC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnINPUT)).EndInit();
            this.pnINPUT.ResumeLayout(false);
            this.pnINPUT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnSHOWDATA;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTAICHO;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl gcDISPLAY;
        private System.Windows.Forms.BindingSource sp_GetPhieuMuonChiTietTheoHinhThucBindingSource;
        private QLTVDataSet qLTVDataSet;
        private QLTVDataSetTableAdapters.sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter sp_GetPhieuMuonChiTietTheoHinhThucTableAdapter;
        private QLTVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.PanelControl pnDATA;
        private DevExpress.XtraEditors.PanelControl pnINPUT;
        private DevExpress.XtraGrid.GridControl sp_GetPhieuMuonChiTietTheoHinhThucGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCTPMHINHTHUC;
        private System.Windows.Forms.RadioButton rbMAT;
        private System.Windows.Forms.RadioButton rbHONG;
        private System.Windows.Forms.RadioButton rbTOT;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPHIEU;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTENDG;
        private DevExpress.XtraGrid.Columns.GridColumn colSACH;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYMUON;
        private DevExpress.XtraGrid.Columns.GridColumn colTRANGTHAI;
        private DevExpress.XtraGrid.Columns.GridColumn TRASACH;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}