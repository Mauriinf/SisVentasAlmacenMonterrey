namespace CapaPresentacion
{
    partial class FrmReporteProveedores
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DSPrincipal = new CapaPresentacion.DSPrincipal();
            this.ReporteProveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteProveedoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "ReporteProveedores";
            reportDataSource2.Value = this.ReporteProveedoresBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.RptReporteProveedores.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(918, 672);
            this.reportViewer1.TabIndex = 0;
            // 
            // DSPrincipal
            // 
            this.DSPrincipal.DataSetName = "DSPrincipal";
            this.DSPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReporteProveedoresBindingSource
            // 
            this.ReporteProveedoresBindingSource.DataMember = "ReporteProveedores";
            this.ReporteProveedoresBindingSource.DataSource = this.DSPrincipal;
            // 
            // FrmReporteProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 672);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteProveedores";
            this.Text = ".::: Reporte Proveedores :::.";
            this.Load += new System.EventHandler(this.FrmReporteProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteProveedoresBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteProveedoresBindingSource;
        private DSPrincipal DSPrincipal;
    }
}