using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NIngreso
    {
        public static string Insertar(int idconductor,int idtrabajador, int nombreproveedor, DateTime fechasalida, DateTime fechaingresodeposito,
           string nrotalonario,string comprobante, string nrocomprobante, string destino, string descargo,
           decimal fleteunitario, decimal fletetotal, decimal fletecontado, decimal fleteporcancelar, decimal carguiounitario,
           decimal carguiototal,decimal carguiocontado,decimal carguioporpagar, decimal totalfletemascarguio, string estado, DataTable dtDetalles)
        {

            DIngreso Obj = new DIngreso();
            Obj.Idconductor = idconductor;
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = nombreproveedor;
            Obj.NroTalonario1 = nrotalonario;
            Obj.Comprobante = comprobante;
            Obj.NroComprobante = nrocomprobante;
            Obj.Fechasalida = fechasalida;
            Obj.Fechaingresodeposito = fechaingresodeposito;
            Obj.Destino = destino;
            Obj.Descargo = descargo;
            Obj.CarguioContado = carguiocontado;
            Obj.Fleteunitario = fleteunitario;
            Obj.Fletetotal = fletetotal;
            Obj.Fletecontado = fletecontado;
            Obj.Fleteporpagar = fleteporcancelar;
            Obj.Carguiounitario = carguiounitario;
            Obj.CarguioTotal = carguiototal;
            Obj.Carguioporpagar = carguioporpagar;
            Obj.Totalfletemascarguio = totalfletemascarguio;

            Obj.Estado = estado;
            List<DDetalle_ingreso> detalles = new List<DDetalle_ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_ingreso detalle = new DDetalle_ingreso();
                detalle.Idproducto = row["ID_Producto"].ToString();
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Fleteunitario= Convert.ToDecimal(row["Flete_Unitario"].ToString());
                detalle.Fletetotal= Convert.ToDecimal(row["Flete_Total"].ToString());
                detalle.Fletecontado = Convert.ToDecimal(row["Flete_Contado"].ToString());
                detalle.Fleteporpagar = Convert.ToDecimal(row["Flete_x_Pagar"].ToString());
                detalle.Carguiounitario = Convert.ToDecimal(row["Carguio_Unitario"].ToString());
                detalle.CarguioTotal = Convert.ToDecimal(row["Carguio_Total"].ToString());
                detalle.CarguioContado = Convert.ToDecimal(row["Carguio_Contado"].ToString());
                detalle.Carguioporpagar = Convert.ToDecimal(row["Carguio_x_Pagar"].ToString());
                detalle.Totalfletemascarguio = Convert.ToDecimal(row["Total"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }

        public static string Editar(int idingreso,int idconductor, int nombreproveedor, DateTime fechasalida, DateTime fechaingresodeposito,
            string nrotalonario, string comprobante, string nrocomprobante, string destino, string descargo)
        {

            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;
            Obj.Idconductor = idconductor;
            
            Obj.Idproveedor = nombreproveedor;
            Obj.NroTalonario1 = nrotalonario;
            Obj.Comprobante = comprobante;
            Obj.NroComprobante = nrocomprobante;
            Obj.Fechasalida = fechasalida;
            Obj.Fechaingresodeposito = fechaingresodeposito;
            Obj.Destino = destino;
            Obj.Descargo = descargo;
            
           return Obj.Editar(Obj);
        }
        public static string EditarIngresoPorDetalle(int idingreso,decimal fleteunitario, decimal fletetotal, decimal fletecontado, decimal fleteporcancelar, decimal carguiounitario,
           decimal carguiototal, decimal carguiocontado, decimal carguioporpagar, decimal totalfletemascarguio)
        {

            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;           
            Obj.Fleteunitario = fleteunitario;
            Obj.Fletetotal = fletetotal;
            Obj.Fletecontado = fletecontado;
            Obj.Fleteporpagar = fleteporcancelar;
            Obj.Carguiounitario = carguiounitario;
            Obj.CarguioTotal = carguiototal;
            Obj.CarguioContado = carguiocontado;
            Obj.Carguioporpagar = carguioporpagar;
            Obj.Totalfletemascarguio = totalfletemascarguio;
            
            return Obj.EditarIngresoPorDetalle(Obj);
        }
        public static string EditarDetalleIngreso(int iddetalleingreso, string idproducto, int stockinicial, int stockactual,decimal fleteunitario,decimal fletetotal,
            decimal fletecontado,decimal fleteporpagar,decimal carguiounitario, decimal carguiototal,decimal carguiocontado,decimal carguioporpagar,decimal total)
        {

            DDetalle_ingreso Obj = new DDetalle_ingreso();
            Obj.Iddetalle_Ingreso = iddetalleingreso;
            Obj.Idproducto = idproducto;

            Obj.Stock_Inicial = stockinicial;
            Obj.Stock_Actual= stockactual;
            Obj.Fleteunitario = fleteunitario;
            Obj.Fletetotal = fletetotal;
            Obj.Fletecontado =fletecontado;
            Obj.Fleteporpagar = fleteporpagar;
            Obj.Carguiounitario =carguiounitario;
            Obj.CarguioTotal = carguiototal;
            Obj.CarguioContado = carguiocontado;
            Obj.Carguioporpagar = carguioporpagar;
            Obj.Totalfletemascarguio = total;

            return Obj.Editar(Obj);
        }
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }
        public static string Eliminar(int iddetalleingreso)
        {
            DDetalle_ingreso Obj = new DDetalle_ingreso();
            Obj.Iddetalle_Ingreso = iddetalleingreso;
            return Obj.Eliminar(Obj);
        }
        //Método Mostrar que llama al método Mostrar de la clase DIngreso
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        //Método BuscarFecha que llama al método BuscarNombre
        //de la clase DIngreso de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }
        public static DataTable BuscarPorNroRecibo(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarPorNroRecibo(textobuscar);
        }
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
