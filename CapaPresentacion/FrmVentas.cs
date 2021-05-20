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
using System.Data;


namespace CapaPresentacion
{
    public partial class FrmVentas : Form
    {
        public int IDTrabajador;
        public FrmVentas()
        {
            InitializeComponent();
            txtIdventa.Visible = false;
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
            this.dataListado.Columns[3].Visible = false;
            
        }
        //Método Mostrar
        public void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
            this.AlternarColorFilasDataGridView(dataListado);
            this.AlternarColorFilasDataGridView(dataListadoDetalle);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            tam();
        }
        //Método Buscarpor fechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"), this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            this.AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarPorCliente()
        {
            this.dataListado.DataSource = NVenta.BuscarPorClientes(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarPorNroRecibo()
        {
            this.dataListado.DataSource = NVenta.BuscarPorNrorecibo(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void tam()
        {
            dataListado.Columns[9].DefaultCellStyle.Format = "#,#0.00";
            dataListado.Columns[10].DefaultCellStyle.Format = "#,#0.00";
            dataListado.Columns[11].DefaultCellStyle.Format = "#,#0.00";
            /*dataListado.Columns[4].Width = 90;
            dataListado.Columns[6].Width = 70;
            dataListado.Columns[5].Width = 90;
            dataListado.Columns[7].Width = 70;*/

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
            this.dataListadoDetalle.GridColor = Color.FromArgb(232, 4, 10);
        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(this.txtBuscar.Text==string.Empty)
                this.BuscarFechas();
            else
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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
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
                    string Rpta = "";
                    int aux = 0;
                    int ban = 0;
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));
                            aux++;
                            if (!Rpta.Equals("OK"))
                            {
                                ban = 1;
                                break;
                            }
                            

                        }
                    }
                    if (ban==0)
                    {
                        this.MensajeOk("Se Elimino Correctamente las Ventas seleccionadas");
                        this.chkEliminar.Checked = false;
                    }else
                    {
                        this.MensajeError(Rpta);
                    }
                    
                    if (aux == 0)
                    {
                        this.MensajeError("Debe seleccionar los registros a eliminar");
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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
            this.btnEliminar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
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
            this.btnEliminar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnImprimir_MouseLeave(object sender, EventArgs e)
        {
            this.btnImprimir.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnImprimir.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarVenta form = FrmAgregarVenta.GetInstancia();
            form.IdTrabajador = this.IDTrabajador;
            form.ShowDialog();

            Mostrar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditarVenta frm = FrmEditarVenta.GetInstancia();
            frm.txtIdVenta.Text = dataListado.CurrentRow.Cells["ID_Venta"].Value.ToString();
            frm.cbTipo_Comprobante.Text = dataListado.CurrentRow.Cells["Tipo_Comprobante"].Value.ToString();
            frm.txtNroTalonario.Text = dataListado.CurrentRow.Cells["Nro_Talonario"].Value.ToString();
            frm.txtNrorecibo.Text = dataListado.CurrentRow.Cells["Nro_Recibo"].Value.ToString();
            frm.dtFechaVenta.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["Fecha"].Value);            
            frm.txtIdcliente.Text = dataListado.CurrentRow.Cells["idcliente"].Value.ToString();
            frm.cbCliente.Text = dataListado.CurrentRow.Cells["cliente"].Value.ToString();

            frm.txtIdTrabajado.Text = dataListado.CurrentRow.Cells["ID_Trabajador"].Value.ToString();
            frm.ShowDialog();
            Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.cbBuscar.Text.Equals("Nombre").ToString(), "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (this.cbBuscar.Text.Equals("Nombre"))
            {
                this.BuscarPorCliente();
            }
            else
            {
                this.BuscarPorNroRecibo();
            }
        }
        private void formato()
        {
            dataListadoDetalle.Columns[5].DefaultCellStyle.Format = "#,#0.00";
            dataListadoDetalle.Columns[6].DefaultCellStyle.Format = "#,#0.00";
            dataListadoDetalle.Columns[7].DefaultCellStyle.Format = "#,#0.00";
            dataListadoDetalle.Columns[8].DefaultCellStyle.Format = "#,#0.00";
            dataListadoDetalle.Columns[9].DefaultCellStyle.Format = "#,#0.00";
         
            /*dataListado.Columns[4].Width = 90;
            dataListado.Columns[6].Width = 70;
            dataListado.Columns[5].Width = 90;
            dataListado.Columns[7].Width = 70;*/

        }
        private void MostrarDetalle()
        {
            
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalleVentaPorIdVenta(this.txtIdventa.Text);
            this.formato();
        }
        private void dataListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtIdventa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Venta"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
            decimal Inimportetotal = 0;
            decimal Inimportecontado = 0;
            decimal Insaldoporpagar = 0;

            foreach (DataGridViewRow row in dataListadoDetalle.Rows)
            {
                Inimportetotal = Inimportetotal + Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                Inimportecontado = Inimportecontado + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                Insaldoporpagar = Insaldoporpagar + Convert.ToDecimal(row.Cells["Por_Cobrar"].Value);
                label1.Text = "Total Cancelado: " + Inimportecontado.ToString("#,#0.00");
                label3.Text = "Importe Total: " + Inimportetotal.ToString("#,#0.00");
                label4.Text = "Total de Deuda: " + Insaldoporpagar.ToString("#,#0.00");
            }
            this.dataListadoDetalle.Columns[0].Visible = false;

            this.dataListadoDetalle.Columns[1].Visible = false;
            this.dataListadoDetalle.Columns[2].Visible = false;
        }

        private void dataListadoDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            /*SqlConnection SqlCon = new SqlConnection();
            SqlCon.ConnectionString = Nconexion.CnReporte();//conexio base de datos
            SqlCon.Open();
            int rpta = 0;
            foreach (DataGridViewRow row in dataListado.Rows)
            {
                try
                {
                    int id = Convert.ToInt32(row.Cells["ID_Venta"].Value);
                string dd = Convert.ToDecimal((row.Cells["Saldo_Por_Cobrar"].Value)).ToString("#,#0.");
                    decimal deuda = Convert.ToDecimal(dd);
                string querystr = "update Cobros set Deuda_Anterior='"+deuda+"',Deuda_Pendiente='"+deuda+"' where Cobros.ID_Venta="+id+ " and Cobros.Deuda_Pendiente<>0";
                SqlCommand SqlCmd2 = new SqlCommand(querystr, SqlCon);
                SqlCmd2.ExecuteNonQuery();
                }
                catch (SqlException sqlexception)
                {
                    MessageBox.Show(sqlexception.Message, "SISTEMA MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                rpta++;
            }
            MessageBox.Show(rpta.ToString());*/
        }
    }
}
