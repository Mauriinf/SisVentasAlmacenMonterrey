using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DTrabajador
    {
        //declarar todos lo atributos que tiene nuestra tabla
        private int _Idtrabajador;//_para diferenciar
        private string _Nombre;
        private string _Apellidop;
        private string _Apellidom;
        private string _Ci;
        private string _Sexo;
        private string _TextoBuscar;
        private DateTime _FechaNac;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _TipoTrabajador;
        private string _Usuario;
        private string _Password;
        private string _Estado;

        public int Idtrabajador
        {
            get
            {
                return _Idtrabajador;
            }

            set
            {
                _Idtrabajador = value;
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

        public DateTime FechaNac
        {
            get
            {
                return _FechaNac;
            }

            set
            {
                _FechaNac = value;
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

        public string TipoTrabajador
        {
            get
            {
                return _TipoTrabajador;
            }

            set
            {
                _TipoTrabajador = value;
            }
        }

        public string Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                _Usuario = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        public string Estado
        {
            get
            {
                return _Estado;
            }

            set
            {
                _Estado = value;
            }
        }
        //Constructor Vacío
        public DTrabajador()
        {

        }
        //Constructor con parámetros
        public DTrabajador(int idtrabajador, string nombre, string apellidop, string apellidom, string sexo,DateTime fechanac, string ci,string direccion,string telefono,string email,string tipotrabajador,string usuario,string password,string estado, string textobuscar)//todo minuscula ara diferenciar
        {
            this.Idtrabajador = idtrabajador;
            this.Nombre = nombre;
            this.Apellidop = apellidop;
            this.Apellidom = apellidom;
            this.Ci = ci;
            this.Sexo = sexo;
            this.FechaNac = fechanac;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.TipoTrabajador = tipotrabajador;
            this.Usuario = usuario;
            this.Password = password;
            this.Estado = estado;
            this.TextoBuscar = textobuscar;

        }
        //Método Insertar

        public string Insertar(DTrabajador Trabajador)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "pinsertar_trabajador";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idtrabajador";//variable de procedimieto almacenado
                ParIdtrabajador.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdtrabajador.Direction = ParameterDirection.Output;//parametro de salida
                SqlCmd.Parameters.Add(ParIdtrabajador);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 20;//tamaño
                ParNombre.Value = Trabajador.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidop = new SqlParameter();
                ParApellidop.ParameterName = "@apellidop";//variable de procedimieto almacenado
                ParApellidop.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApellidop.Size = 20;//tamaño
                ParApellidop.Value = Trabajador.Apellidop;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApellidop);

                SqlParameter ParApelldiom = new SqlParameter();
                ParApelldiom.ParameterName = "@apellidom";//variable de procedimieto almacenado
                ParApelldiom.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApelldiom.Size = 20;//tamaño
                ParApelldiom.Value = Trabajador.Apellidom;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApelldiom);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";//variable de procedimieto almacenado
                ParSexo.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParSexo.Size = 1;//tamaño
                ParSexo.Value = Trabajador.Sexo;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter Parfecha = new SqlParameter();
                Parfecha.ParameterName = "@fechanac";//variable de procedimieto almacenado
                Parfecha.SqlDbType = SqlDbType.DateTime;//tipo de dato
                Parfecha.Size = 15;//tamaño
                Parfecha.Value = Trabajador.FechaNac;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(Parfecha);

                SqlParameter ParCi = new SqlParameter();
                ParCi.ParameterName = "@ci";//variable de procedimieto almacenado
                ParCi.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParCi.Size = 10;//tamaño
                ParCi.Value = Trabajador.Ci;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParCi);

                SqlParameter ParDireccion= new SqlParameter();
                ParDireccion.ParameterName = "@direccion";//variable de procedimieto almacenado
                ParDireccion.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParDireccion.Size = 50;//tamaño
                ParDireccion.Value = Trabajador.Direccion;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";//variable de procedimieto almacenado
                ParTelefono.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParTelefono.Size = 10;//tamaño
                ParTelefono.Value = Trabajador.Telefono;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParTelefono);


                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";//variable de procedimieto almacenado
                ParEmail.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParEmail.Size = 50;//tamaño
                ParEmail.Value = Trabajador.Email;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipotrabajador";//variable de procedimieto almacenado
                ParTipo.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParTipo.Size = 20;//tamaño
                ParTipo.Value = Trabajador.TipoTrabajador;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";//variable de procedimieto almacenado
                ParUsuario.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParUsuario.Size = 20;//tamaño
                ParUsuario.Value = Trabajador.Usuario;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParUsuario);

                byte[] theBytes = Encoding.UTF8.GetBytes(Trabajador.Password);
                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";//variable de procedimieto almacenado
                ParPassword.SqlDbType = SqlDbType.VarBinary;//tipo de dato
                ParPassword.Size = 8000;//tamaño
                ParPassword.Value = theBytes;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParPassword);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";//variable de procedimieto almacenado
                ParEstado.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParEstado.Size = 20;//tamaño
                ParEstado.Value = Trabajador.Estado;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParEstado);


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
        public string Editar(DTrabajador Trabajador)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peditar_Trabajador";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";//variable de procedimieto almacenado
                ParIdTrabajador.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdTrabajador.Value = Trabajador.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdTrabajador);//agregar este parametro a nuestro comando

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";//variable de procedimieto almacenado
                ParNombre.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParNombre.Size = 20;//tamaño
                ParNombre.Value = Trabajador.Nombre;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidop = new SqlParameter();
                ParApellidop.ParameterName = "@apellidop";//variable de procedimieto almacenado
                ParApellidop.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApellidop.Size = 20;//tamaño
                ParApellidop.Value = Trabajador.Apellidop;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApellidop);

                SqlParameter ParApelldiom = new SqlParameter();
                ParApelldiom.ParameterName = "@apellidom";//variable de procedimieto almacenado
                ParApelldiom.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParApelldiom.Size = 20;//tamaño
                ParApelldiom.Value = Trabajador.Apellidom;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParApelldiom);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";//variable de procedimieto almacenado
                ParSexo.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParSexo.Size = 1;//tamaño
                ParSexo.Value = Trabajador.Sexo;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter Parfecha = new SqlParameter();
                Parfecha.ParameterName = "@fechanac";//variable de procedimieto almacenado
                Parfecha.SqlDbType = SqlDbType.DateTime;//tipo de dato
                Parfecha.Size = 15;//tamaño
                Parfecha.Value = Trabajador.FechaNac;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(Parfecha);

                SqlParameter ParCi = new SqlParameter();
                ParCi.ParameterName = "@ci";//variable de procedimieto almacenado
                ParCi.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParCi.Size = 10;//tamaño
                ParCi.Value = Trabajador.Ci;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParCi);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";//variable de procedimieto almacenado
                ParDireccion.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParDireccion.Size = 50;//tamaño
                ParDireccion.Value = Trabajador.Direccion;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";//variable de procedimieto almacenado
                ParTelefono.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParTelefono.Size = 10;//tamaño
                ParTelefono.Value = Trabajador.Telefono;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParTelefono);


                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";//variable de procedimieto almacenado
                ParEmail.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParEmail.Size = 50;//tamaño
                ParEmail.Value = Trabajador.Email;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParTipo = new SqlParameter();
                ParTipo.ParameterName = "@tipotrabajador";//variable de procedimieto almacenado
                ParTipo.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParTipo.Size = 20;//tamaño
                ParTipo.Value = Trabajador.TipoTrabajador;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParTipo);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";//variable de procedimieto almacenado
                ParUsuario.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParUsuario.Size = 20;//tamaño
                ParUsuario.Value = Trabajador.Usuario;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParUsuario);

                

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";//variable de procedimieto almacenado
                ParEstado.SqlDbType = SqlDbType.VarChar;//tipo de dato
                ParEstado.Size = 20;//tamaño
                ParEstado.Value = Trabajador.Estado;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParEstado);




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
        public string Eliminar(DTrabajador Trabajador)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peliminar_trabajador";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";//variable de procedimieto almacenado
                ParIdTrabajador.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdTrabajador.Value = Trabajador.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdTrabajador);//agregar este parametro a nuestro comando




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
            DataTable DtResultado = new DataTable("Trabajador");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();//crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_Trabajador";//nombre del procedimiento almacnado
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
        public DataTable BuscarNombre(DTrabajador Trabajador)//instanciar a la clase DCategoria2 y generamos es objeto categoria
                                                         //data table devolver la tabla
        {
            DataTable DtResultado = new DataTable("Trabajador");//nombre de la tabla
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();// crear un comando
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_trabajador";//nombre del procedimiento almacnado
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es procedimiento

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";//nombre del parametro a la cual ara referencia
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = Trabajador.TextoBuscar;
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
        public DataTable Login(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("Trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                byte[] theBytes = Encoding.UTF8.GetBytes(Trabajador.Password);
                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarBinary;
                ParPassword.Size = 8000;
                ParPassword.Value = theBytes;
                SqlCmd.Parameters.Add(ParPassword);

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
