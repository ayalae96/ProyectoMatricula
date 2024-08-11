using ProyectoMatricula.UtilidadesSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatricula
{
    public class LoginSQL : ConexionSQL
    {
        public LoginSQL() { }
        public DataSet spIniciarSesion(string usuario, string contrasena)
        {
            DataSet ds = new DataSet(); 
            try
            {

                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, usuario, "USUARIO"));
                datos.Add(new DatoSQL(TipoDato.String, contrasena, "CONTRASENA"));

                ds = ejecutarProcedimientoAlmacenadoSimple("spIniciarSesion", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " LoginSQL - spIniciarSesion");
            }
            return ds;
        }
    }
}
