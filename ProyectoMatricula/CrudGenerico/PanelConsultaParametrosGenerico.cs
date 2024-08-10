using ProyectoMatricula.CrudGenerico;
using ProyectoMatricula.UtilidadesSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
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
        public List<Control> lstCampos;
        public List<Control> lstBotones;
        public List<string> lstColumnas;
        private string id;
        TableLayoutPanel pnlTRX;
        TableLayoutPanel pnlBotones;
        
        /// <summary>
        /// Generara un panel con todos los datos y controles de una tabla
        /// </summary>
        /// <param name="tabla">Nombre de la tabla a consultar</param>
        public PanelConsultaParametrosGenerico(string tabla)
        {

            inicializarControl(tabla);
            establecerModoConsulta(ModoConsultaPanelGenerico.Crear);
            this.Refresh();
        }
        public PanelConsultaParametrosGenerico(string tabla, ModoConsultaPanelGenerico modo, string id)
        {
            this.id = id;
            inicializarControl(tabla);
            establecerModoConsulta(modo);
            this.Refresh();
        }
        public PanelConsultaParametrosGenerico(string tabla, ModoConsultaPanelGenerico modo, string id, List<string> lstColumnas)
        {
            this.id = id;
            inicializarControl(tabla);
            establecerModoConsulta(modo);
            this.Refresh();
            this.lstColumnas = lstColumnas;
        }
        public Button generarBotonFormato(string nombre, Color color)
        {
            Button boton = new Button();
            boton.Text = nombre;
            boton.FlatStyle = FlatStyle.Flat;
            if(color != null) boton.BackColor = color;
            boton.Size = new Size(80, 23);
            return boton;
        }
        public void establecerModoConsulta(ModoConsultaPanelGenerico modo)
        {
            lstBotones = new List<Control> ();  
            switch(modo)
            {
                case ModoConsultaPanelGenerico.Crear:
                    MessageBox.Show("Ingrese los datos...");
                    lstBotones.Add(generarBotonFormato("Crear", Color.DeepSkyBlue));
                    break;
                case ModoConsultaPanelGenerico.Actualizar:
                    // llenar
                    llenarDatos();
                    break;
                case ModoConsultaPanelGenerico.Leer:
                    // llenar y quemar
                    llenarDatos();
                    quemarCampos();
                    break;
                case ModoConsultaPanelGenerico.Eliminar:
                    // llenar y quemar
                    llenarDatos();
                    quemarCampos();
                    break;
            }
            FlowLayoutPanel f = new FlowLayoutPanel();
            f.AutoSize = true;
            f.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            f.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom);
            foreach(Control c in lstBotones) f.Controls.Add(c);
            pnlBotones.Controls.Add(f);
            //centrarControles(lstBotones, pnlBotones);

        }
        public void quemarCampos()
        {
            foreach(Control c in lstCampos)
            {
                c.Enabled = false;
            }
        }
        public void activarCampos()
        {
            for (int i = 0; i < lstCampos.Count; i++)
            {
                if (i != 0) lstCampos[i].Enabled = true;
            }
        }

        public void estadoID(bool estado)
        {
            lstCampos[0].Enabled= estado;
        }
        public void llenarDatos()
        {

        }
        public void inicializarControl(string tabla)
        {
            lstCampos = new List<Control>();
            ;
            if (id == null )
            {
                obtenerDatosTabla(tabla);
            }
            else
            {
                obtenerDatosTabla(tabla, id);
            }
            inicializarDatos();
        }
        /// <summary>
        /// Llenado del dataset con todos los datos necesarios
        /// </summary>
        /// <param name="tabla"></param>
        public void obtenerDatosTabla(string tabla)
        {
            this.datosLlenado = new ConsultaGenericaSQL().spObtenerDatosTabla(tabla);
        }
        public void obtenerDatosTabla(string tabla, string id)
        {
            this.datosLlenado = new ConsultaGenericaSQL().spObtenerDatosTabla(tabla, id);
        }
        /// <summary>
        /// Metodo Inicializador.
        /// </summary>
        public void inicializarDatos()
        {
            iniciarPanelTransaccional();
            insertarPanelesInternos();
        }
        /// <summary>
        /// Se da formato al panel principal segun las conevenciones establecidas.
        /// </summary>
        public void iniciarPanelTransaccional()
        {
            //Atributos referenciales
            if (lstColumnas == null) 
            {
                campos = datosLlenado.Tables[0].Columns.Count; 
            } else 
            {
                campos = lstColumnas.Count; 
            }
            columnasCampos = 2;
            filasCampos = ((campos - (campos % columnasCampos)) / columnasCampos) + campos % columnasCampos;

            //Atributos TableLayoutPanel 
            this.ColumnCount = 1;
            this.RowCount = 2;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));

            this.pnlTRX = new TableLayoutPanel();
            this.pnlTRX.ColumnCount = columnasCampos;
            this.pnlTRX.RowCount = filasCampos + 1;
            for (int i = 0; i < columnasCampos; i++)
            {
                this.pnlTRX.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            for (int i = 0; i < filasCampos; i++)
            {
                this.pnlTRX.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            //this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));

            pnlTRX.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlTRX.Margin = new Padding(0);

            this.Controls.Add(pnlTRX, 0, 0);



            //Atributos Control 
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Size = new System.Drawing.Size(200 * columnasCampos, 30 * filasCampos);
            this.TabIndex = 0;
            this.Name = "pnlTabla";
            this.BackColor = Color.LightGray;
            this.Visible = true;
        }
       public void centrarControles(List<Control> ctls, Control container)
        {
            int w = container.ClientSize.Width;
            int marge = (w - ctls.Sum(x => x.Width)) / 2;
            Padding oldM = ctls[0].Margin;
            ctls.First().Margin = new Padding(marge, oldM.Top, oldM.Right, oldM.Bottom);
            ctls.Last().Margin = new Padding(oldM.Left, oldM.Top, oldM.Right, marge);
        }
        /// <summary>
        /// Insera los paneles internos de cada transaccion, y les asigna un control segun el tipo de dato.
        /// </summary>
        public void insertarPanelesInternos()
        {
            int contadorCampos = 0;
            
            for (int x = 0; x < columnasCampos; x++)
            {
                for (int y = 0; y < filasCampos && contadorCampos < campos ; y++)
                {
                    string nombreCampo;
                    if (lstColumnas == null)
                    {
                        nombreCampo = (string)datosLlenado.Tables[2].Rows[contadorCampos][0];
                    }
                    else
                    {
                        nombreCampo = lstColumnas[contadorCampos];
                    }

                    this.pnlTRX.Controls.Add(generarPanelInterno(nombreCampo, contadorCampos), x, y);
                    contadorCampos++;
                }
            }
            pnlBotones = new TableLayoutPanel();
            //pnlBotones.FlowDirection = FlowDirection.LeftToRight;
            pnlBotones.RowCount = 1;
            pnlBotones.ColumnCount = 1;
            pnlBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            pnlBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); 
            pnlBotones.Dock = DockStyle.Bottom;
            this.Controls.Add(pnlBotones, 0, 1);
            
        }

        /// <summary>
        /// Los paneles internos son paneles que se insertan en cada una de las "celdas" generadas del TableLayoutPanel principal
        /// de forma tal que si hay 2 filas y 2 columnas, se generen 4 paneles internos.
        /// Esta funcion, genera esos paneles de manera automatica y genera los controles correspondientes.
        /// -
        /// Ejemplo: 
        /// -
        ///     [Parametros de tabla SQL = 3]
        ///     
        ///     Si una tabla tiene 3 parametros, se generaran 2 filas y 2 columnas
        ///     Como son 3 campos solo se crearan 3 Labels y 3 controles correpondientes
        ///     Si no existe se quedara en blanco
        ///     +---------------------------------------------------------------------+
        ///     | CUALQUIER CONTENEDOR EXTERNO QUE INVOQUE ESTE CONTROL               |
        ///     | +-----------------------------------------------------------------+ |
        ///     | | +TABLELAYOUTPANLEPRINCIPAL+                                     | |
        ///     | | +-----------------------------+ +-----------------------------+ | |
        ///     | | | [TABLEPANLE INTERNO 1]      | | [TABLEPANLE INTERNO 2]      | | | 
        ///     | | | +-----------+ +-----------+ | | +-----------+ +------------+| | |
        ///     | | | |FLOWLAYOUT1| |FLOWLAYOUT2| | | |FLOWLAYOUT1| |FLOWLAYOUT2 || | |
        ///     | | | |+---------+| |+---------+| | | |+---------+| |+----------+|| | |
        ///     | | | || LABEL_1 || ||CONTROL_1|| | | || LABEL_2 || ||CONTROL_2 ||| | |
        ///     | | | |+---------+| |+---------+| | | |+---------+| |+----------+|| | |
        ///     | | | +-----------+ +-----------+ | | +-----------+ +------------+| | |
        ///     | | +-----------------------------+ +-----------------------------+ | |
        ///     | | +-----------------------------+ +-----------------------------+ | |
        ///     | | | [TABLEPANLE INTERNO 3]      | | [NULL]                      | | |   
        ///     | | | +-----------+ +-----------+ | |                             | | |
        ///     | | | |FLOWLAYOUT1| |FLOWLAYOUT2| | | [NO EXISTE CAMPO            | | |
        ///     | | | |+---------+| |+---------+| | | CORRESPONDIENTE]            | | |
        ///     | | | || LABEL_3 || ||CONTROL_3|| | |                             | | |
        ///     | | | |+---------+| |+---------+| | |                             | | |
        ///     | | | +-----------+ +-----------+ | |                             | | | 
        ///     | | +-----------------------------+ +-----------------------------+ | |
        ///     | +-----------------------------------------------------------------+ |
        ///     +---------------------------------------------------------------------+
        /// </summary>
        /// <param name="nombreCampo"></param>
        /// <param name="contadorCampos"></param>
        /// <returns> Panel a ser insertado</returns>
        public TableLayoutPanel generarPanelInterno(string nombreCampo, int contadorCampos)
        {
            
            TableLayoutPanel pnl = new TableLayoutPanel();
            pnl.RowCount = 1;
            pnl.ColumnCount = 2;
            pnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            pnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            pnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl.Margin = new Padding(0);

            Label label = generarLabel(nombreCampo, contadorCampos);
            Control campo = obtenerCampo(nombreCampo, contadorCampos);
            pnl.Controls.Add(generarFLayout(label), 0, 0);
            pnl.Controls.Add(generarFLayout(campo), 1, 0);
            return pnl;
        }
        /// <summary>
        /// Genera el contenedor del Label y el Control
        /// </summary>
        /// <param name="nombreCampo"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public FlowLayoutPanel generarFLayout(Control control)
        {
            FlowLayoutPanel flayout = new FlowLayoutPanel();

            flayout.FlowDirection = FlowDirection.LeftToRight;
            flayout.Margin = new Padding(0);
            flayout.Controls.Add(control);
            flayout.Dock = DockStyle.Fill;
            return flayout;
        }
        /// <summary>
        /// Genera el campo segun el tipo de dato
        /// </summary>
        /// <param name="nombreCampo"></param>
        /// <param name="contadorCampo"></param>
        /// <returns></returns>
        public Control obtenerCampo(string nombreCampo, int contadorCampo)
        {
            Padding padding = new Padding(0, 8, 0, 0);
            Control c = new Control();
            for (int i = 0; i < datosLlenado.Tables[1].Rows.Count; i++)
            {
                string nombreForaneo = (string) datosLlenado.Tables[1].Rows[0][i];
                string tipoDato = (string)datosLlenado.Tables[2].Rows[contadorCampo][2];
                if(string.Compare(nombreCampo, nombreForaneo,StringComparison.Ordinal) == 0)
                {
                    c = new ComboBox();
                    c.Margin = padding;
                }
                else if(string.Compare(tipoDato, "date", StringComparison.Ordinal) == 0)
                {
                    DateTimePicker d = new DateTimePicker();
                    d.Format = DateTimePickerFormat.Custom;
                    d.CustomFormat = "dd-MM-yyyy";
                    d.Size = new Size(100, 20);
                    d.Margin = padding;
                    c = d;
                }
                else
                {
                    c = new TextBox();
                    c.Margin = padding;
                    if (contadorCampo == 0) c.Enabled = false;
                }
            }
            return c;

        }
        /// <summary>
        /// Genera el label correspondiente
        /// </summary>
        /// <param name="nombreCampo"></param>
        /// <param name="contadorCampos"></param>
        /// <returns></returns>
        public Label generarLabel(string nombreCampo , int contadorCampos)
        {
            Label l = new Label();
            l.Margin = new Padding(0, 10, 0, 0);
            l.Text = nombreCampo + ":";
            string nulo = (string)datosLlenado.Tables[2].Rows[contadorCampos][1];

            if (string.Compare(nulo, "NO", StringComparison.Ordinal) == 0)
            {
                l.Text = "*" + l.Text;
                l.Font = new Font(l.Font, l.Font.Style & ~FontStyle.Bold);
            }

            return l;
        }



    }
}
