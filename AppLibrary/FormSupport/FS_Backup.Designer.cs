namespace AppLibrary.FormSupport
{
    partial class FS_Backup
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.qLTVDataSet = new AppLibrary.QLTVDataSet();
            this.cbBackupType = new System.Windows.Forms.ComboBox();
            this.txtDBName = new DevExpress.XtraEditors.TextEdit();
            this.cbDeviceName = new System.Windows.Forms.ComboBox();
            this.bdsSysBKDevice = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtNameBK = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.rbtINIT = new System.Windows.Forms.RadioButton();
            this.rbtNOINIT = new System.Windows.Forms.RadioButton();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.gbBackupSet = new System.Windows.Forms.GroupBox();
            this.gbDestination = new System.Windows.Forms.GroupBox();
            this.sYSBACKUP_DEVICETableAdapter = new AppLibrary.QLTVDataSetTableAdapters.SYSBACKUP_DEVICETableAdapter();
            this.tableAdapterManager = new AppLibrary.QLTVDataSetTableAdapters.TableAdapterManager();
            this.sp_DanhSachBackupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_DanhSachBackupTableAdapter = new AppLibrary.QLTVDataSetTableAdapters.sp_DanhSachBackupTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSysBKDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameBK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.gbSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.gbBackupSet.SuspendLayout();
            this.gbDestination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_DanhSachBackupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(81, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Databases:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(81, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(103, 22);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Backup type:";
            // 
            // qLTVDataSet
            // 
            this.qLTVDataSet.DataSetName = "QLTVDataSet";
            this.qLTVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbBackupType
            // 
            this.cbBackupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBackupType.FormattingEnabled = true;
            this.cbBackupType.Items.AddRange(new object[] {
            "Full",
            "Differential",
            "Transaction Log"});
            this.cbBackupType.Location = new System.Drawing.Point(211, 58);
            this.cbBackupType.Name = "cbBackupType";
            this.cbBackupType.Size = new System.Drawing.Size(428, 27);
            this.cbBackupType.TabIndex = 6;
            this.cbBackupType.SelectedIndexChanged += new System.EventHandler(this.cbBackupType_SelectedIndexChanged);
            // 
            // txtDBName
            // 
            this.txtDBName.Enabled = false;
            this.txtDBName.Location = new System.Drawing.Point(211, 25);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDBName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDBName.Size = new System.Drawing.Size(428, 27);
            this.txtDBName.TabIndex = 7;
            // 
            // cbDeviceName
            // 
            this.cbDeviceName.DataSource = this.bdsSysBKDevice;
            this.cbDeviceName.DisplayMember = "name";
            this.cbDeviceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeviceName.FormattingEnabled = true;
            this.cbDeviceName.Location = new System.Drawing.Point(211, 25);
            this.cbDeviceName.Name = "cbDeviceName";
            this.cbDeviceName.Size = new System.Drawing.Size(432, 27);
            this.cbDeviceName.TabIndex = 6;
            this.cbDeviceName.ValueMember = "name";
            // 
            // bdsSysBKDevice
            // 
            this.bdsSysBKDevice.DataMember = "SYSBACKUP_DEVICE";
            this.bdsSysBKDevice.DataSource = this.qLTVDataSet;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(80, 30);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 22);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Name:";
            // 
            // txtNameBK
            // 
            this.txtNameBK.Enabled = false;
            this.txtNameBK.Location = new System.Drawing.Point(211, 25);
            this.txtNameBK.Name = "txtNameBK";
            this.txtNameBK.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNameBK.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtNameBK.Size = new System.Drawing.Size(428, 27);
            this.txtNameBK.TabIndex = 7;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(80, 63);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(99, 22);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(211, 58);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDescription.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtDescription.Size = new System.Drawing.Size(428, 27);
            this.txtDescription.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(545, 502);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(114, 34);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(423, 502);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 34);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(85, 30);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(109, 22);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Device name:";
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.rbtINIT);
            this.gbSource.Controls.Add(this.rbtNOINIT);
            this.gbSource.Controls.Add(this.radioGroup1);
            this.gbSource.Controls.Add(this.txtDBName);
            this.gbSource.Controls.Add(this.labelControl1);
            this.gbSource.Controls.Add(this.labelControl2);
            this.gbSource.Controls.Add(this.cbBackupType);
            this.gbSource.Location = new System.Drawing.Point(16, 12);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(675, 213);
            this.gbSource.TabIndex = 16;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Source";
            // 
            // rbtINIT
            // 
            this.rbtINIT.AutoSize = true;
            this.rbtINIT.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtINIT.Location = new System.Drawing.Point(211, 158);
            this.rbtINIT.Name = "rbtINIT";
            this.rbtINIT.Size = new System.Drawing.Size(305, 26);
            this.rbtINIT.TabIndex = 10;
            this.rbtINIT.TabStop = true;
            this.rbtINIT.Text = "Overwrite all existing backup sets";
            this.rbtINIT.UseVisualStyleBackColor = true;
            // 
            // rbtNOINIT
            // 
            this.rbtNOINIT.AutoSize = true;
            this.rbtNOINIT.Checked = true;
            this.rbtNOINIT.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtNOINIT.Location = new System.Drawing.Point(211, 116);
            this.rbtNOINIT.Name = "rbtNOINIT";
            this.rbtNOINIT.Size = new System.Drawing.Size(299, 26);
            this.rbtNOINIT.TabIndex = 9;
            this.rbtNOINIT.TabStop = true;
            this.rbtNOINIT.Text = "Append to the existing backup set";
            this.rbtNOINIT.UseVisualStyleBackColor = true;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(192, 98);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Size = new System.Drawing.Size(337, 96);
            this.radioGroup1.TabIndex = 8;
            // 
            // gbBackupSet
            // 
            this.gbBackupSet.Controls.Add(this.txtNameBK);
            this.gbBackupSet.Controls.Add(this.labelControl6);
            this.gbBackupSet.Controls.Add(this.labelControl7);
            this.gbBackupSet.Controls.Add(this.txtDescription);
            this.gbBackupSet.Location = new System.Drawing.Point(16, 246);
            this.gbBackupSet.Name = "gbBackupSet";
            this.gbBackupSet.Size = new System.Drawing.Size(675, 122);
            this.gbBackupSet.TabIndex = 17;
            this.gbBackupSet.TabStop = false;
            this.gbBackupSet.Text = "Backup set";
            // 
            // gbDestination
            // 
            this.gbDestination.Controls.Add(this.cbDeviceName);
            this.gbDestination.Controls.Add(this.labelControl3);
            this.gbDestination.Location = new System.Drawing.Point(16, 374);
            this.gbDestination.Name = "gbDestination";
            this.gbDestination.Size = new System.Drawing.Size(675, 86);
            this.gbDestination.TabIndex = 18;
            this.gbDestination.TabStop = false;
            this.gbDestination.Text = "Destination";
            // 
            // sYSBACKUP_DEVICETableAdapter
            // 
            this.sYSBACKUP_DEVICETableAdapter.ClearBeforeFill = true;
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
            // sp_DanhSachBackupBindingSource
            // 
            this.sp_DanhSachBackupBindingSource.DataMember = "sp_DanhSachBackup";
            this.sp_DanhSachBackupBindingSource.DataSource = this.qLTVDataSet;
            // 
            // sp_DanhSachBackupTableAdapter
            // 
            this.sp_DanhSachBackupTableAdapter.ClearBeforeFill = true;
            // 
            // FS_Backup
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 581);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbSource);
            this.Controls.Add(this.gbBackupSet);
            this.Controls.Add(this.gbDestination);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FS_Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Back Up Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FS_Backup_FormClosing);
            this.Load += new System.EventHandler(this.FS_Backup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qLTVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSysBKDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameBK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.gbBackupSet.ResumeLayout(false);
            this.gbBackupSet.PerformLayout();
            this.gbDestination.ResumeLayout(false);
            this.gbDestination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp_DanhSachBackupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private QLTVDataSet qLTVDataSet;
        private System.Windows.Forms.ComboBox cbBackupType;
        private DevExpress.XtraEditors.TextEdit txtDBName;
        private System.Windows.Forms.ComboBox cbDeviceName;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtNameBK;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.GroupBox gbBackupSet;
        private System.Windows.Forms.GroupBox gbDestination;
        private System.Windows.Forms.BindingSource bdsSysBKDevice;
        private QLTVDataSetTableAdapters.SYSBACKUP_DEVICETableAdapter sYSBACKUP_DEVICETableAdapter;
        private QLTVDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.RadioButton rbtINIT;
        private System.Windows.Forms.RadioButton rbtNOINIT;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.BindingSource sp_DanhSachBackupBindingSource;
        private QLTVDataSetTableAdapters.sp_DanhSachBackupTableAdapter sp_DanhSachBackupTableAdapter;
    }
}