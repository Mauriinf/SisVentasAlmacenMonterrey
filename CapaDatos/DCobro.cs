using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DCobro
    {
        //Variables
        private int _Idcobro;
        private int _Idtrabajador;
        private int _Idventa;
        private int _NroTalonario;
        private string _TipoComprobante;
        private string _Nrorecibo;
        private DateTime _Fecha;
        private decimal _Deudaanterior;
        private decimal _Pago;
        private decimal _Deudapendiente;
        private decimal _Rebaja;

        public int Idcobro
        {
            get
            {
                return _Idcobro;
            }

            set
            {
                _Idcobro = value;
            }
        }

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

        public decimal Deudaanterior
        {
            get
            {
                return _Deudaanterior;
            }

            set
            {
                _Deudaanterior = value;
            }
        }

        public decimal Pago
        {
            get
            {
                return _Pago;
            }

            set
            {
                _Pago = value;
            }
        }

        public decimal Deudapendiente
        {
            get
            {
                return _Deudapendiente;
            }

            set
            {
                _Deudapendiente = value;
            }
        }

        public decimal Rebaja
        {
            get
            {
                return _Rebaja;
            }

            set
            {
                _Rebaja = value;
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

        public int NroTalonario
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

        public DCobro()
        {

        }
        public DCobro(int idcobro, int idventa,int idtrabajador,
            int nrotalonario,string tipocomprobante,string nrorecibo, DateTime fecha, decimal deudaanterior,
            decimal pago, decimal deudapendiente, decimal rebaja)
        {
            this.Idventa = idventa;
            this.Idcobro = idcobro;
            this.Idtrabajador = idtrabajador;
            this.Fecha = fecha;
            this.NroTalonario = nrotalonario;
            this.TipoComprobante = tipocomprobante;
            this.Nrorecibo = nrorecibo;
            this.Deudaanterior = deudaanterior;
            this.Pago = pago;
            this.Deudapendiente = deudapendiente;
            this.Rebaja = rebaja;

        }
        //insertar
        //Método Insertar
        public string Insertar(DCobro Cobro)
        {
            string rpta = "";//respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {

                SqlCon.ConnectionString = conexion.Cn;//conexio base de datos
                SqlCon.Open();//abrir la conexion

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pinsertar_cobros";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcobro = new SqlParameter();
                ParIdcobro.ParameterName = "@idcobro";
                ParIdcobro.SqlDbType = SqlDbType.Int;
                ParIdcobro.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcobro);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Cobro.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);
            

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Cobro.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParNroTalonario = new SqlParameter();
                ParNroTalonario.ParameterName = "@nrotalonario";
                ParNroTalonario.SqlDbType = SqlDbType.Int;
                ParNroTalonario.Value = Cobro.NroTalonario;
                SqlCmd.Parameters.Add(ParNroTalonario);

                SqlParameter ParTipoComprobante= new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipocomprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Cobro.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParNrorecibo = new SqlParameter();
                ParNrorecibo.ParameterName = "@nrorecibo";
                ParNrorecibo.SqlDbType = SqlDbType.VarChar;
                ParNrorecibo.Size = 20;
                ParNrorecibo.Value = Cobro.Nrorecibo;
                SqlCmd.Parameters.Add(ParNrorecibo);


                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Cobro.Fecha;
                SqlCmd.Parameters.Add(ParFecha);



                SqlParameter ParDeudaanterior = new SqlParameter();
                ParDeudaanterior.ParameterName = "@deudaanterior";
                ParDeudaanterior.SqlDbType = SqlDbType.Money;
                ParDeudaanterior.Value = Cobro.Deudaanterior;
                SqlCmd.Parameters.Add(ParDeudaanterior);

                SqlParameter ParPago = new SqlParameter();
                ParPago.ParameterName = "@pago";
                ParPago.SqlDbType = SqlDbType.Money;
                ParPago.Value = Cobro.Pago;
                SqlCmd.Parameters.Add(ParPago);


                SqlParameter ParDeudapendiente = new SqlParameter();
                ParDeudapendiente.ParameterName = "@deudapendiente";
                ParDeudapendiente.SqlDbType = SqlDbType.Money;
                ParDeudapendiente.Value = Cobro.Deudapendiente;
                SqlCmd.Parameters.Add(ParDeudapendiente);


                SqlParameter ParRebaja = new SqlParameter();
                ParRebaja.ParameterName = "@rebaja";
                ParRebaja.SqlDbType = SqlDbType.Money;
                ParRebaja.Value = Cobro.Rebaja;
                SqlCmd.Parameters.Add(ParRebaja);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally//cerrar la cade na conexion
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();//si la coneion esta abierta entonces cerrarlo
            }
            return rpta;

        }

        //Método Editar
        public string Editar(DCobro Cobro)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peditar_cobro";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdCobro = new SqlParameter();
                ParIdCobro.ParameterName = "@idcobro";//variable de procedimieto almacenado
                ParIdCobro.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdCobro.Value = Cobro.Idcobro;
                SqlCmd.Parameters.Add(ParIdCobro);//agregar este parametro a nuestro comando

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idventa";//variable de procedimieto almacenado
                ParIdVenta.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdVenta.Value = Cobro.Idventa;
                SqlCmd.Parameters.Add(ParIdVenta);//agregar este parametro a nuestro comando

                SqlParameter ParNroTalonario = new SqlParameter();
                ParNroTalonario.ParameterName = "@nrotalonario";
                ParNroTalonario.SqlDbType = SqlDbType.Int;
                ParNroTalonario.Value = Cobro.NroTalonario;
                SqlCmd.Parameters.Add(ParNroTalonario);

                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipocomprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Cobro.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParNrorecibo = new SqlParameter();
                ParNrorecibo.ParameterName = "@nrorecibo";
                ParNrorecibo.SqlDbType = SqlDbType.VarChar;
                ParNrorecibo.Size = 20;
                ParNrorecibo.Value = Cobro.Nrorecibo;
                SqlCmd.Parameters.Add(ParNrorecibo);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Cobro.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParDeudaanterior = new SqlParameter();
                ParDeudaanterior.ParameterName = "@deudaanterior";//variable de procedimieto almacenado
                ParDeudaanterior.SqlDbType = SqlDbType.Money;//tipo de dat             
                ParDeudaanterior.Value = Cobro.Deudaanterior;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParDeudaanterior);


                SqlParameter ParPago = new SqlParameter();
                ParPago.ParameterName = "@pago";
                ParPago.SqlDbType = SqlDbType.Money;
                ParPago.Value = Cobro.Pago;
                SqlCmd.Parameters.Add(ParPago);


                SqlParameter ParDeudapendiente = new SqlParameter();
                ParDeudapendiente.ParameterName = "@deudapendiente";
                ParDeudapendiente.SqlDbType = SqlDbType.Money;
                ParDeudapendiente.Value = Cobro.Deudapendiente;
                SqlCmd.Parameters.Add(ParDeudapendiente);


                SqlParameter ParRebaja = new SqlParameter();
                ParRebaja.ParameterName = "@rebaja";
                ParRebaja.SqlDbType = SqlDbType.Money;
                ParRebaja.Value = Cobro.Rebaja;
                SqlCmd.Parameters.Add(ParRebaja);



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
        //Métodos
        public string Actualizar_detalle_venta(int idventa, decimal pag, decimal reb)
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
                SqlCmd.CommandText = "pactualizar_detalle_venta_al_realizar_cobro";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParPago = new SqlParameter();
                ParPago.ParameterName = "@monto";
                ParPago.SqlDbType = SqlDbType.Money;
                ParPago.Value = pag;
                SqlCmd.Parameters.Add(ParPago);

                SqlParameter ParRebaja = new SqlParameter();
                ParRebaja.ParameterName = "@reb";
                ParRebaja.SqlDbType = SqlDbType.Money;
                ParRebaja.Value = reb;
                SqlCmd.Parameters.Add(ParRebaja);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO se Actualizó el stock";


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
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Cobros");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_cobro";
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

        public DataTable Mostrar_Cobro_Por_IdVenta(int idcobro)
        {
            DataTable DtResultado = new DataTable("Cobros");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pmostrar_cobros_IdVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcobro = new SqlParameter();
                ParIdcobro.ParameterName = "@textobuscar";
                ParIdcobro.SqlDbType = SqlDbType.Int;
                ParIdcobro.Value = idcobro;
                SqlCmd.Parameters.Add(ParIdcobro);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;

        }


        public string ActualizarCobros_por_detalle_venta(int idcobro, decimal deudaanterior, decimal deudapendiente)
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
                SqlCmd.CommandText = "peditarCobro_al_EditarDetalleVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcobro = new SqlParameter();
                ParIdcobro.ParameterName = "@idcobro";
                ParIdcobro.SqlDbType = SqlDbType.Int;
                ParIdcobro.Value = idcobro;
                SqlCmd.Parameters.Add(ParIdcobro);

                SqlParameter Pardeudaanterior = new SqlParameter();
                Pardeudaanterior.ParameterName = "@deudaanterior";
                Pardeudaanterior.SqlDbType = SqlDbType.Money;
                Pardeudaanterior.Value = deudaanterior;
                SqlCmd.Parameters.Add(Pardeudaanterior);

                SqlParameter Pardeudapendiente = new SqlParameter();
                Pardeudapendiente.ParameterName = "@deudapendiente";
                Pardeudapendiente.SqlDbType = SqlDbType.Money;
                Pardeudapendiente.Value = deudapendiente;
                SqlCmd.Parameters.Add(Pardeudapendiente);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO se Actualizó el stock";


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
        public DataTable Buscarcliente(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Cobros");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_cobros_cliente";
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

        public string Actualizar_Venta_al_EliminarCobro(int idventa, decimal pag, decimal reb)
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
                SqlCmd.CommandText = "peditar_venta_por_eliminarCobro";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParPago = new SqlParameter();
                ParPago.ParameterName = "@monto";
                ParPago.SqlDbType = SqlDbType.Money;
                ParPago.Value = pag;
                SqlCmd.Parameters.Add(ParPago);

                SqlParameter ParRebaja = new SqlParameter();
                ParRebaja.ParameterName = "@rebaja";
                ParRebaja.SqlDbType = SqlDbType.Money;
                ParRebaja.Value = reb;
                SqlCmd.Parameters.Add(ParRebaja);


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

        public string ActualizarDetalle_Venta_al_EliminarCobro(int idventa, decimal pag, decimal reb)
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
                SqlCmd.CommandText = "pactualizar_detalle_venta_al_eliminar_cobro";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParPago = new SqlParameter();
                ParPago.ParameterName = "@monto";
                ParPago.SqlDbType = SqlDbType.Money;
                ParPago.Value = pag;
                SqlCmd.Parameters.Add(ParPago);

                SqlParameter ParRebaja = new SqlParameter();
                ParRebaja.ParameterName = "@reb";
                ParRebaja.SqlDbType = SqlDbType.Money;
                ParRebaja.Value = reb;
                SqlCmd.Parameters.Add(ParRebaja);


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
        public DataTable BuscarNrorecibo(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Cobros");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_cobros_nrorecibro";

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


        public DataTable MostrarCliente_Cobro_Nombre(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("clientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscarcliente_cobro_nombre";
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
        public DataTable MostrarCliente_Cobro_Nombre2()
        {
            DataTable DtResultado = new DataTable("clientes");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscarcliente_cobro_nombre2";
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
        public string Eliminar(DCobro Cobro)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peliminar_cobro";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdccobro = new SqlParameter();
                ParIdccobro.ParameterName = "@idcobro";//variable de procedimieto almacenado
                ParIdccobro.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdccobro.Value = Cobro.Idcobro;
                SqlCmd.Parameters.Add(ParIdccobro);//agregar este parametro a nuestro comando




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
    }
}
