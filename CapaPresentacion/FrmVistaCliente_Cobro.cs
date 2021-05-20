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
    public partial class FrmVistaCliente_Cobro : Form
    {
        public FrmVistaCliente_Cobro()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }
        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NCobros.MostrarCliente_Cobro_Nombre2();
            this.OcultarColumnas();
            AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCobros.MostrarCliente_Cobro_Nombre(this.txtBuscar.Text);
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

            
        }
        private void FrmVistaCliente_Cobro_Load(object sender, EventArgs e)
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
            FrmAgregarCobro form = FrmAgregarCobro.GetInstancia();
            string par1, par2, par3, par4, par5, par6, par7, par8;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Venta"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            par4 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre"].Value);
            par3 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Recibo"].Value);
            par5 = Convert.ToString(this.dataListado.CurrentRow.Cells["Importe_Total"].Value);
            par6 = Convert.ToString(this.dataListado.CurrentRow.Cells["Total_Contado"].Value);
            par7 = Convert.ToString(this.dataListado.CurrentRow.Cells["Saldo_Por_Cobrar"].Value);
            par8 = Convert.ToString(this.dataListado.CurrentRow.Cells["Deuda_Anterior"].Value);
            form.setCliente_ventas(par1, par2, par3, par4, par5, par6, par7, par8);

            this.Hide();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dataListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.Enter))
            {
                FrmAgregarCobro form = FrmAgregarCobro.GetInstancia();
                string par1, par2, par3, par4, par5, par6, par7, par8;
                e.SuppressKeyPress = true;//suprime el enter para q no seleccione el de abajajo al hacer enter
                par1 = Convert.ToString(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["ID_Venta"].Value);
                par2 = Convert.ToString(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["idcliente"].Value);
                par4 = Convert.ToString(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["Nombre"].Value);
                par3 = Convert.ToString(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["Nro_Recibo"].Value);
                par5 = Convert.ToString(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["Importe_Total"].Value);
                par6 = Convert.ToString(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["Total_Contado"].Value);
                par7 = Convert.ToString(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["Saldo_Por_Cobrar"].Value);
                par8 = Convert.ToString(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["Deuda_Anterior"].Value);

                form.setCliente_ventas(par1, par2, par3, par4, par5, par6, par7, par8);

                this.Hide();

            }
        }
    }
}
