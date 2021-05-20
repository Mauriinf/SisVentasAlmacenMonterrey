using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NIngreso2
    {
        public static string Insertar(int idtrabajador, int nombreproveedor, DateTime fechaingreso,
            string nrotalonario, string comprobante, string nrocomprobante, string estado, DataTable dtDetalles)
        {

            DIngreso2 Obj = new DIngreso2();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = nombreproveedor;
            Obj.NroTalonario = nrotalonario;
            Obj.Comprobante = comprobante;
            Obj.NroComprobante = nrocomprobante;
            Obj.Fechaingreso = fechaingreso;
            Obj.Estado = estado;
            List<DDetalle_Ingreso2> detalles = new List<DDetalle_Ingreso2>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso2 detalle = new DDetalle_Ingreso2();
                detalle.Idproducto = row["Id_Producto"].ToString();
                detalle.Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString());

                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }
        //Método Mostrar que llama al método Mostrar de la clase DIngreso
        //de la CapaDatos
        public static string Editar(int idingreso, int nombreproveedor, DateTime fechaingreso,
           string nrotalonario, string comprobante, string nrocomprobante)
        {

            DIngreso2 Obj = new DIngreso2();
            Obj.Idingreso = idingreso;
            Obj.Idproveedor = nombreproveedor;
            Obj.Fechaingreso = fechaingreso;
            Obj.NroTalonario = nrotalonario;
            Obj.Comprobante = comprobante;
            Obj.NroComprobante = nrocomprobante;
            return Obj.Editar(Obj);
        }
        public static string EditarDetalleIngreso2(int iddetalleingreso, string idproducto, int stockinicial, int stockactual)
        {

            DDetalle_Ingreso2 Obj = new DDetalle_Ingreso2();
            Obj.Iddetalle_Ingreso = iddetalleingreso;
            Obj.Idproducto = idproducto;

            Obj.Stock_Inicial = stockinicial;
            Obj.Stock_Actual = stockactual;           

            return Obj.Editar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DIngreso2().Mostrar();
        }

        //Método BuscarFecha que llama al método BuscarNombre
        //de la clase DIngreso de la CapaDatos

        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DIngreso2 Obj = new DIngreso2();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }
        public static DataTable Buscar_por_nroRecibo(string textobuscar)
        {
            DIngreso2 Obj = new DIngreso2();
            return Obj.Buscar_por_nroRecibo(textobuscar);
        }
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso2 Obj = new DIngreso2();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
