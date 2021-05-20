using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;//agregar referencia
using System.Data;//agregar

namespace CapaNegocio
{
    public class NConductor
    { //Método Insertar que llama al método Insertar de la clase DCategoría
        //de la CapaDatos
        public static string Insertar(string nombre, string apellidop, string apellidom, string nlicencia, string placa, string sexo,string colorvehiculo)
        {
            DConductor Obj = new DConductor();//objeto q hace instanacia a la clase categoria
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidop = apellidop;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidom = apellidom;//Nombre del objeto //lo que recibiremos nombre
            Obj.Nlicencia = nlicencia;//Nombre del objeto //lo que recibiremos nombre
            Obj.Placa = placa;
            Obj.Sexo = sexo;//Nombre del objeto //lo que recibiremos nombre
            Obj.Colorvehiculo = colorvehiculo;
            return Obj.Insertar(Obj);
        }
        //Método Editar que llama al método Editar de la clase DCategoría2
        //de la CapaDatos
        public static string Editar(int idconductor, string nombre, string apellidop, string apellidom, string nlicencia, string placa, string sexo, string colorvehiculo)
        {
            DConductor Obj = new DConductor();//objeto q hace instanacia a la clase categoria
            Obj.Idconductor = idconductor;//Nombre del objeto //lo que recibiremos idcategoria
            Obj.Nombre = nombre;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidop = apellidop;//Nombre del objeto //lo que recibiremos nombre
            Obj.Apellidom = apellidom;//Nombre del objeto //lo que recibiremos nombre
            Obj.Nlicencia = nlicencia;//Nombre del objeto //lo que recibiremos nombre
            Obj.Placa = placa;
            Obj.Sexo = sexo;//Nombre del objeto //lo que recibiremos nombre
            Obj.Colorvehiculo = colorvehiculo;
            return Obj.Editar(Obj);
        }

        //Método Eliminar que llama al método Eliminar de la clase DCategoría
        //de la CapaDatos
        public static string Eliminar(int idconductor)
        {
            DConductor Obj = new DConductor();//objeto q hace instanacia a la clase categoria
            Obj.Idconductor = idconductor;//Nombre del objeto //lo que recibiremos id categoria
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar que llama al método Mostrar de la clase DCategoría
        //de la CapaDatos
        public static DataTable Mostrar()
        {
            return new DConductor().Mostrar();
        }

        //Método BuscarNombre que llama al método BuscarNombre
        //de la clase DCategoría de la CapaDatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DConductor Obj = new DConductor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
