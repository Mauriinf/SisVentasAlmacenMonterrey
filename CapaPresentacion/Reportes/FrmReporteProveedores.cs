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
    public partial class FrmReporteProveedores : Form
    {
        public FrmReporteProveedores()
        {
            InitializeComponent();
        }
        private DataTable reporte(DataTable dt)
        {
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            SqlDataAdapter da = new SqlDataAdapter("SELECT *  FROM Proveedores order by Nombre asc", cn);
            da.Fill(dt);
            return dt;
        }
        private void FrmReporteProveedores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'daPrincipal.preporte_mostrar_categoria' Puede moverla o quitarla según sea necesario.
            //this.preporte_mostrar_categoriaTableAdapter.Fill(this.daPrincipal.preporte_mostrar_categoria);
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("ReporteProveedores", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
