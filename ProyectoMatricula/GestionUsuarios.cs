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
    public partial class GestionUsuarios : Form
    {
        private GestionUsuarioSQL gestionUsuariosSQL;
        string usuario;
        public GestionUsuarios(string usuario)
        {
            InitializeComponent();
            gestionUsuariosSQL = new GestionUsuarioSQL();
            rbCedula.Checked = true;
            this.usuario = usuario;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(rbNombre.Checked)
            {
                rbCedula.Checked = false;
                rbUsuario.Checked = false;
            }


        }

        private void rbCedula_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCedula.Checked)
            {
                rbNombre.Checked = false;
                rbUsuario.Checked = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(rbUsuario.Checked)
            {
                rbNombre.Checked = false;
                rbCedula.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            if (tbBusqueda.Text.Length > 2)
            {
                if (rbCedula.Checked)
                {
                    ds = gestionUsuariosSQL.spObtenerBusquedaUsuariosPorCedula(tbBusqueda.Text);
                }
                if (rbNombre.Checked)
                {
                    ds = gestionUsuariosSQL.spObtenerBusquedaUsuariosPorNombre(tbBusqueda.Text);
                }
                if (rbUsuario.Checked)
                {
                    ds = gestionUsuariosSQL.spObtenerBusquedaUsuariosPorUsuario(tbBusqueda.Text);
                }
                if(ds != null) tblUsuarios.DataSource = ds.Tables[0];
            }

        }

        private void GestionUsuarios_Shown(object sender, EventArgs e)
        {
            tbBusqueda.Focus();
        }

        private void tblUsuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(tblUsuarios.SelectedRows.Count > 0)
            {
                int idUsuario = (int)tblUsuarios.SelectedRows[0].Cells[0].Value;
                string usuario = (string)tblUsuarios.SelectedRows[0].Cells[4].Value;
                DialogResult res = MessageBox.Show("¿Desea eliminar el usuario: "+usuario+"?", "Eliminar Usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    if(string.Compare(usuario,this.usuario,StringComparison.Ordinal) == 0)
                    {
                        MessageBox.Show("No puede eliminarse el usuario del propio DBA");
                    }
                    else
                    {
                        
                        if(gestionUsuariosSQL.spEliminarUsuario(usuario, idUsuario))
                        {
                            foreach (DataGridViewRow row in tblUsuarios.SelectedRows)
                            {
                                tblUsuarios.Rows.RemoveAt(row.Index);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el usuario...");
                        }

                    }

                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea crear usuario a una persona ya exitente?", " Creacion Usuario ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                var dialog = new ConsultarPersonaExistente();
                dialog.ShowDialog();
                DataSet ds = dialog.Ds;
                var creacion = new CreacionUsuario(ds);
                creacion.ShowDialog();
            }
            else
            {
                this.ShowDialog(new CreacionUsuario());
            }
        }
    }
}
