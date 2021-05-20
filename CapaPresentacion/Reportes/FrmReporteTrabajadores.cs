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
    public partial class FrmReporteTrabajadores : Form
    {
        public FrmReporteTrabajadores()
        {
            InitializeComponent();
        }
        private DataTable reporte(DataTable dt)
        {
            string cnstr = Nconexion.CnReporte();
            SqlConnection cn = new SqlConnection(cnstr);
            string consulta = "select Id_Trabajador ,Nombre,Apellido_Paterno, Apellido_Materno,Sexo,Fecha_Nacimiento,Nro_Documento,Direccion,Telefono,Email, Tipo_Trabajador, Usuario, Estado from Trabajador where Tipo_Trabajador ='"+comboBox1.Text+"' order by Id_Trabajador desc";
            SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
            da.Fill(dt);
            return dt;
        }
        private void FrmReporteTrabajadores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DaPrincipal.preporte_mostrar_Trabajador' Puede moverla o quitarla según sea necesario.
            //   this.preporte_mostrar_TrabajadorTableAdapter.Fill(this.DaPrincipal.preporte_mostrar_Trabajador,comboBox1.Text);


            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("Trabajadores", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DaPrincipal.preporte_mostrar_clientes' Puede moverla o quitarla según sea necesario.
            // this.preporte_mostrar_TrabajadorTableAdapter.Fill(this.DaPrincipal.preporte_mostrar_Trabajador, comboBox1.Text);
            DataTable dtt = new DataTable();
            dtt = reporte(dtt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rpts = new ReportDataSource("Trabajadores", dtt);
            this.reportViewer1.LocalReport.DataSources.Add(rpts);
            this.reportViewer1.RefreshReport();
        }
    }
}
