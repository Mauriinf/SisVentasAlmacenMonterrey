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
    public partial class FrmTrabajador : Form
    {
        public FrmTrabajador()
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

        }
        //Método Mostrar
        public void Mostrar()
        {
            this.dataListado.DataSource = NTrabajador.Mostrar();
            this.AlternarColorFilasDataGridView(dataListado);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            tam();
        }
        private void tam()
        {
            dataListado.Columns["Id_Trabajador"].Width = 30;
            dataListado.Columns["Nombre"].Width = 120;
            dataListado.Columns["Apellido_Paterno"].Width = 120;
            dataListado.Columns["Apellido_Materno"].Width = 120;            
            dataListado.Columns["Sexo"].Width = 42;
            dataListado.Columns["Fecha_Nacimiento"].Width = 80;
            dataListado.Columns["Nro_Documento"].Width = 80;
            dataListado.Columns["Direccion"].Width = 80;
            dataListado.Columns["Telefono"].Width = 80;
            dataListado.Columns["Email"].Width = 50;
            dataListado.Columns["Tipo_Trabajador"].Width = 70;
            dataListado.Columns["Usuario"].Width = 70;
            dataListado.Columns["Estado"].Width = 70;
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NTrabajador.BuscarNombre(this.txtBuscar.Text);
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
        private void FrmTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
            //dataListado.Rows[e.RowIndex].Cells[e.RowIndex].Style.BackColor = Color.Red;
            //dataListado.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema MONTERREY", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Id;
                    string Rpta = "";
                    int aux = 0;
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Id = Convert.ToString(row.Cells[1].Value);
                            Rpta = NTrabajador.Eliminar(Convert.ToInt32(Id));//cambiar
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

        private void btnImprimir_MouseHover(object sender, EventArgs e)
        {
            this.btnImprimir.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnImprimir.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnEliminar_MouseHover(object sender, EventArgs e)
        {
            this.btnEliminar.BackgroundImage = CapaPresentacion.Properties.Resources.b2;
            this.btnEliminar.BackgroundImageLayout = ImageLayout.Stretch;
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
            FrmAgregarTrabajador form = new FrmAgregarTrabajador();
            form.ShowDialog();
            Mostrar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditarTrabajador frm = new FrmEditarTrabajador();
            frm.txtId.Text = dataListado.CurrentRow.Cells["Id_Trabajador"].Value.ToString();
            frm.txtNombre.Text = dataListado.CurrentRow.Cells["Nombre"].Value.ToString();
            frm.txtPaterno.Text = dataListado.CurrentRow.Cells["Apellido_Paterno"].Value.ToString();
            frm.txtMaterno.Text = dataListado.CurrentRow.Cells["Apellido_Materno"].Value.ToString();
            
            frm.cbSexo.Text = dataListado.CurrentRow.Cells["Sexo"].Value.ToString();
            frm.dtFechaNac.Text = dataListado.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString();
            frm.txtCi.Text = dataListado.CurrentRow.Cells["Nro_Documento"].Value.ToString();
            frm.txtDireccion.Text = dataListado.CurrentRow.Cells["Direccion"].Value.ToString();
            frm.txtTelefono.Text = dataListado.CurrentRow.Cells["Telefono"].Value.ToString();
            frm.txtEmail.Text = dataListado.CurrentRow.Cells["Email"].Value.ToString();
            frm.cbTipousuario.Text = dataListado.CurrentRow.Cells["Tipo_Trabajador"].Value.ToString();
            frm.txtUsuario.Text = dataListado.CurrentRow.Cells["Usuario"].Value.ToString();
            frm.cbEstado.Text = dataListado.CurrentRow.Cells["Estado"].Value.ToString();
            frm.ShowDialog();
            Mostrar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteTrabajadores frm = new FrmReporteTrabajadores();
            frm.ShowDialog();
        }
    }
}
