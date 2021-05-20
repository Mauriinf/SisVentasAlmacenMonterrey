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
    public partial class FrmCobros : Form
    {
        public int IDTrabajador;
        public FrmCobros()
        {
            InitializeComponent();
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
        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[2].Visible = false;
            //this.dataListado.Columns[3].Visible = false;*/
        }
        //Método Mostrar
        public void Mostrar()
        {
            this.dataListado.DataSource = NCobros.Mostrar();
            this.AlternarColorFilasDataGridView(dataListado);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            tam();
        }
        public void BuscarPorCliente()
        {
            this.dataListado.DataSource = NCobros.Buscarcliente(this.txtBuscar.Text);
            this.AlternarColorFilasDataGridView(dataListado);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            tam();
        }
        public void BuscarPorNroRecibo()
        {
            this.dataListado.DataSource = NCobros.Buscarnumerorecibo(this.txtBuscar.Text);
            this.AlternarColorFilasDataGridView(dataListado);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            tam();
        }
        private void tam()
        {
            dataListado.Columns[10].DefaultCellStyle.Format = "#,#0.00";
            dataListado.Columns[11].DefaultCellStyle.Format = "#,#0.00";
            dataListado.Columns[8].DefaultCellStyle.Format = "#,#0.00";
            dataListado.Columns[9].DefaultCellStyle.Format = "#,#0.00";

        }

        //motodo alternar color datagridview
        private void AlternarColorFilasDataGridView(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.White;//color intercalado
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 213, 159);//color intercalado
            this.dataListado.GridColor = Color.FromArgb(232, 4, 10);//cambiar color de lineas
                                                                    //  this.dataListado.BorderStyle = BorderStyle.FixedSingle;
                                                                    //  this.dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(125, 190, 255);
                                                                    //  this.dataListado.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(125, 190, 255);
                                                                    // this.dataListado.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                                                    // dgv.Rows[1].Cells[1].Style.BackColor = Color.Red;
                                                                    //dataListado.CurrentRow.Cells[e.RowIndex].Style.BackColor = Color.Red;
        }
        private void FrmCobros_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnAgregar_MouseHover(object sender, EventArgs e)
        {
            this.btnAgregar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnAgregar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            this.btnAgregar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnAgregar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnEditar_MouseHover(object sender, EventArgs e)
        {
            this.btnEditar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnEditar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnEditar_MouseLeave(object sender, EventArgs e)
        {
            this.btnEditar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnEditar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnEliminar_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void btnImprimir_MouseHover(object sender, EventArgs e)
        {
            this.btnImprimir.BackgroundImage = CapaPresentacion.Properties.Resources.b2; 
            this.btnImprimir.BackgroundImageLayout = ImageLayout.Stretch;
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

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void btnImprimir_MouseLeave(object sender, EventArgs e)
        {
            this.btnImprimir.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnImprimir.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarCobro form = FrmAgregarCobro.GetInstancia();
            form.IdTrabajador = this.IDTrabajador;
            form.ShowDialog();
            Mostrar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            decimal a=0;
            FrmEditarCobro frm =new  FrmEditarCobro();
           
            frm.txtIdventa.Text= dataListado.CurrentRow.Cells["ID_Venta"].Value.ToString();
            frm.txtIdCobro.Text = dataListado.CurrentRow.Cells["ID_Cobro"].Value.ToString();
            frm.txtCliente.Text = dataListado.CurrentRow.Cells["Nombre"].Value.ToString();
            frm.txtNrofactura.Text = dataListado.CurrentRow.Cells["Factura"].Value.ToString();
            frm.txtDeudaanterior.Text = Convert.ToDecimal(dataListado.CurrentRow.Cells["Deuda_Anterior"].Value).ToString("#,#0.00");
            frm.txtDeudapendiente.Text = Convert.ToDecimal(dataListado.CurrentRow.Cells["Deuda_Pendiente"].Value).ToString("#,#0.00");
            frm.dtFechaCobro.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["Fecha"].Value);
            frm.txtTotalapagar.Text = Convert.ToDecimal(dataListado.CurrentRow.Cells["Pago"].Value).ToString("#,#0.00");
            frm.txtRebaja.Text = Convert.ToDecimal(dataListado.CurrentRow.Cells["Rebaja"].Value).ToString("#,#0.00");

            frm.ShowDialog();
            Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.cbBuscar.Text.Equals("Nombre"))
            {
                this.BuscarPorCliente();
            }
            else
            {
                this.BuscarPorNroRecibo();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (this.cbBuscar.Text.Equals("Nombre"))
            {
                this.BuscarPorCliente();
            }
            else
            {
                this.BuscarPorNroRecibo();
            }
        }
    }
}
