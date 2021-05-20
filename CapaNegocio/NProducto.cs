using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;//agregar referencia
using System.Data;//agregar
namespace CapaNegocio
{
    public class NProducto
    {
        //Método Insertar que llama al método Insertar de la clase DProducto
        //de la CapaDatos
        public static string Insertar(string idproducto, string nombre, string idcategoria,string unidadmedida)
        {
            DProducto Obj = new DProducto();//objeto q hace instanacia a la clase categoria
            Obj.Idproducto = idproducto;
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre

            Obj.Idcategoria = idcategoria;//Nombre del objeto //lo que recibiremos idcategoria
            Obj.Unidadmedida = unidadmedida;
            return Obj.Insertar(Obj);
        }
        //Método Editar que llama al método Editar de la clase DCategoría2
        //de la CapaDatos
        public static string Editar(string idproducto, string nombre, string idcategoria,string unidadmedida)
        {
            DProducto Obj = new DProducto();//objeto q hace instanacia a la clase categoria
            Obj.Idproducto = idproducto;//Nombre del objeto //lo que recibiremos idproducto
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre

            Obj.Idcategoria = idcategoria;//Nombre del objeto //lo que recibiremos idcategoria
            Obj.Unidadmedida = unidadmedida;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCategoría
        //de la CapaDatos
        public static string Eliminar(string idproducto)
        {
            DProducto Obj = new DProducto();//objeto q hace instanacia a la clase categoria
            Obj.Idproducto = idproducto;//Nombre del objeto //lo que recibiremos id categoria
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCategoría
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DProducto().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DCategoría de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
