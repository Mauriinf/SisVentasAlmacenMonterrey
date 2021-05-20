namespace CapaPresentacion
{
    partial class FrmReporteClientes
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
            this.DSPrincipal = new CapaPresentacion.DSPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReporteClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DSPrincipal
            // 
            this.DSPrincipal.DataSetName = "DSPrincipal";
            this.DSPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Clientes";
            reportDataSource1.Value = this.ReporteClientesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.RptCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1013, 612);
            this.reportViewer1.TabIndex = 0;
            // 
            // ReporteClientesBindingSource
            // 
            this.ReporteClientesBindingSource.DataMember = "ReporteClientes";
            this.ReporteClientesBindingSource.DataSource = this.DSPrincipal;
            // 
            // FrmReporteClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 612);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteClientes";
            this.Text = ".::: Reporte Clientes :::.";
            this.Load += new System.EventHandler(this.FrmReporteClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteClientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DSPrincipal DSPrincipal;
        private System.Windows.Forms.BindingSource ReporteClientesBindingSource;
    }
}