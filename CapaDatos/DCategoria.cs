using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DCategoria
    //debe ser publica
    {
        private string _Idcategoria;
        private string _Nombre;
        private string _TextoBuscar;



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

        public string Idcategoria
        {
            get
            {
                return _Idcategoria;
            }

            set
            {
                _Idcategoria = value;
            }
        }



        //Constructor Vacío
        public DCategoria()
        {

        }
        //Constructor con parámetros
        public DCategoria(string idcategoria, string nombre, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.TextoBuscar = textobuscar;

        }
        //Método Insertar

        public string Insertar(DCategoria Categoria)
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
                SqlCmd.CommandText = "pinsertar_categoria";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";//variable de procedimieto almacenado
                ParIdcategoria.SqlDbType = SqlDbType.VarChar;//ipo de dato
                ParIdcategoria.Size = 20;//tamaño
                ParIdcategoria.Value = Categoria.Idcategoria;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParIdcategoria);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 30;//tamaño
                ParNombre.Value = Categoria.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);


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
        public string Editar(DCategoria Categoria)
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
                SqlCmd.CommandText = "peditar_categoria";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";//variable de procedimieto almacenado
                ParIdcategoria.SqlDbType = SqlDbType.VarChar;//ipo de dato
                ParIdcategoria.Size = 20;//tamaño
                ParIdcategoria.Value = Categoria.Idcategoria;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParIdcategoria);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 30;//tamaño
                ParNombre.Value = Categoria.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);


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
        public string Eliminar(DCategoria Categoria)
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
                SqlCmd.CommandText = "peliminar_categoria";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";//variable de procedimieto almacenado
                ParIdcategoria.SqlDbType = SqlDbType.VarChar;//ipo de dato
                ParIdcategoria.Size = 20;//tamaño
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);//agregar este parametro a nuestro comando




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
            DataTable DtResultado = new DataTable("categoria1");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();//crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_categoria";//nombre del procedimiento almacnado
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
        public DataTable BuscarNombre(DCategoria Categoria)//data table devolver la tabla
        {
            DataTable DtResultado = new DataTable("categoria1");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 30;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
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
