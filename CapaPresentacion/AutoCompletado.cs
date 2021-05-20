using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;
namespace CapaPresentacion
{
    class AutoCompletado
    {
        SqlConnection SqlCon = new SqlConnection();
        SqlCommand cmd;
        SqlDataReader dr;
        public AutoCompletado()
        {
            try
            {
                SqlCon.ConnectionString = NTrabajador.cadenaConexion();
                SqlCon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar a la base de datos: "+ex.ToString());
            }
        }
        public void AutocompletarConductor(TextBox cajatexto,TextBox id, TextBox placa)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                            //data table devolver la tabla
        {


            try
            {
             
                cmd = new SqlCommand("select idconductor as Id,(nombre +' '+ apellidop + ' '+apellidom) as NombreCompleto, nlicencia as NroLicencia,placa as Placa from conductor", SqlCon);//crear un comando
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    //string[] customSourceItems = new string[] { dr["Nombre"].ToString(), dr["ApellidoPaterno"].ToString()};
                    cajatexto.AutoCompleteCustomSource.Add(dr["NombreCompleto"].ToString());
                    
                }
                // id.Text = dr["Id"].ToString();
                /// placa.Text = dr["Placa"].ToString();
               


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo autocompletar el textBox: " + ex.ToString());
            }
            if (dr.Read() == true)
            {
                id.Text = dr["Id"].ToString();
                placa.Text = dr["Placa"].ToString();
            }
            else
            {
                id.Text = "";
                placa.Text ="";
            }
         

        }

        public void llenarcomboBox(ComboBox combo)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                                                        //data table devolver la tabla
        {
            DataTable tb = new DataTable("tabla");
            cmd = new SqlCommand("select idconductor as Id,(nombre +' '+ apellidop + ' '+apellidom) as NombreCompleto, nlicencia as NroLicencia,placa as Placa from conductor", SqlCon);
            dr = cmd.ExecuteReader();
            tb.Load(dr);
            combo.DisplayMember = "NombreCompleto";
            combo.ValueMember = "Id";
            
            combo.DataSource = tb;
        }
        public void llenarcomboBoxProducto(ComboBox combo)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                  //data table devolver la tabla
        {
            DataTable tb = new DataTable("tabla2");
            cmd = new SqlCommand("SELECT   dbo.producto1.idproducto1,dbo.producto1.nombre,dbo.producto1.Unidad_De_Medida, dbo.producto1.idCategoria FROM dbo.producto1", SqlCon);
            dr = cmd.ExecuteReader();
            tb.Load(dr);
            combo.DisplayMember = "nombre";
            combo.ValueMember = "idproducto1";

            combo.DataSource = tb;
        }
        public void llenarcomboBoxCliente(ComboBox combo)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                          //data table devolver la tabla
        {
            DataTable tb = new DataTable("tabla");
            cmd = new SqlCommand("select idcliente ,(nombre+' '+apellidop +' '+apellidom ) as NombreCompleto,ci , sexo,Puesto_Venta from clientes", SqlCon);
            dr = cmd.ExecuteReader();
            tb.Load(dr);
            combo.DisplayMember = "NombreCompleto";
            combo.ValueMember = "idcliente";

            combo.DataSource = tb;
        }
        public void llenarcomboBoxProveedor(ComboBox combo)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                         //data table devolver la tabla
        {
            DataTable tb = new DataTable("tabla");
            cmd = new SqlCommand("select IdProveedor ,Nombre,Direccion,Ciudad,Telefono,Email from Proveedores order by Nombre desc", SqlCon);
            dr = cmd.ExecuteReader();
            tb.Load(dr);
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "idProveedor";

            combo.DataSource = tb;
        }
        public void llenarcomboBoxCategoria(ComboBox combo)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                          //data table devolver la tabla
        {
            DataTable tb = new DataTable("tabla2");
            cmd = new SqlCommand("select * from categoria1", SqlCon);
            dr = cmd.ExecuteReader();
            tb.Load(dr);
            combo.DisplayMember = "nombre";
            combo.ValueMember = "idCategoria";

            combo.DataSource = tb;
        }
    }
   
}
