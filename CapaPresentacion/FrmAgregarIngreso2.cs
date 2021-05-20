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
    public partial class FrmAgregarIngreso2 : Form
    {
        public int IdTrabajador;
        private static FrmAgregarIngreso2 _instancia;
        private bool IsNuevo;
        private DataTable dtDetalle;
        public FrmAgregarIngreso2()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.cbProveedor, "Seleccione Proveedor");
            this.ttMensaje.SetToolTip(this.cbProducto, "Selecione el Producto");
            this.ttMensaje.SetToolTip(this.txtStock, "Inserte Stock");
            this.ttMensaje.SetToolTip(this.txtnrocomprobante, "Inserte Nro comprobante");
            this.ttMensaje.SetToolTip(this.txtTalonario, "Inserte Nro Talonario");
            this.txtIdProducto.Enabled = false;
            this.txtIdProveedor.Visible = false;
            this.txtnrocomprobante.ReadOnly = true;
            this.txtTalonario.ReadOnly = true;
            this.txtnrocomprobante.Enabled = false;
            // this.txtProducto.Enabled = false;

        }
        public static FrmAgregarIngreso2 GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmAgregarIngreso2();
            }
            return _instancia;
        }
       
        public void setProducto(string idproducto, string nombre)
        {
            this.txtIdProducto.Text = idproducto;
            //this.txtProducto.Text = nombre;
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
            //this.txtIdProducto.Text = string.Empty;           
            
            this.txtTalonario.Text = string.Empty;
            // this.txtProducto.Text = string.Empty;          
            this.txtStock.Text = string.Empty;            
                    
            this.crearTabla();
        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("ID_Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("stock_actual", System.Type.GetType("System.Int32"));
            
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
            this.AlternarColorFilasDataGridView(dataListadoDetalle);
        }
        //motodo alternar color datagridview
        private void AlternarColorFilasDataGridView(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.White;//color intercalado
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 213, 159);//color intercalado
            this.dataListadoDetalle.GridColor = Color.FromArgb(232, 4, 10);//cambiar color de lineas
                                                                           //  this.dataListado.BorderStyle = BorderStyle.FixedSingle;
                                                                           //  this.dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(125, 190, 255);
                                                                           //  this.dataListado.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(125, 190, 255);
                                                                           // this.dataListado.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                                                           // dgv.Rows[1].Cells[1].Style.BackColor = Color.Red;
                                                                           //dataListado.CurrentRow.Cells[e.RowIndex].Style.BackColor = Color.Red;
        }
        private void LimpiarDetalle()
        {
          //  this.txtIdProducto.Text = string.Empty;
            //this.txtProducto.Text = string.Empty;
            this.txtStock.Text = string.Empty;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {

            this.cbProveedor.Enabled = valor;
            this.btnNuevoProveedor.Enabled = valor;
            this.txtnrocomprobante.ReadOnly = !valor;
            this.txtTalonario.ReadOnly = !valor;
            this.txtStock.ReadOnly = !valor;            
            this.cbTipo_Comprobante.Enabled = valor;           
            this.dtFechaIngreso.Enabled = valor;
            this.cbProducto.Enabled = valor;
            this.btnBuscarProducto.Enabled = valor;           
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;

        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnAgregar.Enabled = true;
                this.btnQuitar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.btnQuitar.Enabled = false;
            }

        }
       
        private void FrmAgregarIngreso2_Load(object sender, EventArgs e)
        {
            this.txtnrocomprobante.Text = Convert.ToString(Nconexion.VerNroBoleta() + 1);
            this.Top = 0;
            this.Left = 0;
            IsNuevo = true; 
            this.Habilitar(true);
            this.Botones();
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxProducto(cbProducto);
            
            c.llenarcomboBoxProveedor(cbProveedor);
            this.crearTabla();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.LimpiarDetalle();
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
                    e.Handled = true;

                }
            }
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

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto form = new FrmAgregarProducto();
            form.ShowDialog();
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxProducto(cbProducto);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.txtnrocomprobante.Text = Convert.ToString(Nconexion.VerNroBoleta() + 1);
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtTalonario.Focus();
            this.LimpiarDetalle();
        }

        private void FrmAgregarIngreso2_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.LimpiarDetalle();
            _instancia = null;
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            try
            {

                if (this.txtnrocomprobante.Text == string.Empty || this.txtIdProveedor.Text == string.Empty || this.txtTalonario.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");                    
                    errorIcono.SetError(cbProveedor, "Seleccione un Valor");
                    errorIcono.SetError(txtnrocomprobante, "Ingrese un Valor");
                    errorIcono.SetError(txtTalonario, "Ingrese un Valor");
                }
                else
                {                   
                        if (this.IsNuevo)
                        {
                            rpta = NIngreso2.Insertar(IdTrabajador,
                                Convert.ToInt32(this.txtIdProveedor.Text),
                                dtFechaIngreso.Value,txtTalonario.Text, cbTipo_Comprobante.Text, this.txtnrocomprobante.Text.Trim().ToUpper()
                                , "EMITIDO", dtDetalle);
                        }
                   


                        if (rpta.Equals("OK"))
                        {
                            if (this.IsNuevo)
                            {
                                this.MensajeOk("Se Insertó de forma correcta el registro");
                                Nconexion.NroBoleta(Convert.ToInt32(txtnrocomprobante.Text));
                                this.txtnrocomprobante.Text = Convert.ToString(Nconexion.VerNroBoleta() + 1);
                            }

                        }
                        else
                        {
                            this.MensajeError(rpta);
                        }

                        this.IsNuevo = false;
                        this.Botones();
                        this.Limpiar();
                        this.Habilitar(false);
;                        this.LimpiarDetalle();
                  




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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtIdProducto.Text == string.Empty                    
                    || this.txtStock.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(cbProducto, "Selecione un Valor");
                    errorIcono.SetError(txtStock, "Ingrese un Valor");         

                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToString(row["ID_Producto"]) == this.txtIdProducto.Text)
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el producto en el detalle");
                        }
                    }
                    if (registrar)
                    {
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();                        
                        row["ID_Producto"] = (this.txtIdProducto.Text);
                        row["Producto"] = this.cbProducto.Text;
                        row["stock_inicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["stock_actual"] = Convert.ToInt32(this.txtStock.Text);                       
                        this.dtDetalle.Rows.Add(row);                        
                        this.LimpiarDetalle();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            cbProducto.Focus();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];          

                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void txtnrocomprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sId = cbProducto.SelectedValue.ToString();
            txtIdProducto.Text = sId;
        }

        private void btnAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cbProducto.Focus();
            if (e.KeyChar == (char)(Keys.Tab))
                btnGuardar.Focus();
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

        private void Cambiar_Click(object sender, EventArgs e)
        {
            this.txtnrocomprobante.Enabled = true;
        }
    }
}
