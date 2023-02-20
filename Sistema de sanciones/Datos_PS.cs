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
        //Estas dos variables son de vital importancia a lo largo del programa, la primera llama al controladorPS para llamar
        //al metodo para cargar los datos, los cuales seran desplegados en su totalidad desde la ventana de visualizacion. la 
        //segunda variable es la que se encarga de decirle al programa cual es la sancion que vamos a visualizar, esto gracias
        //al id de la sancion que vamos a seleccionar desde el dataGridView.
        controlador1PS consPS = new controlador1PS();
        int idPS;

        //Creamos un handler del form2 que es nuestro menu principal para posteriormente asignarle una instancia de este y poder acceder a sus funciones.
        private Form2 form2Handler;

        //Definimos que para llamar a este form se debe de mandar una instancia del form2 que es el menu principal, desde donde este sera llamado. A diferencia
        //que con las capturas o los listados, aqui utilizaremos un segundo parametro, el cual es el ID de la sancion que vayamos a consultar, y para ello
        //colocaremos que el id sea el valor idPS de la sancion que buscamos.
        public Datos_PS(Form2 form2, int id)
        {
            idPS = id;
            InitializeComponent();

            cargarDatos();

            //Asignamos la instancia que llega al mandar a llamar este form a nuestro handler para poder usarlo correctamente en el resto de la ejecucion de este form.
            form2Handler = form2;
            cargarDGV();

        }

        //el metodo cargarDGV como su nombre lo indica, es el metodo que se encarga de cargar el dataGridView, esto para colocarle
        //las medidas que utilizara para cada una de las columnas que lo conforman.
        private void cargarDGV()
        {
            int p = panel8.Width;
            dataGridView1.Columns[1].Width = (Convert.ToInt32(p * 0.5));
            dataGridView1.Columns[2].Width = (Convert.ToInt32(p * 0.5));

            int p2 = panel9.Width;
            dataGridView2.Columns[1].Width = (Convert.ToInt32(p * 0.185));
            dataGridView2.Columns[2].Width = (Convert.ToInt32(p * 0.198));
            dataGridView2.Columns[3].Width = (Convert.ToInt32(p * 0.235));
            dataGridView2.Columns[4].Width = (Convert.ToInt32(p * 0.255));
            dataGridView2.Columns[5].Width = (Convert.ToInt32(p * 0.135));
        }

        //El metodo cargarDatos como su nombre indica, es la llamada al procedimiento CsdsdargarPS, el cual cargara todos los
        //datos de la sancion indicada con el idPS (id de la sancion), para luego cargar todos esos datos en sus respectivos
        //labels.
        private void cargarDatos()
        {
            modeloPS mps = new modeloPS();
            mps = consPS.CsdsdargarPS(idPS);

            //Los labels que no esten dentro de una condicional if, son todos aquellos campos que son obligatorios, por lo que
            //en ningun caso estos apareceran con una cadena vacio y por consecuente, jamas tendran el texto DNC (Dato No Capturado).
            labelExpediente.Text = mps.expediente;
            //En el caso de las fechas, se le agrega una pequeña funcion remove al final de este, pues al cargar el llamado, las fechas
            //apareceran con el formato YYYY-MM-DD y la hora, sin embargo unicamente requerimos de la fecha, por esa razon es que se
            //agrega la funcion.
            labelFEAC.Text = (mps.ultimaActualizacion.Remove(10, 15));
            labelAUSA.Text = mps.autoridadSancionadora;
            labelCMH.Text = mps.causaMotivoHechos;

            labelRFC.Text = mps.rfcPS;
            labelNR.Text = mps.nombreRazonSocial;
            labelTF.Text = mps.tipoFalta;

            labelNMID.Text = mps.nombreInstitucionDependencia;
            labelNMRS.Text = mps.nombreRS;
            labelPARS.Text = mps.primerApellidoRS;

            labelTP.Text = Convert.ToString(mps.tipoPersona);

            //Para los campos que pueden ser nulos, hay dos caminos, el primero donde si dicho campo es nulo, entonces el texto que
            //aparecera en pantalla sera el de DNC, pero en el caso de que dicho campo se haya llenado, entonces aparecera aquel
            //texto o fecha que se haya seleccionado.

            //campos de responsable sancion
            if (mps.segundoApellidoRS == null || mps.segundoApellidoRS == "")
            {
                labelSARS.Text = "DNC";
            }
            else
            {
                labelSARS.Text = mps.segundoApellidoRS;
            }
            if (mps.telefono == null || mps.telefono == "")
            {
                labelTelefono.Text = "DNC";
            }
            else
            {
                labelTelefono.Text = mps.telefono;
            }

            //campos generales de la sancion
            if (mps.objetoSocial == null || mps.objetoSocial == "")
            {
                labelObj.Text = "DNC";
            }
            else
            {
                labelObj.Text = Convert.ToString(mps.objetoSocial);
            }
            if (mps.acto == null || mps.acto == "")
            {
                labelActo.Text = "DNC";
            }
            else
            {
                labelActo.Text = Convert.ToString(mps.acto);
            }

            //Por defecto, los paneles 6 y 7 que son los paneles de domicilio son visibles, pero estos dejaran de ser visibles en el
            //caso de que los campos de pais en ambos sea nulo, o si alguno de los dos es uno, lo que causara que el otro se vuelva
            //invisible.
            //El primer if es para conocer si paisMX y paisEX son nulos, entonces ambos paneles seran nulos.
            if (mps.domMX == false && mps.domEX == false)
            {
                panel6.Visible = false;
                panel7.Visible = false;
            }
            //La condicional else entrara cuando alguno de los dos paises es nulo, pues hay que recordar que ambos no pueden ser
            //no nulos a la vez.
            else
            {
                //campos de direccion mexico
                if (mps.domMX == false)
                {
                    //en el caso de que paisMX sea nulo, el panel 6 (domicilio mexicano) se volvera invisible.
                    panel6.Visible = false;
                }
                //en el caso de que paisMX no sea nulo, entrara en la condicional else, donde el panel 6 se volvera visible,
                //y al panel 4 se le sumara el valor de la altura del panel 6.
                else
                {
                    panel6.Visible = true;
                    panel4.Top += panel6.Height;
                    if (mps.entidadFederativaV == null || mps.entidadFederativaV == "")
                    {
                        labelEF.Text = "DNC";
                    }
                    else
                    {
                        labelEF.Text = mps.entidadFederativaV;
                    }
                    if (mps.municipioV == null || mps.municipioV == "")
                    {
                        labelMunicipio.Text = "DNC";
                    }
                    else
                    {
                        labelMunicipio.Text = mps.municipioV;
                    }
                    if (mps.localidadV == null || mps.localidadV == "")
                    {
                        labelLocalidad.Text = "DNC";
                    }
                    else
                    {
                        labelLocalidad.Text = mps.localidadV;
                    }
                    if (mps.vialidadV == null || mps.vialidadV == "")
                    {
                        labelVialidad.Text = "DNC";
                    }
                    else
                    {
                        labelVialidad.Text = mps.vialidadV;
                    }
                    if (mps.codigoPostalMX == null || mps.codigoPostalMX == "")
                    {
                        labelCOPMX.Text = "DNC";
                    }
                    else
                    {
                        labelCOPMX.Text = mps.codigoPostalMX;
                    }
                    if (mps.numeroExteriorMX == null || mps.numeroExteriorMX == "")
                    {
                        labelNEMX.Text = "DNC";
                    }
                    else
                    {
                        labelNEMX.Text = mps.numeroExteriorMX;
                    }
                    if (mps.numeroInteriorMX == null || mps.numeroInteriorMX == "")
                    {
                        labelNIMX.Text = "DNC";
                    }
                    else
                    {
                        labelNIMX.Text = mps.numeroInteriorMX;
                    }
                }

                //campos de direccion extranjero
                if (mps.domEX == false)
                {
                    //En el caso de que el paisEX sea nulo, entonces el panel 7 (domicilio extranjero) se volvera invisible.
                    panel7.Visible = false;
                    labelPais.Text = "DNC";
                }
                //en el caso de que paisEX no sea nulo, entrara en la condicional else, donde el panel 7 se volvera visible,
                //y al panel 4 se le sumara el valor de la altura del panel 7.
                else
                {
                    panel7.Visible = true;
                    panel4.Top += panel7.Height;
                    labelPais.Text = mps.paisV;
                }
                if (mps.calle == null || mps.calle == "")
                {
                    labelCalle.Text = "DNC";
                }
                else
                {
                    labelCalle.Text = mps.calle;
                }
                if (mps.ciudadLocalidad == null || mps.ciudadLocalidad == "")
                {
                    labelCILO.Text = "DNC";
                }
                else
                {
                    labelCILO.Text = mps.ciudadLocalidad;
                }
                if (mps.estadoProvincia == null || mps.estadoProvincia == "")
                {
                    labelESPR.Text = "DNC";
                }
                else
                {
                    labelESPR.Text = mps.estadoProvincia;
                }
                if (mps.codigoPostalEX == null || mps.codigoPostalEX == "")
                {
                    labelCOPEX.Text = "DNC";
                }
                else
                {
                    labelCOPEX.Text = mps.codigoPostalEX;
                }
                if (mps.numeroExteriorEX == null || mps.numeroExteriorEX == "")
                {
                    labelNEEX.Text = "DNC";
                }
                else
                {
                    labelNEEX.Text = mps.numeroExteriorEX;
                }
                if (mps.numeroInteriorEX == null || mps.numeroInteriorEX == "")
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
            if (mps.claveInstitucionDependencia == null || mps.claveInstitucionDependencia == "")
            {
                labelClave.Text = "DNC";
            }
            else
            {
                labelClave.Text = mps.claveInstitucionDependencia;
            }

            if (mps.siglasInstitucionDependencia == null || mps.siglasInstitucionDependencia == "")
            {
                labelSiglas.Text = "DNC";
            }
            else
            {
                labelSiglas.Text = mps.siglasInstitucionDependencia;
            }

            //campos de resolucion
            if (mps.sentidoResolucion == null || mps.sentidoResolucion == "")
            {
                labelSentido.Text = "DNC";
            }
            else
            {
                labelSentido.Text = mps.sentidoResolucion;
            }
            if (mps.fechaResolucion == null || mps.fechaResolucion == "")
            {
                labelFR.Text = "DNC";
            }
            else
            {
                labelFR.Text = mps.fechaResolucion.Remove(10, 15);
            }
            if (mps.urlResolucion == null || mps.urlResolucion == "")
            {
                labelURL.Text = "DNC";
            }
            else
            {
                labelURL.Text = mps.urlResolucion;
            }

            //campos de inhabilitacion
            if (mps.plazoInhabilitacion == null || mps.plazoInhabilitacion == "")
            {
                labelPlazo.Text = "DNC";
            }
            else
            {
                labelPlazo.Text = mps.plazoInhabilitacion;
            }
            if (mps.fechaInicialInhabilitacion == null || mps.fechaInicialInhabilitacion == "")
            {
                labelFI.Text = "DNC";
            }
            else
            {
                labelFI.Text = mps.fechaInicialInhabilitacion.Remove(10, 15);
            }
            if (mps.fechaFinalInhabilitacion == null || mps.fechaFinalInhabilitacion == "")
            {
                labelFF.Text = "DNC";
            }
            else
            {
                labelFF.Text = mps.fechaFinalInhabilitacion.Remove(10, 15);
            }

            if (mps.observaciones == null || mps.observaciones == "")
            {
                labelObservaciones.Text = "DNC";
            }
            else
            {
                labelObservaciones.Text = mps.observaciones;
            }

            //campos de director general
            if (mps.nombresDG == null || mps.nombresDG == "")
            {
                labelNMDG.Text = "DNC";
            }
            else
            {
                labelNMDG.Text = mps.nombresDG;
            }
            if (mps.curpDG == null || mps.curpDG == "")
            {
                labelCURPDG.Text = "DNC";
            }
            else
            {
                labelCURPDG.Text = mps.curpDG; ;
            }
            if (mps.primerApellidoDG == null || mps.primerApellidoDG == "")
            {
                labelPADG.Text = "DNC";
            }
            else
            {
                labelPADG.Text = mps.primerApellidoDG;
            }
            if (mps.segundoApellidoDG == null || mps.segundoApellidoDG == "")
            {
                labelSADG.Text = "DNC";
            }
            else
            {
                labelSADG.Text = mps.segundoApellidoDG;
            }

            //campos de apoderado legal
            if (mps.nombresAL == null || mps.nombresAL == "")
            {
                labelNMAL.Text = "DNC";
            }
            else
            {
                labelNMAL.Text = mps.nombresAL;
            }
            if (mps.curpAL == null || mps.curpAL == "")
            {
                labelCURPAL.Text = "DNC";
            }
            else
            {
                labelCURPAL.Text = mps.curpAL; ;
            }
            if (mps.primerApellidoAL == null || mps.primerApellidoAL == "")
            {
                labelPAAL.Text = "DNC";
            }
            else
            {
                labelPAAL.Text = mps.primerApellidoAL;
            }
            if (mps.segundoApellidoAL == null || mps.segundoApellidoAL == "")
            {
                labelSAAL.Text = "DNC";
            }
            else
            {
                labelSAAL.Text = mps.segundoApellidoAL;
            }

            //campos de multa
            if (mps.monto == null || mps.monto == 0)
            {
                labelMulta.Text = "DNC";
            }
            else
            {
                labelMulta.Text = Convert.ToString(mps.monto);
            }
            if (mps.moneda2 == null || mps.moneda2 == "")
            {
                labelMoneda.Text = "DNC";
            }
            else
            {
                labelMoneda.Text = mps.moneda2;
            }

            //Los siguientes dos modulos son los que se encargan de enlistar todos los documentos y todas las sanciones en las
            //tablas de visualizar, donde ira colocando una sancion y/o documento, y por cada una que se agregue, se aumentara
            //en 1 un valor de i, hasta que i sea mayor que el contador de la lista de sanciones y documentos respectivamente.
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

        //El boton para salir, el cual cerrara nuestra ventana para volver a cargar nuestra ventana de listados.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            form2Handler.ListaPS();
        }
    }
}
