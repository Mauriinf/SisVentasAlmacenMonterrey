namespace CapaPresentacion
{
    partial class FrmEditarDetalleVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarDetalleVentas));
            this.lblTotal = new System.Windows.Forms.Label();
            this.dataListadoDetalle = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAlcontado = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtContado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdevoluciones = new System.Windows.Forms.TextBox();
            this.txtIdDetalleIngreso = new System.Windows.Forms.TextBox();
            this.txtIddetalleVenta = new System.Windows.Forms.TextBox();
            this.txtnrocomprobante = new System.Windows.Forms.TextBox();
            this.txtIdVenta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblPorCobrar = new System.Windows.Forms.Label();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStockactual = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.txtRebaja = new System.Windows.Forms.TextBox();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dataListadoCobro = new System.Windows.Forms.DataGridView();
            this.txtContadoActual = new System.Windows.Forms.TextBox();
            this.txtRebajasHastaLaFecha = new System.Windows.Forms.TextBox();
            this.btnDevolucion = new System.Windows.Forms.Button();
            this.btnsiguiente = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnatras = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCobro)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(140, 107);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(59, 20);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "label3";
            // 
            // dataListadoDetalle
            // 
            this.dataListadoDetalle.AllowUserToAddRows = false;
            this.dataListadoDetalle.AllowUserToDeleteRows = false;
            this.dataListadoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoDetalle.Location = new System.Drawing.Point(668, 14);
            this.dataListadoDetalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataListadoDetalle.Name = "dataListadoDetalle";
            this.dataListadoDetalle.RowTemplate.Height = 24;
            this.dataListadoDetalle.Size = new System.Drawing.Size(168, 81);
            this.dataListadoDetalle.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtAlcontado);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtContado);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtdevoluciones);
            this.groupBox5.Controls.Add(this.txtIdDetalleIngreso);
            this.groupBox5.Controls.Add(this.txtIddetalleVenta);
            this.groupBox5.Controls.Add(this.txtnrocomprobante);
            this.groupBox5.Controls.Add(this.txtIdVenta);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.btnBuscarProducto);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.lblEstado);
            this.groupBox5.Controls.Add(this.lblPorCobrar);
            this.groupBox5.Controls.Add(this.lblImporteTotal);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txtPrecio);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtStockactual);
            this.groupBox5.Controls.Add(this.txtCantidad);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.txtProducto);
            this.groupBox5.Controls.Add(this.txtIdProducto);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 138);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(865, 203);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pago al contado:";
            // 
            // txtAlcontado
            // 
            this.txtAlcontado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlcontado.BackColor = System.Drawing.Color.White;
            this.txtAlcontado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlcontado.Location = new System.Drawing.Point(495, 112);
            this.txtAlcontado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAlcontado.Name = "txtAlcontado";
            this.txtAlcontado.Size = new System.Drawing.Size(130, 25);
            this.txtAlcontado.TabIndex = 30;
            this.txtAlcontado.TextChanged += new System.EventHandler(this.txtAlcontado_TextChanged);
            this.txtAlcontado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlcontado_KeyPress);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(350, 164);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(128, 20);
            this.label15.TabIndex = 10;
            this.label15.Text = "Total Cancelado:";
            // 
            // txtContado
            // 
            this.txtContado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContado.BackColor = System.Drawing.Color.White;
            this.txtContado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContado.Location = new System.Drawing.Point(495, 164);
            this.txtContado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContado.Name = "txtContado";
            this.txtContado.Size = new System.Drawing.Size(130, 25);
            this.txtContado.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(631, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Devoluciones:";
            // 
            // txtdevoluciones
            // 
            this.txtdevoluciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdevoluciones.BackColor = System.Drawing.Color.White;
            this.txtdevoluciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdevoluciones.Location = new System.Drawing.Point(761, 22);
            this.txtdevoluciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdevoluciones.Name = "txtdevoluciones";
            this.txtdevoluciones.Size = new System.Drawing.Size(86, 25);
            this.txtdevoluciones.TabIndex = 21;
            this.txtdevoluciones.TextChanged += new System.EventHandler(this.txtdevoluciones_TextChanged);
            this.txtdevoluciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdevoluciones_KeyPress);
            // 
            // txtIdDetalleIngreso
            // 
            this.txtIdDetalleIngreso.BackColor = System.Drawing.Color.White;
            this.txtIdDetalleIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdDetalleIngreso.Location = new System.Drawing.Point(495, -9);
            this.txtIdDetalleIngreso.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdDetalleIngreso.Name = "txtIdDetalleIngreso";
            this.txtIdDetalleIngreso.Size = new System.Drawing.Size(122, 25);
            this.txtIdDetalleIngreso.TabIndex = 14;
            // 
            // txtIddetalleVenta
            // 
            this.txtIddetalleVenta.BackColor = System.Drawing.Color.White;
            this.txtIddetalleVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIddetalleVenta.Location = new System.Drawing.Point(351, -5);
            this.txtIddetalleVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtIddetalleVenta.Name = "txtIddetalleVenta";
            this.txtIddetalleVenta.Size = new System.Drawing.Size(122, 25);
            this.txtIddetalleVenta.TabIndex = 5;
            // 
            // txtnrocomprobante
            // 
            this.txtnrocomprobante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnrocomprobante.BackColor = System.Drawing.Color.White;
            this.txtnrocomprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnrocomprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnrocomprobante.Location = new System.Drawing.Point(152, 27);
            this.txtnrocomprobante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnrocomprobante.Name = "txtnrocomprobante";
            this.txtnrocomprobante.Size = new System.Drawing.Size(139, 25);
            this.txtnrocomprobante.TabIndex = 22;
            // 
            // txtIdVenta
            // 
            this.txtIdVenta.BackColor = System.Drawing.Color.White;
            this.txtIdVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdVenta.Location = new System.Drawing.Point(199, -6);
            this.txtIdVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdVenta.Name = "txtIdVenta";
            this.txtIdVenta.Size = new System.Drawing.Size(122, 25);
            this.txtIdVenta.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro Comprobante:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "ID Producto:";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarProducto.BackgroundImage")));
            this.btnBuscarProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarProducto.FlatAppearance.BorderSize = 0;
            this.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProducto.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarProducto.Location = new System.Drawing.Point(298, 69);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(71, 42);
            this.btnBuscarProducto.TabIndex = 23;
            this.btnBuscarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(819, 91);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(32, 20);
            this.label27.TabIndex = 19;
            this.label27.Text = "Bs.";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(819, 56);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 20);
            this.label26.TabIndex = 20;
            this.label26.Text = "Bs.";
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(757, 133);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(82, 20);
            this.lblEstado.TabIndex = 18;
            this.lblEstado.Text = "Por cobrar";
            // 
            // lblPorCobrar
            // 
            this.lblPorCobrar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorCobrar.AutoSize = true;
            this.lblPorCobrar.Location = new System.Drawing.Point(751, 95);
            this.lblPorCobrar.Name = "lblPorCobrar";
            this.lblPorCobrar.Size = new System.Drawing.Size(49, 20);
            this.lblPorCobrar.TabIndex = 17;
            this.lblPorCobrar.Text = "00.00";
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImporteTotal.AutoSize = true;
            this.lblImporteTotal.Location = new System.Drawing.Point(751, 61);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(49, 20);
            this.lblImporteTotal.TabIndex = 16;
            this.lblImporteTotal.Text = "00.00";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(670, 133);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 20);
            this.label18.TabIndex = 15;
            this.label18.Text = "Estado:";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(645, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 20);
            this.label17.TabIndex = 13;
            this.label17.Text = "Por Cobrar:";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(627, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 20);
            this.label16.TabIndex = 12;
            this.label16.Text = "Importe Total:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(421, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecio.BackColor = System.Drawing.Color.White;
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.Location = new System.Drawing.Point(495, 65);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(130, 25);
            this.txtPrecio.TabIndex = 28;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stock:";
            // 
            // txtStockactual
            // 
            this.txtStockactual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStockactual.BackColor = System.Drawing.Color.White;
            this.txtStockactual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockactual.Location = new System.Drawing.Point(152, 150);
            this.txtStockactual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStockactual.Name = "txtStockactual";
            this.txtStockactual.Size = new System.Drawing.Size(139, 25);
            this.txtStockactual.TabIndex = 26;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Location = new System.Drawing.Point(495, 25);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(130, 25);
            this.txtCantidad.TabIndex = 27;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(401, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Cantidad:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProducto.BackColor = System.Drawing.Color.White;
            this.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProducto.Location = new System.Drawing.Point(152, 107);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(139, 25);
            this.txtProducto.TabIndex = 25;
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdProducto.BackColor = System.Drawing.Color.White;
            this.txtIdProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdProducto.Location = new System.Drawing.Point(152, 65);
            this.txtIdProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(139, 25);
            this.txtIdProducto.TabIndex = 24;
            // 
            // txtRebaja
            // 
            this.txtRebaja.BackColor = System.Drawing.Color.White;
            this.txtRebaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRebaja.Location = new System.Drawing.Point(767, 374);
            this.txtRebaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRebaja.Name = "txtRebaja";
            this.txtRebaja.Size = new System.Drawing.Size(130, 22);
            this.txtRebaja.TabIndex = 29;
            this.txtRebaja.TextChanged += new System.EventHandler(this.txtRebaja_TextChanged);
            this.txtRebaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRebaja_KeyPress);
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(773, 109);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 24);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Devolver";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // dataListadoCobro
            // 
            this.dataListadoCobro.AllowUserToAddRows = false;
            this.dataListadoCobro.AllowUserToDeleteRows = false;
            this.dataListadoCobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoCobro.Location = new System.Drawing.Point(12, 11);
            this.dataListadoCobro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataListadoCobro.Name = "dataListadoCobro";
            this.dataListadoCobro.RowTemplate.Height = 24;
            this.dataListadoCobro.Size = new System.Drawing.Size(168, 81);
            this.dataListadoCobro.TabIndex = 0;
            // 
            // txtContadoActual
            // 
            this.txtContadoActual.BackColor = System.Drawing.Color.White;
            this.txtContadoActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContadoActual.Location = new System.Drawing.Point(660, 319);
            this.txtContadoActual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContadoActual.Name = "txtContadoActual";
            this.txtContadoActual.Size = new System.Drawing.Size(86, 22);
            this.txtContadoActual.TabIndex = 5;
            // 
            // txtRebajasHastaLaFecha
            // 
            this.txtRebajasHastaLaFecha.BackColor = System.Drawing.Color.White;
            this.txtRebajasHastaLaFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRebajasHastaLaFecha.Location = new System.Drawing.Point(660, 345);
            this.txtRebajasHastaLaFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRebajasHastaLaFecha.Name = "txtRebajasHastaLaFecha";
            this.txtRebajasHastaLaFecha.Size = new System.Drawing.Size(86, 22);
            this.txtRebajasHastaLaFecha.TabIndex = 15;
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDevolucion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDevolucion.BackgroundImage")));
            this.btnDevolucion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDevolucion.FlatAppearance.BorderSize = 0;
            this.btnDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevolucion.ForeColor = System.Drawing.Color.White;
            this.btnDevolucion.Image = ((System.Drawing.Image)(resources.GetObject("btnDevolucion.Image")));
            this.btnDevolucion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDevolucion.Location = new System.Drawing.Point(246, 14);
            this.btnDevolucion.Margin = new System.Windows.Forms.Padding(4);
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.Size = new System.Drawing.Size(98, 82);
            this.btnDevolucion.TabIndex = 7;
            this.btnDevolucion.Text = "&Devolucion";
            this.btnDevolucion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDevolucion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDevolucion.UseVisualStyleBackColor = true;
            this.btnDevolucion.Click += new System.EventHandler(this.button1_Click);
            this.btnDevolucion.MouseLeave += new System.EventHandler(this.btnDevolucion_MouseLeave);
            this.btnDevolucion.MouseHover += new System.EventHandler(this.btnDevolucion_MouseHover);
            // 
            // btnsiguiente
            // 
            this.btnsiguiente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnsiguiente.BackgroundImage = global::CapaPresentacion.Properties.Resources.siguiente;
            this.btnsiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsiguiente.FlatAppearance.BorderSize = 0;
            this.btnsiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsiguiente.ForeColor = System.Drawing.Color.Black;
            this.btnsiguiente.Location = new System.Drawing.Point(454, 355);
            this.btnsiguiente.Margin = new System.Windows.Forms.Padding(4);
            this.btnsiguiente.Name = "btnsiguiente";
            this.btnsiguiente.Size = new System.Drawing.Size(71, 42);
            this.btnsiguiente.TabIndex = 11;
            this.btnsiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsiguiente.UseVisualStyleBackColor = true;
            this.btnsiguiente.Click += new System.EventHandler(this.btnsiguiente_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrimero.BackgroundImage = global::CapaPresentacion.Properties.Resources.primero;
            this.btnPrimero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrimero.FlatAppearance.BorderSize = 0;
            this.btnPrimero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimero.ForeColor = System.Drawing.Color.Black;
            this.btnPrimero.Location = new System.Drawing.Point(300, 355);
            this.btnPrimero.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(71, 42);
            this.btnPrimero.TabIndex = 14;
            this.btnPrimero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrimero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUltimo.BackgroundImage = global::CapaPresentacion.Properties.Resources.Ultimo;
            this.btnUltimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUltimo.FlatAppearance.BorderSize = 0;
            this.btnUltimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimo.ForeColor = System.Drawing.Color.Black;
            this.btnUltimo.Location = new System.Drawing.Point(531, 355);
            this.btnUltimo.Margin = new System.Windows.Forms.Padding(4);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(71, 42);
            this.btnUltimo.TabIndex = 13;
            this.btnUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUltimo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnatras
            // 
            this.btnatras.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnatras.BackgroundImage = global::CapaPresentacion.Properties.Resources.atras;
            this.btnatras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnatras.FlatAppearance.BorderSize = 0;
            this.btnatras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnatras.ForeColor = System.Drawing.Color.Black;
            this.btnatras.Location = new System.Drawing.Point(375, 355);
            this.btnatras.Margin = new System.Windows.Forms.Padding(4);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(71, 42);
            this.btnatras.TabIndex = 12;
            this.btnatras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnatras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Location = new System.Drawing.Point(468, 13);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 82);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnEliminar.MouseLeave += new System.EventHandler(this.btnEliminar_MouseLeave);
            this.btnEliminar.MouseHover += new System.EventHandler(this.btnEliminar_MouseHover);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelar.BackgroundImage")));
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(578, 13);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 82);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseHover += new System.EventHandler(this.btnCancelar_MouseHover);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnModificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModificar.BackgroundImage")));
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.Location = new System.Drawing.Point(363, 13);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(83, 82);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            this.btnModificar.MouseLeave += new System.EventHandler(this.btnModificar_MouseLeave);
            this.btnModificar.MouseHover += new System.EventHandler(this.btnModificar_MouseHover);
            // 
            // FrmEditarDetalleVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(891, 410);
            this.Controls.Add(this.txtRebajasHastaLaFecha);
            this.Controls.Add(this.txtContadoActual);
            this.Controls.Add(this.dataListadoCobro);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnDevolucion);
            this.Controls.Add(this.btnsiguiente);
            this.Controls.Add(this.btnPrimero);
            this.Controls.Add(this.btnUltimo);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dataListadoDetalle);
            this.Controls.Add(this.txtRebaja);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEditarDetalleVentas";
            this.Text = ".:: Editar Detalle Venta ::.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditarDetalleVentas_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditarDetalleVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCobro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dataListadoDetalle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblPorCobrar;
        private System.Windows.Forms.Label lblImporteTotal;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRebaja;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStockactual;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.TextBox txtIddetalleVenta;
        public System.Windows.Forms.TextBox txtIdVenta;
        public System.Windows.Forms.TextBox txtnrocomprobante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnsiguiente;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.TextBox txtIdDetalleIngreso;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtdevoluciones;
        private System.Windows.Forms.Button btnDevolucion;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dataListadoCobro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlcontado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtContado;
        private System.Windows.Forms.TextBox txtContadoActual;
        private System.Windows.Forms.TextBox txtRebajasHastaLaFecha;
    }
}