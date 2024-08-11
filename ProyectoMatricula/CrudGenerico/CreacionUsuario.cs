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
            if(dsPersona != null)
            {
                PanelConsultaParametrosGenerico f = new PanelConsultaParametrosGenerico("Usuario");
                List<string> lst= new List<string>();
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
                PanelConsultaParametrosGenerico f = new PanelConsultaParametrosGenerico("Usuario",CrudGenerico.ModoConsultaPanelGenerico.Leer,"5");
                //f.darDatoForaneo("Persona", this.dsPersona.Tables[0].Rows[0][0].ToString());
                this.pnlParametros.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.Location = new Point(0, 0);
                f.Visible = true;
                this.Size = new System.Drawing.Size(280 * f.columnasCampos, 120 + (35 * f.filasCampos));
                Refresh();
            }

        }

        private void pnlParametros_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
