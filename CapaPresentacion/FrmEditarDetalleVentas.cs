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
    public partial class FrmEditarDetalleVentas : Form
    {
        int posicion;
        int posicionfinal;
        int auxcantidad = 0;
        int auxstock = 0;
        int auxdevolucion = 0;
        decimal deudaanterior = 0;
        decimal deudapendiente = 0;
        string auxiddetalleingreso;
        decimal auxalcontado = 0;
        decimal rebajahastalafecha = 0;
        decimal rebajaini = 0;
        public FrmEditarDetalleVentas()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtIdProducto, "Selecione Producto");
            this.ttMensaje.SetToolTip(this.txtProducto, "Selecione Producto");
            this.ttMensaje.SetToolTip(this.txtStockactual, "Stock actual");
            this.ttMensaje.SetToolTip(this.txtnrocomprobante, "Inserte Nro de Comprobante");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Inserte Cantidad de la venta");
            this.ttMensaje.SetToolTip(this.txtPrecio, "Inserte Precio unitario del producto");
            this.ttMensaje.SetToolTip(this.txtRebaja, "Inserte Rebaja de la Venta");
            this.ttMensaje.SetToolTip(this.txtAlcontado, "Inserte Monto Alcontado");
            // this.txtIdingreso.ReadOnly = true;
            this.txtIddetalleVenta.Visible = false;
            this.txtRebajasHastaLaFecha.Visible = false;
            this.txtIdVenta.Visible = false;
            this.txtIdDetalleIngreso.Visible = false;
            this.txtContadoActual.Visible = false;
            this.txtnrocomprobante.Enabled = false;
            this.txtRebaja.Text = "0";
            this.txtRebaja.Visible = false;
            this.txtdevoluciones.Enabled = false;
            this.txtProducto.Enabled = false;
            this.txtIdProducto.Enabled = false;
            this.txtStockactual.Enabled = false;
            this.btnDevolucion.Enabled = false;
            this.txtContado.Enabled = false;
            this.dataListadoDetalle.Visible = false;
            this.dataListadoCobro.Visible = false;
        }
        private static FrmEditarDetalleVentas _instancia;
        public static FrmEditarDetalleVentas GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmEditarDetalleVentas();
            }
            return _instancia;
        }


        public void setProducto(string iddetalle_ingreso,string idproducto, string nombre,
             string stock)
        {
            this.txtIdDetalleIngreso.Text = iddetalle_ingreso;
            this.txtIdProducto.Text = idproducto;
            this.txtProducto.Text = nombre;
            this.txtStockactual.Text =stock;
        }
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalle(this.txtIdVenta.Text);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoDetalle.Rows.Count);
            posicion = 0;
            posicionfinal = dataListadoDetalle.Rows.Count - 1;
        }
        private void MostrarCobroPorIDVenta()
        {
            this.dataListadoCobro.DataSource = NCobros.Mostrar_Cobros_IdVenta(Convert.ToInt32(this.txtIdVenta.Text));
            
        }
        private void mover(int paso)
        {
            posicion = posicion + paso;
            txtIdDetalleIngreso.Text = dataListadoDetalle.Rows[posicion].Cells["Id_Detalle_Ingreso"].Value.ToString();
            txtIddetalleVenta.Text = dataListadoDetalle.Rows[posicion].Cells["ID_Detalle_Venta"].Value.ToString();
            txtIdProducto.Text = dataListadoDetalle.Rows[posicion].Cells["idproducto1"].Value.ToString();
            txtProducto.Text = dataListadoDetalle.Rows[posicion].Cells["Producto"].Value.ToString();
            txtStockactual.Text = dataListadoDetalle.Rows[posicion].Cells["stock_actual"].Value.ToString();
            txtCantidad.Text = dataListadoDetalle.Rows[posicion].Cells["Cantidad"].Value.ToString();
            txtdevoluciones.Text = dataListadoDetalle.Rows[posicion].Cells["Devoluciones"].Value.ToString();
            txtPrecio.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Precio"].Value).ToString("#,#0.00");
            lblImporteTotal.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Importe_Total"].Value).ToString("#,#0.00");
            txtAlcontado.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Al_Contado"].Value).ToString("#,#0.00");
            txtContado.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Total_Contado"].Value).ToString("#,#0.00");
            lblPorCobrar.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Saldo_Por_Cobrar"].Value).ToString("#,#0.00");
            txtRebaja.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["RebajaInicial"].Value).ToString("#,#0.00");
            txtRebajasHastaLaFecha.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Rebaja"].Value).ToString("#,#0.00");
            lblEstado.Text = dataListadoDetalle.Rows[posicion].Cells["Estado"].Value.ToString();
            //aux = Convert.ToInt32(this.dataListadoDetalle.Rows[posicion].Cells["stock_inicial"].Value) - Convert.ToInt32(this.dataListadoDetalle.Rows[posicion].Cells["stock_actual"].Value);
            auxcantidad = Convert.ToInt32(dataListadoDetalle.Rows[posicion].Cells["Cantidad"].Value);
            auxalcontado = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Al_Contado"].Value);

            auxstock = Convert.ToInt32(dataListadoDetalle.Rows[posicion].Cells["stock_actual"].Value);
            auxdevolucion = Convert.ToInt32(dataListadoDetalle.Rows[posicion].Cells["Devoluciones"].Value);
            auxiddetalleingreso = dataListadoDetalle.Rows[posicion].Cells["Id_Detalle_Ingreso"].Value.ToString();
            foreach (DataGridViewRow row in dataListadoDetalle.Rows)
            {
                deudaanterior = deudaanterior + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                deudapendiente = deudapendiente + Convert.ToDecimal(row.Cells["Saldo_Por_Cobrar"].Value);
            }
            rebajahastalafecha= Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Rebaja"].Value);
            rebajaini = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["RebajaInicial"].Value);
            calcular();
        }
        private void FrmEditarDetalleVentas_Load(object sender, EventArgs e)
        {
            this.MostrarDetalle();
            this.mover(0);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnModificar_MouseHover(object sender, EventArgs e)
        {
            this.btnModificar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnModificar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
            this.btnModificar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnModificar.BackgroundImageLayout = ImageLayout.Stretch;
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

        private void btnEliminar_MouseHover(object sender, EventArgs e)
        {
            this.btnEliminar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
            
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            this.btnEliminar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmVistaEditarProducto_Venta form = new FrmVistaEditarProducto_Venta();
            form.ShowDialog();
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
                        e.Handled = true;
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
                        e.Handled = true;
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
                        e.Handled = true;
                    }
                }
            }
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

        private void txtDevolucion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FrmEditarDetalleVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            mover(-posicion);
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if (posicion == posicionfinal)
            {
                MessageBox.Show("No hay mas registros", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mover(1);
            }
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            if (posicion == 0)
            {
                MessageBox.Show("Ya estamos en el primer registro", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mover(-1);
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            posicion = 0;
            if (posicion == posicionfinal)
            {
                MessageBox.Show("No hay mas registros", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mover(posicionfinal);
            }
        }
        private void calcular()
        {

            decimal v2 = 0, v3 = 0, v4 = 0, v5 = 0, r1 = 0;
            int a1 = 0;

            if (!this.txtCantidad.Text.Equals(""))
                a1 = Convert.ToInt32(txtCantidad.Text);

            if (!this.txtPrecio.Text.Equals(""))
                v2 = Convert.ToDecimal(txtPrecio.Text);
            if (!this.txtRebaja.Text.Equals(""))
                v3 = Convert.ToDecimal(txtRebaja.Text);
            if (!this.txtContado.Text.Equals(""))
                v4 = Convert.ToDecimal(txtContado.Text);
            if (!this.txtAlcontado.Text.Equals(""))
                v5 = Convert.ToDecimal(txtAlcontado.Text);
            if (v5 != auxalcontado)
            {
                if (v5 > auxalcontado)
                {
                    v4 = v4 + (v5 - auxalcontado);

                }
                else
                {
                    v4 = v4 - (auxalcontado - v5);

                }
            }

            txtContadoActual.Text = v4.ToString("#,#0.00");

            //if (!this.txtStock.Text.Equals("")&& !this.txtFleteContado.Text.Equals("")&& !this.txtCargioUnitario.Text.Equals(""))
            //{
            lblImporteTotal.Text = ((a1 * v2)).ToString("#,#0.00");
            lblPorCobrar.Text = (Convert.ToDecimal(lblImporteTotal.Text) - (v4 + v3)).ToString("#,#0.00");


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

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtRebaja_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtContado_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDevolucion_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {
                if (this.txtIdProducto.Text == string.Empty || this.txtCantidad.Text == string.Empty || this.txtPrecio.Text == string.Empty || this.txtAlcontado.Text == string.Empty || this.txtRebaja.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio, "Ingrese un Valor");
                    errorIcono.SetError(txtRebaja, "Ingrese un Valor");
                    errorIcono.SetError(txtContado, "Ingrese un Valor");
                    errorIcono.SetError(txtAlcontado, "Ingrese un Valor");

                }
                else
                {
                    string rpta2 = "";
                    string rpta3 = "";
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Desea Actualizar los Datos", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {

                        if (!auxiddetalleingreso.Equals(txtIdDetalleIngreso.Text))
                        {

                            if (Convert.ToInt32(txtCantidad.Text) > Convert.ToInt32(txtStockactual.Text))
                            {
                                MessageBox.Show("La cantidad no puede ser mayor al stock", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                rpta2 = NVenta.restablecer(Convert.ToInt32(auxiddetalleingreso), auxcantidad);
                                if (rpta2.Equals("OK"))
                                {

                                    rpta3 = NVenta.disminuirStock(Convert.ToInt32(txtIdDetalleIngreso.Text), Convert.ToInt32(txtCantidad.Text));

                                }
                                else
                                {
                                    this.MensajeError(rpta2);
                                }

                            }


                        }
                        else
                        {
                            int aux = auxcantidad - Convert.ToInt32(txtCantidad.Text);
                            if (auxstock >= Math.Abs(aux))
                            {
                                if (aux < 0)
                                {

                                    rpta3 = NVenta.disminuirStock(Convert.ToInt32(txtIdDetalleIngreso.Text), Math.Abs(aux));
                                }
                                else
                                {

                                    rpta3 = NVenta.restablecer(Convert.ToInt32(txtIdDetalleIngreso.Text), Math.Abs(aux));
                                }
                            }
                            else
                            {
                                MessageBox.Show("La cantidad no puede ser mayor al stock", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        decimal auxrebaja=Convert.ToDecimal(txtRebaja.Text);
                        decimal aux7 = rebajahastalafecha -auxrebaja;
                        decimal nuevarebajahastalafecha = 0;
                        if (aux7<0)
                        {
                            nuevarebajahastalafecha = aux7 * -1;
                            
                        }
                        else
                        {
                            if (auxrebaja< rebajaini)
                            {
                                nuevarebajahastalafecha = rebajahastalafecha -aux7;
                            }
                            else
                            {
                                nuevarebajahastalafecha = rebajahastalafecha + aux7;
                            }                           
                            
                        }
                        string rpta4 = "";
                        if (rpta3.Equals("OK"))
                        {

                            rpta4 = NVenta.EditarDetalleVenta(Convert.ToInt32(txtIddetalleVenta.Text), Convert.ToInt32(txtIdVenta.Text),
                              Convert.ToInt32(txtIdDetalleIngreso.Text), Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtdevoluciones.Text),
                                Convert.ToDecimal(txtPrecio.Text), Convert.ToDecimal(lblImporteTotal.Text), Convert.ToDecimal(txtAlcontado.Text)
                                , Convert.ToDecimal(txtContadoActual.Text), Convert.ToDecimal(lblPorCobrar.Text),nuevarebajahastalafecha, Convert.ToDecimal(txtRebaja.Text), lblEstado.Text);
                           
                            if (rpta4.Equals("OK"))
                            {
                                MostrarDetalle();
                                //sumar valores para editar ingreso
                                decimal Inimportetotal = 0;
                                decimal Inimportecontado = 0;
                                decimal Insaldoporpagar = 0;
                                decimal InAlcontado = 0;
                                foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                                {
                                    Inimportetotal = Inimportetotal + Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                                    Inimportecontado = Inimportecontado + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                                    Insaldoporpagar = Insaldoporpagar + Convert.ToDecimal(row.Cells["Saldo_Por_Cobrar"].Value);
                                    InAlcontado = InAlcontado + Convert.ToDecimal(row.Cells["Al_Contado"].Value);
                                }
                                string rpta5 = "";
                                string inestado = "";
                                if (Insaldoporpagar == 0)
                                    inestado = "Cancelado";
                                else
                                    inestado = "Por Cobrar";
                                rpta5 = NVenta.EditarVentaPorDetalle(Convert.ToInt32(txtIdVenta.Text), Inimportetotal, InAlcontado, Inimportecontado, Insaldoporpagar, inestado);
                                decimal cobrodeudaanterior = deudaanterior - Inimportecontado;
                                decimal cobrodeudapendiente = deudapendiente - Insaldoporpagar;
                                //MessageBox.Show("Uno "+cobrodeudaanterior.ToString()+"..."+deudaanterior.ToString()+"....."+Inimportecontado.ToString());
                                //MessageBox.Show("Dos " + cobrodeudapendiente.ToString() + "..." + deudapendiente.ToString() + "....." + Insaldoporpagar.ToString());
                                string rpta6 = "";
                                if (cobrodeudapendiente != 0)
                                {
                                    MostrarCobroPorIDVenta();
                                    int idcobro;
                                    decimal anterior;
                                    decimal porcobrar;
                                    foreach (DataGridViewRow row in dataListadoCobro.Rows)
                                    {
                                        idcobro = Convert.ToInt32(row.Cells["ID_Cobro"].Value);
                                        anterior = Convert.ToDecimal(row.Cells["Deuda_Anterior"].Value) - cobrodeudapendiente;
                                        porcobrar = Convert.ToDecimal(row.Cells["Deuda_Pendiente"].Value) - cobrodeudapendiente;
                                        rpta6 = NCobros.actualizarCobro_por_detalle_venta(idcobro, anterior, porcobrar);
                                        if (!rpta6.Equals("OK"))
                                        {
                                            this.MensajeError(rpta6);
                                        }

                                    }
                                    deudaanterior = 0;
                                    deudapendiente = 0;
                                    foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                                    {
                                        deudaanterior = deudaanterior + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                                        deudapendiente = deudapendiente + Convert.ToDecimal(row.Cells["Saldo_Por_Cobrar"].Value);
                                    }
                                }
                                if (rpta5.Equals("OK"))
                                {
                                    this.MensajeOk("Se Actualizó de forma correcta el registro");
                                    MostrarDetalle();
                                }
                                else
                                {
                                    this.MensajeError(rpta5);
                                }
                            }
                            else
                            {
                                this.MensajeError(rpta4);
                            }
                        }
                        else
                        {
                            if (rpta2.Equals("OK"))
                                this.MensajeError(rpta3);
                            else
                                this.MensajeError(rpta2);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Id;
                    string Rpta = "";


                    Id = txtIddetalleVenta.Text;
                    Rpta = NVenta.EliminarDetalle(Convert.ToInt32(Id));

                    //actualizar ingreso
                    string rpta2 = "";
                    MostrarDetalle();
                    //sumar valores para editar ingreso
                    decimal Inimportetotal = 0;
                    decimal Inimportecontado = 0;
                    decimal Insaldoporpagar = 0;
                    decimal Inalcontado = 0;
                    foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                    {
                        Inimportetotal = Inimportetotal + Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                        Inimportecontado = Inimportecontado + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                        Insaldoporpagar = Insaldoporpagar + Convert.ToDecimal(row.Cells["Saldo_Por_Cobrar"].Value);
                        Inalcontado = Inalcontado + Convert.ToDecimal(row.Cells["Al_Contado"].Value);
                    }
                    string inestado = "";
                    if (Insaldoporpagar == 0)
                        inestado = "Cancelado";
                    else
                        inestado = "Por Cobrar";
                    rpta2 = NVenta.EditarVentaPorDetalle(Convert.ToInt32(txtIdVenta.Text), Inimportetotal, Inalcontado, Inimportecontado, Insaldoporpagar, inestado);
                    if (Convert.ToInt32(dataListadoDetalle.Rows.Count) == 0)
                    {
                        Id = txtIdVenta.Text;
                        Rpta = NVenta.Eliminar(Convert.ToInt32(Id));
                    }
                    if (rpta2.Equals("OK"))
                    {
                        decimal cobrodeudapendiente = deudapendiente - Insaldoporpagar;
                        
                        //MessageBox.Show("Dos " + cobrodeudapendiente.ToString() + "..." + deudapendiente.ToString() + "....." + Insaldoporpagar.ToString());
                        string rpta6 = "";
                        if (cobrodeudapendiente != 0)
                        {
                            MostrarCobroPorIDVenta();
                            int idcobro;
                            decimal anterior;
                            decimal porcobrar;
                            foreach (DataGridViewRow row in dataListadoCobro.Rows)
                            {
                                idcobro = Convert.ToInt32(row.Cells["ID_Cobro"].Value);
                                anterior = Convert.ToDecimal(row.Cells["Deuda_Anterior"].Value) - cobrodeudapendiente;
                                porcobrar = Convert.ToDecimal(row.Cells["Deuda_Pendiente"].Value) - cobrodeudapendiente;
                                rpta6 = NCobros.actualizarCobro_por_detalle_venta(idcobro, anterior, porcobrar);
                                if (!rpta6.Equals("OK"))
                                {
                                    this.MensajeError(rpta6);
                                }

                            }
                            deudaanterior = 0;
                            deudapendiente = 0;
                            foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                            {
                                deudaanterior = deudaanterior + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                                deudapendiente = deudapendiente + Convert.ToDecimal(row.Cells["Saldo_Por_Cobrar"].Value);
                            }
                        }
                        if (rpta6.Equals("OK"))
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                            MostrarDetalle();
                        }
                        else
                        {
                            this.MensajeError(rpta6);
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta2);
                    }
                    this.MostrarDetalle();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void habilitar(bool valor)
        {
            this.txtnrocomprobante.Enabled = !valor;
            this.txtdevoluciones.Enabled = valor;
            this.txtCantidad.Enabled = !valor;
            this.txtPrecio.Enabled = !valor;
            this.txtRebaja.Enabled = !valor;
            this.txtAlcontado.Enabled = !valor;
            this.txtContado.Enabled = !valor;
            this.btnDevolucion.Enabled = valor;
            this.btnModificar.Enabled = !valor;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {
                if (this.txtdevoluciones.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtdevoluciones, "Ingrese un Valor");
                }
                else
                {
                    string rpta2 = "";
                    string rpta3 = "";
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Desea Realizar la Devolución", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        int aux = auxdevolucion - Convert.ToInt32(txtdevoluciones.Text);
                        //int devolcantidadtotal = Convert.ToInt32(txtCantidad)- Convert.ToInt32(txtdevoluciones.Text);
                        if (Convert.ToInt32(txtCantidad.Text) >= Convert.ToInt32(txtdevoluciones.Text))
                        {
                            if (aux >= 0)
                            {
                                rpta2 = NVenta.disminuirStock(Convert.ToInt32(txtIdDetalleIngreso.Text), Math.Abs(aux));
                            }
                            else
                            {
                                rpta2 = NVenta.restablecer(Convert.ToInt32(txtIdDetalleIngreso.Text), Math.Abs(aux));
                            }
                            if (rpta2.Equals("OK"))
                            {

                                rpta3 = NVenta.EditarDetalleVenta(Convert.ToInt32(txtIddetalleVenta.Text), Convert.ToInt32(txtIdVenta.Text),
                                  Convert.ToInt32(txtIdDetalleIngreso.Text), Convert.ToInt32(txtCantidad.Text) + aux, Convert.ToInt32(txtdevoluciones.Text),
                                    Convert.ToDecimal(txtPrecio.Text), Convert.ToDecimal(lblImporteTotal.Text), Convert.ToDecimal(txtAlcontado.Text), Convert.ToDecimal(txtContado.Text),
                                    Convert.ToDecimal(lblPorCobrar.Text), Convert.ToDecimal(txtRebajasHastaLaFecha.Text), Convert.ToDecimal(txtRebaja.Text), lblEstado.Text);
                                if (rpta3.Equals("OK"))
                                {
                                    MostrarDetalle();
                                    //sumar valores para editar ingreso
                                    decimal Inimportetotal = 0;
                                    decimal Inimportecontado = 0;
                                    decimal Insaldoporpagar = 0;
                                    decimal Inalcontado = 0;
                                    foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                                    {
                                        Inimportetotal = Inimportetotal + Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                                        Inimportecontado = Inimportecontado + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                                        Insaldoporpagar = Insaldoporpagar + Convert.ToDecimal(row.Cells["Saldo_Por_Cobrar"].Value);
                                        Inalcontado = Inalcontado + Convert.ToDecimal(row.Cells["Al_Contado"].Value);
                                    }
                                    string rpta5 = "";
                                    string inestado = "";
                                    if (Insaldoporpagar == 0)
                                        inestado = "Cancelado";
                                    else
                                        inestado = "Por Cobrar";
                                    //MessageBox.Show("mmmm"+Inimportetotal.ToString()+" "+Inimportecontado.ToString()+" "+Insaldoporpagar.ToString(), "Sistema MONTERREY", MessageBoxButtons.OK);
                                    string rpta6 = "";
                                    decimal cobrodeudapendiente = Convert.ToInt32(txtdevoluciones.Text) * Convert.ToDecimal(txtPrecio.Text);
                                    if (cobrodeudapendiente != 0)
                                    {
                                        MostrarCobroPorIDVenta();
                                        int idcobro;
                                        decimal anterior;
                                        decimal porcobrar;
                                        foreach (DataGridViewRow row in dataListadoCobro.Rows)
                                        {
                                            idcobro = Convert.ToInt32(row.Cells["ID_Cobro"].Value);
                                            anterior = Convert.ToDecimal(row.Cells["Deuda_Anterior"].Value) - cobrodeudapendiente;
                                            porcobrar = Convert.ToDecimal(row.Cells["Deuda_Pendiente"].Value) - cobrodeudapendiente;
                                            rpta6 = NCobros.actualizarCobro_por_detalle_venta(idcobro, anterior, porcobrar);
                                            if (!rpta6.Equals("OK"))
                                            {
                                                this.MensajeError(rpta6);
                                            }

                                        }

                                    }
                                    rpta5 = NVenta.EditarVentaPorDetalle(Convert.ToInt32(txtIdVenta.Text), Inimportetotal, Inalcontado, Inimportecontado, Insaldoporpagar, inestado);
                                    if (rpta5.Equals("OK"))
                                    {
                                        this.MensajeOk("Se Actualizó de forma correcta el registro");
                                        MostrarDetalle();
                                    }
                                    else
                                    {
                                        this.MensajeError(rpta5);
                                    }
                                }
                                else
                                {
                                    this.MensajeError(rpta3);
                                }
                            }
                            else
                            {
                                this.MensajeError(rpta2);
                            }

                        }
                        else
                        {
                            MensajeError("Devolución no puede ser mayor a cantidad");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            mover(0);
            if (checkBox1.Checked)
            {
                habilitar(true);
            }
            else
            {
                habilitar(false);
            }
        }

        private void txtdevoluciones_TextChanged(object sender, EventArgs e)
        {
            calculardevolucion();
        }
        private void calculardevolucion()
        {
            decimal v2 = 0, v3 = 0, v4 = 0, v5 = 0;
            int a1 = 0, a2 = 0;

            if (!this.txtCantidad.Text.Equals(""))
                a1 = Convert.ToInt32(txtCantidad.Text);
            if (!this.txtdevoluciones.Text.Equals(""))
                a2 = Convert.ToInt32(txtdevoluciones.Text);
            if (!this.txtPrecio.Text.Equals(""))
                v2 = Convert.ToDecimal(txtPrecio.Text);
            if (!this.txtRebaja.Text.Equals(""))
                v3 = Convert.ToDecimal(txtRebaja.Text);
            if (!this.txtContado.Text.Equals(""))
                v4 = Convert.ToDecimal(txtContado.Text);

            //if (!this.txtStock.Text.Equals("")&& !this.txtFleteContado.Text.Equals("")&& !this.txtCargioUnitario.Text.Equals(""))
            //{
            lblImporteTotal.Text = (((a1 - a2) * v2)).ToString("#,#0.00");
            lblPorCobrar.Text = (Convert.ToDecimal(lblImporteTotal.Text) - (v4 + v3)).ToString("#,#0.00");
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
        private void txtdevoluciones_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnDevolucion_MouseLeave(object sender, EventArgs e)
        {
            this.btnDevolucion.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnDevolucion.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnDevolucion_MouseHover(object sender, EventArgs e)
        {
            this.btnDevolucion.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnDevolucion.BackgroundImageLayout = ImageLayout.Stretch;
            
        }

        private void txtAlcontado_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtAlcontado_KeyPress(object sender, KeyPressEventArgs e)
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
                        e.Handled = true;
                    }
                }
            }
        }
    }
}
