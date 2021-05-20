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
    public partial class FrmReporteCantidadVentasProductoSemanalMonterrey : Form
    {
        private string fecha1 = "";
        private string fecha2 = "";
        public FrmReporteCantidadVentasProductoSemanalMonterrey()
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

            try
            {
                string vista = "Alter view VistaCnatidadesProductosMonterrey as SELECT        v.Fecha, v.Nro_Recibo,p.idCategoria, p.idproducto1, p.nombre, dt.Cantidad, dt.Precio, dt.Importe_Total FROM dbo.Venta AS v INNER JOIN   dbo.Detalle_Venta AS dt ON dt.ID_Venta = v.ID_Venta INNER JOIN dbo.detalle_ingreso AS di ON di.iddetalle_ingreso = dt.ID_Detalle_Ingreso INNER JOIN dbo.producto1 AS p ON p.idproducto1 = di.idProducto WHERE di.Flete_Total is null and (v.Fecha >= '" + fecha1 + "') AND(v.Fecha <= '" + fecha2 + "')";
                SqlCommand SqlCmd = new SqlCommand(vista, SqlCon);
                SqlCmd.ExecuteNonQuery();
                vista = "Alter view VistaTotalesProductosMonterrey as SELECT        p.idproducto1, p.nombre, SUM(dt.Cantidad) AS TotalCantidad, SUM(dt.Importe_Total) AS TotalImporte,(sum(dt.Total_Contado)+sum(dt.Rebaja)) as TotalContado, sum(dt.Saldo_Por_Cobrar) as PorCobrar FROM   dbo.Venta AS v INNER JOIN   dbo.Detalle_Venta AS dt ON dt.ID_Venta = v.ID_Venta INNER JOIN dbo.detalle_ingreso AS di ON di.iddetalle_ingreso = dt.ID_Detalle_Ingreso INNER JOIN dbo.producto1 AS p ON p.idproducto1 = di.idProducto WHERE di.Flete_Total is null and (v.Fecha >= '" + fecha1 + "') AND(v.Fecha <= '" + fecha2 + "') GROUP BY p.idproducto1, p.nombre";
                SqlCommand SqlCmd2 = new SqlCommand(vista, SqlCon);
                SqlCmd2.ExecuteNonQuery();
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
            string consulta = "SELECT        cp.Fecha, cp.Nro_Recibo,cp.idCategoria, cp.idproducto1, cp.nombre, cp.Cantidad, cp.Precio, cp.Importe_Total,tp.TotalCantidad,tp.TotalImporte,tp.TotalContado,tp.PorCobrar,'" + fecha1 + "' as Fecha1, '" + fecha2 + "' as Fecha2 FROM            dbo.VistaCnatidadesProductosMonterrey AS cp INNER JOIN  dbo.VistaTotalesProductosMonterrey AS tp ON tp.idproducto1=cp.idproducto1 order by cp.Fecha";
            // cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
            da.Fill(dt);
            // cn.Close();
            return dt;
        }
        private void FrmReporteCantidadVentasProductoSemanalMonterrey_Load(object sender, EventArgs e)
        {

            actualizarVistas();
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("ReporteSemanalTotalProductoMonterrey", dtt);
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
            ReportDataSource rpts = new ReportDataSource("ReporteSemanalTotalProductoMonterrey", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
