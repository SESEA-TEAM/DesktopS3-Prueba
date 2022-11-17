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
        controlador1SPS conSPS = new controlador1SPS();
        int idSPS;

        private Form2 form2Handler;
        public Datos_SPS(Form2 form2, int id)
        {
            idSPS = id;
            InitializeComponent();
            
            cargarDatos();
            form2Handler = form2;
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

        

        private void cargarDatos()
        {
            modeloSPS mps = new modeloSPS();
            mps = conSPS.CsdsdargarSPS(idSPS);

            labelExpediente.Text = mps.expediente;
            labelFEAC.Text = (mps.ultimaActualizacion.Remove(10, 15));
            labelAUSA.Text = mps.autoridadSancionadora;
            labelCMH.Text = mps.causaMotivoHechos;

            labelCURP.Text = mps.curpSPS;
            labelRFC.Text = mps.rfcSPS;
            labelNombres.Text = mps.nombreSPS;
            labelPRAP.Text = mps.primerApellidoSPS;
            labelPuesto.Text = mps.puestoSPS;
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

            List<modeloTipoSancion> listaSancionesSPS = new List<modeloTipoSancion>();
            listaSancionesSPS = conSPS.obtenerSancionesSPS(idSPS);
            for (var i = 0; i < listaSancionesSPS.Count; i++)
            {
              dataGridView1.Rows.Add(listaSancionesSPS[i].valor, listaSancionesSPS[i].descripcion);

            }
            List<modeloTipoDocumento> listaDocsSPS = new List<modeloTipoDocumento>();
            listaDocsSPS = conSPS.obtenerDocumentosSPS(idSPS);
            for (var i = 0; i < listaDocsSPS.Count; i++)
            {
              dataGridView2.Rows.Add(listaDocsSPS[i].tituloDocumento, listaDocsSPS[i].tipoDocumento, listaDocsSPS[i].descripcionDocumento, listaDocsSPS[i].urlDocumento, listaDocsSPS[i].fechaDocumento.Remove(10, 15));

            }

        }
    }
}
