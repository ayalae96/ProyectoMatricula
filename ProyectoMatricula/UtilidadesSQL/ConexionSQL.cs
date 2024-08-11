using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoMatricula.UtilidadesSQL;


namespace ProyectoMatricula
{
    public class ConexionSQL
    {
        //private string sql;
        public SqlConnection conexion;
        public ConexionSQL()
        {
            try
            {
                conexion = new SqlConnection("server=EDUARDO-UG\\DB001 ;" +
                    " database=Matricula-te ; integrated security = true ; Encrypt=False");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void abrir()
        {
            conexion.Open();
        }
        public void cerrar()
        {
            conexion.Close();
        }

        public DataSet ejecutarProcedimientoAlmacenadoSimple(string nombreSP, List<DatoSQL> lstDato)
        {
            abrir();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand sqlCmd = new SqlCommand(nombreSP, this.conexion);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            if (lstDato.Count > 0)
            {
                foreach (DatoSQL datoSQL in lstDato)
                {
                    switch (datoSQL.TipoDato)
                    {
                        case TipoDato.Int:
                            sqlCmd.Parameters.AddWithValue("@" + datoSQL.VariableSQL, Int32.Parse(datoSQL.VariableLocal.ToString()));
                            //MessageBox.Show(Int32.Parse(datoSQL.VariableLocal.ToString()) + "");
                            break;
                        case TipoDato.String:
                            sqlCmd.Parameters.AddWithValue("@" + datoSQL.VariableSQL, (string)datoSQL.VariableLocal);
                            //MessageBox.Show("@" + datoSQL.VariableSQL + (string)datoSQL.VariableLocal);

                            break;
                        case TipoDato.Decimal:
                            sqlCmd.Parameters.AddWithValue("@" + datoSQL.VariableSQL, (decimal)datoSQL.VariableLocal);
                            break;
                    }
                }
            }
            //sqlCmd.ExecuteNonQuery(); Genera duplicados...
            da.SelectCommand = sqlCmd;
            da.Fill(ds);
            cerrar();
            return ds;
        }

    }
}

