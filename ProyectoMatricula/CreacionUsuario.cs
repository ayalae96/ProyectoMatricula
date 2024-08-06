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
        DataSet ds;
        public CreacionUsuario(DataSet ds)
        {
            InitializeComponent();
            this.ds = ds;
        }
        public CreacionUsuario() { }
    }

}
