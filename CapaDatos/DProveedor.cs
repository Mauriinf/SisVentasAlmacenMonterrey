using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DProveedor
    {
        //declarar todos lo atributos que tiene nuestra tabla
        private int _IdProveedor;//_para diferenciar
        private string _Nombre;
        private string _Direccion;
        private string _Ciudad;
        private string _Telefono;
        private string _Email;
        private string _TextoBuscar;

        public int IdProveedor
        {
            get
            {
                return _IdProveedor;
            }

            set
            {
                _IdProveedor = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _Direccion;
            }

            set
            {
                _Direccion = value;
            }
        }

        public string Ciudad
        {
            get
            {
                return _Ciudad;
            }

            set
            {
                _Ciudad = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _Telefono;
            }

            set
            {
                _Telefono = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }

        //Constructor Vacío
        public DProveedor()
        {

        }
        //Constructor con parámetros
        public DProveedor(int idproveedor, string nombre,string direccion,string ciudad, string telefono, string email, string textobuscar)//todo minuscula ara diferenciar
        {
            this.IdProveedor = idproveedor;
            this.Nombre = nombre;
            this.Ciudad = ciudad;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            
        }
        //Método Insertar

        public string Insertar(DProveedor Proveedor)//instanciar a la clase DCategoria2 y generamos es objeto categoria
        {
            string rpta = "";//respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;//conexio base de datos
                SqlCon.Open();//abrir la conexion
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pinsertar_Proveedor";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idproveedor";//variable de procedimieto almacenado
                ParIdtrabajador.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdtrabajador.Direction = ParameterDirection.Output;//parametro de salida
                SqlCmd.Parameters.Add(ParIdtrabajador);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 20;//tamaño
                ParNombre.Value = Proveedor.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);

                

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";//variable de procedimieto almacenado
                ParDireccion.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParDireccion.Size = 50;//tamaño
                ParDireccion.Value = Proveedor.Direccion;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParDireccion);


                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@ciudad";//variable de procedimieto almacenado
                ParCiudad.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParCiudad.Size = 50;//tamaño
                ParCiudad.Value = Proveedor.Ciudad;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParCiudad);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";//variable de procedimieto almacenado
                ParTelefono.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParTelefono.Size = 20;//tamaño
                ParTelefono.Value = Proveedor.Telefono;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParTelefono);


                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";//variable de procedimieto almacenado
                ParEmail.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParEmail.Size = 50;//tamaño
                ParEmail.Value = Proveedor.Email;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParEmail);

                
                

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";//si es verdadero "OK" sino "No se ingreso el registro"


            }
            catch (Exception ex)//error
            {
                rpta = ex.Message;//mostrar error
            }
            finally//cerrar la cade na conexion
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//si la coneion esta abierta entonces cerrarlo
            }
            return rpta;

        }

        //Método Editar
        public string Editar(DProveedor Proveedor)//instanciar a la clase DCategoria2 y generamos es objeto categoria
        {
            string rpta = "";//respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;//conexio base de datos
                SqlCon.Open();//abrir la coexion
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "peditar_Proveedor";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idproveedor";//variable de procedimieto almacenado
                ParIdtrabajador.SqlDbType = SqlDbType.Int;//ipo de da
                ParIdtrabajador.Value = Proveedor.IdProveedor;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParIdtrabajador);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 20;//tamaño
                ParNombre.Value = Proveedor.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);



                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";//variable de procedimieto almacenado
                ParDireccion.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParDireccion.Size = 50;//tamaño
                ParDireccion.Value = Proveedor.Direccion;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParDireccion);


                SqlParameter ParCiudad = new SqlParameter();
                ParCiudad.ParameterName = "@ciudad";//variable de procedimieto almacenado
                ParCiudad.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParCiudad.Size = 50;//tamaño
                ParCiudad.Value = Proveedor.Ciudad;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParCiudad);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";//variable de procedimieto almacenado
                ParTelefono.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParTelefono.Size = 20;//tamaño
                ParTelefono.Value = Proveedor.Telefono;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParTelefono);


                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";//variable de procedimieto almacenado
                ParEmail.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParEmail.Size = 50;//tamaño
                ParEmail.Value = Proveedor.Email;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParEmail);




                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";//si es verdadero "OK" sino "No se ingreso el registro"


            }
            catch (Exception ex)//error
            {
                rpta = ex.Message;//mostrar error
            }
            finally//cerrar la cade na conexion
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//si la coneion esta abierta entonces cerrarlo
            }
            return rpta;
        }

        //Método Eliminar
        public string Eliminar(DProveedor Proveedor)//instanciar a la clase DCategoria2 y generamos es objeto categoria
        {
            string rpta = "";//respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;//conexio base de datos
                SqlCon.Open();//abrir la coexion
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "peliminar_proveedor";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";//variable de procedimieto almacenado
                ParIdProveedor.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdProveedor.Value =Proveedor.IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);//agregar este parametro a nuestro comando




                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";//si es verdadero "OK" sino "No se ingreso el registro"


            }
            catch (Exception ex)//error
            {
                rpta = ex.Message;//mostrar error
            }
            finally//cerrar la cade na conexion
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//si la coneion esta abierta entonces cerrarlo
            }
            return rpta;
        }

        //Método Mostrar
        public DataTable Mostrar()//mostrar toda la tabla
        {
            DataTable DtResultado = new DataTable("Proveedor");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();//crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_Proveedor";//nombre del procedimiento almacnado
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es procedimiento

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);//ejecutar el comando y llenar el data table
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        //Método BuscarNombre
        public DataTable BuscarNombre(DProveedor Proveedor)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                             //data table devolver la tabla
        {
            DataTable DtResultado = new DataTable("Proveedor");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();// crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_proveedor";//nombre del procedimiento almacnado
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es procedimiento

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";//nombre del parametro a la cual ara referencia
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
}
