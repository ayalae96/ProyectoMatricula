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
    public partial class AsignarRoles : Form
    {
        public AsignarRoles()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            if (tbBusqueda.Text.Length > 2)
            {
                ds = new ConsultaRolSQL().spBuscarUsuariosRoles("%" + tbBusqueda.Text + "%");
                if (ds != null) tblUsuario.DataSource = ds.Tables[0];
            }
        }

        private void tblUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                DataGridViewRow row = tblUsuario.CurrentRow;
                llenarDatos(row);
            }
        }

        public void llenarDatos(DataGridViewRow row)
        {
            lblId.Text = row.Cells[0].Value.ToString();
            tbUsuario.Text = row.Cells[1].Value.ToString();
            tbRolActual.Text = row.Cells[2].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new ConsultaRolSQL().spCambiarRol(cbNuevoRol.SelectedIndex + 1, Int32.Parse(lblId.Text));
            DataSet ds = new ConsultaRolSQL().spBuscarUsuariosRoles("%" + tbUsuario.Text + "%");
            if (ds != null) tblUsuario.DataSource = ds.Tables[0];
        }
    }
}
