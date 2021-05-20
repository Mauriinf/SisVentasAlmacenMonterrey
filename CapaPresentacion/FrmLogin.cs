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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmCalendario form = new FrmCalendario();
            form.ShowDialog();
            
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            ConfiguracionDataBase fr = new ConfiguracionDataBase();
            fr.Show();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
            this.Datos.Visible = false;
            this.txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //DataTable Datos = null;
            if (NTrabajador.verificacion())
            {
                this.Datos.DataSource = CapaNegocio.NTrabajador.Login(this.txtUsuario.Text, this.txtPassword.Text);
                //Evaluar si existe el Usuario
                if (Datos.Rows.Count > 0)
                {
                    if (this.txtUsuario.Text != (Datos.Rows[0].Cells[1].Value.ToString()) && this.txtPassword.Text != (Datos.Rows[0].Cells[2].Value.ToString()))
                    {
                        MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        MDIPrincipal frm = new MDIPrincipal();
                        frm.Idtrabajador = Datos.Rows[0].Cells[0].Value.ToString();
                        frm.ApellidoPaterno = Datos.Rows[0].Cells[4].Value.ToString();
                        frm.Nombre = Datos.Rows[0].Cells[3].Value.ToString();
                        frm.ApellidoMaterno = Datos.Rows[0].Cells[5].Value.ToString();
                        frm.TipoAcceso = Datos.Rows[0].Cells[6].Value.ToString();
                        MessageBox.Show("BIENVENIDO "+Datos.Rows[0].Cells[3].Value.ToString(), "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm.Show();
                        this.Hide();

                    }
                }
                else
                {
                    MessageBox.Show("NO tiene acceso al sistema", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("NO existe conexió a la base de datos", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                txtPassword.Focus();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                btnIngresar.Focus();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
