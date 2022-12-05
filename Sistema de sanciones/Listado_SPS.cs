using Sistema_de_sanciones;
using Sistema_de_sanciones.Properties;
using Sistema_de_sanciones.Controladores;
using Sistema_de_sanciones.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Runtime.ConstrainedExecution;

namespace WinFormsApp1
{
    public partial class FormListadoSPS : Form
    {
        //Declaramos nuestras variables, objs sera el nombre con el que nos referiremos al controlador SPS, dsTable sera el nombre de nuestro dataset para 
        //visualizar los datos en el dataGridView, y las variables EX, ISD, NM, PA y SA seran nuestros valores de entrada.
        controladorSPS objs = new controladorSPS();
        DataSet dsTable;
        int ContadorTotal;
        String? FA = null;
        String? EX = null;
        String? ISD = null;
        String? NM = null;
        String? PA = null;
        String? SA = null;
        String? IH = null;
        String? TP = null;
        List<modeloTipoSancion> lSancion = new controladorTipoSancion().obtenerListaSanciones();

        private Form2 form2Handler;

        public FormListadoSPS(Form2 form2)
        {
            //En este apartado cargamos todos los componentes, asignamos el valor por defecto a los dateTimePicker, desabilitamos
            //los botones de la paginacion, agregamos la lista del tipo de persona, llamamos al metodo del listado tipo sancion, y
            //por ultimo, llamamos al procedimiento para rellenar la base de datos.
            InitializeComponent();
            dateTimePicker1.Value = new DateTime(2000, 01, 01);
            dateTimePicker2.Value = new DateTime(2000, 01, 01);
            botonPrimero.Enabled = false;
            botonAnterior.Enabled = false;
            botonSiguiente.Enabled = false;
            botonFinal.Enabled = false;
            listarTipoSancion();
            IniciarDB();

            form2Handler = form2;

        }

        //listarTipoSancion sera nuestro metodo para los valores de nuestra tabla tipoSancion dentro de un comboBox
        private void listarTipoSancion()
        {
            //La primera linea sirve para indicarle a nuestro comboBox la ubicacion donde este debera tomar los valores, en este caso del
            //controladorListaTipoSancion, mientras que la segunda linea sera para indicarle cual valor de la tabla desplegara, en este caso es valor.
            comboBox1.DataSource = lSancion;
            comboBox1.ValueMember = "valor";

        }

        //Este metodo sirve para carga la base de datos en un inicio y/o cuando utilizamos el boton limpiar; para poder cargar los
        //datos cuando no se ingresan los parametros de busqueda a los que se les asigna el valor cuando utilizan el boton busqueda.
        private void IniciarDB()
        {
            objs.Inicio2 = 1;

            //Llamamos al metodo ultimoBarraListado para poder identificar el numero total de registros que hay, y si hay una cantidad
            //determinada de registros, estos tomaran una via u otra.
            ContadorTotal = objs.UltimoBarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);

            //Si los registros son iguales o menores a 10, los botones de la paginacion seran desabilitados y el contador final sera
            //igual al contador total.
            if (ContadorTotal <= 10)
            {
                botonPrimero.Enabled = false;
                botonAnterior.Enabled = false;
                botonSiguiente.Enabled = false;
                botonFinal.Enabled = false;
                objs.Final2 = ContadorTotal;
            }
            //En el caso de que el contador total sea mayor a 10, entonces se habilitaran los botones para pasar a la siguiente y ultimo
            //registro de la tabla, ademas de asignarle el valor de 10 al contador final.
            else
            {
                objs.Final2 = 10;
                botonSiguiente.Enabled = true;
                botonFinal.Enabled = true;
            }


            //Las siguientes dos lineas son las que se encargar de cargar los datos de nuestra base de datos al dataGridView, el primero es la llamada al
            //procedimiento BarraListadoSPS el cual declaramos en el controladorSPS y es el encargado de realizar la consulta, mientras que la segunda linea
            //carga los datos de la consulta en nuestro dataGridView.
            int p = panel3.Width;
            dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
            dataGridView1.DataSource = dsTable.Tables[1];
            dataGridView1.Columns[0].Width = Convert.ToInt32(p*0.035); //Despliega el id de la tabla temporal.
            dataGridView1.Columns[1].Visible = false;   //Desactiva la columna ID sancion.
            dataGridView1.Columns[2].Width = Convert.ToInt32(p*0.145);  //Despliega el expediente.
            dataGridView1.Columns[3].Width = Convert.ToInt32(p*0.285);  //Despliega la institucion/dependencia.
            dataGridView1.Columns[4].Width = Convert.ToInt32(p*0.224);  //Despliega el nombre completo.
            dataGridView1.Columns[5].Width = Convert.ToInt32(p * 0.224);    //Despliega el tipo de sancion.

            botonPrimero.Enabled = false;
            botonAnterior.Enabled = false;

            //En el caso de que no exista un registro, tanto el contador inicial como el contador final pasaran a ser 0.
            if (ContadorTotal == 0)
            {
                objs.Final2 = ContadorTotal;
                objs.Inicio2 = ContadorTotal;
            }

            //Despliega en el texto de hasta abajo, el numero de registros total y los registros donde nos encontramos, digase
            //1 al 10, 21 al 31, 41 al 47, etc...
            label9.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2) + " de: " + ContadorTotal.ToString();
        }

        //El metodo CargarDB sirve para cargar nuestros datos de la base de datos PublicosSancionados en nuestro dataGridView, ademas que aqui es donde le
        //especificaremos al programa los parametros de busqueda que utilizaremos, para ello utilizamos la condicional if, donde si el text dentro de uno
        //de los campos es igual al valor por defecto, el programa lo tomara como una busqueda de todo, pero si se introduce un texto distinto al predeterminado
        //entonces el programa hara la consulta y buscara todos los resultados que coincidan con los parametros indicados.
        private void CargarDB()
        {
            //Las siguientes condiciones if son para la realizacion de la busqueda, pues si se hace una busqueda, estos buscaran
            //todos aquellos registros que coincidan, y en el caso de que no se coloquen, estos se colocaran como nulos, lo que
            //significa que se buscaran todos los registros con todos los valores en dichos campos que se hayan dejado vacios.
            if (dateTimePicker1.Text == "2000-01-01")
                {
                    FA = null;
                }
                else
                {
                    FA = dateTimePicker1.Text;
                }
                if (dateTimePicker2.Text == "2000-01-01")
                {
                    IH = null;
                }
                else
                {
                    IH = dateTimePicker2.Text;
                }
                if (textExpediente.Texts == "Expediente")
                {

                }
                else
                {
                    EX = textExpediente.Texts;
                }
                if (textISD.Texts == "Institución / Dependencia")
                {

                }
                else
                {
                    ISD = textISD.Texts;
                }
                if (textNombre.Texts == "Nombre(s)")
                {

                }
                else
                {
                    NM = textNombre.Texts;
                }
                if (textPA.Texts == "Primer apellido")
                {

                }
                else
                {
                    PA = textPA.Texts;
                }
                if (textSA.Texts == "Segundo apellido")
                {

                }
                else
                {
                    SA = textSA.Texts;
                }
                modeloTipoSancion TipoS = (modeloTipoSancion)comboBox1.SelectedItem;
                if (TipoS.id == 0)
                {
                    TP = null;
                }
                else
                {
                    TP = Convert.ToString(TipoS.valor);
                }

                //Los valores objs.Inicio2 y Final2 seran nuestros contadores, que nos serviran para navegar entre las distintas paginas del dataGridView.
                //Por otro lado, el valor del contador total sera el encargado de contabilizar el numero de registros de nuestra tabla, tomando como parametros
                //los mismos parametros de busqueda que utilizamos en la busqueda de registros en especificos
                objs.Inicio2 = 1;

                ContadorTotal = objs.UltimoBarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);

                if (ContadorTotal <= 10)
                {
                    botonPrimero.Enabled = false;
                    botonAnterior.Enabled = false;
                    botonSiguiente.Enabled = false;
                    botonFinal.Enabled = false;
                    objs.Final2 = ContadorTotal;
                }
                else
                {
                    objs.Final2 = 10;
                    botonSiguiente.Enabled = true;
                    botonFinal.Enabled = true;
                }


            //Las siguientes dos lineas son las que se encargar de cargar los datos de nuestra base de datos al dataGridView, el primero es la llamada al
            //procedimiento BarraListadoSPS el cual declaramos en el controladorSPS y es el encargado de realizar la consulta, mientras que la segunda linea
            //carga los datos de la consulta en nuestro dataGridView.
            int p = panel3.Width;
            dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
            dataGridView1.DataSource = dsTable.Tables[1];
            dataGridView1.Columns[0].Width = Convert.ToInt32(p * 0.035); //Despliega el id de la tabla temporal.
            dataGridView1.Columns[1].Visible = false;   //Desactiva la columna ID sancion.
            dataGridView1.Columns[2].Width = Convert.ToInt32(p * 0.145);  //Despliega el expediente.
            dataGridView1.Columns[3].Width = Convert.ToInt32(p * 0.285);  //Despliega la institucion/dependencia.
            dataGridView1.Columns[4].Width = Convert.ToInt32(p * 0.224);  //Despliega el nombre completo.
            dataGridView1.Columns[5].Width = Convert.ToInt32(p * 0.224);    //Despliega el tipo de sancion.



            botonPrimero.Enabled = false;
                botonAnterior.Enabled = false;

                label9.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2) + " de: " + ContadorTotal.ToString();
            }

        //Este metodo sirve para cargar el boton para visualizar cada vez que se inicie la base de datos para evitar generar errores.
        private void Form1_Load(object sender, EventArgs e)
        {
            int p = panel3.Width;
            //Se genera 3 nuevas columas con botones.
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = Convert.ToInt32(p * 0.084);
            Ver.FlatStyle = FlatStyle.Flat;
            Ver.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(Ver);
            //this.dataGridView1.Columns["Ver"].Frozen = true;
        }

        //Adiferencia del metodo anterior, este carga los botones nuevamente cada que se realice una busqueda y/o se utilicen los botones
        //del paginador para pasar a la siguiente o anterior pagina.
        private void CargarBotones()
        {
            int p = panel3.Width;
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = Convert.ToInt32(p * 0.084);
            Ver.FlatStyle = FlatStyle.Flat;
            Ver.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(Ver);
            //this.dataGridView1.Columns["Ver"].Frozen = true;
        }

        //Este evento es el encargado de iniciar la busqueda de los registros en nuestro dataGridView, en este caso los contadores Inicio2 y Final2 regresan
        //a sus valores de 1 y 10, pues cada que se realiza una busqueda, este debe de regresar al primer registro.
        private void button2_Click(object sender, EventArgs e)
        {
            objs.Inicio2 = 1;
            objs.Final2 = 10;
            //Cargamos nuevamente el metodo CargarDB y ponemos los datos dentro de nuestro dataGridView.

            dataGridView1.Columns.Remove("Ver");
            CargarDB();
            CargarBotones();

            //La siguiente linea es nuestro contador de total de registros, en este almacenaremos en un valor el numero de registros totales dentro de nuestra
            //base de datos, pues este valor sera de mucha importancia para indicarle al programa cuando debera de desabilitar los botones para ir al siguiente
            //registro y el anterior, todo esto a traves del metodo UltimoBarraListadoSPS, el cual definimos en nuestro controlador.
            botonPrimero.Enabled = false;
            botonAnterior.Enabled = false;

            label9.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2) + " de: " + ContadorTotal.ToString();
        }

        //El metodo limpiar sirve para regresar todos los campos para la busqueda a su estado original, poner como nulo todas
        //las variables que hayamos puesto, y recarga el dataGridView para mostrar nuevamente todos los registros.
        private void limpiarBusqueda()
        {
            dateTimePicker1.Text = "2000-01-01";
            dateTimePicker2.Text = "2000-01-01";
            textExpediente.Texts = "Expediente";
            textISD.Texts = "Institución / Dependencia";
            textNombre.Texts = "Nombre(s)";
            textPA.Texts = "Primer apellido";
            textSA.Texts = "Segundo apellido";
            comboBox1.SelectedItem = lSancion[0];
            FA = null;
            EX = null;
            ISD = null;
            NM = null;
            PA = null;
            SA = null;
            IH = null;

            objs.Inicio2 = 1;
            objs.Final2 = 10;
            //Cargamos nuevamente el metodo CargarDB y ponemos los datos dentro de nuestro dataGridView.

            dataGridView1.Columns.Remove("Ver");
            IniciarDB();
            CargarBotones();

            botonPrimero.Enabled = false;
            botonAnterior.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rjComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
               
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox8_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        //El metodo de nuestro boton para dirigirnos hasta la primera pagina de nuestros registros.
        private void button3_Click(object sender, EventArgs e)
        {
            objs.Inicio2 = 1;
            
            if (ContadorTotal < 10)
            {
                botonPrimero.Enabled = false;
                botonAnterior.Enabled = false;
                botonSiguiente.Enabled = false;
                objs.Final2 = ContadorTotal;
            }
            else
            {
                objs.Final2 = 10;
            }
            
            botonSiguiente.Enabled = true;
            dataGridView1.Columns.Remove("Ver");
            dsTable.Clear();
            dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
            dataGridView1.DataSource = dsTable.Tables[1];
            CargarBotones();

            botonAnterior.Enabled = false;

            label9.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2)+ " de: " + ContadorTotal.ToString();
        }

        //El metodo de nuestro boton para dirigirnos una pagina anterior, en el caso de que hayan menos de 10 registros o estemos en la primera pagina, este
        //boton se desactivara.
        private void button4_Click(object sender, EventArgs e)
        {
            
            objs.Inicio2 = objs.Inicio2 - 10;
            objs.Final2 = objs.Inicio2 + 10;
            botonSiguiente.Enabled = true;
            if (objs.Inicio2 <= 1)
            {
                botonAnterior.Enabled=false;
            }
            dataGridView1.Columns.Remove("Ver");
            dsTable.Clear();
            dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
            dataGridView1.DataSource = dsTable.Tables[1];
            CargarBotones();

            label9.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2 - 1) + " de: " + ContadorTotal.ToString();
        }

        //El metodo de nuestro boton para dirigirnos a la siguiente pagina, en el caso de que hayan menos de 10 registros o estemos en la ultima pagina, este
        //boton se desactivara
        private void button5_Click(object sender, EventArgs e)
        {
            objs.Inicio2 = objs.Inicio2 + 10;
            objs.Final2 = objs.Inicio2 + 10;
            if (objs.Final2 >= ContadorTotal)
            {

                botonSiguiente.Enabled = false;
                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                dataGridView1.Columns.Remove("Ver");
                dsTable.Clear();
                dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
                
                dataGridView1.DataSource = dsTable.Tables[1];
                CargarBotones();
                label9.Text = "Registros: " + objs.Inicio2 + " - " + ContadorTotal + " de: " + ContadorTotal.ToString();
            }
            else
            {
                
                objs.Final2 = objs.Inicio2 + 10;
                

                botonPrimero.Enabled = true;

                botonAnterior.Enabled = true;
                dataGridView1.Columns.Remove("Ver");
                dsTable.Clear();
                
                dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
                dataGridView1.DataSource = dsTable.Tables[1];
                CargarBotones();
                label9.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2 - 1) + " de: " + ContadorTotal.ToString();
            }
            
            
        }

        //El metodo de nuestro boton para dirigirnos a la ultima pagina, en este caso nuestro contador de registros total sera el que determine a la ultima
        //pagina del registro, para ello tendremos dos escenarios, en el primero que es cuando el residuo de nuestro contador total es igual a 0, en ese caso
        //se hace una operacion, donde el contador Inicio2 sera igual al contador total - el residuo de 10 de dicho contador, al cual se le sumara 1 y se
        //le restaran 10, finalmente se le asigna al contador Final2 el valor del contador Inicio2 + 10.
        //El otro escenario es cuando el residuo es distinto de 0, en ese escenario el contador inicio2 sera igual al contador total menos el residuo del
        //contador total entre 10 + 1, y el contador Final2 sera igual al Inicio2 + 10. 
        private void button6_Click(object sender, EventArgs e)
        {
            if(ContadorTotal % 10 == 0)
            {
                objs.Inicio2 = ContadorTotal - (ContadorTotal % 10) + 1 - 10;
                objs.Final2 = objs.Inicio2 + 10;

                dataGridView1.Columns.Remove("Ver");
                dsTable.Clear();
                dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
                dataGridView1.DataSource = dsTable.Tables[1];
                CargarBotones();

                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                botonSiguiente.Enabled = false;
            }
            else
            {
                objs.Inicio2 = ContadorTotal - (ContadorTotal % 10) + 1;
                objs.Final2 = objs.Inicio2 + 10;

                dataGridView1.Columns.Remove("Ver");
                dsTable.Clear();
                dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
                dataGridView1.DataSource = dsTable.Tables[1];
                CargarBotones();

                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                botonSiguiente.Enabled = false;
            }
            label9.Text = "Registros: " + objs.Inicio2 + " - " + ContadorTotal + " de: " + ContadorTotal.ToString();
        }

        //El evento que llama al metodo de limpiar.
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiarBusqueda();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                Image someImage = Sistema_de_sanciones.Properties.Resources.abajo;

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Sistema_de_sanciones.Properties.Resources.abajo.Width;
                var h = Sistema_de_sanciones.Properties.Resources.abajo.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }

        }

        //Este evento es para visualizar los registros al pulsar el boton de ver sobre uno de los registros.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //La primera condicional if, es para determinar si se esta pulsando la columna con el nombre "Ver" del datagridview.
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Ver")
            {
                //La segunda condicional if es para saber si el numero de filas que se haya contado sea mayor a 0.
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    //Despues de eso, se llamara al metodo visualizarPS, donde el numero de la celda actual sea el mismo al
                    //al numero del id de nuestra tabla temporal, donde contiene el id de la sancion.
                    form2Handler.visualizarSPS(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString()));
                    //textExpediente.Texts = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }
            }
        }

        private void textExpediente_Enter(object sender, EventArgs e)
        {
            if (textExpediente.Texts == "Expediente")
            {
                textExpediente.Texts = "";
                textExpediente.ForeColor = Color.Black;
            }
        }

        private void textExpediente_Leave(object sender, EventArgs e)
        {
            if (textExpediente.Texts == "")
            {
                textExpediente.Texts = "Expediente";
                textExpediente.ForeColor = Color.Gray;
            }
        }

        private void textISD_Enter(object sender, EventArgs e)
        {
            if (textISD.Texts == "Institución / Dependencia")
            {
                textISD.Texts = "";
                textISD.ForeColor = Color.Black;
            }
        }

        private void textISD_Leave(object sender, EventArgs e)
        {
            if (textISD.Texts == "")
            {
                textISD.Texts = "Institución / Dependencia";
                textISD.ForeColor = Color.Gray;
            }
        }

        private void textNombre_Enter(object sender, EventArgs e)
        {
            if (textNombre.Texts == "Nombre(s)")
            {
                textNombre.Texts = "";
                textNombre.ForeColor = Color.Black;
            }
        }

        private void textNombre_Leave(object sender, EventArgs e)
        {
            if (textNombre.Texts == "")
            {
                textNombre.Texts = "Nombre(s)";
                textNombre.ForeColor = Color.Gray;
            }
        }

        private void textPA_Enter(object sender, EventArgs e)
        {
            if (textPA.Texts == "Primer apellido")
            {
                textPA.Texts = "";
                textPA.ForeColor = Color.Black;
            }
        }

        private void textPA_Leave(object sender, EventArgs e)
        {
            if (textPA.Texts == "")
            {
                textPA.Texts = "Primer apellido";
                textPA.ForeColor = Color.Gray;
            }
        }

        private void textSA_Enter(object sender, EventArgs e)
        {
            if (textSA.Texts == "Segundo apellido")
            {
                textSA.Texts = "";
                textSA.ForeColor = Color.Black;
            }
        }

        private void textSA_Leave(object sender, EventArgs e)
        {
            if (textSA.Texts == "")
            {
                textSA.Texts = "Segundo apellido";
                textSA.ForeColor = Color.Gray;
            }
        }
    }
}