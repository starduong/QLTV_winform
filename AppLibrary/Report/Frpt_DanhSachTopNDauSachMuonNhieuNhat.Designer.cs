namespace AppLibrary.Report
{
    partial class Frpt_DanhSachTopNDauSachMuonNhieuNhat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frpt_DanhSachTopNDauSachMuonNhieuNhat));
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.numTopNDauSach = new System.Windows.Forms.NumericUpDown();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.numTopNDauSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Appearance.BorderColor = System.Drawing.Color.Blue;
            this.btnPreview.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Appearance.Options.UseBorderColor = true;
            this.btnPreview.Appearance.Options.UseFont = true;
            this.btnPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.ImageOptions.Image")));
            this.btnPreview.Location = new System.Drawing.Point(212, 224);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(292, 41);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "PreviewReport";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(212, 57);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(4);
            this.dtpTuNgay.MaximumSize = new System.Drawing.Size(304, 30);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(304, 26);
            this.dtpTuNgay.TabIndex = 1;
            this.dtpTuNgay.ValueChanged += new System.EventHandler(this.dtpTuNgay_ValueChanged);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(212, 111);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDenNgay.MaximumSize = new System.Drawing.Size(304, 30);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(304, 26);
            this.dtpDenNgay.TabIndex = 2;
            this.dtpDenNgay.ValueChanged += new System.EventHandler(this.dtpDenNgay_ValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(122, 63);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 23);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Từ ngày:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(113, 111);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 23);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Đến ngày:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(65, 172);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(134, 23);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Top N đầu sách:";
            // 
            // numTopNDauSach
            // 
            this.numTopNDauSach.Location = new System.Drawing.Point(212, 169);
            this.numTopNDauSach.Name = "numTopNDauSach";
            this.numTopNDauSach.Size = new System.Drawing.Size(162, 26);
            this.numTopNDauSach.TabIndex = 8;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dtpDenNgay);
            this.groupControl1.Controls.Add(this.numTopNDauSach);
            this.groupControl1.Controls.Add(this.btnPreview);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.dtpTuNgay);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(999, 607);
            this.groupControl1.TabIndex = 9;
            // 
            // Frpt_DanhSachTopNDauSachMuonNhieuNhat
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 607);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frpt_DanhSachTopNDauSachMuonNhieuNhat";
            this.Text = "Danh mục đầu sách mượn nhiều nhất";
            this.Load += new System.EventHandler(this.Frpt_DanhSachTopNDauSachMuonNhieuNhat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTopNDauSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.NumericUpDown numTopNDauSach;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}