using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatricula.UtilidadesSQL
{
    public class GestionUsuarioSQL : ConexionSQL
    {
        public GestionUsuarioSQL() { }

        public DataSet spObtenerBusquedaUsuariosPorCedula(string busqueda)
        {
            DataSet ds = null;
            try
            {
                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, busqueda, "BUSQUEDA"));
                ds = ejecutarProcedimientoAlmacenadoSimple("spObtenerBusquedaUsuarioPorCedula", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " GestionUsuarioSQL - spObtenerBusquedaUsuariosPorCedula");
            }
            return ds;
        }

        public DataSet spObtenerBusquedaUsuariosPorNombre(string busqueda)
        {
            DataSet ds = null;
            try
            {
                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, busqueda, "BUSQUEDA"));
                ds = ejecutarProcedimientoAlmacenadoSimple("spObtenerBusquedaUsuarioPorNombre", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " GestionUsuarioSQL - spObtenerBusquedaUsuariosPorNombre");
            }
            return ds;
        }

        public DataSet spObtenerBusquedaUsuariosPorUsuario(string busqueda)
        {
            DataSet ds = null;
            try
            {

                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, busqueda, "BUSQUEDA"));
                ds = ejecutarProcedimientoAlmacenadoSimple("spObtenerBusquedaUsuarioPorUsuario", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " GestionUsuarioSQL - spObtenerBusquedaUsuariosPorUsuario");
            }
            return ds;
        }

        public bool spEliminarUsuario(string usuario, int id)
        {
            bool exito = false;
            try
            {
                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, usuario, "USUARIO"));
                datos.Add(new DatoSQL(TipoDato.Int, id, "ID_USUARIO"));
                ejecutarProcedimientoAlmacenadoSimple("spEliminarUsuario", datos);
                exito = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " GestionUsuarioSQL - spObtenerBusquedaUsuariosPorUsuario");          
            }
            return exito;
        }

        public DataSet spBuscarPersonaPorCedula(string busqueda)
        {
            DataSet ds = null;
            try
            {
                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, busqueda, "BUSQUEDA"));
                ds = ejecutarProcedimientoAlmacenadoSimple("spBuscarPersonaPorCedula", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " GestionUsuarioSQL - spBuscarPersonaPorCedula");
            }
            return ds;
        }

    }
}
