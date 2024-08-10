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
    public partial class CreacionUsuario : Form
    {
        DataSet dsPersona;
        DataSet dsDatos;
        public CreacionUsuario(DataSet ds)
        {
            InitializeComponent();
            this.dsPersona = ds;

            //this.pnlParametros.Controls.Add(new ConsultaGenericaParametro("Rol"));
        }
        public CreacionUsuario() 
        {
            InitializeComponent();
            //this.dsPersona = ds;
        }

        private void CreacionUsuario_Load(object sender, EventArgs e)
        {
            var f = new PanelConsultaParametrosGenerico("Persona", CrudGenerico.ModoConsultaPanelGenerico.Crear);
            this.pnlParametros.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.Location = new Point(0, 0);
            f.Visible = true;
            this.Size = new System.Drawing.Size(280 * f.columnasCampos, 120 + (35 * f.filasCampos));
            Refresh();
        }

        private void pnlParametros_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
