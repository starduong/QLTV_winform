namespace AppLibrary.Report
{
    partial class Frpt_DanhSachDGMuonSachQuaHan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frpt_DanhSachDGMuonSachQuaHan));
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.ImageOptions.Image")));
            this.btnPreview.Location = new System.Drawing.Point(247, 58);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(141, 34);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "PreviewReport\r\n";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // Frpt_DanhSachDGMuonSachQuaHan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 451);
            this.Controls.Add(this.btnPreview);
            this.Name = "Frpt_DanhSachDGMuonSachQuaHan";
            this.Text = "Báo cáo danh sách độc giả mượn sách quá hạn";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPreview;
    }
}