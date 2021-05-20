using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;//agregar referencia
using System.Data;//agregar
namespace CapaNegocio
{
    public class NProveedor
    {
        //Método Insertar que llama al método Insertar de la clase DCategoría
        //de la CapaDatos
        public static string Insertar(string nombre, string direccion,string ciudad, string telefono, string email)
        {
            DProveedor Obj = new DProveedor();//objeto q hace instanacia a la clase categoria
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre
            Obj.Ciudad = ciudad;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
           
            return Obj.Insertar(Obj);
        }
        //Método Editar que llama al método Editar de la clase DCategoría2
        //de la CapaDatos
        public static string Editar(int idproveedor, string nombre, string direccion, string ciudad, string telefono, string email)
        {
            DProveedor Obj = new DProveedor();//objeto q hace instanacia a la clase categoria
            Obj.IdProveedor = idproveedor;//Nombre del objeto //lo que recibiremos idcategoria
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre
            Obj.Ciudad = ciudad;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCategoría
        //de la CapaDatos
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();//objeto q hace instanacia a la clase categoria
            Obj.IdProveedor = idproveedor;//Nombre del objeto //lo que recibiremos id categoria
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCategoría
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DCategoría de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        
    }
}
