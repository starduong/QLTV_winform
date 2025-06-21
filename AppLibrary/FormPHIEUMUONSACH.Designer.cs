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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.mANVTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barButtonLPMS = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonHuy = new DevExpress.XtraBars.BarButtonItem();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonXPMS = new DevExpress.XtraBars.BarButtonItem();
            this.mAPHIEUTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.comboBoxEditMaDG = new DevExpress.XtraEditors.LookUpEdit();
            this.comboBoxEditSach = new DevExpress.XtraEditors.LookUpEdit();
            this.buttonLapPhieu = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.hINHTHUCRadioButton = new System.Windows.Forms.RadioButton();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qltvDataSet1 = new AppLibrary.QLTVDataSet();
            mAPHIEULabel = new System.Windows.Forms.Label();
            mADGLabel = new System.Windows.Forms.Label();
            hINHTHUCLabel = new System.Windows.Forms.Label();
            mANVLabel = new System.Windows.Forms.Label();
            labelSach = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUMUONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mANVTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAPHIEUTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMaDG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qltvDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // mAPHIEULabel
            // 
            mAPHIEULabel.AutoSize = true;
            mAPHIEULabel.Location = new System.Drawing.Point(29, 95);
            mAPHIEULabel.Name = "mAPHIEULabel";
            mAPHIEULabel.Size = new System.Drawing.Size(62, 16);
            mAPHIEULabel.TabIndex = 0;
            mAPHIEULabel.Text = "Mã phiếu:";
            // 
            // mADGLabel
            // 
            mADGLabel.AutoSize = true;
            mADGLabel.Location = new System.Drawing.Point(29, 258);
            mADGLabel.Name = "mADGLabel";
            mADGLabel.Size = new System.Drawing.Size(54, 16);
            mADGLabel.TabIndex = 2;
            mADGLabel.Text = "Độc giả:";
            // 
            // hINHTHUCLabel
            // 
            hINHTHUCLabel.AutoSize = true;
            hINHTHUCLabel.Location = new System.Drawing.Point(29, 310);
            hINHTHUCLabel.Name = "hINHTHUCLabel";
            hINHTHUCLabel.Size = new System.Drawing.Size(67, 16);
            hINHTHUCLabel.TabIndex = 4;
            hINHTHUCLabel.Text = "Hình thức:";
            // 
            // mANVLabel
            // 
            mANVLabel.AutoSize = true;
            mANVLabel.Location = new System.Drawing.Point(29, 152);
            mANVLabel.Name = "mANVLabel";
            mANVLabel.Size = new System.Drawing.Size(121, 16);
            mANVLabel.TabIndex = 8;
            mANVLabel.Text = "Nhân viên lập phiếu:";
            // 
            // labelSach
            // 
            labelSach.AutoSize = true;
            labelSach.Location = new System.Drawing.Point(29, 205);
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
            this.tableAdapterManager.CHITIETNGANTUTableAdapter = null;
            this.tableAdapterManager.CT_PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.DAUSACHTableAdapter = null;
            this.tableAdapterManager.DOCGIATableAdapter = null;
            this.tableAdapterManager.NGANTUTableAdapter = null;
            this.tableAdapterManager.NGONNGUTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.PHIEUMUONTableAdapter = this.pHIEUMUONTableAdapter;
            this.tableAdapterManager.SACHTableAdapter = null;
            this.tableAdapterManager.sp_DanhSachBackupTableAdapter = null;
            this.tableAdapterManager.TACGIA_SACHTableAdapter = null;
            this.tableAdapterManager.TACGIATableAdapter = null;
            this.tableAdapterManager.THELOAITableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.mANVTextEdit);
            this.panelControl1.Controls.Add(this.mAPHIEUTextEdit);
            this.panelControl1.Controls.Add(this.comboBoxEditMaDG);
            this.panelControl1.Controls.Add(this.comboBoxEditSach);
            this.panelControl1.Controls.Add(labelSach);
            this.panelControl1.Controls.Add(this.buttonLapPhieu);
            this.panelControl1.Controls.Add(this.radioButton1);
            this.panelControl1.Controls.Add(mANVLabel);
            this.panelControl1.Controls.Add(hINHTHUCLabel);
            this.panelControl1.Controls.Add(this.hINHTHUCRadioButton);
            this.panelControl1.Controls.Add(mADGLabel);
            this.panelControl1.Controls.Add(mAPHIEULabel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 34);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(746, 432);
            this.panelControl1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 37);
            this.label1.TabIndex = 21;
            this.label1.Text = "PHIẾU MƯỢN SÁCH";
            // 
            // mANVTextEdit
            // 
            this.mANVTextEdit.Location = new System.Drawing.Point(188, 145);
            this.mANVTextEdit.MenuManager = this.barManager1;
            this.mANVTextEdit.Name = "mANVTextEdit";
            this.mANVTextEdit.Size = new System.Drawing.Size(523, 23);
            this.mANVTextEdit.TabIndex = 20;
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
            this.barDockControlTop.Size = new System.Drawing.Size(1461, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 466);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1461, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 432);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1461, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 432);
            // 
            // barButtonXPMS
            // 
            this.barButtonXPMS.Caption = "Xóa phiếu mượn sách";
            this.barButtonXPMS.Id = 1;
            this.barButtonXPMS.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonXPMS.ImageOptions.SvgImage")));
            this.barButtonXPMS.Name = "barButtonXPMS";
            this.barButtonXPMS.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // mAPHIEUTextEdit
            // 
            this.mAPHIEUTextEdit.Location = new System.Drawing.Point(188, 92);
            this.mAPHIEUTextEdit.MenuManager = this.barManager1;
            this.mAPHIEUTextEdit.Name = "mAPHIEUTextEdit";
            this.mAPHIEUTextEdit.Size = new System.Drawing.Size(523, 23);
            this.mAPHIEUTextEdit.TabIndex = 19;
            // 
            // comboBoxEditMaDG
            // 
            this.comboBoxEditMaDG.Location = new System.Drawing.Point(188, 255);
            this.comboBoxEditMaDG.MenuManager = this.barManager1;
            this.comboBoxEditMaDG.Name = "comboBoxEditMaDG";
            this.comboBoxEditMaDG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditMaDG.Size = new System.Drawing.Size(523, 23);
            this.comboBoxEditMaDG.TabIndex = 18;
            this.comboBoxEditMaDG.EditValueChanged += new System.EventHandler(this.comboBoxEditMaDG_EditValueChanged);
            // 
            // comboBoxEditSach
            // 
            this.comboBoxEditSach.Location = new System.Drawing.Point(188, 198);
            this.comboBoxEditSach.MenuManager = this.barManager1;
            this.comboBoxEditSach.Name = "comboBoxEditSach";
            this.comboBoxEditSach.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSach.Size = new System.Drawing.Size(523, 23);
            this.comboBoxEditSach.TabIndex = 17;
            // 
            // buttonLapPhieu
            // 
            this.buttonLapPhieu.BackColor = System.Drawing.Color.Blue;
            this.buttonLapPhieu.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonLapPhieu.Location = new System.Drawing.Point(188, 355);
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
            this.radioButton1.Location = new System.Drawing.Point(289, 302);
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
            this.hINHTHUCRadioButton.Location = new System.Drawing.Point(188, 302);
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
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(746, 34);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(715, 432);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // qltvDataSet1
            // 
            this.qltvDataSet1.DataSetName = "QLTVDataSet";
            this.qltvDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FormPHIEUMUONSACH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 488);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormPHIEUMUONSACH";
            this.Text = "FormPHIEUMUONSACH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pHIEUMUONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mANVTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAPHIEUTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditMaDG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qltvDataSet1)).EndInit();
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
        private QLTVDataSetTableAdapters.NHANVIENTableAdapter NHANVIENTableAdapter;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RadioButton hINHTHUCRadioButton;
        private System.Windows.Forms.RadioButton radioButton1;
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
        private DevExpress.XtraEditors.LookUpEdit comboBoxEditMaDG;
        private DevExpress.XtraEditors.LookUpEdit comboBoxEditSach;
        private DevExpress.XtraEditors.TextEdit mANVTextEdit;
        private DevExpress.XtraEditors.TextEdit mAPHIEUTextEdit;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private QLTVDataSet qltvDataSet1;
    }
}