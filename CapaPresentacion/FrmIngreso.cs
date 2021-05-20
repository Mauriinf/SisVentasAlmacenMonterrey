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
    public partial class FrmIngreso : Form
    {
        public int IDTrabajador;
        public FrmIngreso()
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
            this.dataListado.Columns[3].Visible = false;
            this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[23].Visible = false;
            this.dataListado.Columns[15].Visible = false;
            this.dataListado.Columns[16].Visible = false;
            this.dataListado.Columns[17].Visible = false;
            this.dataListado.Columns[18].Visible = false;
            this.dataListado.Columns[19].Visible = false;
            this.dataListado.Columns[20].Visible = false;
            this.dataListado.Columns[21].Visible = false;
            this.dataListado.Columns[22].Visible = false;
        }
        //Método Mostrar
        public void Mostrar()
        {
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.AlternarColorFilasDataGridView(dataListado);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            tam();
        }
        //Método Buscarpor fechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NIngreso.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"), this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            this.AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        
        private void BuscarPorNroRecibo()
        {
            this.dataListado.DataSource = NIngreso.BuscarPorNroRecibo(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void tam()
        {
            dataListado.Columns[5].Width = 90;
            dataListado.Columns[7].Width = 70;
            dataListado.Columns[6].Width = 90;
            dataListado.Columns[8].Width = 70;

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
        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (this.txtBuscar.Text == string.Empty)
                this.BuscarFechas();
            else
                this.BuscarPorNroRecibo();
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
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));
                            aux++;
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Anulo Correctamente el ingreso");
                                this.chkEliminar.Checked = false;
                            }                           
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
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

        private void btnEditar_MouseLeave(object sender, EventArgs e)
        {
            this.btnEditar.BackgroundImage = CapaPresentacion.Properties.Resources.b1;
            this.btnEditar.BackgroundImageLayout = ImageLayout.Stretch;
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
            FrmAgregarIngreso form = FrmAgregarIngreso.GetInstancia();
            form.IdTrabajador = this.IDTrabajador;
            form.ShowDialog();
            Mostrar();
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditarIngreso frm = FrmEditarIngreso.GetInstancia();
            frm.txtIdingreso.Text = dataListado.CurrentRow.Cells["Id_Ingreso"].Value.ToString();
            frm.cbTipo_Comprobante.Text = dataListado.CurrentRow.Cells["Comprobante"].Value.ToString();
            frm.txtnrocomprobante.Text = dataListado.CurrentRow.Cells["Nro_Comprobante"].Value.ToString();
            frm.idProveedor = dataListado.CurrentRow.Cells["IdProveedor"].Value.ToString();
            frm.Proveedor = dataListado.CurrentRow.Cells["Proveedor"].Value.ToString();
            frm.cbDestino.Text = dataListado.CurrentRow.Cells["Origen"].Value.ToString();
            frm.cbDescargo.Text = dataListado.CurrentRow.Cells["Destino"].Value.ToString();
            frm.dtFechaSalida.Value= Convert.ToDateTime(dataListado.CurrentRow.Cells["Fecha_Salida"].Value);
            frm.dtFechaIngreso.Value = Convert.ToDateTime(dataListado.CurrentRow.Cells["Fecha_Ingreso"].Value);
            frm.idConductor = dataListado.CurrentRow.Cells["Id_Conductor"].Value.ToString();
            frm.txtIdtrabajador.Text = dataListado.CurrentRow.Cells["Id_Trabajador"].Value.ToString();
            frm.placa = dataListado.CurrentRow.Cells["Placa"].Value.ToString();
            frm.Conductor = dataListado.CurrentRow.Cells["Conductor"].Value.ToString();
            frm.txtTalonario.Text = dataListado.CurrentRow.Cells["Nro_Talonario"].Value.ToString();
            frm.ShowDialog();
            Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarPorNroRecibo();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteIngresoPorId frm =new  FrmReporteIngresoPorId();
            frm.Idingreso = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Id_Ingreso"].Value);
            frm.ShowDialog();
        }
    }
}
