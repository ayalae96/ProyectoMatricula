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
    public partial class Login : Form
    {
        Principal principal;
        public Login(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.tbUser.Text == "userdba")
            {
                this.principal.tipoUsuario = 4;
                this.principal.setMenu();
                this.Close();
            }
            if (this.tbUser.Text == "userAlumno")
            {
                this.principal.tipoUsuario = 1;
                this.principal.setMenu();
                this.Close();
            }
            if (this.tbUser.Text == "userProfe")
            {
                this.principal.tipoUsuario = 2;
                this.principal.setMenu();
                this.Close();
            }
            if (this.tbUser.Text == "userAdmi")
            {
                this.principal.tipoUsuario = 3;
                this.principal.setMenu();
                this.Close();
            }
        }
    }
}
