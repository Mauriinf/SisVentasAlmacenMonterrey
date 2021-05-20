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
    public partial class FrmReporteConductores : Form
    {
        public FrmReporteConductores()
        {
            InitializeComponent();
        }
        private DataTable reporte(DataTable dt)
        {
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM conductor order by nombre asc", cn);
            da.Fill(dt);
            return dt;
        }
        private void FrmReporteConductores_Load(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("ReporteConductores", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
