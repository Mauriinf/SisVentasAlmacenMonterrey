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
    public partial class FrmAgregarCobro : Form
    {
        public int IdTrabajador;
        private decimal pagopendiente = 0;
        private static FrmAgregarCobro _instancia;
        private bool IsNuevo;
        public FrmAgregarCobro()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente, "Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtIdcliente, "Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtCi, "Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtDeudaanterior, "Seleccione una Venta");
            this.ttMensaje.SetToolTip(this.txtNrofactura, "Ingrese el Nro de Factura");
            this.ttMensaje.SetToolTip(this.txtNroTalonario, "Ingrese el Nro de Talonario");
            this.ttMensaje.SetToolTip(this.txtTotalapagar, "Ingrese el monto a pagar");
            this.ttMensaje.SetToolTip(this.txtRebaja, "Ingrese una rebaja");
            this.txtIdventa.Visible = false;
            this.txtDeudapendiente.Visible = false;
            this.txtCliente.Enabled = false;
            this.txtIdcliente.Enabled = false;

            this.txtCi.Enabled = false;

            this.txtDeudaanterior.Enabled = false;
            this.btnGuardar.Enabled = false;
        }
        public static FrmAgregarCobro GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmAgregarCobro();
            }
            return _instancia;
        }
        public void setCliente_ventas(string idventa, string idcliente, string ci, string nombre, string importetotal, string saldoxcobrar, string totalcancelado, string deudaanterior)
        {

            this.txtIdcliente.Text = idcliente;
            this.txtCliente.Text = nombre;
            this.txtIdventa.Text = idventa;
            this.txtCi.Text = ci;
            this.lblImportetotal.Text = importetotal;
            this.lblSaldoxcobrar.Text = saldoxcobrar;
            this.lblTotalcancelado.Text = totalcancelado;
            this.txtDeudaanterior.Text = deudaanterior;
            // MessageBox.Show(nombre, "Sistema de MONTEREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.txtIdventa.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtNrofactura.Text = string.Empty;
            this.txtNroTalonario.Text = string.Empty;
            this.txtTotalapagar.Text = string.Empty;
            this.txtRebaja.Text = string.Empty;
            this.txtDeudapendiente.Text = string.Empty;
            this.txtCi.Text = string.Empty;
            this.lblImportetotal.Text = string.Empty;
            this.lblSaldoxcobrar.Text = string.Empty;
            this.lblTotalcancelado.Text = string.Empty;
            this.txtDeudaanterior.Text = string.Empty;

        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNrofactura.ReadOnly = !valor;
            this.txtNroTalonario.ReadOnly = !valor;
            this.dtFechaCobro.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtTotalapagar.ReadOnly = !valor;
            this.txtRebaja.ReadOnly = !valor;



        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnBuscarCliente.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnBuscarCliente.Enabled = false;
            }

        }
        private void FrmAgregarCobro_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            
            this.Habilitar(false);
            this.Botones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();

            this.Habilitar(true);
            this.txtNrofactura.Focus();
        }

        private void FrmAgregarCobro_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _instancia = null;
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
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

        private void txtTotalapagar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaCliente_Cobro form = new FrmVistaCliente_Cobro();
            form.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                string rpta2 = "";
                if (this.txtIdcliente.Text == string.Empty || this.txtNroTalonario.Text == string.Empty || this.txtNrofactura.Text == string.Empty || this.txtTotalapagar.Text == string.Empty
                    || this.txtNroTalonario.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtCliente, "Ingrese un Valor");
                    errorIcono.SetError(txtNrofactura, "Ingrese un Valor");
                    errorIcono.SetError(txtNroTalonario, "Ingrese un Valor");
                    errorIcono.SetError(txtTotalapagar, "Ingrese un Valor");
                    errorIcono.SetError(txtNroTalonario, "Ingrese un Valor");

                }
                else
                {
                    decimal rebaja = 0;
                    if (this.txtRebaja.Text != string.Empty)
                    {
                        rebaja = Convert.ToDecimal(txtRebaja.Text);
                    }

                    pagopendiente = Convert.ToDecimal(txtDeudaanterior.Text) - Convert.ToDecimal(txtTotalapagar.Text) - rebaja;
                    if (this.IsNuevo)
                    {
                        rpta = NCobros.InsertarCobro(Convert.ToInt32(txtIdventa.Text), IdTrabajador, Convert.ToInt32(txtNroTalonario.Text),cbTipo_Comprobante.Text,
                            txtNrofactura.Text, dtFechaCobro.Value, Convert.ToDecimal(txtDeudaanterior.Text),
                            Convert.ToDecimal(txtTotalapagar.Text), pagopendiente, rebaja);
                        rpta2 = NCobros.actualizar_detalle_venta(Convert.ToInt32(this.txtIdventa.Text),
                            Convert.ToDecimal(txtTotalapagar.Text), rebaja);
                        if (rpta.Equals("OK") && rpta2.Equals("OK"))
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");

                        }
                        else
                        {
                            if (!rpta.Equals("OK"))
                                this.MensajeError(rpta);
                            else
                                this.MensajeError(rpta2);
                        }
                    }




                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();





                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtNrofactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnBuscarCliente.Focus();
        }
    }
}
