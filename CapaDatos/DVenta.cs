using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DVenta
    {
        //Variables
        private int _Idventa;
        private int _Idcliente;
        private int _Idtrabajador;
        private DateTime _Fecha;
        private string _NroTalonario;
        private string _TipoComprobante;
        private string _Nrorecibo;
        private decimal _ImporteTotal;
        private decimal _AlContado;
        private decimal _ImporteContado;
        private decimal _SaldoXcobrar;
        private string _Estado;

        public int Idventa
        {
            get
            {
                return _Idventa;
            }

            set
            {
                _Idventa = value;
            }
        }

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

        public DateTime Fecha
        {
            get
            {
                return _Fecha;
            }

            set
            {
                _Fecha = value;
            }
        }

        public string Nrorecibo
        {
            get
            {
                return _Nrorecibo;
            }

            set
            {
                _Nrorecibo = value;
            }
        }

        public decimal ImporteTotal
        {
            get
            {
                return _ImporteTotal;
            }

            set
            {
                _ImporteTotal = value;
            }
        }

        public decimal ImporteContado
        {
            get
            {
                return _ImporteContado;
            }

            set
            {
                _ImporteContado = value;
            }
        }

        public decimal SaldoXcobrar
        {
            get
            {
                return _SaldoXcobrar;
            }

            set
            {
                _SaldoXcobrar = value;
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

        public decimal AlContado
        {
            get
            {
                return _AlContado;
            }

            set
            {
                _AlContado = value;
            }
        }

        public string TipoComprobante
        {
            get
            {
                return _TipoComprobante;
            }

            set
            {
                _TipoComprobante = value;
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



        //Constructores 
        public DVenta()
        {

        }
        public DVenta(int idventa, int idcliente,
            DateTime fecha,string nrotalonario,string tipocomprobante, string nrorecibo, decimal importetotal, decimal alcontado,
            decimal importecontado, decimal saldoxcobrar, string estado)
        {
            this.Idventa = idventa;
            this.Idcliente = idcliente;

            this.Fecha = fecha;
            this.NroTalonario = nrotalonario;
            this.TipoComprobante = tipocomprobante;
            this.Nrorecibo = nrorecibo;
            this.ImporteTotal = importetotal;
            this.AlContado = alcontado;
            this.ImporteContado = importecontado;
            this.SaldoXcobrar = saldoxcobrar;
            this.Estado = estado;

        }
        //Métodos

        //Métodos

        public string DisminuirStock(int iddetalle_ingreso, int cantidad)
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
                SqlCmd.CommandText = "pdisminuir_stock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Ingreso = new SqlParameter();
                ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Value = iddetalle_ingreso;
                SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizó el stock";


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

        public string Insertar(DVenta Venta, List<DDetalle_Venta> Detalle)
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
                SqlCmd.CommandText = "pinsertar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdTrabajador);


                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);



                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParNroTalonario = new SqlParameter();
                ParNroTalonario.ParameterName = "@nrotalonario";
                ParNroTalonario.SqlDbType = SqlDbType.VarChar;
                ParNroTalonario.Size = 20;
                ParNroTalonario.Value = Venta.NroTalonario;
                SqlCmd.Parameters.Add(ParNroTalonario);

                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipocomprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Venta.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParNrorecibo = new SqlParameter();
                ParNrorecibo.ParameterName = "@nrorecibo";
                ParNrorecibo.SqlDbType = SqlDbType.VarChar;
                ParNrorecibo.Size = 20;
                ParNrorecibo.Value = Venta.Nrorecibo;
                SqlCmd.Parameters.Add(ParNrorecibo);

                SqlParameter ParImportetotal = new SqlParameter();
                ParImportetotal.ParameterName = "@importetotal";
                ParImportetotal.SqlDbType = SqlDbType.Money;
                ParImportetotal.Value = Venta.ImporteTotal;
                SqlCmd.Parameters.Add(ParImportetotal);

                SqlParameter ParImportecontado = new SqlParameter();
                ParImportecontado.ParameterName = "@totalcontado";
                ParImportecontado.SqlDbType = SqlDbType.Money;
                ParImportecontado.Value = Venta.ImporteContado;
                SqlCmd.Parameters.Add(ParImportecontado);

                SqlParameter ParSaldoxcobrar = new SqlParameter();
                ParSaldoxcobrar.ParameterName = "@saldoporcobrar";
                ParSaldoxcobrar.SqlDbType = SqlDbType.Money;
                ParSaldoxcobrar.Value = Venta.SaldoXcobrar;
                SqlCmd.Parameters.Add(ParSaldoxcobrar);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Venta.Estado;
                SqlCmd.Parameters.Add(ParEstado);
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el código del ingreso generado
                    this.Idventa = Convert.ToInt32(SqlCmd.Parameters["@idventa"].Value);
                    foreach (DDetalle_Venta det in Detalle)
                    {
                        det.Idventa = this.Idventa;
                        //Llamar al método insertar de la clase DDetalle_Ingreso
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //Actualizamos el stock
                            rpta = DisminuirStock(det.Iddetalle_ingreso, det.Cantidad); //cambiar
                            if (!rpta.Equals("OK"))
                            {
                                break;
                            }
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

        //editar
        public string Editar(DVenta Ventas)//instanciar a la clase DCategoria2 y generamos es objeto categoria
        {
            string rpta = "";//respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;

                SqlCmd.CommandText = "peditar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Ventas.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Ventas.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);



                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ventas.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParNroTalonario = new SqlParameter();
                ParNroTalonario.ParameterName = "@nrotalonario";
                ParNroTalonario.SqlDbType = SqlDbType.VarChar;
                ParNroTalonario.Size = 20;
                ParNroTalonario.Value = Ventas.NroTalonario;
                SqlCmd.Parameters.Add(ParNroTalonario);

                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipocomprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Ventas.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParNrorecibo = new SqlParameter();
                ParNrorecibo.ParameterName = "@nrorecibo";
                ParNrorecibo.SqlDbType = SqlDbType.VarChar;
                ParNrorecibo.Size = 20;
                ParNrorecibo.Value = Ventas.Nrorecibo;
                SqlCmd.Parameters.Add(ParNrorecibo);
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
        public string Eliminar(DVenta Venta)
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
                SqlCmd.CommandText = "peliminar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);


                //Ejecutamos nuestro comando
                //cambiar
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "OK"; //cambiar


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
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_venta";
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
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_venta_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
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

        //buscar por cliente
        public DataTable Buscarcliente(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_venta_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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


        //buscar por nro recibo
        public DataTable BuscarNrorecibo(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_venta_nrorecibo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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
            DataTable DtResultado = new DataTable("Detalle_Venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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

        //Mostrar Artículos por su nombre
        public string RestablecerStock(int iddetalle_ingreso, int devoluciones)
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
                SqlCmd.CommandText = "paumentar_stock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Ingreso = new SqlParameter();
                ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Value = iddetalle_ingreso;
                SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = devoluciones;
                SqlCmd.Parameters.Add(ParCantidad);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizó el stock";


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
        public DataTable MostrarProducto_Venta_Nombre(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("producto1");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscarproducto_venta_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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

        public DataTable MostrarProducto_Venta_Nombre2(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("producto1");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscarproducto_venta_nombre2";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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

        public DataTable MostrarProducto_Venta_codigo(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("producto1");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscarproducto_venta_codigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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
        public DataTable BuscarDeudasVentaCliente(String TextoBuscar, String TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Ventas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_deudas_Venta_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
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
        
             public DataTable BuscarDeudasVentaClientePorRecibo(String TextoBuscar, String TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Ventas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_Detalle_Venta_X_NroRecibo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 50;
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
        public DataTable MostrarProducto_Venta(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("producto1");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscarproducto_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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
        
             public DataTable MostrarDetalleVentaPorIdVenta(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pMostrar_Detalle_Venta_X_IdVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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
        public DataTable MostrarDetalle_Ingreso_NombreProducto(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscardetalle_Ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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
        public string EditarVentaPorDetalle(DVenta VentaDetalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer la trasacción
                //SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                // SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "peditarVenta_por_Detalle";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdentrega = new SqlParameter();
                ParIdentrega.ParameterName = "@idventa";
                ParIdentrega.SqlDbType = SqlDbType.Int;
                ParIdentrega.Value = VentaDetalle.Idventa;
                SqlCmd.Parameters.Add(ParIdentrega);

                SqlParameter ParImportetotal = new SqlParameter();
                ParImportetotal.ParameterName = "@importetotal";
                ParImportetotal.SqlDbType = SqlDbType.Money;
                ParImportetotal.Value = VentaDetalle.ImporteTotal;
                SqlCmd.Parameters.Add(ParImportetotal);

                SqlParameter ParAlcontado = new SqlParameter();
                ParAlcontado.ParameterName = "@alcontado";
                ParAlcontado.SqlDbType = SqlDbType.Money;
                ParAlcontado.Value = VentaDetalle.AlContado;
                SqlCmd.Parameters.Add(ParAlcontado);

                SqlParameter ParImportecontado = new SqlParameter();
                ParImportecontado.ParameterName = "@totalcontado";
                ParImportecontado.SqlDbType = SqlDbType.Money;
                ParImportecontado.Value = VentaDetalle.ImporteContado;
                SqlCmd.Parameters.Add(ParImportecontado);

                SqlParameter ParSaldoxcobrar = new SqlParameter();
                ParSaldoxcobrar.ParameterName = "@saldoporcobrar";
                ParSaldoxcobrar.SqlDbType = SqlDbType.Money;
                ParSaldoxcobrar.Value = VentaDetalle.SaldoXcobrar;
                SqlCmd.Parameters.Add(ParSaldoxcobrar);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = VentaDetalle.Estado;
                SqlCmd.Parameters.Add(ParEstado);


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
    }
}
