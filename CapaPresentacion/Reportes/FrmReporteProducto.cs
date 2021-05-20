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
    public partial class FrmReporteProducto : Form
    {
        public FrmReporteProducto()
        {
            InitializeComponent();
        }
        private DataTable reporte(DataTable dt)
        {
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            SqlDataAdapter da = new SqlDataAdapter("SELECT  dbo.producto1.idproducto1 as ID_Producto,dbo.producto1.nombre as Producto, dbo.producto1.idCategoria as ID_Categoria, dbo.categoria1.nombre AS Categoria, dbo.producto1.Unidad_De_Medida FROM dbo.categoria1 INNER JOIN dbo.producto1 ON dbo.categoria1.idCategoria = dbo.producto1.idCategoria order by producto1.nombre asc", cn);
            da.Fill(dt);
            return dt;
        }
        private void FrmReporteProducto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'daPrincipal.preporte_mostrar_producto' Puede moverla o quitarla según sea necesario.
            // this.preporte_mostrar_productoTableAdapter.Fill(this.daPrincipal.preporte_mostrar_producto);

            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("DataSet1", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
