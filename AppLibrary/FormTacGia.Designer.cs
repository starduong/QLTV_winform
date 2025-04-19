namespace AppLibrary
{
    partial class FormTacGia
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.tACGIABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tACGIATableAdapter = new AppLibrary.QLTVDataSetTableAdapters.TACGIATableAdapter();
            this.tableAdapterManager = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.tACGIAGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMATACGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOTENTG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHITG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIENTHOAITG = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tACGIABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tACGIAGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 467);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(974, 144);
            this.panelControl2.TabIndex = 12;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 56);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(20, 22, 20, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(974, 56);
            this.panelControl1.TabIndex = 10;
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 611);
            this.barDockControlBottom.Manager = null;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(974, 0);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 56);
            this.barDockControlTop.Manager = null;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(974, 0);
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
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3,
            this.bar4});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MainMenu = this.bar3;
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar4;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(974, 56);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 611);
            this.barDockControl2.Manager = this.barManager1;
            this.barDockControl2.Size = new System.Drawing.Size(974, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 56);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 555);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(974, 56);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 555);
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Main menu";
            // 
            // bar4
            // 
            this.bar4.BarName = "Status bar";
            this.bar4.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar4.DockCol = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar4.OptionsBar.AllowQuickCustomization = false;
            this.bar4.OptionsBar.DrawDragBorder = false;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Status bar";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tACGIABindingSource
            // 
            this.tACGIABindingSource.DataMember = "TACGIA";
            this.tACGIABindingSource.DataSource = this.qLTVDataSet;
            // 
            // tACGIATableAdapter
            // 
            this.tACGIATableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.PHIEUMUONTableAdapter = null;
            this.tableAdapterManager.SACHTableAdapter = null;
            this.tableAdapterManager.TACGIA_SACHTableAdapter = null;
            this.tableAdapterManager.TACGIATableAdapter = this.tACGIATableAdapter;
            this.tableAdapterManager.THELOAITableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tACGIAGridControl
            // 
            this.tACGIAGridControl.DataSource = this.tACGIABindingSource;
            this.tACGIAGridControl.Location = new System.Drawing.Point(0, 112);
            this.tACGIAGridControl.MainView = this.gridView1;
            this.tACGIAGridControl.MenuManager = this.barManager1;
            this.tACGIAGridControl.Name = "tACGIAGridControl";
            this.tACGIAGridControl.Size = new System.Drawing.Size(974, 355);
            this.tACGIAGridControl.TabIndex = 21;
            this.tACGIAGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMATACGIA,
            this.colHOTENTG,
            this.colDIACHITG,
            this.colDIENTHOAITG});
            this.gridView1.GridControl = this.tACGIAGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMATACGIA
            // 
            this.colMATACGIA.FieldName = "MATACGIA";
            this.colMATACGIA.MinWidth = 25;
            this.colMATACGIA.Name = "colMATACGIA";
            this.colMATACGIA.Visible = true;
            this.colMATACGIA.VisibleIndex = 0;
            this.colMATACGIA.Width = 94;
            // 
            // colHOTENTG
            // 
            this.colHOTENTG.FieldName = "HOTENTG";
            this.colHOTENTG.MinWidth = 25;
            this.colHOTENTG.Name = "colHOTENTG";
            this.colHOTENTG.Visible = true;
            this.colHOTENTG.VisibleIndex = 1;
            this.colHOTENTG.Width = 94;
            // 
            // colDIACHITG
            // 
            this.colDIACHITG.FieldName = "DIACHITG";
            this.colDIACHITG.MinWidth = 25;
            this.colDIACHITG.Name = "colDIACHITG";
            this.colDIACHITG.Visible = true;
            this.colDIACHITG.VisibleIndex = 2;
            this.colDIACHITG.Width = 94;
            // 
            // colDIENTHOAITG
            // 
            this.colDIENTHOAITG.FieldName = "DIENTHOAITG";
            this.colDIENTHOAITG.MinWidth = 25;
            this.colDIENTHOAITG.Name = "colDIENTHOAITG";
            this.colDIENTHOAITG.Visible = true;
            this.colDIENTHOAITG.VisibleIndex = 3;
            this.colDIENTHOAITG.Width = 94;
            // 
            // FormTacGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 633);
            this.Controls.Add(this.tACGIAGridControl);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "FormTacGia";
            this.Text = "FormTacGia";
            this.Load += new System.EventHandler(this.FormTacGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tACGIABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tACGIAGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource tACGIABindingSource;
        private QLTVDataSet qLTVDataSet;
        private QLTVDataSetTableAdapters.TACGIATableAdapter tACGIATableAdapter;
        private QLTVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl tACGIAGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMATACGIA;
        private DevExpress.XtraGrid.Columns.GridColumn colHOTENTG;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHITG;
        private DevExpress.XtraGrid.Columns.GridColumn colDIENTHOAITG;
    }
}