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
    public partial class FrmReporteIngreso2PorID : Form
    {
        private int _Idingreso;
        public int Idingreso
        {
            get { return _Idingreso; }
            set { _Idingreso = value; }
        }
        public FrmReporteIngreso2PorID()
        {
            InitializeComponent();
        }

        private void FrmReporteIngreso2PorID_Load(object sender, EventArgs e)
        {
            
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'daPrincipal.p_reporte_ingreso2' Puede moverla o quitarla según sea necesario.
               // this.p_reporte_ingreso2TableAdapter.Fill(this.daPrincipal.p_reporte_ingreso2,Idingreso);
                this.reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
