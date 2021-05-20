using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DIngreso
    {
        //Variables
        private int _Idingreso;
        private int _Idconductor;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fechasalida;
        private DateTime _Fechaingresodeposito;
        private string _NroTalonario;
        private string _Comprobante;
        private string _NroComprobante;


        private string _Destino;
        private string _Descargo;
        private decimal _Fleteunitario;
        private decimal _Fletetotal;
        private decimal _Fletecontado;
        private decimal _Fleteporpagar;
        private decimal _Carguiounitario;
        private decimal _CarguioTotal;
        private decimal _CarguioContado;
        private decimal _Carguioporpagar;
        private decimal _Totalfletemascarguio;
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

       
        public DateTime Fechasalida
        {
            get
            {
                return _Fechasalida;
            }

            set
            {
                _Fechasalida = value;
            }
        }

        public DateTime Fechaingresodeposito
        {
            get
            {
                return _Fechaingresodeposito;
            }

            set
            {
                _Fechaingresodeposito = value;
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

        public string Destino
        {
            get
            {
                return _Destino;
            }

            set
            {
                _Destino = value;
            }
        }

        public string Descargo
        {
            get
            {
                return _Descargo;
            }

            set
            {
                _Descargo = value;
            }
        }


        public decimal Fleteunitario
        {
            get
            {
                return _Fleteunitario;
            }

            set
            {
                _Fleteunitario = value;
            }
        }

        public decimal Fletetotal
        {
            get
            {
                return _Fletetotal;
            }

            set
            {
                _Fletetotal = value;
            }
        }

        public decimal Fletecontado
        {
            get
            {
                return _Fletecontado;
            }

            set
            {
                _Fletecontado = value;
            }
        }

        public decimal Fleteporpagar
        {
            get
            {
                return _Fleteporpagar;
            }

            set
            {
                _Fleteporpagar = value;
            }
        }

        public decimal Carguiounitario
        {
            get
            {
                return _Carguiounitario;
            }

            set
            {
                _Carguiounitario = value;
            }
        }

        public decimal CarguioTotal
        {
            get
            {
                return _CarguioTotal;
            }

            set
            {
                _CarguioTotal = value;
            }
        }

        public decimal Totalfletemascarguio
        {
            get
            {
                return _Totalfletemascarguio;
            }

            set
            {
                _Totalfletemascarguio = value;
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

        public decimal Carguioporpagar
        {
            get
            {
                return _Carguioporpagar;
            }

            set
            {
                _Carguioporpagar = value;
            }
        }

        public decimal CarguioContado
        {
            get
            {
                return _CarguioContado;
            }

            set
            {
                _CarguioContado = value;
            }
        }

        

        public string NroTalonario1
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

        public DIngreso()
        {

        }

        public DIngreso(int idingreso, int idconductor,int idtrabajador, int Idproveedor,
            DateTime fechasalida, DateTime fechaingresodeposito,string nrotalonario, string comprobante, string nrocomprobante, string destino, string descargo,
            decimal fleteunitario, decimal fletetotal, decimal fletecontado, decimal fleteporcancelar, decimal carguiounitario,
            decimal carguiototal,decimal carguiocontado,decimal carguioporpagar, decimal totalfletemascarguio, string estado)
        {
            this.Idingreso = idingreso;
            this.Idconductor = idconductor;
            this.Idtrabajador = idtrabajador;
            this.Idproveedor = Idproveedor;
            this.Fechasalida = fechasalida;
            this.Fechaingresodeposito = fechaingresodeposito;
            this.NroTalonario1 = nrotalonario;
            this.Comprobante = comprobante;
            this.NroComprobante = nrocomprobante;
            this.Destino = destino;
            this.Descargo = descargo;
            this.CarguioContado = carguiocontado;
            this.Fleteunitario = fleteunitario;
            this.Fletetotal = fletetotal;
            this.Fletecontado = fletecontado;
            this.Fleteporpagar = fleteporcancelar;
            this.Carguiounitario = carguiounitario;
            this.CarguioTotal = carguiototal;
            this.CarguioContado = carguiocontado;
            this.Carguioporpagar = carguioporpagar;
            this.Totalfletemascarguio = totalfletemascarguio;
            this.Estado = estado;
        }
        //Métodos
        public string Insertar(DIngreso Ingreso, List<DDetalle_ingreso> Detalle)
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
                SqlCmd.CommandText = "pinsertar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdentrega = new SqlParameter();
                ParIdentrega.ParameterName = "@idingreso";
                ParIdentrega.SqlDbType = SqlDbType.Int;
                ParIdentrega.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdentrega);


                SqlParameter ParIdconductor = new SqlParameter();
                ParIdconductor.ParameterName = "@idconductor";
                ParIdconductor.SqlDbType = SqlDbType.Int;
                ParIdconductor.Value = Ingreso.Idconductor;
                SqlCmd.Parameters.Add(ParIdconductor);

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


                SqlParameter ParFechasalida = new SqlParameter();
                ParFechasalida.ParameterName = "@fechasalida";
                ParFechasalida.SqlDbType = SqlDbType.Date;
                ParFechasalida.Value = Ingreso.Fechasalida;
                SqlCmd.Parameters.Add(ParFechasalida);

                SqlParameter ParFechaingresodeposito = new SqlParameter();
                ParFechaingresodeposito.ParameterName = "@fechaingreso";
                ParFechaingresodeposito.SqlDbType = SqlDbType.Date;
                ParFechaingresodeposito.Value = Ingreso.Fechaingresodeposito;
                SqlCmd.Parameters.Add(ParFechaingresodeposito);

                SqlParameter ParNroTalonario = new SqlParameter();
                ParNroTalonario.ParameterName = "@nrotalonario";
                ParNroTalonario.SqlDbType = SqlDbType.VarChar;
                ParNroTalonario.Size = 20;
                ParNroTalonario.Value = Ingreso.NroTalonario1;
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





                SqlParameter ParDestino = new SqlParameter();
                ParDestino.ParameterName = "@destino";
                ParDestino.SqlDbType = SqlDbType.VarChar;
                ParDestino.Size = 20;
                ParDestino.Value = Ingreso.Destino;
                SqlCmd.Parameters.Add(ParDestino);

                SqlParameter ParDescargo = new SqlParameter();
                ParDescargo.ParameterName = "@descargo";
                ParDescargo.SqlDbType = SqlDbType.VarChar;
                ParDescargo.Size = 20;
                ParDescargo.Value = Ingreso.Descargo;
                SqlCmd.Parameters.Add(ParDescargo);

                
                SqlParameter ParFleteunitario = new SqlParameter();
                ParFleteunitario.ParameterName = "@fleteunitario";
                ParFleteunitario.SqlDbType = SqlDbType.Money;
                ParFleteunitario.Value = Ingreso.Fleteunitario;
                SqlCmd.Parameters.Add(ParFleteunitario);

                SqlParameter ParFletetotal = new SqlParameter();
                ParFletetotal.ParameterName = "@fletetotal";
                ParFletetotal.SqlDbType = SqlDbType.Money;
                ParFletetotal.Value = Ingreso.Fletetotal;
                SqlCmd.Parameters.Add(ParFletetotal);

                SqlParameter ParFletecontado = new SqlParameter();
                ParFletecontado.ParameterName = "@fletecontado";
                ParFletecontado.SqlDbType = SqlDbType.Money;
                ParFletecontado.Value = Ingreso.Fletecontado;
                SqlCmd.Parameters.Add(ParFletecontado);

                SqlParameter ParFleteporcancelar = new SqlParameter();
                ParFleteporcancelar.ParameterName = "@fletexpagar";
                ParFleteporcancelar.SqlDbType = SqlDbType.Money;
                ParFleteporcancelar.Value = Ingreso.Fleteporpagar;
                SqlCmd.Parameters.Add(ParFleteporcancelar);

                SqlParameter ParCarguiounitario = new SqlParameter();
                ParCarguiounitario.ParameterName = "@carguiounitario";
                ParCarguiounitario.SqlDbType = SqlDbType.Money;
                ParCarguiounitario.Value = Ingreso.Carguiounitario;
                SqlCmd.Parameters.Add(ParCarguiounitario);

                SqlParameter ParCarguiototal = new SqlParameter();
                ParCarguiototal.ParameterName = "@carguiototal";
                ParCarguiototal.SqlDbType = SqlDbType.Money;
                ParCarguiototal.Value = Ingreso.CarguioTotal;
                SqlCmd.Parameters.Add(ParCarguiototal);

                SqlParameter ParCarguioContado = new SqlParameter();
                ParCarguioContado.ParameterName = "@carguiocontado";
                ParCarguioContado.SqlDbType = SqlDbType.Money;
                ParCarguioContado.Value = Ingreso.CarguioContado;
                SqlCmd.Parameters.Add(ParCarguioContado);


                SqlParameter ParCarguioporpagar = new SqlParameter();
                ParCarguioporpagar.ParameterName = "@carguioxpagar";
                ParCarguioporpagar.SqlDbType = SqlDbType.Money;
                ParCarguioporpagar.Value = Ingreso.CarguioTotal;
                SqlCmd.Parameters.Add(ParCarguioporpagar);

                SqlParameter ParTotalfletemascarguio = new SqlParameter();
                ParTotalfletemascarguio.ParameterName = "@total";
                ParTotalfletemascarguio.SqlDbType = SqlDbType.Money;
                ParTotalfletemascarguio.Value = Ingreso.Totalfletemascarguio;
                SqlCmd.Parameters.Add(ParTotalfletemascarguio);



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
                    foreach (DDetalle_ingreso det in Detalle)
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
        public string Editar(DIngreso Ingreso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer la trasacción
                
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
             
                SqlCmd.CommandText = "peditar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdentrega = new SqlParameter();
                ParIdentrega.ParameterName = "@idingreso";
                ParIdentrega.SqlDbType = SqlDbType.Int;
                ParIdentrega.Value = Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdentrega);


                SqlParameter ParIdconductor = new SqlParameter();
                ParIdconductor.ParameterName = "@idconductor";
                ParIdconductor.SqlDbType = SqlDbType.Int;
                ParIdconductor.Value = Ingreso.Idconductor;
                SqlCmd.Parameters.Add(ParIdconductor);

                

                SqlParameter ParNombreproveedor = new SqlParameter();
                ParNombreproveedor.ParameterName = "@proveedor";
                ParNombreproveedor.SqlDbType = SqlDbType.Int;
               
                ParNombreproveedor.Value = Ingreso.Idproveedor;
                SqlCmd.Parameters.Add(ParNombreproveedor);


                SqlParameter ParFechasalida = new SqlParameter();
                ParFechasalida.ParameterName = "@fechasalida";
                ParFechasalida.SqlDbType = SqlDbType.Date;
                ParFechasalida.Value = Ingreso.Fechasalida;
                SqlCmd.Parameters.Add(ParFechasalida);

                SqlParameter ParFechaingresodeposito = new SqlParameter();
                ParFechaingresodeposito.ParameterName = "@fechaingreso";
                ParFechaingresodeposito.SqlDbType = SqlDbType.Date;
                ParFechaingresodeposito.Value = Ingreso.Fechaingresodeposito;
                SqlCmd.Parameters.Add(ParFechaingresodeposito);

                SqlParameter ParNroTalonario = new SqlParameter();
                ParNroTalonario.ParameterName = "@nrotalonario";
                ParNroTalonario.SqlDbType = SqlDbType.VarChar;
                ParNroTalonario.Size = 20;
                ParNroTalonario.Value = Ingreso.NroTalonario1;
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





                SqlParameter ParDestino = new SqlParameter();
                ParDestino.ParameterName = "@destino";
                ParDestino.SqlDbType = SqlDbType.VarChar;
                ParDestino.Size = 20;
                ParDestino.Value = Ingreso.Destino;
                SqlCmd.Parameters.Add(ParDestino);

                SqlParameter ParDescargo = new SqlParameter();
                ParDescargo.ParameterName = "@descargo";
                ParDescargo.SqlDbType = SqlDbType.VarChar;
                ParDescargo.Size = 20;
                ParDescargo.Value = Ingreso.Descargo;
                SqlCmd.Parameters.Add(ParDescargo);


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
        public string EditarIngresoPorDetalle(DIngreso IngresoDetalle)
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
                SqlCmd.CommandText = "peditar_ingreso_por_detalle";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdentrega = new SqlParameter();
                ParIdentrega.ParameterName = "@idingreso";
                ParIdentrega.SqlDbType = SqlDbType.Int;
                ParIdentrega.Value = IngresoDetalle.Idingreso;
                SqlCmd.Parameters.Add(ParIdentrega);

              
                SqlParameter ParFleteunitario = new SqlParameter();
                ParFleteunitario.ParameterName = "@fleteunitario";
                ParFleteunitario.SqlDbType = SqlDbType.Money;
                ParFleteunitario.Value = IngresoDetalle.Fleteunitario;
                SqlCmd.Parameters.Add(ParFleteunitario);

                SqlParameter ParFletetotal = new SqlParameter();
                ParFletetotal.ParameterName = "@fletetotal";
                ParFletetotal.SqlDbType = SqlDbType.Money;
                ParFletetotal.Value = IngresoDetalle.Fletetotal;
                SqlCmd.Parameters.Add(ParFletetotal);

                SqlParameter ParFletecontado = new SqlParameter();
                ParFletecontado.ParameterName = "@fletecontado";
                ParFletecontado.SqlDbType = SqlDbType.Money;
                ParFletecontado.Value = IngresoDetalle.Fletecontado;
                SqlCmd.Parameters.Add(ParFletecontado);

                SqlParameter ParFleteporcancelar = new SqlParameter();
                ParFleteporcancelar.ParameterName = "@fletexpagar";
                ParFleteporcancelar.SqlDbType = SqlDbType.Money;
                ParFleteporcancelar.Value = IngresoDetalle.Fleteporpagar;
                SqlCmd.Parameters.Add(ParFleteporcancelar);

                SqlParameter ParCarguiounitario = new SqlParameter();
                ParCarguiounitario.ParameterName = "@carguiounitario";
                ParCarguiounitario.SqlDbType = SqlDbType.Money;
                ParCarguiounitario.Value = IngresoDetalle.Carguiounitario;
                SqlCmd.Parameters.Add(ParCarguiounitario);

                SqlParameter ParCarguiototal = new SqlParameter();
                ParCarguiototal.ParameterName = "@carguiototal";
                ParCarguiototal.SqlDbType = SqlDbType.Money;
                ParCarguiototal.Value = IngresoDetalle.CarguioTotal;
                SqlCmd.Parameters.Add(ParCarguiototal);

                SqlParameter ParCarguioContado = new SqlParameter();
                ParCarguioContado.ParameterName = "@carguiocontado";
                ParCarguioContado.SqlDbType = SqlDbType.Money;
                ParCarguioContado.Value = IngresoDetalle.CarguioContado;
                SqlCmd.Parameters.Add(ParCarguioContado);


                SqlParameter ParCarguioporpagar = new SqlParameter();
                ParCarguioporpagar.ParameterName = "@carguioxpagar";
                ParCarguioporpagar.SqlDbType = SqlDbType.Money;
                ParCarguioporpagar.Value = IngresoDetalle.CarguioTotal;
                SqlCmd.Parameters.Add(ParCarguioporpagar);

                SqlParameter ParTotalfletemascarguio = new SqlParameter();
                ParTotalfletemascarguio.ParameterName = "@total";
                ParTotalfletemascarguio.SqlDbType = SqlDbType.Money;
                ParTotalfletemascarguio.Value = IngresoDetalle.Totalfletemascarguio;
                SqlCmd.Parameters.Add(ParTotalfletemascarguio);



                

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
        public string Anular(DIngreso Ingreso)
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
                SqlCmd.CommandText = "panular_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se anulo el Registro";


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
                SqlCmd.CommandText = "pmostrar_ingreso";
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
                SqlCmd.CommandText = "pbuscar_ingreso_fecha";
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
        public DataTable BuscarPorNroRecibo(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "pbuscar_ingreso_nrorecibro";
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
                SqlCmd.CommandText = "pmostrar_detalle_ingreso";
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
