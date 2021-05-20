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
    public partial class FrmEditarDetalleIngreso : Form
    {
        int posicion;
        int posicionfinal;
        int aux = 0;
        public string idproducto;
        public string producto;
        private static FrmEditarDetalleIngreso _instancia;
        public static FrmEditarDetalleIngreso GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmEditarDetalleIngreso();
            }
            return _instancia;
        }
        

        public void setProducto(string idproducto, string nombre)
        {
            this.txtIdProducto.Text = idproducto;
           // this.txtProducto.Text = nombre;
        }
        public FrmEditarDetalleIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtIdProducto, "Selecione Producto");
            this.ttMensaje.SetToolTip(this.cbProducto, "Selecione Producto");
            this.ttMensaje.SetToolTip(this.txtStock, "Inserte Stock actual");
            this.ttMensaje.SetToolTip(this.txtFleteUnitario, "Inserte Flete Unitario");
            this.ttMensaje.SetToolTip(this.txtFleteContado, "Inserte Flete Contado");
            this.ttMensaje.SetToolTip(this.txtCarguioContado, "Inserte Carguio Contado");
            this.ttMensaje.SetToolTip(this.txtCargioUnitario, "Inserte Carguio Unitario");
            // this.txtIdingreso.ReadOnly = true;
            this.txtIddetalleingreso.Visible = false;
            this.txtIdingreso.Visible = false;
            this.txtnrocomprobante.Enabled = false;
            //this.txtProducto.Enabled = false;
            this.txtIdProducto.Enabled = false;
            this.txtStockActual.Enabled = false;
            this.txtTotalcancelado.Enabled = false;
            this.txtTotalporCancelar.Enabled = false;
            this.dataListadoDetalle.Visible = false;
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
            this.dataListadoDetalle.DataSource = NIngreso.MostrarDetalle(this.txtIdingreso.Text);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoDetalle.Rows.Count);
            posicion = 0;
            posicionfinal = dataListadoDetalle.Rows.Count-1;
        }
        private void mover(int paso)
        {
            posicion = posicion + paso;
            txtIddetalleingreso.Text=dataListadoDetalle.Rows[posicion].Cells["iddetalle_ingreso"].Value.ToString();
            txtIdProducto.Text = dataListadoDetalle.Rows[posicion].Cells["idProducto"].Value.ToString();
            cbProducto.Text = dataListadoDetalle.Rows[posicion].Cells["Producto"].Value.ToString();
            txtStock.Text = dataListadoDetalle.Rows[posicion].Cells["stock_inicial"].Value.ToString();
            txtStockActual.Text = dataListadoDetalle.Rows[posicion].Cells["stock_actual"].Value.ToString();
            txtFleteUnitario.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Flete_Unitario"].Value).ToString("#,#0.00");
            txtFleteContado.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Flete_Contado"].Value).ToString("#,#0.00");
            txtCargioUnitario.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Carguio_Unitario"].Value).ToString("#,#0.00");
            txtCarguioContado.Text = Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Carguio_Contado"].Value).ToString("#,#0.00");
            txtTotalcancelado.Text = (Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Flete_Contado"].Value)+ Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Carguio_Contado"].Value)).ToString("#,#0.00");
            txtTotalporCancelar.Text = (Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Flete_x_Pagar"].Value) + Convert.ToDecimal(dataListadoDetalle.Rows[posicion].Cells["Carguio_x_Pagar"].Value)).ToString("#,#0.00");
            aux = Convert.ToInt32(this.dataListadoDetalle.Rows[posicion].Cells["stock_inicial"].Value) - Convert.ToInt32(this.dataListadoDetalle.Rows[posicion].Cells["stock_actual"].Value);
        }
        private void FrmEditarDetalleIngreso_Load(object sender, EventArgs e)
        {
            AutoCompletado c = new AutoCompletado();

            c.llenarcomboBoxProducto(cbProducto);
            this.MostrarDetalle();
            this.mover(0);
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea Actualizar los Datos", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                   
                    if (Convert.ToInt32(this.txtStock.Text) >= aux) { 
                            //calculo para editar detall ingreso
                            decimal fletetot = Convert.ToInt32(this.txtStock.Text) * Convert.ToDecimal(this.txtFleteUnitario.Text);
                            decimal fletexpagar = fletetot - Convert.ToDecimal(this.txtFleteContado.Text);
                            decimal carguiotot = Convert.ToInt32(this.txtStock.Text) * Convert.ToDecimal(this.txtCargioUnitario.Text);
                            decimal carguioxpagar = carguiotot - Convert.ToDecimal(this.txtCarguioContado.Text);
                        //editamos detalle ingreso
                       // MessageBox.Show(txtStock.Text+" "+aux.ToString(), "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        rpta = NIngreso.EditarDetalleIngreso(Convert.ToInt32(this.txtIddetalleingreso.Text), this.txtIdProducto.Text,
                             Convert.ToInt32(this.txtStock.Text), Convert.ToInt32(this.txtStock.Text)-aux, Convert.ToDecimal(this.txtFleteUnitario.Text)
                             , fletetot, Convert.ToDecimal(this.txtFleteContado.Text),fletexpagar, Convert.ToDecimal(this.txtCargioUnitario.Text),carguiotot,
                             Convert.ToDecimal(this.txtCarguioContado.Text),carguioxpagar,fletetot+carguiotot);
                        MostrarDetalle();
                            //sumar valores para editar ingreso
                            decimal InfleteTotal = 0;
                            decimal InfleteUnitario = 0;
                            decimal InfleteContado = 0;
                            decimal InfletePorPagar = 0;
                            decimal InCarguioTotal = 0;
                            decimal InCarguioUnitario = 0;
                            decimal InCarguioContado = 0;
                            decimal InCarguioPorPagar = 0;
                            decimal InTotal = 0;
                            foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                            {
                                InfleteTotal = InfleteTotal + Convert.ToDecimal(row.Cells["Flete_Total"].Value);
                                InfleteUnitario =InfleteUnitario+ Convert.ToDecimal(row.Cells["Flete_Unitario"].Value);
                                InfleteContado = InfleteContado + Convert.ToDecimal(row.Cells["Flete_Contado"].Value);
                                InfletePorPagar = InfletePorPagar + Convert.ToDecimal(row.Cells["Flete_x_Pagar"].Value);
                                InCarguioUnitario = InCarguioUnitario + Convert.ToDecimal(row.Cells["Carguio_Unitario"].Value);
                                InCarguioTotal = InCarguioTotal + Convert.ToDecimal(row.Cells["Carguio_Total"].Value);
                                InCarguioContado = InCarguioContado + Convert.ToDecimal(row.Cells["Carguio_Contado"].Value);
                                InCarguioPorPagar= InCarguioPorPagar + Convert.ToDecimal(row.Cells["Carguio_x_Pagar"].Value);
                                InTotal = InTotal+ Convert.ToDecimal(row.Cells["Total"].Value);

                            }
                            //actualizar ingreso
                        string rpta2 = "";
                        rpta2 = NIngreso.EditarIngresoPorDetalle(Convert.ToInt32(this.txtIdingreso.Text),InfleteUnitario,InfleteTotal,
                            InfleteContado,InfletePorPagar,InCarguioUnitario,InCarguioTotal,InCarguioContado,InCarguioPorPagar,InTotal);
                        if (rpta.Equals("OK")&& rpta2.Equals("OK"))
                            {
                                this.MensajeOk("Se Actualizó de forma correcta el registro");
                                MostrarDetalle();
                            }
                            else
                            {
                                if (rpta.Equals("OK"))
                                {
                                    this.MensajeOk("Se Actualizó de forma correcta el registro");
                                    MostrarDetalle();
                                }
                                else
                                {
                                this.MensajeError(rpta);
                                }
                                if (rpta2.Equals("OK"))
                                {
                                    this.MensajeOk("Se Actualizó de forma correcta el registro.");
                                    MostrarDetalle();
                                }
                                else
                                {
                                    this.MensajeError(rpta2);
                                }
                        }
                    }                   
                    else
                    {
                        MessageBox.Show("El stock debe ser mayor igual a lo que ya se vendio", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
           
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
           
        }

        private void txtFleteUnitario_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == (char)(Keys.Enter))
                txtFleteContado.Focus();
        }

        private void txtCargioUnitario_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == (char)(Keys.Enter))
                txtCarguioContado.Focus();
        }

        private void txtFleteContado_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == (char)(Keys.Enter))
                txtCargioUnitario.Focus();
        }

        private void txtCarguioContado_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == (char)(Keys.Enter))
                txtFleteUnitario.Focus();
        }

        private void FrmEditarDetalleIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            mover(-posicion);
            
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if (posicion==posicionfinal)
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
        private void calculartotal()
        {
            int stock = 0;
            if (this.txtStock.Text!=string.Empty)
            {
                stock = Convert.ToInt32(this.txtStock.Text);
            }
            decimal fleteunitario = 0;
            if (this.txtFleteUnitario.Text != string.Empty)
            {
                fleteunitario = Convert.ToDecimal(this.txtFleteUnitario.Text);
            }
            decimal fletecontado = 0;
            if (this.txtFleteContado.Text != string.Empty)
            {
                fletecontado = Convert.ToDecimal(this.txtFleteContado.Text);
            }
            decimal carguiocontado = 0;
            if (this.txtCarguioContado.Text != string.Empty)
            {
                carguiocontado = Convert.ToDecimal(this.txtCarguioContado.Text);
            }
            decimal Carguiounitario = 0;
            if (this.txtCargioUnitario.Text != string.Empty)
            {
                Carguiounitario = Convert.ToDecimal(this.txtCargioUnitario.Text);
            }
            decimal fletetot = stock * fleteunitario;
            decimal fletexpagar = fletetot - fletecontado;
            decimal carguiotot = stock * Carguiounitario;
            decimal carguioxpagar = carguiotot - carguiocontado;
            this.txtTotalcancelado.Text = (fletetot + carguiotot).ToString("#,#0.00");
            this.txtTotalporCancelar.Text = (fletexpagar + carguioxpagar).ToString("#,#0.00");
        }
        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            this.calculartotal();
        }

        private void txtFleteUnitario_TextChanged(object sender, EventArgs e)
        {
            this.calculartotal();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(this.dataListadoDetalle.Rows[posicion].Cells["stock_inicial"].Value) == Convert.ToInt32(this.dataListadoDetalle.Rows[posicion].Cells["stock_actual"].Value))
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Id;
                        string Rpta = "";


                        Id = txtIddetalleingreso.Text;
                        Rpta = NIngreso.Eliminar(Convert.ToInt32(Id));//cambiar
                        MostrarDetalle();                                          //sumar valores para editar ingreso
                        decimal InfleteTotal = 0;
                        decimal InfleteUnitario = 0;
                        decimal InfleteContado = 0;
                        decimal InfletePorPagar = 0;
                        decimal InCarguioTotal = 0;
                        decimal InCarguioUnitario = 0;
                        decimal InCarguioContado = 0;
                        decimal InCarguioPorPagar = 0;
                        decimal InTotal = 0;
                        foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                        {
                            InfleteTotal = InfleteTotal + Convert.ToDecimal(row.Cells["Flete_Total"].Value);
                            InfleteUnitario = InfleteUnitario + Convert.ToDecimal(row.Cells["Flete_Unitario"].Value);
                            InfleteContado = InfleteContado + Convert.ToDecimal(row.Cells["Flete_Contado"].Value);
                            InfletePorPagar = InfletePorPagar + Convert.ToDecimal(row.Cells["Flete_x_Pagar"].Value);
                            InCarguioUnitario = InCarguioUnitario + Convert.ToDecimal(row.Cells["Carguio_Unitario"].Value);
                            InCarguioTotal = InCarguioTotal + Convert.ToDecimal(row.Cells["Carguio_Total"].Value);
                            InCarguioContado = InCarguioContado + Convert.ToDecimal(row.Cells["Carguio_Contado"].Value);
                            InCarguioPorPagar = InCarguioPorPagar + Convert.ToDecimal(row.Cells["Carguio_x_Pagar"].Value);
                            InTotal = InTotal + Convert.ToDecimal(row.Cells["Total"].Value);

                        }
                        //actualizar ingreso
                        string rpta2 = "";
                        rpta2 = NIngreso.EditarIngresoPorDetalle(Convert.ToInt32(this.txtIdingreso.Text), InfleteUnitario, InfleteTotal,
                            InfleteContado, InfletePorPagar, InCarguioUnitario, InCarguioTotal, InCarguioContado, InCarguioPorPagar, InTotal);
                        if (Convert.ToInt32(dataListadoDetalle.Rows.Count) == 0)
                        {
                            Id = txtIdingreso.Text;
                            Rpta = NIngreso.Anular(Convert.ToInt32(Id));
                        }
                        if (Rpta.Equals("OK") && rpta2.Equals("OK"))
                        {
                            this.MensajeOk("Se Eliminó Correctamente el registro");
                            MostrarDetalle();
                        }
                        else
                        {
                            if (!Rpta.Equals("OK"))
                                this.MensajeError(Rpta);
                            else
                                this.MensajeError(rpta2);
                        }


                        this.MostrarDetalle();
                    }
                }
                else
                {
                    this.MensajeError("No se puede eliminar ya que realizo una venta del registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtFleteContado_TextChanged(object sender, EventArgs e)
        {
            this.calculartotal();
        }

        private void txtCargioUnitario_TextChanged(object sender, EventArgs e)
        {
            this.calculartotal();
        }

        private void txtCarguioContado_TextChanged(object sender, EventArgs e)
        {
            this.calculartotal();
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sId = cbProducto.SelectedValue.ToString();
            txtIdProducto.Text = sId;
        }

        private void btnsiguiente_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnsiguiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtnrocomprobante.Focus();
        }

        private void btnUltimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtnrocomprobante.Focus();
        }

        private void btnatras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtnrocomprobante.Focus();
        }

        private void btnPrimero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtnrocomprobante.Focus();
        }

        private void btnModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtnrocomprobante.Focus();
        }
    }
}
