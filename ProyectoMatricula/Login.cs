using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoMatricula.UtilidadesSQL;
namespace ProyectoMatricula
{
    public partial class Login : Form
    {
        Principal principal;
        LoginSQL loginSQL;
        public Login(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
            loginSQL = new LoginSQL();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            DataSet ds = loginSQL.spIniciarSesion(tbUser.Text, tbContrasena.Text);
            if (ds != null && ds.Tables.Count > 0 && (int)ds.Tables[0].Rows[0][0] > 0)
            {
                int rol = (int)ds.Tables[1].Rows[0][0];
                switch (rol)
                {
                    case 1:
                        principal.tipoUsuario = rol;
                        principal.setMenu(tbUser.Text, "Alumno");
                        break;
                    case 2:
                        principal.tipoUsuario = rol;
                        principal.setMenu(tbUser.Text, "Profesor");

                        break;
                    case 3:
                        principal.tipoUsuario = rol;
                        principal.setMenu(tbUser.Text, "Administrativo");

                        break;
                    case 4:
                        principal.tipoUsuario = rol;
                        principal.setMenu(tbUser.Text, "DBA");

                        break;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales Erroneas");
            }
        }
    }
}
