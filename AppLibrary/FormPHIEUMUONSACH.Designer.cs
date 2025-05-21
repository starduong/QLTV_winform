using AppLibrary.QLTVDataSetTableAdapters;

namespace AppLibrary
{
    partial class FormPHIEUMUONSACH
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
            System.Windows.Forms.Label mAPHIEULabel;
            System.Windows.Forms.Label mADGLabel;
            System.Windows.Forms.Label hINHTHUCLabel;
            System.Windows.Forms.Label mANVLabel;
            System.Windows.Forms.Label labelSach;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPHIEUMUONSACH));
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.pHIEUMUONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pHIEUMUONTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.PHIEUMUONTableAdapter();
            this.tableAdapterManager = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.pHIEUMUONGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAPHIEU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMADG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHINHTHUC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYMUON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditMaDG = new DevExpress.XtraEditors.LookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barButtonLPMS = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonXPMS = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonHuy = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.comboBoxEditSach = new DevExpress.XtraEditors.LookUpEdit();
            this.pictureEditSach = new DevExpress.XtraEditors.PictureEdit();
            this.buttonLapPhieu = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.hINHTHUCRadioButton = new System.Windows.Forms.RadioButton();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.mAPHIEUTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.mANVTextEdit = new DevExpress.XtraEditors.TextEdit();
            mAPHIEULabel = new System.Windows.Forms.Label();
            mADGLabel = new System.Windows.Forms.Label();
            hINHTHUCLabel = new System.Windows.Forms.Label();
            mANVLabel = new System.Windows.Forms.Label();
            labelSach = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUMUONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUMUONGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMaDG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditSach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAPHIEUTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mANVTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mAPHIEULabel
            // 
            mAPHIEULabel.AutoSize = true;
            mAPHIEULabel.Location = new System.Drawing.Point(648, 20);
            mAPHIEULabel.Name = "mAPHIEULabel";
            mAPHIEULabel.Size = new System.Drawing.Size(62, 16);
            mAPHIEULabel.TabIndex = 0;
            mAPHIEULabel.Text = "Mã phiếu:";
            // 
            // mADGLabel
            // 
            mADGLabel.AutoSize = true;
            mADGLabel.Location = new System.Drawing.Point(637, 182);
            mADGLabel.Name = "mADGLabel";
            mADGLabel.Size = new System.Drawing.Size(73, 16);
            mADGLabel.TabIndex = 2;
            mADGLabel.Text = "Mã độc giả:";
            // 
            // hINHTHUCLabel
            // 
            hINHTHUCLabel.AutoSize = true;
            hINHTHUCLabel.Location = new System.Drawing.Point(643, 232);
            hINHTHUCLabel.Name = "hINHTHUCLabel";
            hINHTHUCLabel.Size = new System.Drawing.Size(67, 16);
            hINHTHUCLabel.TabIndex = 4;
            hINHTHUCLabel.Text = "Hình thức:";
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(570, 77);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(140, 16);
            mANVLabel.TabIndex = 8;
            mANVLabel.Text = "Mã nhân viên lập phiếu:";
            // 
            // labelSach
            // 
            labelSach.AutoSize = true;
            labelSach.Location = new System.Drawing.Point(606, 128);
            labelSach.Name = "labelSach";
            labelSach.Size = new System.Drawing.Size(104, 16);
            labelSach.TabIndex = 13;
            labelSach.Text = "Sách cho mượn :";
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pHIEUMUONBindingSource
            // 
            this.pHIEUMUONBindingSource.DataMember = "PHIEUMUON";
            this.pHIEUMUONBindingSource.DataSource = this.qLTVDataSet;
            // 
            // pHIEUMUONTableAdapter
            // 
            this.pHIEUMUONTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CT_PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.DAUSACHTableAdapter = null;
            this.tableAdapterManager.DOCGIATableAdapter = null;
            this.tableAdapterManager.NGANTUTableAdapter = null;
            this.tableAdapterManager.NGONNGUTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.PHIEUMUONTableAdapter = this.pHIEUMUONTableAdapter;
            this.tableAdapterManager.SACHTableAdapter = null;
            this.tableAdapterManager.TACGIA_SACHTableAdapter = null;
            this.tableAdapterManager.TACGIATableAdapter = null;
            this.tableAdapterManager.THELOAITableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pHIEUMUONGridControl
            // 
            this.pHIEUMUONGridControl.DataSource = this.pHIEUMUONBindingSource;
            this.pHIEUMUONGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHIEUMUONGridControl.Location = new System.Drawing.Point(0, 34);
            this.pHIEUMUONGridControl.MainView = this.gridView1;
            this.pHIEUMUONGridControl.Name = "pHIEUMUONGridControl";
            this.pHIEUMUONGridControl.Size = new System.Drawing.Size(1447, 284);
            this.pHIEUMUONGridControl.TabIndex = 1;
            this.pHIEUMUONGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAPHIEU,
            this.colMADG,
            this.colHINHTHUC,
            this.colNGAYMUON,
            this.colMANV});
            this.gridView1.GridControl = this.pHIEUMUONGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMAPHIEU
            // 
            this.colMAPHIEU.Caption = "Mã Phiếu ";
            this.colMAPHIEU.FieldName = "MAPHIEU";
            this.colMAPHIEU.MinWidth = 25;
            this.colMAPHIEU.Name = "colMAPHIEU";
            this.colMAPHIEU.Visible = true;
            this.colMAPHIEU.VisibleIndex = 0;
            this.colMAPHIEU.Width = 94;
            // 
            // colMADG
            // 
            this.colMADG.Caption = "Mã độc giả";
            this.colMADG.FieldName = "MADG";
            this.colMADG.MinWidth = 25;
            this.colMADG.Name = "colMADG";
            this.colMADG.Visible = true;
            this.colMADG.VisibleIndex = 1;
            this.colMADG.Width = 94;
            // 
            // colHINHTHUC
            // 
            this.colHINHTHUC.Caption = "Mã hình thức";
            this.colHINHTHUC.FieldName = "HINHTHUC";
            this.colHINHTHUC.MinWidth = 25;
            this.colHINHTHUC.Name = "colHINHTHUC";
            this.colHINHTHUC.Visible = true;
            this.colHINHTHUC.VisibleIndex = 2;
            this.colHINHTHUC.Width = 94;
            // 
            // colNGAYMUON
            // 
            this.colNGAYMUON.Caption = "Ngày mượn";
            this.colNGAYMUON.FieldName = "NGAYMUON";
            this.colNGAYMUON.MinWidth = 25;
            this.colNGAYMUON.Name = "colNGAYMUON";
            this.colNGAYMUON.Visible = true;
            this.colNGAYMUON.VisibleIndex = 3;
            this.colNGAYMUON.Width = 94;
            // 
            // colMANV
            // 
            this.colMANV.Caption = "Mã nhân viên";
            this.colMANV.FieldName = "MANV";
            this.colMANV.MinWidth = 25;
            this.colMANV.Name = "colMANV";
            this.colMANV.Visible = true;
            this.colMANV.VisibleIndex = 4;
            this.colMANV.Width = 94;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.mANVTextEdit);
            this.panelControl1.Controls.Add(this.mAPHIEUTextEdit);
            this.panelControl1.Controls.Add(this.comboBoxEditMaDG);
            this.panelControl1.Controls.Add(this.comboBoxEditSach);
            this.panelControl1.Controls.Add(this.pictureEditSach);
            this.panelControl1.Controls.Add(labelSach);
            this.panelControl1.Controls.Add(this.buttonLapPhieu);
            this.panelControl1.Controls.Add(this.radioButton1);
            this.panelControl1.Controls.Add(mANVLabel);
            this.panelControl1.Controls.Add(hINHTHUCLabel);
            this.panelControl1.Controls.Add(this.hINHTHUCRadioButton);
            this.panelControl1.Controls.Add(mADGLabel);
            this.panelControl1.Controls.Add(mAPHIEULabel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 318);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1447, 362);
            this.panelControl1.TabIndex = 2;
            // 
            // comboBoxEditMaDG
            // 
            this.comboBoxEditMaDG.Location = new System.Drawing.Point(749, 179);
            this.comboBoxEditMaDG.MenuManager = this.barManager1;
            this.comboBoxEditMaDG.Name = "comboBoxEditMaDG";
            this.comboBoxEditMaDG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditMaDG.Size = new System.Drawing.Size(523, 23);
            this.comboBoxEditMaDG.TabIndex = 18;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.bar4});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonLPMS,
            this.barButtonXPMS,
            this.barButtonRefresh,
            this.barButtonHuy});
            this.barManager1.MainMenu = this.bar3;
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar4;
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonLPMS),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonXPMS),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonHuy)});
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Main menu";
            // 
            // barButtonLPMS
            // 
            this.barButtonLPMS.Caption = "Lập phiếu mượn sách";
            this.barButtonLPMS.Id = 0;
            this.barButtonLPMS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonLPMS.ImageOptions.SvgImage")));
            this.barButtonLPMS.Name = "barButtonLPMS";
            this.barButtonLPMS.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonLPMS.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonLPMS_ItemClick);
            // 
            // barButtonXPMS
            // 
            this.barButtonXPMS.Caption = "Xóa phiếu mượn sách";
            this.barButtonXPMS.Id = 1;
            this.barButtonXPMS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonXPMS.ImageOptions.SvgImage")));
            this.barButtonXPMS.Name = "barButtonXPMS";
            this.barButtonXPMS.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barButtonRefresh
            // 
            this.barButtonRefresh.Caption = "Refresh";
            this.barButtonRefresh.Id = 2;
            this.barButtonRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonRefresh.ImageOptions.SvgImage")));
            this.barButtonRefresh.Name = "barButtonRefresh";
            this.barButtonRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonRefresh_ItemClick);
            // 
            // barButtonHuy
            // 
            this.barButtonHuy.Caption = "Hủy";
            this.barButtonHuy.Id = 3;
            this.barButtonHuy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonHuy.ImageOptions.SvgImage")));
            this.barButtonHuy.Name = "barButtonHuy";
            this.barButtonHuy.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonHuy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonHuy_ItemClick);
            // 
            // bar4
            // 
            this.bar4.BarName = "Status bar";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DrawDragBorder = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1447, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 680);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1447, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 646);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1447, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 646);
            // 
            // comboBoxEditSach
            // 
            this.comboBoxEditSach.Location = new System.Drawing.Point(749, 125);
            this.comboBoxEditSach.MenuManager = this.barManager1;
            this.comboBoxEditSach.Name = "comboBoxEditSach";
            this.comboBoxEditSach.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSach.Size = new System.Drawing.Size(523, 23);
            this.comboBoxEditSach.TabIndex = 17;
            // 
            // pictureEditSach
            // 
            this.pictureEditSach.Location = new System.Drawing.Point(309, 20);
            this.pictureEditSach.MenuManager = this.barManager1;
            this.pictureEditSach.Name = "pictureEditSach";
            this.pictureEditSach.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEditSach.Size = new System.Drawing.Size(196, 276);
            this.pictureEditSach.TabIndex = 15;
            // 
            // buttonLapPhieu
            // 
            this.buttonLapPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonLapPhieu.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonLapPhieu.Location = new System.Drawing.Point(749, 283);
            this.buttonLapPhieu.Name = "buttonLapPhieu";
            this.buttonLapPhieu.Size = new System.Drawing.Size(523, 51);
            this.buttonLapPhieu.TabIndex = 12;
            this.buttonLapPhieu.Text = "Lập phiếu";
            this.buttonLapPhieu.UseVisualStyleBackColor = false;
            this.buttonLapPhieu.Click += new System.EventHandler(this.buttonLapPhieu_Click_1);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(851, 228);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 20);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tại chỗ";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // hINHTHUCRadioButton
            // 
            this.hINHTHUCRadioButton.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.pHIEUMUONBindingSource, "HINHTHUC", true));
            this.hINHTHUCRadioButton.Location = new System.Drawing.Point(749, 226);
            this.hINHTHUCRadioButton.Name = "hINHTHUCRadioButton";
            this.hINHTHUCRadioButton.Size = new System.Drawing.Size(104, 24);
            this.hINHTHUCRadioButton.TabIndex = 5;
            this.hINHTHUCRadioButton.TabStop = true;
            this.hINHTHUCRadioButton.Text = "Mượn về";
            this.hINHTHUCRadioButton.UseVisualStyleBackColor = true;
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
            // mAPHIEUTextEdit
            // 
            this.mAPHIEUTextEdit.Location = new System.Drawing.Point(749, 20);
            this.mAPHIEUTextEdit.MenuManager = this.barManager1;
            this.mAPHIEUTextEdit.Name = "mAPHIEUTextEdit";
            this.mAPHIEUTextEdit.Size = new System.Drawing.Size(523, 23);
            this.mAPHIEUTextEdit.TabIndex = 19;
            // 
            // mANVTextEdit
            // 
            this.mANVTextEdit.Location = new System.Drawing.Point(749, 77);
            this.mANVTextEdit.MenuManager = this.barManager1;
            this.mANVTextEdit.Name = "mANVTextEdit";
            this.mANVTextEdit.Size = new System.Drawing.Size(523, 23);
            this.mANVTextEdit.TabIndex = 20;
            // 
            // FormPHIEUMUONSACH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 702);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pHIEUMUONGridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormPHIEUMUONSACH";
            this.Text = "FormPHIEUMUONSACH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUMUONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUMUONGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMaDG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEditSach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAPHIEUTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mANVTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QLTVDataSet qLTVDataSet;
        private System.Windows.Forms.BindingSource pHIEUMUONBindingSource;
        private QLTVDataSetTableAdapters.PHIEUMUONTableAdapter pHIEUMUONTableAdapter;
        private QLTVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private QLTVDataSetTableAdapters.SACHTableAdapter sachTableAdapter;
        private QLTVDataSetTableAdapters.DAUSACHTableAdapter dauSachTableAdapter;
        private QLTVDataSetTableAdapters.CT_PHIEUMUONTableAdapter ctPhieuMuonTableAdapter;
        private QLTVDataSetTableAdapters.DOCGIATableAdapter docGiaTableAdapter;
        private DevExpress.XtraGrid.GridControl pHIEUMUONGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RadioButton hINHTHUCRadioButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAPHIEU;
        private DevExpress.XtraGrid.Columns.GridColumn colMADG;
        private DevExpress.XtraGrid.Columns.GridColumn colHINHTHUC;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYMUON;
        private DevExpress.XtraGrid.Columns.GridColumn colMANV;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem barButtonLPMS;
        private DevExpress.XtraBars.BarButtonItem barButtonXPMS;
        private DevExpress.XtraBars.BarButtonItem barButtonRefresh;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonHuy;
        private System.Windows.Forms.Button buttonLapPhieu;
        private DevExpress.XtraEditors.PictureEdit pictureEditSach;
        private DevExpress.XtraEditors.LookUpEdit comboBoxEditMaDG;
        private DevExpress.XtraEditors.LookUpEdit comboBoxEditSach;
        private DevExpress.XtraEditors.TextEdit mANVTextEdit;
        private DevExpress.XtraEditors.TextEdit mAPHIEUTextEdit;
    }
}