namespace AppLibrary
{
    partial class FormDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDoiMatKhau));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcNVCoTK = new DevExpress.XtraEditors.GroupControl();
            this.v_NhanVienCoTaiKhoanGridControl = new DevExpress.XtraGrid.GridControl();
            this.bdsNVCoTK = new System.Windows.Forms.BindingSource(this.components);
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.gvNVCoTK = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMãnhânviên = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHọtên = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiớitính = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colĐịachỉ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSốđiệnthoại = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTênLogin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInput = new DevExpress.XtraEditors.GroupControl();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.btnShowPW = new DevExpress.XtraEditors.LabelControl();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmMK = new DevExpress.XtraEditors.TextEdit();
            this.btnHidePW = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenLogin = new DevExpress.XtraEditors.TextEdit();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.lblMaNV = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblHoTen = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.lblTenLogin = new DevExpress.XtraEditors.LabelControl();
            this.v_NhanVienCoTaiKhoanTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.v_NhanVienCoTaiKhoanTableAdapter();
            this.tableAdapterManager = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNVCoTK)).BeginInit();
            this.gcNVCoTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_NhanVienCoTaiKhoanGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNVCoTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNVCoTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInput)).BeginInit();
            this.gcInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmMK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcNVCoTK);
            this.panelControl1.Controls.Add(this.gcInput);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1311, 521);
            this.panelControl1.TabIndex = 0;
            // 
            // gcNVCoTK
            // 
            this.gcNVCoTK.Controls.Add(this.v_NhanVienCoTaiKhoanGridControl);
            this.gcNVCoTK.Dock = System.Windows.Forms.DockStyle.Right;
            this.gcNVCoTK.Location = new System.Drawing.Point(275, 2);
            this.gcNVCoTK.Name = "gcNVCoTK";
            this.gcNVCoTK.Size = new System.Drawing.Size(1034, 517);
            this.gcNVCoTK.TabIndex = 1;
            this.gcNVCoTK.Text = "DANH SÁCH NHÂN VIÊN ĐÃ CÓ TÀI KHOẢN";
            // 
            // v_NhanVienCoTaiKhoanGridControl
            // 
            this.v_NhanVienCoTaiKhoanGridControl.DataSource = this.bdsNVCoTK;
            this.v_NhanVienCoTaiKhoanGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.v_NhanVienCoTaiKhoanGridControl.Location = new System.Drawing.Point(2, 32);
            this.v_NhanVienCoTaiKhoanGridControl.MainView = this.gvNVCoTK;
            this.v_NhanVienCoTaiKhoanGridControl.Name = "v_NhanVienCoTaiKhoanGridControl";
            this.v_NhanVienCoTaiKhoanGridControl.Size = new System.Drawing.Size(1030, 483);
            this.v_NhanVienCoTaiKhoanGridControl.TabIndex = 0;
            this.v_NhanVienCoTaiKhoanGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNVCoTK});
            // 
            // bdsNVCoTK
            // 
            this.bdsNVCoTK.DataMember = "v_NhanVienCoTaiKhoan";
            this.bdsNVCoTK.DataSource = this.qLTVDataSet;
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gvNVCoTK
            // 
            this.gvNVCoTK.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMãnhânviên,
            this.colHọtên,
            this.colGiớitính,
            this.colĐịachỉ,
            this.colSốđiệnthoại,
            this.colEmail,
            this.colTênLogin});
            this.gvNVCoTK.GridControl = this.v_NhanVienCoTaiKhoanGridControl;
            this.gvNVCoTK.Name = "gvNVCoTK";
            this.gvNVCoTK.OptionsBehavior.Editable = false;
            this.gvNVCoTK.OptionsDetail.EnableMasterViewMode = false;
            this.gvNVCoTK.OptionsHint.ShowFooterHints = false;
            // 
            // colMãnhânviên
            // 
            this.colMãnhânviên.FieldName = "Mã nhân viên";
            this.colMãnhânviên.MinWidth = 30;
            this.colMãnhânviên.Name = "colMãnhânviên";
            this.colMãnhânviên.Visible = true;
            this.colMãnhânviên.VisibleIndex = 0;
            this.colMãnhânviên.Width = 112;
            // 
            // colHọtên
            // 
            this.colHọtên.FieldName = "Họ tên";
            this.colHọtên.MinWidth = 30;
            this.colHọtên.Name = "colHọtên";
            this.colHọtên.Visible = true;
            this.colHọtên.VisibleIndex = 1;
            this.colHọtên.Width = 112;
            // 
            // colGiớitính
            // 
            this.colGiớitính.FieldName = "Giới tính";
            this.colGiớitính.MinWidth = 30;
            this.colGiớitính.Name = "colGiớitính";
            this.colGiớitính.Visible = true;
            this.colGiớitính.VisibleIndex = 2;
            this.colGiớitính.Width = 112;
            // 
            // colĐịachỉ
            // 
            this.colĐịachỉ.FieldName = "Địa chỉ";
            this.colĐịachỉ.MinWidth = 30;
            this.colĐịachỉ.Name = "colĐịachỉ";
            this.colĐịachỉ.Visible = true;
            this.colĐịachỉ.VisibleIndex = 3;
            this.colĐịachỉ.Width = 112;
            // 
            // colSốđiệnthoại
            // 
            this.colSốđiệnthoại.FieldName = "Số điện thoại";
            this.colSốđiệnthoại.MinWidth = 30;
            this.colSốđiệnthoại.Name = "colSốđiệnthoại";
            this.colSốđiệnthoại.Visible = true;
            this.colSốđiệnthoại.VisibleIndex = 4;
            this.colSốđiệnthoại.Width = 112;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.MinWidth = 30;
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 5;
            this.colEmail.Width = 112;
            // 
            // colTênLogin
            // 
            this.colTênLogin.FieldName = "TênLogin";
            this.colTênLogin.MinWidth = 30;
            this.colTênLogin.Name = "colTênLogin";
            this.colTênLogin.Visible = true;
            this.colTênLogin.VisibleIndex = 6;
            this.colTênLogin.Width = 112;
            // 
            // gcInput
            // 
            this.gcInput.Controls.Add(this.txtMaNV);
            this.gcInput.Controls.Add(this.btnShowPW);
            this.gcInput.Controls.Add(this.txtHoTen);
            this.gcInput.Controls.Add(this.txtConfirmMK);
            this.gcInput.Controls.Add(this.btnHidePW);
            this.gcInput.Controls.Add(this.labelControl4);
            this.gcInput.Controls.Add(this.txtTenLogin);
            this.gcInput.Controls.Add(this.btnXacNhan);
            this.gcInput.Controls.Add(this.txtMatKhau);
            this.gcInput.Controls.Add(this.lblMaNV);
            this.gcInput.Controls.Add(this.labelControl3);
            this.gcInput.Controls.Add(this.lblHoTen);
            this.gcInput.Controls.Add(this.btnThoat);
            this.gcInput.Controls.Add(this.btnHuy);
            this.gcInput.Controls.Add(this.lblTenLogin);
            this.gcInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcInput.Location = new System.Drawing.Point(2, 2);
            this.gcInput.Name = "gcInput";
            this.gcInput.Size = new System.Drawing.Size(1307, 517);
            this.gcInput.TabIndex = 0;
            // 
            // txtMaNV
            // 
            this.txtMaNV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNVCoTK, "Mã nhân viên", true));
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Location = new System.Drawing.Point(273, 100);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Properties.Appearance.Options.UseFont = true;
            this.txtMaNV.Size = new System.Drawing.Size(326, 28);
            this.txtMaNV.TabIndex = 1;
            // 
            // btnShowPW
            // 
            this.btnShowPW.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPW.ImageOptions.Image")));
            this.btnShowPW.Location = new System.Drawing.Point(606, 255);
            this.btnShowPW.Name = "btnShowPW";
            this.btnShowPW.Size = new System.Drawing.Size(32, 32);
            this.btnShowPW.TabIndex = 20;
            this.btnShowPW.Click += new System.EventHandler(this.btnShowPW_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNVCoTK, "Họ tên", true));
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(273, 154);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Properties.Appearance.Options.UseFont = true;
            this.txtHoTen.Size = new System.Drawing.Size(326, 28);
            this.txtHoTen.TabIndex = 3;
            // 
            // txtConfirmMK
            // 
            this.txtConfirmMK.Location = new System.Drawing.Point(273, 308);
            this.txtConfirmMK.Name = "txtConfirmMK";
            this.txtConfirmMK.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmMK.Properties.Appearance.Options.UseFont = true;
            this.txtConfirmMK.Properties.UseSystemPasswordChar = true;
            this.txtConfirmMK.Size = new System.Drawing.Size(326, 28);
            this.txtConfirmMK.TabIndex = 19;
            // 
            // btnHidePW
            // 
            this.btnHidePW.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHidePW.ImageOptions.Image")));
            this.btnHidePW.Location = new System.Drawing.Point(606, 253);
            this.btnHidePW.Name = "btnHidePW";
            this.btnHidePW.Size = new System.Drawing.Size(32, 32);
            this.btnHidePW.TabIndex = 21;
            this.btnHidePW.Click += new System.EventHandler(this.btnHidePW_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl4.ImageOptions.Image")));
            this.labelControl4.Location = new System.Drawing.Point(36, 311);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(202, 38);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "CONFIRM MẬT KHẨU:";
            // 
            // txtTenLogin
            // 
            this.txtTenLogin.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNVCoTK, "TênLogin", true));
            this.txtTenLogin.Enabled = false;
            this.txtTenLogin.Location = new System.Drawing.Point(273, 202);
            this.txtTenLogin.Name = "txtTenLogin";
            this.txtTenLogin.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLogin.Properties.Appearance.Options.UseFont = true;
            this.txtTenLogin.Size = new System.Drawing.Size(326, 28);
            this.txtTenLogin.TabIndex = 5;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.ImageOptions.Image")));
            this.btnXacNhan.Location = new System.Drawing.Point(416, 390);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(183, 34);
            this.btnXacNhan.TabIndex = 18;
            this.btnXacNhan.Text = "XÁC NHẬN";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(273, 256);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Properties.Appearance.Options.UseFont = true;
            this.txtMatKhau.Properties.UseSystemPasswordChar = true;
            this.txtMatKhau.Size = new System.Drawing.Size(326, 28);
            this.txtMatKhau.TabIndex = 15;
            // 
            // lblMaNV
            // 
            this.lblMaNV.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblMaNV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblMaNV.ImageOptions.Image")));
            this.lblMaNV.Location = new System.Drawing.Point(79, 96);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(159, 38);
            this.lblMaNV.TabIndex = 14;
            this.lblMaNV.Text = "MÃ NHÂN VIÊN;";
            // 
            // labelControl3
            // 
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl3.ImageOptions.Image")));
            this.labelControl3.Location = new System.Drawing.Point(78, 259);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(160, 38);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "MẬT KHẨU MỚI:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblHoTen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblHoTen.ImageOptions.Image")));
            this.lblHoTen.Location = new System.Drawing.Point(139, 150);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(99, 38);
            this.lblHoTen.TabIndex = 14;
            this.lblHoTen.Text = "HỌ TÊN:";
            // 
            // btnThoat
            // 
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(80, 390);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 34);
            this.btnThoat.TabIndex = 16;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.Image")));
            this.btnHuy.Location = new System.Drawing.Point(273, 390);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 34);
            this.btnHuy.TabIndex = 17;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lblTenLogin
            // 
            this.lblTenLogin.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblTenLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("lblTenLogin.ImageOptions.Image")));
            this.lblTenLogin.Location = new System.Drawing.Point(113, 205);
            this.lblTenLogin.Name = "lblTenLogin";
            this.lblTenLogin.Size = new System.Drawing.Size(125, 38);
            this.lblTenLogin.TabIndex = 14;
            this.lblTenLogin.Text = "TÊN LOGIN:";
            // 
            // v_NhanVienCoTaiKhoanTableAdapter
            // 
            this.v_NhanVienCoTaiKhoanTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.TACGIA_SACHTableAdapter = null;
            this.tableAdapterManager.TACGIATableAdapter = null;
            this.tableAdapterManager.THELOAITableAdapter = null;
            this.tableAdapterManager.UpdateOrder = AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // FormDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 521);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormDoiMatKhau";
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.FormDoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNVCoTK)).EndInit();
            this.gcNVCoTK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v_NhanVienCoTaiKhoanGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNVCoTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNVCoTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInput)).EndInit();
            this.gcInput.ResumeLayout(false);
            this.gcInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmMK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl gcNVCoTK;
        private DevExpress.XtraEditors.GroupControl gcInput;
        private QLTVDataSet qLTVDataSet;
        private System.Windows.Forms.BindingSource bdsNVCoTK;
        private QLTVDataSetTableAdapters.v_NhanVienCoTaiKhoanTableAdapter v_NhanVienCoTaiKhoanTableAdapter;
        private QLTVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl v_NhanVienCoTaiKhoanGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNVCoTK;
        private DevExpress.XtraGrid.Columns.GridColumn colMãnhânviên;
        private DevExpress.XtraGrid.Columns.GridColumn colHọtên;
        private DevExpress.XtraGrid.Columns.GridColumn colGiớitính;
        private DevExpress.XtraGrid.Columns.GridColumn colĐịachỉ;
        private DevExpress.XtraGrid.Columns.GridColumn colSốđiệnthoại;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colTênLogin;
        private DevExpress.XtraEditors.TextEdit txtTenLogin;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private DevExpress.XtraEditors.LabelControl btnShowPW;
        private DevExpress.XtraEditors.LabelControl btnHidePW;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraEditors.TextEdit txtConfirmMK;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblMaNV;
        private DevExpress.XtraEditors.LabelControl lblHoTen;
        private DevExpress.XtraEditors.LabelControl lblTenLogin;
    }
}