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
    public partial class FrmEditarIngreso2 : Form
    {
        public string idProveedor;
        public string Proveedor;
        public FrmEditarIngreso2()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.cbProveedor, "Seleccione Proveedor");           
            this.ttMensaje.SetToolTip(this.txtnrocomprobante, "Inserte Nro comprobante");
            this.ttMensaje.SetToolTip(this.txtTalonario, "Inserte Nro talonario");
            this.txtIdingreso.ReadOnly = true;            
            this.txtIdtrabajador.Visible = false;
            this.txtIdProveedor.Visible = false;
            this.txtIdingreso.Enabled = false;
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
        private void FrmEditarIngreso2_Load(object sender, EventArgs e)
        {
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxProveedor(cbProveedor);
            txtIdProveedor.Text = idProveedor;
            cbProveedor.Text = Proveedor;
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {
                if (this.txtnrocomprobante.Text == string.Empty || this.txtTalonario.Text == string.Empty || this.txtIdProveedor.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtnrocomprobante, "Ingrese número comprobante");
                    errorIcono.SetError(txtTalonario, "Ingrese número talonario");
                    errorIcono.SetError(cbProveedor, "SeleccioneProveedor");

                }
                else
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Desea Actualizar los Datos", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {

                        rpta = NIngreso2.Editar(Convert.ToInt32(this.txtIdingreso.Text),
                         Convert.ToInt32(this.txtIdProveedor.Text), dtFechaIngreso.Value,
                         txtTalonario.Text,cbTipo_Comprobante.Text, txtnrocomprobante.Text.Trim().ToUpper());
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

        private void FrmEditarIngreso2_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            FrmEditarDetalleIngreso2 frm = FrmEditarDetalleIngreso2.GetInstancia();
            frm.txtIdingreso.Text = this.txtIdingreso.Text;
            frm.txtnrocomprobante.Text = this.txtnrocomprobante.Text;
            frm.ShowDialog();
        }

        private void txtnrocomprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
            
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
    }
}
