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
    public partial class FrmCategoria : Form
    {
        //private bool IsNuevo = false;
       
        public FrmCategoria()
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

        }
        //Método Mostrar
        public void Mostrar()
        {
            this.dataListado.DataSource = NCategoria.Mostrar();
            this.AlternarColorFilasDataGridView(dataListado);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            tam();
        }
        private void tam()
        {
            dataListado.Columns["idCategoria"].Width = 200;
            dataListado.Columns["nombre"].Width = 295;
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            //btnAgregar.BackColor = Color.FromArgb(39, 81, 245);poner color a un boton

            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
                            Rpta = NCategoria.Eliminar(Codigo);
                            aux++;
                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                                this.chkEliminar.Checked = false;
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    if (aux==0)
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAgregarCategoria form = new FrmAgregarCategoria();
            form.ShowDialog();
            Mostrar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditarCategoria frm = new FrmEditarCategoria();
            frm.txtCodigo.Text = dataListado.CurrentRow.Cells["idCategoria"].Value.ToString();
            frm.txtNombre.Text = dataListado.CurrentRow.Cells["nombre"].Value.ToString();
            frm.ShowDialog();
            Mostrar();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            //this.btnAgregar.BackgroundImage = Image.FromFile(@"../../../CapaPresentacion/Resources/b2.png");//../ir atras un directorio
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

        private void dataListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteCategorias frm = new FrmReporteCategorias();
            frm.ShowDialog();
        }
    }
}
