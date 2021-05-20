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
    public partial class FrmVistaEditarConductor_Ingreso : Form
    {
        public FrmVistaEditarConductor_Ingreso()
        {
            InitializeComponent();
        }
        //Método para ocultar columnas
        private void OcultarColumnas()
        {

            this.dataListado.Columns[6].Visible = false;

        }
        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NConductor.Mostrar();
            this.OcultarColumnas();
            AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NConductor.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
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
        private void FrmVistaEditarConductor_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmEditarIngreso form = FrmEditarIngreso.GetInstancia();
            string par1, par2, par3;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["Id"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Placa"].Value);
            par3 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value) + " " + Convert.ToString(this.dataListado.CurrentRow.Cells["ApellidoPaterno"].Value);


            form.setConductor(par1, par2, par3);
            this.Hide();
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
