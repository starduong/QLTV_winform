namespace AppLibrary
{
    partial class FormTraSach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTraSach));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTAICHO = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonDONG = new DevExpress.XtraEditors.SimpleButton();
            this.textEditSACH = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.simpleButtonTS = new DevExpress.XtraEditors.SimpleButton();
            this.textEditNVNS = new DevExpress.XtraEditors.TextEdit();
            this.textEditMPS = new DevExpress.XtraEditors.TextEdit();
            this.radioButtonMat = new System.Windows.Forms.RadioButton();
            this.radioButtonHong = new System.Windows.Forms.RadioButton();
            this.radioButtonTot = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSACH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNVNS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMPS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
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
            this.barButtonItemRefresh,
            this.barButtonItemTAICHO});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemTAICHO)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItemRefresh
            // 
            this.barButtonItemRefresh.Caption = "Refresh";
            this.barButtonItemRefresh.Id = 2;
            this.barButtonItemRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemRefresh.ImageOptions.SvgImage")));
            this.barButtonItemRefresh.Name = "barButtonItemRefresh";
            this.barButtonItemRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItemTAICHO
            // 
            this.barButtonItemTAICHO.Caption = "Danh sách độc giả mượn tại chỗ chưa trả sách";
            this.barButtonItemTAICHO.Id = 4;
            this.barButtonItemTAICHO.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barButtonItemTAICHO.ImageOptions.SvgImage")));
            this.barButtonItemTAICHO.Name = "barButtonItemTAICHO";
            this.barButtonItemTAICHO.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemTAICHO.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemTAICHO_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1381, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 470);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1381, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 436);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1381, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 436);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 27);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1127, 407);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 328;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsEditForm.PopupEditFormWidth = 700;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonDONG);
            this.panelControl1.Controls.Add(this.textEditSACH);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.simpleButtonTS);
            this.panelControl1.Controls.Add(this.textEditNVNS);
            this.panelControl1.Controls.Add(this.textEditMPS);
            this.panelControl1.Controls.Add(this.radioButtonMat);
            this.panelControl1.Controls.Add(this.radioButtonHong);
            this.panelControl1.Controls.Add(this.radioButtonTot);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(2, 27);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(246, 407);
            this.panelControl1.TabIndex = 5;
            // 
            // simpleButtonDONG
            // 
            this.simpleButtonDONG.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonDONG.ImageOptions.Image")));
            this.simpleButtonDONG.Location = new System.Drawing.Point(541, 0);
            this.simpleButtonDONG.Name = "simpleButtonDONG";
            this.simpleButtonDONG.Size = new System.Drawing.Size(23, 26);
            this.simpleButtonDONG.TabIndex = 14;
            this.simpleButtonDONG.Click += new System.EventHandler(this.simpleButtonDONG_Click);
            // 
            // textEditSACH
            // 
            this.textEditSACH.Location = new System.Drawing.Point(170, 189);
            this.textEditSACH.MenuManager = this.barManager1;
            this.textEditSACH.Name = "textEditSACH";
            this.textEditSACH.Size = new System.Drawing.Size(305, 23);
            this.textEditSACH.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sách :";
            // 
            // simpleButtonTS
            // 
            this.simpleButtonTS.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.simpleButtonTS.Appearance.Options.UseBackColor = true;
            this.simpleButtonTS.Location = new System.Drawing.Point(26, 307);
            this.simpleButtonTS.Name = "simpleButtonTS";
            this.simpleButtonTS.Size = new System.Drawing.Size(449, 27);
            this.simpleButtonTS.TabIndex = 11;
            this.simpleButtonTS.Text = "Trả sách";
            this.simpleButtonTS.Click += new System.EventHandler(this.simpleButtonTS_Click);
            // 
            // textEditNVNS
            // 
            this.textEditNVNS.Location = new System.Drawing.Point(170, 149);
            this.textEditNVNS.MenuManager = this.barManager1;
            this.textEditNVNS.Name = "textEditNVNS";
            this.textEditNVNS.Size = new System.Drawing.Size(305, 23);
            this.textEditNVNS.TabIndex = 10;
            // 
            // textEditMPS
            // 
            this.textEditMPS.Location = new System.Drawing.Point(170, 100);
            this.textEditMPS.MenuManager = this.barManager1;
            this.textEditMPS.Name = "textEditMPS";
            this.textEditMPS.Size = new System.Drawing.Size(305, 23);
            this.textEditMPS.TabIndex = 9;
            // 
            // radioButtonMat
            // 
            this.radioButtonMat.AutoSize = true;
            this.radioButtonMat.Location = new System.Drawing.Point(405, 230);
            this.radioButtonMat.Name = "radioButtonMat";
            this.radioButtonMat.Size = new System.Drawing.Size(80, 20);
            this.radioButtonMat.TabIndex = 8;
            this.radioButtonMat.TabStop = true;
            this.radioButtonMat.Text = "Mất sách";
            this.radioButtonMat.UseVisualStyleBackColor = true;
            this.radioButtonMat.CheckedChanged += new System.EventHandler(this.radioButtonMat_CheckedChanged);
            // 
            // radioButtonHong
            // 
            this.radioButtonHong.AutoSize = true;
            this.radioButtonHong.Location = new System.Drawing.Point(293, 230);
            this.radioButtonHong.Name = "radioButtonHong";
            this.radioButtonHong.Size = new System.Drawing.Size(88, 20);
            this.radioButtonHong.TabIndex = 7;
            this.radioButtonHong.TabStop = true;
            this.radioButtonHong.Text = "Sách hỏng";
            this.radioButtonHong.UseVisualStyleBackColor = true;
            this.radioButtonHong.CheckedChanged += new System.EventHandler(this.radioButtonHong_CheckedChanged);
            // 
            // radioButtonTot
            // 
            this.radioButtonTot.AutoSize = true;
            this.radioButtonTot.Location = new System.Drawing.Point(170, 230);
            this.radioButtonTot.Name = "radioButtonTot";
            this.radioButtonTot.Size = new System.Drawing.Size(100, 20);
            this.radioButtonTot.TabIndex = 6;
            this.radioButtonTot.TabStop = true;
            this.radioButtonTot.Text = "Sách còn tốt";
            this.radioButtonTot.UseVisualStyleBackColor = true;
            this.radioButtonTot.CheckedChanged += new System.EventHandler(this.radioButtonTot_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hiện trạng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nhân viên nhận lại sách  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã phiếu mượn :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(181, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRẢ SÁCH";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 34);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1131, 436);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Danh sách sách mượn mang về";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.panelControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(1131, 34);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(250, 436);
            this.groupControl2.TabIndex = 11;
            this.groupControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl2_Paint);
            // 
            // FormTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 492);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormTraSach";
            this.Text = "FormTraSach";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditSACH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNVNS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMPS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private QLTVDataSet qLTVDataSet;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRefresh;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButtonTot;
        private System.Windows.Forms.RadioButton radioButtonMat;
        private System.Windows.Forms.RadioButton radioButtonHong;
        private DevExpress.XtraEditors.TextEdit textEditNVNS;
        private DevExpress.XtraEditors.TextEdit textEditMPS;
        private DevExpress.XtraEditors.SimpleButton simpleButtonTS;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTAICHO;
        private DevExpress.XtraEditors.TextEdit textEditSACH;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDONG;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}