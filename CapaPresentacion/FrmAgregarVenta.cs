using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class FrmAgregarVenta : Form
    {
        private static FrmAgregarVenta _instancia;
        private bool IsNuevo;
        public int IdTrabajador;
        private DataTable dtDetalle;
        private decimal importetotal = 0;
        private decimal alcontado = 0;
        private decimal pagoalcontado = 0;
        private decimal rebajatotal = 0;
        private decimal porcobrar = 0;
        private string estado = "";
        public FrmAgregarVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtIdProducto, "Selecione producto");
            this.ttMensaje.SetToolTip(this.txtProducto, "Selecione producto");
            this.ttMensaje.SetToolTip(this.txtStockactual, "Selecione producto");
            this.ttMensaje.SetToolTip(this.cbCliente, "Selecione un cliente");
            this.ttMensaje.SetToolTip(this.txtNrorecibo, "Ingrese el Nro de Recibo");
            this.ttMensaje.SetToolTip(this.txtNroTalonario, "Ingrese el Nro de Talonario");
            this.ttMensaje.SetToolTip(this.cbTipo_Comprobante, "Seleccione Tipo Comprobante");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese cantidad a vender");
            this.ttMensaje.SetToolTip(this.txtPrecio, "Ingrese precio del producto");
            this.ttMensaje.SetToolTip(this.txtRebaja, "Ingrese Rebaja");
            this.ttMensaje.SetToolTip(this.txtContado, "Ingrese pago al contado");
       
            this.txtIdcliente.Visible = false;
            this.txtRebaja.Text = "0";
            this.txtRebaja.Visible = false;
            this.txtIdProducto.Enabled = false;
            this.txtProducto.Enabled = false;
            this.txtStockactual.Enabled = false;
            this.txtNrorecibo.Enabled = false;
            // this.txtCliente.Enabled = false;
            this.txtNrorecibo.ReadOnly = true;
            this.txtNroTalonario.ReadOnly = true;
            this.txtCantidad.ReadOnly = true;
            this.txtPrecio.ReadOnly = true;
            this.txtRebaja.ReadOnly = true;
            this.txtContado.ReadOnly = true;
            this.dataListado.Visible =false;
            this.dataListadoProducto.Visible = false;
        }
        public static FrmAgregarVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmAgregarVenta();
            }
            return _instancia;
        }
        public void setCliente(string idCliente, string nombre)
        {
            
            this.txtIdcliente.Text = idCliente;
          //  this.txtCliente.Text = nombre;
        }

        public void setProducto(string id, string nombre,
             int stock)
        {
            this.txtIdProducto.Text = id;
            this.txtProducto.Text = nombre;
            this.txtStockactual.Text = Convert.ToString(stock);
        }
        private void FrmAgregarVenta_Load(object sender, EventArgs e)
        {
            this.dtFechaVenta.Focus();
            this.txtNrorecibo.Text=Convert.ToString(Nconexion.VerNroRecibo()+1);
            this.Top = 0;
            this.Left = 0;
            this.IsNuevo = true;
            this.Habilitar(true);
            this.Botones();
            this.crearTabla();
            
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxCliente(cbCliente);
        }
            //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            
            //this.txtIdcliente.Text = string.Empty;
           // this.txtCliente.Text = string.Empty;
            
            this.txtNroTalonario.Text = string.Empty;
            this.lblImporteTotalv.Text = string.Empty;
            this.lblPagoContadov.Text = string.Empty;
            this.lblPorCobrarv.Text = string.Empty;
            this.lblEstadov.Text = "Por Cobrar";
            this.crearTabla();
        }
        private void LimpiarDetalle()
        {
            this.txtIdProducto.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtStockactual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtRebaja.Text = "0.0";
            this.txtContado.Text = "0.0";
            this.lblImporteTotal.Text = "0.00";
            this.lblPorCobrar.Text = "0.00";
            this.lblEstado.Text = "Por Cobrar";

            //  this.txtDevoluciones.Text = string.Empty;
        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Devoluciones", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Precio", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("Importe_Total", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("Al_Contado", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("Total_Contado", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("Saldo_por_Cobrar", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("Rebaja", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("RebajaInicial", System.Type.GetType("System.Double"));
            this.dtDetalle.Columns.Add("Estado", System.Type.GetType("System.String"));

            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
           this.dataListadoDetalle.Columns[0].Visible = false;//ocultar id_venta
            this.dataListadoDetalle.Columns[3].Visible = false;//ocultar devoluciones
            this.dataListadoDetalle.Columns[6].Visible = false;
            this.AlternarColorFilasDataGridView(dataListadoDetalle);
        }
        private void AlternarColorFilasDataGridView(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.White;//color intercalado
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 213, 159);//color intercalado
            this.dataListadoDetalle.GridColor = Color.FromArgb(232, 4, 10);//cambiar color de lineas
                                                                           //  this.dataListado.BorderStyle = BorderStyle.FixedSingle;
                                                                           //  this.dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(125, 190, 255);
                                                                           //  this.dataListado.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(125, 190, 255);
                                                                           // this.dataListado.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                                                           // dgv.Rows[1].Cells[1].Style.BackColor = Color.Red;
                                                                           //dataListado.CurrentRow.Cells[e.RowIndex].Style.BackColor = Color.Red;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNrorecibo.ReadOnly = !valor;
            this.dtFechaVenta.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtNroTalonario.ReadOnly = !valor;
            this.txtContado.ReadOnly = !valor;
            this.txtPrecio.ReadOnly = !valor;
            this.txtRebaja.ReadOnly = !valor;
            this.btnBuscarProducto.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.cbCliente.Enabled = valor;
            this.txtNrorecibo.Enabled = !valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;

        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnAgregar.Enabled = true;
                this.btnQuitar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.btnQuitar.Enabled = false;
            }

        }


        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmAgregarCliente form = new FrmAgregarCliente();
            form.ShowDialog();

            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxCliente(cbCliente);
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmVistaProducto_Venta form = new FrmVistaProducto_Venta();
            form.ShowDialog();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.dtFechaVenta.Focus();
            this.LimpiarDetalle();
            this.txtNrorecibo.Text = Convert.ToString(Nconexion.VerNroRecibo() + 1);
            vaciarvariables();
            calcular();
        }

        private void FrmAgregarVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.LimpiarDetalle();
            vaciarvariables();
            calcular();
            _instancia = null;
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (this.txtIdProducto.Text == string.Empty || this.txtCantidad.Text == string.Empty || this.txtPrecio.Text == string.Empty || this.txtContado.Text == string.Empty || this.txtRebaja.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdProducto, "Selecciones un Valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio, "Ingrese un Valor");
                    errorIcono.SetError(txtRebaja, "Ingrese un Valor");
                    errorIcono.SetError(txtContado, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if ((row["Producto"]).ToString() == this.txtProducto.Text)
                        {
                            registrar = false;
                            
                        }
                    }
                    if(!registrar)
                    this.MensajeError("YA se encuentra el producto en el detalle");
                    if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStockactual.Text))
                    {
                        decimal subTotal = Convert.ToDecimal(this.lblImporteTotal.Text);
                        decimal subContado = Convert.ToDecimal(this.txtContado.Text);
                        decimal subRebaja = Convert.ToDecimal(this.txtRebaja.Text);
                        importetotal = importetotal + subTotal;
                        pagoalcontado = pagoalcontado + subContado;

                        rebajatotal = rebajatotal + subRebaja;
                        porcobrar = importetotal - pagoalcontado - rebajatotal;
                        this.lblImporteTotalv.Text = importetotal.ToString("#0.00#");
                        this.lblPagoContadov.Text = pagoalcontado.ToString("#0.00#");
                        this.lblPorCobrarv.Text = porcobrar.ToString("#0.00#");
                        if ((Convert.ToDecimal(lblPorCobrarv.Text)) <= 0)
                        {
                            estado = "Cancelado";
                        }
                        else
                        {
                            estado = "Por cobrar";
                        }
                        lblEstadov.Text = estado;
                        //Agregar ese detalle al datalistadoDetalle
                        this.MostrarProducto();
                        int cant = Convert.ToInt32(this.txtCantidad.Text);
                        decimal contado = Convert.ToDecimal(this.txtContado.Text);
                        decimal rebaja = Convert.ToDecimal(this.txtRebaja.Text);
                        foreach (DataGridViewRow rowss in dataListadoProducto.Rows)
                        {
                            if (cant != 0)
                            {
                                if (Convert.ToInt32(rowss.Cells["stock_actual"].Value.ToString()) <= cant)
                                {
                                    decimal auxtot = Convert.ToDecimal(Convert.ToInt32(rowss.Cells["stock_actual"].Value.ToString()) * Convert.ToDecimal(this.txtPrecio.Text));
                                    cant = cant - Convert.ToInt32(rowss.Cells["stock_actual"].Value.ToString());
                                    DataRow row = this.dtDetalle.NewRow();
                                    row["iddetalle_ingreso"] = Convert.ToInt32(rowss.Cells["iddetalle_ingreso"].Value.ToString());
                                    row["Producto"] = this.txtProducto.Text;
                                    row["Cantidad"] = Convert.ToInt32(rowss.Cells["stock_actual"].Value.ToString());
                                    row["Devoluciones"] = 0;
                                    row["Precio"] = Convert.ToDecimal(this.txtPrecio.Text);
                                    decimal auxcontado, auxporpagar, auxrebaja = 0;
                                    if (auxtot < rebaja)
                                    {
                                        rebaja = rebaja - auxtot;
                                        auxrebaja = auxtot;
                                        auxtot = 0;
                                    }
                                    else
                                    {

                                        auxrebaja = rebaja;
                                        rebaja = 0;

                                    }
                                    if (auxrebaja == 0)
                                    {
                                        if (auxtot < contado)
                                        {
                                            contado = contado - auxtot;
                                            auxcontado = auxtot;
                                        }
                                        else
                                        {
                                            auxcontado = contado;
                                            contado = 0;
                                        }
                                    }
                                    else
                                    {
                                        if ((auxtot - auxrebaja) < contado)
                                        {
                                            contado = contado - (auxtot - auxrebaja);
                                            auxcontado = (auxtot - auxrebaja);
                                        }
                                        else
                                        {
                                            auxcontado = contado;
                                            contado = 0;
                                        }
                                    }

                                    auxporpagar = auxtot - (auxcontado + auxrebaja);
                                    string auxestado;
                                    if (auxporpagar == 0)
                                    {
                                        auxestado = "Cancelado";
                                    }
                                    else
                                    {
                                        auxestado = "Por cobrar";
                                    }
                                    row["Importe_Total"] = auxtot;
                                    row["Total_Contado"] = auxcontado;
                                    row["Saldo_por_Cobrar"] = auxporpagar;
                                    row["Rebaja"] = auxrebaja;
                                    row["RebajaInicial"] = auxrebaja;                                    
                                    row["Estado"] = auxestado;

                                    // row["subtotal"] = subTotal;
                                    this.dtDetalle.Rows.Add(row);
                                }
                                else
                                {
                                    decimal auxtot = cant * Convert.ToDecimal(this.txtPrecio.Text);

                                    DataRow row = this.dtDetalle.NewRow();
                                    row["iddetalle_ingreso"] = Convert.ToInt32(rowss.Cells["iddetalle_ingreso"].Value.ToString());
                                    row["Producto"] = this.txtProducto.Text;
                                    row["Cantidad"] = cant;
                                    row["Devoluciones"] = 0;
                                    row["Precio"] = Convert.ToDecimal(this.txtPrecio.Text);
                                    decimal auxcontado, auxporpagar, auxrebaja;
                                    if (auxtot < rebaja)
                                    {
                                        rebaja = rebaja - auxtot;
                                        auxrebaja = auxtot;
                                        auxtot = 0;
                                    }
                                    else
                                    {

                                        auxrebaja = rebaja;
                                        rebaja = 0;

                                    }
                                    if (auxtot < contado)
                                    {
                                        contado = contado - auxtot;
                                        auxcontado = auxtot;
                                    }
                                    else
                                    {
                                        auxcontado = contado;
                                        contado = 0;
                                    }
                                    auxporpagar = auxtot - auxcontado - auxrebaja;
                                    string auxestado;
                                    if (auxporpagar == 0)
                                    {
                                        auxestado = "Cancelado";
                                    }
                                    else
                                    {
                                        auxestado = "Por cobrar";
                                    }
                                    row["Importe_Total"] = auxtot;
                                    row["Total_Contado"] = auxcontado;
                                    row["Saldo_por_Cobrar"] = auxporpagar;
                                    row["Rebaja"] = auxrebaja;
                                    row["RebajaInicial"] = auxrebaja;
                                    row["Estado"] = auxestado;

                                    // row["subtotal"] = subTotal;
                                    this.dtDetalle.Rows.Add(row);
                                    cant = 0;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        this.LimpiarDetalle();

                    }
                    else
                    {
                        if (registrar)
                        {
                            MensajeError("No hay Stock Suficiente");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            btnBuscarProducto.Focus();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir el totalPAgado
                // this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                // this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                //Removemos la fila
                this.importetotal = this.importetotal - Convert.ToDecimal(row["Importe_Total"].ToString());
                this.lblImporteTotalv.Text = importetotal.ToString("#0.00#");
                this.pagoalcontado = this.pagoalcontado - Convert.ToDecimal(row["Total_Contado"].ToString());
                this.lblPagoContadov.Text = pagoalcontado.ToString("#0.00#");
                this.porcobrar = this.porcobrar - Convert.ToDecimal(row["Saldo_por_Cobrar"].ToString());
                this.lblPorCobrarv.Text = porcobrar.ToString("#0.00#");
                this.rebajatotal = rebajatotal - Convert.ToDecimal(row["Rebaja"].ToString());
                if ((Convert.ToDecimal(lblPorCobrarv.Text)) <= 0)
                {
                    estado = "Cancelado";
                }
                else
                {
                    estado = "Por cobrar";
                }
                lblEstadov.Text = estado;
                this.dtDetalle.Rows.Remove(row);


            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            //this.Habilitar(false);
            this.LimpiarDetalle();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;

                }
            }
           
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (e.KeyChar == ',')
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        if (e.KeyChar == '.')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            
        }

        private void txtRebaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (e.KeyChar == ',')
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        if (e.KeyChar == '.')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            
        }

        private void txtContado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    if (e.KeyChar == ',')
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        if (e.KeyChar == '.')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private void btnNuevo_MouseHover(object sender, EventArgs e)
        {
            this.btnNuevo.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnNuevo.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnNuevo_MouseLeave(object sender, EventArgs e)
        {
            this.btnNuevo.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnNuevo.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnCancelar_MouseHover(object sender, EventArgs e)
        {
            this.btnCancelar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnCancelar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancelar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnCancelar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnLimpiar_MouseHover(object sender, EventArgs e)
        {
            this.btnLimpiar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnLimpiar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnLimpiar_MouseLeave(object sender, EventArgs e)
        {
            this.btnLimpiar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnLimpiar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnGuardar_MouseHover(object sender, EventArgs e)
        {
            this.btnGuardar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            this.btnGuardar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                string rpta2 = "";
                if (this.txtIdcliente.Text == string.Empty || this.txtNrorecibo.Text == string.Empty
                    || this.txtNroTalonario.Text == string.Empty || this.cbCliente.ValueMember == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(cbCliente, "Ingrese un Valor");
                    errorIcono.SetError(txtNrorecibo, "Ingrese un Valor");
                    errorIcono.SetError(txtNroTalonario, "Ingrese un Valor");
                  

                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = NVenta.Insertar(IdTrabajador, Convert.ToInt32(this.txtIdcliente.Text),
                            dtFechaVenta.Value, this.txtNroTalonario.Text,cbTipo_Comprobante.Text,
                            txtNrorecibo.Text, Convert.ToDecimal(lblImporteTotalv.Text),
                            Convert.ToDecimal(lblPagoContadov.Text), Convert.ToDecimal(lblPorCobrarv.Text),
                            lblEstadov.Text, dtDetalle);

                        int aux = 0;
                        if (lblEstadov.Text == "Por cobrar")
                        {
                            this.Mostrar();
                            aux = Convert.ToInt32(dataListado[0, 0].Value.ToString());
                            
                            decimal deud = Convert.ToDecimal(dataListado[10, 0].Value.ToString());
                           
                            rpta2 = NCobros.InsertarCobro(aux, IdTrabajador,0,"", "", dtFechaVenta.Value,deud, 0,
                              deud, 0);
                        }
                        else
                        {
                            this.Mostrar();
                            aux = Convert.ToInt32(dataListado[0, 0].Value.ToString());
                            rpta2 = NCobros.InsertarCobro(aux, IdTrabajador,0,"", "", dtFechaVenta.Value, 0, 0,
                             0, 0);
                        }
                    }


                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                            Nconexion.NroRecibo(Convert.ToInt32(txtNrorecibo.Text));
                            this.txtNrorecibo.Text = Convert.ToString(Nconexion.VerNroRecibo() + 1);
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.LimpiarDetalle();
                    vaciarvariables();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
        
            // lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void MostrarProducto()
        {
            this.dataListadoProducto.DataSource = NVenta.MostrarrProducto_Venta(this.txtIdProducto.Text);

            // lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void vaciarvariables()
        {
            importetotal = 0;
            pagoalcontado = 0;
            porcobrar = 0;
            rebajatotal = 0;

            
        }
        private void calcular()
        {

            decimal v2, v3, v4, v5;
            int v1;
           
            if (this.txtCantidad.Text.Equals(""))
                v1 = 0;
            else
                v1 = Convert.ToInt32(txtCantidad.Text);
            if (this.txtPrecio.Text.Equals(""))
                v2 = 0;
            else
                v2 = Convert.ToDecimal(txtPrecio.Text);
            if (this.txtRebaja.Text.Equals(""))
                v3 = 0;
            else
                v3 = Convert.ToDecimal(txtRebaja.Text);
            if (this.txtContado.Text.Equals(""))
                v4 = 0;
            else
                v4 = Convert.ToDecimal(txtContado.Text);
            //if (!this.txtStock.Text.Equals("")&& !this.txtFleteContado.Text.Equals("")&& !this.txtCargioUnitario.Text.Equals(""))
            //{
            lblImporteTotal.Text = ((v1 * v2)).ToString("#,#0.00");
            lblPorCobrar.Text = (Convert.ToDecimal(lblImporteTotal.Text) - (v4+v3)).ToString("#,#0.00");
            if ((Convert.ToDecimal(lblPorCobrar.Text)) <= 0)
            {
                lblEstado.Text = "Cancelado";
            }
            else
            {
                lblEstado.Text = "Por cobrar";
            }
            //lblEstado.Text = (v1 * v4).ToString("#,#0.00");
            // lblTotal.Text = (v3 + Convert.ToDecimal(lblfleteporcancelar.Text) + Convert.ToDecimal(lblCarguioTotal.Text)).ToString("#,##0");
            // lblcancelado.Text = ( Convert.ToDecimal(txtFleteContado.Text)).ToString("#,#0.00");
            // }      
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtContado_TextChanged(object sender, EventArgs e)
        {

            calcular();
        }

        private void txtRebaja_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtNrorecibo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sId = cbCliente.SelectedValue.ToString();
            txtIdcliente.Text = sId;
        }

        private void btnAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnBuscarProducto.Focus();
            


        }

        private void btnNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dtFechaVenta.Focus();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Cambiar_Click(object sender, EventArgs e)
        {
            this.txtNrorecibo.Enabled = true;
        }

        private void btnGuardar_TabStopChanged(object sender, EventArgs e)
        {
           
        }

        private void btnGuardar_TabIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnGuardar_DragOver(object sender, DragEventArgs e)
        {
            
        }
    }
}
