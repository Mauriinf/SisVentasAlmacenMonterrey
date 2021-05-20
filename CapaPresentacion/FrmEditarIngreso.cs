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
namespace CapaPresentacion
{
    public partial class FrmEditarIngreso : Form
    {
        private static FrmEditarIngreso _instancia;
        public string idProveedor;
        public string Proveedor;
        public string idConductor;
        public string Conductor;
        public string placa;
        public FrmEditarIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.cbProveedor, "Seleccione Proveedor");            
            this.ttMensaje.SetToolTip(this.txtPlaca, "Selecione Conductor");
            this.ttMensaje.SetToolTip(this.cbConductor, "Selecione Conductor");          
            this.ttMensaje.SetToolTip(this.txtnrocomprobante, "Inserte Nro comprobante");
            this.ttMensaje.SetToolTip(this.txtTalonario, "Inserte Nro talonario");
            this.txtIdingreso.ReadOnly = true;
            this.txtIdconductor.Visible = false;
            this.txtIdProveedor.Visible = false;
            this.txtIdtrabajador.Visible = false;
            //this.txtConductor.Enabled = false;
            this.txtPlaca.Enabled = false;
            this.txtIdingreso.Enabled = false;
        }
        public static FrmEditarIngreso GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmEditarIngreso();
            }
            return _instancia;
        }
        public void setConductor(string idConductor, string placa, string nombre)
        {
            this.txtIdconductor.Text = idConductor;
            this.txtPlaca.Text = placa;
           // this.txtConductor.Text = nombre;
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
        private void label2_Click(object sender, EventArgs e)
        {

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
                        if (dtFechaSalida.Value > dtFechaIngreso.Value)
                        {
                            MessageBox.Show("La fecha de salida no puede ser mayo a la de Ingreso", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            rpta = NIngreso.Editar(Convert.ToInt32(this.txtIdingreso.Text), Convert.ToInt32(this.txtIdconductor.Text),
                             Convert.ToInt32(this.txtIdProveedor.Text), dtFechaSalida.Value, dtFechaIngreso.Value, txtTalonario.Text, cbTipo_Comprobante.Text, this.txtnrocomprobante.Text.Trim().ToUpper(),
                             cbDestino.Text, cbDescargo.Text);
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

        private void btnDetalles_MouseLeave(object sender, EventArgs e)
        {
            this.btnDetalles.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnDetalles.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnDetalles_MouseHover(object sender, EventArgs e)
        {
            this.btnDetalles.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnDetalles.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnBuscarConductor_Click(object sender, EventArgs e)
        {
            FrmAgregarConductor form = new FrmAgregarConductor();
            form.ShowDialog();
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBox(cbConductor);
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            FrmEditarDetalleIngreso frm = FrmEditarDetalleIngreso.GetInstancia();
            frm.txtIdingreso.Text = this.txtIdingreso.Text;
            frm.txtnrocomprobante.Text = this.txtnrocomprobante.Text;
            frm.ShowDialog();

        }

        private void FrmEditarIngreso_Load(object sender, EventArgs e)
        {
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBox(cbConductor);
            c.llenarcomboBoxProveedor(cbProveedor);
            txtIdProveedor.Text = idProveedor;
            cbProveedor.Text = Proveedor;
            txtIdconductor.Text = idConductor;
            cbConductor.Text = Conductor;
            txtPlaca.Text = placa;
        }

        private void FrmEditarIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void txtnrocomprobante_KeyPress(object sender, KeyPressEventArgs e)
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
