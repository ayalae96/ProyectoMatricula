using Microsoft.VisualBasic.ApplicationServices;
using ProyectoMatricula.CrudGenerico;
using ProyectoMatricula.UtilidadesSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMatricula
{
    public class PanelConsultaParametrosGenerico : TableLayoutPanel
    {
        public DataSet datosLlenado;
        int campos;
        public int columnasCampos;
        public int filasCampos;
        public List<Control> lstCampos;
        public List<Control> lstBotones;
        public List<string> lstColumnas;
        private string id;
        TableLayoutPanel pnlTRX;
        TableLayoutPanel pnlBotones;
        string tabla;
        List<Label> lstLabel;
        List<string> lstForaneos;
        /// <summary>
        /// Generara un panel con todos los datos y controles de una tabla
        /// </summary>
        /// <param name="tabla">Nombre de la tabla a consultar</param>
        public PanelConsultaParametrosGenerico(string tabla)
        {
            this.tabla = tabla;
            inicializarControl(tabla);
            establecerModoConsulta(ModoConsultaPanelGenerico.Crear);
            this.Refresh();
        }
        public PanelConsultaParametrosGenerico(string tabla, List<string> lstForaneos)
        {
            this.lstForaneos = lstForaneos;
            this.tabla = tabla;
            inicializarControl(tabla);
            establecerModoConsulta(ModoConsultaPanelGenerico.Crear);
            this.Refresh();
            darDatoForaneo(this.lstForaneos);
            this.Refresh();
        }
        //LLENAR TODO
        public PanelConsultaParametrosGenerico(string tabla, ModoConsultaPanelGenerico modo, string id)
        {
            this.tabla = tabla;
            this.id = id;
            inicializarControl(tabla);
            establecerModoConsulta(modo);
            this.Refresh();
        }
        //PARA LLENAR SOLO CIERTAS COLUMNAS
        public PanelConsultaParametrosGenerico(string tabla, ModoConsultaPanelGenerico modo, string id, List<string> lstColumnas)
        {
            this.id = id;
            inicializarControl(tabla);
            establecerModoConsulta(modo);
            this.Refresh();
            this.lstColumnas = lstColumnas;
        }

        public void darDatoForaneo(List<string> lstForaneos)
        {
            int pos = -1;
            string nombreColumna="";
            for(int i = 0; i < datosLlenado.Tables[1].Rows.Count; i++)
            {
                //MessageBox.Show(datosLlenado.Tables[1].Rows[i][2].ToString() +" TABLA "+ tablaForanea);
                if (string.Compare(datosLlenado.Tables[1].Rows[i][2].ToString(), lstForaneos[0]) == 0)
                {
                    nombreColumna = datosLlenado.Tables[1].Rows[i][1].ToString();
                    break;
                }
            }
            for (int i = 0; i < datosLlenado.Tables[2].Rows.Count; i++)
            {
                //MessageBox.Show(datosLlenado.Tables[2].Rows[i][0].ToString() + " COLUMNA " + nombreColumna);

                if (string.Compare(datosLlenado.Tables[2].Rows[i][0].ToString(), nombreColumna) == 0)
                {
                    pos = i;
                    break;
                }
            }


            if (pos < 0)
            {
                MessageBox.Show("No se encontro dato foraneo...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //if(lstCampos[pos] is ComboBox) MessageBox.Show("" + ((ComboBox)lstCampos[pos]).Items.Count);
                ComboBox c = ((ComboBox)lstCampos[pos]);
                c.SelectedItem = c.Items[obtenerComboValor(lstForaneos[0], c)];
                lstCampos[pos].Enabled = false;
            }
        }
        public CheckBox generarCheck(string nombre)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Text = nombre;
            checkBox.Size = TextRenderer.MeasureText(checkBox.Text, new Font("Arial", 11));
            checkBox.Margin = new Padding(2, 6, 0, 0);
            checkBox.FlatStyle = FlatStyle.Flat;
            //checkBox.CheckedChanged += CheckBox_CheckedChanged;
            return checkBox;
        }

        private void Quemar_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox obj = (CheckBox)sender;
                if (obj.Checked == true)
                {
                    quemarCampos();
                    
                }
                else
                {
                    activarCampos();
                }
                foreach(Control c in lstBotones)
                {
                    if(string.Compare(c.Text,"Actualizar") == 0)
                    {
                        c.Enabled = !c.Enabled;
                    }
                }
            }
        }

        

        public Button generarBotonFormato(string nombre, Color color, bool estado)
        {
            Button boton = new Button();
            boton.Text = nombre;
            boton.FlatStyle = FlatStyle.Flat;
            if(color != null) boton.BackColor = color;
            boton.Size = new Size(80, 23);
            boton.Enabled = estado;
            boton.Click += Boton_Click;
            return boton;
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            Button b = (Button )sender;
            if (string.Compare(b.Text, "Crear") == 0)
            {
                crearElemento();
            }
            else if(string.Compare(b.Text, "Actualizar") == 0)
            {
                actualizarElemento();
            }
            else if (string.Compare(b.Text, "Eliminar") == 0)
            {

            }
        }
        public void actualizarElemento()
        {
            bool valorVacio = false;
            string cadena = "";
            for (int i = 1; i < lstCampos.Count; i++)
            {

                if (lstCampos[i] is TextBox)
                {
                    if (String.IsNullOrEmpty(lstCampos[i].Text.Trim()))
                    {
                        MessageBox.Show("Campo *" + datosLlenado.Tables[2].Rows[i][0].ToString()
                            + "* esta vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstCampos[i].Focus();
                        valorVacio = true;
                        break;
                    }
                    cadena = cadena + valorarCampoElementoU(i, lstCampos[i].Text);
                }
                else if (lstCampos[i] is ComboBox)
                {
                    string str = lstCampos[i].Text.Substring(0, lstCampos[i].Text.IndexOf("|")).Trim();
                    cadena = cadena + valorarCampoElementoU(i, str);
                }
                else if (lstCampos[i] is DateTimePicker)
                {
                    cadena = cadena + datosLlenado.Tables[2].Rows[i][0].ToString() +" = '" + lstCampos[i].Text.ToString() + "'" + (i < campos ? ", " : "");
                }
            }
            if (valorVacio)
            {
                MessageBox.Show("No se procedera con la transaccion...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TipoDato tipoDato;
                if (string.Compare(datosLlenado.Tables[2].Rows[0][2].ToString(), "int") == 0)
                    tipoDato = TipoDato.Int;
                else
                    tipoDato = TipoDato.String;
                new ConsultaGenericaSQL().spActualizarDatoGenerico(tabla, id, cadena, tipoDato, datosLlenado.Tables[2].Rows[0][0].ToString());
                //MessageBox.Show(cadena);
            }
            System.Console.WriteLine(cadena);
            //spInsertarNuevoElemento(cadena)
        }
        public string valorarCampoElementoU(int i, string campo)
        {
            string cadena = "";

            string tipo = (string)datosLlenado.Tables[2].Rows[i][2];
            if (string.Compare(tipo, "int") == 0)
            {
                cadena = datosLlenado.Tables[2].Rows[i][0].ToString() + " = " + campo.Trim();
            }
            else
            if (string.Compare(tipo, "nvarchar") == 0 ||
                string.Compare(tipo, "varchar") == 0 ||
                string.Compare(tipo, "nchar") == 0)
            {
                cadena = datosLlenado.Tables[2].Rows[i][0].ToString() + " = '" + campo.Trim() + "'";
            }
            if (i < campos - 1) cadena = cadena + ", ";
            return cadena;
        }

        public void crearElemento()
        {
            bool valorVacio = false;
            string cadena = "";
            for(int i = 1; i < lstCampos.Count; i++)
            {

                if (lstCampos[i] is TextBox)
                {
                    if (String.IsNullOrEmpty(lstCampos[i].Text.Trim()))
                    {
                        MessageBox.Show("Campo *" + datosLlenado.Tables[2].Rows[i][0].ToString()
                            + "* esta vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstCampos[i].Focus();
                        valorVacio = true;
                        break;
                    }
                    cadena = cadena + valorarCampoElemento(i, lstCampos[i].Text);
                }else if (lstCampos[i] is ComboBox)
                {
                    string str = lstCampos[i].Text.Substring(0,lstCampos[i].Text.IndexOf("|")).Trim();
                    cadena = cadena + valorarCampoElemento(i, str);
                }
                else if (lstCampos[i] is DateTimePicker)
                {
                    cadena = cadena + "'" + lstCampos[i].Text.ToString()+ "'" + (i<campos ? ", " : "") ;
                }
            }
            if (valorVacio)
            {
                MessageBox.Show("No se procedera con la transaccion...","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                new ConsultaGenericaSQL().spInsertarDatoGenerico(tabla, cadena);
                //MessageBox.Show(cadena);
            }
            System.Console.WriteLine(cadena);
            //spInsertarNuevoElemento(cadena)
        }

        public string valorarCampoElemento(int i, string campo)
        {
            string cadena = "";
            
            string tipo = (string)datosLlenado.Tables[2].Rows[i][2];
            if (string.Compare(tipo, "int") == 0)
            {
                cadena = campo.Trim();
            }
            else
            if (string.Compare(tipo, "nvarchar") == 0 || 
                string.Compare(tipo, "varchar") == 0 ||
                string.Compare(tipo, "nchar") == 0 )
            {
                cadena = "'" + campo.Trim() + "'";
            }
            if (i < campos-1) cadena = cadena + ", ";
            return cadena; 
        }

        public void establecerModoConsulta(ModoConsultaPanelGenerico modo)
        {
            lstBotones = new List<Control> ();  
            switch(modo)
            {
                case ModoConsultaPanelGenerico.Crear:

                    lstBotones.Add(generarBotonFormato("Crear", Color.DeepSkyBlue,true));
                    CheckBox chActivar = generarCheck("Activar ID");
                    chActivar.CheckedChanged += activarID_CheckedChanged;
                    lstBotones.Add (chActivar);
                    MessageBox.Show("Ingrese los datos...");
                    break;
                case ModoConsultaPanelGenerico.Actualizar:
                    // llenar
                    llenarDatos();
                    lstBotones.Add(generarBotonFormato("Actualizar", Color.DeepSkyBlue, true));
                    chActivar = generarCheck("Activar ID");
                    chActivar.CheckedChanged += activarID_CheckedChanged;
                    lstBotones.Add(chActivar);
                    break;
                case ModoConsultaPanelGenerico.Leer:
                    // llenar y quemar
                    llenarDatos();
                    quemarCampos();
                    lstBotones.Add(generarBotonFormato("Actualizar", Color.DeepSkyBlue, false));
                    chActivar = generarCheck("Activar ID");
                    chActivar.CheckedChanged += activarID_CheckedChanged;
                    lstBotones.Add(chActivar);
                    CheckBox ch = new CheckBox();
                    ch = generarCheck("Bloquear");
                    ch.Checked = true;
                    ch.CheckedChanged += Quemar_CheckedChanged;
                    lstBotones.Add(ch);

                    break;
                case ModoConsultaPanelGenerico.Eliminar:
                    // llenar y quemar
                    llenarDatos();
                    quemarCampos();
                    lstBotones.Add(generarBotonFormato("Eliminar", Color.IndianRed, false));
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

        private void activarID_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox obj = (CheckBox)sender;
                if (obj.Checked == true)
                {
                    estadoID(true);
                }
                else
                {
                    estadoID(false);
                }
            }
            //throw new NotImplementedException();
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
            if (!lstCampos[0].Enabled)
                MessageBox.Show("Modificar este campo podria generar errores... Uselo con cuidado");
            lstCampos[0].Enabled= estado;
        }
        public void llenarDatos()
        {
            TipoDato tipoDato;
            if (string.Compare(datosLlenado.Tables[2].Rows[0][2].ToString(),"int")==0)
                tipoDato = TipoDato.Int;
            else
                tipoDato = TipoDato.String;
            //MessageBox.Show(tipoDato.ToString());
            DataSet ds = new ConsultaGenericaSQL()
                    .spObtenerDatoGenerico(this.tabla, this.id, datosLlenado.Tables[2].Rows[0][0].ToString(),tipoDato);
            darDatos(ds);
        }
        public void darDatos(DataSet ds)
        {
            for(int i = 0; i < lstCampos.Count; i++)
            {
                if (lstCampos[i] is TextBox)
                {
                    lstCampos[i].Text = ds.Tables[0].Rows[0][i].ToString();

                }
                if (lstCampos[i] is ComboBox)
                {
                    ComboBox c = lstCampos[i] as ComboBox;
                    //c.DataSource = c.DataSource;
                    //c.Refresh();
                    //if (c == null) MessageBox.Show(c.SelectedIndex + ds.Tables[0].Rows[0][i].ToString());

                    c.SelectedItem = c.Items[obtenerComboValor(ds.Tables[0].Rows[0][i].ToString(),c)];
                   
                }
                if (lstCampos[i] is DateTimePicker)
                {
                    ((DateTimePicker)lstCampos[i]).Text = ds.Tables[0].Rows[0][i].ToString();
                }
            }
        }

        public int obtenerComboValor(string id, ComboBox c)
        {
            for(int i = 0; i<c.Items.Count;i++)
            {
                if (string.Compare(((DataRowView)c.Items[i])[0].ToString(),id)== 0){
                    return i;
                }
            }
            return 1;
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
                obtenerDatosTabla(tabla);

                //obtenerDatosTabla(tabla, id);
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
        /// <summary>
        /// Insera los paneles internos de cada transaccion, y les asigna un control segun el tipo de dato.
        /// </summary>
        public void insertarPanelesInternos()
        {
            int contadorCampos = 0;
            this.lstLabel = new List<Label>();
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
                string nombreForaneo = (string) datosLlenado.Tables[1].Rows[i][1];
                string tipoDato = (string)datosLlenado.Tables[2].Rows[contadorCampo][2];
                //MessageBox.Show(nombreCampo + "-" + nombreForaneo);
                if (string.Compare(nombreCampo, nombreForaneo,StringComparison.Ordinal) == 0)
                {
                    ComboBox cb = new ComboBox();
                    DataSet comboDS = new ConsultaGenericaSQL().spLlenarComboBox((string)datosLlenado.Tables[1].Rows[i][2], nombreCampo);
                    if (comboDS.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("hola");

                        DataTable dt = comboDS.Tables[0];
                        string columnas = "";
                        int cols = comboDS.Tables[0].Columns.Count;
                        for (int s = 0; s < cols; s++)
                        {
                            columnas = columnas + comboDS.Tables[0].Columns[s].ColumnName ;
                            if(s<cols-2)
                            {
                                columnas = columnas + "+' | ' +";
                            }
                            else
                            {
                                if(s < cols - 1)
                                {
                                    columnas = columnas + "+' | ' +";  
                                }
                            }
                        }
                        //essageBox.Show(columnas);
                        cb.DropDownWidth = TextRenderer.MeasureText(columnas, new Font("Arial", 7)).Width; ;

                        dt.Columns.Add("FullName",
                                        typeof(string),
                                        columnas);
                        //da.Fill(dt);
                        cb.BindingContext = new BindingContext();
                        BindingSource bindingSource = new BindingSource();
                        bindingSource.DataSource = dt;
                        cb.DataSource = bindingSource;
                        cb.DisplayMember = "FullName";
                        cb.ValueMember = (string)comboDS.Tables[0].Columns[1].ColumnName;
                    }
                    cb.Margin = padding;
                    c = cb;
                    break;
                }
                else if(string.Compare(tipoDato, "date", StringComparison.Ordinal) == 0)
                {
                    DateTimePicker d = new DateTimePicker();
                    d.Format = DateTimePickerFormat.Custom;
                    d.CustomFormat = "yyyy-MM-dd";
                    d.Size = new Size(100, 20);
                    d.Margin = padding;
                    c = d;
                    break;
                }
                else
                {
                    c = new TextBox();
                    c.Margin = padding;
                    if (contadorCampo == 0) c.Enabled = false;
                }
            }
            lstCampos.Add(c);
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
            this.lstLabel.Add(l);
            return l;
        }



    }
}
