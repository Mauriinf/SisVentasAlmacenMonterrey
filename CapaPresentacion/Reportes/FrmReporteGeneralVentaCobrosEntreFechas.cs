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
    public partial class FrmReporteGeneralVentaCobrosEntreFechas : Form
    {
        private string fecha1 = "";
        private string fecha2 = "";
        public FrmReporteGeneralVentaCobrosEntreFechas()
        {
            InitializeComponent();
        }
        private void actualizarVistas()
        {
            fecha1 = dtFecha1.Value.ToString("dd/MM/yyyy");
            fecha2 = dtFecha2.Value.ToString("dd/MM/yyyy");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.ConnectionString = Nconexion.CnReporte();//conexio base de datos
            SqlCon.Open();
            string vista = "alter view VistaCobros as SELECT p.idproducto1, SUM(c.Pago) AS Pago FROM dbo.producto1 AS p INNER JOIN dbo.detalle_ingreso AS di ON di.idProducto = p.idproducto1 INNER JOIN dbo.Detalle_Venta AS dv ON dv.ID_Detalle_Ingreso = di.iddetalle_ingreso INNER JOIN dbo.Ingreso AS i ON i.Id_Ingreso = di.idIngreso INNER JOIN dbo.Venta AS v ON dv.ID_Venta = v.ID_Venta INNER JOIN dbo.Cobros AS c ON c.ID_Venta = v.ID_Venta WHERE(i.Estado <> 'ANULADO' and v.Fecha>='" + fecha1 + "' and v.Fecha<='" + fecha2 + "' and c.Fecha>='" + fecha1 + "' and c.Fecha<='" + fecha2 + "') GROUP BY p.idproducto1";
            SqlCommand SqlCmd = new SqlCommand(vista, SqlCon);
            try
            {
                SqlCmd.ExecuteNonQuery();
                vista = "alter view VistaProducto as SELECT p.idproducto1, p.nombre, p.Unidad_De_Medida FROM dbo.producto1 AS p INNER JOIN dbo.detalle_ingreso AS di ON di.idProducto = p.idproducto1 INNER JOIN dbo.Detalle_Venta AS dv ON di.iddetalle_ingreso = dv.ID_Detalle_Ingreso INNER JOIN dbo.Ingreso AS i ON i.Id_Ingreso = di.idIngreso inner join Venta v on v.ID_Venta=dv.ID_Venta INNER JOIN dbo.Cobros AS c ON c.ID_Venta = v.ID_Venta WHERE(i.Estado <> 'ANULADO' and v.Fecha>='" + fecha1 + "' and v.Fecha<='" + fecha2 + "' and c.Fecha>='" + fecha1 + "' and c.Fecha<='" + fecha2 + "') GROUP BY p.idproducto1, p.nombre, p.Unidad_De_Medida";
                SqlCommand SqlCmd2 = new SqlCommand(vista, SqlCon);
                SqlCmd2.ExecuteNonQuery();
                vista = "alter view VistaTotalesProducto as SELECT p.idproducto1, SUM(dv.Cantidad) AS Cantidad ,AVG(dv.Precio) AS Precio_Unitario, SUM(dv.Importe_Total) AS Importe_Total,SUM(dv.Al_Contado) AS al_Contado, SUM(dv.Total_Contado) AS total_Contado, (SUM(dv.Importe_Total)- SUM(dv.Al_Contado)) AS credito FROM dbo.producto1 AS p INNER JOIN dbo.detalle_ingreso AS di ON di.idProducto = p.idproducto1 INNER JOIN dbo.Detalle_Venta AS dv ON dv.ID_Detalle_Ingreso = di.iddetalle_ingreso INNER JOIN dbo.Ingreso AS i ON i.Id_Ingreso = di.idIngreso INNER JOIN dbo.Venta AS v ON dv.ID_Venta = v.ID_Venta WHERE(i.Estado <> 'ANULADO' and v.Fecha>='" + fecha1 + "' and v.Fecha<='" + fecha2 + "') GROUP BY p.idproducto1";
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
            fecha2 = dtFecha2.Value.ToString("dd/MM/yyyy");
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            string consulta = "select  p.idproducto1,p.nombre,p.Unidad_De_Medida,vtp.Cantidad,vtp.Precio_Unitario,vtp.Importe_Total,vtp.al_Contado,vtp.total_Contado,vtp.credito,vc.Pago as cobro,'" + fecha1 + "' as fecha1,'" + fecha2 + "' as fecha2 from VistaProducto p inner join VistaTotalesProducto vtp on p.idproducto1 = vtp.idproducto1 inner join VistaCobros vc on vc.idproducto1 = vtp.idproducto1  ";
            // cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
            da.Fill(dt);
            // cn.Close();
            return dt;
        }
        private void FrmReporteGeneralVentaCobrosEntreFechas_Load(object sender, EventArgs e)
        {
            actualizarVistas();
            DataTable dtt = new DataTable();
             dtt = reporte(dtt);
             this.reportViewer1.LocalReport.DataSources.Clear();
             ReportDataSource rpts = new ReportDataSource("InformeGeneralVentasyCobrosPorProducto", dtt);
             this.reportViewer1.LocalReport.DataSources.Add(rpts);
             this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            actualizarVistas();
           // this.reporte_ingreso_General_Entre_FechasTableAdapter.Fill(this.DaPrincipal.reporte_ingreso_General_Entre_Fechas, dtFecha1.Value.ToString("dd/MM/yyyy"), dtFecha2.Value.ToString("dd/MM/yyyy"));
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("InformeGeneralVentasyCobrosPorProducto", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
