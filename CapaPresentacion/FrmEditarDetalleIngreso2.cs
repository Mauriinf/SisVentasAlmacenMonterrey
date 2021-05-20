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
    public partial class FrmEditarDetalleIngreso2 : Form
    {
        int posicion;
        int posicionfinal;
        int aux = 0;
        private static FrmEditarDetalleIngreso2 _instancia;
        public static FrmEditarDetalleIngreso2 GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmEditarDetalleIngreso2();
            }
            return _instancia;
        }


        public void setProducto(string idproducto, string nombre)
        {
            this.txtIdProducto.Text = idproducto;
           // this.txtProducto.Text = nombre;
        }
        public FrmEditarDetalleIngreso2()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtIdProducto, "Selecione Producto");
            this.ttMensaje.SetToolTip(this.cbProducto, "Selecione Producto");
            this.ttMensaje.SetToolTip(this.txtStock, "Inserte Stock actual");           
            this.txtIddetalleingreso.Visible = false;
            this.txtIdingreso.Visible = false;
            this.txtnrocomprobante.Enabled = false;
            //this.txtProducto.Enabled = false;
            this.txtIdProducto.Enabled = false;
            this.txtStockActual.Enabled = false;            
            this.dataListadoDetalle.Visible = false;
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
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NIngreso2.MostrarDetalle(this.txtIdingreso.Text);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListadoDetalle.Rows.Count);
            posicion = 0;
            posicionfinal = dataListadoDetalle.Rows.Count - 1;
        }
        private void mover(int paso)
        {
            posicion = posicion + paso;
            txtIddetalleingreso.Text = dataListadoDetalle.Rows[posicion].Cells["iddetalle_ingreso"].Value.ToString();
            txtIdProducto.Text = dataListadoDetalle.Rows[posicion].Cells["idProducto"].Value.ToString();
            cbProducto.Text = dataListadoDetalle.Rows[posicion].Cells["Producto"].Value.ToString();
            txtStock.Text = dataListadoDetalle.Rows[posicion].Cells["stock_inicial"].Value.ToString();
            txtStockActual.Text = dataListadoDetalle.Rows[posicion].Cells["stock_actual"].Value.ToString();
            aux = Convert.ToInt32(this.dataListadoDetalle.Rows[posicion].Cells["stock_inicial"].Value) - Convert.ToInt32(this.dataListadoDetalle.Rows[posicion].Cells["stock_actual"].Value);

        }
        private void FrmEditarDetalleIngreso2_Load(object sender, EventArgs e)
        {
            AutoCompletado c = new AutoCompletado();

            c.llenarcomboBoxProducto(cbProducto);
            this.MostrarDetalle();
            this.mover(0);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea Actualizar los Datos", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    
                    if (Convert.ToInt32(this.txtStock.Text) >= aux)
                    {
                        
                        rpta = NIngreso2.EditarDetalleIngreso2(Convert.ToInt32(this.txtIddetalleingreso.Text), this.txtIdProducto.Text,
                         Convert.ToInt32(this.txtStock.Text), Convert.ToInt32(this.txtStock.Text) - aux);


                        if (rpta.Equals("OK"))
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                            MostrarDetalle();
                        }
                        else
                        {

                            this.MensajeError(rpta);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El stock debe ser mayor igual a lo que ya se vendio", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            mover(-posicion);
           
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            if (posicion == 0)
            {
                MessageBox.Show("Ya estamos en el primer registro", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mover(-1);
            }
           
        }

        private void btnsiguiente_Click(object sender, EventArgs e)
        {
            if (posicion == posicionfinal)
            {
                MessageBox.Show("No hay mas registros", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mover(1);
            }
           
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            posicion = 0;
            if (posicion == posicionfinal)
            {
                MessageBox.Show("No hay mas registros", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mover(posicionfinal);
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

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            this.btnEliminar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnEliminar_MouseHover(object sender, EventArgs e)
        {
            this.btnEliminar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto form = new FrmAgregarProducto();
            form.ShowDialog();

            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxProducto(cbProducto);
            mover(0);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (e.KeyChar == '.')
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

        private void FrmEditarDetalleIngreso2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(this.dataListadoDetalle.Rows[posicion].Cells["stock_inicial"].Value) == Convert.ToInt32(this.dataListadoDetalle.Rows[posicion].Cells["stock_actual"].Value))
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Id;
                        string Rpta = "";


                        Id = txtIddetalleingreso.Text;
                        Rpta = NIngreso.Eliminar(Convert.ToInt32(Id));//cambiar
                                                                      //sumar valores para editar ingreso
                        if (Convert.ToInt32(dataListadoDetalle.Rows.Count) == 0)
                        {
                            Id = txtIdingreso.Text;
                            Rpta = NIngreso.Anular(Convert.ToInt32(Id));
                        }
                        if (Rpta.Equals("OK"))
                        {
                            this.MensajeOk("Se Eliminó Correctamente el registro");
                            MostrarDetalle();
                        }
                        else
                        {
                            this.MensajeError(Rpta);

                        }


                        this.MostrarDetalle();
                    }
                }
                else
                {
                    this.MensajeError("No se puede eliminar ya que realizo una venta del registro");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sId = cbProducto.SelectedValue.ToString();
            txtIdProducto.Text = sId;
        }

        private void btnsiguiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtnrocomprobante.Focus();
        }

        private void btnatras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtnrocomprobante.Focus();
        }

        private void btnUltimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtnrocomprobante.Focus();
        }

        private void btnPrimero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtnrocomprobante.Focus();
        }

        private void btnModificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtnrocomprobante.Focus();
        }
    }
}
