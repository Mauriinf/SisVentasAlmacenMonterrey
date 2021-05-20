using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDatos
{
    public class DDetalle_Venta
    {
        private int _Iddetalle_venta;
        private int _Idventa;
        private int _Iddetalle_ingreso;
        private int _Cantidad;
        private int _Dovoluciones;
        private decimal _Precio;
        private decimal _ImporteTotal;
        private decimal _AlContado;
        private decimal _TotalContado;
        private decimal _SaldoXcobrar;
        private decimal _Rebaja;
        private decimal _RebajaInicial;
        private string _Estado;

        public int Iddetalle_venta
        {
            get
            {
                return _Iddetalle_venta;
            }

            set
            {
                _Iddetalle_venta = value;
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

        public int Iddetalle_ingreso
        {
            get
            {
                return _Iddetalle_ingreso;
            }

            set
            {
                _Iddetalle_ingreso = value;
            }
        }

        public int Dovoluciones
        {
            get
            {
                return _Dovoluciones;
            }

            set
            {
                _Dovoluciones = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return _Cantidad;
            }

            set
            {
                _Cantidad = value;
            }
        }

        public decimal Precio
        {
            get
            {
                return _Precio;
            }

            set
            {
                _Precio = value;
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

        public decimal TotalContado
        {
            get
            {
                return _TotalContado;
            }

            set
            {
                _TotalContado = value;
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

        public decimal RebajaInicial
        {
            get
            {
                return _RebajaInicial;
            }

            set
            {
                _RebajaInicial = value;
            }
        }

        //Constructores
        public DDetalle_Venta()
        {

        }

        public DDetalle_Venta(int iddetalle_venta, int idventa, int iddetalle_ingreso,
            int cantidad, int devoluciones, decimal precio, decimal importetotal, decimal alcontado,
            decimal totalcontado, decimal saldoporcobrar, decimal rebaja,decimal rebajaini, string estado)
        {
            this.Iddetalle_venta = iddetalle_venta;
            this.Idventa = idventa;
            this.Iddetalle_ingreso = iddetalle_ingreso;
            this.Cantidad = cantidad;
            this.Dovoluciones = devoluciones;
            this.Precio = precio;
            this.ImporteTotal = importetotal;
            this.AlContado = alcontado;
            this.TotalContado = totalcontado;
            this.SaldoXcobrar = saldoporcobrar;
            this.Rebaja = rebaja;
            this.RebajaInicial = rebajaini;
            this.Estado = estado;

        }
                //Método Insertar
        public string Insertar(DDetalle_Venta Detalle_venta,
           ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "pinsertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_venta = new SqlParameter();
                ParIddetalle_venta.ParameterName = "@iddetalle_venta";
                ParIddetalle_venta.SqlDbType = SqlDbType.Int;
                ParIddetalle_venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_venta);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = Detalle_venta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);



                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Value = Detalle_venta.Iddetalle_ingreso;
                SqlCmd.Parameters.Add(ParIddetalle_ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = Detalle_venta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParDevoluciones = new SqlParameter();
                ParDevoluciones.ParameterName = "@devoluciones";
                ParDevoluciones.SqlDbType = SqlDbType.Int;
                ParDevoluciones.Value = Detalle_venta.Dovoluciones;
                SqlCmd.Parameters.Add(ParDevoluciones);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = Detalle_venta.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParImporteTotal = new SqlParameter();
                ParImporteTotal.ParameterName = "@importetotal";
                ParImporteTotal.SqlDbType = SqlDbType.Money;
                ParImporteTotal.Value = Detalle_venta.ImporteTotal;
                SqlCmd.Parameters.Add(ParImporteTotal);


                SqlParameter ParTotalcontado = new SqlParameter();
                ParTotalcontado.ParameterName = "@totalcontado";
                ParTotalcontado.SqlDbType = SqlDbType.Money;
                ParTotalcontado.Value = Detalle_venta.TotalContado;
                SqlCmd.Parameters.Add(ParTotalcontado);


                SqlParameter ParSaldoxCobrar = new SqlParameter();
                ParSaldoxCobrar.ParameterName = "@saldoporcobrar";
                ParSaldoxCobrar.SqlDbType = SqlDbType.Money;
                ParSaldoxCobrar.Value = Detalle_venta.SaldoXcobrar;
                SqlCmd.Parameters.Add(ParSaldoxCobrar);

                SqlParameter ParRebaja = new SqlParameter();
                ParRebaja.ParameterName = "@rebaja";
                ParRebaja.SqlDbType = SqlDbType.Money;
                ParRebaja.Value = Detalle_venta.Rebaja;
                SqlCmd.Parameters.Add(ParRebaja);


                SqlParameter ParRebajaIni = new SqlParameter();
                ParRebajaIni.ParameterName = "@rebajaini";
                ParRebajaIni.SqlDbType = SqlDbType.Money;
                ParRebajaIni.Value = Detalle_venta.RebajaInicial;
                SqlCmd.Parameters.Add(ParRebajaIni);


                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Detalle_venta.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }


        //Método Editar
        public string Editar(DDetalle_Venta DetalleVenta)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peditar_detalle_venta";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIddetalleVenta = new SqlParameter();
                ParIddetalleVenta.ParameterName = "@iddetalle_venta";//variable de procedimieto almacenado
                ParIddetalleVenta.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIddetalleVenta.Value = DetalleVenta.Iddetalle_venta;
                SqlCmd.Parameters.Add(ParIddetalleVenta);//agregar este parametro a nuestro comando

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idventa";//variable de procedimieto almacenado
                ParIdVenta.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdVenta.Value = DetalleVenta.Idventa;
                SqlCmd.Parameters.Add(ParIdVenta);//agregar este parametro a nuestro comando

                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@iddetalle_ingreso";//variable de procedimieto almacenado
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdDetalleIngreso.Value = DetalleVenta.Iddetalle_ingreso;
                SqlCmd.Parameters.Add(ParIdDetalleIngreso);//agregar este parametro a nuestro comando

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";//variable de procedimieto almacenado
                ParCantidad.SqlDbType = SqlDbType.Int;//tipo de dat             
                ParCantidad.Value = DetalleVenta.Cantidad;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParCantidad);


                SqlParameter ParDevoluciones = new SqlParameter();
                ParDevoluciones.ParameterName = "@devoluciones";//variable de procedimieto almacenado
                ParDevoluciones.SqlDbType = SqlDbType.Int;//tipo de dat             
                ParDevoluciones.Value = DetalleVenta.Dovoluciones;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParDevoluciones);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";//variable de procedimieto almacenado
                ParPrecio.SqlDbType = SqlDbType.Money;//tipo de dat             
                ParPrecio.Value = DetalleVenta.Precio;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParImporteTotal = new SqlParameter();
                ParImporteTotal.ParameterName = "@importetotal";//variable de procedimieto almacenado
                ParImporteTotal.SqlDbType = SqlDbType.Money;//tipo de dat             
                ParImporteTotal.Value = DetalleVenta.ImporteTotal;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParImporteTotal);

                SqlParameter ParAlContado = new SqlParameter();
                ParAlContado.ParameterName = "@alcontado";//variable de procedimieto almacenado
                ParAlContado.SqlDbType = SqlDbType.Money;//tipo de dat             
                ParAlContado.Value = DetalleVenta.AlContado;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParAlContado);

                SqlParameter ParTotalContado = new SqlParameter();
                ParTotalContado.ParameterName = "@totalcontado";//variable de procedimieto almacenado
                ParTotalContado.SqlDbType = SqlDbType.Money;//tipo de dat             
                ParTotalContado.Value = DetalleVenta.TotalContado;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParTotalContado);

                SqlParameter ParSaldoPorCobrar = new SqlParameter();
                ParSaldoPorCobrar.ParameterName = "@saldoporcobrar";//variable de procedimieto almacenado
                ParSaldoPorCobrar.SqlDbType = SqlDbType.Money;//tipo de dat             
                ParSaldoPorCobrar.Value = DetalleVenta.SaldoXcobrar;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParSaldoPorCobrar);

                SqlParameter ParRebaja = new SqlParameter();
                ParRebaja.ParameterName = "@rebaja";//variable de procedimieto almacenado
                ParRebaja.SqlDbType = SqlDbType.Money;//tipo de dat             
                ParRebaja.Value = DetalleVenta.Rebaja;//enviar un valor a este parametro
                SqlCmd.Parameters.Add(ParRebaja);

                SqlParameter ParRebajaIni = new SqlParameter();
                ParRebajaIni.ParameterName = "@rebajaini";
                ParRebajaIni.SqlDbType = SqlDbType.Money;
                ParRebajaIni.Value = DetalleVenta.RebajaInicial;
                SqlCmd.Parameters.Add(ParRebajaIni);


                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = DetalleVenta.Estado;
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
        public string Eliminar(DDetalle_Venta Detalle)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peliminar_detalle_venta";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdDetalle = new SqlParameter();
                ParIdDetalle.ParameterName = "@iddetalle";//variable de procedimieto almacenado
                ParIdDetalle.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdDetalle.Value = Detalle.Iddetalle_venta;
                SqlCmd.Parameters.Add(ParIdDetalle);//agregar este parametro a nuestro comando




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
