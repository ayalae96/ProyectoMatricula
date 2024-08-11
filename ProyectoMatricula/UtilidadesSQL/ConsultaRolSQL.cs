using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatricula.UtilidadesSQL
{
    public class ConsultaRolSQL : ConexionSQL
    {
        public DataSet spBuscarUsuariosRoles(string busqueda)
        {
            DataSet ds = null;
            try
            {

                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, busqueda, "Busqueda"));

                ds = ejecutarProcedimientoAlmacenadoSimple("spBuscarUsuariosRoles", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ConsultaGenericaSQL - spBuscarUsuariosRoles");
            }
            return ds;
        }
        public DataSet spCambiarRol(int rol, int id)
        {
            DataSet ds = null;
            try
            {

                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.Int, rol, "ROL"));
                datos.Add(new DatoSQL(TipoDato.Int, id, "ID"));


                ds = ejecutarProcedimientoAlmacenadoSimple("spCambiarRol", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ConsultaGenericaSQL - spCambiarRol");
            }
            return ds;
        }
    }
}
