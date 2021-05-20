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
    public partial class FrmReporteDetalleGeneralVentasEntreFechas : Form
    {
        private string fecha1 = "";
        private string fecha2 = "";
        public FrmReporteDetalleGeneralVentasEntreFechas()
        {
            InitializeComponent();
        }
        private DataTable reporte(DataTable dt)
        {
            fecha1 = dtFecha1.Value.ToString("dd/MM/yyyy");
            fecha2 = dtFecha2.Value.ToString("dd/MM/yyyy");
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            string consulta = "select v.Fecha,v.Tipo_Comprobante,v.Nro_Talonario,v.Nro_Recibo,(c.nombre+' '+c.apellidop+' '+c.apellidom) as Nombre,SUM(dv.Importe_Total) as Importe_Total,SUM(dv.Al_Contado) as Al_Contado,(SUM(dv.Importe_Total)-SUM(dv.Al_Contado)) as VentaCredito,'" + fecha1 + "' as fech1,'" + fecha2 + "' as fech2  from Detalle_Venta dv inner join Venta v on dv.ID_Venta = v.ID_Venta inner join clientes c on v.ID_Cliente = c.idcliente where v.Fecha >= '" + fecha1 + "' and v.Fecha <= '" + fecha2 + "' group by v.Fecha,v.Tipo_Comprobante,v.Nro_Talonario,v.Nro_Recibo,c.nombre,c.apellidop,c.apellidom";
            // cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
            da.Fill(dt);
            // cn.Close();
            return dt;
        }
        private void FrmReporteDetalleGeneralVentasEntreFechas_Load(object sender, EventArgs e)
        {

            
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("DetalleGeneralVentaEntreFechas", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("DetalleGeneralVentaEntreFechas", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
