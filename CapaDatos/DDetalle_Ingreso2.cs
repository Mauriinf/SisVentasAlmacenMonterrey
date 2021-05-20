using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DDetalle_Ingreso2
    {
        //Variables
        private int _Iddetalle_Ingreso;
        private int _Idingreso;
        private string _Idproducto;
        private int _Stock_Inicial;
        private int _Stock_Actual;

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

        public DDetalle_Ingreso2()
        {

        }
        public DDetalle_Ingreso2(int iddetalle_ingreso, int idingreso, string idproducto,
            int stock_inicial, int stock_actual)
        {
            this.Iddetalle_Ingreso = iddetalle_ingreso;
            this.Idingreso = idingreso;
            this.Idproducto = idproducto;
            this.Stock_Inicial = stock_inicial;
            this.Stock_Actual = stock_actual;
           

        }
        //Método Insertar
        public string Insertar(DDetalle_Ingreso2 Detalle_Ingreso,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "pinsertar_detalle_ingreso2";
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

                
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }
        public string Editar(DDetalle_Ingreso2 Detalle_Ingreso )
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

                SqlCmd.CommandText = "peditar_detalle_ingreso2";
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

                
                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            return rpta;

        }
    }
}
