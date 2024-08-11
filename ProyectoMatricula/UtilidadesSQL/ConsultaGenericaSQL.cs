using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatricula.UtilidadesSQL
{
    public class ConsultaGenericaSQL : ConexionSQL
    {
        public DataSet spActualizarDatoGenerico(string tabla, string id, string cadena, TipoDato tipoDato, string columna)
        {
            DataSet ds = null;
            try
            {
                MessageBox.Show(tabla);
                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, tabla, "TABLA"));
                datos.Add(new DatoSQL(tipoDato, id, "ID"));
                datos.Add(new DatoSQL(TipoDato.String, cadena, "VALORES"));
                datos.Add(new DatoSQL(TipoDato.String, columna, "COLUMNA"));



                ds = ejecutarProcedimientoAlmacenadoSimple("spActualizarDatoGenerico", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ConsultaGenericaSQL - spActualizarDatoGenerico");
            }
            return ds;
        }
        public DataSet spObtenerDatoGenerico(string tabla, string id, string columna, TipoDato tipoDato)
        {
            DataSet ds = null;
            try
            {
                MessageBox.Show(tabla);
                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, tabla, "TABLA"));
                datos.Add(new DatoSQL(tipoDato, id, "ID"));
                datos.Add(new DatoSQL(TipoDato.String, columna, "COLUMNA"));


                ds = ejecutarProcedimientoAlmacenadoSimple("spObtenerDatoGenerico", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ConsultaGenericaSQL - spObtenerDatoGenerico");
            }
            return ds;
        }
        public DataSet spLlenarComboBox(string tabla, string columna)
        {
            DataSet ds = null;
            try
            {

                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, tabla, "TABLA"));
                datos.Add(new DatoSQL(TipoDato.String, columna, "COLUMNA"));

                ds = ejecutarProcedimientoAlmacenadoSimple("spLlenarComboBox", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ConsultaGenericaSQL - spLlenarComboBox");
            }
            return ds;
        }
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

        public DataSet spObtenerBusquedaTabla(string tabla, string busqueda)
        {
            DataSet ds = null;
            try
            {

                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, tabla, "TABLA"));
                datos.Add(new DatoSQL(TipoDato.String, busqueda, "BUSQUEDA"));


                ds = ejecutarProcedimientoAlmacenadoSimple("spObtenerBusquedaTabla", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ConsultaGenericaSQL - spObtenerBusquedaTabla");
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
        public void spInsertarDatoGenerico(string tabla, string valores)
        {
            try
            {

                List<DatoSQL> datos = new List<DatoSQL>();
                datos.Add(new DatoSQL(TipoDato.String, tabla, "TABLA"));
                datos.Add(new DatoSQL(TipoDato.String, valores, "VALORES"));

                ejecutarProcedimientoAlmacenadoSimple("spInsertarDatoGenerico", datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " ConsultaGenericaSQL - spInsertarDatoGenerico");
            }
            //return ds;
        }
    }
}
