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
   
    public partial class FrmAgregarTrabajador : Form
    {
        private bool IsNuevo = false;
        public FrmAgregarTrabajador()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Conductor");
            this.ttMensaje.SetToolTip(this.txtMaterno, "Ingrese el Apellido Materno");
            this.ttMensaje.SetToolTip(this.txtPaterno, "Ingrese el Apellido Paterno");
            this.ttMensaje.SetToolTip(this.txtCi, "Ingrese el Nro de Ci");
            this.ttMensaje.SetToolTip(this.txtTelefono, "Ingrese el Nro de Teléfono");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese Direccion");
            this.ttMensaje.SetToolTip(this.dtFechaNac, "Ingrese Fecha de Nacimiento");
            this.ttMensaje.SetToolTip(this.txtEmail, "Ingrese Direccion Email");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese nombre de Usario");
            this.ttMensaje.SetToolTip(this.txtPass, "Ingrese Contraseña");
            this.ttMensaje.SetToolTip(this.txtRepPass, "Repita Contraseña");
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
            this.txtCi.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPass.Text = string.Empty;
            this.txtRepPass.Text = string.Empty;

        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtMaterno.ReadOnly = !valor;
            this.txtPaterno.ReadOnly = !valor;
            this.txtCi.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtPass.ReadOnly = !valor;
            this.txtRepPass.ReadOnly = !valor;
            this.cbEstado.Enabled = valor;
            this.cbSexo.Enabled = valor;
            this.cbTipousuario.Enabled = valor;
            this.dtFechaNac.Enabled = valor;


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
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmAgregarTrabajador_Load(object sender, EventArgs e)
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
            this.btnNuevo.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnNuevo.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnNuevo_MouseLeave(object sender, EventArgs e)
        {
            this.btnNuevo.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnNuevo.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnGuardar_MouseHover(object sender, EventArgs e)
        {
            this.btnGuardar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
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

                if (this.txtNombre.Text == string.Empty || this.txtPaterno.Text == string.Empty || this.txtMaterno.Text == string.Empty || this.txtCi.Text == string.Empty
                    || this.txtUsuario.Text == string.Empty || this.txtPass.Text == string.Empty || this.txtRepPass.Text == string.Empty)//si esta vacio
                {
                    MensajeError("Falta ingresar algunos datos importantes, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                    errorIcono.SetError(txtPaterno, "Ingrese Apellido");
                    errorIcono.SetError(txtMaterno, "Ingrese Apellido");
                    errorIcono.SetError(txtCi, "Ingrese Nro de Ci");
                    errorIcono.SetError(txtUsuario, "Ingrese Usuario");
                    errorIcono.SetError(txtPass, "Ingrese contraseña");
                    errorIcono.SetError(txtRepPass, "Repita Contraseña");

                }
                else
                {
                    if (this.txtPass.Text.CompareTo(this.txtRepPass.Text)==0)
                    {
                        rpta = NTrabajador.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtPaterno.Text.Trim().ToUpper(), this.txtMaterno.Text.Trim().ToUpper(),
                        this.cbSexo.Text, this.dtFechaNac.Value, this.txtCi.Text, this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text, this.cbTipousuario.Text, this.txtUsuario.Text,
                        this.txtPass.Text, this.cbEstado.Text);

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
                    else
                    {
                        MensajeError("Las contraseñas no coinciden");
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
