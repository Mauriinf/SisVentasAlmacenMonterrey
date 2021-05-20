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
    public partial class FrmBuscarDeudasVentasClientes : Form
    {
        string estado = "";
        string comprobante = "";
        public FrmBuscarDeudasVentasClientes()
        {
            InitializeComponent();
            this.idCliente.Visible = false;
            this.txtIdventa.Visible = false;
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NVenta.BuscarDeudasVentaCliente(this.idCliente.Text, this.estado);

            AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        
        private void BuscarDetalleVentaNroRecibo()
        {
            this.dataListado.DataSource = NVenta.BuscarDeudasVentaClientePorNroRecibo(this.NroRecibo.Text, this.comprobante);

            AlternarColorFilasDataGridView(dataListado);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void AlternarColorFilasDataGridView(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.White;//color intercalado
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 213, 159);//color intercalado
            this.dataListadoDetalle.GridColor = Color.FromArgb(232, 4, 10);
            this.dataListado.GridColor = Color.FromArgb(232, 4, 10);//cambiar color de lineas
                                                                    //  this.dataListado.BorderStyle = BorderStyle.FixedSingle;
                                                                    //  this.dataListado.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(125, 190, 255);
                                                                    //  this.dataListado.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(125, 190, 255);
                                                                    // this.dataListado.Font = new Font("Tahoma", 9, FontStyle.Bold);
                                                                    // dgv.Rows[1].Cells[1].Style.BackColor = Color.Red;
                                                                    //dataListado.CurrentRow.Cells[e.RowIndex].Style.BackColor = Color.Red;
            dataListado.Columns[0].Visible = false;
            dataListado.Columns[1].Visible = false;
            dataListado.Columns[2].Visible = false;
            dataListado.Columns[7].DefaultCellStyle.Format = "#,#0.00";
            dataListado.Columns[8].DefaultCellStyle.Format = "#,#0.00";
            dataListado.Columns[9].DefaultCellStyle.Format = "#,#0.00";
            dataListadoDetalle.Columns[0].Visible = false;
            dataListadoDetalle.Columns[1].Visible = false;
            //dataListadoDetalle.Columns[4].Visible = false;
            dataListadoDetalle.Columns[2].Visible = false;
            //dataListado.Columns[1].Width = 120;
            //dataListado.Columns[2].Width = 140;
            //dataListado.Columns[3].Width = 110;
        }
        private void FrmBuscarDeudasVentasClientes_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            AutoCompletado c = new AutoCompletado();
            c.llenarcomboBoxCliente(cbCliente);
            string sId = cbCliente.SelectedValue.ToString();
            idCliente.Text = sId;
            MostrarDetalle();
        }
        private void formato()
        {
           dataListadoDetalle.Columns[5].DefaultCellStyle.Format = "#,#0.00";
           dataListadoDetalle.Columns[6].DefaultCellStyle.Format = "#,#0.00";
           dataListadoDetalle.Columns[7].DefaultCellStyle.Format = "#,#0.00";
            dataListadoDetalle.Columns[8].DefaultCellStyle.Format = "#,#0.00";
            dataListadoDetalle.Columns[9].DefaultCellStyle.Format = "#,#0.00";

            

        }
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalleVentaPorIdVenta(this.txtIdventa.Text);
            this.formato();
        }
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
        }

        private void NroRecibo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbTipo_Comprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataListadoDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

            }
            label2.Text = "Total de Deuda: " + Insaldoporpagar.ToString("#,#0.00");
            label3.Text = "Importe Total: " + Inimportetotal.ToString("#,#0.00");
            label4.Text = "Total Cancelado: " + Inimportecontado.ToString("#,#0.00");
        }

        private void btnBuscarProducto_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Todos")
            {
                this.estado = "";
            }
            else
            {
                this.estado = comboBox1.Text;
            }
            this.BuscarNombre();

            decimal Inimportetotal = 0;
            decimal Inimportecontado = 0;
            decimal Insaldoporpagar = 0;

            foreach (DataGridViewRow row in dataListado.Rows)
            {
                Inimportetotal = Inimportetotal + Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                Inimportecontado = Inimportecontado + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                Insaldoporpagar = Insaldoporpagar + Convert.ToDecimal(row.Cells["Por_Cobrar"].Value);

            }
            total.Text = "Total de Deuda: " + Insaldoporpagar.ToString("#,#0.00");
            Importetotal.Text = "Importe Total: " + Inimportetotal.ToString("#,#0.00");
            TotalContado.Text = "Total Cancelado: " + Inimportecontado.ToString("#,#0.00");
        }

        private void NroRecibo_TextChanged_1(object sender, EventArgs e)
        {
            if (cbTipo_Comprobante.Text == "TODOS")
            {
                this.comprobante = "";
            }
            else
            {
                this.comprobante = cbTipo_Comprobante.Text;
            }
            this.BuscarDetalleVentaNroRecibo();
            decimal Inimportetotal = 0;
            decimal Inimportecontado = 0;
            decimal Insaldoporpagar = 0;

            foreach (DataGridViewRow row in dataListado.Rows)
            {
                Inimportetotal = Inimportetotal + Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                Inimportecontado = Inimportecontado + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                Insaldoporpagar = Insaldoporpagar + Convert.ToDecimal(row.Cells["Por_Cobrar"].Value);

            }
            total.Text = "Total de Deuda: " + Insaldoporpagar.ToString("#,#0.00");
            Importetotal.Text = "Importe Total: " + Inimportetotal.ToString("#,#0.00");
            TotalContado.Text = "Total Cancelado: " + Inimportecontado.ToString("#,#0.00");
        }

        private void cbTipo_Comprobante_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbTipo_Comprobante.Text == "TODOS")
            {
                this.comprobante = "";
            }
            else
            {
                this.comprobante = cbTipo_Comprobante.Text;
            }
            this.BuscarDetalleVentaNroRecibo();
            decimal Inimportetotal = 0;
            decimal Inimportecontado = 0;
            decimal Insaldoporpagar = 0;

            foreach (DataGridViewRow row in dataListado.Rows)
            {
                Inimportetotal = Inimportetotal + Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                Inimportecontado = Inimportecontado + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                Insaldoporpagar = Insaldoporpagar + Convert.ToDecimal(row.Cells["Por_Cobrar"].Value);

            }
            total.Text = "Total de Deuda: " + Insaldoporpagar.ToString("#,#0.00");
            Importetotal.Text = "Importe Total: " + Inimportetotal.ToString("#,#0.00");
            TotalContado.Text = "Total Cancelado: " + Inimportecontado.ToString("#,#0.00");
        }

        private void cbCliente_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string sId = cbCliente.SelectedValue.ToString();
            idCliente.Text = sId;
        }
      
        
private void dataListado_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

            this.txtIdventa.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Venta"].Value);
            this.lblcliente.Text = "Cliente: "+Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            this.lbltalonario.Text = "Nro Talonario: "+Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Talonario"].Value);
            this.lblrecibo.Text = "Nro Recibo: " + Convert.ToString(this.dataListado.CurrentRow.Cells["Nro_Recibo"].Value);
            this.MostrarDetalle();
            AlternarColorFilasDataGridView(dataListadoDetalle);
            this.tabControl1.SelectedIndex = 1;
            decimal Inimportetotal = 0;
            decimal Inimportecontado = 0;
            decimal Insaldoporpagar = 0;

            foreach (DataGridViewRow row in dataListadoDetalle.Rows)
            {
                Inimportetotal = Inimportetotal + Convert.ToDecimal(row.Cells["Importe_Total"].Value);
                Inimportecontado = Inimportecontado + Convert.ToDecimal(row.Cells["Total_Contado"].Value);
                Insaldoporpagar = Insaldoporpagar + Convert.ToDecimal(row.Cells["Por_Cobrar"].Value);
                label2.Text = "Total Cancelado: " + Inimportecontado.ToString("#,#0.00"); 
            label3.Text = "Importe Total: " + Inimportetotal.ToString("#,#0.00");
            label4.Text = "Total de Deuda: " + Insaldoporpagar.ToString("#,#0.00");
            }
            
    }
    
        
    }
}
