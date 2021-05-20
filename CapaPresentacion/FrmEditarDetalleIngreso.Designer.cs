namespace CapaPresentacion
{
    partial class FrmEditarDetalleIngreso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarDetalleIngreso));
            this.dataListadoDetalle = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbProducto = new System.Windows.Forms.ComboBox();
            this.txtTotalporCancelar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalcancelado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtnrocomprobante = new System.Windows.Forms.TextBox();
            this.txtIddetalleingreso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdingreso = new System.Windows.Forms.TextBox();
            this.txtCarguioContado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtFleteContado = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCargioUnitario = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFleteUnitario = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.btnsiguiente = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnatras = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataListadoDetalle
            // 
            this.dataListadoDetalle.AllowUserToAddRows = false;
            this.dataListadoDetalle.AllowUserToDeleteRows = false;
            this.dataListadoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoDetalle.Location = new System.Drawing.Point(486, 14);
            this.dataListadoDetalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataListadoDetalle.Name = "dataListadoDetalle";
            this.dataListadoDetalle.RowTemplate.Height = 24;
            this.dataListadoDetalle.Size = new System.Drawing.Size(168, 81);
            this.dataListadoDetalle.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.cbProducto);
            this.groupBox5.Controls.Add(this.txtTotalporCancelar);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtTotalcancelado);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtStockActual);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtnrocomprobante);
            this.groupBox5.Controls.Add(this.txtIddetalleingreso);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtIdingreso);
            this.groupBox5.Controls.Add(this.txtCarguioContado);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.txtFleteContado);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.txtCargioUnitario);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.txtFleteUnitario);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtStock);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtIdProducto);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 129);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(690, 255);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalle Ingreso";
            // 
            // cbProducto
            // 
            this.cbProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProducto.FormattingEnabled = true;
            this.cbProducto.Location = new System.Drawing.Point(160, 107);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Size = new System.Drawing.Size(197, 26);
            this.cbProducto.TabIndex = 22;
            this.cbProducto.SelectedIndexChanged += new System.EventHandler(this.cbProducto_SelectedIndexChanged);
            // 
            // txtTotalporCancelar
            // 
            this.txtTotalporCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalporCancelar.BackColor = System.Drawing.Color.White;
            this.txtTotalporCancelar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalporCancelar.Location = new System.Drawing.Point(160, 216);
            this.txtTotalporCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalporCancelar.Name = "txtTotalporCancelar";
            this.txtTotalporCancelar.Size = new System.Drawing.Size(196, 25);
            this.txtTotalporCancelar.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Total Por Cancelar:";
            // 
            // txtTotalcancelado
            // 
            this.txtTotalcancelado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalcancelado.BackColor = System.Drawing.Color.White;
            this.txtTotalcancelado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalcancelado.Location = new System.Drawing.Point(160, 184);
            this.txtTotalcancelado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalcancelado.Name = "txtTotalcancelado";
            this.txtTotalcancelado.Size = new System.Drawing.Size(196, 25);
            this.txtTotalcancelado.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total Cancelado:";
            // 
            // txtStockActual
            // 
            this.txtStockActual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStockActual.BackColor = System.Drawing.Color.White;
            this.txtStockActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockActual.Location = new System.Drawing.Point(160, 146);
            this.txtStockActual.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(196, 25);
            this.txtStockActual.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Stock Inicial:";
            // 
            // txtnrocomprobante
            // 
            this.txtnrocomprobante.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnrocomprobante.BackColor = System.Drawing.Color.White;
            this.txtnrocomprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnrocomprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnrocomprobante.Location = new System.Drawing.Point(160, 39);
            this.txtnrocomprobante.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtnrocomprobante.Name = "txtnrocomprobante";
            this.txtnrocomprobante.Size = new System.Drawing.Size(196, 25);
            this.txtnrocomprobante.TabIndex = 20;
            // 
            // txtIddetalleingreso
            // 
            this.txtIddetalleingreso.BackColor = System.Drawing.Color.White;
            this.txtIddetalleingreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIddetalleingreso.Location = new System.Drawing.Point(336, 3);
            this.txtIddetalleingreso.Margin = new System.Windows.Forms.Padding(4);
            this.txtIddetalleingreso.Name = "txtIddetalleingreso";
            this.txtIddetalleingreso.Size = new System.Drawing.Size(122, 25);
            this.txtIddetalleingreso.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nro Comprobante:";
            // 
            // txtIdingreso
            // 
            this.txtIdingreso.BackColor = System.Drawing.Color.White;
            this.txtIdingreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdingreso.Location = new System.Drawing.Point(184, 2);
            this.txtIdingreso.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdingreso.Name = "txtIdingreso";
            this.txtIdingreso.Size = new System.Drawing.Size(122, 25);
            this.txtIdingreso.TabIndex = 13;
            // 
            // txtCarguioContado
            // 
            this.txtCarguioContado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarguioContado.BackColor = System.Drawing.Color.White;
            this.txtCarguioContado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarguioContado.Location = new System.Drawing.Point(513, 207);
            this.txtCarguioContado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCarguioContado.Name = "txtCarguioContado";
            this.txtCarguioContado.Size = new System.Drawing.Size(151, 25);
            this.txtCarguioContado.TabIndex = 6;
            this.txtCarguioContado.TextChanged += new System.EventHandler(this.txtCarguioContado_TextChanged);
            this.txtCarguioContado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCarguioContado_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Carguio contado:";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 80);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(98, 20);
            this.label24.TabIndex = 1;
            this.label24.Text = "ID Producto:";
            // 
            // txtFleteContado
            // 
            this.txtFleteContado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFleteContado.BackColor = System.Drawing.Color.White;
            this.txtFleteContado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFleteContado.Location = new System.Drawing.Point(513, 119);
            this.txtFleteContado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFleteContado.Name = "txtFleteContado";
            this.txtFleteContado.Size = new System.Drawing.Size(151, 25);
            this.txtFleteContado.TabIndex = 4;
            this.txtFleteContado.TextChanged += new System.EventHandler(this.txtFleteContado_TextChanged);
            this.txtFleteContado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFleteContado_KeyPress);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(380, 124);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(127, 20);
            this.label18.TabIndex = 17;
            this.label18.Text = "Flete al contado:";
            // 
            // txtCargioUnitario
            // 
            this.txtCargioUnitario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCargioUnitario.BackColor = System.Drawing.Color.White;
            this.txtCargioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCargioUnitario.Location = new System.Drawing.Point(513, 166);
            this.txtCargioUnitario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCargioUnitario.Name = "txtCargioUnitario";
            this.txtCargioUnitario.Size = new System.Drawing.Size(151, 25);
            this.txtCargioUnitario.TabIndex = 5;
            this.txtCargioUnitario.TextChanged += new System.EventHandler(this.txtCargioUnitario_TextChanged);
            this.txtCargioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCargioUnitario_KeyPress);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(380, 173);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(127, 20);
            this.label17.TabIndex = 18;
            this.label17.Text = "Carguio Unitario:";
            // 
            // txtFleteUnitario
            // 
            this.txtFleteUnitario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFleteUnitario.BackColor = System.Drawing.Color.White;
            this.txtFleteUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFleteUnitario.Location = new System.Drawing.Point(513, 80);
            this.txtFleteUnitario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFleteUnitario.Name = "txtFleteUnitario";
            this.txtFleteUnitario.Size = new System.Drawing.Size(151, 25);
            this.txtFleteUnitario.TabIndex = 3;
            this.txtFleteUnitario.TextChanged += new System.EventHandler(this.txtFleteUnitario_TextChanged);
            this.txtFleteUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFleteUnitario_KeyPress);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(380, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 20);
            this.label15.TabIndex = 16;
            this.label15.Text = "Flete Unitario:";
            // 
            // txtStock
            // 
            this.txtStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStock.BackColor = System.Drawing.Color.White;
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Location = new System.Drawing.Point(513, 38);
            this.txtStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(151, 25);
            this.txtStock.TabIndex = 2;
            this.txtStock.TextChanged += new System.EventHandler(this.txtStock_TextChanged);
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Stock Actual:";
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdProducto.BackColor = System.Drawing.Color.White;
            this.txtIdProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdProducto.Location = new System.Drawing.Point(160, 75);
            this.txtIdProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(196, 25);
            this.txtIdProducto.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Producto:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(152, 107);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(59, 20);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "label3";
            // 
            // ttMensaje
            // 
            this.ttMensaje.IsBalloon = true;
            // 
            // btnsiguiente
            // 
            this.btnsiguiente.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnsiguiente.BackgroundImage = global::CapaPresentacion.Properties.Resources.siguiente;
            this.btnsiguiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsiguiente.FlatAppearance.BorderSize = 0;
            this.btnsiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsiguiente.ForeColor = System.Drawing.Color.Black;
            this.btnsiguiente.Location = new System.Drawing.Point(360, 390);
            this.btnsiguiente.Margin = new System.Windows.Forms.Padding(4);
            this.btnsiguiente.Name = "btnsiguiente";
            this.btnsiguiente.Size = new System.Drawing.Size(71, 42);
            this.btnsiguiente.TabIndex = 6;
            this.btnsiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsiguiente.UseVisualStyleBackColor = true;
            this.btnsiguiente.Click += new System.EventHandler(this.btnsiguiente_Click);
            this.btnsiguiente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnsiguiente_KeyDown);
            this.btnsiguiente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnsiguiente_KeyPress);
            // 
            // btnPrimero
            // 
            this.btnPrimero.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrimero.BackgroundImage = global::CapaPresentacion.Properties.Resources.primero;
            this.btnPrimero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrimero.FlatAppearance.BorderSize = 0;
            this.btnPrimero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimero.ForeColor = System.Drawing.Color.Black;
            this.btnPrimero.Location = new System.Drawing.Point(206, 390);
            this.btnPrimero.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(71, 42);
            this.btnPrimero.TabIndex = 9;
            this.btnPrimero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrimero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            this.btnPrimero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnPrimero_KeyPress);
            // 
            // btnUltimo
            // 
            this.btnUltimo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUltimo.BackgroundImage = global::CapaPresentacion.Properties.Resources.Ultimo;
            this.btnUltimo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUltimo.FlatAppearance.BorderSize = 0;
            this.btnUltimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUltimo.ForeColor = System.Drawing.Color.Black;
            this.btnUltimo.Location = new System.Drawing.Point(437, 390);
            this.btnUltimo.Margin = new System.Windows.Forms.Padding(4);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(71, 42);
            this.btnUltimo.TabIndex = 8;
            this.btnUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUltimo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            this.btnUltimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnUltimo_KeyPress);
            // 
            // btnatras
            // 
            this.btnatras.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnatras.BackgroundImage = global::CapaPresentacion.Properties.Resources.atras;
            this.btnatras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnatras.FlatAppearance.BorderSize = 0;
            this.btnatras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnatras.ForeColor = System.Drawing.Color.Black;
            this.btnatras.Location = new System.Drawing.Point(281, 390);
            this.btnatras.Margin = new System.Windows.Forms.Padding(4);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(71, 42);
            this.btnatras.TabIndex = 7;
            this.btnatras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnatras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            this.btnatras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnatras_KeyPress);
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
            this.btnEliminar.Location = new System.Drawing.Point(286, 13);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 82);
            this.btnEliminar.TabIndex = 4;
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
            this.btnCancelar.Location = new System.Drawing.Point(396, 13);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 82);
            this.btnCancelar.TabIndex = 5;
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
            this.btnModificar.Location = new System.Drawing.Point(181, 13);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(83, 82);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            this.btnModificar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnModificar_KeyPress);
            this.btnModificar.MouseLeave += new System.EventHandler(this.btnModificar_MouseLeave);
            this.btnModificar.MouseHover += new System.EventHandler(this.btnModificar_MouseHover);
            // 
            // FrmEditarDetalleIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(716, 449);
            this.Controls.Add(this.btnsiguiente);
            this.Controls.Add(this.btnPrimero);
            this.Controls.Add(this.btnUltimo);
            this.Controls.Add(this.btnatras);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.dataListadoDetalle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEditarDetalleIngreso";
            this.Text = ".:: Editar Detalle Ingreso ::.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditarDetalleIngreso_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditarDetalleIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataListadoDetalle;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtIddetalleingreso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarguioContado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFleteContado;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCargioUnitario;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtFleteUnitario;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnsiguiente;
        public System.Windows.Forms.TextBox txtIdingreso;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtnrocomprobante;
        private System.Windows.Forms.TextBox txtTotalporCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalcancelado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbProducto;
    }
}