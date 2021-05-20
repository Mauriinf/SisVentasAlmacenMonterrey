using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DDetalle_ingreso
    {
        //Variables
        private int _Iddetalle_Ingreso;
        private int _Idingreso;
        private string _Idproducto;
        private int _Stock_Inicial;
        private int _Stock_Actual;
        private decimal _Fleteunitario;
        private decimal _Fletetotal;
        private decimal _Fletecontado;
        private decimal _Fleteporpagar;
        private decimal _Carguiounitario;
        private decimal _CarguioTotal;
        private decimal _CarguioContado;
        private decimal _Carguioporpagar;
        private decimal _Totalfletemascarguio;

        public int Iddetalle_Ingreso
        {
            get
            {
                return _Iddetalle_Ingreso;
            }

            set
            {
                _Iddetalle_Ingreso = value;
            }
        }

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

        public int Stock_Inicial
        {
            get
            {
                return _Stock_Inicial;
            }

            set
            {
                _Stock_Inicial = value;
            }
        }

        public int Stock_Actual
        {
            get
            {
                return _Stock_Actual;
            }

            set
            {
                _Stock_Actual = value;
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

        //Constructores 
        public DDetalle_ingreso()
        {

        }
        public DDetalle_ingreso(int iddetalle_ingreso, int idingreso, string idproducto,
            int stock_inicial, int stock_actual,decimal fleteunitario, decimal fletetotal, 
            decimal fletecontado, decimal fleteporcancelar, decimal carguiounitario,
            decimal carguiototal,decimal carguiocontado, decimal carguioporpagar, decimal totalfletemascarguio)
        {
            this.Iddetalle_Ingreso = iddetalle_ingreso;
            this.Idingreso = idingreso;
            this.Idproducto = idproducto;
            this.Stock_Inicial = stock_inicial;
            this.Stock_Actual = stock_actual;
            this.Fleteunitario = fleteunitario;
            this.Fletetotal = fletetotal;
            this.Fletecontado = fletecontado;
            this.Fleteporpagar = fleteporcancelar;
            this.Carguiounitario = carguiounitario;
            this.CarguioTotal = carguiototal;
            this.CarguioContado = carguiocontado;
            this.Carguioporpagar = carguioporpagar;
            this.Totalfletemascarguio = totalfletemascarguio;

        }
        //Método Insertar
        public string Insertar(DDetalle_ingreso Detalle_Ingreso,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "pinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Ingreso = new SqlParameter();
                ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Detalle_Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";
                ParIdproducto.Size = 20;
                ParIdproducto.SqlDbType = SqlDbType.VarChar;
                ParIdproducto.Value = Detalle_Ingreso.Idproducto;
                SqlCmd.Parameters.Add(ParIdproducto);

                SqlParameter ParStock_Inicial = new SqlParameter();
                ParStock_Inicial.ParameterName = "@stock_inicial";
                ParStock_Inicial.SqlDbType = SqlDbType.Int;
                ParStock_Inicial.Value = Detalle_Ingreso.Stock_Inicial;
                SqlCmd.Parameters.Add(ParStock_Inicial);

                SqlParameter ParStock_Actual = new SqlParameter();
                ParStock_Actual.ParameterName = "@stock_actual";
                ParStock_Actual.SqlDbType = SqlDbType.Int;
                ParStock_Actual.Value = Detalle_Ingreso.Stock_Actual;
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParFleteunitario = new SqlParameter();
                ParFleteunitario.ParameterName = "@fleteunitario";
                ParFleteunitario.SqlDbType = SqlDbType.Money;
                ParFleteunitario.Value = Detalle_Ingreso.Fleteunitario;
                SqlCmd.Parameters.Add(ParFleteunitario);

                SqlParameter ParFletetotal = new SqlParameter();
                ParFletetotal.ParameterName = "@fletetotal";
                ParFletetotal.SqlDbType = SqlDbType.Money;
                ParFletetotal.Value = Detalle_Ingreso.Fletetotal;
                SqlCmd.Parameters.Add(ParFletetotal);

                SqlParameter ParFletecontado = new SqlParameter();
                ParFletecontado.ParameterName = "@fletecontado";
                ParFletecontado.SqlDbType = SqlDbType.Money;
                ParFletecontado.Value = Detalle_Ingreso.Fletecontado;
                SqlCmd.Parameters.Add(ParFletecontado);

                SqlParameter ParFleteporcancelar = new SqlParameter();
                ParFleteporcancelar.ParameterName = "@fleteporpagar";
                ParFleteporcancelar.SqlDbType = SqlDbType.Money;
                ParFleteporcancelar.Value = Detalle_Ingreso.Fleteporpagar;
                SqlCmd.Parameters.Add(ParFleteporcancelar);

                SqlParameter ParCarguiounitario = new SqlParameter();
                ParCarguiounitario.ParameterName = "@carguiounitario";
                ParCarguiounitario.SqlDbType = SqlDbType.Money;
                ParCarguiounitario.Value = Detalle_Ingreso.Carguiounitario;
                SqlCmd.Parameters.Add(ParCarguiounitario);

                SqlParameter ParCarguiototal = new SqlParameter();
                ParCarguiototal.ParameterName = "@carguiototal";
                ParCarguiototal.SqlDbType = SqlDbType.Money;
                ParCarguiototal.Value = Detalle_Ingreso.CarguioTotal;
                SqlCmd.Parameters.Add(ParCarguiototal);

                SqlParameter ParCarguiocontado = new SqlParameter();
                ParCarguiocontado.ParameterName = "@carguiocontado";
                ParCarguiocontado.SqlDbType = SqlDbType.Money;
                ParCarguiocontado.Value = Detalle_Ingreso.CarguioContado;
                SqlCmd.Parameters.Add(ParCarguiocontado);

                SqlParameter ParCarguioporpagar = new SqlParameter();
                ParCarguioporpagar.ParameterName = "@carguioporpagar";
                ParCarguioporpagar.SqlDbType = SqlDbType.Money;
                ParCarguioporpagar.Value = Detalle_Ingreso.Carguioporpagar;
                SqlCmd.Parameters.Add(ParCarguioporpagar);

                SqlParameter ParTotalfletemascarguio = new SqlParameter();
                ParTotalfletemascarguio.ParameterName = "@total";
                ParTotalfletemascarguio.SqlDbType = SqlDbType.Money;
                ParTotalfletemascarguio.Value = Detalle_Ingreso.Totalfletemascarguio;
                SqlCmd.Parameters.Add(ParTotalfletemascarguio);





                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }

        public string Editar(DDetalle_ingreso Detalle_Ingreso)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer la trasacción

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                
                SqlCmd.CommandText = "peditar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Ingreso = new SqlParameter();
                ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Value = Detalle_Ingreso.Iddetalle_Ingreso;
                SqlCmd.Parameters.Add(ParIddetalle_Ingreso);

               
                SqlParameter ParIdproducto = new SqlParameter();
                ParIdproducto.ParameterName = "@idproducto";
                ParIdproducto.Size = 20;
                ParIdproducto.SqlDbType = SqlDbType.VarChar;
                ParIdproducto.Value = Detalle_Ingreso.Idproducto;
                SqlCmd.Parameters.Add(ParIdproducto);

                SqlParameter ParStock_Inicial = new SqlParameter();
                ParStock_Inicial.ParameterName = "@stock_inicial";
                ParStock_Inicial.SqlDbType = SqlDbType.Int;
                ParStock_Inicial.Value = Detalle_Ingreso.Stock_Inicial;
                SqlCmd.Parameters.Add(ParStock_Inicial);

                SqlParameter ParStock_Actual = new SqlParameter();
                ParStock_Actual.ParameterName = "@stock_actual";
                ParStock_Actual.SqlDbType = SqlDbType.Int;
                ParStock_Actual.Value = Detalle_Ingreso.Stock_Actual;
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParFleteunitario = new SqlParameter();
                ParFleteunitario.ParameterName = "@fleteunitario";
                ParFleteunitario.SqlDbType = SqlDbType.Money;
                ParFleteunitario.Value = Detalle_Ingreso.Fleteunitario;
                SqlCmd.Parameters.Add(ParFleteunitario);

                SqlParameter ParFletetotal = new SqlParameter();
                ParFletetotal.ParameterName = "@fletetotal";
                ParFletetotal.SqlDbType = SqlDbType.Money;
                ParFletetotal.Value = Detalle_Ingreso.Fletetotal;
                SqlCmd.Parameters.Add(ParFletetotal);

                SqlParameter ParFletecontado = new SqlParameter();
                ParFletecontado.ParameterName = "@fletecontado";
                ParFletecontado.SqlDbType = SqlDbType.Money;
                ParFletecontado.Value = Detalle_Ingreso.Fletecontado;
                SqlCmd.Parameters.Add(ParFletecontado);

                SqlParameter ParFleteporcancelar = new SqlParameter();
                ParFleteporcancelar.ParameterName = "@fleteporpagar";
                ParFleteporcancelar.SqlDbType = SqlDbType.Money;
                ParFleteporcancelar.Value = Detalle_Ingreso.Fleteporpagar;
                SqlCmd.Parameters.Add(ParFleteporcancelar);

                SqlParameter ParCarguiounitario = new SqlParameter();
                ParCarguiounitario.ParameterName = "@carguiounitario";
                ParCarguiounitario.SqlDbType = SqlDbType.Money;
                ParCarguiounitario.Value = Detalle_Ingreso.Carguiounitario;
                SqlCmd.Parameters.Add(ParCarguiounitario);

                SqlParameter ParCarguiototal = new SqlParameter();
                ParCarguiototal.ParameterName = "@carguiototal";
                ParCarguiototal.SqlDbType = SqlDbType.Money;
                ParCarguiototal.Value = Detalle_Ingreso.CarguioTotal;
                SqlCmd.Parameters.Add(ParCarguiototal);

                SqlParameter ParCarguiocontado = new SqlParameter();
                ParCarguiocontado.ParameterName = "@carguiocontado";
                ParCarguiocontado.SqlDbType = SqlDbType.Money;
                ParCarguiocontado.Value = Detalle_Ingreso.CarguioContado;
                SqlCmd.Parameters.Add(ParCarguiocontado);

                SqlParameter ParCarguioporpagar = new SqlParameter();
                ParCarguioporpagar.ParameterName = "@carguioporpagar";
                ParCarguioporpagar.SqlDbType = SqlDbType.Money;
                ParCarguioporpagar.Value = Detalle_Ingreso.Carguioporpagar;
                SqlCmd.Parameters.Add(ParCarguioporpagar);

                SqlParameter ParTotalfletemascarguio = new SqlParameter();
                ParTotalfletemascarguio.ParameterName = "@total";
                ParTotalfletemascarguio.SqlDbType = SqlDbType.Money;
                ParTotalfletemascarguio.Value = Detalle_Ingreso.Totalfletemascarguio;
                SqlCmd.Parameters.Add(ParTotalfletemascarguio);





                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }
        //Método Eliminar
        public string Eliminar(DDetalle_ingreso Detalle)//instanciar a la clase DCategoria2 y generamos es objeto categoria
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
                SqlCmd.CommandText = "peliminar_detalle_ingreso";//nombre del objeto al cual ara referencia (procedimiento)
                SqlCmd.CommandType = CommandType.StoredProcedure;//tipo de objeto es un procedimiento almacenado

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@iddetalle";//variable de procedimieto almacenado
                ParIdcliente.SqlDbType = SqlDbType.Int;//ipo de dato
                ParIdcliente.Value = Detalle.Iddetalle_Ingreso;
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

    }
}
