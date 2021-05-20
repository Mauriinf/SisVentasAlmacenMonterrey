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
    public partial class pru : Form
    {
        public pru()
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
            this.dataListado.DataSource = NClientes.Mostrar();
            this.AlternarColorFilasDataGridView(dataListado);
            
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            tam();
        }
        private void tam()
        {
            dataListado.Columns["idcliente"].Width = 80;
            dataListado.Columns["Nombre"].Width = 120;
            dataListado.Columns["ApellidoPaterno"].Width = 120;
            dataListado.Columns["ApellidoMaterno"].Width = 120;
            dataListado.Columns["Ci"].Width = 105;
            dataListado.Columns["Sexo"].Width = 70;
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NClientes.BuscarNombre(this.txtBuscar.Text);
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
        private void pru_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
        }

        private void btnAgregar_MouseHover(object sender, EventArgs e)
        {
            this.btnAgregar.BackgroundImage = Image.FromFile(@"../../../CapaPresentacion/Resources/btonnaranja3.png");//../ir atras un directorio
            this.btnAgregar.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {

            this.btnAgregar.BackgroundImage = Image.FromFile(@"../../../CapaPresentacion/Resources/BotonNaranja2.png");//../ir atras un directorio
            this.btnAgregar.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
