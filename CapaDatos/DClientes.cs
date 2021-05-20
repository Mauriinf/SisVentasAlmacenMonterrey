using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DClientes
    {
        //declarar todos lo atributos que tiene nuestra tabla
        private int _Idcliente;//_para diferenciar
        private string _Nombre;
        private string _Apellidop;
        private string _Apellidom;
        private string _Ci;
        private string _Sexo;
        private string _TextoBuscar;
        private string _Puestoventa;

        public int Idcliente
        {
            get
            {
                return _Idcliente;
            }

            set
            {
                _Idcliente = value;
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

        public string Apellidop
        {
            get
            {
                return _Apellidop;
            }

            set
            {
                _Apellidop = value;
            }
        }

        public string Apellidom
        {
            get
            {
                return _Apellidom;
            }

            set
            {
                _Apellidom = value;
            }
        }

        public string Ci
        {
            get
            {
                return _Ci;
            }

            set
            {
                _Ci = value;
            }
        }

        public string Sexo
        {
            get
            {
                return _Sexo;
            }

            set
            {
                _Sexo = value;
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

        public string Puestoventa
        {
            get
            {
                return _Puestoventa;
            }

            set
            {
                _Puestoventa = value;
            }
        }

        //Constructor Vacío
        public DClientes()
        {

        }
        //Constructor con parámetros
        public DClientes(int idcliente, string nombre, string apellidop, string apellidom, string ci, string sexo, string textobuscar,string puestoventa)//todo minuscula ara diferenciar
        {
            this.Idcliente = idcliente;
            this.Nombre = nombre;
            this.Apellidop = apellidop;
            this.Apellidom = apellidom;
            this.Ci = ci;
            this.Sexo = sexo;
            this.TextoBuscar = textobuscar;
            this.Puestoventa = puestoventa;

        }
        //Método Insertar

        public string Insertar(DClientes Clientes)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "pinsertar_clientes";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";//variable de procedimieto almacenado
                ParIdcliente.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdcliente.Direction = ParameterDirection.Output;//parametro de salida
                SqlCmd.Parameters.Add(ParIdcliente);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 20;//tamaño
                ParNombre.Value = Clientes.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidop = new SqlParameter();
                ParApellidop.ParameterName = "@apellidop";//variable de procedimieto almacenado
                ParApellidop.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApellidop.Size = 20;//tamaño
                ParApellidop.Value = Clientes.Apellidop;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApellidop);

                SqlParameter ParApelldiom = new SqlParameter();
                ParApelldiom.ParameterName = "@apellidom";//variable de procedimieto almacenado
                ParApelldiom.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApelldiom.Size = 20;//tamaño
                ParApelldiom.Value = Clientes.Apellidom;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApelldiom);

                SqlParameter ParCi = new SqlParameter();
                ParCi.ParameterName = "@ci";//variable de procedimieto almacenado
                ParCi.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParCi.Size = 15;//tamaño
                ParCi.Value = Clientes.Ci;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParCi);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";//variable de procedimieto almacenado
                ParSexo.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParSexo.Size = 10;//tamaño
                ParSexo.Value = Clientes.Sexo;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParPuestoventa = new SqlParameter();
                ParPuestoventa.ParameterName = "@puestoventa";//variable de procedimieto almacenado
                ParPuestoventa.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParPuestoventa.Size = 50;//tamaño
                ParPuestoventa.Value = Clientes.Puestoventa;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParPuestoventa);


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
        public string Editar(DClientes Clientes)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peditar_clientes";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";//variable de procedimieto almacenado
                ParIdcliente.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdcliente.Value = Clientes.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 20;//tamaño
                ParNombre.Value = Clientes.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidop = new SqlParameter();
                ParApellidop.ParameterName = "@apellidop";//variable de procedimieto almacenado
                ParApellidop.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApellidop.Size = 20;//tamaño
                ParApellidop.Value = Clientes.Apellidop;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApellidop);

                SqlParameter ParApellidom = new SqlParameter();
                ParApellidom.ParameterName = "@apellidom";//variable de procedimieto almacenado
                ParApellidom.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApellidom.Size = 20;//tamaño
                ParApellidom.Value = Clientes.Apellidom;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApellidom);

                SqlParameter ParCi = new SqlParameter();
                ParCi.ParameterName = "@ci";//variable de procedimieto almacenado
                ParCi.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParCi.Size = 15;//tamaño
                ParCi.Value = Clientes.Ci;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParCi);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";//variable de procedimieto almacenado
                ParSexo.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParSexo.Size = 20;//tamaño
                ParSexo.Value = Clientes.Sexo;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParPuestoventa = new SqlParameter();
                ParPuestoventa.ParameterName = "@puestoventa";//variable de procedimieto almacenado
                ParPuestoventa.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParPuestoventa.Size = 50;//tamaño
                ParPuestoventa.Value = Clientes.Puestoventa;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParPuestoventa);

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
        public string Eliminar(DClientes Clientes)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peliminar_clientes";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";//variable de procedimieto almacenado
                ParIdcliente.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdcliente.Value = Clientes.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);//agregar este parametro a nuestro comando




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
            DataTable DtResultado = new DataTable("clientes");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();//crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_clientes";//nombre del procedimiento almacnado
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
        public DataTable BuscarNombre(DClientes Clientes)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                         //data table devolver la tabla
        {
            DataTable DtResultado = new DataTable("clientes");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();// crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_clientes";//nombre del procedimiento almacnado
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es procedimiento

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";//nombre del parametro a la cual ara referencia
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = Clientes.TextoBuscar;
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
