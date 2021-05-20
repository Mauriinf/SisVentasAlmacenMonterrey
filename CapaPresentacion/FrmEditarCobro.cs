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
    public partial class FrmEditarCobro : Form
    {
        private decimal pagopendiente = 0;
        public FrmEditarCobro()
        {
            InitializeComponent();
            
            this.txtIdventa.Enabled = false;
            this.txtDeudapendiente.Visible = false;
            this.txtCliente.Enabled = false;
            this.txtDeudaanterior.Enabled = false;
            this.txtIdventa.Visible = false;
            this.dataListadoCobro.Visible = false;

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
        private void MostrarCobroPorIDVenta()
        {
            this.dataListadoCobro.DataSource = NCobros.Mostrar_Cobros_IdVenta(Convert.ToInt32(this.txtIdventa.Text));

        }
        private void FrmEditarCobro_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void txtNrofactura_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnModificar_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_MouseHover(object sender, EventArgs e)
        {
            this.btnCancelar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnCancelar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnEliminar_MouseHover(object sender, EventArgs e)
        {
            this.btnEliminar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancelar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnCancelar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "", rpta2 = "", rpta3 = "";
                    rpta3 = NCobros.ActualizarDetalle_Venta_al_EliminarCobro(Convert.ToInt32(txtIdventa.Text), Convert.ToDecimal(txtTotalapagar.Text), Convert.ToDecimal(txtRebaja.Text));
                    rpta2 = NCobros.Actualizar_Venta_al_EliminarCobro(Convert.ToInt32(txtIdventa.Text), Convert.ToDecimal(txtTotalapagar.Text), Convert.ToDecimal(txtRebaja.Text));
                    Rpta = NCobros.Eliminar(Convert.ToInt32(txtIdCobro.Text));
                    if (rpta2.Equals("OK") && rpta2.Equals("OK"))
                    {
                        this.MensajeOk("Accion correcta");
                    }
                    else
                    {
                        if (!rpta2.Equals("OK"))
                        {
                            this.MensajeError(rpta2);
                        }
                        else
                        {
                            this.MensajeError(rpta3);
                        }
                    }
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Eliminó Correctamente el Cobro");
                        MostrarCobroPorIDVenta();
                        string rpta6 = "";
                        int idcobro;
                        decimal anterior;
                        decimal porcobrar;
                        decimal auxanterior = 0;
                        decimal auxpago = 0;
                        decimal auxrebaja = 0;
                        decimal auxporcobrar = 0;
                        foreach (DataGridViewRow row in dataListadoCobro.Rows)
                        {
                            idcobro = Convert.ToInt32(row.Cells["ID_Cobro"].Value);
                            auxpago = Convert.ToDecimal(row.Cells["Pago"].Value);
                            auxrebaja = Convert.ToDecimal(row.Cells["Rebaja"].Value);
                            if (auxpago == 0)
                            {
                                auxanterior = Convert.ToDecimal(row.Cells["Deuda_Anterior"].Value);
                                auxporcobrar = Convert.ToDecimal(row.Cells["Deuda_Pendiente"].Value);
                            }
                            else
                            {
                                anterior = auxporcobrar;
                                porcobrar = anterior - auxpago - auxrebaja;
                                rpta6 = NCobros.actualizarCobro_por_detalle_venta(idcobro, anterior, porcobrar);
                                auxporcobrar = porcobrar;
                                if (!rpta6.Equals("OK"))
                                {
                                    this.MensajeError(rpta6);
                                }
                            }
                        }


                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            this.btnEliminar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
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

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
