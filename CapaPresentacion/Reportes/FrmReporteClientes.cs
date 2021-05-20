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
    public partial class FrmReporteClientes : Form
    {
        public FrmReporteClientes()
        {
            InitializeComponent();
        }
        private DataTable reporte(DataTable dt)
        {
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            SqlDataAdapter da = new SqlDataAdapter("select idcliente ,nombre as Nombre,apellidop as Apellido_Paterno, apellidom as Apellido_Materno,ci as Ci, sexo as Sexo,Puesto_Venta from clientes order by idcliente desc", cn);
            da.Fill(dt);
            return dt;
        }
        private void FrmReporteClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DaPrincipal.preporte_mostrar_clientes' Puede moverla o quitarla según sea necesario.
            //  this.preporte_mostrar_clientesTableAdapter.Fill(this.DaPrincipal.preporte_mostrar_clientes);
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("Clientes", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
         
           
        }
    }
}
