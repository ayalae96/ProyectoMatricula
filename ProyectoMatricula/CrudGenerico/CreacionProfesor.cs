using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatricula.CrudGenerico
{
    public partial class CreacionProfesor : Form
    {
        DataSet dsPersona;
        public CreacionProfesor(DataSet ds)
        {
            this.dsPersona = ds;
            InitializeComponent();
        }
        public CreacionProfesor()
        {
            InitializeComponent();
        }

        private void CreacionProfesor_Load(object sender, EventArgs e)
        {
            if (dsPersona != null)
            {
                PanelConsultaParametrosGenerico f = new PanelConsultaParametrosGenerico("Profesor");
                List<string> lst = new List<string>();
                lst.Add("Persona");
                lst.Add(this.dsPersona.Tables[0].Rows[0][0].ToString());
                f.darDatoForaneo(lst);
                this.pnlParametros.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Location = new Point(0, 0);
                f.Visible = true;
                this.Size = new System.Drawing.Size(280 * f.columnasCampos, 120 + (35 * f.filasCampos));
                Refresh();
            }
            else
            {
                PanelConsultaParametrosGenerico f = new PanelConsultaParametrosGenerico("Usuario", CrudGenerico.ModoConsultaPanelGenerico.Leer, "5");
                //f.darDatoForaneo("Persona", this.dsPersona.Tables[0].Rows[0][0].ToString());
                this.pnlParametros.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Location = new Point(0, 0);
                f.Visible = true;
                this.Size = new System.Drawing.Size(280 * f.columnasCampos, 120 + (35 * f.filasCampos));
                Refresh();
            }
        }
    }
}
