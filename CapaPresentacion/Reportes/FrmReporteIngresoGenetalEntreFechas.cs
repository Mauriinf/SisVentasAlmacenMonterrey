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
    public partial class FrmReporteIngresoGenetalEntreFechas : Form
    {
        private string fecha1 = "";
        private string fecha2 = "";
        public FrmReporteIngresoGenetalEntreFechas()
        {
            InitializeComponent();
        }
        private DataTable reporte(DataTable dt)
        {
            fecha1 = dtFecha1.Value.ToString("dd/MM/yyyy");
            fecha2 = dtFecha2.Value.ToString("dd/MM/yyyy");
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            string consulta = "SELECT p.idproducto1,p.nombre,P.Unidad_De_Medida,sum(di.stock_inicial) as stock_inicial,avg(di.Flete_Unitario) as D_Flete_Unitario,sum(di.Flete_Total) AS D_Flete_Total,sum(di.Flete_Contado) AS D_Flete_Contado,sum(di.Flete_x_Pagar) AS D_Flete_x_Pagar,sum(di.Carguio_Unitario) AS D_Carguio_Unitario, sum(di.Carguio_Total) AS D_Carguio_Total, sum(di.Carguio_Contado)AS D_Carguio_Contado, sum(di.Carguio_x_Pagar) AS D_Carguio_x_Pagar, sum(di.Total) AS D_Total,'" + fecha1 + "' as Fecha1,'" + fecha2 + "' as Fecha2  FROM   Ingreso i INNER JOIN detalle_ingreso di on di.idIngreso=i.Id_Ingreso inner join producto1 p on p.idproducto1 = di.idProducto where i.Total is not NULL and i.Estado <> 'ANULADO' and i.Fecha_Ingreso >= '" + fecha1 + "' and i.Fecha_Ingreso<='" + fecha2 + "' group by  p.idproducto1,p.nombre,P.Unidad_De_Medida";
            SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
            da.Fill(dt);

            return dt;
        }
        private void FrmReporteIngresoGenetalEntreFechas_Load(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("Ingresos", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  this.reporte_ingreso_General_Entre_FechasTableAdapter.Fill(this.DaPrincipal.reporte_ingreso_General_Entre_Fechas, dtFecha1.Value.ToString("dd/MM/yyyy"), dtFecha2.Value.ToString("dd/MM/yyyy"));
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("Ingresos", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
