namespace CapaPresentacion
{
    partial class FrmReporteConductores
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DSPrincipal = new CapaPresentacion.DSPrincipal();
            this.Reporte_ConductorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_ConductorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ReporteConductores";
            reportDataSource1.Value = this.Reporte_ConductorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.RptReporteConductor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(830, 617);
            this.reportViewer1.TabIndex = 0;
            // 
            // DSPrincipal
            // 
            this.DSPrincipal.DataSetName = "DSPrincipal";
            this.DSPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Reporte_ConductorBindingSource
            // 
            this.Reporte_ConductorBindingSource.DataMember = "Reporte Conductor";
            this.Reporte_ConductorBindingSource.DataSource = this.DSPrincipal;
            // 
            // FrmReporteConductores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(830, 617);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteConductores";
            this.Text = ".::: Reporte Conductores :::.";
            this.Load += new System.EventHandler(this.FrmReporteConductores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_ConductorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DSPrincipal DSPrincipal;
        private System.Windows.Forms.BindingSource Reporte_ConductorBindingSource;
    }
}