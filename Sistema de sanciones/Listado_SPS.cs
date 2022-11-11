using Sistema_de_sanciones;
using Sistema_de_sanciones.Controladores;
using Sistema_de_sanciones.Modelo;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

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
        

        public FormListadoSPS()
        {
            InitializeComponent();
            dateTimePicker1.Value = new DateTime(2000, 01, 01);
            dateTimePicker2.Value = new DateTime(2000, 01, 01);
            botonPrimero.Enabled = false;
            botonAnterior.Enabled = false;
            botonSiguiente.Enabled = false;
            botonFinal.Enabled = false;
            listarTipoSancion();
            //CargarDB();
            //List<string> lista = new List<string>();
            //lista.Add("Tipo Sancion");
            //lista.Add("Inhabilitado");
            //lista.Add("Multado");
            //lista.Add("Otro");
            //comboBox1.DataSource = lista;
        }

        //listarTipoSancion sera nuestro metodo para los valores de nuestra tabla tipoSancion dentro de un comboBox
        private void listarTipoSancion()
        {
            //La primera linea sirve para indicarle a nuestro comboBox la ubicacion donde este debera tomar los valores, en este caso del
            //controladorListaTipoSancion, mientras que la segunda linea sera para indicarle cual valor de la tabla desplegara, en este caso es valor.
            comboBox1.DataSource = new controladorTipoSancion().obtenerListaSanciones();
            comboBox1.ValueMember = "valor";

        }

        //El metodo CargarDB sirve para cargar nuestros datos de la base de datos PublicosSancionados en nuestro dataGridView, ademas que aqui es donde le
        //especificaremos al programa los parametros de busqueda que utilizaremos, para ello utilizamos la condicional if, donde si el text dentro de uno
        //de los campos es igual al valor por defecto, el programa lo tomara como una busqueda de todo, pero si se introduce un texto distinto al predeterminado
        //entonces el programa hara la consulta y buscara todos los resultados que coincidan con los parametros indicados.
        private void CargarDB()
        {
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

            dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
            dataGridView1.DataSource = dsTable.Tables[1];
            dataGridView1.Columns[0].Visible = false; //Desactiva la columna ID
            dataGridView1.Columns[1].Width = 120; //Desactiva la columna ID
            dataGridView1.Columns[2].Width = 300;     //Se asigna tamaño a la columna Nombre Completo
            dataGridView1.Columns[3].Width = 300; //Desactiva la columna Nombre
            dataGridView1.Columns[4].Width = 270; //Desactiva la columna Primer Apellido
            //dataGridView1.Columns[5].Width = 250; //Desactiva la columna Primer Apellido

            botonPrimero.Enabled = false;
            botonAnterior.Enabled = false;

            label9.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2) + " de: " + ContadorTotal.ToString();

        }

        //Este evento es el encargado de iniciar la busqueda de los registros en nuestro dataGridView, en este caso los contadores Inicio2 y Final2 regresan
        //a sus valores de 1 y 10, pues cada que se realiza una busqueda, este debe de regresar al primer registro.
        private void button2_Click(object sender, EventArgs e)
        {
            objs.Inicio2 = 1;
            objs.Final2 = 10;
            //Cargamos nuevamente el metodo CargarDB y ponemos los datos dentro de nuestro dataGridView.
            CargarDB();
            dataGridView1.DataSource = dsTable.Tables[1];

            //La siguiente linea es nuestro contador de total de registros, en este almacenaremos en un valor el numero de registros totales dentro de nuestra
            //base de datos, pues este valor sera de mucha importancia para indicarle al programa cuando debera de desabilitar los botones para ir al siguiente
            //registro y el anterior, todo esto a traves del metodo UltimoBarraListadoSPS, el cual definimos en nuestro controlador.
            //ContadorTotal = objs.UltimoBarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
            //ContadorTotal = objs.UltimoBarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
            botonPrimero.Enabled = false;
            botonAnterior.Enabled = false;

            label9.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2) + " de: " + ContadorTotal.ToString();
        }

        private void limpiarBusqueda()
        {
            dateTimePicker1.Text = "2000-01-01";
            dateTimePicker2.Text = "2000-01-01";
            textExpediente.Texts = "Expediente";
            textISD.Texts = "Institución / Dependencia";
            textNombre.Texts = "Nombre(s)";
            textPA.Texts = "Primer apellido";
            textSA.Texts = "Segundo apellido";
            comboBox1.Text = "Tipo Sancion";
            FA = null;
            EX = null;
            ISD = null;
            NM = null;
            PA = null;
            SA = null;
            IH = null;

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
                ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.FromArgb(179, 41, 45), ButtonBorderStyle.Solid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            dsTable.Clear();
            dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
            dataGridView1.DataSource = dsTable.Tables[1];
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
            dsTable.Clear();
            dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
            dataGridView1.DataSource = dsTable.Tables[1];
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
                
                dsTable.Clear();
                dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
                dataGridView1.DataSource = dsTable.Tables[1];
                label9.Text = "Registros: " + objs.Inicio2 + " - " + ContadorTotal + " de: " + ContadorTotal.ToString();
            }
            else
            {
                
                objs.Final2 = objs.Inicio2 + 10;
                

                botonPrimero.Enabled = true;

                botonAnterior.Enabled = true;
                dsTable.Clear();
                dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
                dataGridView1.DataSource = dsTable.Tables[1];

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
                dsTable.Clear();
                dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
                dataGridView1.DataSource = dsTable.Tables[1];
                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                botonSiguiente.Enabled = false;
            }
            else
            {
                objs.Inicio2 = ContadorTotal - (ContadorTotal % 10) + 1;
                objs.Final2 = objs.Inicio2 + 10;
                dsTable.Clear();
                dsTable = objs.BarraListadoSPS(EX, ISD, NM, PA, SA, TP, FA, IH);
                dataGridView1.DataSource = dsTable.Tables[1];
                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                botonSiguiente.Enabled = false;
            }
            label9.Text = "Registros: " + objs.Inicio2 + " - " + ContadorTotal + " de: " + ContadorTotal.ToString();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiarBusqueda();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}