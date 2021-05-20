using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;
        public string Idtrabajador = "";
        public string ApellidoPaterno = "";
        public string Nombre = "";
        public string ApellidoMaterno= "";
        public string TipoAcceso = "";
        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            this.Width = 1500;
            this.Height = 750;
            this.Top = 10;
            this.Left = 10;
            

        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {

            FrmCategoria frm = new FrmCategoria();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            FrmClientes frm = new FrmClientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            FrmConductor frm = new FrmConductor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducto frm = new FrmProducto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            FrmTrabajador frm = new FrmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MDIPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void maximo_Click(object sender, EventArgs e)
        {
            FrmIngreso frm = new FrmIngreso();
            frm.MdiParent = this;
            frm.IDTrabajador = Convert.ToInt32(this.Idtrabajador);
            frm.Show();
            
            
        }

        private void monterey_Click(object sender, EventArgs e)
        {
            FrmIngreso2 frm = new FrmIngreso2();
            frm.MdiParent = this;
            frm.IDTrabajador = Convert.ToInt32(this.Idtrabajador);
            frm.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            FrmCobros frm = new FrmCobros();
            frm.MdiParent = this;
            frm.IDTrabajador = Convert.ToInt32(this.Idtrabajador);
            frm.Show();
        }

        private void ventanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool r = Nconexion.backups();
            if (r)
            {
                MessageBox.Show("La copia se ha creado Satisfactoriamente", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Porfavor intentelo de nuevo", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void entreFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteIngresoEntreFechas frm = new FrmReporteIngresoEntreFechas();
            frm.ShowDialog();
        }

        private void generalEntreFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteIngresoGenetalEntreFechas frm = new FrmReporteIngresoGenetalEntreFechas();
            frm.ShowDialog();
        }

        private void ventasYCobrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteGeneralVentaCobrosEntreFechas frm = new FrmReporteGeneralVentaCobrosEntreFechas();
            frm.ShowDialog();
        }

        private void ventasEnGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteDetalleGeneralVentasEntreFechas frm = new FrmReporteDetalleGeneralVentasEntreFechas();
            frm.ShowDialog();
        }

        private void estadoCuentasPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteEstadoDeCuentasPorCobrar frm = new FrmReporteEstadoDeCuentasPorCobrar();
            frm.ShowDialog();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cantidadYTotalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteCantidadVentasProductoSemanalMonterrey frm = new FrmReporteCantidadVentasProductoSemanalMonterrey();
            frm.ShowDialog();
        }

        private void cantidadYTotalesMaximoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteCantidadVentasProductoSemanalMaximo frm = new FrmReporteCantidadVentasProductoSemanalMaximo();
            frm.ShowDialog();
        }

        private void deudasClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBuscarDeudasVentasClientes frm = new FrmBuscarDeudasVentasClientes();
            frm.MdiParent = this;
           
            frm.Show();
           
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.MdiParent = this;
            frm.IDTrabajador = Convert.ToInt32(this.Idtrabajador);
            frm.Show();
        }

        private void ventasContadoYCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteImporteContadoCreditoSemanalMonterrey frm = new FrmReporteImporteContadoCreditoSemanalMonterrey();
            frm.ShowDialog();
        }

        private void ventasMaximoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporteImporteContadoCreditoSemanalMaximo frm = new FrmReporteImporteContadoCreditoSemanalMaximo();
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmProveedor frm = new FrmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
