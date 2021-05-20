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
    public partial class FrmVistaProducto_Venta : Form
    {
        public FrmVistaProducto_Venta()
        {
            InitializeComponent();
        }
       
      
        //Método BuscarNombre
        private void MostrarProducto_salida_Nombre()
        {
            this.dataListado.DataSource = NVenta.MostrarProducto_Venta_Nombre(this.txtBuscar.Text);
           
            AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarProducto_salida_Codigo()
        {
            this.dataListado.DataSource = NVenta.MostrarrProducto_Venta_Codigo(this.txtBuscar.Text);
          
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
            dataListado.Columns[ 0].Visible=false;
            dataListado.Columns[1].Width = 120;
            dataListado.Columns[2].Width = 140;
            dataListado.Columns[3].Width = 110;
        }
        private void FrmVistaProducto_Venta_Load(object sender, EventArgs e)
        {
            this.dataListado.DataSource = NVenta.MostrarProducto_Venta_Nombre(this.txtBuscar.Text);
          
            AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Codigo"))
            {
                this.MostrarProducto_salida_Codigo();
            }
            else 
            {
                this.MostrarProducto_salida_Nombre();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmAgregarVenta form = FrmAgregarVenta.GetInstancia();
            string par1, par2;
            int par3;
           par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["ID"].Value);
            par3 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["stock_actual"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setProducto(par1,par2, par3);
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Codigo"))
            {
                this.MostrarProducto_salida_Codigo();
            }
            else
            {
                this.MostrarProducto_salida_Nombre();
            }
        }

        private void dataListado_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }

        private void dataListado_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.Enter))
            {
                FrmAgregarVenta form = FrmAgregarVenta.GetInstancia();
                string par1, par2;
                int par3;
                //dataListado.Rows[dataListado.CurrentRow.Index - 1].Cells["ID"].Selected = true;
                
                    e.SuppressKeyPress = true;//suprime el enter para q no seleccione el de abajajo al hacer enter                  
                par1 = Convert.ToString(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["ID"].Value);
                par3 = Convert.ToInt32(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["stock_actual"].Value);
                par2 = Convert.ToString(this.dataListado.Rows[dataListado.CurrentRow.Index].Cells["nombre"].Value);
                //MessageBox.Show((dataListado.CurrentRow.Index).ToString());                
                form.setProducto(par1, par2, par3);
                this.dataListado.CurrentRow.Selected = true;
                this.Hide();
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
