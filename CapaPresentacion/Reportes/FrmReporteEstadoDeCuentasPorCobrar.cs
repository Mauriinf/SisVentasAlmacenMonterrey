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
using System.Data;
using Microsoft.Reporting.WinForms;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class FrmReporteEstadoDeCuentasPorCobrar : Form
    {
        private string fecha1 = "";
        
        public FrmReporteEstadoDeCuentasPorCobrar()
        {
            InitializeComponent();
        }
        private void actualizarVistas()
        {
            fecha1 = dtFecha1.Value.ToString("dd/MM/yyyy");
           // fecha2 = dtFecha2.Value.ToString("dd/MM/yyyy");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.ConnectionString = Nconexion.CnReporte();//conexio base de datos
            SqlCon.Open();
            string vista;
            try
            {
                
                vista = "alter view VistaClientesCobrosReporteEstadoCuentasPorCobrar as SELECT c.idcliente, c.nombre + ' ' + c.apellidop + ' ' + c.apellidom AS Nombre, SUM(cb.Pago) AS Cobro, SUM(cb.Rebaja) AS RebajaCobro FROM dbo.Venta AS v INNER JOIN dbo.clientes AS c ON v.ID_Cliente = c.idcliente INNER JOIN dbo.Cobros AS cb ON cb.ID_Venta = v.ID_Venta WHERE(cb.Fecha <= '" + fecha1 + "') GROUP BY c.idcliente, c.nombre, c.apellidop, c.apellidom";
                SqlCommand SqlCmd2 = new SqlCommand(vista, SqlCon);
                SqlCmd2.ExecuteNonQuery();
                vista = "alter view VistaClientesVentasReporteEstadoCuentasPorCobrar as SELECT c.idcliente, c.nombre + ' ' + c.apellidop + ' ' + c.apellidom AS Nombre, SUM(dv.Importe_Total) AS Importe_Total, SUM(dv.Al_Contado) AS Al_Contado, SUM(dv.RebajaInicial) AS RebajaInicial FROM dbo.Detalle_Venta AS dv INNER JOIN dbo.Venta AS v ON dv.ID_Venta = v.ID_Venta INNER JOIN dbo.clientes AS c ON v.ID_Cliente = c.idcliente WHERE(v.Fecha <=  '" + fecha1 + "') GROUP BY c.idcliente, c.nombre, c.apellidop, c.apellidom";
                SqlCommand SqlCmd3 = new SqlCommand(vista, SqlCon);
                SqlCmd3.ExecuteNonQuery();
                SqlCon.Close();
                // MessageBox.Show("correcto", "SISTEMA MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "SISTEMA MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private DataTable reporte(DataTable dt)
        {
            fecha1 = dtFecha1.Value.ToString("dd/MM/yyyy");           
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            string consulta = "select v1.idcliente,v1.Nombre,v1.Importe_Total,v1.Al_Contado,v2.Cobro,(v1.RebajaInicial+v2.RebajaCobro) as RebajaTotal,(v1.Al_Contado+v1.RebajaInicial+v2.RebajaCobro+v2.Cobro) as TotalCobros, (v1.Importe_Total-(v1.Al_Contado+v1.RebajaInicial+v2.RebajaCobro+v2.Cobro))AS DeudaPendiente,'" + fecha1 + "' as Fecha from VistaClientesVentasReporteEstadoCuentasPorCobrar v1 inner join VistaClientesCobrosReporteEstadoCuentasPorCobrar v2 on v1.idcliente = v2.idcliente where v1.Al_Contado!=v1.Importe_Total ";
            // cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
            da.Fill(dt);
            // cn.Close();
            return dt;
        }
        private void FrmReporteEstadoDeCuentasPorCobrar_Load(object sender, EventArgs e)
        {
            actualizarVistas();
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("InformeEstadoCuentasPorCobrar", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizarVistas();
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("InformeEstadoCuentasPorCobrar", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
