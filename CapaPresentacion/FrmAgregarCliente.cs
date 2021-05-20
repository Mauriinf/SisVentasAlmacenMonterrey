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
    public partial class FrmAgregarCliente : Form
    {
        private bool IsNuevo = false;
        public FrmAgregarCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Conductor");
            this.ttMensaje.SetToolTip(this.txtMaterno, "Ingrese el Apellido Materno");
            this.ttMensaje.SetToolTip(this.txtPaterno, "Ingrese el Apellido Paterno");
            this.ttMensaje.SetToolTip(this.txtci, "Ingrese el Nro de Ci");
            
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
            this.txtNombre.Text = string.Empty;
            this.txtMaterno.Text = string.Empty;
            this.txtPaterno.Text = string.Empty;
            this.txtci.Text = string.Empty;
            this.txtpuesto.Text = string.Empty;


        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtMaterno.ReadOnly = !valor;
            this.txtPaterno.ReadOnly = !valor;
            this.txtci.ReadOnly = !valor;
            this.txtpuesto.ReadOnly = !valor;


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
                this.btnLimpiar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnLimpiar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }

        }
        private void FrmAgregarCliente_Load(object sender, EventArgs e)
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
            this.txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnNuevo_MouseHover(object sender, EventArgs e)
        {
            this.btnNuevo.BackgroundImage = CapaPresentacion.Properties.Resources.b2;//../ir atras un directorio
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
            string rpta = "";
            try
            {

                if (this.txtNombre.Text == string.Empty || this.txtPaterno.Text == string.Empty)//si esta vacio
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                    errorIcono.SetError(txtPaterno, "Ingrese Apellido");
                    errorIcono.SetError(txtMaterno, "Ingrese Apellido");
                    errorIcono.SetError(txtci, "Ingrese Ci");

                }
                else
                {

                    rpta = NClientes.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtPaterno.Text.Trim().ToUpper(), this.txtMaterno.Text.Trim().ToUpper(), this.txtci.Text.Trim().ToUpper(), this.cbSexo.Text.Trim().ToUpper(), this.txtpuesto.Text.Trim().ToUpper());

                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Insertó de forma correcta el registro");

                    }
                    else
                    {
                        this.MensajeError(rpta);
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
            if (rpta.Equals("OK"))
            {
                this.Hide();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
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
                    if (Char.IsSeparator(e.KeyChar))
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

        private void txtPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
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
                    if (Char.IsSeparator(e.KeyChar))
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

        private void txtMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
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
                    if (Char.IsSeparator(e.KeyChar))
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

        private void txtci_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
