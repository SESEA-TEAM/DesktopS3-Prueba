using Sistema_de_sanciones.Controladores;
using Sistema_de_sanciones.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_sanciones
{
    public partial class Datos_PS : Form
    {
        controlador1PS consPS = new controlador1PS();
        int idPS;

        private Form2 form2Handler;
        public Datos_PS(Form2 form2, int id)
        {
            idPS = id;
            InitializeComponent();

            cargarDatos();
            form2Handler = form2;
        }

        private void cargarDatos()
        {
            modeloPS mps = new modeloPS();
            mps = consPS.CsdsdargarPS(idPS);

            labelExpediente.Text = mps.expediente;
            labelFEAC.Text = (mps.ultimaActualizacion.Remove(10, 15));
            labelAUSA.Text = mps.autoridadSancionadora;
            labelCMH.Text = mps.causaMotivoHechos;

            labelRFC.Text = mps.rfcPS;
            labelNR.Text = mps.nombreRazonSocial;
            labelTF.Text = mps.tipoFalta;

            labelNMID.Text = mps.nombreInstitucionDependencia;
            labelNMRS.Text = mps.nombreRS;
            labelPARS.Text = mps.primerApellidoRS;

            //campos de responsable sancion
            if (mps.segundoApellidoRS == null)
            {
                labelSARS.Text = "DNC";
            }
            else
            {
                labelSARS.Text = mps.segundoApellidoRS;
            }
            if (mps.telefono == null)
            {
                labelTelefono.Text = "DNC";
            }
            else
            {
                labelTelefono.Text = mps.telefono;
            }

            //campos generales de la sancion
            if (mps.tipoFalta == null)
            {
                labelTF.Text = "DNC";
            }
            else
            {
                labelTF.Text = Convert.ToString(mps.tipoFalta);
            }
            if (mps.tipoPersona == null)
            {
                labelTP.Text = "DNC";
            }
            else
            {
                labelTP.Text = Convert.ToString(mps.tipoPersona);
            }
            if (mps.objetoSocial == null)
            {
                labelObj.Text = "DNC";
            }
            else
            {
                labelObj.Text = Convert.ToString(mps.objetoSocial);
            }
            if (mps.acto == null)
            {
                labelActo.Text = "DNC";
            }
            else
            {
                labelActo.Text = Convert.ToString(mps.acto);
            }

            if (mps.paisMX == null && mps.paisEX == null)
            {
                panel6.Visible = false;
                //panel6.Top -= 200;
                panel7.Visible = false;
                //panel7.Top -= 200;
                //panel4.Top += 200;
            }
            else
            {
                //campos de direccion mexico
                if (mps.paisMX == null)
                {
                    panel6.Visible = false;
                }
                else
                {
                    panel6.Visible = true;
                    panel4.Top += panel7.Height;
                    if (mps.entidadFederativaV == null)
                    {
                        labelEF.Text = "DNC";
                    }
                    else
                    {
                        labelEF.Text = mps.entidadFederativaV;
                    }
                    if (mps.municipioV == null)
                    {
                        labelMunicipio.Text = "DNC";
                    }
                    else
                    {
                        labelMunicipio.Text = mps.municipioV;
                    }
                    if (mps.localidadV == null)
                    {
                        labelLocalidad.Text = "DNC";
                    }
                    else
                    {
                        labelLocalidad.Text = mps.localidadV;
                    }
                    if (mps.vialidadV == null)
                    {
                        labelVialidad.Text = "DNC";
                    }
                    else
                    {
                        labelVialidad.Text = mps.vialidadV;
                    }
                    if (mps.codigoPostalMX == null)
                    {
                        labelCOPMX.Text = "DNC";
                    }
                    else
                    {
                        labelCOPMX.Text = mps.codigoPostalMX;
                    }
                    if (mps.numeroExteriorMX == null)
                    {
                        labelNEMX.Text = "DNC";
                    }
                    else
                    {
                        labelNEMX.Text = mps.numeroExteriorMX;
                    }
                    if (mps.numeroInteriorMX == null)
                    {
                        labelNIMX.Text = "DNC";
                    }
                    else
                    {
                        labelNIMX.Text = mps.numeroInteriorMX;
                    }
                }

                //campos de direccion extranjero
                if (mps.paisEX == null)
                {
                    panel7.Visible = false;
                    labelPais.Text = "DNC";
                }
                else
                {
                    panel7.Visible = true;
                    panel4.Top += panel7.Height;
                    labelPais.Text = mps.paisV;
                }
                if (mps.calle == null)
                {
                    labelCalle.Text = "DNC";
                }
                else
                {
                    labelCalle.Text = mps.calle;
                }
                if (mps.ciudadLocalidad == null)
                {
                    labelCILO.Text = "DNC";
                }
                else
                {
                    labelCILO.Text = mps.ciudadLocalidad;
                }
                if (mps.estadoProvincia == null)
                {
                    labelESPR.Text = "DNC";
                }
                else
                {
                    labelESPR.Text = mps.estadoProvincia;
                }
                if (mps.codigoPostalEX == null)
                {
                    labelCOPEX.Text = "DNC";
                }
                else
                {
                    labelCOPEX.Text = mps.codigoPostalEX;
                }
                if (mps.numeroExteriorEX == null)
                {
                    labelNEEX.Text = "DNC";
                }
                else
                {
                    labelNEEX.Text = mps.numeroExteriorEX;
                }
                if (mps.numeroInteriorEX == null)
                {
                    labelNIEX.Text = "DNC";
                }
                else
                {
                    labelNIEX.Text = mps.numeroInteriorEX;
                }
            }
            //panel4.Visible = false;

            //campos de institucion dependencia
            if (mps.claveInstitucionDependencia == null)
            {
                labelClave.Text = "DNC";
            }
            else
            {
                labelClave.Text = mps.claveInstitucionDependencia;
            }

            if (mps.siglasInstitucionDependencia == null)
            {
                labelSiglas.Text = "DNC";
            }
            else
            {
                labelSiglas.Text = mps.siglasInstitucionDependencia;
            }

            //campos de resolucion
            if (mps.sentidoResolucion == null)
            {
                labelSentido.Text = "DNC";
            }
            else
            {
                labelSentido.Text = mps.sentidoResolucion;
            }
            if (mps.fechaResolucion == null)
            {
                labelFR.Text = "DNC";
            }
            else
            {
                labelFR.Text = mps.fechaResolucion.Remove(10, 15);
            }
            if (mps.urlResolucion == null)
            {
                labelURL.Text = "DNC";
            }
            else
            {
                labelURL.Text = mps.urlResolucion;
            }

            //campos de inhabilitacion
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
                labelObservaciones.Text = "DNC";
            }
            else
            {
                labelObservaciones.Text = mps.observaciones;
            }

            //campos de director general
            if (mps.nombresDG == null)
            {
                labelNMDG.Text = "DNC";
            }
            else
            {
                labelNMDG.Text = mps.nombresDG;
            }
            if (mps.curpDG == null)
            {
                labelCURPDG.Text = "DNC";
            }
            else
            {
                labelCURPDG.Text = mps.curpDG; ;
            }
            if (mps.primerApellidoDG == null)
            {
                labelPADG.Text = "DNC";
            }
            else
            {
                labelPADG.Text = mps.primerApellidoDG;
            }
            if (mps.segundoApellidoDG == null)
            {
                labelSADG.Text = "DNC";
            }
            else
            {
                labelSADG.Text = mps.segundoApellidoDG;
            }

            //campos de apoderado legal
            if (mps.nombresAL == null)
            {
                labelNMAL.Text = "DNC";
            }
            else
            {
                labelNMAL.Text = mps.nombresAL;
            }
            if (mps.curpAL == null)
            {
                labelCURPAL.Text = "DNC";
            }
            else
            {
                labelCURPAL.Text = mps.curpAL; ;
            }
            if (mps.primerApellidoAL == null)
            {
                labelPAAL.Text = "DNC";
            }
            else
            {
                labelPAAL.Text = mps.primerApellidoAL;
            }
            if (mps.segundoApellidoAL == null)
            {
                labelSAAL.Text = "DNC";
            }
            else
            {
                labelSAAL.Text = mps.segundoApellidoAL;
            }

            //campos de multa
            if (mps.monto == null)
            {
                labelMulta.Text = "DNC";
            }
            else
            {
                labelMulta.Text = Convert.ToString(mps.monto);
            }
            if (mps.moneda2 == null)
            {
                labelMoneda.Text = "DNC";
            }
            else
            {
                labelMoneda.Text = mps.moneda2;
            }



            List<modeloTipoSancion> listaSancionesPS = new List<modeloTipoSancion>();
            listaSancionesPS = consPS.obtenerSancionesPS(idPS);
            for (var i = 0; i < listaSancionesPS.Count; i++)
            {
                dataGridView1.Rows.Add(listaSancionesPS[i].id, listaSancionesPS[i].valor, listaSancionesPS[i].descripcion);

            }
            List<modeloTipoDocumento> listaDocsPS = new List<modeloTipoDocumento>();
            listaDocsPS = consPS.obtenerDocumentosPS(idPS);
            for (var i = 0; i < listaDocsPS.Count; i++)
            {
                dataGridView2.Rows.Add(listaDocsPS[i].Id, listaDocsPS[i].tituloDocumento, listaDocsPS[i].tipoDocumento, listaDocsPS[i].descripcionDocumento, listaDocsPS[i].urlDocumento, listaDocsPS[i].fechaDocumento.Remove(10, 15));

            }

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label92_Click(object sender, EventArgs e)
        {

        }

        private void label115_Click(object sender, EventArgs e)
        {

        }

        private void label122_Click(object sender, EventArgs e)
        {

        }

        private void label114_Click(object sender, EventArgs e)
        {

        }

        private void label121_Click(object sender, EventArgs e)
        {

        }

        private void label113_Click(object sender, EventArgs e)
        {

        }

        private void label120_Click(object sender, EventArgs e)
        {

        }

        private void label119_Click(object sender, EventArgs e)
        {

        }

        private void label118_Click(object sender, EventArgs e)
        {

        }

        private void label111_Click(object sender, EventArgs e)
        {

        }

        private void label106_Click(object sender, EventArgs e)
        {

        }

        private void label117_Click(object sender, EventArgs e)
        {

        }

        private void label109_Click(object sender, EventArgs e)
        {

        }

        private void label103_Click(object sender, EventArgs e)
        {

        }

        private void label116_Click(object sender, EventArgs e)
        {

        }

        private void label107_Click(object sender, EventArgs e)
        {

        }

        private void label100_Click(object sender, EventArgs e)
        {

        }

        private void label104_Click(object sender, EventArgs e)
        {

        }

        private void label99_Click(object sender, EventArgs e)
        {

        }

        private void label123_Click(object sender, EventArgs e)
        {

        }

        private void label101_Click(object sender, EventArgs e)
        {

        }

        private void label96_Click(object sender, EventArgs e)
        {

        }

        private void label97_Click(object sender, EventArgs e)
        {

        }

        private void label93_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form2Handler.ListaPS();
        }
    }
}
