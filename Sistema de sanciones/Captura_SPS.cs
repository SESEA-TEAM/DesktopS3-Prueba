using Sistema_de_sanciones.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_sanciones.Modelo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Security.Policy;

namespace Sistema_de_sanciones
{
    
    public partial class Captura_SPS : Form
    {
        //declaramos una instancia del controlador de servidores sancionados para poder acceder a sus funciones facilmente
        controlador1SPS conSPS = new controlador1SPS();
        //variables para ayudar a guardar las fechas
        String? f1, f2, f3, f4;
        //declaramos una instancia del modelo de servidores sancionados para facilitar el uso del objeto
        private ServidorPublico ServidorP = new ServidorPublico();
        //creamos un handler de el form 2 que es nuestro menu principal para posteriormente asignarle una instancia de este y poder acceder a sus funciones
        private Form2 form2Handler;

        //declaramos listas que usaremos en el formulario con ayuda de sus controladores respectivos
        List<modeloTipoDocumento> lDocumentos = new controladorTipoDocumento().obtenerListaDocumentos();
        List<modeloTipoSancion> lSancion = new controladorTipoSancion().obtenerListaSanciones();

        //definimos que para llamar a este form se debe de mandar una instancia del form 2 que es el menu principal, desde donde este será llamado
        public Captura_SPS(Form2 form2)
        {
            //llamamos a funciones que ayudan a que el formulario funcione correctamente
            InitializeComponent();
            llenarCombos();
            CargarDG();

            //asignamos una hora por defecto a los datetimepickers
            dateTimePicker1.Value = new DateTime(2000, 01, 01);
            dateTimePicker2.Value = new DateTime(2000, 01, 01);
            dateTimePicker3.Value = new DateTime(2000, 01, 01);
            dateTimePicker4.Value = new DateTime(2000, 01, 01);

            //asignamos la instancia que llega al mandar a llamar este form a nuestro handler para poder usarlo correctamente en el resto de la ejecucion de este form
            form2Handler = form2;
            
        }

        private void textBox29_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //funcion para cargar la lista de usuarios al combobox
        private void llenarCombos()
        {
            //asigna la lista de genero al combobox 2
            comboBox2.DataSource = new controladorListaGenero().obtenerListaGenero();
            comboBox2.ValueMember = "valor";

            //asigna la lista de faltas al combobox 3
            comboBox3.DataSource = new controladorTipoFalta().obtenerListaFaltas();
            comboBox3.ValueMember = "valor";

            //asigna la lista de monedas al combobox 4
            comboBox4.DataSource = new controladorMoneda().obtenerListaMonedas();
            comboBox4.ValueMember = "valor";

            //asigna la lista de documentos al combobox 5
            comboBox5.DataSource = lDocumentos;
            comboBox5.ValueMember = "tipoDocumento";

            //asigna la lista de sanciones al combobox 6
            comboBox6.DataSource = lSancion;
            comboBox6.ValueMember = "valor";

        }
        //da formato al datagridview de sanciones
        private void CargarDG()
        {
            //para asignar los tamaños de las columnas se toma como referencia el tamaño de un panel para que la resolucion de la pantalla donde se esta ejecutando no afecte a como se ven las columnas
            int p = panel3.Width;
            //se llama al datagrid y a la columna (estos ya fueron declarados en las propiedades del datagrid), despues con la propiedad de width (ancho) se le asigna un porcentaje del tamaño del panel de referencia
            dataGridView1.Columns[1].Width = (Convert.ToInt32(p * 0.46));
            dataGridView1.Columns[2].Width = (Convert.ToInt32(p * 0.45));

            int p2 = panel9.Width;

            dataGridView2.Columns[1].Width = (Convert.ToInt32(p2 * 0.16));
            dataGridView2.Columns[2].Width = Convert.ToInt32(p2 * 0.16);
            dataGridView2.Columns[3].Width = Convert.ToInt32(p2 * 0.21);
            dataGridView2.Columns[4].Width = Convert.ToInt32(p2 * 0.22);
            dataGridView2.Columns[5].Width = Convert.ToInt32(p2 * 0.16);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //boton para agregar sanciones
        private void button1_Click(object sender, EventArgs e)
        {
            //comprueba que se haya seleccionado un tipo de sancion
            if (comboBox6.Text == "Tipo Sanción")
            {
                //se muestra un error de que es requerido
                errorProvider1.SetError(comboBox6, "Se necesita seleccionar un tipo de sanción");
            }  
            else
            {
                //si la sancion va sin descripcion
                if(textBox22.Texts == "Descripción")
                {
                    //se declara un modelo de sancion y se le asigna el selecionado en el combobox 6
                    modeloTipoSancion sn = (modeloTipoSancion)comboBox6.SelectedItem;
                    //se agregan los valores al datagrid
                    dataGridView1.Rows.Add(Convert.ToString(sn.id), comboBox6.Text);
                    //se resetean los campos
                    textBox22.Texts = "Descripción";
                    comboBox6.SelectedItem = lSancion[0];
                }
                //si la sancion va con descripcion
                else
                {
                    //se declara un modelo de sancion y se le asigna el selecionado en el combobox 6
                    modeloTipoSancion sn = (modeloTipoSancion)comboBox6.SelectedItem;
                    //se agregan los valores al datagrid
                    dataGridView1.Rows.Add(Convert.ToString(sn.id), comboBox6.Text, textBox22.Texts);
                    //se resetean los campos
                    textBox22.Texts = "Descripción";
                    comboBox6.SelectedItem = lSancion[0];
                }
                
            }
        }

        //funcion de guardar particular
        private bool guardar()
        {
            //La siguiente lista de Regex es para todos aquellos campos que sean obligatorios. 
            Regex nombre = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchN = nombre.Match(textBox1.Texts);
            Regex apellidoP = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchP = apellidoP.Match(textBox2.Texts);
            Regex RFC = new Regex(@"^([A-ZÑ&]{4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$");
            Match matchR = RFC.Match(textBox4.Texts);
            Regex CURP = new Regex(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$");
            Match matchC = CURP.Match(textBox5.Texts);
            Regex URLS = new Regex(@"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$");
            Match matchU = URLS.Match(textBox10.Texts);
            Regex apellidoM = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchM = apellidoM.Match(textBox3.Texts);
            
            //variable de ayuda para el resultado
            bool valor = true;
            
            //Se comprueba que los campos obligatorios tengan algun valor asignado
            if (textBox1.Texts == "Nombre(s)*" || textBox2.Texts == "Primer apellido*" || textBox4.Texts == "RFC*" || textBox5.Texts == "CURP*" || textBox7.Texts == "Expediente*" || textBox25.Texts == "Puesto nombre*" || textBox15.Texts == "Nombre*" || textBox16.Texts == "Autoridad sancionadora*" || textBox9.Texts == "Causa, motivo o hechos*" || comboBox3.Text == "Tipo falta")
            {
                //mensaje de que se necesitan terminar de llenar los campos obligatorios
                MessageBox.Show("Debe completar los campos obligatorios para poder hacer el registro");
                valor = false;
            }
            else
            {
                //se comprueba que hay al menos una sancion
                if (dataGridView1.Rows.Count <= 0)
                {
                    //mensaje de error de sanciones
                    MessageBox.Show("Necesita asignar al menos una sanción al registro");
                    valor = false;
                }
                else
                {
                    /*
                     * Los condicionales con match son para saber que los datos de los textbox cumplan con los estandares requeridos
                     */
                    if (matchN.Success)
                    {
                        errorProvider1.SetError(textBox1, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox1, "Se necesita un nombre válido");
                        valor = false;
                    }
                    if (matchP.Success)
                    {
                        errorProvider1.SetError(textBox2, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox2, "Se necesita un apellido válido");
                        valor = false;
                    }
                    if (matchR.Success)
                    {
                        errorProvider1.SetError(textBox4, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox4, "Se necesita un RFC válido");
                        valor = false;
                    }
                    if (matchC.Success)
                    {
                        errorProvider1.SetError(textBox5, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox5, "Se necesita un CURP válido");
                        valor = false;
                    }
                    /*
                     * se toman los valores de las fechas si es que estas han cambiado del valor por default
                     */
                    if (dateTimePicker1.Text == "2000-01-01")
                    {
                        f1 = null;
                    }
                    else
                    {
                        f1 = dateTimePicker1.Text;
                    }
                    if (dateTimePicker2.Text == "2000-01-01")
                    {
                        f2 = null;
                    }
                    else
                    {
                        f2 = dateTimePicker2.Text;
                    }
                    if (dateTimePicker3.Text == "2000-01-01")
                    {
                        f3 = null;
                    }
                    else
                    {
                        f3 = dateTimePicker3.Text;
                    }

                    //se toman los items de los combobox correspondientes
                    modeloListaGenero gn = (modeloListaGenero)comboBox2.SelectedItem;
                    modeloTipoFalta fl = (modeloTipoFalta)comboBox3.SelectedItem;
                    modeloMoneda mn = (modeloMoneda)comboBox4.SelectedItem;

                    //se declara un servidor publico para asignarle los valores
                    modeloSPS modSPS = new modeloSPS();

                    /*
                     * se asignan los atributos a los que si se les han ingresado valores
                     * se comprueba si el campo tiene el valor default, de no ser asi se asigna el valor al particular
                     * en caso de que el atributo tenga algun tipo de formato requerido se comprueba que este sea correcto
                     */
                    if (gn.Id == 0)
                    {

                    }
                    else
                    {
                        modSPS.generoSPS = Convert.ToInt32(gn.Id);
                    }
                    if (mn.Id == 0)
                    {

                    }
                    else
                    {
                        modSPS.monedaMulta = Convert.ToInt32(mn.Id);
                    }
                    if (textBox3.Texts == "Segundo apellido")
                    {

                    }
                    else
                    {
                        if (matchM.Success)
                        {
                            modSPS.segundoApellidoSPS = textBox3.Texts;
                            errorProvider1.SetError(textBox3, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox3, "Se necesita un apellido válido");
                            valor = false;
                        }
                    }
                    if (textBox6.Texts == "Puesto nivel")
                    {

                    }
                    else
                    {
                        modSPS.nivelSPS = textBox6.Texts;
                    }
                    if (textBox13.Texts == "Siglas")
                    {

                    }
                    else
                    {
                        modSPS.siglasInstitucionDependencia = textBox13.Texts;
                    }
                    if (textBox14.Texts == "Clave")
                    {

                    }
                    else
                    {
                        modSPS.claveInstitucionDependencia = textBox14.Texts;
                    }
                    if (textBox11.Texts == "Descripción")
                    {

                    }
                    else
                    {
                        modSPS.descripcionFalta = textBox11.Texts;
                    }
                    if (textBox12.Texts == "Observaciones")
                    {

                    }
                    else
                    {
                        modSPS.observaciones = textBox12.Texts;
                    }
                    if (textBox10.Texts == "URL")
                    {

                    }
                    else
                    {
                        if (matchU.Success)
                        {
                            modSPS.urlResolucion = textBox10.Texts;
                            errorProvider1.SetError(textBox10, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox10, "Se necesita un apellido válido");
                            valor = false;
                        }
                    }
                    if (textBox19.Texts == "Plazo")
                    {

                    }
                    else
                    {
                        modSPS.plazoInhabilitacion = textBox19.Texts;
                    }
                    if (textBox21.Texts == "Monto")
                    {

                    }
                    else
                    {
                        modSPS.montoMulta = Convert.ToInt32(textBox21.Texts);
                    }

                    //los campos que son obligatorios se asignan sin condicional, ya que se comprobo que estos tuvieran informacion en un inicio
                    modSPS.nombreSPS = textBox1.Texts;
                    modSPS.primerApellidoSPS = textBox2.Texts;
                    modSPS.rfcSPS = textBox4.Texts;
                    modSPS.curpSPS = textBox5.Texts;
                    modSPS.expediente = textBox7.Texts;
                    modSPS.puestoSPS = textBox25.Texts;
                    modSPS.nombreInstitucionDependencia = textBox15.Texts;
                    modSPS.autoridadSancionadora = textBox16.Texts;
                    modSPS.causaMotivoHechos = textBox9.Texts;
                    modSPS.tipoFalta = fl.Id;

                    //con las fechas ya se comprobo si tienen o no un valor, de no tener se quedan con valor null, asi que estas variables se asignan siempre a lo atributos
                    modSPS.fechaResolucion = f2;
                    modSPS.fechaInicialInhabilitacion = f1;
                    modSPS.fechaFinalInhabilitacion = f3;

                    //si la variable de valor no ha cambado de valor, significa que todos los atributos necesarios estan llenos y con formato correcto 
                    if (valor == true)
                    {
                        //se guarda el particular
                        conSPS.guardarSPS(modSPS);

                        //se guardan las sanciones
                        foreach (DataGridViewRow fila in dataGridView1.Rows)
                        {
                            conSPS.guardarSancionSPS(Convert.ToInt16(fila.Cells["ID"].Value), Convert.ToString(fila.Cells["Descripcion"].Value));
                        }

                        //se guardan los documentos
                        foreach (DataGridViewRow fila2 in dataGridView2.Rows)
                        {
                            conSPS.guardarDocumentoSPS(Convert.ToInt16(fila2.Cells["idxd"].Value), Convert.ToString(fila2.Cells["Titulo"].Value), Convert.ToString(fila2.Cells["descripcionxd"].Value), Convert.ToString(fila2.Cells["URL"].Value), Convert.ToString(fila2.Cells["Fecha"].Value));
                        }
                    }
                    else
                    {
                        //mensaje de error cuando los atributos necesarios no estan llenos o con formato correcto
                        MessageBox.Show("Debe completar los campos obligatorios para poder hacer el registro");
                    }
                }
            }
            return valor;
        }

        //boton de guardar
        private void button4_Click(object sender, EventArgs e)
        {
            //si la funcion de guardar devuelve un valor verdadero
            if (guardar())
            {
                //se manda un aviso de que la operacion se realizo con exito y manda a la ventana de listado
                MessageBox.Show("Se ha realizado el registro con exito");
                form2Handler.ListaSPS();
            }
        }

        //agregar documentos
        private void button2_Click(object sender, EventArgs e)
        {
            //Este regex solo se activara si se coloca una url en el apartado de los documentos, por lo que si se deja vacio, no
            //saltara ningun mensaje de error, a menos que se coloque algo sobre alguno de los campos de documentos.
            Regex URLS = new Regex(@"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$");

            Match match = URLS.Match(textBox20.Texts);
            //pasa la fecha ingresada a la variable f4
            if (dateTimePicker4.Text == "2000-01-01")
            {
                f4 = null;
            }
            else
            {
                f4 = dateTimePicker4.Text;
            }
            //comprueba que se haya introducido un tipo de documento
            if (comboBox5.Text == "Tipo Documento")
            {
                errorProvider1.SetError(comboBox5, "Se necesita seleccionar un tipo de documento");
            }
            else
            {
                //comprueba que se haya introducido un titulo del documento
                if(textBox23.Texts == "Título*")
                {
                    errorProvider1.SetError(textBox23, "Se necesita introducir el título del documento");
                }
                else
                {
                    //comprueba que se haya introducido una descripcion del documento
                    if(textBox29.Texts == "Descripción*")
                    {
                        errorProvider1.SetError(textBox29, "Se necesita introducir la descripción del documento");
                    }
                    else
                    {
                        //comprueba que se haya introducido una url del documento
                        if (textBox20.Texts == "URL*")
                        {
                            errorProvider1.SetError(textBox20, "Se necesita introducir el URL del documento");
                        }
                        //comprueba que la url introducida tenga un formato valido
                        else if (!match.Success)
                        {
                            errorProvider1.SetError(textBox20, "Ingrese un URL válido");
                        }
                        else
                        {
                            //comprueba que la fecha introducida del documento sea valida
                            if (f4 == null)
                            {
                                errorProvider1.SetError(dateTimePicker4, "Se necesita introducir una fecha válida");
                            }
                            else
                            {
                                //se guarda el tipo de documento en un modelo
                                modeloTipoDocumento dc = (modeloTipoDocumento)comboBox5.SelectedItem;
                                //se agregan los valores del documento a la tabla
                                dataGridView2.Rows.Add(Convert.ToString(dc.Id), textBox23.Texts, comboBox5.Text, textBox29.Texts, textBox20.Texts, dateTimePicker4.Text);
                                //se resetean los campos
                                textBox23.Texts = "Título*";
                                textBox29.Texts = "Descripción*";
                                textBox20.Texts = "URL*";
                                dateTimePicker4.Value = new DateTime(2000, 01, 01);
                                comboBox5.SelectedItem = lDocumentos[0];
                            }
                        }
                    }
                }
            }
            
        }

        private void Captura_SPS_Load(object sender, EventArgs e)
        {
            //al cargar el form se agregan 2 columnas con combre a los datagrid que serviran como botones
            
            int p = panel3.Width;
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "quitar";
            Ver.Name = "quitar";
            Ver.Width = Convert.ToInt32(p * 0.095);
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);
            //dataGridView2.Columns.Add(Ver);
            int p2 = panel9.Width;
            DataGridViewButtonColumn Ver2 = new DataGridViewButtonColumn();
            Ver2.HeaderText = "quitar";
            Ver2.Name = "quitar";
            Ver2.Width = Convert.ToInt32(p2 * 0.095);
            Ver2.FlatStyle = FlatStyle.Flat;
            dataGridView2.Columns.Add(Ver2);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //pintamos la celda con el icono de basura
            if (e.ColumnIndex == 3)
            {
                Image someImage = Properties.Resources.basura;

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.basura.Width;
                var h = Properties.Resources.basura.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //accion de cuando la celda es presionada
            if (dataGridView1.Columns[e.ColumnIndex].Name == "quitar")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow); //Se elimina la fila seleccionada del DataGridView.
 
                }
            }
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //pintamos la celda con el icono de basura
            if (e.ColumnIndex == 6)
            {
                Image someImage = Properties.Resources.basura;

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.basura.Width;
                var h = Properties.Resources.basura.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //accion de cuando la clda es presionada
            if (dataGridView2.Columns[e.ColumnIndex].Name == "quitar")
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    dataGridView2.Rows.Remove(dataGridView2.CurrentRow); //Se elimina la fila seleccionada del DataGridView.

                }
            }
        }

        /*
         * Estas funciones proveen la utilidad de que al seleccionar un campo se borre su texto y al dejarlo vacio regrese a su valor por defecto
         * Se conforma de 2 funciones diferentes para cada textbox, una de enter y una de leave
         * Enter: tiene una condicion de que si tiene el valor por defecto se vacia 
         * Leave: si esta vacio vuelve a su valor por defecto, si es un campo obligatorio manda un mensaje de error de que el campo es obligatorio y hay un else para quitar el mensaje de error
         */
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Texts == "Nombre(s)*")
            {
                textBox1.Texts = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Texts == "")
            {
                textBox1.Texts = "Nombre(s)*";
                errorProvider1.SetError(textBox1, "Se necesita ingresar un nombre");
                textBox1.ForeColor = Color.Gray;
            }
            else
            {
                textBox1.ForeColor = Color.Black;
                //El regex para nombres (servidor publico sancionado) busca que solo se puedan colocar letras en dicho campo, tanto
                //mayusculas, minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter, se agrego que
                //el minimo de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                Regex nombre = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match match = nombre.Match(textBox1.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox1, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Se necesita un nombre válido");
                }
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Texts == "Primer apellido*")
            {
                textBox2.Texts = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Texts == "")
            {
                textBox2.Texts = "Primer apellido*";
                errorProvider1.SetError(textBox2, "Se necesita ingresar un apellido");
                textBox2.ForeColor = Color.Gray;
            }
            else
            {
                textBox2.ForeColor = Color.Black;
                //El regex para apellido paterno (servidor publico sancionado) busca que solo se puedan colocar letras en dicho
                //campo, tanto mayusculas, minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter,
                //se agrego que el minimo de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                Regex apellidoP = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match match = apellidoP.Match(textBox2.Texts);
                if (match.Success)
                {
                    errorProvider1.SetError(textBox2, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox2, "Se necesita un apellido válido");
                }
            }
        }

        private void textBox3_Enter_1(object sender, EventArgs e)
        {
            
                if (textBox3.Texts == "Segundo apellido")
                {
                    textBox3.Texts = "";
                    textBox3.ForeColor = Color.Black;
                }
            
        }

        private void textBox3_Leave_1(object sender, EventArgs e)
        {
            if (textBox3.Texts == "")
            {
                textBox3.Texts = "Segundo apellido";
                textBox3.ForeColor = Color.Gray;
            }
            else
            {
                textBox3.ForeColor = Color.Black;
                //El regex para apellido materno (servidor publico sancionado) busca que solo se puedan colocar letras en dicho
                //campo, tanto mayusculas, minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter,
                //se agrego que el minimo de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                Regex apellidoM = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match match = apellidoM.Match(textBox3.Texts);
                if (match.Success)
                {
                    errorProvider1.SetError(textBox3, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox3, "Se necesita un apellido válido");
                }
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Texts == "RFC*")
            {
                textBox4.Texts = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox5, String.Empty);
            if (textBox5.Texts == "CURP*")
            {
                textBox5.Texts = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Texts == "")
            {
                textBox4.Texts = "RFC*";
                errorProvider1.SetError(textBox4, "Se necesita ingresar un RFC");
                textBox4.ForeColor = Color.Gray;
            }
            else
            {
                textBox4.ForeColor = Color.Black;
                //Este regex se encarga de verificar que un RFC sea valido, tomando en consideracion que existen 2 tipos de RFC,
                //uno para las personas fisicas y otro para las personas morales, y cada uno de ellos tiene sus caracteristicas,
                //por lo que si colocamos un RFC para una persona fisica (13 caracteres) o uno para una persona moral (11 caracteres)
                //el regex se encargara de verificar si dicho RFC cumple con las condiciones de alguno de los dos.
                Regex RFC = new Regex(@"^([A-ZÑ&]{4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$");

                Match match = RFC.Match(textBox4.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox4, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox4, "Se necesita ingresar un RFC válido");

                }

            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Texts == "")
            {
                textBox5.Texts = "CURP*";
                errorProvider1.SetError(textBox5, "Se necesita ingresar un CURP");
                textBox5.ForeColor = Color.Gray;
            }
            else
            {
                //El regex para el CURP toma como base el formato oficial para el CURP de un ciudadano mexicano, por lo que debe de
                //llevar el formato ya establecido. En el caso de que alguno de los caracteres no sea correcto, lanzara un mensaje
                //de error indicando que el CURP no es valido.
                textBox5.ForeColor = Color.Black;
                Regex CURP = new Regex (@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$");

                Match match = CURP.Match(textBox5.Texts);
                
                if (match.Success)
                {
                    errorProvider1.SetError(textBox4, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox5, "Se necesita ingresar un CURP válido");
                }
            }
        }

        private void textBox25_Enter(object sender, EventArgs e)
        {
            if (textBox25.Texts == "Puesto nombre*")
            {
                textBox25.Texts = "";
                textBox25.ForeColor = Color.Black;
            }
        }

        private void textBox25_Leave(object sender, EventArgs e)
        {
            if (textBox25.Texts == "")
            {
                textBox25.Texts = "Puesto nombre*";
                errorProvider1.SetError(textBox25, "Se necesita ingresar un puesto");
                textBox25.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox25, String.Empty);

            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Texts == "Puesto nivel")
            {
                textBox6.Texts = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Texts == "")
            {
                textBox6.Texts = "Puesto nivel";
                textBox6.ForeColor = Color.Gray;
            }
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            if (textBox15.Texts == "Nombre*")
            {
                textBox15.Texts = "";
                textBox15.ForeColor = Color.Black;
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Texts == "")
            {
                textBox15.Texts = "Nombre*";
                errorProvider1.SetError(textBox15, "Se necesita ingresar una institución o dependencia");
                textBox15.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox15, String.Empty);

            }
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            if (textBox13.Texts == "Siglas")
            {
                textBox13.Texts = "";
                textBox13.ForeColor = Color.Black;
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Texts == "")
            {
                textBox13.Texts = "Siglas";
                textBox13.ForeColor = Color.Gray;
            }
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (textBox14.Texts == "Clave")
            {
                textBox14.Texts = "";
                textBox14.ForeColor = Color.Black;
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Texts == "")
            {
                textBox14.Texts = "Clave";
                textBox14.ForeColor = Color.Gray;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Texts == "Expediente*")
            {
                textBox7.Texts = "";
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Texts == "")
            {
                textBox7.Texts = "Expediente*";
                errorProvider1.SetError(textBox7, "Se necesita ingresar un expediente");
                textBox7.ForeColor = Color.Gray;
            }
            else
            {
                textBox7.ForeColor = Color.Black;
                errorProvider1.SetError(textBox7, String.Empty);

            }
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textBox11.Texts == "Descripción")
            {
                textBox11.Texts = "";
                textBox11.ForeColor = Color.Black;
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Texts == "")
            {
                textBox11.Texts = "Descripción";
                textBox11.ForeColor = Color.Gray;
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Texts == "Causa, motivo o hechos*")
            {
                textBox9.Texts = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Texts == "")
            {
                textBox9.Texts = "Causa, motivo o hechos*";
                textBox9.ForeColor = Color.Gray;
            }
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (textBox12.Texts == "Observaciones")
            {
                textBox12.Texts = "";
                textBox12.ForeColor = Color.Black;
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Texts == "")
            {
                textBox12.Texts = "Observaciones";
                textBox12.ForeColor = Color.Gray;
            }
        }

        private void textBox16_Load(object sender, EventArgs e)
        {

        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (textBox16.Texts == "")
            {
                textBox16.Texts = "Autoridad sancionadora*";
                errorProvider1.SetError(textBox16, "Se necesita ingresar una autoridad sancionadora");
                textBox16.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox16, String.Empty);

            }
        }

        private void textBox16_Enter(object sender, EventArgs e)
        {
            if (textBox16.Texts == "Autoridad sancionadora*")
            {
                textBox16.Texts = "";
                textBox16.ForeColor = Color.Black;
            }
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox10, String.Empty);
            if (textBox10.Texts == "URL")
            {
                textBox10.Texts = "";
                textBox10.ForeColor = Color.Black;

            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Texts == "")
            {
                textBox10.Texts = "URL";
                textBox10.ForeColor = Color.Gray;

            }
            else
            {
                //El regex de urls para el campo de resolucion, en este caso este regex solo se activara si se coloca algo sobre el
                //campo de url en resolucion, y si este es el caso, buscara que dicho texto sea una direccion url valida.
                Regex URLS = new Regex (@"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$");

                Match match = URLS.Match(textBox10.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox10, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox10, "Ingrese un URL válido");
                }
            }
        }

        private void textBox19_Enter(object sender, EventArgs e)
        {
            if (textBox19.Texts == "Plazo")
            {
                textBox19.Texts = "";
                textBox19.ForeColor = Color.Black;
            }
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            if (textBox19.Texts == "")
            {
                textBox19.Texts = "Plazo";
                textBox19.ForeColor = Color.Gray;
            }
        }

        private void textBox21_Enter(object sender, EventArgs e)
        {
            if (textBox21.Texts == "Monto")
            {
                textBox21.Texts = "";
                textBox21.ForeColor = Color.Black;
            }
        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            if (textBox21.Texts == "")
            {
                textBox21.Texts = "Monto";
                textBox21.ForeColor = Color.Gray;
            }
        }

        private void textBox22_Enter(object sender, EventArgs e)
        {
            if (textBox22.Texts == "Descripción")
            {
                textBox22.Texts = "";
                textBox22.ForeColor = Color.Black;
            }
        }

        private void textBox22_Leave(object sender, EventArgs e)
        {
            if (textBox22.Texts == "")
            {
                textBox22.Texts = "Descripción";
                textBox22.ForeColor = Color.Gray;
            }
        }

        private void comboBox6_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox6, String.Empty);
        }

        private void textBox23_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox23, String.Empty);
            if (textBox23.Texts == "Título*")
            {
                textBox23.Texts = "";
                textBox23.ForeColor = Color.Black;
            }
        }

        private void textBox23_Leave(object sender, EventArgs e)
        {
            if (textBox23.Texts == "")
            {
                textBox23.Texts = "Título*";
                textBox23.ForeColor = Color.Gray;
            }
        }

        private void textBox29_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox29, String.Empty);
            if (textBox29.Texts == "Descripción*")
            {
                textBox29.Texts = "";
                textBox29.ForeColor = Color.Black;
            }
        }

        private void textBox29_Leave(object sender, EventArgs e)
        {
            if (textBox29.Texts == "")
            {
                textBox29.Texts = "Descripción*";
                textBox29.ForeColor = Color.Gray;
            }
        }

        private void dateTimePicker4_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(dateTimePicker4, String.Empty);
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox5, String.Empty);
        }

        private void textBox1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.validarNumeros(e);
        }

        //boton cancelar
        private void button3_Click(object sender, EventArgs e)
        {
            //ventana emergente para confirmar la accion
            DialogResult resut = MessageBox.Show("¿Desea cancelar esta operación? Si cancela se perderán todos los datos que ha ingresado", "Cancelar registro", MessageBoxButtons.YesNo);
            //en caso de seleccionar si se mandara al listado de servidores 
            if (resut == DialogResult.Yes)
            {

                form2Handler.ListaSPS();

            }
            //en caso de selecionar no se permanecera en la misma ventana
            else if (resut == DialogResult.No)
            {
            }
        }

        private void textBox20_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox20, String.Empty);
            if (textBox20.Texts == "URL*")
            {
                textBox20.Texts = "";
                textBox20.ForeColor = Color.Black;
            }
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            if (textBox20.Texts == "")
            {
                textBox20.Texts = "URL*";
                errorProvider1.SetError(textBox20, "Se requiere un URL");
                textBox20.ForeColor = Color.Gray;
            }
            else
            {
                
            }
        }

        private void comboBox5_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox5, String.Empty);
        }
    }
}
