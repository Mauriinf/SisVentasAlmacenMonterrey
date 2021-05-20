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
using System.Data.SqlClient;
namespace CapaPresentacion
{
    public partial class ConfiguracionDataBase : Form
    {
        private Boolean valor = true;
        public ConfiguracionDataBase()
        {
            InitializeComponent();
        }

        private void ConfiguracionDataBase_Load(object sender, EventArgs e)
        {
            habilitar();
            limpiar();

        }
        private void habilitar()
        {
            this.txtserver.Enabled = true;
            this.txtDatabase.Enabled = true;
            if (rbUno.Checked==true)
            {
                this.txtUser.Enabled = false;
                this.txtPass.Enabled = false;

            }
            else
            {
                this.txtUser.Enabled = true;
                this.txtPass.Enabled = true;
                this.rbUno.Enabled= false;
            }
            if (this.chkVerificar.Checked==true)
            {
                this.btnOk.Enabled = true;
                this.btnOk.BackgroundImage = CapaPresentacion.Properties.Resources.b1;//../ir atras un directorio
                this.btnOk.BackgroundImageLayout = ImageLayout.Stretch;
                
            }
            else
            {
                this.btnOk.Enabled = false;
                this.btnOk.BackgroundImage = CapaPresentacion.Properties.Resources.b2;//../ir atras un directorio
                this.btnOk.BackgroundImageLayout = ImageLayout.Stretch;
                this.btnOk.FlatAppearance.BorderColor = Color.Tomato;
            }
        }
        private void limpiar()
        {
            this.txtserver.Text = string.Empty;
            this.txtDatabase.Text = string.Empty;
            this.txtUser.Text = string.Empty;
            this.txtPass.Text = string.Empty;
        }

        private bool verificar()
        {
            try
            {
                string cadena = "Data Source=" + txtserver.Text + ";Initial Catalog=" + txtDatabase.Text + ";User ID=" + txtUser.Text + ";Password=" + txtPass.Text;
                using (SqlConnection conn = new SqlConnection(cadena))
                {
                    conn.Open();

                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            rbUno.Checked = true;
            rbDos.Enabled = true;
            habilitar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            habilitar();
            this.Hide();
        }

        private void rbDos_CheckedChanged(object sender, EventArgs e)
        {
            if (valor)
            {
                habilitar();
            }
        }

        private void rbUno_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void chkVerificar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerificar.Checked == true)
            {
                if (verificar())
                {
                    MessageBox.Show("Conexión Correcta", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkVerificar.Checked = false;
                    this.btnOk.Enabled = true;
                    this.btnOk.BackgroundImage = CapaPresentacion.Properties.Resources.b1;//../ir atras un directorio
                    this.btnOk.BackgroundImageLayout = ImageLayout.Stretch;
                    this.btnOk.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 0);
                    this.txtserver.Enabled = false;
                    this.txtDatabase.Enabled = false;
                    this.txtUser.Enabled = false;
                    this.txtPass.Enabled = false;
                    this.rbUno.Enabled = false;
                    this.rbDos.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Conexion Incorrecta", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chkVerificar.Checked = false;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Nconexion.conex(txtserver.Text, txtDatabase.Text, txtUser.Text, txtPass.Text);
            // MessageBox.Show("Guardado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Se guardo la cadena de conexion. Cierre ó Reinicie la aplicaión", "Sistema MONTERREY", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiar();
            habilitar();
            FrmLogin fr = new FrmLogin();
            fr.Show();
            this.Hide();
        }

        private void txtserver_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtserver_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtDatabase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                rbUno.Focus();
        }

        private void rbDos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtUser.Focus();

        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                chkVerificar.Focus();
        }

        private void rbUno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                rbDos.Focus();
        }

        private void chkVerificar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnOk_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnCancelar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnLimpiar_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtDatabase_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
