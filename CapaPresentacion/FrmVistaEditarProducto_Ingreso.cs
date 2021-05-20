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
    public partial class FrmVistaEditarProducto_Ingreso : Form
    {
        public FrmVistaEditarProducto_Ingreso()
        {
            InitializeComponent();
        }
        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NProducto.Mostrar();

            AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NProducto.BuscarNombre(this.txtBuscar.Text);

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
        private void FrmVistaEditarProducto_Ingreso_Load(object sender, EventArgs e)
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
            FrmEditarDetalleIngreso form = FrmEditarDetalleIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Producto"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Producto"].Value);

            form.setProducto(par1, par2);
            Mostrar();
            this.Hide();
        }
    }
}
