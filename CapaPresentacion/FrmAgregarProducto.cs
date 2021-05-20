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
    public partial class FrmAgregarProducto : Form
    {
        private bool IsNuevo = false;
        private static FrmAgregarProducto _Instancia;

        public static FrmAgregarProducto GetInstancia()//nombre getinstancia //importante
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmAgregarProducto();
            }
            return _Instancia;
        }
        public void setCategoria1(string idcategoria, string nombre)//nombre del metodo setcategoria con los parametros a recibir
        {

            this.txtIdcategoria.Text = idcategoria;
            //this.txtCategoria.Text = nombre;
        }
        public FrmAgregarProducto()
        {
            InitializeComponent();
            this.txtIdcategoria.ReadOnly = true;
            this.cbCategoria.Enabled = false;
            this.ttMensaje.SetToolTip(this.txtCodigo, "Ingrese el código");

            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Producto");
            this.ttMensaje.SetToolTip(this.cbCategoria, "Selecione la Categoría");
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
            this.txtIdcategoria.Text = string.Empty;
           // this.txtCategoria.Text = string.Empty;
            this.txtUnidadmedida.Text = string.Empty;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.cbCategoria.Enabled = valor;
            this.txtCodigo.ReadOnly = !valor;
            this.txtIdcategoria.Enabled =false;

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
                this.btnBuscar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnLimpiar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnBuscar.Enabled = false;
            }

        }
        private void btnBuscar_MouseHover(object sender, EventArgs e)
        {
            this.btnBuscar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Habilitar(false);
            this.Botones();
            AutoCompletado c = new AutoCompletado();
            
            c.llenarcomboBoxCategoria(cbCategoria);
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

                if (this.txtCodigo.Text == string.Empty || this.txtNombre.Text == string.Empty || this.txtIdcategoria.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtCodigo, "Ingrese un Valor");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(cbCategoria, "Ingrese un Valor");
                }
                else
                {
                    rpta = NProducto.Insertar(this.txtCodigo.Text.Trim().ToUpper(),
                            this.txtNombre.Text.Trim().ToUpper(),
                            this.txtIdcategoria.Text.Trim().ToUpper(), this.txtUnidadmedida.Text.Trim().ToUpper());
                    if (rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Insertó de forma correcta el registro");
                        Limpiar();
                        this.IsNuevo = false;
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
            this.IsNuevo = false;
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

        private void btnBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.btnBuscar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmAgregarCategoria form = new FrmAgregarCategoria();
            form.ShowDialog();
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxCategoria(cbCategoria);
        }
   

        private void FrmAgregarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                txtNombre.Focus();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                txtUnidadmedida.Focus();
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sId = cbCategoria.SelectedValue.ToString();
            txtIdcategoria.Text = sId;
        }
    }
}
