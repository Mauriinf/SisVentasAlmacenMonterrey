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
    public partial class FrmVistaEditarCliente_Venta : Form
    {
        public FrmVistaEditarCliente_Venta()
        {
            InitializeComponent();
        }
        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NClientes.Mostrar();

            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

            AlternarColorFilasDataGridView(dataListado);

        }
        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NClientes.BuscarNombre(this.txtBuscar.Text);


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
            dataListado.Columns[0].Visible = false;
            dataListado.Columns[1].Width = 95;
            dataListado.Columns[3].Width = 90;
            dataListado.Columns[2].Width = 90;
            dataListado.Columns[4].Width = 80;
            dataListado.Columns[5].Width = 40;
        }
        private void FrmVistaEditarCliente_Venta_Load(object sender, EventArgs e)
        {
            Mostrar();
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
            FrmEditarVenta form = FrmEditarVenta.GetInstancia();
            string par1, par2,par3,par4;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            par3 = Convert.ToString(this.dataListado.CurrentRow.Cells["ApellidoPaterno"].Value);
            par4 = Convert.ToString(this.dataListado.CurrentRow.Cells["ApellidoMaterno"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);

            form.setCliente(par1, par2,par3,par4);
            this.Hide();
        }
    }
}
