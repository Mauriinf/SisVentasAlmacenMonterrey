using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;//agregar referencia
using System.Data;//agregar
namespace CapaNegocio
{
    public class NTrabajador
    {
        //Método Insertar que llama al método Insertar de la clase DCategoría
        //de la CapaDatos
        public static string Insertar(string nombre, string apellidop, string apellidom, string sexo, DateTime fechanac, string ci, string direccion, string telefono, string email, string tipotrabajador, string usuario, string password, string estado)
        {
            DTrabajador Obj = new DTrabajador();//objeto q hace instanacia a la clase categoria
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidop = apellidop;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidom = apellidom;//Nombre del objeto //lo que recibiremos nombre
            Obj.Ci = ci;//Nombre del objeto //lo que recibiremos nombre
            Obj.FechaNac = fechanac;
            Obj.Sexo = sexo;//Nombre del objeto //lo que recibiremos nombre
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.TipoTrabajador = tipotrabajador;
            Obj.Usuario = usuario;
            Obj.Password = password;
            Obj.Estado = estado;
            return Obj.Insertar(Obj);
        }
        //Método Editar que llama al método Editar de la clase DCategoría2
        //de la CapaDatos
        public static string Editar(int idtrabajador, string nombre, string apellidop, string apellidom, string sexo, DateTime fechanac, string ci, string direccion, string telefono, string email, string tipotrabajador, string usuario, string estado)
        {
            DTrabajador Obj = new DTrabajador();//objeto q hace instanacia a la clase categoria
            Obj.Idtrabajador = idtrabajador;//Nombre del objeto //lo que recibiremos idcategoria
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidop = apellidop;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidom = apellidom;//Nombre del objeto //lo que recibiremos nombre
            Obj.Ci = ci;//Nombre del objeto //lo que recibiremos nombre
            Obj.FechaNac = fechanac;
            Obj.Sexo = sexo;//Nombre del objeto //lo que recibiremos nombre
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.TipoTrabajador = tipotrabajador;
            Obj.Usuario = usuario;
           
            Obj.Estado = estado;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCategoría
        //de la CapaDatos
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador Obj = new DTrabajador();//objeto q hace instanacia a la clase categoria
            Obj.Idtrabajador = idtrabajador;//Nombre del objeto //lo que recibiremos id categoria
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCategoría
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DCategoría de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
        public static DataTable Login(string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
        public static bool verificacion()
        {
            conexion obj = new conexion();
            return obj.verificacion();
        }
        public static string cadenaConexion()
        {
            conexion obj = new conexion();
            return obj.cadena();
        }
    }
}
