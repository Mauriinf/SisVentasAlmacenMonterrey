using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DIngreso2
    {
        //Variables
        private int _Idingreso;      
        private int _Idtrabajador;
        private int _Idproveedor;
        private string _NroTalonario;
        private DateTime _Fechaingreso;
        private string _Comprobante;
        private string _NroComprobante;
        private string _Estado;

        public int Idingreso
        {
            get
            {
                return _Idingreso;
            }

            set
            {
                _Idingreso = value;
            }
        }

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

        
        public DateTime Fechaingreso
        {
            get
            {
                return _Fechaingreso;
            }

            set
            {
                _Fechaingreso = value;
            }
        }

        public string Comprobante
        {
            get
            {
                return _Comprobante;
            }

            set
            {
                _Comprobante = value;
            }
        }

        public string NroComprobante
        {
            get
            {
                return _NroComprobante;
            }

            set
            {
                _NroComprobante = value;
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

        public string NroTalonario
        {
            get
            {
                return _NroTalonario;
            }

            set
            {
                _NroTalonario = value;
            }
        }

        public int Idproveedor
        {
            get
            {
                return _Idproveedor;
            }

            set
            {
                _Idproveedor = value;
            }
        }

        public DIngreso2()
        {

        }

        public DIngreso2(int idingreso, int idtrabajador, int idproveedor,
            DateTime fechaingreso, string nrotalonario, string comprobante, string nrocomprobante, string estado)
        {
            this.Idingreso = idingreso;          
            this.Idtrabajador = idtrabajador;
            this.Fechaingreso = fechaingreso;
            this.Idproveedor = idproveedor;
            this.NroTalonario = nrotalonario;       
            this.Comprobante = comprobante;
            this.NroComprobante = nrocomprobante;           
            this.Estado = estado;
        }
        //Métodos
        public string Insertar(DIngreso2 Ingreso, List<DDetalle_Ingreso2> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer la trasacción
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "pinsertar_ingreso2";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdentrega = new SqlParameter();
                ParIdentrega.ParameterName = "@idingreso";
                ParIdentrega.SqlDbType = SqlDbType.Int;
                ParIdentrega.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdentrega);


                
                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Ingreso.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParNombreproveedor = new SqlParameter();
                ParNombreproveedor.ParameterName = "@proveedor";
                ParNombreproveedor.SqlDbType = SqlDbType.Int;
                ParNombreproveedor.Value = Ingreso.Idproveedor;
                SqlCmd.Parameters.Add(ParNombreproveedor);


               

                SqlParameter ParFechaingresodeposito = new SqlParameter();
                ParFechaingresodeposito.ParameterName = "@fechaingreso";
                ParFechaingresodeposito.SqlDbType = SqlDbType.Date;
                ParFechaingresodeposito.Value = Ingreso.Fechaingreso;
                SqlCmd.Parameters.Add(ParFechaingresodeposito);

                SqlParameter ParNroTalonario = new SqlParameter();
                ParNroTalonario.ParameterName = "@nrotalonario";
                ParNroTalonario.SqlDbType = SqlDbType.VarChar;
                ParNroTalonario.Size = 20;
                ParNroTalonario.Value = Ingreso.NroTalonario;
                SqlCmd.Parameters.Add(ParNroTalonario);

                SqlParameter ParComprobante = new SqlParameter();
                ParComprobante.ParameterName = "@comprobante";
                ParComprobante.SqlDbType = SqlDbType.VarChar;
                ParComprobante.Size = 20;
                ParComprobante.Value = Ingreso.Comprobante;
                SqlCmd.Parameters.Add(ParComprobante);

                SqlParameter ParNroComprobante = new SqlParameter();
                ParNroComprobante.ParameterName = "@nrocomprobante";
                ParNroComprobante.SqlDbType = SqlDbType.VarChar;
                ParNroComprobante.Size = 20;
                ParNroComprobante.Value = Ingreso.NroComprobante;
                SqlCmd.Parameters.Add(ParNroComprobante);                


                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    this.Idingreso = Convert.ToInt32(SqlCmd.Parameters["@idingreso"].Value);
                    foreach (DDetalle_Ingreso2 det in Detalle)
                    {
                        det.Idingreso = this.Idingreso;
                        //Llamar al método insertar de la clase DDetalle_Ingreso
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                    }

                }
                if (rpta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }
        public string Editar(DIngreso2 Ingreso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
               
                SqlCmd.CommandText = "peditar_ingreso2";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdentrega = new SqlParameter();
                ParIdentrega.ParameterName = "@idingreso";
                ParIdentrega.SqlDbType = SqlDbType.Int;
                ParIdentrega.Value = Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdentrega);


                
                SqlParameter ParNombreproveedor = new SqlParameter();
                ParNombreproveedor.ParameterName = "@proveedor";
                ParNombreproveedor.SqlDbType = SqlDbType.Int;
                ParNombreproveedor.Value = Ingreso.Idproveedor;
                SqlCmd.Parameters.Add(ParNombreproveedor);

                SqlParameter ParFechaingresodeposito = new SqlParameter();
                ParFechaingresodeposito.ParameterName = "@fechaingreso";
                ParFechaingresodeposito.SqlDbType = SqlDbType.Date;
                ParFechaingresodeposito.Value = Ingreso.Fechaingreso;
                SqlCmd.Parameters.Add(ParFechaingresodeposito);


                SqlParameter ParNroTalonario = new SqlParameter();
                ParNroTalonario.ParameterName = "@nrotalonario";
                ParNroTalonario.SqlDbType = SqlDbType.VarChar;
                ParNroTalonario.Size = 20;
                ParNroTalonario.Value = Ingreso.NroTalonario;
                SqlCmd.Parameters.Add(ParNroTalonario);


                SqlParameter ParComprobante = new SqlParameter();
                ParComprobante.ParameterName = "@comprobante";
                ParComprobante.SqlDbType = SqlDbType.VarChar;
                ParComprobante.Size = 20;
                ParComprobante.Value = Ingreso.Comprobante;
                SqlCmd.Parameters.Add(ParComprobante);

                SqlParameter ParNroComprobante = new SqlParameter();
                ParNroComprobante.ParameterName = "@nrocomprobante";
                ParNroComprobante.SqlDbType = SqlDbType.VarChar;
                ParNroComprobante.Size = 20;
                ParNroComprobante.Value = Ingreso.NroComprobante;
                SqlCmd.Parameters.Add(ParNroComprobante);               

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";



            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;

        }
        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_ingreso2";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        //Método Buscarfechas
        public DataTable BuscarFechas(String TextoBuscar, String TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_ingreso2_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 20;
                ParTextoBuscar2.Value = TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        public DataTable Buscar_por_nroRecibo(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_ingreso2_nrorecibro";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = TextoBuscar;
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
        public DataTable MostrarDetalle(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_detalle_ingreso2";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.Int;
                ParTextoBuscar.Value = TextoBuscar;
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
