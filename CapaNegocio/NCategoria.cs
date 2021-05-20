using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;//agregar referencia
using System.Data;//agregar
namespace CapaNegocio
{
    public class NCategoria
    {
        //Método Insertar que llama al método Insertar de la clase DCategoría
        //de la CapaDatos
        public static string Insertar(string idcategoria, string nombre)
        {
            DCategoria Obj = new DCategoria();//objeto q hace instanacia a la clase categoria
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre
            Obj.Idcategoria = idcategoria;
            return Obj.Insertar(Obj);
        }
        //Método Editar que llama al método Editar de la clase DCategoría
        //de la CapaDatos
        public static string Editar(string idcategoria, string nombre)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nombre = nombre;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCategoría
        //de la CapaDatos
        public static string Eliminar(string idcategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCategoría
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DCategoría de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }

}
