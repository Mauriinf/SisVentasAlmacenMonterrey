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
    public partial class FrmEditarProveedor : Form
    {
        public FrmEditarProveedor()
        {
            InitializeComponent();
            this.txtId.Enabled  = false;
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {
                if (this.txtNombre.Text == string.Empty || this.txtDireccion.Text == string.Empty)//si esta vacio
                {
                    MensajeError("Falta ingresar algunos datos importantes, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                    
                    errorIcono.SetError(txtDireccion, "Ingrese Direccion");


                }
                else
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Desea Actualizar los Datos", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {

                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtId.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtDireccion.Text, this.cbDestino.Text, this.txtTelefono.Text, this.txtEmail.Text);
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

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
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

        private void button1_MouseHover(object sender, EventArgs e)
        {

            this.btnCancelar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnCancelar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancelar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnCancelar.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
