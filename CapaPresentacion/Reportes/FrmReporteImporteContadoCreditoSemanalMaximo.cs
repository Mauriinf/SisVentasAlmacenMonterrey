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
    public partial class FrmReporteImporteContadoCreditoSemanalMaximo : Form
    {
        private string fecha1 = "";
        private string fecha2 = "";
        public FrmReporteImporteContadoCreditoSemanalMaximo()
        {
            InitializeComponent();
        }
        private DataTable reporte(DataTable dt)
        {
            fecha1 = dtFecha1.Value.ToString("dd/MM/yyyy");
            fecha2 = dtFecha2.Value.ToString("dd/MM/yyyy");
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            string consulta = "SELECT        V.Fecha,p.idCategoria, SUM(dv.Cantidad) AS Cantidad, AVG(dv.Precio) AS Precio_Unitario, SUM(dv.Importe_Total) AS Importe_Total, SUM(dv.Al_Contado) AS al_Contado, SUM(dv.Importe_Total) - SUM(dv.Al_Contado) AS credito,'" + fecha1 + "' as Fecha1, '" + fecha2 + "' as Fecha2 FROM dbo.producto1 AS p INNER JOIN dbo.detalle_ingreso AS di ON di.idProducto = p.idproducto1 INNER JOIN dbo.Detalle_Venta AS dv ON dv.ID_Detalle_Ingreso = di.iddetalle_ingreso INNER JOIN dbo.Ingreso AS i ON i.Id_Ingreso = di.idIngreso INNER JOIN dbo.Venta AS v ON dv.ID_Venta = v.ID_Venta WHERE(di.Flete_Total IS NOT NULL) AND(i.Estado <> 'ANULADO') AND(v.Fecha >= '" + fecha1 + "') AND(v.Fecha <= '" + fecha2 + "') and p.idCategoria = 1 GROUP BY v.Fecha,p.idCategoria Order by v.Fecha";
            // cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
            da.Fill(dt);
            // cn.Close();
            return dt;
        }
        private void FrmReporteImporteContadoCreditoSemanalMaximo_Load(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("ReporteSemanalImportesCreditoContadoMaximo", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("ReporteSemanalImportesCreditoContadoMaximo", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
