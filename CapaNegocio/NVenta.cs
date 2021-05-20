using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NVenta
    {
        public static string Insertar(int idtrabajador, int idcliente, DateTime fecha,
            string nrotalonario,string tipocomprobante,
         string nrorecibo, decimal importetotal, decimal totalcontado,
         decimal saldoporcobrar, string estado, DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();
            Obj.Idcliente = idcliente;
            Obj.Idtrabajador = idtrabajador;
            Obj.Fecha = fecha;
            Obj.NroTalonario = nrotalonario;
            Obj.TipoComprobante = tipocomprobante;
            Obj.Nrorecibo = nrorecibo;
            Obj.ImporteTotal = importetotal;
            Obj.ImporteContado = totalcontado;
            Obj.SaldoXcobrar = saldoporcobrar;
            Obj.Estado = estado;

            List<DDetalle_Venta> detalles = new List<DDetalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Venta detalle = new DDetalle_Venta();
                detalle.Iddetalle_ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                detalle.Dovoluciones = Convert.ToInt32(row["Devoluciones"].ToString());
                detalle.Precio = Convert.ToDecimal(row["Precio"].ToString());
                detalle.ImporteTotal = Convert.ToDecimal(row["Importe_Total"].ToString());
                detalle.TotalContado = Convert.ToDecimal(row["Total_Contado"].ToString());
                detalle.SaldoXcobrar = Convert.ToDecimal(row["Saldo_por_Cobrar"].ToString());
                detalle.Rebaja = Convert.ToDecimal(row["Rebaja"].ToString());
                detalle.RebajaInicial = Convert.ToDecimal(row["RebajaInicial"].ToString());
                detalle.Estado = row["Estado"].ToString();
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }

        //editar

        public static string EditarVenta(int idventa, int idcliente,
             DateTime fecha,string nrotalonario, string tipocomprobante, string nrorecibo)
        {
            DVenta Obj = new DVenta();
            Obj.Idventa = idventa;
            Obj.Idcliente = idcliente;
            Obj.Fecha = fecha;
            Obj.NroTalonario = nrotalonario;
            Obj.TipoComprobante = tipocomprobante;
            Obj.Nrorecibo = nrorecibo;
            return Obj.Editar(Obj);
        }
        public static string EditarDetalleVenta(int iddetalle_venta, int idventa, int iddetalle_ingreso,
            int cantidad, int devoluciones, decimal precio, decimal importetotal, decimal alcontado,
            decimal totalcontado, decimal saldoporcobrar, decimal rebaja, decimal rebajaini, string estado)
        {
            DDetalle_Venta Obj = new DDetalle_Venta();
            Obj.Iddetalle_venta = iddetalle_venta;
            Obj.Idventa = idventa;
            Obj.Iddetalle_ingreso = iddetalle_ingreso;
            Obj.Cantidad = cantidad;
            Obj.Dovoluciones = devoluciones;
            Obj.Precio = precio;
            Obj.ImporteTotal = importetotal;
            Obj.TotalContado = totalcontado;
            Obj.AlContado = alcontado;
            Obj.SaldoXcobrar = saldoporcobrar;
            Obj.Rebaja = rebaja;
            Obj.RebajaInicial = rebajaini;
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }
        public static string EditarVentaPorDetalle(int idventa
         , decimal importetotal, decimal alcontado, decimal totalcontado,
          decimal saldoporcobrar, string estado)
        {
            DVenta Obj = new DVenta();
            Obj.Idventa = idventa;
            Obj.ImporteTotal = importetotal;
            Obj.AlContado = alcontado;
            Obj.ImporteContado = totalcontado;
            Obj.SaldoXcobrar = saldoporcobrar;
            Obj.Estado = estado;

            return Obj.EditarVentaPorDetalle(Obj);
        }
        public static string Eliminar(int idventa)
        {
            DVenta Obj = new DVenta();
            Obj.Idventa = idventa;
            return Obj.Eliminar(Obj);
        }
        public static string EliminarDetalle(int iddetalle)
        {

            DDetalle_Venta Obj = new DDetalle_Venta();
            Obj.Iddetalle_venta = iddetalle;
            return Obj.Eliminar(Obj);
        }
        public static string restablecer(int iddetalle_ingreso, int devol)
        {
            DVenta Obj = new DVenta();
            return Obj.RestablecerStock(iddetalle_ingreso, devol);
        }
        public static string disminuirStock(int iddetalle_ingreso, int devol)
        {
            DVenta Obj = new DVenta();
            return Obj.DisminuirStock(iddetalle_ingreso, devol);
        }
        //Método Mostrar que llama al método Mostrar de la clase DVenta
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        //Método BuscarFecha que llama al método BuscarFecha
        //de la clase DVenta de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }
        public static DataTable BuscarPorNrorecibo(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarNrorecibo(textobuscar);
        }
        public static DataTable BuscarPorClientes(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.Buscarcliente(textobuscar);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(textobuscar);
        }
        public static DataTable MostrarProducto_Venta_Nombre(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarProducto_Venta_Nombre(textobuscar);
        }
        public static DataTable MostrarProducto_Venta_NombreNombre(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarProducto_Venta_Nombre2(textobuscar);
        }
        public static DataTable MostrarrProducto_Venta_Codigo(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarProducto_Venta_codigo(textobuscar);
        }
        public static DataTable MostrarrProducto_Venta(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarProducto_Venta(textobuscar);
        }
        public static DataTable MostrarDetalleIngreso_NombreProducto(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle_Ingreso_NombreProducto(textobuscar);
        }
        public static DataTable BuscarDeudasVentaCliente(string textobuscar,string textobuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarDeudasVentaCliente(textobuscar,textobuscar2);
        }
        
        public static DataTable BuscarDeudasVentaClientePorNroRecibo(string textobuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarDeudasVentaClientePorRecibo(textobuscar, textobuscar2);
        }
        
            public static DataTable MostrarDetalleVentaPorIdVenta(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalleVentaPorIdVenta(textobuscar);
        }
    }
}
