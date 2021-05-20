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
using System.Data.SqlClient;
using System.Data;
namespace CapaPresentacion
{
    public partial class FrmAgregarIngreso : Form
    {
        public int IdTrabajador;
        private static FrmAgregarIngreso _instancia;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal InfleteTotal = 0;
        private decimal InfleteUnitario = 0;
        private decimal InfleteContado = 0;
        private decimal InfletePorPagar = 0;
        private decimal InCarguioTotal = 0;
        private decimal InCarguioUnitario = 0;
        private decimal InCarguioContado = 0;
        private decimal InCarguioPorPagar = 0;
        private decimal InTotal = 0;

        public FrmAgregarIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.cbProveedor, "Seleccione Proveedor");
            this.ttMensaje.SetToolTip(this.cbProducto, "Selecione el Producto");           
            this.ttMensaje.SetToolTip(this.txtFleteUnitario, "Ingrese el flete Unitario");
            this.ttMensaje.SetToolTip(this.txtFleteContado, "Ingrese el flete cancelado");
            this.ttMensaje.SetToolTip(this.txtCargioUnitario, "Ingrese el carguio unitario");
            this.ttMensaje.SetToolTip(this.txtPlaca, "Selecione Conductor");
           // this.ttMensaje.SetToolTip(this.txtConductor, "Selecione Conductor");
            this.ttMensaje.SetToolTip(this.txtStock, "Inserte Stock");
            this.ttMensaje.SetToolTip(this.txtnrocomprobante, "Inserte Nro comprobante");
            this.ttMensaje.SetToolTip(this.txtTalonario, "Inserte Nro Talonario");
            this.txtIdconductor.Visible = false;
            this.txtConductor.Visible = false;
            this.txtIdProveedor.Visible = false;
            this.txtIdProducto.Enabled = false;           
            
            this.txtnrocomprobante.ReadOnly = true;
            this.txtTalonario.ReadOnly = true;

            this.txtPlaca.Enabled = false;

            
        }
        public static FrmAgregarIngreso GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmAgregarIngreso();
            }
            return _instancia;
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
           // this.txtPlaca.Text = string.Empty;
            //this.txtIdProducto.Text = string.Empty;
            //this.txtIdconductor.Text = string.Empty;
            this.txtnrocomprobante.Text = string.Empty;
            this.txtTalonario.Text = string.Empty;
            //this.txtProducto.Text = string.Empty;
            //this.txtConductor.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtFleteContado.Text = string.Empty;
            this.txtCarguioContado.Text = string.Empty;
            this.txtFleteUnitario.Text = string.Empty;
            this.txtCargioUnitario.Text = string.Empty;
            
            this.lblTotalporCancelar.Text = "0,0";
            this.lblTotal.Text = "0,0";
            this.lblTotalCancelado.Text = "0,0";
            this.crearTabla();

        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("ID_Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("stock_actual", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Flete_Unitario", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Flete_Total", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Flete_Contado", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Flete_x_Pagar", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Carguio_Unitario", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Carguio_Total", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Carguio_Contado", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Carguio_x_Pagar", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Total", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
            this.AlternarColorFilasDataGridView(dataListadoDetalle);
        }
        private void LimpiarDetalle()
        {

            //this.txtIdProducto.Text = string.Empty;
           // this.txtProducto.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtFleteUnitario.Text= string.Empty;
            this.txtFleteContado.Text = string.Empty;
            this.txtCargioUnitario.Text = string.Empty;
            this.txtCarguioContado.Text = string.Empty;

        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {

            this.btnNuevoProveedor.Enabled = valor;
            this.cbProveedor.Enabled = valor;
            this.txtnrocomprobante.ReadOnly = !valor;
            this.txtTalonario.ReadOnly = !valor;
            this.cbConductor.Enabled = valor;
            this.txtStock.ReadOnly = !valor;
            this.cbProducto.Enabled = valor;
            this.txtCarguioContado.ReadOnly = !valor;
            this.txtFleteUnitario.ReadOnly = !valor;
            this.txtCargioUnitario.ReadOnly = !valor;
            this.txtFleteContado.ReadOnly = !valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.cbDescargo.Enabled = valor;
            this.cbDestino.Enabled = valor;
            this.dtFechaIngreso.Enabled = valor;
            this.dtFechaSalida.Enabled = valor;

            this.btnBuscarProducto.Enabled = valor;
            this.btnBuscarConductor.Enabled = valor;
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
                this.btnQuitar.Enabled =false;
            }

        }
        private void sumar(decimal fleteunitario, decimal fletetotal, decimal fletecontado,decimal fletexpagar,
            decimal carguiounitario, decimal carguiototal, decimal carguiocontado, decimal carguioxpagar, decimal total)
        {
            InfleteTotal = InfleteTotal + fletetotal;
            InfleteUnitario = InfleteUnitario + fleteunitario;
            InfleteContado = InfleteContado + fletecontado;
            InfletePorPagar = InfletePorPagar + fletexpagar;
            InCarguioTotal = InCarguioTotal + carguiototal;
            InCarguioUnitario = InCarguioUnitario + carguiounitario;
            InCarguioContado = InCarguioContado + carguiocontado;
            InCarguioPorPagar = InCarguioPorPagar + carguioxpagar;
            InTotal = InTotal + total;
         }
        private void restar(decimal fleteunitario, decimal fletetotal, decimal fletecontado, decimal fletexpagar,
            decimal carguiounitario, decimal carguiototal, decimal carguiocontado, decimal carguioxpagar, decimal total)
        {
            InfleteTotal = InfleteTotal - fletetotal;
            InfleteUnitario = InfleteUnitario - fleteunitario;
            InfleteContado = InfleteContado - fletecontado;
            InfletePorPagar = InfletePorPagar - fletexpagar;
            InCarguioTotal = InCarguioTotal - carguiototal;
            InCarguioUnitario = InCarguioUnitario - carguiounitario;
            InCarguioContado = InCarguioContado - carguiocontado;
            InCarguioPorPagar = InCarguioPorPagar - carguioxpagar;
            InTotal = InTotal - total;
        }
        private void calcular()
        {

            decimal fu, fc, cu, cc;
            int c1;

            if (this.txtStock.Text.Equals(""))
                c1 = 0;
            else
                c1 = Convert.ToInt32(txtStock.Text);
            if (this.txtFleteUnitario.Text.Equals(""))
                fu = 0;
            else
                fu = Convert.ToDecimal(txtFleteUnitario.Text);
            if (this.txtFleteContado.Text.Equals(""))
                fc = 0;
            else
                fc = Convert.ToDecimal(txtFleteContado.Text);
            if (this.txtCargioUnitario.Text.Equals(""))
                cu = 0;
            else
                cu = Convert.ToDecimal(txtCargioUnitario.Text);
            if (this.txtCarguioContado.Text.Equals(""))
                cc = 0;
            else
                cc = Convert.ToDecimal(txtCarguioContado.Text);
            //if (!this.txtStock.Text.Equals("")&& !this.txtFleteContado.Text.Equals("")&& !this.txtCargioUnitario.Text.Equals(""))
            //{
            lblFleteTotal.Text = (c1*fu).ToString("#,#0.00");
            lblfleteporcancelar.Text = (Convert.ToDecimal(lblFleteTotal.Text) - fc).ToString("#,#0.00");
            lblCarguioTotal.Text = (c1 * cu).ToString("#,#0.00");
            lblCarguioporcancelar.Text = (Convert.ToDecimal(lblCarguioTotal.Text) - cc).ToString("#,#0.00");
            lbltotalfeleteycarguio.Text = (Convert.ToDecimal(lblCarguioTotal.Text) + Convert.ToDecimal(lblFleteTotal.Text)).ToString("#,#0.00");
            //lblEstado.Text = (v1 * v4).ToString("#,#0.00");
            // lblTotal.Text = (v3 + Convert.ToDecimal(lblfleteporcancelar.Text) + Convert.ToDecimal(lblCarguioTotal.Text)).ToString("#,##0");
            // lblcancelado.Text = ( Convert.ToDecimal(txtFleteContado.Text)).ToString("#,#0.00");
            // }      
        }
        private void btnBuscarConductor_Click_1(object sender, EventArgs e)
        {
            FrmAgregarConductor form = new FrmAgregarConductor();
            form.ShowDialog();

            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBox(cbConductor);
        }

        private void FrmAgregarIngreso_Load(object sender, EventArgs e)
        {
            
            this.Left = 0;
            IsNuevo = true;
            this.Habilitar(true);
            this.Botones();
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBox(cbConductor);
            c.llenarcomboBoxProducto(cbProducto);
            c.llenarcomboBoxProveedor(cbProveedor);
            string sId = cbProveedor.SelectedValue.ToString();
            txtIdProveedor.Text = sId;
            sId = cbProducto.SelectedValue.ToString();
            txtIdProducto.Text = sId;
            sId = cbConductor.SelectedValue.ToString();
            txtIdconductor.Text = sId;
            this.crearTabla();
            //c.AutocompletarConductor(txtConductor,txtIdconductor,txtPlaca);    
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto form = new FrmAgregarProducto();
            form.ShowDialog();

            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxProducto(cbProducto);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtnrocomprobante.Focus();
            this.LimpiarDetalle();
            calcular();
            //calcular();
        }

        private void FrmAgregarIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            calcular();
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.LimpiarDetalle();
            _instancia = null;
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {
                
                if (this.txtIdconductor.Text == string.Empty || this.txtTalonario.Text == string.Empty || this.txtnrocomprobante.Text == string.Empty  || this.txtIdProveedor.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    
                    //errorIcono.SetError(txtConductor, "Ingrese un Valor");
                   
                    errorIcono.SetError(cbProveedor, "Seleccione");
                    errorIcono.SetError(cbConductor, "Seleccione");
                    errorIcono.SetError(txtnrocomprobante, "Ingrese un Valor");
                    errorIcono.SetError(txtTalonario, "Ingrese un Valor");
                }
                else
                {
                    if (dtFechaSalida.Value> dtFechaIngreso.Value)
                    {
                        MessageBox.Show("La fecha de salida no puede ser mayo a la de Ingreso", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (this.IsNuevo)
                        {


                            rpta = NIngreso.Insertar(Convert.ToInt32(this.txtIdconductor.Text), IdTrabajador,
                                Convert.ToInt32(this.txtIdProveedor.Text), dtFechaSalida.Value,
                                dtFechaIngreso.Value, txtTalonario.Text, cbTipo_Comprobante.Text, this.txtnrocomprobante.Text.Trim().ToUpper(), cbDestino.Text, cbDescargo.Text,
                                InfleteUnitario, InfleteTotal, InfleteContado, InfletePorPagar,InCarguioUnitario, InCarguioTotal, InCarguioContado, InCarguioPorPagar, InTotal, "EMITIDO", dtDetalle);
                        }


                        if (rpta.Equals("OK"))
                        {
                            if (this.IsNuevo)
                            {
                                this.MensajeOk("Se Insertó de forma correcta el registro");
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
                    }
                    
                    


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            if (rpta.Equals("OK"))
            {
                this.Hide();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtIdProducto.Text == string.Empty
                    || this.txtFleteUnitario.Text == string.Empty || this.txtCargioUnitario.Text == string.Empty
                    || this.txtFleteContado.Text == string.Empty || this.txtStock.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(cbProducto, "Selecione un Valor");
                    errorIcono.SetError(txtStock, "Ingrese un Valor");
                   
                    errorIcono.SetError(txtFleteContado, "Ingrese un Valor");
                    errorIcono.SetError(txtFleteUnitario, "Ingrese un Valor");
                    errorIcono.SetError(txtCargioUnitario, "Ingrese un Valor");

                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToString(row["ID_Producto"]) == this.txtIdProducto.Text)
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el producto en el detalle");
                        }
                    }
                    if (registrar)
                    {
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        decimal fletetot = Convert.ToInt32(this.txtStock.Text) * Convert.ToDecimal(this.txtFleteUnitario.Text);
                        decimal fletexpagar=fletetot- Convert.ToDecimal(this.txtFleteContado.Text);
                        decimal carguiotot= Convert.ToInt32(this.txtStock.Text) * Convert.ToDecimal(this.txtCargioUnitario.Text);
                        decimal carguioxpagar=carguiotot- Convert.ToDecimal(this.txtCarguioContado.Text);
                        row["ID_Producto"] = (this.txtIdProducto.Text);
                        row["Producto"] = this.cbProducto.Text;
                        row["stock_inicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["stock_actual"] = Convert.ToInt32(this.txtStock.Text);
                        row["Flete_Unitario"] = Convert.ToDecimal(this.txtFleteUnitario.Text);
                        row["Flete_Total"] = fletetot;
                        row["Flete_Contado"] = Convert.ToDecimal(this.txtFleteContado.Text);
                        row["Flete_x_Pagar"] = fletexpagar;
                        row["Carguio_Unitario"] = Convert.ToDecimal(this.txtCargioUnitario.Text);
                        row["Carguio_Total"] = carguiotot;
                        row["Carguio_Contado"] = Convert.ToDecimal(this.txtCarguioContado.Text);
                        row["Carguio_x_Pagar"] = carguioxpagar;
                        row["Total"] = fletetot + carguiotot;
                        this.dtDetalle.Rows.Add(row);
                        this.sumar(Convert.ToDecimal(this.txtFleteUnitario.Text), fletetot, Convert.ToDecimal(this.txtFleteContado.Text),
                            fletexpagar, Convert.ToDecimal(this.txtCargioUnitario.Text), carguiotot, Convert.ToDecimal(this.txtCarguioContado.Text),
                            carguioxpagar, fletetot + carguiotot);
                        this.lblTotal.Text = InTotal.ToString("#,#0.00");
                        this.lblTotalCancelado.Text = (InfleteContado+InCarguioContado).ToString("#,#0.00");
                        this.lblTotalporCancelar.Text = (InfletePorPagar + InCarguioPorPagar).ToString("#,#0.00");
                        this.LimpiarDetalle();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            cbProducto.Focus();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                decimal fletetot = Convert.ToInt32(row["stock_inicial"].ToString()) * Convert.ToDecimal(row["Flete_Unitario"].ToString());
                decimal fletexpagar = fletetot - Convert.ToDecimal(row["Flete_Contado"].ToString());
                decimal carguiotot = Convert.ToInt32(row["stock_inicial"].ToString()) * Convert.ToDecimal(row["Carguio_Unitario"].ToString());
                decimal carguioxpagar = carguiotot - Convert.ToDecimal(row["Carguio_Contado"].ToString());
                this.restar(Convert.ToDecimal(row["Flete_Unitario"].ToString()), fletetot, Convert.ToDecimal(row["Flete_Contado"].ToString()),
                            fletexpagar, Convert.ToDecimal(row["Carguio_Unitario"].ToString()), carguiotot, Convert.ToDecimal(row["Carguio_Contado"].ToString()),
                            carguioxpagar, fletetot + carguiotot);
                this.lblTotal.Text = InTotal.ToString("#,#0.00");
                this.lblTotalCancelado.Text = (InfleteContado + InCarguioContado).ToString("#,#0.00");
                this.lblTotalporCancelar.Text = (InfletePorPagar + InCarguioPorPagar).ToString("#,#0.00");
                
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }
        //motodo alternar color datagridview
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
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //this.IsNuevo = false;
            //this.Botones();
            this.Limpiar();
           // this.Habilitar(false);
            this.LimpiarDetalle();
      
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
                    if (e.KeyChar==',')
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
                     e.Handled = true;
                     
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

        private void txtnrocomprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtFleteUnitario_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtFleteContado_TextChanged(object sender, EventArgs e)
        {
            calcular();

        }

        private void txtCargioUnitario_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtCarguioContado_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtConductor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbConductor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SqlConnection SqlCon = new SqlConnection();
            SqlCommand cmd;
            SqlDataReader dr;
            SqlCon.ConnectionString = NTrabajador.cadenaConexion();
            SqlCon.Open();
            cmd = new SqlCommand("select idconductor,placa from conductor where idconductor=" + Convert.ToUInt32(cbConductor.SelectedValue.ToString()) + " ", SqlCon);
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string sId = cbConductor.SelectedValue.ToString();
                    string sPlaca = dr.GetString(1).ToString();
                    txtIdconductor.Text = sId;
                    txtPlaca.Text = sPlaca;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {            
           string sId = cbProducto.SelectedValue.ToString();
            txtIdProducto.Text = sId;
           
        }

        private void btnAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Tab))
                btnGuardar.Focus();
            if (e.KeyChar == (char)(Keys.Enter))
              cbProducto.Focus();
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            FrmAgregarProveedor form = new FrmAgregarProveedor();
            form.ShowDialog();

            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxProveedor(cbProveedor);
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sId = cbProveedor.SelectedValue.ToString();
            txtIdProveedor.Text = sId;
        }

        private void cbProveedor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string sId = cbProveedor.SelectedValue.ToString();
            txtIdProveedor.Text = sId;
        }
    }
}
