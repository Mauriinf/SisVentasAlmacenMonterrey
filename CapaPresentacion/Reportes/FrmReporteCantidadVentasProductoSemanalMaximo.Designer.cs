namespace CapaPresentacion
{
    partial class FrmReporteCantidadVentasProductoSemanalMaximo
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
            this.ReporteCantidadVentasProductoMaximoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSPrincipal = new CapaPresentacion.DSPrincipal();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dtFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dtFecha1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteCantidadVentasProductoMaximoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // ReporteCantidadVentasProductoMaximoBindingSource
            // 
            this.ReporteCantidadVentasProductoMaximoBindingSource.DataMember = "ReporteCantidadVentasProductoMaximo";
            this.ReporteCantidadVentasProductoMaximoBindingSource.DataSource = this.DSPrincipal;
            // 
            // DSPrincipal
            // 
            this.DSPrincipal.DataSetName = "DSPrincipal";
            this.DSPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "ReporteCantidadVentasProductoSemanalMaximo";
            reportDataSource2.Value = this.ReporteCantidadVentasProductoMaximoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reportes.ReporteSemanalTotalesProductoMaximo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 41);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1077, 629);
            this.reportViewer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(687, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 33);
            this.button1.TabIndex = 86;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(479, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 20);
            this.label9.TabIndex = 85;
            this.label9.Text = "Al:";
            // 
            // dtFecha2
            // 
            this.dtFecha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha2.Location = new System.Drawing.Point(512, 11);
            this.dtFecha2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFecha2.Name = "dtFecha2";
            this.dtFecha2.Size = new System.Drawing.Size(143, 25);
            this.dtFecha2.TabIndex = 84;
            // 
            // dtFecha1
            // 
            this.dtFecha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha1.Location = new System.Drawing.Point(341, 11);
            this.dtFecha1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFecha1.Name = "dtFecha1";
            this.dtFecha1.Size = new System.Drawing.Size(132, 25);
            this.dtFecha1.TabIndex = 83;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(298, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 82;
            this.label8.Text = "Del:";
            // 
            // FrmReporteCantidadVentasProductoSemanalMaximo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(1083, 682);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtFecha2);
            this.Controls.Add(this.dtFecha1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteCantidadVentasProductoSemanalMaximo";
            this.Text = ".::: Informe Cantidad Ventas Maximo :::.";
            this.Load += new System.EventHandler(this.FrmReporteCantidadVentasProductoSemanalMaximo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteCantidadVentasProductoMaximoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtFecha2;
        private System.Windows.Forms.DateTimePicker dtFecha1;
        private System.Windows.Forms.Label label8;
        private DSPrincipal DSPrincipal;
        private System.Windows.Forms.BindingSource ReporteCantidadVentasProductoMaximoBindingSource;
    }
}