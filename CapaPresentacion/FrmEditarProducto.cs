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
    public partial class FrmEditarProducto : Form
    {
        private static FrmEditarProducto _Instancia;

        public static FrmEditarProducto GetInstancia()//nombre getinstancia //importante
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmEditarProducto();
            }
            return _Instancia;
        }
        public void setCategoria1(string idcategoria, string nombre)//nombre del metodo setcategoria con los parametros a recibir
        {

            this.txtIdcategoria.Text = idcategoria;
           // this.txtCategoria.Text = nombre;
        }
        public FrmEditarProducto()
        {
            InitializeComponent();
            this.txtCodigo.ReadOnly = true;
            this.txtIdcategoria.Enabled= false;
         // this.txt = true;
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
        private void FrmEditarProducto_Load(object sender, EventArgs e)
        {
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxCategoria(cbCategoria);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNombre.Text == string.Empty|| this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese nombre del producto");
                    errorIcono.SetError(txtCodigo, "Ingrese un Codigo del producto");

                }
                else
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Desea Actualizar los Datos", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string rpta = "";
                        rpta = NProducto.Editar(this.txtCodigo.Text.Trim().ToUpper(),
                                this.txtNombre.Text.Trim().ToUpper(),
                                 this.txtIdcategoria.Text.Trim().ToUpper(), this.txtUnidadmedida.Text.Trim().ToUpper());

                        if (rpta.Equals("OK"))
                        {

                            this.MensajeOk("Se Actualizó los Datos");

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

            this.Hide();
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

        private void btnBuscar_MouseHover(object sender, EventArgs e)
        {
            this.btnBuscar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnBuscar.BackgroundImageLayout = ImageLayout.Stretch;
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
        }

        private void FrmEditarProducto_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sId = cbCategoria.SelectedValue.ToString();
            txtIdcategoria.Text = sId;
        }
    }
}
