
namespace SistemaVentasE.Forms
{
    partial class FormReporteMarca
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvMarca = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MarcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MarcaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvMarca
            // 
            this.rvMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "Marca";
            reportDataSource1.Value = this.MarcaBindingSource;
            this.rvMarca.LocalReport.DataSources.Add(reportDataSource1);
            this.rvMarca.LocalReport.ReportEmbeddedResource = "SistemaVentasE.Reportes.Marca.rdlc";
            this.rvMarca.Location = new System.Drawing.Point(75, 58);
            this.rvMarca.Name = "rvMarca";
            this.rvMarca.ServerReport.BearerToken = null;
            this.rvMarca.Size = new System.Drawing.Size(633, 322);
            this.rvMarca.TabIndex = 0;
            // 
            // MarcaBindingSource
            // 
            this.MarcaBindingSource.DataSource = typeof(SistemaVentasE.Model.Marca);
            // 
            // FormReporteMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvMarca);
            this.Name = "FormReporteMarca";
            this.Text = "FormReporteMarca";
            this.Load += new System.EventHandler(this.FormReporteMarca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MarcaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvMarca;
        private System.Windows.Forms.BindingSource MarcaBindingSource;
    }
}