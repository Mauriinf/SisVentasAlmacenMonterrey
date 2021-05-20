using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NCobros
    {
        public static string InsertarCobro(int idventa, int idtrabajador, int nrotalonario, string tipocomprobante, string nrorecibo,
           DateTime fecha, decimal deudaanterior, decimal pago,
         decimal deudapendiente, decimal rebaja)
        {
            DCobro Obj = new DCobro();
            Obj.Idventa = idventa;
            Obj.Idtrabajador = idtrabajador;
            Obj.NroTalonario = nrotalonario;
            Obj.TipoComprobante = tipocomprobante;
            Obj.Nrorecibo = nrorecibo;
            Obj.Fecha = fecha;
            Obj.Deudaanterior = deudaanterior;
            Obj.Pago = pago;
            Obj.Deudapendiente = deudapendiente;
            Obj.Rebaja = rebaja;

            return Obj.Insertar(Obj);
        }
        public static string EditarCobro(int idcobro, int idventa,
            int nrotalonario, string tipocomprobante, string nrorecibo, DateTime fecha, decimal deudaanterior,
           decimal pago, decimal deudapendiente, decimal rebaja)
        {
            DCobro Obj = new DCobro();
            Obj.Idventa = idventa;
            Obj.Idcobro = idcobro;
            Obj.Fecha = fecha;
            Obj.NroTalonario = nrotalonario;
            Obj.TipoComprobante = tipocomprobante;
            Obj.Nrorecibo = nrorecibo;
            Obj.Deudaanterior = deudaanterior;
            Obj.Pago = pago;
            Obj.Deudapendiente = deudapendiente;
            Obj.Rebaja = rebaja;
            return Obj.Editar(Obj);
        }
        public static string actualizar_detalle_venta(int idventa, decimal monto, decimal rebaja)
        {
            DCobro Obj = new DCobro();
            return Obj.Actualizar_detalle_venta(idventa, monto, rebaja);
        }
        public static string Actualizar_Venta_al_EliminarCobro(int idventa, decimal monto, decimal rebaja)
        {
            DCobro Obj = new DCobro();
            return Obj.Actualizar_Venta_al_EliminarCobro(idventa, monto, rebaja);
        }

        public static string ActualizarDetalle_Venta_al_EliminarCobro(int idventa, decimal monto, decimal rebaja)
        {
            DCobro Obj = new DCobro();
            return Obj.ActualizarDetalle_Venta_al_EliminarCobro(idventa, monto, rebaja);
        }
        public static DataTable Mostrar()
        {
            return new DCobro().Mostrar();
        }
        public static DataTable Buscarcliente(string textobuscar)
        {
            DCobro Obj = new DCobro();
            return Obj.Buscarcliente(textobuscar);
        }
        public static DataTable Buscarnumerorecibo(string textobuscar)
        {
            DCobro Obj = new DCobro();
            return Obj.BuscarNrorecibo(textobuscar);
        }

        public static DataTable MostrarCliente_Cobro_Nombre(string textobuscar)
        {
            DCobro Obj = new DCobro();
            return Obj.MostrarCliente_Cobro_Nombre(textobuscar);
        }
        public static DataTable MostrarCliente_Cobro_Nombre2()
        {
            DCobro Obj = new DCobro();
            return Obj.MostrarCliente_Cobro_Nombre2();
        }
        public static DataTable Mostrar_Cobros_IdVenta(int idventa)
        {
            return new DCobro().Mostrar_Cobro_Por_IdVenta(idventa);
        }
        public static string actualizarCobro_por_detalle_venta(int idcobro, decimal deudaanterior, decimal deudapendiente)
        {
            DCobro Obj = new DCobro();
            return Obj.ActualizarCobros_por_detalle_venta(idcobro, deudaanterior, deudapendiente);
        }
        public static string Eliminar(int idcobro)
        {
            DCobro Obj = new DCobro();//objeto q hace instanacia a la clase categoria
            Obj.Idcobro = idcobro;//Nombre del objeto //lo que recibiremos id categoria
            return Obj.Eliminar(Obj);
        }
    }
}
