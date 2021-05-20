using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class FrmReporteIngresoEntreFechas : Form
    {
        private string fecha1 = "";
        private string fecha2 = "";
        
        public FrmReporteIngresoEntreFechas()
        {
            InitializeComponent();
        }
        private DataTable reporte(DataTable dt)
        {
            fecha1 = dtFecha1.Value.ToString("dd/MM/yyyy");
            fecha2 = dtFecha2.Value.ToString("dd/MM/yyyy");
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            string consulta = "SELECT i.Id_Ingreso,i.Id_Trabajador,(t.Nombre+' '+t.Apellido_Paterno+' '+t.Apellido_Materno) as Trabjador,i.Id_Conductor,i.Proveedor, (c.nombre+' '+c.apellidop+' '+c.apellidom) as Conductor, (c.placa) as Placa, c.nlicencia,c.Color_Vehiculo,i.Comprobante,i.Nro_Comprobante, i.Fecha_Salida,i.Fecha_Ingreso, i.Destino, i.Descargo,i.Flete_Unitario,i.Flete_Total, i.Flete_Contado,i.Flete_X_Pagar,i.Carguio_Unitario,i.Carguio_Total,i.Carguio_Contado,i.Carguio_X_Pagar, i.Total, i.Estado,di.iddetalle_ingreso ,di.idProducto,di.stock_inicial,di.stock_actual,di.Flete_Unitario as D_Flete_Unitario,di.Flete_Total AS D_Flete_Total,di.Flete_Contado AS D_Flete_Contado,di.Flete_x_Pagar AS D_Flete_x_Pagar,di.Carguio_Unitario AS D_Carguio_Unitario, di.Carguio_Total AS D_Carguio_Total,di.Carguio_Contado AS D_Carguio_Contado,di.Carguio_x_Pagar AS D_Carguio_x_Pagar,di.Total AS D_Total,p.idproducto1,p.idCategoria,p.nombre,P.Unidad_De_Medida,'"+fecha1+ "' as fecha1,'" + fecha2 + "' as fecha2  FROM Ingreso i INNER JOIN conductor c ON i.Id_Conductor = c.idconductor inner join detalle_ingreso di on di.idIngreso = i.Id_Ingreso inner join producto1 p on p.idproducto1 = di.idProducto inner join Trabajador t on t.Id_Trabajador = i.Id_Trabajador where i.Total is not NULL and i.Estado <> 'ANULADO' and i.Fecha_Ingreso >= '" + fecha1+"' and i.Fecha_Ingreso <='"+fecha2+"'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
            da.Fill(dt);
            
            return dt;
        }
        private void FrmReporteIngresoEntreFechas_Load(object sender, EventArgs e)
        {
            fecha1 = dtFecha1.Value.ToString("dd/MM/yyyy");
            fecha2 = dtFecha2.Value.ToString("dd/MM/yyyy");
            
            // TODO: esta línea de código carga datos en la tabla 'DaPrincipal.preporte_mostrar_Trabajador' Puede moverla o quitarla según sea necesario., this.dtFecha2.Value.ToString("dd/MM/yyyy")
            //this.reporte_ingreso_Entre_FechasTableAdapter.Fill(this.DaPrincipal.reporte_ingreso_Entre_Fechas, dtFecha1.Value.ToString("dd/MM/yyyy"), dtFecha2.Value.ToString("dd/MM/yyyy"));
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("Ingresos", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DaPrincipal.preporte_mostrar_Trabajador' Puede moverla o quitarla según sea necesario.this.dtFecha1.Value.ToString("dd/MM/yyyy"), this.dtFecha2.Value.ToString("dd/MM/yyyy")
            // this.reporte_ingreso_Entre_FechasTableAdapter.Fill(this.DaPrincipal.reporte_ingreso_Entre_Fechas, dtFecha1.Value.ToString("dd/MM/yyyy"), dtFecha2.Value.ToString("dd/MM/yyyy"));
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("Ingresos", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
