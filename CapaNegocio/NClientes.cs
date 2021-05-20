using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;//agregar referencia
using System.Data;//agregar
namespace CapaNegocio
{
    public class NClientes
    {
        //Método Insertar que llama al método Insertar de la clase DCategoría
        //de la CapaDatos
        public static string Insertar(string nombre, string apellidop, string apellidom, string ci, string sexo,string puestoventa)
        {
            DClientes Obj = new DClientes();//objeto q hace instanacia a la clase categoria
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidop = apellidop;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidom = apellidom;//Nombre del objeto //lo que recibiremos nombre
            Obj.Ci = ci;//Nombre del objeto //lo que recibiremos nombre
            Obj.Sexo = sexo;//Nombre del objeto //lo que recibiremos nombre
            Obj.Puestoventa = puestoventa;
            return Obj.Insertar(Obj);
        }
        //Método Editar que llama al método Editar de la clase DCategoría2
        //de la CapaDatos
        public static string Editar(int idcliente, string nombre, string apellidop, string apellidom, string ci, string sexo, string puestoventa)
        {
            DClientes Obj = new DClientes();//objeto q hace instanacia a la clase categoria
            Obj.Idcliente = idcliente;//Nombre del objeto //lo que recibiremos idcategoria
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidop = apellidop;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidom = apellidom;//Nombre del objeto //lo que recibiremos nombre
            Obj.Ci = ci;//Nombre del objeto //lo que recibiremos nombre
            Obj.Sexo = sexo;//Nombre del objeto //lo que recibiremos nombre
            Obj.Puestoventa = puestoventa;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCategoría
        //de la CapaDatos
        public static string Eliminar(int idcliente)
        {
            DClientes Obj = new DClientes();//objeto q hace instanacia a la clase categoria
            Obj.Idcliente = idcliente;//Nombre del objeto //lo que recibiremos id categoria
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCategoría
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DClientes().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DCategoría de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DClientes Obj = new DClientes();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
