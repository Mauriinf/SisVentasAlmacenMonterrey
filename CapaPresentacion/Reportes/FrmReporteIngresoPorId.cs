using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteIngresoPorId : Form
    {
        private int _Idingreso;
        public int Idingreso
        {
            get { return _Idingreso; }
            set { _Idingreso = value; }
        }
        public FrmReporteIngresoPorId()
        {
            InitializeComponent();
        }

        private void FrmReporteIngresoPorId_Load(object sender, EventArgs e)
        {
            try
            {
               // this.p_reporte_ingresoTableAdapter.Fill(this.DaPrincipal.p_reporte_ingreso, Idingreso);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
            
            
        }
    }
}
