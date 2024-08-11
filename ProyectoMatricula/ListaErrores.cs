using ProyectoMatricula.UtilidadesSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatricula
{
    public partial class ListaErrores : Form
    {
        public ListaErrores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            if (tbBusqueda.Text.Length > 2)
            {
                ds = new ConsultaGenericaSQL().spObtenerBusquedaTabla("DB_Errors", "%"+tbBusqueda.Text+"%");
                if (ds != null) tblErrores.DataSource = ds.Tables[0];
            }
        }
    }
}
