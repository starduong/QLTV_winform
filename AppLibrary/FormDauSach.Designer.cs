using System.Windows.Forms;

namespace AppLibrary
{
    partial class FormDauSach
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
            System.Windows.Forms.Label mATLLabel;
            System.Windows.Forms.Label mANGONNGULabel;
            System.Windows.Forms.Label nHAXBLabel;
            System.Windows.Forms.Label gIALabel;
            System.Windows.Forms.Label sOTRANGLabel;
            System.Windows.Forms.Label lANXUATBANLabel;
            System.Windows.Forms.Label nGAYXUATBANLabel;
            System.Windows.Forms.Label hINHANHPATHLabel;
            System.Windows.Forms.Label nOIDUNGLabel;
            System.Windows.Forms.Label kHOSACHLabel;
            System.Windows.Forms.Label tENSACHLabel;
            System.Windows.Forms.Label iSBNLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDauSach));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDauSach = new DevExpress.XtraBars.Bar();
            this.btnTHEM = new DevExpress.XtraBars.BarButtonItem();
            this.btnGHI = new DevExpress.XtraBars.BarButtonItem();
            this.btnXOA = new DevExpress.XtraBars.BarButtonItem();
            this.btnUNDO = new DevExpress.XtraBars.BarButtonItem();
            this.btnREDO = new DevExpress.XtraBars.BarButtonItem();
            this.btnREFRESH = new DevExpress.XtraBars.BarButtonItem();
            this.btnTHOAT = new DevExpress.XtraBars.BarButtonItem();
            this.btnTG_SACH = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnSUA = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.btnTACGIA_SACH = new DevExpress.XtraBars.BarButtonItem();
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.bdsDAUSACH = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterDAUSACH = new AppLibrary.QLTVDataSetTableAdapters.DAUSACHTableAdapter();
            this.gcDAUSACH = new DevExpress.XtraGrid.GridControl();
            this.gridViewDAUSACH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colISBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENSACH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKHOSACH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNOIDUNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYXUATBAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLANXUATBAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOTRANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNHAXB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANGONNGU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.bdsDSNgonNgu = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMATL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.bdsDSTheLoai = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.tamDauSach = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.gcThongTinDauSach = new DevExpress.XtraEditors.GroupControl();
            this.pncINPUT = new DevExpress.XtraEditors.PanelControl();
            this.cbKHOSACH = new System.Windows.Forms.ComboBox();
            this.txtISBN = new DevExpress.XtraEditors.TextEdit();
            this.txtNOIDUNG = new System.Windows.Forms.TextBox();
            this.txtHinhAnh = new DevExpress.XtraEditors.ButtonEdit();
            this.txtMaTheLoai = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNgonNgu = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbTheLoai = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbNgonNgu = new System.Windows.Forms.ComboBox();
            this.txtNHAXB = new DevExpress.XtraEditors.TextEdit();
            this.speGIA = new DevExpress.XtraEditors.SpinEdit();
            this.speSOTRANG = new DevExpress.XtraEditors.SpinEdit();
            this.speLANXB = new DevExpress.XtraEditors.SpinEdit();
            this.dteNGAYXB = new DevExpress.XtraEditors.DateEdit();
            this.txtTENSACH = new DevExpress.XtraEditors.TextEdit();
            this.picDauSach = new DevExpress.XtraEditors.PictureEdit();
            this.bdsSACH = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterSACH = new AppLibrary.QLTVDataSetTableAdapters.SACHTableAdapter();
            this.bdsChiTietNganTu = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStripSACH = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnThemSach = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGhiSach = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoaSach = new System.Windows.Forms.ToolStripMenuItem();
            this.tableAdapterNGONNGU = new AppLibrary.QLTVDataSetTableAdapters.DSNGONNGUTableAdapter();
            this.tableAdapterTHELOAI = new AppLibrary.QLTVDataSetTableAdapters.DSTHELOAITableAdapter();
            this.tableAdapterCTNGANTU = new AppLibrary.QLTVDataSetTableAdapters.CHITIETNGANTUTableAdapter();
            this.gcTABLESACH = new DevExpress.XtraEditors.GroupControl();
            this.gvSACH = new System.Windows.Forms.DataGridView();
            this.tINHTRANG_SACHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvTACGIA_SACH = new System.Windows.Forms.DataGridView();
            this.ISBN_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MATACGIA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bdsTACGIA = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStripTACGIA = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnTHEM_TGS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGHI_TGS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXOA_TGS = new System.Windows.Forms.ToolStripMenuItem();
            this.bdsTACGIA_SACH = new System.Windows.Forms.BindingSource(this.components);
            this.cHOMUON_SACHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableAdapterTACGIA_SACH = new AppLibrary.QLTVDataSetTableAdapters.TACGIA_SACHTableAdapter();
            this.cHOMUON_SACHTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.CHOMUON_SACHTableAdapter();
            this.tINHTRANG_SACHTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.TINHTRANG_SACHTableAdapter();
            this.tACGIATableAdapter = new AppLibrary.QLTVDataSetTableAdapters.TACGIATableAdapter();
            this.fKCTPHIEUMUONSACHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cT_PHIEUMUONTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.CT_PHIEUMUONTableAdapter();
            this.MASACH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TINHTRANG = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CHOMUON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGANTU = new System.Windows.Forms.DataGridViewComboBoxColumn();
            mATLLabel = new System.Windows.Forms.Label();
            mANGONNGULabel = new System.Windows.Forms.Label();
            nHAXBLabel = new System.Windows.Forms.Label();
            gIALabel = new System.Windows.Forms.Label();
            sOTRANGLabel = new System.Windows.Forms.Label();
            lANXUATBANLabel = new System.Windows.Forms.Label();
            nGAYXUATBANLabel = new System.Windows.Forms.Label();
            hINHANHPATHLabel = new System.Windows.Forms.Label();
            nOIDUNGLabel = new System.Windows.Forms.Label();
            kHOSACHLabel = new System.Windows.Forms.Label();
            tENSACHLabel = new System.Windows.Forms.Label();
            iSBNLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDAUSACH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDAUSACH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDAUSACH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSNgonNgu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSTheLoai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcThongTinDauSach)).BeginInit();
            this.gcThongTinDauSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pncINPUT)).BeginInit();
            this.pncINPUT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtISBN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHinhAnh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTheLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNgonNgu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNHAXB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speGIA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speSOTRANG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speLANXB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYXB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYXB.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTENSACH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDauSach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSACH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsChiTietNganTu)).BeginInit();
            this.contextMenuStripSACH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcTABLESACH)).BeginInit();
            this.gcTABLESACH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSACH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tINHTRANG_SACHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTACGIA_SACH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTACGIA)).BeginInit();
            this.contextMenuStripTACGIA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTACGIA_SACH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHOMUON_SACHBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKCTPHIEUMUONSACHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mATLLabel
            // 
            mATLLabel.AutoSize = true;
            mATLLabel.Location = new System.Drawing.Point(363, 110);
            mATLLabel.Name = "mATLLabel";
            mATLLabel.Size = new System.Drawing.Size(80, 19);
            mATLLabel.TabIndex = 51;
            mATLLabel.Text = "Mã thể loại:";
            // 
            // mANGONNGULabel
            // 
            mANGONNGULabel.AutoSize = true;
            mANGONNGULabel.Location = new System.Drawing.Point(353, 77);
            mANGONNGULabel.Name = "mANGONNGULabel";
            mANGONNGULabel.Size = new System.Drawing.Size(93, 19);
            mANGONNGULabel.TabIndex = 49;
            mANGONNGULabel.Text = "Mã ngôn ngữ:";
            // 
            // nHAXBLabel
            // 
            nHAXBLabel.AutoSize = true;
            nHAXBLabel.Location = new System.Drawing.Point(440, 6);
            nHAXBLabel.Name = "nHAXBLabel";
            nHAXBLabel.Size = new System.Drawing.Size(93, 19);
            nHAXBLabel.TabIndex = 43;
            nHAXBLabel.Text = "Nhà xuất bản:";
            // 
            // gIALabel
            // 
            gIALabel.AutoSize = true;
            gIALabel.Location = new System.Drawing.Point(70, 141);
            gIALabel.Name = "gIALabel";
            gIALabel.Size = new System.Drawing.Size(33, 19);
            gIALabel.TabIndex = 41;
            gIALabel.Text = "Giá:";
            // 
            // sOTRANGLabel
            // 
            sOTRANGLabel.AutoSize = true;
            sOTRANGLabel.Location = new System.Drawing.Point(647, 78);
            sOTRANGLabel.Name = "sOTRANGLabel";
            sOTRANGLabel.Size = new System.Drawing.Size(63, 19);
            sOTRANGLabel.TabIndex = 39;
            sOTRANGLabel.Text = "Số trang:";
            // 
            // lANXUATBANLabel
            // 
            lANXUATBANLabel.AutoSize = true;
            lANXUATBANLabel.Location = new System.Drawing.Point(620, 39);
            lANXUATBANLabel.Name = "lANXUATBANLabel";
            lANXUATBANLabel.Size = new System.Drawing.Size(90, 19);
            lANXUATBANLabel.TabIndex = 37;
            lANXUATBANLabel.Text = "Lần xuất bản:";
            // 
            // nGAYXUATBANLabel
            // 
            nGAYXUATBANLabel.AutoSize = true;
            nGAYXUATBANLabel.Location = new System.Drawing.Point(343, 38);
            nGAYXUATBANLabel.Name = "nGAYXUATBANLabel";
            nGAYXUATBANLabel.Size = new System.Drawing.Size(100, 19);
            nGAYXUATBANLabel.TabIndex = 35;
            nGAYXUATBANLabel.Text = "Ngày xuất bản:";
            // 
            // hINHANHPATHLabel
            // 
            hINHANHPATHLabel.AutoSize = true;
            hINHANHPATHLabel.Location = new System.Drawing.Point(348, 145);
            hINHANHPATHLabel.Name = "hINHANHPATHLabel";
            hINHANHPATHLabel.Size = new System.Drawing.Size(95, 19);
            hINHANHPATHLabel.TabIndex = 34;
            hINHANHPATHLabel.Text = "Hình ảnh path:";
            // 
            // nOIDUNGLabel
            // 
            nOIDUNGLabel.AutoSize = true;
            nOIDUNGLabel.Location = new System.Drawing.Point(35, 168);
            nOIDUNGLabel.Name = "nOIDUNGLabel";
            nOIDUNGLabel.Size = new System.Drawing.Size(68, 19);
            nOIDUNGLabel.TabIndex = 32;
            nOIDUNGLabel.Text = "Nội dung:";
            // 
            // kHOSACHLabel
            // 
            kHOSACHLabel.AutoSize = true;
            kHOSACHLabel.Location = new System.Drawing.Point(647, 111);
            kHOSACHLabel.Name = "kHOSACHLabel";
            kHOSACHLabel.Size = new System.Drawing.Size(70, 19);
            kHOSACHLabel.TabIndex = 30;
            kHOSACHLabel.Text = "Khổ sách:";
            // 
            // tENSACHLabel
            // 
            tENSACHLabel.AutoSize = true;
            tENSACHLabel.Location = new System.Drawing.Point(37, 6);
            tENSACHLabel.Name = "tENSACHLabel";
            tENSACHLabel.Size = new System.Drawing.Size(66, 19);
            tENSACHLabel.TabIndex = 28;
            tENSACHLabel.Text = "Tên sách:";
            // 
            // iSBNLabel
            // 
            iSBNLabel.AutoSize = true;
            iSBNLabel.Location = new System.Drawing.Point(55, 38);
            iSBNLabel.Name = "iSBNLabel";
            iSBNLabel.Size = new System.Drawing.Size(48, 19);
            iSBNLabel.TabIndex = 55;
            iSBNLabel.Text = "ISBN:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barDauSach,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnTHEM,
            this.btnSUA,
            this.btnGHI,
            this.btnXOA,
            this.btnUNDO,
            this.btnREFRESH,
            this.btnREDO,
            this.btnTHOAT,
            this.barButtonItem9,
            this.btnTACGIA_SACH,
            this.btnTG_SACH});
            this.barManager1.MainMenu = this.barDauSach;
            this.barManager1.MaxItemId = 12;
            this.barManager1.StatusBar = this.bar3;
            // 
            // barDauSach
            // 
            this.barDauSach.BarName = "Main menu";
            this.barDauSach.DockCol = 0;
            this.barDauSach.DockRow = 0;
            this.barDauSach.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barDauSach.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTHEM, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnGHI, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXOA, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUNDO, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnREDO, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnREFRESH, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTHOAT, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTG_SACH, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barDauSach.OptionsBar.MultiLine = true;
            this.barDauSach.OptionsBar.UseWholeRow = true;
            this.barDauSach.Text = "Main menu";
            // 
            // btnTHEM
            // 
            this.btnTHEM.Caption = "Thêm";
            this.btnTHEM.Id = 0;
            this.btnTHEM.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTHEM.ImageOptions.SvgImage")));
            this.btnTHEM.Name = "btnTHEM";
            this.btnTHEM.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTHEM_ItemClick);
            // 
            // btnGHI
            // 
            this.btnGHI.Caption = "Ghi";
            this.btnGHI.Id = 2;
            this.btnGHI.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGHI.ImageOptions.SvgImage")));
            this.btnGHI.Name = "btnGHI";
            this.btnGHI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGHI_ItemClick);
            // 
            // btnXOA
            // 
            this.btnXOA.Caption = "Xóa";
            this.btnXOA.Id = 3;
            this.btnXOA.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnXOA.ImageOptions.SvgImage")));
            this.btnXOA.ImageOptions.SvgImageSize = new System.Drawing.Size(17, 17);
            this.btnXOA.Name = "btnXOA";
            this.btnXOA.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXOA_ItemClick);
            // 
            // btnUNDO
            // 
            this.btnUNDO.Caption = "Phục hồi";
            this.btnUNDO.Id = 4;
            this.btnUNDO.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUNDO.ImageOptions.SvgImage")));
            this.btnUNDO.Name = "btnUNDO";
            this.btnUNDO.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUNDO_ItemClick);
            // 
            // btnREDO
            // 
            this.btnREDO.Caption = "Redo";
            this.btnREDO.Id = 6;
            this.btnREDO.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnREDO.ImageOptions.SvgImage")));
            this.btnREDO.Name = "btnREDO";
            this.btnREDO.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnREDO_ItemClick);
            // 
            // btnREFRESH
            // 
            this.btnREFRESH.Caption = "Refresh";
            this.btnREFRESH.Id = 5;
            this.btnREFRESH.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnREFRESH.ImageOptions.SvgImage")));
            this.btnREFRESH.Name = "btnREFRESH";
            this.btnREFRESH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnREFRESH_ItemClick);
            // 
            // btnTHOAT
            // 
            this.btnTHOAT.Caption = "Thoát";
            this.btnTHOAT.Id = 7;
            this.btnTHOAT.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTHOAT.ImageOptions.SvgImage")));
            this.btnTHOAT.Name = "btnTHOAT";
            this.btnTHOAT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTHOAT_ItemClick);
            // 
            // btnTG_SACH
            // 
            this.btnTG_SACH.Caption = "Cập nhật tác giả";
            this.btnTG_SACH.Id = 11;
            this.btnTG_SACH.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTG_SACH.ImageOptions.SvgImage")));
            this.btnTG_SACH.Name = "btnTG_SACH";
            this.btnTG_SACH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTG_SACH_ItemClick);
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlTop.Size = new System.Drawing.Size(1580, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 760);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlBottom.Size = new System.Drawing.Size(1580, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 719);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1580, 41);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 719);
            // 
            // btnSUA
            // 
            this.btnSUA.Caption = "Sửa";
            this.btnSUA.Id = 1;
            this.btnSUA.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSUA.ImageOptions.SvgImage")));
            this.btnSUA.Name = "btnSUA";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "barButtonItem9";
            this.barButtonItem9.Id = 8;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // btnTACGIA_SACH
            // 
            this.btnTACGIA_SACH.Id = 10;
            this.btnTACGIA_SACH.Name = "btnTACGIA_SACH";
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsDAUSACH
            // 
            this.bdsDAUSACH.DataMember = "DAUSACH";
            this.bdsDAUSACH.DataSource = this.qLTVDataSet;
            // 
            // tableAdapterDAUSACH
            // 
            this.tableAdapterDAUSACH.ClearBeforeFill = true;
            // 
            // gcDAUSACH
            // 
            this.gcDAUSACH.DataSource = this.bdsDAUSACH;
            this.gcDAUSACH.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcDAUSACH.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(15, 13, 15, 13);
            this.gcDAUSACH.Location = new System.Drawing.Point(0, 41);
            this.gcDAUSACH.MainView = this.gridViewDAUSACH;
            this.gcDAUSACH.Margin = new System.Windows.Forms.Padding(9);
            this.gcDAUSACH.MenuManager = this.barManager1;
            this.gcDAUSACH.Name = "gcDAUSACH";
            this.gcDAUSACH.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemGridLookUpEdit2});
            this.gcDAUSACH.Size = new System.Drawing.Size(1580, 412);
            this.gcDAUSACH.TabIndex = 12;
            this.gcDAUSACH.ToolTipController = this.toolTipController1;
            this.gcDAUSACH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDAUSACH});
            // 
            // gridViewDAUSACH
            // 
            this.gridViewDAUSACH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colISBN,
            this.colTENSACH,
            this.colKHOSACH,
            this.colNOIDUNG,
            this.colNGAYXUATBAN,
            this.colLANXUATBAN,
            this.colSOTRANG,
            this.colGIA,
            this.colNHAXB,
            this.colMANGONNGU,
            this.colMATL});
            this.gridViewDAUSACH.DetailHeight = 1180;
            this.gridViewDAUSACH.GridControl = this.gcDAUSACH;
            this.gridViewDAUSACH.Name = "gridViewDAUSACH";
            this.gridViewDAUSACH.OptionsBehavior.Editable = false;
            this.gridViewDAUSACH.OptionsDetail.EnableMasterViewMode = false;
            this.gridViewDAUSACH.OptionsEditForm.PopupEditFormWidth = 2700;
            this.gridViewDAUSACH.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewDAUSACH_RowStyle);
            this.gridViewDAUSACH.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDAUSACH_FocusedRowChanged);
            // 
            // colISBN
            // 
            this.colISBN.Caption = "ISBN";
            this.colISBN.FieldName = "ISBN";
            this.colISBN.MinWidth = 97;
            this.colISBN.Name = "colISBN";
            this.colISBN.OptionsEditForm.Caption = "IBSN";
            this.colISBN.Visible = true;
            this.colISBN.VisibleIndex = 0;
            this.colISBN.Width = 129;
            // 
            // colTENSACH
            // 
            this.colTENSACH.Caption = "Tên sách";
            this.colTENSACH.FieldName = "TENSACH";
            this.colTENSACH.MinWidth = 97;
            this.colTENSACH.Name = "colTENSACH";
            this.colTENSACH.Visible = true;
            this.colTENSACH.VisibleIndex = 1;
            this.colTENSACH.Width = 228;
            // 
            // colKHOSACH
            // 
            this.colKHOSACH.Caption = "Khổ sách";
            this.colKHOSACH.FieldName = "KHOSACH";
            this.colKHOSACH.MinWidth = 80;
            this.colKHOSACH.Name = "colKHOSACH";
            this.colKHOSACH.Visible = true;
            this.colKHOSACH.VisibleIndex = 2;
            this.colKHOSACH.Width = 80;
            // 
            // colNOIDUNG
            // 
            this.colNOIDUNG.Caption = "Nội dung";
            this.colNOIDUNG.FieldName = "NOIDUNG";
            this.colNOIDUNG.MinWidth = 97;
            this.colNOIDUNG.Name = "colNOIDUNG";
            this.colNOIDUNG.Visible = true;
            this.colNOIDUNG.VisibleIndex = 3;
            this.colNOIDUNG.Width = 318;
            // 
            // colNGAYXUATBAN
            // 
            this.colNGAYXUATBAN.Caption = "Ngày xuất bản";
            this.colNGAYXUATBAN.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNGAYXUATBAN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAYXUATBAN.FieldName = "NGAYXUATBAN";
            this.colNGAYXUATBAN.MinWidth = 97;
            this.colNGAYXUATBAN.Name = "colNGAYXUATBAN";
            this.colNGAYXUATBAN.Visible = true;
            this.colNGAYXUATBAN.VisibleIndex = 4;
            this.colNGAYXUATBAN.Width = 113;
            // 
            // colLANXUATBAN
            // 
            this.colLANXUATBAN.Caption = "Lần xuất bản";
            this.colLANXUATBAN.FieldName = "LANXUATBAN";
            this.colLANXUATBAN.MinWidth = 50;
            this.colLANXUATBAN.Name = "colLANXUATBAN";
            this.colLANXUATBAN.Visible = true;
            this.colLANXUATBAN.VisibleIndex = 5;
            this.colLANXUATBAN.Width = 90;
            // 
            // colSOTRANG
            // 
            this.colSOTRANG.Caption = "Số trang";
            this.colSOTRANG.FieldName = "SOTRANG";
            this.colSOTRANG.MinWidth = 50;
            this.colSOTRANG.Name = "colSOTRANG";
            this.colSOTRANG.Visible = true;
            this.colSOTRANG.VisibleIndex = 6;
            this.colSOTRANG.Width = 72;
            // 
            // colGIA
            // 
            this.colGIA.Caption = "Giá";
            this.colGIA.DisplayFormat.FormatString = "c";
            this.colGIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGIA.FieldName = "GIA";
            this.colGIA.MinWidth = 97;
            this.colGIA.Name = "colGIA";
            this.colGIA.Visible = true;
            this.colGIA.VisibleIndex = 7;
            this.colGIA.Width = 134;
            // 
            // colNHAXB
            // 
            this.colNHAXB.Caption = "Nhà xuất bản";
            this.colNHAXB.FieldName = "NHAXB";
            this.colNHAXB.MinWidth = 97;
            this.colNHAXB.Name = "colNHAXB";
            this.colNHAXB.Visible = true;
            this.colNHAXB.VisibleIndex = 8;
            this.colNHAXB.Width = 126;
            // 
            // colMANGONNGU
            // 
            this.colMANGONNGU.Caption = "Ngôn ngữ";
            this.colMANGONNGU.ColumnEdit = this.repositoryItemGridLookUpEdit1;
            this.colMANGONNGU.FieldName = "MANGONNGU";
            this.colMANGONNGU.MinWidth = 97;
            this.colMANGONNGU.Name = "colMANGONNGU";
            this.colMANGONNGU.Visible = true;
            this.colMANGONNGU.VisibleIndex = 9;
            this.colMANGONNGU.Width = 97;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.DataSource = this.bdsDSNgonNgu;
            this.repositoryItemGridLookUpEdit1.DisplayMember = "TENNGONNGU";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repositoryItemGridLookUpEdit1.ValueMember = "MANGONNGU";
            // 
            // bdsDSNgonNgu
            // 
            this.bdsDSNgonNgu.DataMember = "DSNGONNGU";
            this.bdsDSNgonNgu.DataSource = this.qLTVDataSet;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colMATL
            // 
            this.colMATL.Caption = "Thể loại";
            this.colMATL.ColumnEdit = this.repositoryItemGridLookUpEdit2;
            this.colMATL.FieldName = "MATL";
            this.colMATL.MinWidth = 97;
            this.colMATL.Name = "colMATL";
            this.colMATL.Visible = true;
            this.colMATL.VisibleIndex = 10;
            this.colMATL.Width = 170;
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.AutoHeight = false;
            this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit2.DataSource = this.bdsDSTheLoai;
            this.repositoryItemGridLookUpEdit2.DisplayMember = "TENTHELOAI";
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.PopupView = this.repositoryItemGridLookUpEdit2View;
            this.repositoryItemGridLookUpEdit2.ValueMember = "MATL";
            // 
            // bdsDSTheLoai
            // 
            this.bdsDSTheLoai.DataMember = "DSTHELOAI";
            this.bdsDSTheLoai.DataSource = this.qLTVDataSet;
            // 
            // repositoryItemGridLookUpEdit2View
            // 
            this.repositoryItemGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit2View.Name = "repositoryItemGridLookUpEdit2View";
            this.repositoryItemGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // toolTipController1
            // 
            this.toolTipController1.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
            // 
            // tamDauSach
            // 
            this.tamDauSach.BackupDataSetBeforeUpdate = false;
            this.tamDauSach.CHITIETNGANTUTableAdapter = null;
            this.tamDauSach.CT_PHIEUMUONTableAdapter = null;
            this.tamDauSach.DAUSACHTableAdapter = this.tableAdapterDAUSACH;
            this.tamDauSach.DOCGIATableAdapter = null;
            this.tamDauSach.NGANTUTableAdapter = null;
            this.tamDauSach.NGONNGUTableAdapter = null;
            this.tamDauSach.NHANVIENTableAdapter = null;
            this.tamDauSach.PHIEUMUONTableAdapter = null;
            this.tamDauSach.SACHTableAdapter = null;
            this.tamDauSach.sp_DanhSachBackupTableAdapter = null;
            this.tamDauSach.TACGIA_SACHTableAdapter = null;
            this.tamDauSach.TACGIATableAdapter = null;
            this.tamDauSach.THELOAITableAdapter = null;
            this.tamDauSach.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gcThongTinDauSach
            // 
            this.gcThongTinDauSach.Controls.Add(this.pncINPUT);
            this.gcThongTinDauSach.Controls.Add(this.picDauSach);
            this.gcThongTinDauSach.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcThongTinDauSach.Location = new System.Drawing.Point(0, 453);
            this.gcThongTinDauSach.Name = "gcThongTinDauSach";
            this.gcThongTinDauSach.Size = new System.Drawing.Size(1064, 307);
            this.gcThongTinDauSach.TabIndex = 17;
            this.gcThongTinDauSach.Text = "THÔNG TIN ĐẦU SÁCH";
            // 
            // pncINPUT
            // 
            this.pncINPUT.Controls.Add(this.cbKHOSACH);
            this.pncINPUT.Controls.Add(iSBNLabel);
            this.pncINPUT.Controls.Add(this.txtISBN);
            this.pncINPUT.Controls.Add(this.txtNOIDUNG);
            this.pncINPUT.Controls.Add(this.txtHinhAnh);
            this.pncINPUT.Controls.Add(mATLLabel);
            this.pncINPUT.Controls.Add(this.txtMaTheLoai);
            this.pncINPUT.Controls.Add(mANGONNGULabel);
            this.pncINPUT.Controls.Add(this.txtMaNgonNgu);
            this.pncINPUT.Controls.Add(this.labelControl2);
            this.pncINPUT.Controls.Add(this.cbTheLoai);
            this.pncINPUT.Controls.Add(this.labelControl1);
            this.pncINPUT.Controls.Add(this.cbNgonNgu);
            this.pncINPUT.Controls.Add(nHAXBLabel);
            this.pncINPUT.Controls.Add(this.txtNHAXB);
            this.pncINPUT.Controls.Add(gIALabel);
            this.pncINPUT.Controls.Add(this.speGIA);
            this.pncINPUT.Controls.Add(sOTRANGLabel);
            this.pncINPUT.Controls.Add(this.speSOTRANG);
            this.pncINPUT.Controls.Add(lANXUATBANLabel);
            this.pncINPUT.Controls.Add(this.speLANXB);
            this.pncINPUT.Controls.Add(nGAYXUATBANLabel);
            this.pncINPUT.Controls.Add(this.dteNGAYXB);
            this.pncINPUT.Controls.Add(hINHANHPATHLabel);
            this.pncINPUT.Controls.Add(nOIDUNGLabel);
            this.pncINPUT.Controls.Add(kHOSACHLabel);
            this.pncINPUT.Controls.Add(tENSACHLabel);
            this.pncINPUT.Controls.Add(this.txtTENSACH);
            this.pncINPUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pncINPUT.Location = new System.Drawing.Point(241, 32);
            this.pncINPUT.Name = "pncINPUT";
            this.pncINPUT.Size = new System.Drawing.Size(821, 273);
            this.pncINPUT.TabIndex = 1;
            // 
            // cbKHOSACH
            // 
            this.cbKHOSACH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDAUSACH, "KHOSACH", true));
            this.cbKHOSACH.FormattingEnabled = true;
            this.cbKHOSACH.Items.AddRange(new object[] {
            "A6",
            "A5",
            "B5",
            "A4",
            "13x19 cm",
            "14.5x20.5 cm",
            "15.5x24 cm",
            "16x24 cm",
            "17x24 cm",
            "19x27 cm",
            "20x28 cm",
            "20.5x29.5 cm",
            "25x25 cm",
            "30x30 cm"});
            this.cbKHOSACH.Location = new System.Drawing.Point(716, 107);
            this.cbKHOSACH.Name = "cbKHOSACH";
            this.cbKHOSACH.Size = new System.Drawing.Size(100, 27);
            this.cbKHOSACH.TabIndex = 57;
            // 
            // txtISBN
            // 
            this.txtISBN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDAUSACH, "ISBN", true));
            this.txtISBN.Enabled = false;
            this.txtISBN.Location = new System.Drawing.Point(109, 36);
            this.txtISBN.MenuManager = this.barManager1;
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(231, 27);
            this.txtISBN.TabIndex = 56;
            this.txtISBN.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            // 
            // txtNOIDUNG
            // 
            this.txtNOIDUNG.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsDAUSACH, "NOIDUNG", true));
            this.txtNOIDUNG.Location = new System.Drawing.Point(109, 174);
            this.txtNOIDUNG.Multiline = true;
            this.txtNOIDUNG.Name = "txtNOIDUNG";
            this.txtNOIDUNG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNOIDUNG.Size = new System.Drawing.Size(707, 94);
            this.txtNOIDUNG.TabIndex = 55;
            this.txtNOIDUNG.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDAUSACH, "HINHANHPATH", true));
            this.txtHinhAnh.Location = new System.Drawing.Point(449, 141);
            this.txtHinhAnh.MenuManager = this.barManager1;
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtHinhAnh.Size = new System.Drawing.Size(367, 27);
            this.txtHinhAnh.TabIndex = 54;
            this.txtHinhAnh.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            this.txtHinhAnh.Click += new System.EventHandler(this.txtHinhAnh_Click);
            // 
            // txtMaTheLoai
            // 
            this.txtMaTheLoai.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDAUSACH, "MATL", true));
            this.txtMaTheLoai.Enabled = false;
            this.txtMaTheLoai.Location = new System.Drawing.Point(449, 108);
            this.txtMaTheLoai.MenuManager = this.barManager1;
            this.txtMaTheLoai.Name = "txtMaTheLoai";
            this.txtMaTheLoai.Size = new System.Drawing.Size(166, 27);
            this.txtMaTheLoai.TabIndex = 52;
            // 
            // txtMaNgonNgu
            // 
            this.txtMaNgonNgu.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDAUSACH, "MANGONNGU", true));
            this.txtMaNgonNgu.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMaNgonNgu.Enabled = false;
            this.txtMaNgonNgu.Location = new System.Drawing.Point(449, 72);
            this.txtMaNgonNgu.MenuManager = this.barManager1;
            this.txtMaNgonNgu.Name = "txtMaNgonNgu";
            this.txtMaNgonNgu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMaNgonNgu.Size = new System.Drawing.Size(166, 30);
            this.txtMaNgonNgu.TabIndex = 50;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(52, 111);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 19);
            this.labelControl2.TabIndex = 48;
            this.labelControl2.Text = "Thể loại:";
            // 
            // cbTheLoai
            // 
            this.cbTheLoai.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsDAUSACH, "MATL", true));
            this.cbTheLoai.DataSource = this.bdsDSTheLoai;
            this.cbTheLoai.DisplayMember = "TENTHELOAI";
            this.cbTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTheLoai.FormattingEnabled = true;
            this.cbTheLoai.Location = new System.Drawing.Point(109, 108);
            this.cbTheLoai.Name = "cbTheLoai";
            this.cbTheLoai.Size = new System.Drawing.Size(231, 27);
            this.cbTheLoai.TabIndex = 46;
            this.cbTheLoai.ValueMember = "MATL";
            this.cbTheLoai.SelectedIndexChanged += new System.EventHandler(this.cbTheLoai_SelectedIndexChanged);
            this.cbTheLoai.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(42, 78);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 19);
            this.labelControl1.TabIndex = 47;
            this.labelControl1.Text = "Ngôn ngữ";
            // 
            // cbNgonNgu
            // 
            this.cbNgonNgu.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bdsDAUSACH, "MANGONNGU", true));
            this.cbNgonNgu.DataSource = this.bdsDSNgonNgu;
            this.cbNgonNgu.DisplayMember = "TENNGONNGU";
            this.cbNgonNgu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNgonNgu.FormattingEnabled = true;
            this.cbNgonNgu.Location = new System.Drawing.Point(109, 75);
            this.cbNgonNgu.Name = "cbNgonNgu";
            this.cbNgonNgu.Size = new System.Drawing.Size(231, 27);
            this.cbNgonNgu.TabIndex = 45;
            this.cbNgonNgu.ValueMember = "MANGONNGU";
            this.cbNgonNgu.SelectedIndexChanged += new System.EventHandler(this.cbNgonNgu_SelectedIndexChanged);
            this.cbNgonNgu.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            // 
            // txtNHAXB
            // 
            this.txtNHAXB.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDAUSACH, "NHAXB", true));
            this.txtNHAXB.Location = new System.Drawing.Point(539, 3);
            this.txtNHAXB.MenuManager = this.barManager1;
            this.txtNHAXB.Name = "txtNHAXB";
            this.txtNHAXB.Size = new System.Drawing.Size(277, 27);
            this.txtNHAXB.TabIndex = 44;
            this.txtNHAXB.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            // 
            // speGIA
            // 
            this.speGIA.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDAUSACH, "GIA", true));
            this.speGIA.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speGIA.Location = new System.Drawing.Point(109, 138);
            this.speGIA.MenuManager = this.barManager1;
            this.speGIA.Name = "speGIA";
            this.speGIA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speGIA.Properties.DisplayFormat.FormatString = "c";
            this.speGIA.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.speGIA.Properties.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speGIA.Properties.MaskSettings.Set("mask", "c");
            this.speGIA.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.speGIA.Properties.UseMaskAsDisplayFormat = true;
            this.speGIA.Size = new System.Drawing.Size(231, 30);
            this.speGIA.TabIndex = 42;
            this.speGIA.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            // 
            // speSOTRANG
            // 
            this.speSOTRANG.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDAUSACH, "SOTRANG", true));
            this.speSOTRANG.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speSOTRANG.Location = new System.Drawing.Point(716, 73);
            this.speSOTRANG.MenuManager = this.barManager1;
            this.speSOTRANG.Name = "speSOTRANG";
            this.speSOTRANG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speSOTRANG.Properties.IsFloatValue = false;
            this.speSOTRANG.Properties.MaskSettings.Set("mask", "d");
            this.speSOTRANG.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.speSOTRANG.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speSOTRANG.Size = new System.Drawing.Size(100, 30);
            this.speSOTRANG.TabIndex = 40;
            this.speSOTRANG.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            // 
            // speLANXB
            // 
            this.speLANXB.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDAUSACH, "LANXUATBAN", true));
            this.speLANXB.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speLANXB.Location = new System.Drawing.Point(716, 33);
            this.speLANXB.MenuManager = this.barManager1;
            this.speLANXB.Name = "speLANXB";
            this.speLANXB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speLANXB.Properties.IsFloatValue = false;
            this.speLANXB.Properties.MaskSettings.Set("mask", "N00");
            this.speLANXB.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speLANXB.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.speLANXB.Size = new System.Drawing.Size(100, 30);
            this.speLANXB.TabIndex = 38;
            this.speLANXB.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            // 
            // dteNGAYXB
            // 
            this.dteNGAYXB.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDAUSACH, "NGAYXUATBAN", true));
            this.dteNGAYXB.EditValue = null;
            this.dteNGAYXB.Location = new System.Drawing.Point(449, 36);
            this.dteNGAYXB.MenuManager = this.barManager1;
            this.dteNGAYXB.Name = "dteNGAYXB";
            this.dteNGAYXB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNGAYXB.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteNGAYXB.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dteNGAYXB.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteNGAYXB.Properties.CalendarTimeProperties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dteNGAYXB.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteNGAYXB.Properties.CalendarTimeProperties.TouchUIMaxValue = new System.DateTime(((long)(0)));
            this.dteNGAYXB.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dteNGAYXB.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteNGAYXB.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dteNGAYXB.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteNGAYXB.Size = new System.Drawing.Size(166, 27);
            this.dteNGAYXB.TabIndex = 36;
            this.dteNGAYXB.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            // 
            // txtTENSACH
            // 
            this.txtTENSACH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsDAUSACH, "TENSACH", true));
            this.txtTENSACH.Location = new System.Drawing.Point(109, 3);
            this.txtTENSACH.MenuManager = this.barManager1;
            this.txtTENSACH.Name = "txtTENSACH";
            this.txtTENSACH.Size = new System.Drawing.Size(304, 27);
            this.txtTENSACH.TabIndex = 29;
            this.txtTENSACH.TextChanged += new System.EventHandler(this.AnyTextBox_TextChanged);
            // 
            // picDauSach
            // 
            this.picDauSach.Dock = System.Windows.Forms.DockStyle.Left;
            this.picDauSach.Location = new System.Drawing.Point(2, 32);
            this.picDauSach.MenuManager = this.barManager1;
            this.picDauSach.Name = "picDauSach";
            this.picDauSach.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picDauSach.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picDauSach.Size = new System.Drawing.Size(239, 273);
            this.picDauSach.TabIndex = 0;
            // 
            // bdsSACH
            // 
            this.bdsSACH.DataMember = "FK_SACH_DAUSACH";
            this.bdsSACH.DataSource = this.bdsDAUSACH;
            this.bdsSACH.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bdsSACH_ListChanged);
            // 
            // tableAdapterSACH
            // 
            this.tableAdapterSACH.ClearBeforeFill = true;
            // 
            // bdsChiTietNganTu
            // 
            this.bdsChiTietNganTu.DataMember = "CHITIETNGANTU";
            this.bdsChiTietNganTu.DataSource = this.qLTVDataSet;
            // 
            // contextMenuStripSACH
            // 
            this.contextMenuStripSACH.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripSACH.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThemSach,
            this.toolStripSeparator3,
            this.btnGhiSach,
            this.toolStripSeparator2,
            this.btnXoaSach});
            this.contextMenuStripSACH.Name = "contextMenuStrip1";
            this.contextMenuStripSACH.Size = new System.Drawing.Size(169, 112);
            // 
            // btnThemSach
            // 
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(168, 32);
            this.btnThemSach.Text = "Thêm sách";
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // btnGhiSach
            // 
            this.btnGhiSach.Name = "btnGhiSach";
            this.btnGhiSach.Size = new System.Drawing.Size(168, 32);
            this.btnGhiSach.Text = "Ghi sách";
            this.btnGhiSach.Click += new System.EventHandler(this.btnGhiSach_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(168, 32);
            this.btnXoaSach.Text = "Xóa sách";
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // tableAdapterNGONNGU
            // 
            this.tableAdapterNGONNGU.ClearBeforeFill = true;
            // 
            // tableAdapterTHELOAI
            // 
            this.tableAdapterTHELOAI.ClearBeforeFill = true;
            // 
            // tableAdapterCTNGANTU
            // 
            this.tableAdapterCTNGANTU.ClearBeforeFill = true;
            // 
            // gcTABLESACH
            // 
            this.gcTABLESACH.Controls.Add(this.gvSACH);
            this.gcTABLESACH.Controls.Add(this.gvTACGIA_SACH);
            this.gcTABLESACH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTABLESACH.Location = new System.Drawing.Point(1064, 453);
            this.gcTABLESACH.Name = "gcTABLESACH";
            this.gcTABLESACH.Size = new System.Drawing.Size(516, 307);
            this.gcTABLESACH.TabIndex = 22;
            this.gcTABLESACH.Text = "QUẢN LÍ SÁCH";
            // 
            // gvSACH
            // 
            this.gvSACH.AllowUserToAddRows = false;
            this.gvSACH.AllowUserToDeleteRows = false;
            this.gvSACH.AutoGenerateColumns = false;
            this.gvSACH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSACH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MASACH,
            this.ISBN,
            this.TINHTRANG,
            this.CHOMUON,
            this.NGANTU});
            this.gvSACH.ContextMenuStrip = this.contextMenuStripSACH;
            this.gvSACH.DataSource = this.bdsSACH;
            this.gvSACH.Location = new System.Drawing.Point(20, 38);
            this.gvSACH.Name = "gvSACH";
            this.gvSACH.RowHeadersWidth = 62;
            this.gvSACH.RowTemplate.Height = 28;
            this.gvSACH.Size = new System.Drawing.Size(251, 181);
            this.gvSACH.TabIndex = 18;
            this.gvSACH.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvSACH_CellFormatting);
            this.gvSACH.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvSACH_CellValidating);
            this.gvSACH.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvSACH_CellValueChanged);
            this.gvSACH.CurrentCellDirtyStateChanged += new System.EventHandler(this.gvSACH_CurrentCellDirtyStateChanged);
            // 
            // tINHTRANG_SACHBindingSource
            // 
            this.tINHTRANG_SACHBindingSource.DataMember = "TINHTRANG_SACH";
            this.tINHTRANG_SACHBindingSource.DataSource = this.qLTVDataSet;
            // 
            // gvTACGIA_SACH
            // 
            this.gvTACGIA_SACH.AllowUserToAddRows = false;
            this.gvTACGIA_SACH.AllowUserToDeleteRows = false;
            this.gvTACGIA_SACH.AutoGenerateColumns = false;
            this.gvTACGIA_SACH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTACGIA_SACH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISBN_TG,
            this.MATACGIA});
            this.gvTACGIA_SACH.ContextMenuStrip = this.contextMenuStripTACGIA;
            this.gvTACGIA_SACH.DataSource = this.bdsTACGIA_SACH;
            this.gvTACGIA_SACH.Location = new System.Drawing.Point(196, 91);
            this.gvTACGIA_SACH.Name = "gvTACGIA_SACH";
            this.gvTACGIA_SACH.RowHeadersWidth = 62;
            this.gvTACGIA_SACH.RowTemplate.Height = 28;
            this.gvTACGIA_SACH.Size = new System.Drawing.Size(300, 220);
            this.gvTACGIA_SACH.TabIndex = 0;
            this.gvTACGIA_SACH.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTACGIA_SACH_CellValueChanged);
            this.gvTACGIA_SACH.CurrentCellDirtyStateChanged += new System.EventHandler(this.gvTACGIA_SACH_CurrentCellDirtyStateChanged);
            this.gvTACGIA_SACH.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvTACGIA_SACH_EditingControlShowing);
            // 
            // ISBN_TG
            // 
            this.ISBN_TG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ISBN_TG.DataPropertyName = "ISBN";
            this.ISBN_TG.HeaderText = "ISBN";
            this.ISBN_TG.MinimumWidth = 8;
            this.ISBN_TG.Name = "ISBN_TG";
            this.ISBN_TG.ReadOnly = true;
            // 
            // MATACGIA
            // 
            this.MATACGIA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MATACGIA.DataPropertyName = "MATACGIA";
            this.MATACGIA.DataSource = this.bdsTACGIA;
            this.MATACGIA.DisplayMember = "HOTENTG";
            this.MATACGIA.HeaderText = "TÁC GIẢ";
            this.MATACGIA.MinimumWidth = 8;
            this.MATACGIA.Name = "MATACGIA";
            this.MATACGIA.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MATACGIA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MATACGIA.ValueMember = "MATACGIA";
            // 
            // bdsTACGIA
            // 
            this.bdsTACGIA.DataMember = "TACGIA";
            this.bdsTACGIA.DataSource = this.qLTVDataSet;
            // 
            // contextMenuStripTACGIA
            // 
            this.contextMenuStripTACGIA.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripTACGIA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTHEM_TGS,
            this.toolStripSeparator1,
            this.btnGHI_TGS,
            this.toolStripMenuItem1,
            this.btnXOA_TGS});
            this.contextMenuStripTACGIA.Name = "contextMenuStripTACGIA";
            this.contextMenuStripTACGIA.Size = new System.Drawing.Size(295, 112);
            // 
            // btnTHEM_TGS
            // 
            this.btnTHEM_TGS.Name = "btnTHEM_TGS";
            this.btnTHEM_TGS.Size = new System.Drawing.Size(294, 32);
            this.btnTHEM_TGS.Text = "Thêm tác giả cho đầu sách";
            this.btnTHEM_TGS.Click += new System.EventHandler(this.btnTHEM_TGS_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(291, 6);
            // 
            // btnGHI_TGS
            // 
            this.btnGHI_TGS.Name = "btnGHI_TGS";
            this.btnGHI_TGS.Size = new System.Drawing.Size(294, 32);
            this.btnGHI_TGS.Text = "Ghi xuống DB";
            this.btnGHI_TGS.Click += new System.EventHandler(this.btnGHI_TGS_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(291, 6);
            // 
            // btnXOA_TGS
            // 
            this.btnXOA_TGS.Name = "btnXOA_TGS";
            this.btnXOA_TGS.Size = new System.Drawing.Size(294, 32);
            this.btnXOA_TGS.Text = "Xóa tác giả của đầu sách";
            this.btnXOA_TGS.Click += new System.EventHandler(this.btnXOA_TGS_Click);
            // 
            // bdsTACGIA_SACH
            // 
            this.bdsTACGIA_SACH.DataMember = "FK_TACGIA_SACH_DAUSACH";
            this.bdsTACGIA_SACH.DataSource = this.bdsDAUSACH;
            this.bdsTACGIA_SACH.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bdsTACGIA_SACH_ListChanged);
            // 
            // cHOMUON_SACHBindingSource
            // 
            this.cHOMUON_SACHBindingSource.DataMember = "CHOMUON_SACH";
            this.cHOMUON_SACHBindingSource.DataSource = this.qLTVDataSet;
            // 
            // tableAdapterTACGIA_SACH
            // 
            this.tableAdapterTACGIA_SACH.ClearBeforeFill = true;
            // 
            // cHOMUON_SACHTableAdapter
            // 
            this.cHOMUON_SACHTableAdapter.ClearBeforeFill = true;
            // 
            // tINHTRANG_SACHTableAdapter
            // 
            this.tINHTRANG_SACHTableAdapter.ClearBeforeFill = true;
            // 
            // tACGIATableAdapter
            // 
            this.tACGIATableAdapter.ClearBeforeFill = true;
            // 
            // fKCTPHIEUMUONSACHBindingSource
            // 
            this.fKCTPHIEUMUONSACHBindingSource.DataMember = "FK_CTPHIEUMUON_SACH";
            this.fKCTPHIEUMUONSACHBindingSource.DataSource = this.bdsSACH;
            // 
            // cT_PHIEUMUONTableAdapter
            // 
            this.cT_PHIEUMUONTableAdapter.ClearBeforeFill = true;
            // 
            // MASACH
            // 
            this.MASACH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MASACH.DataPropertyName = "MASACH";
            this.MASACH.FillWeight = 250F;
            this.MASACH.HeaderText = "MÃ SÁCH";
            this.MASACH.MinimumWidth = 50;
            this.MASACH.Name = "MASACH";
            // 
            // ISBN
            // 
            this.ISBN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ISBN.DataPropertyName = "ISBN";
            this.ISBN.FillWeight = 250F;
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.MinimumWidth = 100;
            this.ISBN.Name = "ISBN";
            this.ISBN.ReadOnly = true;
            // 
            // TINHTRANG
            // 
            this.TINHTRANG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TINHTRANG.DataPropertyName = "TINHTRANG";
            this.TINHTRANG.DataSource = this.tINHTRANG_SACHBindingSource;
            this.TINHTRANG.DisplayMember = "TEXT";
            this.TINHTRANG.FillWeight = 150F;
            this.TINHTRANG.HeaderText = "TÌNH TRẠNG";
            this.TINHTRANG.MinimumWidth = 150;
            this.TINHTRANG.Name = "TINHTRANG";
            this.TINHTRANG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TINHTRANG.ValueMember = "VALUE";
            // 
            // CHOMUON
            // 
            this.CHOMUON.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHOMUON.DataPropertyName = "CHOMUON";
            this.CHOMUON.FillWeight = 150F;
            this.CHOMUON.HeaderText = "CHO MƯỢN";
            this.CHOMUON.MinimumWidth = 110;
            this.CHOMUON.Name = "CHOMUON";
            this.CHOMUON.ReadOnly = true;
            this.CHOMUON.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CHOMUON.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NGANTU
            // 
            this.NGANTU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NGANTU.DataPropertyName = "MANGANTU";
            this.NGANTU.DataSource = this.bdsChiTietNganTu;
            this.NGANTU.DisplayMember = "MOTA";
            this.NGANTU.FillWeight = 500F;
            this.NGANTU.HeaderText = "NGĂN TỦ";
            this.NGANTU.MinimumWidth = 220;
            this.NGANTU.Name = "NGANTU";
            this.NGANTU.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NGANTU.ValueMember = "MANGANTU";
            // 
            // FormDauSach
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 784);
            this.Controls.Add(this.gcTABLESACH);
            this.Controls.Add(this.gcThongTinDauSach);
            this.Controls.Add(this.gcDAUSACH);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormDauSach";
            this.Text = "Danh sách Đầu sách";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDauSach_FormClosing);
            this.Load += new System.EventHandler(this.FormDauSach_Load);
            this.Shown += new System.EventHandler(this.FormDauSach_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDAUSACH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDAUSACH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDAUSACH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSNgonNgu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsDSTheLoai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcThongTinDauSach)).EndInit();
            this.gcThongTinDauSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pncINPUT)).EndInit();
            this.pncINPUT.ResumeLayout(false);
            this.pncINPUT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtISBN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHinhAnh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTheLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNgonNgu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNHAXB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speGIA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speSOTRANG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speLANXB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYXB.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteNGAYXB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTENSACH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDauSach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSACH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsChiTietNganTu)).EndInit();
            this.contextMenuStripSACH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcTABLESACH)).EndInit();
            this.gcTABLESACH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSACH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tINHTRANG_SACHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTACGIA_SACH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsTACGIA)).EndInit();
            this.contextMenuStripTACGIA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsTACGIA_SACH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cHOMUON_SACHBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKCTPHIEUMUONSACHBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barDauSach;
        private DevExpress.XtraBars.BarButtonItem btnTHEM;
        private DevExpress.XtraBars.BarButtonItem btnSUA;
        private DevExpress.XtraBars.BarButtonItem btnGHI;
        private DevExpress.XtraBars.BarButtonItem btnXOA;
        private DevExpress.XtraBars.BarButtonItem btnUNDO;
        private DevExpress.XtraBars.BarButtonItem btnREFRESH;
        private DevExpress.XtraBars.BarButtonItem btnREDO;
        private DevExpress.XtraBars.BarButtonItem btnTHOAT;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem9;
        private System.Windows.Forms.BindingSource bdsDAUSACH;
        private QLTVDataSet qLTVDataSet;
        private QLTVDataSetTableAdapters.DAUSACHTableAdapter tableAdapterDAUSACH;
        private DevExpress.XtraGrid.GridControl gcDAUSACH;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDAUSACH;
        private QLTVDataSetTableAdapters.TableAdapterManager tamDauSach;
        private DevExpress.XtraGrid.Columns.GridColumn colISBN;
        private DevExpress.XtraGrid.Columns.GridColumn colTENSACH;
        private DevExpress.XtraGrid.Columns.GridColumn colKHOSACH;
        private DevExpress.XtraGrid.Columns.GridColumn colNOIDUNG;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYXUATBAN;
        private DevExpress.XtraGrid.Columns.GridColumn colLANXUATBAN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOTRANG;
        private DevExpress.XtraGrid.Columns.GridColumn colGIA;
        private DevExpress.XtraGrid.Columns.GridColumn colNHAXB;
        private DevExpress.XtraGrid.Columns.GridColumn colMANGONNGU;
        private DevExpress.XtraGrid.Columns.GridColumn colMATL;
        private DevExpress.XtraEditors.GroupControl gcThongTinDauSach;
        private System.Windows.Forms.BindingSource bdsSACH;
        private QLTVDataSetTableAdapters.SACHTableAdapter tableAdapterSACH;
        private DevExpress.XtraEditors.PictureEdit picDauSach;
        private System.Windows.Forms.BindingSource bdsDSNgonNgu;
        private QLTVDataSetTableAdapters.DSNGONNGUTableAdapter tableAdapterNGONNGU;
        private System.Windows.Forms.BindingSource bdsDSTheLoai;
        private QLTVDataSetTableAdapters.DSTHELOAITableAdapter tableAdapterTHELOAI;
        private System.Windows.Forms.BindingSource bdsChiTietNganTu;
        private QLTVDataSetTableAdapters.CHITIETNGANTUTableAdapter tableAdapterCTNGANTU;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSACH;
        private System.Windows.Forms.ToolStripMenuItem btnThemSach;
        private System.Windows.Forms.ToolStripMenuItem btnXoaSach;
        private System.Windows.Forms.ToolStripMenuItem btnGhiSach;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit2View;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.GroupControl gcTABLESACH;
        private DevExpress.XtraEditors.PanelControl pncINPUT;
        private DevExpress.XtraEditors.ButtonEdit txtHinhAnh;
        private DevExpress.XtraEditors.TextEdit txtMaTheLoai;
        private DevExpress.XtraEditors.SpinEdit txtMaNgonNgu;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cbTheLoai;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox cbNgonNgu;
        private DevExpress.XtraEditors.TextEdit txtNHAXB;
        private DevExpress.XtraEditors.SpinEdit speGIA;
        private DevExpress.XtraEditors.SpinEdit speSOTRANG;
        private DevExpress.XtraEditors.SpinEdit speLANXB;
        private DevExpress.XtraEditors.DateEdit dteNGAYXB;
        private DevExpress.XtraEditors.TextEdit txtTENSACH;
        private System.Windows.Forms.TextBox txtNOIDUNG;
        private DevExpress.XtraBars.BarButtonItem btnTACGIA_SACH;
        private DevExpress.XtraEditors.TextEdit txtISBN;
        private System.Windows.Forms.ComboBox cbKHOSACH;
        private DevExpress.XtraBars.BarButtonItem btnTG_SACH;
        private System.Windows.Forms.BindingSource bdsTACGIA_SACH;
        private QLTVDataSetTableAdapters.TACGIA_SACHTableAdapter tableAdapterTACGIA_SACH;
        private System.Windows.Forms.DataGridView gvTACGIA_SACH;
        private System.Windows.Forms.DataGridView gvSACH;
        private System.Windows.Forms.BindingSource cHOMUON_SACHBindingSource;
        private QLTVDataSetTableAdapters.CHOMUON_SACHTableAdapter cHOMUON_SACHTableAdapter;
        private System.Windows.Forms.BindingSource tINHTRANG_SACHBindingSource;
        private QLTVDataSetTableAdapters.TINHTRANG_SACHTableAdapter tINHTRANG_SACHTableAdapter;
        private System.Windows.Forms.BindingSource bdsTACGIA;
        private QLTVDataSetTableAdapters.TACGIATableAdapter tACGIATableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTACGIA;
        private System.Windows.Forms.ToolStripMenuItem btnTHEM_TGS;
        private System.Windows.Forms.ToolStripMenuItem btnGHI_TGS;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem btnXOA_TGS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN_TG;
        private System.Windows.Forms.DataGridViewComboBoxColumn MATACGIA;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private System.Windows.Forms.BindingSource fKCTPHIEUMUONSACHBindingSource;
        private QLTVDataSetTableAdapters.CT_PHIEUMUONTableAdapter cT_PHIEUMUONTableAdapter;
        private DataGridViewTextBoxColumn MASACH;
        private DataGridViewTextBoxColumn ISBN;
        private DataGridViewComboBoxColumn TINHTRANG;
        private DataGridViewTextBoxColumn CHOMUON;
        private DataGridViewComboBoxColumn NGANTU;
    }
}