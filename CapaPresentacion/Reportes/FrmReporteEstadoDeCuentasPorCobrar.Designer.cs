namespace CapaPresentacion
{
    partial class FrmReporteEstadoDeCuentasPorCobrar
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
            this.ReporteEstadoCuentasPorCobrarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSPrincipal = new CapaPresentacion.DSPrincipal();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dtFecha1 = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteEstadoCuentasPorCobrarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // ReporteEstadoCuentasPorCobrarBindingSource
            // 
            this.ReporteEstadoCuentasPorCobrarBindingSource.DataMember = "ReporteEstadoCuentasPorCobrar";
            this.ReporteEstadoCuentasPorCobrarBindingSource.DataSource = this.DSPrincipal;
            // 
            // DSPrincipal
            // 
            this.DSPrincipal.DataSetName = "DSPrincipal";
            this.DSPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(637, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 33);
            this.button1.TabIndex = 71;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(442, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 20);
            this.label9.TabIndex = 70;
            this.label9.Text = "Al:";
            // 
            // dtFecha1
            // 
            this.dtFecha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha1.Location = new System.Drawing.Point(478, 11);
            this.dtFecha1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFecha1.Name = "dtFecha1";
            this.dtFecha1.Size = new System.Drawing.Size(132, 25);
            this.dtFecha1.TabIndex = 68;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "InformeEstadoCuentasPorCobrar";
            reportDataSource2.Value = this.ReporteEstadoCuentasPorCobrarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.RptInformeEstadoCuentasPorCobrarHastaLaFecha.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(6, 41);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1075, 609);
            this.reportViewer1.TabIndex = 72;
            // 
            // FrmReporteEstadoDeCuentasPorCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(1088, 656);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtFecha1);
            this.Name = "FrmReporteEstadoDeCuentasPorCobrar";
            this.Text = ".::: Reporte Estado De Cuentas Por Cobrar :::.";
            this.Load += new System.EventHandler(this.FrmReporteEstadoDeCuentasPorCobrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteEstadoCuentasPorCobrarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtFecha1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteEstadoCuentasPorCobrarBindingSource;
        private DSPrincipal DSPrincipal;
    }
}