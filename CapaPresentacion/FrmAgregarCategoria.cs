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
    public partial class FrmAgregarCategoria : Form
    {
        private bool IsNuevo = false;

        private bool IsEditar = false;
        public FrmAgregarCategoria()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre de la Categoría");
            this.ttMensaje.SetToolTip(this.txtCodigo, "Ingrese el código");

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
            this.txtCodigo.Text = string.Empty;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            if (this.IsEditar)
            {
                this.txtCodigo.ReadOnly = valor;
            }
            else
                this.txtCodigo.ReadOnly = !valor;
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
        private void FrmAgregarCategoria_Load(object sender, EventArgs e)
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
            this.txtCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {
               
                if (this.txtNombre.Text == string.Empty || this.txtCodigo.Text == string.Empty)//si esta vacio
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                    errorIcono.SetError(txtCodigo, "Ingrese un Código");
                }
                else
                {                   
                    rpta = NCategoria.Insertar(this.txtCodigo.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper());

                    if (rpta.Equals("OK"))
                    {                       
                            this.MensajeOk("Se Insertó de forma correcta el registro");

                    }
                    else
                    {
                        this.MensajeError(rpta);
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
            this.btnNuevo.BackgroundImage = CapaPresentacion.Properties.Resources.b1;//../ir atras un directorio
            this.btnNuevo.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnCancelar_MouseHover(object sender, EventArgs e)
        {
            this.btnCancelar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;//../ir atras un directorio
            this.btnCancelar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            
            this.btnCancelar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;//../ir atras un directorio
            this.btnCancelar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnGuardar_MouseHover(object sender, EventArgs e)
        {
           
                this.btnGuardar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;//../ir atras un directorio
            this.btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
          
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
           
                this.btnGuardar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;//../ir atras un directorio
            this.btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
          
        }

        private void btnLimpiar_MouseHover(object sender, EventArgs e)
        {
          
                this.btnLimpiar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;//../ir atras un directorio
            this.btnLimpiar.BackgroundImageLayout = ImageLayout.Stretch;
        
        }

        private void btnLimpiar_MouseLeave(object sender, EventArgs e)
        {
            
                this.btnLimpiar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;//../ir atras un directorio
            this.btnLimpiar.BackgroundImageLayout = ImageLayout.Stretch;
           
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
