using ProyectoMatricula.UtilidadesSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatricula
{
    public class PanelConsultaParametrosGenerico : TableLayoutPanel
    {
        DataSet datosLlenado;
        int campos;
        public int columnasCampos;
        public int filasCampos;

        public PanelConsultaParametrosGenerico(string tabla)
        {
            this.datosLlenado = new ConsultaGenericaSQL().spObtenerDatosTabla(tabla);
            inicializarDatos();
            this.Refresh();
        }

        public void inicializarDatos()
        {
            generarPanel();
            insertarPanelesDefault();
        }
        public void insertarPanelesDefault()
        {
            int camposRestantes = campos;
            int contadorCampos = 0;
            for (int x = 0; x < columnasCampos; x++)
            {
                for (int y = 0; y < filasCampos && contadorCampos<campos ; y++)
                {
                    string nombreCampo = (string)datosLlenado.Tables[2].Rows[contadorCampos][0];

                    var campo = obtenerCampo(nombreCampo);
                    Label l = new Label();
                    l.Margin = new Padding(0, 8, 0, 0);

                    l.Text = nombreCampo;
                    TableLayoutPanel pnl = new TableLayoutPanel();
                    pnl.RowCount = 1;
                    pnl.ColumnCount = 2;
                    pnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
                    pnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
                    pnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
                    pnl.Dock = System.Windows.Forms.DockStyle.Fill;

                    FlowLayoutPanel flayout1 = new FlowLayoutPanel();
                    FlowLayoutPanel flayout2 = new FlowLayoutPanel();
                    flayout1.FlowDirection = FlowDirection.RightToLeft;
                    flayout2.FlowDirection = FlowDirection.LeftToRight;
                    //flayout1.BorderStyle = BorderStyle.FixedSingle;
                    //flayout2.BorderStyle = BorderStyle.FixedSingle;
                    flayout1.Margin = new Padding(0);
                    flayout2.Margin = new Padding(0);
                    flayout1.Controls.Add(l);
                    flayout2.Controls.Add(campo);
                    pnl.Controls.Add(flayout1, 0, 0);
                    pnl.Controls.Add(flayout2, 1, 0);
                    pnl.Margin = new Padding(0);
                    flayout1.Dock = DockStyle.Fill;
                    flayout2.Dock = DockStyle.Fill;
                    this.Controls.Add(pnl, x, y);
                    
                    contadorCampos++;
                }
                contadorCampos++;
            }
        }
        public Control obtenerCampo(string nombreCampo)
        {
            for(int i = 0; i < datosLlenado.Tables[1].Rows.Count; i++)
            {
                string nombreForaneo = (string) datosLlenado.Tables[1].Rows[0][i];
                if(string.Compare(nombreCampo, nombreForaneo,StringComparison.Ordinal) == 0)
                {
                    return new ComboBox();
                }
            }
            return new TextBox();
        }
        public void generarPanel()
        {
            campos = datosLlenado.Tables[0].Columns.Count;
            columnasCampos = 2;
            filasCampos = (campos - (campos % columnasCampos)) / columnasCampos;
            //this = new System.Windows.Forms.TableLayoutPanel();
            //this.SuspendLayout();
            // 
            // pnlTabla
            // 
            MessageBox.Show("x =" + columnasCampos + " y =" + filasCampos + "General =" + campos);
            this.ColumnCount = columnasCampos;
            this.RowCount = filasCampos + 1;
            for (int i = 0; i < columnasCampos; i++)
            {
                this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            for (int i = 0; i < filasCampos; i++)
            {
                this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));

            this.Dock = System.Windows.Forms.DockStyle.Fill;
            //thisLocation = new System.Drawing.Point(0, 0);
            //this.pnlTabla.Size = new System.Drawing.Size(200 * columnasCampos, 40 * filasCampos);
            this.Size = new System.Drawing.Size(200 * columnasCampos, 30 * filasCampos);
            this.TabIndex = 0;
            this.Name = "pnlTabla";
            this.BackColor = Color.LightGray;
            this.Visible = true;

            //this.ResumeLayout(false);
        }


    }
}
