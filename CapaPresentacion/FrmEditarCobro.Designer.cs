namespace CapaPresentacion
{
    partial class FrmEditarCobro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarCobro));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dtFechaCobro = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRebaja = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalapagar = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNrofactura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeudaanterior = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtIdCobro = new System.Windows.Forms.TextBox();
            this.txtDeudapendiente = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtIdventa = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dataListadoCobro = new System.Windows.Forms.DataGridView();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCobro)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.BackColor = System.Drawing.Color.Orange;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(229, 13);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 82);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseHover += new System.EventHandler(this.btnCancelar_MouseHover);
            // 
            // dtFechaCobro
            // 
            this.dtFechaCobro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFechaCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaCobro.Location = new System.Drawing.Point(140, 197);
            this.dtFechaCobro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFechaCobro.Name = "dtFechaCobro";
            this.dtFechaCobro.Size = new System.Drawing.Size(239, 25);
            this.dtFechaCobro.TabIndex = 13;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(9, 197);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "Fecha :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rebaja:";
            // 
            // txtRebaja
            // 
            this.txtRebaja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRebaja.BackColor = System.Drawing.Color.White;
            this.txtRebaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRebaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebaja.Location = new System.Drawing.Point(140, 293);
            this.txtRebaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRebaja.Name = "txtRebaja";
            this.txtRebaja.Size = new System.Drawing.Size(240, 25);
            this.txtRebaja.TabIndex = 15;
            this.txtRebaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRebaja_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total a Pagar:";
            // 
            // txtTotalapagar
            // 
            this.txtTotalapagar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalapagar.BackColor = System.Drawing.Color.White;
            this.txtTotalapagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalapagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalapagar.Location = new System.Drawing.Point(140, 242);
            this.txtTotalapagar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalapagar.Name = "txtTotalapagar";
            this.txtTotalapagar.Size = new System.Drawing.Size(240, 25);
            this.txtTotalapagar.TabIndex = 14;
            this.txtTotalapagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalapagar_KeyPress);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 20);
            this.label15.TabIndex = 3;
            this.label15.Text = "Nro de Factura:";
            // 
            // txtNrofactura
            // 
            this.txtNrofactura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNrofactura.BackColor = System.Drawing.Color.White;
            this.txtNrofactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNrofactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNrofactura.Location = new System.Drawing.Point(140, 113);
            this.txtNrofactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNrofactura.Name = "txtNrofactura";
            this.txtNrofactura.Size = new System.Drawing.Size(240, 25);
            this.txtNrofactura.TabIndex = 11;
            this.txtNrofactura.TextChanged += new System.EventHandler(this.txtNrofactura_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Deuda Anterior:";
            // 
            // txtDeudaanterior
            // 
            this.txtDeudaanterior.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeudaanterior.BackColor = System.Drawing.Color.White;
            this.txtDeudaanterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeudaanterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeudaanterior.Location = new System.Drawing.Point(140, 154);
            this.txtDeudaanterior.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDeudaanterior.Name = "txtDeudaanterior";
            this.txtDeudaanterior.Size = new System.Drawing.Size(240, 25);
            this.txtDeudaanterior.TabIndex = 12;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtIdCobro);
            this.groupBox5.Controls.Add(this.dtFechaCobro);
            this.groupBox5.Controls.Add(this.txtDeudapendiente);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.txtIdventa);
            this.groupBox5.Controls.Add(this.txtCliente);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.txtDeudaanterior);
            this.groupBox5.Controls.Add(this.txtTotalapagar);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtNrofactura);
            this.groupBox5.Controls.Add(this.txtRebaja);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 110);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(430, 336);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datos Cobros";
            // 
            // txtIdCobro
            // 
            this.txtIdCobro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdCobro.BackColor = System.Drawing.Color.White;
            this.txtIdCobro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdCobro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCobro.Location = new System.Drawing.Point(140, 30);
            this.txtIdCobro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdCobro.Name = "txtIdCobro";
            this.txtIdCobro.Size = new System.Drawing.Size(240, 25);
            this.txtIdCobro.TabIndex = 8;
            // 
            // txtDeudapendiente
            // 
            this.txtDeudapendiente.BackColor = System.Drawing.Color.White;
            this.txtDeudapendiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeudapendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeudapendiente.Location = new System.Drawing.Point(217, 0);
            this.txtDeudapendiente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDeudapendiente.Name = "txtDeudapendiente";
            this.txtDeudapendiente.Size = new System.Drawing.Size(91, 25);
            this.txtDeudapendiente.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(7, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(110, 20);
            this.label22.TabIndex = 0;
            this.label22.Text = "Código Venta:";
            // 
            // txtIdventa
            // 
            this.txtIdventa.BackColor = System.Drawing.Color.White;
            this.txtIdventa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdventa.Location = new System.Drawing.Point(140, 0);
            this.txtIdventa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtIdventa.Name = "txtIdventa";
            this.txtIdventa.Size = new System.Drawing.Size(53, 25);
            this.txtIdventa.TabIndex = 7;
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(140, 71);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(240, 25);
            this.txtCliente.TabIndex = 10;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(7, 76);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 20);
            this.label20.TabIndex = 1;
            this.label20.Text = "Cliente:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEliminar.BackColor = System.Drawing.Color.Orange;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(110, 13);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 82);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnEliminar.MouseLeave += new System.EventHandler(this.btnEliminar_MouseLeave);
            this.btnEliminar.MouseHover += new System.EventHandler(this.btnEliminar_MouseHover);
            // 
            // dataListadoCobro
            // 
            this.dataListadoCobro.AllowUserToAddRows = false;
            this.dataListadoCobro.AllowUserToDeleteRows = false;
            this.dataListadoCobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoCobro.Location = new System.Drawing.Point(333, 14);
            this.dataListadoCobro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataListadoCobro.Name = "dataListadoCobro";
            this.dataListadoCobro.RowTemplate.Height = 24;
            this.dataListadoCobro.Size = new System.Drawing.Size(109, 81);
            this.dataListadoCobro.TabIndex = 2;
            // 
            // FrmEditarCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(458, 460);
            this.Controls.Add(this.dataListadoCobro);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnCancelar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmEditarCobro";
            this.Text = ".:: Editar Cobro ::.";
            this.Load += new System.EventHandler(this.FrmEditarCobro_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCobro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnEliminar;
        public System.Windows.Forms.DateTimePicker dtFechaCobro;
        public System.Windows.Forms.TextBox txtRebaja;
        public System.Windows.Forms.TextBox txtTotalapagar;
        public System.Windows.Forms.TextBox txtNrofactura;
        public System.Windows.Forms.TextBox txtDeudaanterior;
        public System.Windows.Forms.TextBox txtDeudapendiente;
        public System.Windows.Forms.TextBox txtIdventa;
        public System.Windows.Forms.TextBox txtCliente;
        public System.Windows.Forms.TextBox txtIdCobro;
        private System.Windows.Forms.DataGridView dataListadoCobro;
    }
}