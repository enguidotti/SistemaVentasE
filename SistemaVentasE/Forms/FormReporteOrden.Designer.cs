
namespace SistemaVentasE.Forms
{
    partial class FormReporteOrden
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.rvOrden = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OrdenAuxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OrdenAuxBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(567, 90);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 34);
            this.btnBuscar.TabIndex = 39;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFactura
            // 
            this.txtFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFactura.Location = new System.Drawing.Point(223, 94);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(300, 26);
            this.txtFactura.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Número Factura";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.Location = new System.Drawing.Point(179, 23);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(387, 31);
            this.lblSubtitulo.TabIndex = 36;
            this.lblSubtitulo.Text = "Orden de compra por factura";
            // 
            // rvOrden
            // 
            this.rvOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "Orden";
            reportDataSource1.Value = this.OrdenAuxBindingSource;
            this.rvOrden.LocalReport.DataSources.Add(reportDataSource1);
            this.rvOrden.LocalReport.ReportEmbeddedResource = "SistemaVentasE.Reportes.OrdenCompra.rdlc";
            this.rvOrden.Location = new System.Drawing.Point(82, 183);
            this.rvOrden.Name = "rvOrden";
            this.rvOrden.ServerReport.BearerToken = null;
            this.rvOrden.Size = new System.Drawing.Size(575, 246);
            this.rvOrden.TabIndex = 40;
            this.rvOrden.Visible = false;
            // 
            // OrdenAuxBindingSource
            // 
            this.OrdenAuxBindingSource.DataSource = typeof(SistemaVentasE.Model.OrdenAux);
            // 
            // FormReporteOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvOrden);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSubtitulo);
            this.Name = "FormReporteOrden";
            this.Text = "FormReporteOrden";
            this.Load += new System.EventHandler(this.FormReporteOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdenAuxBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSubtitulo;
        private Microsoft.Reporting.WinForms.ReportViewer rvOrden;
        private System.Windows.Forms.BindingSource OrdenAuxBindingSource;
    }
}