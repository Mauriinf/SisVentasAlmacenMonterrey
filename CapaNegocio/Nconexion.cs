using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class Nconexion
    {
        public static void conex(string uno, string dos, string tres, string cuatro)
        {
            conexion obj = new conexion();
            obj.conex(uno, dos, tres, cuatro);
        }
        public static bool backups()
        {
            conexion obj = new conexion();
            return obj.Backups();
        }
        public static string CnReporte()
        {
            conexion obj = new conexion();
            return obj.CnReporte();
        }
        public static void NroRecibo(int num)
        {
            conexion obj = new conexion();
            obj.NroRecibo(num);
        }
        public static int VerNroRecibo()
        {
            conexion obj = new conexion();
            return obj.VerNroRecibo();
        }
        public static void NroBoleta(int num)
        {
            conexion obj = new conexion();
            obj.NroBoleta(num);
        }
        public static int VerNroBoleta()
        {
            conexion obj = new conexion();
            return obj.VerNroBoleta();
        }
    }
}
