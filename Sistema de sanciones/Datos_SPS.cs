using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_sanciones.Controladores;
using Sistema_de_sanciones.Modelo;
using Sistema_de_sanciones.Templates;
using WinFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_de_sanciones
{
    public partial class Datos_SPS : Form
    {
        String? f1, f2, f3, f4;
        //Estas dos variables son de vital importancia a lo largo del programa, la primera llama al controladorPS para llamar
        //al metodo para cargar los datos, los cuales seran desplegados en su totalidad desde la ventana de visualizacion. la 
        //segunda variable es la que se encarga de decirle al programa cual es la sancion que vamos a visualizar, esto gracias
        //al id de la sancion que vamos a seleccionar desde el dataGridView.
        controlador1SPS conSPS = new controlador1SPS();
        int idSPS;

        private Form2 form2Handler;
        public Datos_SPS(Form2 form2, int id)
        {
            idSPS = id;
            InitializeComponent();
            
            cargarDatos();
            form2Handler = form2;
            cargarDGV();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void label16_Click(object sender, EventArgs e)
        {

        }
        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form2Handler.ListaSPS();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void cargarDGV()
        {
            int p = panel3.Width;
            dataGridView1.Columns[1].Width = (Convert.ToInt32(p * 0.5));
            dataGridView1.Columns[2].Width = (Convert.ToInt32(p * 0.5));

            int p2 = panel5.Width;
            dataGridView2.Columns[1].Width = (Convert.ToInt32(p * 0.185));
            dataGridView2.Columns[2].Width = (Convert.ToInt32(p * 0.198));
            dataGridView2.Columns[3].Width = (Convert.ToInt32(p * 0.235));
            dataGridView2.Columns[4].Width = (Convert.ToInt32(p * 0.255));
            dataGridView2.Columns[5].Width = (Convert.ToInt32(p * 0.135));
        }

        //El metodo cargarDatos como su nombre indica, es la llamada al procedimiento CsdsdargarSPS, el cual cargara todos los
        //datos de la sancion indicada con el idSPS (id de la sancion), para luego cargar todos esos datos en sus respectivos
        //labels.
        private void cargarDatos()
        {
            modeloSPS mps = new modeloSPS();
            mps = conSPS.CsdsdargarSPS(idSPS);

            //Los labels que no esten dentro de una condicional if, son todos aquellos campos que son obligatorios, por lo que
            //en ningun caso estos apareceran con una cadena vacio y por consecuente, jamas tendran el texto DNC (Dato No Capturado).
            labelExpediente.Text = mps.expediente;
            //En el caso de las fechas, se le agrega una pequeña funcion remove al final de este, pues al cargar el llamado, las fechas
            //apareceran con el formato YYYY-MM-DD y la hora, sin embargo unicamente requerimos de la fecha, por esa razon es que se
            //agrega la funcion.
            labelFEAC.Text = (mps.ultimaActualizacion.Remove(10, 15));
            labelAUSA.Text = mps.autoridadSancionadora;
            labelCMH.Text = mps.causaMotivoHechos;

            labelCURP.Text = mps.curpSPS;
            labelRFC.Text = mps.rfcSPS;
            labelNombres.Text = mps.nombreSPS;
            labelPRAP.Text = mps.primerApellidoSPS;
            labelPuesto.Text = mps.puestoSPS;

            //Para los campos que pueden ser nulos, hay dos caminos, el primero donde si dicho campo es nulo, entonces el texto que
            //aparecera en pantalla sera el de DNC, pero en el caso de que dicho campo se haya llenado, entonces aparecera aquel
            //texto o fecha que se haya seleccionado.
            if (mps.claveInstitucionDependencia == null)
            {
                labelClave.Text = "DNC";
            }
            else
            {
                labelClave.Text = mps.claveInstitucionDependencia;
            }
            
            labelNombre.Text = mps.nombreInstitucionDependencia;

            if (mps.plazoInhabilitacion == null)
            {
                labelPlazo.Text = "DNC";
            }
            else
            {
                labelPlazo.Text = mps.plazoInhabilitacion;
            }
            if (mps.fechaInicialInhabilitacion == null)
            {
                labelFI.Text = "DNC";
            }
            else
            {
                labelFI.Text = mps.fechaInicialInhabilitacion.Remove(10, 15);
            }
            if (mps.fechaFinalInhabilitacion == null)
            {
                labelFF.Text = "DNC";
            }
            else
            {
                labelFF.Text = mps.fechaFinalInhabilitacion.Remove(10, 15);
            }
            if (mps.observaciones == null)
            {
                labelOBS.Text = "DNC";
            }
            else
            {
                labelOBS.Text = mps.observaciones;
            }
            if (mps.segundoApellidoSPS == null)
            {
                labelSEPA.Text = "DNC";
            }
            else
            {
                labelSEPA.Text = mps.segundoApellidoSPS;
            }
            if (mps.nivelSPS == null)
            {
                labelNivel.Text = "DNC";
            }
            else
            {
                labelNivel.Text = mps.nivelSPS;
            }
            if (mps.genero == null)
            {
                labelGenero.Text = "DNC";
            }
            else
            {
                labelGenero.Text = Convert.ToString(mps.genero);
            }
            if (mps.siglasInstitucionDependencia == null)
            {
                labelSiglas.Text = "DNC";
            }
            else
            {
                labelSiglas.Text = mps.siglasInstitucionDependencia;
            }
            
            if (mps.fechaResolucion == null)
            {
                labelFERE.Text = "DNC";
            }
            else
            {
                labelFERE.Text = mps.fechaResolucion.Remove(10, 15);
            }

            if (mps.urlResolucion == null)
            {
                labelURL.Text = "DNC";
            }
            else
            {
                labelURL.Text = mps.urlResolucion;
            }

            if (mps.montoMulta == null)
            {
                labelMulta.Text = "DNC";
            }
            else
            {
                labelMulta.Text = Convert.ToString(mps.montoMulta);
            }
            if (mps.moneda == null)
            {
                labelMoneda.Text = "DNC";
            }
            else
            {
                labelMoneda.Text = mps.moneda;
            }
            if (mps.falta == null)
            {
                labelTF.Text = "DNC";
            }
            else
            {
                labelTF.Text = Convert.ToString(mps.falta);
            }
            if (mps.descripcionFalta == null)
            {
                labelDF.Text = "DNC";
            }
            else
            {
                labelDF.Text = Convert.ToString(mps.descripcionFalta);
            }

            //Los siguientes dos modulos son los que se encargan de enlistar todos los documentos y todas las sanciones en las
            //tablas de visualizar, donde ira colocando una sancion y/o documento, y por cada una que se agregue, se aumentara
            //en 1 un valor de i, hasta que i sea mayor que el contador de la lista de sanciones y documentos respectivamente.
            List<modeloTipoSancion> listaSancionesSPS = new List<modeloTipoSancion>();
            listaSancionesSPS = conSPS.obtenerSancionesSPS(idSPS);
            for (var i = 0; i < listaSancionesSPS.Count; i++)
            {
              dataGridView1.Rows.Add(listaSancionesSPS[i].id, listaSancionesSPS[i].valor, listaSancionesSPS[i].descripcion);

            }
            List<modeloTipoDocumento> listaDocsSPS = new List<modeloTipoDocumento>();
            listaDocsSPS = conSPS.obtenerDocumentosSPS(idSPS);
            for (var i = 0; i < listaDocsSPS.Count; i++)
            {
              dataGridView2.Rows.Add(listaDocsSPS[i].Id, listaDocsSPS[i].tituloDocumento, listaDocsSPS[i].tipoDocumento, listaDocsSPS[i].descripcionDocumento, listaDocsSPS[i].urlDocumento, listaDocsSPS[i].fechaDocumento.Remove(10, 15));

            }

        }
    }
}
