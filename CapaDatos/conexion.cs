using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class conexion
    {
        // public static string Cn = "Data Source=MAURI\\MAURI;Initial Catalog=BDMonterrey;Integrated Security=True";
        public void conex(string uno, string dos, string tres, string cuatro)
        {
            Properties.Settings.Default.user = tres;
            Properties.Settings.Default.server = uno;
            Properties.Settings.Default.database = dos;
            Properties.Settings.Default.password = cuatro;
            Properties.Settings.Default.Save();
        }
        public static string Cn = "Data Source=" + Properties.Settings.Default.server + ";Initial Catalog=" + Properties.Settings.Default.database + ";User ID=" + Properties.Settings.Default.user + ";Password=" + Properties.Settings.Default.password;
        public bool verificacion()
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Cn))
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string cadena()
        {
            return Cn;
        }
        public string CnReporte()
        {
            return Cn;
        }
        
        public bool Backups()
        {
            string nombre_copia = (System.DateTime.Today.Day.ToString()+"-"+System.DateTime.Today.Month.ToString()+"-"+System.DateTime.Today.Year.ToString()+"-"+System.DateTime.Now.Hour.ToString()+"-"+System.DateTime.Now.Minute.ToString()+"-"+System.DateTime.Now.Second.ToString()+"SisMonterrwy");
            string comando_consulta= "BACKUP DATABASE [BDMonterrey] TO  DISK = N'E:\\copias\\" + nombre_copia+".bak"+"' WITH NOFORMAT, NOINIT,  NAME = N'BDMonterrey-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            SqlConnection conexion = new SqlConnection(Cn);
            SqlCommand cmd = new SqlCommand(comando_consulta, conexion);
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
           
        }
        public void NroRecibo(int n)
        {
            Properties.Settings.Default.NroRecibo = n;
            Properties.Settings.Default.Save();
        }
        public int VerNroRecibo()
        {
            int n;
            n= Properties.Settings.Default.NroRecibo;
            if (n == null)
            {
                n = 0;
            }
            return n++;
        }
        public void NroBoleta(int n)
        {
            Properties.Settings.Default.NroBoleta = n;
            Properties.Settings.Default.Save();
        }
        public int VerNroBoleta()
        {
            int n;
            n = Properties.Settings.Default.NroBoleta;
            if (n == null)
            {
                n = 0;
            }
            return n++;
        }
    }
}
