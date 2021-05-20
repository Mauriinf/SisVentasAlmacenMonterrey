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
    public partial class FrmEditarVenta : Form
    {
        private static FrmEditarVenta _instancia;
        public string cliente = "";
        public FrmEditarVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtIdVenta, "Código venta");
            this.ttMensaje.SetToolTip(this.txtNrorecibo, "Nro de recibo");
            this.ttMensaje.SetToolTip(this.txtNroTalonario, "Nro de Talonario");
            this.ttMensaje.SetToolTip(this.cbTipo_Comprobante, "Tipo Comprobante");
            this.ttMensaje.SetToolTip(this.cbCliente, "Nombre del cliente");
           
            this.txtIdcliente.Visible = false;
            this.cbCliente.Enabled = false;
            this.txtIdTrabajado.Visible = false;
           // this.txtCliente.Enabled = false;
           
            this.txtIdVenta.Enabled = false;
        }
        public static FrmEditarVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmEditarVenta();
            }
            return _instancia;
        }
        public void setCliente(string idCliente, string nombre, string appaterno,string apmaterno)
        {
            this.txtIdcliente.Text = idCliente;
           // this.txtCliente.Text = nombre;
           

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
        private void FrmEditarVenta_Load(object sender, EventArgs e)
        {
            cliente = cbCliente.Text;
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {
                if (this.txtIdcliente.Text == string.Empty || this.txtNrorecibo.Text == string.Empty || this.txtNroTalonario.Text == string.Empty || this.cbCliente.ValueMember == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNrorecibo, "Ingrese un Valor");
                    errorIcono.SetError(txtNroTalonario, "Ingrese un Valor");
                    errorIcono.SetError(cbCliente, "Ingrese un Valor");


                }
                else
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Desea Actualizar los Datos", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {

                        rpta = NVenta.EditarVenta(Convert.ToInt32(this.txtIdVenta.Text), Convert.ToInt32(this.txtIdcliente.Text),
                        dtFechaVenta.Value, this.txtNroTalonario.Text,cbTipo_Comprobante.Text, this.txtNrorecibo.Text.Trim().ToUpper());
                        if (rpta.Equals("OK"))
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }

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

        private void btnDetalles_MouseHover(object sender, EventArgs e)
        {
            this.btnDetalles.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnDetalles.BackgroundImageLayout = ImageLayout.Stretch;
            
        }

        private void btnDetalles_MouseLeave(object sender, EventArgs e)
        {
            this.btnDetalles.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnDetalles.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void FrmEditarVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            cbCliente.Enabled = true;
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxCliente(cbCliente);
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            FrmEditarDetalleVentas frm = FrmEditarDetalleVentas.GetInstancia();
            frm.txtIdVenta.Text = this.txtIdVenta.Text;
            frm.txtnrocomprobante.Text = this.txtNrorecibo.Text;
            frm.ShowDialog();
        }

        private void cbTipo_Comprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sId = cbCliente.SelectedValue.ToString();
            txtIdcliente.Text = sId;
        }
    }
}
