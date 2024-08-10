using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatricula.UtilidadesSQL
{
    public class ConsultaGenericaSQL : ConexionSQL
    {
        public DataSet spObtenerDatosTabla(string tabla, string id)
        {
            DataSet ds = null;
            try
            {

                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, tabla, "TABLA"));
                datos.Add(new DatoSQL(TipoDato.String, tabla, "ID"));

                ds = ejecutarProcedimientoAlmacenadoSimple("spObtenerDatosTabla", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ConsultaGenericaSQL - spObtenerDatosTabla");
            }   
            return ds;
        }
        public DataSet spObtenerDatosTabla(string tabla)
        {
            DataSet ds = null;
            try
            {

                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, tabla, "TABLA"));

                ds = ejecutarProcedimientoAlmacenadoSimple("spObtenerDatosTabla", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ConsultaGenericaSQL - spObtenerDatosTabla");
            }
            return ds;
        }
    }
}
