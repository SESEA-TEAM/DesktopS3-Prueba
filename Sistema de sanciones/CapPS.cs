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
    
    public partial class CapPS : Form
    {
        //declaramos una instancia del controlador de particulares cancionados para poder acceder a sus funciones facilmente
        controlador1PS conPS = new controlador1PS();
        //variables de ayuda para almacenar fechas
        String? f1, f2, f3, f4;
        //declaramos una instancia del modelo de particulares cancionados para facilitar el uso del objeto
        private Particular ParticularS = new Particular();
        //creamos un handler de el form 2 que es nuestro menu principal para posteriormente asignarle una instancia de este y poer acceder a sus funciones
        private Form2 form2Handler;

        //declaramos listas que usaremos en el formulario con ayuda de sus controladores respectivos
        List<modeloTipoDocumento> lDocumentos = new controladorTipoDocumento().obtenerListaDocumentosPS();
        List<modeloTipoSancion> lSancion = new controladorTipoSancion().obtenerListaSancionesPS();
        
        //definimos que para llamar a este form se debe de mandar una instancia del form 2 que es el menu principal, desde donde este será llamado
        public CapPS(Form2 form2)
        {
            InitializeComponent();
            //llamamos a funciones que ayudan a que el formulario funcione correctamente
            llenarCombos();
            CargarDG();

            //asignamos una hora por defecto a los datetimepickers
            dateTimePicker1.Value = new DateTime(2000, 01, 01);
            dateTimePicker2.Value = new DateTime(2000, 01, 01);
            dateTimePicker3.Value = new DateTime(2000, 01, 01);
            dateTimePicker4.Value = new DateTime(2000, 01, 01);

            //lista para combobox tipo persona
            List<string> lista = new List<string>();
            lista.Add("Tipo persona*");
            lista.Add("Física");
            lista.Add("Moral");
            comboBox9.DataSource = lista;

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
            //asigna la lista de monedas a el combobox 1
            comboBox1.DataSource = new controladorMoneda().obtenerListaMonedasPS();
            comboBox1.ValueMember = "valor";

            //asigna la lista de documentos a el combobox 8
            comboBox8.DataSource = lDocumentos;
            comboBox8.ValueMember = "tipoDocumento";

            //asigna la lista de sanciones a el combobox 2
            comboBox2.DataSource = lSancion;
            comboBox2.ValueMember = "valor";

            //asigna la lista de entidades a el combobox 3
            comboBox3.DataSource = new controladorEntidadFederativa().obtenerListaPais();
            comboBox3.ValueMember = "name";

            //asigna la lista de paises a el combobox 7
            comboBox7.DataSource = new controladorPais().obtenerListaPais();
            comboBox7.ValueMember = "name";

        }
        //da formato al datagridview de sanciones
        private void CargarDG()
        {
            //para asignar los tamaños de las columnas se toma como referencia el tamaño de un panel para que la resolucion de la pantalla donde se esta ejecutando no afecte a como se ven las columnas
            int p = panel3.Width;
            //se llama al datagrid y a la columna (estos ya fueron declarados en las propiedades del datagrid), despues con la propiedad de width (ancho) se le asigna un porcentaje del tamaño del panel de referencia
            dataGridView1.Columns[1].Width = (Convert.ToInt32(p * 0.46));
            dataGridView1.Columns[2].Width = (Convert.ToInt32(p * 0.45));

            int p2 = panel6.Width;

            dataGridView2.Columns[1].Width = (Convert.ToInt32(p2 * 0.16));
            dataGridView2.Columns[2].Width = Convert.ToInt32(p2 * 0.16);
            dataGridView2.Columns[3].Width = Convert.ToInt32(p2 * 0.21);
            dataGridView2.Columns[4].Width = Convert.ToInt32(p2 * 0.22);
            dataGridView2.Columns[5].Width = Convert.ToInt32(p2 * 0.16);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //boton para agregar documentos
        private void button1_Click(object sender, EventArgs e)
        {
            //Este regex solo se activara si se coloca una url en el apartado de los documentos, por lo que si se deja vacio, no
            //saltara ningun mensaje de error, a menos que se coloque algo sobre alguno de los campos de documentos.
            Regex URLS = new Regex(@"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$");

            Match match = URLS.Match(textBox44.Texts);
            //comprobamos que el documento tenga una fecha
            if (dateTimePicker3.Text == "2000-01-01")
            {
                f4 = null;
            }
            else
            {
                f4 = dateTimePicker3.Text;
            }
            //comprobamos que se haya seleccionado algun tipo de documento
            if (comboBox8.Text == "Tipo Documento")
            {
                errorProvider1.SetError(comboBox8, "Se necesita seleccionar un tipo de documento");
            }
            else
            {
                //comprobamos que se haya introduido algun titulo
                if (textBox45.Texts == "Título*")
                {
                    errorProvider1.SetError(textBox45, "Se necesita introducir el título del documento");
                }
                else
                {
                    //comprobamos que se haya introducido una descripción
                    if (textBox46.Texts == "Descripción*")
                    {
                        errorProvider1.SetError(textBox46, "Se necesita introducir la descripción del documento");
                    }
                    else
                    {
                        //comprobamos que se haya introducido una url
                        if (textBox44.Texts == "URL*")
                        {
                            errorProvider1.SetError(textBox44, "Se necesita introducir el URL del documento");
                        }
                        //se comprueba que la url tenga un formato valido
                        else if (!match.Success)
                        {
                            errorProvider1.SetError(textBox44, "Ingrese un URL válido");
                        }
                        else
                        {
                            //se comprueba que la fecha se haya introducido
                            if (f4 == null)
                            {
                                errorProvider1.SetError(dateTimePicker3, "Se necesita introducir una fecha válida");
                            }
                            else
                            {
                                //se delara un tipo de documento y se le asigna el valor seleccionado en el combobox
                                modeloTipoDocumento dc = (modeloTipoDocumento)comboBox8.SelectedItem;
                                //se agregan los valores del documento al datagrid 2
                                dataGridView2.Rows.Add(Convert.ToString(dc.Id), textBox45.Texts, comboBox8.Text, textBox46.Texts, textBox44.Texts, dateTimePicker3.Text);
                                //se resetean los campos
                                textBox45.Texts = "Título*";
                                textBox46.Texts = "Descripción*";
                                textBox44.Texts = "URL*";
                                dateTimePicker3.Value = new DateTime(2000, 01, 01);
                                comboBox8.SelectedItem = lDocumentos[0];
                            }
                        }
                    }
                }
            }
        }

        //acciones al cambiar la seleccion del boton de ningun domicilio
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //altura del panel de domicilio mexicano para usar como referencia
            int p = panel10.Height;
            //si el redio button de ningun domicilio es desseleccionado
            if (!radioButton3.Checked)
            {
                //el panel de documentos se recorre hacia abajo
                panel8.Top += p;
            }
            else
            {
                //al seleccionarse el panel de documentos sube
                panel8.Top -= p;
            }
        }
        //acciones al cambiar la seleccion del boton de domicilio mexico
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //si el raio button de domiclio mexico es desseleccionado
            if (!radioButton1.Checked)
            {
                //el panel de dpmicilio mexicano deja de ser visible
                panel10.Visible = false;
            }
            else
            {
                //de lo contrario el panel de domicilio mexicano es visible y el de domicilio extranjero desaparece
                panel10.Visible = true;
                panel9.Visible = false;
            }
        }
        //boton de guardar
        private void button4_Click(object sender, EventArgs e)
        {
            //se llama la funcion de guardar
            if (guardar())
            {
                //en caso de completarse el guardado se muestra un mensaje de exito y manda a la ventana de listado
                MessageBox.Show("Se ha realizado el registro con exito");
                form2Handler.ListaPS();
            }
        }
        //boton para agregar sanciones
        private void button2_Click(object sender, EventArgs e)
        {
            //comprueba que se haya seleccionado un tipo de sancion
            if (comboBox2.Text == "Tipo Sanción")
            {
                //se muestra un error de que es requerido
                errorProvider1.SetError(comboBox2, "Se necesita seleccionar un tipo de sanción");
            }
            else
            {
                //si la sancion va sin descripcion
                if (textBox1.Texts == "Descripción")
                {
                    //se declara un modelo de sancion y se le asigna el selecionado en el combobox 2
                    modeloTipoSancion sn = (modeloTipoSancion)comboBox2.SelectedItem;
                    //se agregan los valores al datagrid
                    dataGridView1.Rows.Add(Convert.ToString(sn.id), comboBox2.Text);
                    //se resetean los campos
                    textBox1.Texts = "Descripción";
                    comboBox2.SelectedItem = lSancion[0];
                }
                //si la sancion va con descripcion
                else
                {
                    //se declara un modelo de sancion y se le asigna el selecionado en el combobox 2
                    modeloTipoSancion sn = (modeloTipoSancion)comboBox2.SelectedItem;
                    //se agregan los valores al datagrid
                    dataGridView1.Rows.Add(Convert.ToString(sn.id), comboBox2.Text, textBox1.Texts);
                    //se resetean los campos
                    textBox1.Texts = "Descripción";
                    comboBox2.SelectedItem = lSancion[0];
                }

            }
        }

        private void CapPS_Load(object sender, EventArgs e)
        {
            //se agregan los botones de quitar a los datagrid
            int p = panel3.Width;
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "quitar";
            Ver.Name = "quitar";
            Ver.Width = Convert.ToInt32(p*0.095);
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);
            
            int p2 = panel6.Width;
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
            //se le inserta el icono de basura al la ccelda 
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
            //accion de cuando la celda es seleccinada
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
            //se le inserta el icono de basura a la celda
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
            //accion de cuando la celda es seleccionada
            if (dataGridView2.Columns[e.ColumnIndex].Name == "quitar")
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    dataGridView2.Rows.Remove(dataGridView2.CurrentRow); //Se elimina la fila seleccionada del DataGridView.

                }
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox2, String.Empty);
        }

        private void comboBox8_SelectedValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox8, String.Empty);
        }

        private void comboBox9_SelectedValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox9, String.Empty);
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            //al seleccionar la entidad federativa se toma su valor y se usa para llamar a la lista de municipios que se relacionan con esta
            modeloEntidadFederativa ef = (modeloEntidadFederativa)comboBox3.SelectedItem;
            comboBox4.DataSource = new controladorMunicipio().obtenerListaMunicipio(ef.id);
            comboBox4.ValueMember = "name";

        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            //al seleccionar el municipio se toma su valor y se usa para llamar a la lista de localidades que se relacionan con este
            modeloMunicipio mp = (modeloMunicipio)comboBox4.SelectedItem;
            comboBox5.DataSource = new controladorLocalidad().obtenerListaLocalidad(mp.id);
            comboBox5.ValueMember = "name";
        }

        private void dateTimePicker3_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(dateTimePicker3, String.Empty);
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            //se toma el valor de la localidad
            modeloLocalidad lc = (modeloLocalidad)comboBox5.SelectedItem;
            //se llama a la lista de vialidades
            comboBox6.DataSource = new controladorVialidad().obtenerListaVialidad(0);
            comboBox6.ValueMember = "name";
        }

        /*
         * Estas funciones proveen la utilidad de que al seleccionar un campo se borre su texto y al dejarlo vacio regrese a su valor por defecto
         * Se conforma de 2 funciones diferentes para cada textbox, una de enter y una de leave
         * Enter: tiene una condicion de que si tiene el valor por defecto se vacia 
         * Leave: si esta vacio vuelve a su valor por defecto, si es un campo obligatorio manda un mensaje de error de que el campo es obligatorio y hay un else para quitar el mensaje de error
         */
        private void textBox20_Enter(object sender, EventArgs e)
        {
            if (textBox20.Texts == "Expediente*")
            {
                textBox20.Texts = "";
                textBox20.ForeColor = Color.Black;
            }
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            if (textBox20.Texts == "")
            {
                textBox20.Texts = "Expediente*";
                errorProvider1.SetError(textBox20, "Se necesita ingresar un expediente");
                textBox20.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox20, String.Empty);

            }
        }

        private void textBox19_Enter(object sender, EventArgs e)
        {
            if (textBox19.Texts == "Nombre(s)/Razón Social*")
            {
                textBox19.Texts = "";
                textBox19.ForeColor = Color.Black;
            }
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            if (textBox19.Texts == "")
            {
                textBox19.Texts = "Nombre(s)/Razón Social*";
                errorProvider1.SetError(textBox19, "Se necesita ingresar un nombre o razón social");
                textBox19.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox19, String.Empty);

            }
        }

        private void textBox18_Enter(object sender, EventArgs e)
        {
            if (textBox18.Texts == "RFC*")
            {
                textBox18.Texts = "";
                textBox18.ForeColor = Color.Black;
            }
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            if (textBox18.Texts == "")
            {
                textBox18.Texts = "RFC*";
                errorProvider1.SetError(textBox18, "Se necesita ingresar un RFC");
                textBox18.ForeColor = Color.Gray;
            }
            else
            {
                textBox18.ForeColor = Color.Black;
                //Este regex se encarga de verificar que un RFC sea valido, tomando en consideracion que existen 2 tipos de RFC,
                //uno para las personas fisicas y otro para las personas morales, y cada uno de ellos tiene sus caracteristicas,
                //por lo que si colocamos un RFC para una persona fisica (13 caracteres) o uno para una persona moral (11 caracteres)
                //el regex se encargara de verificar si dicho RFC cumple con las condiciones de alguno de los dos.
                Regex RFC = new Regex(@"^[A-Z&Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]$");

                Match match = RFC.Match(textBox18.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox18, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox18, "Se necesita ingresar un RFC válido");
                }

            }
        }

        private void textBox17_Enter(object sender, EventArgs e)
        {
            if (textBox17.Texts == "Causa, motivo o hechos*")
            {
                textBox17.Texts = "";
                textBox17.ForeColor = Color.Black;
            }
        }

        private void textBox17_Leave(object sender, EventArgs e)
        {
            if (textBox17.Texts == "")
            {
                textBox17.Texts = "Causa, motivo o hechos*";
                errorProvider1.SetError(textBox17, "Se necesita ingresar causa, motivo o hechos");
                textBox17.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox17, String.Empty);

            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Texts == "Acto")
            {
                textBox8.Texts = "";
                textBox8.ForeColor = Color.Black;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Texts == "")
            {
                textBox8.Texts = "Acto";
                textBox8.ForeColor = Color.Gray;
            }
        }

        private void textBox16_Enter(object sender, EventArgs e)
        {
            if (textBox16.Texts == "Objeto contrato")
            {
                textBox16.Texts = "";
                textBox16.ForeColor = Color.Black;
            }
        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (textBox16.Texts == "")
            {
                textBox16.Texts = "Objeto contrato";
                textBox16.ForeColor = Color.Gray;
            }
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (textBox12.Texts == "Tipo falta*")
            {
                textBox12.Texts = "";
                textBox12.ForeColor = Color.Black;
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Texts == "")
            {
                textBox12.Texts = "Tipo falta*";
                errorProvider1.SetError(textBox12, "Se necesita ingresar una tipo de falta");
                textBox12.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox12, String.Empty);

            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Texts == "Nombre(s)*")
            {
                textBox7.Texts = "";
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Texts == "")
            {
                textBox7.Texts = "Nombre(s)*";
                errorProvider1.SetError(textBox7, "Se necesita ingresar una institución o dependencia");
                textBox7.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox7, String.Empty);

            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Texts == "Siglas")
            {
                textBox9.Texts = "";
                textBox9.ForeColor = Color.Black;
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Texts == "")
            {
                textBox9.Texts = "Siglas";
                textBox9.ForeColor = Color.Gray;
            }
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (textBox10.Texts == "Clave")
            {
                textBox10.Texts = "";
                textBox10.ForeColor = Color.Black;
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Texts == "")
            {
                textBox10.Texts = "Clave";
                textBox10.ForeColor = Color.Gray;
            }
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textBox11.Texts == "Observaciones")
            {
                textBox11.Texts = "";
                textBox11.ForeColor = Color.Black;
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Texts == "")
            {
                textBox11.Texts = "Observaciones";
                textBox11.ForeColor = Color.Gray;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Texts == "Sentido")
            {
                textBox6.Texts = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Texts == "")
            {
                textBox6.Texts = "Sentido";
                textBox6.ForeColor = Color.Gray;
            }
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            if (textBox13.Texts == "URL")
            {
                textBox13.Texts = "";
                textBox13.ForeColor = Color.Black;
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Texts == "")
            {
                textBox13.Texts = "URL";
                textBox13.ForeColor = Color.Gray;
            }
            else
            {
                //El regex de urls para el campo de resolucion, en este caso este regex solo se activara si se coloca algo sobre el
                //campo de url en resolucion, y si este es el caso, buscara que dicho texto sea una direccion url valida.
                Regex URLS = new Regex(@"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$");

                Match match = URLS.Match(textBox13.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox13, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox13, "Ingrese un URL válido");
                }
            }
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (textBox14.Texts == "Fecha resolución")
            {
                textBox14.Texts = "";
                textBox14.ForeColor = Color.Black;
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Texts == "")
            {
                textBox14.Texts = "fecha resolución";
                textBox14.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Texts == "Nombre(s)*")
            {
                textBox4.Texts = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Texts == "")
            {
                textBox4.Texts = "Nombre(s)*";
                errorProvider1.SetError(textBox4, "Se necesita ingresar el nombre del responsable de la sanción");
                textBox4.ForeColor = Color.Gray;
            }
            else
            {
                textBox4.ForeColor = Color.Black;
                //El regex para nombres (responsable sancion) busca que solo se puedan colocar letras en dicho campo, tanto mayusculas,
                //minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter, se agrego que el minimo
                //de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                Regex nombre = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match matchN = nombre.Match(textBox4.Texts);

                if (matchN.Success)
                {
                    errorProvider1.SetError(textBox4, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox4, "Se necesita un nombre válido");
                }
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Texts == "Primer apellido*")
            {
                textBox3.Texts = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Texts == "")
            {
                textBox3.Texts = "Primer apellido*";
                errorProvider1.SetError(textBox3, "Se necesita ingresar el primer apellido del responsable de la sanción");
                textBox3.ForeColor = Color.Gray;
            }
            else
            {
                //El regex el apellido paterno (responsable sancion) busca que solo se puedan colocar letras en dicho campo, tanto
                //mayusculas, minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter, se agrego que
                //el minimo de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                textBox3.ForeColor = Color.Black;
                Regex apellidoP = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match matchP = apellidoP.Match(textBox3.Texts);

                if (matchP.Success)
                {
                    errorProvider1.SetError(textBox3, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox3, "Se necesita un apellido válido");
                }
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Texts == "Segundo apellido")
            {
                textBox2.Texts = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Texts == "")
            {
                textBox2.Texts = "Segundo apellido";
                textBox2.ForeColor = Color.Gray;
            }
            else
            {
                textBox2.ForeColor = Color.Black;
                //El regex el apellido materno (responsable sancion) busca que solo se puedan colocar letras en dicho campo, tanto
                //mayusculas, minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter, se agrego que
                //el minimo de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                Regex apellidoM = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match matchM = apellidoM.Match(textBox2.Texts);

                if (matchM.Success)
                {
                    errorProvider1.SetError(textBox2, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox2, "Se necesita un apellido válido");
                }
            }
        }

        private void textBox23_Enter(object sender, EventArgs e)
        {
            if (textBox23.Texts == "Plazo")
            {
                textBox23.Texts = "";
                textBox23.ForeColor = Color.Black;
            }
        }

        private void textBox23_Leave(object sender, EventArgs e)
        {
            if (textBox23.Texts == "")
            {
                textBox23.Texts = "Plazo";
                textBox23.ForeColor = Color.Gray;
            }
        }

        private void textBox22_Enter(object sender, EventArgs e)
        {
            if (textBox22.Texts == "Fecha inicial")
            {
                textBox22.Texts = "";
                textBox22.ForeColor = Color.Black;
            }
        }

        private void textBox22_Leave(object sender, EventArgs e)
        {
            if (textBox22.Texts == "")
            {
                textBox22.Texts = "Fecha inicial";
                textBox22.ForeColor = Color.Gray;
            }
        }

        private void textBox21_Enter(object sender, EventArgs e)
        {
            if (textBox21.Texts == "Fecha final")
            {
                textBox21.Texts = "";
                textBox21.ForeColor = Color.Black;
            }
        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            if (textBox21.Texts == "")
            {
                textBox21.Texts = "Fecha final";
                textBox21.ForeColor = Color.Gray;
            }
        }

        private void textBox24_Enter(object sender, EventArgs e)
        {
            if (textBox24.Texts == "Monto")
            {
                textBox24.Texts = "";
                textBox24.ForeColor = Color.Black;
            }
        }

        private void textBox24_Leave(object sender, EventArgs e)
        {
            if (textBox24.Texts == "")
            {
                textBox24.Texts = "Monto";
                textBox24.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Texts == "Descripción")
            {
                textBox1.Texts = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Texts == "")
            {
                textBox1.Texts = "Descripción";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox26_Enter(object sender, EventArgs e)
        {
            if (textBox26.Texts == "Teléfono")
            {
                textBox26.Texts = "";
                textBox26.ForeColor = Color.Black;
            }
        }

        private void textBox26_Leave(object sender, EventArgs e)
        {
            if (textBox26.Texts == "")
            {
                textBox26.Texts = "Teléfono";
                textBox26.ForeColor = Color.Gray;
            }
            else
            {
                textBox26.ForeColor = Color.Black;
                //El regex de telefono nos permite colocar unicamente valores numericos dentro del campo de telefono, y en este caso la
                //unica condicion para aceptar si un numero es valido o no, es si este cuenta con 10 caracteres.
                Regex telefono = new Regex(@"^\d{10}$");
                Match matchT = telefono.Match(textBox26.Texts);

                if (matchT.Success)
                {
                    errorProvider1.SetError(textBox26, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox26, "Se necesita un teléfono válido");
                }
            }
        }

        private void textBox25_Enter(object sender, EventArgs e)
        {
            if (textBox25.Texts == "Objeto social")
            {
                textBox25.Texts = "";
                textBox25.ForeColor = Color.Black;
            }
        }

        private void textBox25_Leave(object sender, EventArgs e)
        {
            if (textBox25.Texts == "")
            {
                textBox25.Texts = "Objeto social";
                textBox25.ForeColor = Color.Gray;
            }
        }

        private void textBox31_Enter(object sender, EventArgs e)
        {
            if (textBox31.Texts == "Nombre(s)")
            {
                textBox31.Texts = "";
                textBox31.ForeColor = Color.Black;
            }
        }

        private void textBox31_Leave(object sender, EventArgs e)
        {
            if (textBox31.Texts == "")
            {
                textBox31.Texts = "Nombre(s)";
                textBox31.ForeColor = Color.Gray;
            }
            else
            {
                textBox31.ForeColor = Color.Black;
                //El regex para nombres (director general) busca que solo se puedan colocar letras en dicho campo, tanto mayusculas,
                //minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter, se agrego que el minimo
                //de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                Regex nombre = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match matchN = nombre.Match(textBox31.Texts);

                if (matchN.Success)
                {
                    errorProvider1.SetError(textBox31, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox31, "Se necesita un nombre válido");
                }
            }
        }

        private void textBox30_Enter(object sender, EventArgs e)
        {
            if (textBox30.Texts == "Primer apellido")
            {
                textBox30.Texts = "";
                textBox30.ForeColor = Color.Black;
            }
        }

        private void textBox30_Leave(object sender, EventArgs e)
        {
            if (textBox30.Texts == "")
            {
                textBox30.Texts = "Primer apellido";
                textBox30.ForeColor = Color.Gray;
            }
            else
            {
                textBox30.ForeColor = Color.Black;
                //El regex el apellido paterno (director general) busca que solo se puedan colocar letras en dicho campo, tanto
                //mayusculas, minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter, se agrego que
                //el minimo de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                Regex apellidoP = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match matchP = apellidoP.Match(textBox30.Texts);

                if (matchP.Success)
                {
                    errorProvider1.SetError(textBox30, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox30, "Se necesita un apellido válido");
                }
            }
        }

        private void textBox29_Enter(object sender, EventArgs e)
        {
            if (textBox29.Texts == "Segundo apellido")
            {
                textBox29.Texts = "";
                textBox29.ForeColor = Color.Black;
            }
        }

        private void textBox29_Leave(object sender, EventArgs e)
        {
            if (textBox29.Texts == "")
            {
                textBox29.Texts = "Segundo apellido";
                textBox29.ForeColor = Color.Gray;
            }
            else
            {
                textBox29.ForeColor = Color.Black;
                //El regex el apellido materno (director general) busca que solo se puedan colocar letras en dicho campo, tanto
                //mayusculas, minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter, se agrego que
                //el minimo de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                Regex apellidoM = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match matchM = apellidoM.Match(textBox29.Texts);

                if (matchM.Success)
                {
                    errorProvider1.SetError(textBox29, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox29, "Se necesita un apellido válido");
                }
            }
        }

        private void textBox28_Enter(object sender, EventArgs e)
        {
            if (textBox28.Texts == "CURP")
            {
                textBox28.Texts = "";
                textBox28.ForeColor = Color.Black;
            }
        }

        private void textBox28_Leave(object sender, EventArgs e)
        {
            if (textBox28.Texts == "")
            {
                textBox28.Texts = "CURP";
                textBox28.ForeColor = Color.Gray;
            }
            else
            {
                //El regex para el CURP toma como base el formato oficial para el CURP de un ciudadano mexicano, por lo que debe de
                //llevar el formato ya establecido. En el caso de que alguno de los caracteres no sea correcto, lanzara un mensaje
                //de error indicando que el CURP no es valido.
                textBox28.ForeColor = Color.Black;
                Regex CURP = new Regex(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$");

                Match match = CURP.Match(textBox28.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox28, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox28, "Se necesita ingresar un CURP válido");
                }
            }
        }

        private void textBox35_Enter(object sender, EventArgs e)
        {
            if (textBox35.Texts == "Nombre(s)")
            {
                textBox35.Texts = "";
                textBox35.ForeColor = Color.Black;
            }
        }

        private void textBox35_Leave(object sender, EventArgs e)
        {
            if (textBox35.Texts == "")
            {
                textBox35.Texts = "Nombre(s)";
                textBox35.ForeColor = Color.Gray;
            }
            else
            {
                //El regex para nombres (apoderado legal) busca que solo se puedan colocar letras en dicho campo, tanto mayusculas,
                //minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter, se agrego que el minimo
                //de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                textBox35.ForeColor = Color.Black;
                Regex nombre = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match matchN = nombre.Match(textBox35.Texts);

                if (matchN.Success)
                {
                    errorProvider1.SetError(textBox35, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox35, "Se necesita un nombre válido");
                }
            }
        }

        private void textBox32_Enter(object sender, EventArgs e)
        {
            if (textBox32.Texts == "Primer apellido")
            {
                textBox32.Texts = "";
                textBox32.ForeColor = Color.Black;
            }
        }

        private void textBox32_Leave(object sender, EventArgs e)
        {
            if (textBox32.Texts == "")
            {
                textBox32.Texts = "Primer apellido";
                textBox32.ForeColor = Color.Gray;
            }
            else
            {
                textBox32.ForeColor = Color.Black;
                //El regex el apellido paterno (apoderado legal) busca que solo se puedan colocar letras en dicho campo, tanto
                //mayusculas, minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter, se agrego que
                //el minimo de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                Regex apellidoP = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match matchP = apellidoP.Match(textBox32.Texts);

                if (matchP.Success)
                {
                    errorProvider1.SetError(textBox32, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox32, "Se necesita un apellido válido");
                }
            }
        }

        private void textBox27_Enter(object sender, EventArgs e)
        {
            if (textBox27.Texts == "Segundo apellido")
            {
                textBox27.Texts = "";
                textBox27.ForeColor = Color.Black;
            }
        }

        private void textBox27_Leave(object sender, EventArgs e)
        {
            if (textBox27.Texts == "")
            {
                textBox27.Texts = "Segundo apellido";
                textBox27.ForeColor = Color.Gray;
            }
            else
            {
                textBox27.ForeColor = Color.Black;
                //El regex el apellido materno (apoderado legal) busca que solo se puedan colocar letras en dicho campo, tanto
                //mayusculas, minusculas, y con acentos. En este caso, para evitar que solo se pusiera un caracter, se agrego que
                //el minimo de caracteres sea 3, mientras que el maximo de caracteres permitidos es de 100.
                Regex apellidoM = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match matchM = apellidoM.Match(textBox27.Texts);

                if (matchM.Success)
                {
                    errorProvider1.SetError(textBox27, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox27, "Se necesita un apellido válido");
                }
            }
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            if (textBox15.Texts == "CURP")
            {
                textBox15.Texts = "";
                textBox15.ForeColor = Color.Black;
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Texts == "")
            {
                textBox15.Texts = "CURP";
                textBox15.ForeColor = Color.Gray;
            }
            else
            {
                textBox15.ForeColor = Color.Black;
                //El regex para el CURP toma como base el formato oficial para el CURP de un ciudadano mexicano, por lo que debe de
                //llevar el formato ya establecido. En el caso de que alguno de los caracteres no sea correcto, lanzara un mensaje
                //de error indicando que el CURP no es valido.
                Regex CURP = new Regex(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$");

                Match match = CURP.Match(textBox15.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox15, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox15, "Se necesita ingresar un CURP válido");
                }
            }
        }

        private void textBox40_Enter(object sender, EventArgs e)
        {
            if (textBox40.Texts == "Calle")
            {
                textBox40.Texts = "";
                textBox40.ForeColor = Color.Black;
            }
        }

        private void textBox40_Leave(object sender, EventArgs e)
        {
            if (textBox40.Texts == "")
            {
                textBox40.Texts = "Calle";
                textBox40.ForeColor = Color.Gray;
            }
        }

        private void textBox39_Enter(object sender, EventArgs e)
        {
            if (textBox39.Texts == "Ciudad/Localidad")
            {
                textBox39.Texts = "";
                textBox39.ForeColor = Color.Black;
            }
        }

        private void textBox39_Leave(object sender, EventArgs e)
        {
            if (textBox39.Texts == "")
            {
                textBox39.Texts = "Ciudad/Localidad";
                textBox39.ForeColor = Color.Gray;
            }
        }

        private void textBox38_Enter(object sender, EventArgs e)
        {
            if (textBox38.Texts == "Estado/Provincia")
            {
                textBox38.Texts = "";
                textBox38.ForeColor = Color.Black;
            }
        }

        private void textBox38_Leave(object sender, EventArgs e)
        {
            if (textBox38.Texts == "")
            {
                textBox38.Texts = "Estado/Provincia";
                textBox38.ForeColor = Color.Gray;
            }
        }

        private void textBox37_Enter(object sender, EventArgs e)
        {
            if (textBox37.Texts == "Código Postal")
            {
                textBox37.Texts = "";
                textBox37.ForeColor = Color.Black;
            }
        }

        private void textBox37_Leave(object sender, EventArgs e)
        {
            if (textBox37.Texts == "")
            {
                textBox37.Texts = "Código Postal";
                textBox37.ForeColor = Color.Gray;
            }
        }

        private void textBox41_Enter(object sender, EventArgs e)
        {
            if (textBox41.Texts == "Número exterior")
            {
                textBox41.Texts = "";
                textBox41.ForeColor = Color.Black;
            }
        }

        private void textBox41_Leave(object sender, EventArgs e)
        {
            if (textBox41.Texts == "")
            {
                textBox41.Texts = "Número exterior";
                textBox41.ForeColor = Color.Gray;
            }
        }

        private void textBox42_Enter(object sender, EventArgs e)
        {
            if (textBox42.Texts == "Número interior")
            {
                textBox42.Texts = "";
                textBox42.ForeColor = Color.Black;
            }
        }

        private void textBox42_Leave(object sender, EventArgs e)
        {
            if (textBox42.Texts == "")
            {
                textBox42.Texts = "Número interior";
                textBox42.ForeColor = Color.Gray;
            }
        }

        private void comboBox7_Enter(object sender, EventArgs e)
        {

        }

        private void textBox34_Enter(object sender, EventArgs e)
        {
            if (textBox34.Texts == "Código Postal")
            {
                textBox34.Texts = "";
                textBox34.ForeColor = Color.Black;
            }
        }

        private void textBox34_Leave(object sender, EventArgs e)
        {
            if (textBox34.Texts == "")
            {
                textBox34.Texts = "Código Postal";
                textBox34.ForeColor = Color.Gray;
            }
            else
            {
                textBox34.ForeColor = Color.Black;
                //El regex para el codigo postal toma como referencia el formato del codigo postal de los Estados Unidos Mexicanos,
                //por lo que este debe de estar conformado por 5 digitos.
                Regex ZIPC = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$");

                Match match = ZIPC.Match(textBox34.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox34, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox34, "Se necesita ingresar un código postal válido");
                }
            }
        }

        private void textBox33_Enter(object sender, EventArgs e)
        {
            if (textBox33.Texts == "Número exterior")
            {
                textBox33.Texts = "";
                textBox33.ForeColor = Color.Black;
            }
        }

        private void textBox33_Leave(object sender, EventArgs e)
        {
            if (textBox33.Texts == "")
            {
                textBox33.Texts = "Número exterior";
                textBox33.ForeColor = Color.Gray;
            }
        }

        private void textBox36_Enter(object sender, EventArgs e)
        {
            if (textBox36.Texts == "Número interior")
            {
                textBox36.Texts = "";
                textBox36.ForeColor = Color.Black;
            }
        }

        private void textBox36_Leave(object sender, EventArgs e)
        {
            if (textBox36.Texts == "")
            {
                textBox36.Texts = "Número interior";
                textBox36.ForeColor = Color.Gray;
            }
        }

        private void textBox45_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox45, String.Empty);
            if (textBox45.Texts == "Título*")
            {
                textBox45.Texts = "";
                textBox45.ForeColor = Color.Black;
            }
        }

        private void textBox45_Leave(object sender, EventArgs e)
        {
            if (textBox45.Texts == "")
            {
                textBox45.Texts = "Título*";
                textBox45.ForeColor = Color.Gray;
            }
        }

        private void textBox46_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox46, String.Empty);
            if (textBox46.Texts == "Descripción*")
            {
                textBox46.Texts = "";
                textBox46.ForeColor = Color.Black;
            }
        }

        private void textBox46_Leave(object sender, EventArgs e)
        {
            if (textBox46.Texts == "")
            {
                textBox46.Texts = "Descripción*";
                textBox46.ForeColor = Color.Gray;
            }
        }

        private void textBox44_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox44, String.Empty);
            if (textBox44.Texts == "URL*")
            {
                textBox44.Texts = "";
                textBox44.ForeColor = Color.Black;
            }
        }

        private void textBox44_Leave(object sender, EventArgs e)
        {
            if (textBox44.Texts == "")
            {
                textBox44.Texts = "URL*";
                textBox44.ForeColor = Color.Gray;
            }
        }

        private void textBox43_Enter(object sender, EventArgs e)
        {
            if (textBox43.Texts == "Fecha*")
            {
                textBox43.Texts = "";
                textBox43.ForeColor = Color.Black;
            }
        }

        private void textBox43_Leave(object sender, EventArgs e)
        {
            if (textBox43.Texts == "")
            {
                textBox43.Texts = "Fecha*";
                textBox43.ForeColor = Color.Gray;
            }
        }
        //acciones al cambiar la seleccion del boton de domicilio extranjero
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //si el radio button de domicilio extranjero es desselccionado
            if (!radioButton2.Checked)
            {
                //el panel de domicilio extranjero deja de ser visible
                panel9.Visible = false;
            }
            else
            {
                //de lo contrario el panel de extranjero es visible y el de mexico deja de ser visible
                panel9.Visible = true;
                panel10.Visible = false;
            }
        }

        //La siguiente serie de comando son los keyPress, los cuales se los asignamos a los textBox para limitar los caracteres que este puede poner, por ejemplo,
        //todos los que se encuentran a continuacion solo permiten las teclas alfabeticas, por lo que no podremos colocar simbolos y numeros en dichos campos.
        //Por supuesto, existe otra version unicamente para los caracteres numericos.
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Texts == "Autoridad sancionadora*")
            {
                textBox5.Texts = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Texts == "")
            {
                textBox5.Texts = "Autoridad sancionadora*";
                errorProvider1.SetError(textBox5, "Se necesita ingresar una autoridad sancionadora");
                textBox5.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox5, String.Empty);

            }
        }

        //La siguiente serie de eventos son los keyPress, pero a diferencia de los de arriba, estos son los que se encargan de permitir que unicamente puedas
        //colocar numeros dentro de los textBox.
        private void textBox34_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.validarNumeros(e);
        }

        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.validarNumeros(e);
        }

        private void textBox36_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.validarNumeros(e);
        }

        private void textBox37_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.validarNumeros(e);
        }

        private void textBox41_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.validarNumeros(e);
        }

        private void textBox42_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.validarNumeros(e);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.validarNumeros(e);
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.validarNumeros(e);
        }

        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.validarNumeros(e);
        }

        private void textBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox30_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox35_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        //Cancelar registro
        private void button3_Click(object sender, EventArgs e)
        {
            //se muestra una pestaña emergente para confirmar la accion
            DialogResult resut = MessageBox.Show("¿Desea cancelar esta operación? Si cancela se perderán todos los datos que ha ingresado", "Cancelar registro", MessageBoxButtons.YesNo);
            //en caso de que se seleccione si se mandara a la ventana de listado
            if (resut == DialogResult.Yes)
            {

                form2Handler.ListaPS();

            }
            //en caso de que se seleccione no permanecera en la misma ventana
            else if (resut == DialogResult.No)
            {
            }
        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }

        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            ParticularS.textBoxEvent.textKeyPress(e);
        }



        private bool guardar()
        {
            //La siguiente lista de Regex es para todos aquellos campos que sean obligatorios.
            Regex ZIPC = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$");
            Match matchZIPMX = ZIPC.Match(textBox34.Texts);
            Regex RFC = new Regex(@"^[A-Z&Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]$");
            Match matchRFC = RFC.Match(textBox18.Texts);
            Regex nombre = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchN = nombre.Match(textBox4.Texts);
            Regex apellidoP = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchP = apellidoP.Match(textBox3.Texts);
            Regex apellidoM = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchM = apellidoM.Match(textBox2.Texts);
            Regex CURP = new Regex(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$");
            Match matchC = CURP.Match(textBox28.Texts);
            //variable de ayuda para el reultado
            bool valor = true;
            //condicion de que todos los campos obligatorios estan llenos
            if (textBox17.Texts == "Causa, motivo o hechos*" || textBox18.Texts == "RFC*" || textBox20.Texts == "Expediente*" || textBox12.Texts == "Tipo falta*" || textBox7.Texts == "Nombre(s)*" || textBox5.Texts == "Autoridad sancionadora*" || textBox4.Texts == "Nombre(s)*" || textBox3.Texts == "Primer apellido*" || comboBox9.Text == "Tipo persona*" || textBox19.Texts == "Nombre(s)/Razón Social*")
            {
                //mensaje para informar que falta llenar campos necesarios
                MessageBox.Show("Debe completar los campos obligatorios para poder hacer el registro");

                valor = false;
            }
            else
            {
                //se comprueba que haya al menos una sancion
                if (dataGridView1.Rows.Count <= 0)
                {
                    //si no hay sanciones se pide que se agregue al menos una
                    MessageBox.Show("Necesita asignar al menos una sanción al registro");
                    valor = false;
                }
                else
                {
                    /*
                     * Los condicionales con match son para saber que los datos de los textbox cumplan con los estandares requeridos
                     */
                    if (matchRFC.Success)
                    {
                        errorProvider1.SetError(textBox18, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox18, "Se necesita un RFC válido");
                        valor = false;
                    }
                    if (matchN.Success)
                    {
                        errorProvider1.SetError(textBox4, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox4, "Se necesita un nombre válido");
                        valor = false;
                    }
                    if (matchP.Success)
                    {
                        errorProvider1.SetError(textBox3, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox3, "Se necesita un apellido válido");
                        valor = false;
                    }

                    /*
                     * se toman los valores de las fechas si es que estas han cambiado del valor por default
                     */
                    if (dateTimePicker4.Text == "2000-01-01")
                    {
                        f1 = null;
                    }
                    else
                    {
                        f1 = dateTimePicker4.Text;
                    }
                    if (dateTimePicker1.Text == "2000-01-01")
                    {
                        f2 = null;
                    }
                    else
                    {
                        f2 = dateTimePicker1.Text;
                    }
                    if (dateTimePicker2.Text == "2000-01-01")
                    {
                        f3 = null;
                    }
                    else
                    {
                        f3 = dateTimePicker2.Text;
                    }
                    //se toma el item de moneda del comboox 1
                    modeloMoneda mn = (modeloMoneda)comboBox1.SelectedItem;
                    //se declara un particular sancionado para asignarle los valores
                    modeloPS modPS = new modeloPS();
                    //si se seleccionó un domicilio mexicano
                    if (radioButton1.Checked)
                    {
                        //se toman los valores de los combobox de domicilio mexicano
                        modeloEntidadFederativa ef = (modeloEntidadFederativa)comboBox3.SelectedItem;
                        modeloMunicipio mp = (modeloMunicipio)comboBox4.SelectedItem;
                        modeloLocalidad lc = (modeloLocalidad)comboBox5.SelectedItem;
                        modeloVialidad v = (modeloVialidad)comboBox6.SelectedItem;

                        //se asigna siempre el pais mexico
                        modPS.paisMX = 153;

                        //si no se seleccionó alguno de los campos de comicilio no se agrega el atributo
                        if (ef.id == 0)
                        {

                        }
                        else
                        {
                            modPS.entidadFederativa = Convert.ToInt32(ef.id);
                        }
                        if (mp.id == 0)
                        {

                        }
                        else
                        {
                            modPS.municipio = Convert.ToInt32(mp.id);
                        }
                        if (lc.id == 0)
                        {

                        }
                        else
                        {
                            modPS.localidad = Convert.ToInt32(lc.id);
                        }
                        if (v.id == 0)
                        {

                        }
                        else
                        {
                            modPS.vialidad = Convert.ToInt32(v.id);
                        }
                        //se comprueba que se haya ingresado el codio postal y se comprueba que su estructura sea valida
                        if (textBox34.Texts == "Código postal")
                        {

                        }
                        else
                        {
                            if (matchZIPMX.Success)
                            {
                                modPS.codigoPostalMX = textBox34.Texts;
                                errorProvider1.SetError(textBox34, String.Empty);
                            }
                            else
                            {
                                errorProvider1.SetError(textBox34, "Se necesita un código postal válido");
                                valor = false;
                            }

                        }

                        //en caso de haberlos puesto agrga los campos de numeros interior y exterior al particular
                        if (textBox33.Texts == "Número exterior")
                        {

                        }
                        else
                        {
                            modPS.numeroExteriorMX = textBox33.Texts;
                        }
                        if (textBox36.Texts == "Número interior")
                        {

                        }
                        else
                        {
                            modPS.numeroInteriorMX = textBox36.Texts;
                        }
                    }
                    //si se selecciona domicilio extranjero
                    if (radioButton2.Checked)
                    {
                        //se toma el valor de pais del combobox
                        modeloPais ps = (modeloPais)comboBox7.SelectedItem;
                        //si se selecciona un pais se asigna el valor
                        if (ps.id == 0)
                        {

                        }
                        else
                        {
                            modPS.paisEX = Convert.ToInt32(ps.id);
                        }
                        //se asignan los atributos al particular que si se hayan llenado
                        if (textBox37.Texts == "Código Postal")
                        {

                        }
                        else
                        {
                            modPS.codigoPostalEX = textBox37.Texts;
                        }
                        if (textBox38.Texts == "Estado/Provincia")
                        {

                        }
                        else
                        {
                            modPS.estadoProvincia = textBox38.Texts;
                        }
                        if (textBox39.Texts == "Ciudad/Localidad")
                        {

                        }
                        else
                        {
                            modPS.ciudadLocalidad = textBox39.Texts;
                        }
                        if (textBox40.Texts == "Calle")
                        {

                        }
                        else
                        {
                            modPS.calle = textBox40.Texts;
                        }
                        if (textBox41.Texts == "Número exterior")
                        {

                        }
                        else
                        {
                            modPS.numeroExteriorEX = textBox41.Texts;
                        }
                        if (textBox42.Texts == "Número interior")
                        {

                        }
                        else
                        {
                            modPS.numeroInteriorEX = textBox42.Texts;
                        }

                    }
                    /*
                     * se asignan los atributos a los que si se les han ingresado valores
                     * se comprueba si el campo tiene el valor default, de no ser asi se asigna el valor al particular
                     * en caso de que el atributo tenga algun tipo de formato requerido se comprueba que este sea correcto
                     */
                    if (mn.Id == 0)
                    {

                    }
                    else
                    {
                        modPS.moneda = Convert.ToInt32(mn.Id);
                    }
                    if (textBox8.Texts == "Acto")
                    {

                    }
                    else
                    {
                        modPS.acto = textBox8.Texts;
                    }
                    if (textBox16.Texts == "Objeto contrato")
                    {

                    }
                    else
                    {
                        modPS.objetoContrato = textBox16.Texts;
                    }
                    if (textBox9.Texts == "Siglas")
                    {

                    }
                    else
                    {
                        modPS.siglasInstitucionDependencia = textBox9.Texts;
                    }
                    if (textBox10.Texts == "Clave")
                    {

                    }
                    else
                    {
                        modPS.claveInstitucionDependencia = textBox10.Texts;
                    }
                    if (textBox11.Texts == "Observaciones")
                    {

                    }
                    else
                    {
                        modPS.observaciones = textBox11.Texts;
                    }
                    if (textBox6.Texts == "Sentido")
                    {

                    }
                    else
                    {
                        modPS.sentidoResolucion = textBox6.Texts;
                    }

                    if (textBox13.Texts == "URL")
                    {

                    }
                    else
                    {
                        modPS.urlResolucion = textBox13.Texts;
                    }
                    if (textBox2.Texts == "Segundo apellido")
                    {

                    }
                    else
                    {
                        if (matchM.Success)
                        {
                            modPS.segundoApellidoRS = textBox2.Texts;
                            errorProvider1.SetError(textBox2, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox2, "Se necesita un apellido válido");
                            valor = false;
                        }

                    }
                    if (textBox23.Texts == "Plazo")
                    {

                    }
                    else
                    {
                        modPS.plazoInhabilitacion = textBox23.Texts;
                    }
                    if (textBox24.Texts == "Monto")
                    {

                    }
                    else
                    {
                        modPS.monto = Convert.ToInt32(textBox24.Texts);
                    }
                    if (textBox26.Texts == "Teléfono")
                    {

                    }
                    else
                    {
                        modPS.telefono = Convert.ToString(textBox26.Texts);
                    }
                    if (textBox25.Texts == "Objeto social")
                    {

                    }
                    else
                    {
                        modPS.objetoSocial = textBox25.Texts;
                    }
                    if (textBox31.Texts == "Nombre(s)")
                    {

                    }
                    else
                    {
                        if (matchN.Success)
                        {
                            modPS.nombresDG = textBox31.Texts;
                            errorProvider1.SetError(textBox31, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox31, "Se necesita un nombre válido");
                            valor = false;
                        }
                    }
                    if (textBox30.Texts == "Primer apellido")
                    {

                    }
                    else
                    {
                        if (matchP.Success)
                        {
                            modPS.primerApellidoDG = textBox30.Texts;
                            errorProvider1.SetError(textBox30, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox30, "Se necesita un apellido válido");
                            valor = false;
                        }
                    }
                    if (textBox29.Texts == "Segundo apellido")
                    {

                    }
                    else
                    {
                        if (matchM.Success)
                        {
                            modPS.segundoApellidoDG = textBox29.Texts;
                            errorProvider1.SetError(textBox29, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox29, "Se necesita un apellido válido");
                            valor = false;
                        }
                    }
                    if (textBox28.Texts == "CURP")
                    {

                    }
                    else
                    {
                        if (matchC.Success)
                        {
                            modPS.curpDG = textBox28.Texts;
                            errorProvider1.SetError(textBox28, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox28, "Se necesita un CURP válido");
                            valor = false;
                        }
                    }
                    if (textBox35.Texts == "Nombre(s)")
                    {

                    }
                    else
                    {
                        if (matchN.Success)
                        {
                            modPS.nombresAL = textBox35.Texts;
                            errorProvider1.SetError(textBox35, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox35, "Se necesita un nombre válido");
                            valor = false;
                        }

                    }
                    if (textBox32.Texts == "Primer apellido")
                    {

                    }
                    else
                    {
                        if (matchP.Success)
                        {
                            modPS.primerApellidoAL = textBox32.Texts;
                            errorProvider1.SetError(textBox32, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox32, "Se necesita un apellido válido");
                            valor = false;
                        }
                    }
                    if (textBox27.Texts == "Segundo apellido")
                    {

                    }
                    else
                    {
                        if (matchM.Success)
                        {
                            modPS.segundoApellidoAL = textBox27.Texts;
                            errorProvider1.SetError(textBox27, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox27, "Se necesita un apellido válido");
                            valor = false;
                        }
                    }
                    if (textBox15.Texts == "CURP")
                    {

                    }
                    else
                    {
                        if (matchC.Success)
                        {
                            modPS.curpAL = textBox15.Texts;
                            errorProvider1.SetError(textBox15, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox15, "Se necesita un CURP válido");
                            valor = false;
                        }

                    }

                    //los campos que son obligatorios se asignan sin condicional, ya que se comprobo que estos tuvieran informacion en un inicio
                    modPS.causaMotivoHechos = textBox17.Texts;
                    modPS.tipoFalta = textBox12.Texts;
                    modPS.nombreInstitucionDependencia = textBox7.Texts;
                    modPS.autoridadSancionadora = textBox5.Texts;
                    modPS.nombreRS = textBox4.Texts;
                    modPS.primerApellidoRS = textBox3.Texts;
                    modPS.tipoPersona = comboBox9.Text;
                    modPS.nombreRazonSocial = textBox19.Texts;
                    modPS.expediente = textBox20.Texts;
                    modPS.rfcPS = textBox18.Texts;

                    //con las fechas ya se comprobo si tienen o no un valor, de no tener se quedan con valor null, asi que estas variables se asignan siempre a lo atributos
                    modPS.fechaResolucion = f1;
                    modPS.fechaInicialInhabilitacion = f2;
                    modPS.fechaFinalInhabilitacion = f3;

                    //si la variable de valor no ha cambado de valor, significa que todos los atributos necesarios estan llenos y con formato correcto 
                    if (valor == true)
                    {
                        //se guarda el particular
                        conPS.guardarPS(modPS);

                        //se guardan las sanciones
                        foreach (DataGridViewRow fila in dataGridView1.Rows)
                        {
                            conPS.guardarSancionPS(Convert.ToInt16(fila.Cells["ID"].Value), Convert.ToString(fila.Cells["Descripcion"].Value));
                        }

                        //se guardan los documentos
                        foreach (DataGridViewRow fila2 in dataGridView2.Rows)
                        {
                            conPS.guardarDocumentoPS(Convert.ToInt16(fila2.Cells["idxd"].Value), Convert.ToString(fila2.Cells["Titulo"].Value), Convert.ToString(fila2.Cells["descripcionxd"].Value), Convert.ToString(fila2.Cells["URL"].Value), Convert.ToString(fila2.Cells["Fecha"].Value));
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
    }
}
