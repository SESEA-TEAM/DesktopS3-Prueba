using Sistema_de_sanciones.Controladores;
using Sistema_de_sanciones.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_sanciones.Modelo;
//using static System.Net.Mime.MediaTypeNames;

namespace Sistema_de_sanciones
{
    public partial class Listado_PS : Form
    {
        controladorPS objs = new controladorPS();
        DataSet dsTable;
        int ContadorTotal;
        String? FA = null;
        String? EX = null;
        String? ISD = null;
        String? NM = null;
        String? TS = null;
        String? IH = null;
        String? TP = null;


        public Listado_PS()
        {
            InitializeComponent();
            dateTimePicker1.Value = new DateTime(2000, 01, 01);
            dateTimePicker2.Value = new DateTime(2000, 01, 01);
            botonPrimero.Enabled = false;
            botonAnterior.Enabled = false;
            botonSiguiente.Enabled = false;
            botonUltimo.Enabled = false;
            List<string> lista = new List<string>();
            lista.Add("Tipo Persona");
            lista.Add("Fisica");
            lista.Add("Moral");
            comboBox1.DataSource = lista;
            listarTipoSancion();
            //CargarDB();
        }

        //listarTipoSancion sera nuestro metodo para los valores de nuestra tabla tipoSancion dentro de un comboBox
        private void listarTipoSancion()
        {
            //La primera linea sirve para indicarle a nuestro comboBox la ubicacion donde este debera tomar los valores, en este caso del
            //controladorListaTipoSancion, mientras que la segunda linea sera para indicarle cual valor de la tabla desplegara, en este caso es valor.
            comboBox2.DataSource = new controladorTipoSancion().obtenerListaSancionesPS();
            comboBox2.ValueMember = "valor";

        }

        private void CargarDB()
        {

            if (Convert.ToString(dateTimePicker1.Text) == "2000-01-01")
            {
                FA = null;
            }
            else
            {
                FA = Convert.ToString(dateTimePicker1.Text);
            }
            if (Convert.ToString(dateTimePicker2.Text) == "2000-01-01")
            {
                IH = null;
            }
            else
            {
                IH = Convert.ToString(dateTimePicker2.Text);
            }
            if (textExpediente.Texts == "Expediente")
            {
                EX = null;
            }
            else
            {
                EX = textExpediente.Texts;
            }
            if (textISD.Texts == "Institución / Dependencia")
            {
                ISD = null;
            }
            else
            {
                ISD = textISD.Texts;
            }
            if (textNombre.Texts == "Nombre/Razón social")
            {
                NM = null;
            }
            else
            {
                NM = textNombre.Texts;
            }

            if (comboBox1.Text == "Tipo Persona")
            {
                TP = null;
            }
            else
            {
                TP = comboBox1.Text;
            }

            modeloTipoSancion TipoS = (modeloTipoSancion)comboBox2.SelectedItem;
            if (TipoS.id == 0)
            {
                TS = null;
            }
            else
            {
                TS = Convert.ToString(TipoS.valor);
            }
            



            objs.Inicio2 = 1;

            ContadorTotal = objs.UltimoBarraListadoPS(EX, ISD, NM, TP, TS, FA, IH);

            if (ContadorTotal <= 10)
            {
                botonPrimero.Enabled = false;
                botonAnterior.Enabled = false;
                botonSiguiente.Enabled = false;
                botonUltimo.Enabled = false;
                objs.Final2 = ContadorTotal;
            }
            else
            {
                objs.Final2 = 10;
                botonSiguiente.Enabled = true;
                botonUltimo.Enabled = true;
            }

            dsTable = objs.BarraListadoPS(EX, ISD, NM, TP, TS, FA, IH);
            dataGridView1.DataSource = dsTable.Tables[1];
            dataGridView1.Columns[0].Visible = false; //Desactiva la columna ID
            dataGridView1.Columns[1].Width = 120; //Desactiva la columna ID
            dataGridView1.Columns[2].Width = 275;     //Se asigna tamaño a la columna Nombre Completo
            dataGridView1.Columns[3].Width = 275; //Desactiva la columna Nombre
            dataGridView1.Columns[4].Width = 75; //Desactiva la columna Primer Apellido
            dataGridView1.Columns[5].Width = 300; //Desactiva la columna Primer Apellido

            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "Ver";
            Ver.Name = "Ver";
            Ver.Width = 43;
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);

            DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
            btnclm.HeaderText = "Eliminar";
            btnclm.Name = "Eliminar";
            btnclm.Width = 43;
            btnclm.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(btnclm);

            DataGridViewButtonColumn editar = new DataGridViewButtonColumn();
            editar.HeaderText = "Editar";
            editar.Name = "Editar";
            editar.Width = 43;
            editar.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(editar);


            botonAnterior.Enabled = false;

            label10.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2) + " de: " + ContadorTotal.ToString();

        }
        private void limpiarBusqueda()
        {
            dateTimePicker1.Text = "2000-01-01";
            dateTimePicker2.Text = "2000-01-01";
            textExpediente.Texts = "Expediente";
            textISD.Texts = "Institución / Dependencia";
            textNombre.Texts = "Nombre/Razón social";
            comboBox1.Text = "Tipo Persona";
            comboBox2.Text = "Tipo Sancion";
            FA = null;
            EX = null;
            ISD = null;
            NM = null;
            TP = null;
            TS = null;
            IH = null;

        }

        private void Listado_PS_Load(object sender, EventArgs e)
        {
            
        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            objs.Inicio2 = 1;
            objs.Final2 = 10;
            //Cargamos nuevamente el metodo CargarDB y ponemos los datos dentro de nuestro dataGridView.
            CargarDB();
            dataGridView1.DataSource = dsTable.Tables[1];

            //La siguiente linea es nuestro contador de total de registros, en este almacenaremos en un valor el numero de registros totales dentro de nuestra
            //base de datos, pues este valor sera de mucha importancia para indicarle al programa cuando debera de desabilitar los botones para ir al siguiente
            //registro y el anterior, todo esto a traves del metodo UltimoBarraListadoSPS, el cual definimos en nuestro controlador.
            //ContadorTotal = objs.UltimoBarraListadoSPS(EX, ISD, NM, PA, SA, FA, IH);
            //ContadorTotal = objs.UltimoBarraListadoSPS(EX, ISD, NM, PA, SA, FA, IH);
            botonPrimero.Enabled = false;
            botonAnterior.Enabled = false;

            label10.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2) + " de: " + ContadorTotal.ToString();
        }

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
            dsTable = objs.BarraListadoPS(EX, ISD, NM, TP, TS, FA, IH);
            dataGridView1.DataSource = dsTable.Tables[1];
            botonAnterior.Enabled = false;

            label10.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2) + " de: " + ContadorTotal.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            objs.Inicio2 = objs.Inicio2 - 10;
            objs.Final2 = objs.Inicio2 + 10;
            botonSiguiente.Enabled = true;
            if (objs.Inicio2 <= 1)
            {
                botonAnterior.Enabled = false;
            }
            dsTable.Clear();
            dsTable = objs.BarraListadoPS(EX, ISD, NM, TP, TS, FA, IH);
            dataGridView1.DataSource = dsTable.Tables[1];
            label10.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2 - 1) + " de: " + ContadorTotal.ToString();
        }

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
                dsTable = objs.BarraListadoPS(EX, ISD, NM, TP, TS, FA, IH);
                dataGridView1.DataSource = dsTable.Tables[1];
                label10.Text = "Registros: " + objs.Inicio2 + " - " + ContadorTotal + " de: " + ContadorTotal.ToString();
            }
            else
            {

                objs.Final2 = objs.Inicio2 + 10;


                botonPrimero.Enabled = true;

                botonAnterior.Enabled = true;
                dsTable.Clear();
                dsTable = objs.BarraListadoPS(EX, ISD, NM, TP, TS, FA, IH);
                dataGridView1.DataSource = dsTable.Tables[1];

                label10.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2 - 1) + " de: " + ContadorTotal.ToString();
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ContadorTotal % 10 == 0)
            {
                objs.Inicio2 = ContadorTotal - (ContadorTotal % 10) + 1 - 10;
                objs.Final2 = objs.Inicio2 + 10;
                dsTable.Clear();
                dsTable = objs.BarraListadoPS(EX, ISD, NM, TP, TS, FA, IH);
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
                dsTable = objs.BarraListadoPS(EX, ISD, NM, TP, TS, FA, IH);
                dataGridView1.DataSource = dsTable.Tables[1];
                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                botonSiguiente.Enabled = false;
            }
            label10.Text = "Registros: " + objs.Inicio2 + " - " + ContadorTotal + " de: " + ContadorTotal.ToString();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            limpiarBusqueda();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                Image someImage = Properties.Resources.abajo;

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.abajo.Width;
                var h = Properties.Resources.abajo.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == 7)
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


            if (e.ColumnIndex == 8)
            {
                Image someImage = Properties.Resources.lapiz;

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.lapiz.Width;
                var h = Properties.Resources.lapiz.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
    }
}
