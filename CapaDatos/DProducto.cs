using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DProducto
    {
        //declarar todos lo atributos que tiene nuestra tabla
        private string _Idproducto;//_para diferenciar
        private string _Nombre;
        private string _Idcategoria;
        private string _TextoBuscar;
        private string _Unidadmedida;



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

        public string Idproducto
        {
            get
            {
                return _Idproducto;
            }

            set
            {
                _Idproducto = value;
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

        public string Unidadmedida
        {
            get
            {
                return _Unidadmedida;
            }

            set
            {
                _Unidadmedida = value;
            }
        }

        //Constructor Vacío
        public DProducto()
        {

        }
        //Constructor con parámetros
        public DProducto(string idproducto, string nombre, string idcategoria, string textobuscar,string unidadmedida)
        {
            this.Idproducto = idproducto;
            this.Nombre = nombre;

            this.Idcategoria = idcategoria;
            this.TextoBuscar = textobuscar;
            this.Unidadmedida = unidadmedida;

        }
        //Método Insertar

        public string Insertar(DProducto Producto1)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "pinsertar_producto1";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";//variable de procedimieto almacenado
                ParIdproducto.SqlDbType = SqlDbType.VarChar;//ipo de dato
                ParIdproducto.Size = 20;//tamaño
                ParIdproducto.Value = Producto1.Idproducto;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParIdproducto);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 50;//tamaño
                ParNombre.Value = Producto1.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);



                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";//variable de procedimieto almacenado
                ParIdcategoria.SqlDbType = SqlDbType.VarChar;//ipo de dato
                ParIdcategoria.Size = 20;//tamaño
                ParIdcategoria.Value = Producto1.Idcategoria;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParIdcategoria);


                SqlParameter ParUnidadmedida = new SqlParameter();
                ParUnidadmedida.ParameterName = "@unidadmedida";//variable de procedimieto almacenado
                ParUnidadmedida.SqlDbType = SqlDbType.VarChar;//ipo de dato
                ParUnidadmedida.Size = 20;//tamaño
                ParUnidadmedida.Value = Producto1.Unidadmedida;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParUnidadmedida);
                //Ejecutamos nuestro comando@unidadmedida

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
        public string Editar(DProducto Producto1)//instanciar a la clase Dproducto y generamos es objeto producto
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
                SqlCmd.CommandText = "peditar_producto1";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";//variable de procedimieto almacenado
                ParIdproducto.SqlDbType = SqlDbType.VarChar;//ipo de dato
                ParIdproducto.Size = 20;//tamaño
                ParIdproducto.Value = Producto1.Idproducto;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParIdproducto);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 50;//tamaño
                ParNombre.Value = Producto1.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);



                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria";//variable de procedimieto almacenado
                ParIdcategoria.SqlDbType = SqlDbType.VarChar;//ipo de dato
                ParIdcategoria.Size = 20;//tamaño
                ParIdcategoria.Value = Producto1.Idcategoria;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParIdcategoria);


                SqlParameter ParUnidadmedida = new SqlParameter();
                ParUnidadmedida.ParameterName = "@unidadmedida";//variable de procedimieto almacenado
                ParUnidadmedida.SqlDbType = SqlDbType.VarChar;//ipo de dato
                ParUnidadmedida.Size = 20;//tamaño
                ParUnidadmedida.Value = Producto1.Unidadmedida;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParUnidadmedida);
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
        public string Eliminar(DProducto Producto1)//instanciar a la clase Dproducto y generamos es objeto produto
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
                SqlCmd.CommandText = "peliminar_producto1";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";//variable de procedimieto almacenado
                ParIdproducto.SqlDbType = SqlDbType.VarChar;//ipo de dato
                ParIdproducto.Size = 20;
                ParIdproducto.Value = Producto1.Idproducto;
                SqlCmd.Parameters.Add(ParIdproducto);//agregar este parametro a nuestro comando




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
            DataTable DtResultado = new DataTable("producto1");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();//crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_producto1";//nombre del procedimiento almacnado
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
        public DataTable BuscarNombre(DProducto Producto1)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                           //data table devolver la tabla
        {
            DataTable DtResultado = new DataTable("producto1");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();// crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_producto1";//nombre del procedimiento almacnado
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es procedimiento

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";//nombre del parametro a la cual ara referencia
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto1.TextoBuscar;
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
