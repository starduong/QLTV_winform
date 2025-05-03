namespace AppLibrary
{
    partial class FormTaoTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTaoTaiKhoan));
            this.lblMaNV = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenLogin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtConfirmMK = new DevExpress.XtraEditors.TextEdit();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.btnChonNhanVien = new DevExpress.XtraEditors.SimpleButton();
            this.gcInput = new DevExpress.XtraEditors.GroupControl();
            this.btnShowPW = new DevExpress.XtraEditors.LabelControl();
            this.btnHidePW = new DevExpress.XtraEditors.LabelControl();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.bdsNVChuaCoTk = new System.Windows.Forms.BindingSource(this.components);
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcBangNhanVien = new DevExpress.XtraEditors.GroupControl();
            this.v_NhanVienChuaCoTaiKhoanGridControl = new DevExpress.XtraGrid.GridControl();
            this.gvNVChuaCoTK = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMãnhânviên = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHọtên = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiớitính = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colĐịachỉ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSốđiệnthoại = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableAdapterManager = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.v_NhanVienChuaCoTaiKhoanTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.v_NhanVienChuaCoTaiKhoanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmMK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInput)).BeginInit();
            this.gcInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNVChuaCoTk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBangNhanVien)).BeginInit();
            this.gcBangNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.v_NhanVienChuaCoTaiKhoanGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNVChuaCoTK)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaNV
            // 
            this.lblMaNV.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblMaNV.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.ImageOptions.Image")));
            this.lblMaNV.Location = new System.Drawing.Point(91, 71);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(158, 38);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "MÃ NHÂN VIÊN:";
            // 
            // labelControl2
            // 
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl2.ImageOptions.Image")));
            this.labelControl2.Location = new System.Drawing.Point(124, 126);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(125, 38);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "TÊN LOGIN:";
            // 
            // txtTenLogin
            // 
            this.txtTenLogin.Location = new System.Drawing.Point(284, 123);
            this.txtTenLogin.Name = "txtTenLogin";
            this.txtTenLogin.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLogin.Properties.Appearance.Options.UseFont = true;
            this.txtTenLogin.Size = new System.Drawing.Size(326, 28);
            this.txtTenLogin.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl3.ImageOptions.Image")));
            this.labelControl3.Location = new System.Drawing.Point(124, 173);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(125, 38);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "MẬT KHẨU:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(284, 170);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Properties.Appearance.Options.UseFont = true;
            this.txtMatKhau.Properties.UseSystemPasswordChar = true;
            this.txtMatKhau.Size = new System.Drawing.Size(326, 28);
            this.txtMatKhau.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl4.ImageOptions.Image")));
            this.labelControl4.Location = new System.Drawing.Point(47, 225);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(202, 38);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "CONFIRM MẬT KHẨU:";
            // 
            // txtConfirmMK
            // 
            this.txtConfirmMK.Location = new System.Drawing.Point(284, 222);
            this.txtConfirmMK.Name = "txtConfirmMK";
            this.txtConfirmMK.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmMK.Properties.Appearance.Options.UseFont = true;
            this.txtConfirmMK.Properties.UseSystemPasswordChar = true;
            this.txtConfirmMK.Size = new System.Drawing.Size(326, 28);
            this.txtConfirmMK.TabIndex = 3;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXacNhan.ImageOptions.Image")));
            this.btnXacNhan.Location = new System.Drawing.Point(427, 304);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(183, 34);
            this.btnXacNhan.TabIndex = 2;
            this.btnXacNhan.Text = "XÁC NHẬN";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.ImageOptions.Image")));
            this.btnHuy.Location = new System.Drawing.Point(284, 304);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(112, 34);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnChonNhanVien
            // 
            this.btnChonNhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChonNhanVien.ImageOptions.Image")));
            this.btnChonNhanVien.Location = new System.Drawing.Point(284, 72);
            this.btnChonNhanVien.Name = "btnChonNhanVien";
            this.btnChonNhanVien.Size = new System.Drawing.Size(188, 34);
            this.btnChonNhanVien.TabIndex = 3;
            this.btnChonNhanVien.Text = "CHỌN NHÂN VIÊN";
            this.btnChonNhanVien.Click += new System.EventHandler(this.btnChonNhanVien_Click);
            // 
            // gcInput
            // 
            this.gcInput.Controls.Add(this.btnShowPW);
            this.gcInput.Controls.Add(this.btnHidePW);
            this.gcInput.Controls.Add(this.txtMaNV);
            this.gcInput.Controls.Add(this.txtMatKhau);
            this.gcInput.Controls.Add(this.btnChonNhanVien);
            this.gcInput.Controls.Add(this.lblMaNV);
            this.gcInput.Controls.Add(this.btnThoat);
            this.gcInput.Controls.Add(this.btnHuy);
            this.gcInput.Controls.Add(this.btnXacNhan);
            this.gcInput.Controls.Add(this.labelControl2);
            this.gcInput.Controls.Add(this.txtConfirmMK);
            this.gcInput.Controls.Add(this.txtTenLogin);
            this.gcInput.Controls.Add(this.labelControl4);
            this.gcInput.Controls.Add(this.labelControl3);
            this.gcInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcInput.Location = new System.Drawing.Point(2, 2);
            this.gcInput.Name = "gcInput";
            this.gcInput.Size = new System.Drawing.Size(284, 621);
            this.gcInput.TabIndex = 4;
            // 
            // btnShowPW
            // 
            this.btnShowPW.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnShowPW.ImageOptions.Image")));
            this.btnShowPW.Location = new System.Drawing.Point(617, 167);
            this.btnShowPW.Name = "btnShowPW";
            this.btnShowPW.Size = new System.Drawing.Size(32, 32);
            this.btnShowPW.TabIndex = 12;
            this.btnShowPW.Click += new System.EventHandler(this.btnShowPW_Click);
            // 
            // btnHidePW
            // 
            this.btnHidePW.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHidePW.ImageOptions.Image")));
            this.btnHidePW.Location = new System.Drawing.Point(617, 167);
            this.btnHidePW.Name = "btnHidePW";
            this.btnHidePW.Size = new System.Drawing.Size(32, 32);
            this.btnHidePW.TabIndex = 12;
            this.btnHidePW.Click += new System.EventHandler(this.btnHidePW_Click);
            // 
            // txtMaNV
            // 
            this.txtMaNV.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsNVChuaCoTk, "Mã nhân viên", true));
            this.txtMaNV.DataBindings.Add(new System.Windows.Forms.Binding("ReadOnly", this.bdsNVChuaCoTk, "Mã nhân viên", true));
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Location = new System.Drawing.Point(284, 77);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(326, 27);
            this.txtMaNV.TabIndex = 11;
            // 
            // bdsNVChuaCoTk
            // 
            this.bdsNVChuaCoTk.DataMember = "v_NhanVienChuaCoTaiKhoan";
            this.bdsNVChuaCoTk.DataSource = this.qLTVDataSet;
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnThoat
            // 
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(91, 304);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 34);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gcInput);
            this.panelControl1.Controls.Add(this.gcBangNhanVien);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1320, 625);
            this.panelControl1.TabIndex = 5;
            // 
            // gcBangNhanVien
            // 
            this.gcBangNhanVien.Controls.Add(this.v_NhanVienChuaCoTaiKhoanGridControl);
            this.gcBangNhanVien.Dock = System.Windows.Forms.DockStyle.Right;
            this.gcBangNhanVien.Location = new System.Drawing.Point(286, 2);
            this.gcBangNhanVien.Name = "gcBangNhanVien";
            this.gcBangNhanVien.Size = new System.Drawing.Size(1032, 621);
            this.gcBangNhanVien.TabIndex = 0;
            this.gcBangNhanVien.Text = "DANH SÁCH NHÂN VIÊN CHƯA CÓ TÀI KHOẢN";
            // 
            // v_NhanVienChuaCoTaiKhoanGridControl
            // 
            this.v_NhanVienChuaCoTaiKhoanGridControl.DataSource = this.bdsNVChuaCoTk;
            this.v_NhanVienChuaCoTaiKhoanGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.v_NhanVienChuaCoTaiKhoanGridControl.Location = new System.Drawing.Point(2, 32);
            this.v_NhanVienChuaCoTaiKhoanGridControl.MainView = this.gvNVChuaCoTK;
            this.v_NhanVienChuaCoTaiKhoanGridControl.Name = "v_NhanVienChuaCoTaiKhoanGridControl";
            this.v_NhanVienChuaCoTaiKhoanGridControl.Size = new System.Drawing.Size(1028, 587);
            this.v_NhanVienChuaCoTaiKhoanGridControl.TabIndex = 0;
            this.v_NhanVienChuaCoTaiKhoanGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNVChuaCoTK});
            // 
            // gvNVChuaCoTK
            // 
            this.gvNVChuaCoTK.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMãnhânviên,
            this.colHọtên,
            this.colGiớitính,
            this.colĐịachỉ,
            this.colSốđiệnthoại,
            this.colEmail});
            this.gvNVChuaCoTK.GridControl = this.v_NhanVienChuaCoTaiKhoanGridControl;
            this.gvNVChuaCoTK.Name = "gvNVChuaCoTK";
            this.gvNVChuaCoTK.OptionsBehavior.Editable = false;
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
            // v_NhanVienChuaCoTaiKhoanTableAdapter
            // 
            this.v_NhanVienChuaCoTaiKhoanTableAdapter.ClearBeforeFill = true;
            // 
            // FormTaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1320, 625);
            this.Controls.Add(this.panelControl1);
            this.Name = "FormTaoTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo tài khoản";
            this.Load += new System.EventHandler(this.FormTaoTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTenLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmMK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInput)).EndInit();
            this.gcInput.ResumeLayout(false);
            this.gcInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsNVChuaCoTk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcBangNhanVien)).EndInit();
            this.gcBangNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.v_NhanVienChuaCoTaiKhoanGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNVChuaCoTK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblMaNV;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTenLogin;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtConfirmMK;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SimpleButton btnChonNhanVien;
        private DevExpress.XtraEditors.GroupControl gcInput;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private QLTVDataSet qLTVDataSet;
        private QLTVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.GroupControl gcBangNhanVien;
        private System.Windows.Forms.BindingSource bdsNVChuaCoTk;
        private QLTVDataSetTableAdapters.v_NhanVienChuaCoTaiKhoanTableAdapter v_NhanVienChuaCoTaiKhoanTableAdapter;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private DevExpress.XtraGrid.GridControl v_NhanVienChuaCoTaiKhoanGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNVChuaCoTK;
        private DevExpress.XtraGrid.Columns.GridColumn colMãnhânviên;
        private DevExpress.XtraGrid.Columns.GridColumn colHọtên;
        private DevExpress.XtraGrid.Columns.GridColumn colGiớitính;
        private DevExpress.XtraGrid.Columns.GridColumn colĐịachỉ;
        private DevExpress.XtraGrid.Columns.GridColumn colSốđiệnthoại;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.LabelControl btnHidePW;
        private DevExpress.XtraEditors.LabelControl btnShowPW;
    }
}