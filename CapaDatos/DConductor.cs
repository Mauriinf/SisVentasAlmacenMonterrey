using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DConductor
    {
        //declarar todos lo atributos que tiene nuestra tabla
        private int _Idconductor;//_para diferenciar
        private string _Nombre;
        private string _Apellidop;
        private string _Apellidom;
        private string _Nlicencia;
        private string _Placa;
        private string _Sexo;
        private string _TextoBuscar;
        private string _Colorvehiculo;

        public int Idconductor
        {
            get
            {
                return _Idconductor;
            }

            set
            {
                _Idconductor = value;
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

        public string Nlicencia
        {
            get
            {
                return _Nlicencia;
            }

            set
            {
                _Nlicencia = value;
            }
        }

        public string Placa
        {
            get
            {
                return _Placa;
            }

            set
            {
                _Placa = value;
            }
        }

        public string Colorvehiculo
        {
            get
            {
                return _Colorvehiculo;
            }

            set
            {
                _Colorvehiculo = value;
            }
        }

        //Constructor Vacío
        public DConductor()
        {

        }
        //Constructor con parámetros
        public DConductor(int idconductor, string nombre, string apellidop, string apellidom, string nlicencia, string placa, string sexo, string textobuscar,string colorvehiculo)//todo minuscula ara diferenciar
        {
            this.Idconductor = idconductor;
            this.Nombre = nombre;
            this.Apellidop = apellidop;
            this.Apellidom = apellidom;
            this.Nlicencia = nlicencia;
            this._Placa = placa;
            this.Sexo = sexo;
            this.TextoBuscar = textobuscar;
            this.Colorvehiculo = colorvehiculo;

        }
        //Método Insertar

        public string Insertar(DConductor Conductor)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "pinsertar_conductor";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdconductor = new SqlParameter();
                ParIdconductor.ParameterName = "@idconductor";//variable de procedimieto almacenado
                ParIdconductor.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdconductor.Direction = ParameterDirection.Output;//parametro de salida
                SqlCmd.Parameters.Add(ParIdconductor);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 20;//tamaño
                ParNombre.Value = Conductor.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidop = new SqlParameter();
                ParApellidop.ParameterName = "@apellidop";//variable de procedimieto almacenado
                ParApellidop.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApellidop.Size = 20;//tamaño
                ParApellidop.Value = Conductor.Apellidop;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApellidop);

                SqlParameter ParApelldiom = new SqlParameter();
                ParApelldiom.ParameterName = "@apellidom";//variable de procedimieto almacenado
                ParApelldiom.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApelldiom.Size = 20;//tamaño
                ParApelldiom.Value = Conductor.Apellidom;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApelldiom);

                SqlParameter ParNlicencia = new SqlParameter();
                ParNlicencia.ParameterName = "@nlicencia";//variable de procedimieto almacenado
                ParNlicencia.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNlicencia.Size = 30;//tamaño
                ParNlicencia.Value = Conductor.Nlicencia;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNlicencia);

                SqlParameter ParPlaca = new SqlParameter();
                ParPlaca.ParameterName = "@placa";//variable de procedimieto almacenado
                ParPlaca.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParPlaca.Size = 20;//tamaño
                ParPlaca.Value = Conductor.Placa;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParPlaca);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";//variable de procedimieto almacenado
                ParSexo.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParSexo.Size = 20;//tamaño
                ParSexo.Value = Conductor.Sexo;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParColorvehiculo= new SqlParameter();
                ParColorvehiculo.ParameterName = "@colorvehiculo";//variable de procedimieto almacenado
                ParColorvehiculo.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParColorvehiculo.Size = 20;//tamaño
                ParColorvehiculo.Value = Conductor.Colorvehiculo;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParColorvehiculo);


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
        public string Editar(DConductor Conductor)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peditar_conductor";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdconductor = new SqlParameter();
                ParIdconductor.ParameterName = "@idconductor";//variable de procedimieto almacenado
                ParIdconductor.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdconductor.Value = Conductor.Idconductor;
                SqlCmd.Parameters.Add(ParIdconductor);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 20;//tamaño
                ParNombre.Value = Conductor.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidop = new SqlParameter();
                ParApellidop.ParameterName = "@apellidop";//variable de procedimieto almacenado
                ParApellidop.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApellidop.Size = 20;//tamaño
                ParApellidop.Value = Conductor.Apellidop;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApellidop);

                SqlParameter ParApellidom = new SqlParameter();
                ParApellidom.ParameterName = "@apellidom";//variable de procedimieto almacenado
                ParApellidom.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApellidom.Size = 20;//tamaño
                ParApellidom.Value = Conductor.Apellidom;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApellidom);

                SqlParameter ParNlicencia = new SqlParameter();
                ParNlicencia.ParameterName = "@nlicencia";//variable de procedimieto almacenado
                ParNlicencia.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNlicencia.Size = 30;//tamaño
                ParNlicencia.Value = Conductor.Nlicencia;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNlicencia);

                SqlParameter ParPlaca = new SqlParameter();
                ParPlaca.ParameterName = "@placa";//variable de procedimieto almacenado
                ParPlaca.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParPlaca.Size = 20;//tamaño
                ParPlaca.Value = Conductor.Placa;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParPlaca);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";//variable de procedimieto almacenado
                ParSexo.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParSexo.Size = 20;//tamaño
                ParSexo.Value = Conductor.Sexo;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParColorvehiculo = new SqlParameter();
                ParColorvehiculo.ParameterName = "@colorvehiculo";//variable de procedimieto almacenado
                ParColorvehiculo.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParColorvehiculo.Size = 20;//tamaño
                ParColorvehiculo.Value = Conductor.Colorvehiculo;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParColorvehiculo);

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
        public string Eliminar(DConductor Conductor)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peliminar_conductor";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdconductor = new SqlParameter();
                ParIdconductor.ParameterName = "@idconductor";//variable de procedimieto almacenado
                ParIdconductor.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdconductor.Value = Conductor.Idconductor;
                SqlCmd.Parameters.Add(ParIdconductor);//agregar este parametro a nuestro comando




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
            DataTable DtResultado = new DataTable("conductor");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();//crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_conductor";//nombre del procedimiento almacnado
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
        public DataTable BuscarNombre(DConductor Conductor)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                           //data table devolver la tabla
        {
            DataTable DtResultado = new DataTable("conductor");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();// crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_conductor";//nombre del procedimiento almacnado
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es procedimiento

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";//nombre del parametro a la cual ara referencia
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 30;
                ParTextoBuscar.Value = Conductor.TextoBuscar;
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
