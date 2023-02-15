using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Sistema_de_sanciones.Controladores;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Sistema_de_sanciones.Modelo;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using System.Security.Policy;
using System.Reflection.Metadata;

namespace Sistema_de_sanciones
{
    public partial class CargaMasiva : Form
    {
        //Estas variables se usan para las fechas, cada vez que se guardan
        String? f1, f2, f3, f4;
        String? f5, f6, f7, f8;
        //Estas variables se usan para los catálogos 
        int moned;
        int san;
        int enti;
        int muni;
        int loc;
        int vial;
        int paisE;
        int doc;

        //VARIABLES PARA SPS
        int m, sanSPS, docSPS, faltaSPS, generoSPS;
        //Mandamos a llamar los controladores
        controlador1PS conPS = new controlador1PS();
        controlador1SPS conSPS = new controlador1SPS();

        private DataSet dtsTablas = new DataSet();
        public CargaMasiva()
        {
            InitializeComponent();
            DiseñoInicial();
            /*
            errorProvider1.DataSource = dataGridView1;
            //errorProvider1.DataMember = dataGridView1;
            errorProvider1.ContainerControl = this;
            errorProvider1.BlinkRate = 200;
            */
            //Sistema de los Servidores Públicos Sancionados
            //Sistema de los Particulares Sancionados

            //Esta es la lista para elegir los sistemas 
            List<string> lista = new List<string>();
            lista.Add("Selecciona el sistema*");
            lista.Add("Sistema de los Servidores Públicos Sancionados");
            lista.Add("Sistema de los Particulares Sancionados");
            comboSistema.DataSource = lista;
        }

        private void DiseñoInicial()
        {

           // buttonSeleccionar.Cursor = Cursors.Hand;
           // txtRuta.Enabled = true;
           
           //// dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           // dataGridView1.MultiSelect = false;
           // //dataGridView1.ReadOnly = true;
           // dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
           // dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            
        }
        private void limpiar()
        {
     

            comboSistema.Text = "Selecciona el sistema*";

        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                
              dataGridView1.DataSource = null;
              dataGridView2.DataSource = null;


                txtRuta.Text = oOpenFileDialog.FileName;
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                try
                {
                    FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    //ExcelReaderFactory.CreateBinaryReader = formato XLS
                    //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                    //ExcelReaderFactory.CreateReader = XLS o XLSX
                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);
                    //convierte todas las hojas a un DataSet
                    dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                    foreach (DataTable tabla in dtsTablas.Tables)
                    {
                        cboHojas.Items.Add(tabla.TableName);

                    }
                    cboHojas.SelectedIndex = 0;

                    reader.Close();
                }
                catch
                {
                    MessageBox.Show("El documento se está ejecutando, favor de cerrarlo");

                }
            }

        }
        //En este metodo declaramos las variables para validar cada campo con un regex
        public bool validarCamposPS()
        {
            //Usamos esta variable booleana, cuando el resultado cambia a falso, con una condicional, no guarda
            bool Resultado = true;
            string ClaveExpedientes = @"[ -A-Za-z0-9_(!""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~)]{3,140}";
            string nombreDependencia = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,()]{3,140}$";
            string causaMotivoHecho =  @"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,0-9()]{0,140}$";
            string cadenaTexto = @"[ a-zA-ZÀ-ÿfd]+(\s*[a-zA-ZÀ-ÿfd])[a-zA-ZÀ-ÿfd., ]+$";
            string NoObligatorio = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{0,140}$";
            string ClavePlazo = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,0-9()]{0,50}$";
            string ClavesRFCs = @"^[A-Z&Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]$";
            string Fechas = @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01]){1}$";
            string FechasNobligatoria = @"^([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])){0,10}$";
            string URLS = @"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$";
            string urlNoObligatorio = @"[-A-Za-z0-9_(!""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~)]{0,200}";
            string ClaveSiglas = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{0,50}$";
            string ClaveClave = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{0,140}$";
            string Monto = @"^[0-9.]{0,200}$";
            string Moneda = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ()]{0,141}$";
            string TelefonoNoObligatorio = @"^[0-9]{0,10}$";
            string ClaveObjetoSocial = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{0,100}$";
            string ClaveObjetoSocialClave = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{0,100}$";
            string ClaveEntidad = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,0-9([\\\])-]{0,140}$";
            string ClaveMuni = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,0-9([\\\])-]{0,140}$";
            string ClaveLocalidad = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,0-9([\\\])-]{0,140}$";
            string ClaveCalle = @"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,0-9]{0,140}$";
            string ClaveCiudad = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{0,140}$";
            string ClaveObligatorioPS = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{3,140}$";
            string ClaveObligatorioDependencia = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,()]{3,140}$";
            string ClaveDocumentosPS = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,0-9()]{0,140}$";
            string ClaveCURPPS = @"^[A-Za-z0-9]{0,17}";
            string ClavePais = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,-]{0,140}$";
            string ClaveCodPostalPS = @"^\d{0,50}$";
            string Documentonoobligatorio = @"^[A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ_]{0,140}$";
            string ClaveNumeroExterior = @"^\d{0,50}$";
            //El foreach recorre cada fila del archivo XLSX
            foreach (DataGridViewRow fila1 in dataGridView1.Rows)
            {
                //reseteamos el valor de las variables, para evitar duplicación de información
                moned = 0;
                san = 0;
                enti = 0;
                muni = 0;
                loc = 0;
                vial = 0;
                paisE = 0;
                doc = 0;
                //Evalua cada celda, validando con regex
                bool valExpediente = Regex.IsMatch(fila1.Cells[0].Value.ToString(), ClaveExpedientes);//ok
                bool valNombres = Regex.IsMatch(fila1.Cells[1].Value.ToString(), nombreDependencia);//ok
                bool valRFCs = Regex.IsMatch(fila1.Cells[2].Value.ToString(), ClavesRFCs);//ok
                bool valCausaMotivoHecho = Regex.IsMatch(fila1.Cells[3].Value.ToString(), causaMotivoHecho);//ok
                bool valActo = Regex.IsMatch(fila1.Cells[4].Value.ToString(), NoObligatorio);//ok
                bool valObjContrato = Regex.IsMatch(fila1.Cells[5].Value.ToString(), NoObligatorio);//ok
                bool valTipoFalta = Regex.IsMatch(fila1.Cells[6].Value.ToString(), cadenaTexto);//ok
                bool valNombreInsDep = Regex.IsMatch(fila1.Cells[7].Value.ToString(), ClaveObligatorioDependencia);//ok
                bool valSiglas = Regex.IsMatch(fila1.Cells[8].Value.ToString(), ClaveSiglas);//ok
                bool valClave = Regex.IsMatch(fila1.Cells[9].Value.ToString(), ClaveClave);//ok
                bool Observacion = Regex.IsMatch(fila1.Cells[10].Value.ToString(), causaMotivoHecho);//ok
                bool valAutSancionadora = Regex.IsMatch(fila1.Cells[11].Value.ToString(), cadenaTexto);//ok
                bool valSentido = Regex.IsMatch(fila1.Cells[12].Value.ToString(), NoObligatorio);//ok
                bool valURL = Regex.IsMatch(fila1.Cells[13].Value.ToString(), urlNoObligatorio);//ok
                bool valFechaResolucion = Regex.IsMatch(fila1.Cells[14].Value.ToString(), FechasNobligatoria);//ok
                bool valNombreRespSocial = Regex.IsMatch(fila1.Cells[15].Value.ToString(), cadenaTexto);//ok
                bool valApellidoUnoResp = Regex.IsMatch(fila1.Cells[16].Value.ToString(), cadenaTexto);//OK
                bool valApellidoDosResp = Regex.IsMatch(fila1.Cells[17].Value.ToString(), NoObligatorio);//OK
                bool valPlazo = Regex.IsMatch(fila1.Cells[18].Value.ToString(), ClavePlazo);
                bool valFechaInicial = Regex.IsMatch(fila1.Cells[19].Value.ToString(), FechasNobligatoria);//ok

                bool valFechaFinal = Regex.IsMatch(fila1.Cells[20].Value.ToString(), FechasNobligatoria);//ok
                bool valMonto = Regex.IsMatch(fila1.Cells[21].Value.ToString(), Monto);//ok
                bool valMoneda = Regex.IsMatch(fila1.Cells[22].Value.ToString(), Moneda);//ok
                bool valTipoSancion = Regex.IsMatch(fila1.Cells[23].Value.ToString(), cadenaTexto);//ok
                bool valDescripcion = Regex.IsMatch(fila1.Cells[24].Value.ToString(), causaMotivoHecho);//ok
                bool valTipoPersona = Regex.IsMatch(fila1.Cells[25].Value.ToString(), cadenaTexto);//ok
                bool valTelefono = Regex.IsMatch(fila1.Cells[26].Value.ToString(), TelefonoNoObligatorio);//ok
                ///2DA PARTE
                bool valObjetoSocial = Regex.IsMatch(fila1.Cells[27].Value.ToString(), ClaveObjetoSocialClave);
                bool valNombrePS = Regex.IsMatch(fila1.Cells[28].Value.ToString(), ClaveObjetoSocial);
                bool valPrimerApellidoPS = Regex.IsMatch(fila1.Cells[29].Value.ToString(), ClaveObjetoSocial);
                bool valSegundoApelldoPS = Regex.IsMatch(fila1.Cells[30].Value.ToString(), ClaveObjetoSocial);
                bool valCURPs = Regex.IsMatch(fila1.Cells[31].Value.ToString(), ClaveCURPPS);//ok
                bool valNombreDosPS = Regex.IsMatch(fila1.Cells[32].Value.ToString(), ClaveObjetoSocial);
                bool valPrimerApellidoDosPS = Regex.IsMatch(fila1.Cells[33].Value.ToString(), ClaveObjetoSocial);
                bool valSegundopelldoDosPS = Regex.IsMatch(fila1.Cells[34].Value.ToString(), ClaveObjetoSocial);
                bool valCurpDosPS = Regex.IsMatch(fila1.Cells[35].Value.ToString(), ClaveCURPPS);
                bool valEntidadFederativa = Regex.IsMatch(fila1.Cells[36].Value.ToString(), ClaveEntidad);//ok
                bool valMunicipio = Regex.IsMatch(fila1.Cells[37].Value.ToString(), ClaveMuni);//OK
                bool valLocalidad = Regex.IsMatch(fila1.Cells[38].Value.ToString(), ClaveLocalidad);//OK
                bool valVialidad = Regex.IsMatch(fila1.Cells[39].Value.ToString(), ClaveCalle);//OK
                bool valCodPostal = Regex.IsMatch(fila1.Cells[40].Value.ToString(), ClaveCodPostalPS);//OK
                bool valNumExt = Regex.IsMatch(fila1.Cells[41].Value.ToString(), ClaveNumeroExterior);//OK
                bool valNumInt = Regex.IsMatch(fila1.Cells[42].Value.ToString(), ClaveNumeroExterior);//OK
                bool valCalle = Regex.IsMatch(fila1.Cells[43].Value.ToString(), ClaveCalle);//ok
                bool valCiudad = Regex.IsMatch(fila1.Cells[44].Value.ToString(), ClaveCiudad);
                bool valEstado = Regex.IsMatch(fila1.Cells[45].Value.ToString(), ClaveCiudad);
                bool valCodPostalDos = Regex.IsMatch(fila1.Cells[46].Value.ToString(), ClaveCodPostalPS);
                bool valNumExtDos = Regex.IsMatch(fila1.Cells[47].Value.ToString(), ClaveNumeroExterior);
                bool valNumIntDos = Regex.IsMatch(fila1.Cells[48].Value.ToString(), ClaveNumeroExterior);
                bool valPais = Regex.IsMatch(fila1.Cells[49].Value.ToString(), ClavePais);//ok
                bool valtitulo = Regex.IsMatch(fila1.Cells[50].Value.ToString(), ClaveDocumentosPS);
                bool valTipoDocumento = Regex.IsMatch(fila1.Cells[51].Value.ToString(), Documentonoobligatorio);
                bool valDescripcionDos = Regex.IsMatch(fila1.Cells[52].Value.ToString(), ClaveDocumentosPS);
                bool valURLDos = Regex.IsMatch(fila1.Cells[53].Value.ToString(), urlNoObligatorio);
                bool ValFechaPS = Regex.IsMatch(fila1.Cells[54].Value.ToString(), FechasNobligatoria);
                //Todas estas condicionales, evaluan si la celda ingresaron con lo que corresponde al regex, si es verdadero la variable boleana cambia
                if (!valExpediente)
                {
                    fila1.Cells[0].ErrorText = "Expediente Inválido";
                    Resultado = false;
                }


                if (!valNombres)
                {
                    fila1.Cells[1].ErrorText = "Nombre Inválido";
                    Resultado = false;
                }
                if (!valRFCs)
                {
                    fila1.Cells[2].ErrorText = "RFC Inválido";
                    Resultado = false;
                }
                if (!valCausaMotivoHecho)
                {
                    fila1.Cells[3].ErrorText = "Causa Motivo y Hecho Inválido";
                    Resultado = false;
                }
                if (!valActo)
                {
                    fila1.Cells[4].ErrorText = "Acto Inválido";
                    Resultado = false;
                }

                if (!valObjContrato)
                {
                    fila1.Cells[5].ErrorText = "Objeto Contratante Inválido";
                    Resultado = false;
                }
                if (!valTipoFalta)
                {
                    fila1.Cells[6].ErrorText = "Tipo de Falta Inválida";
                    Resultado = false;
                }
                if (!valNombreInsDep)
                {
                    fila1.Cells[7].ErrorText = "Nombre de la Institución o Dependencia Inválida";
                    Resultado = false;
                }
                if (!valSiglas)
                {
                    fila1.Cells[8].ErrorText = "Siglas Inválidas";
                    Resultado = false;
                }
                if (!valClave)
                {
                    fila1.Cells[9].ErrorText = "Clave Inválida";
                    Resultado = false;
                }
                if (!Observacion)
                {
                    fila1.Cells[10].ErrorText = "Observación Inválida";
                    Resultado = false;
                }

                if (!valAutSancionadora)
                {
                    fila1.Cells[11].ErrorText = "Autoridad Sancionada Inválida";
                    Resultado = false;
                }
                if (!valSentido)
                {
                    fila1.Cells[12].ErrorText = "Sentido de Resolución Inválida";
                    Resultado = false;
                }
                if (!valURL)
                {
                    fila1.Cells[13].ErrorText = "URL Inválida";
                    Resultado = false;
                }
                if (!valFechaResolucion)
                {
                    fila1.Cells[14].ErrorText = "Fecha de Resolución Inválida";
                    Resultado = false;
                }
                if (!valNombreRespSocial)
                {
                    fila1.Cells[15].ErrorText = "Nombre del Responsable Sanción Inválido";
                    Resultado = false;
                }
                if (!valApellidoUnoResp)
                {
                    fila1.Cells[16].ErrorText = "Primer Apellido Inválido";
                    Resultado = false;
                }
                if (!valApellidoDosResp)
                {
                    fila1.Cells[17].ErrorText = "Segundo Apellido Inválido";
                    Resultado = false;
                }
                if (!valPlazo)
                {
                    fila1.Cells[18].ErrorText = "Plazo Inválido";
                    Resultado = false;
                }
                if (!valFechaInicial)
                {
                    fila1.Cells[19].ErrorText = "Fecha Inicial Inválida";
                    Resultado = false;
                }

                if (!valFechaFinal)
                {
                    fila1.Cells[20].ErrorText = "Fecha Final Inválida";
                    Resultado = false;
                }
                if (!valMonto)
                {
                    fila1.Cells[21].ErrorText = "Monto Inválido";
                    Resultado = false;
                }
                if (!valMoneda)
                {
                    fila1.Cells[22].ErrorText = "Moneda Inválida";
                    Resultado = false;
                }
                if (!valTipoSancion)
                {
                    fila1.Cells[23].ErrorText = "Tipo de sanción Inválida";
                    Resultado = false;
                }

                if (!valDescripcion)
                {
                    fila1.Cells[24].ErrorText = "Descripción Inválida";
                    Resultado = false;
                }
                if (!valTipoPersona)
                {
                    fila1.Cells[25].ErrorText = "Tipo de Persona Inválida";
                    Resultado = false;
                }
                if (!valTelefono)
                {
                    fila1.Cells[26].ErrorText = "Teléfono Inválido";
                    Resultado = false;
                }

                //PEPE
                if (!valObjetoSocial)
                {

                    fila1.Cells[27].ErrorText = "Objeto social inválido";
                    Resultado = false;
                }
                if (!valNombrePS)
                {

                    fila1.Cells[28].ErrorText = "Nombre inválido";
                    Resultado = false;
                }
                if (!valPrimerApellidoPS)
                {

                    fila1.Cells[29].ErrorText = "Apellido inválido";
                    Resultado = false;
                }
                if (!valSegundoApelldoPS)
                {

                    fila1.Cells[30].ErrorText = "Segundo apellido inválido";
                    Resultado = false;
                }
                if (!valCURPs)
                {

                    fila1.Cells[31].ErrorText = "CURP inválido";
                    Resultado = false;
                }
                if (!valNombreDosPS)
                {

                    fila1.Cells[32].ErrorText = "Nombre inválido";
                    Resultado = false;
                }
                if (!valPrimerApellidoDosPS)
                {

                    fila1.Cells[33].ErrorText = "Apellido inválido";
                    Resultado = false;
                }
                if (!valSegundopelldoDosPS)
                {

                    fila1.Cells[34].ErrorText = "Segundo apellido inválido";
                    Resultado = false;
                }
                if (!valCurpDosPS)
                {

                    fila1.Cells[35].ErrorText = "CURP inválido";
                    Resultado = false;
                }
                if (!valEntidadFederativa)
                {

                    fila1.Cells[36].ErrorText = "Entidad federativa  inválido";
                    Resultado = false;
                }
                if (!valMunicipio)
                {

                    fila1.Cells[37].ErrorText = "Municipio  inválido";
                    Resultado = false;
                }
                if (!valLocalidad)
                {

                    fila1.Cells[38].ErrorText = "Localidad  inválido";
                    Resultado = false;
                }
                if (!valVialidad)
                {

                    fila1.Cells[39].ErrorText = "Vialidad  inválido";
                    Resultado = false;
                }
                if (!valCodPostal)
                {

                    fila1.Cells[40].ErrorText = "Código postal inválido";
                    Resultado = false;
                }
                if (!valNumExt)
                {

                    fila1.Cells[41].ErrorText = "Número exterior inválido";
                    Resultado = false;
                }
                if (!valNumInt)
                {

                    fila1.Cells[42].ErrorText = "Número interior inválido";
                    Resultado = false;
                }
                if (!valCalle)
                {

                    fila1.Cells[43].ErrorText = "Calle inválida";
                    Resultado = false;
                }
                if (!valCiudad)
                {

                    fila1.Cells[44].ErrorText = "Ciudad inválida";
                    Resultado = false;
                }
                if (!valEstado)
                {

                    fila1.Cells[45].ErrorText = "Estado inválido";
                    Resultado = false;
                }
                if (!valCodPostalDos)
                {

                    fila1.Cells[46].ErrorText = "Código postal inválido";
                    Resultado = false;
                }
                if (!valNumExtDos)
                {

                    fila1.Cells[47].ErrorText = "Número exterior inválido";
                    Resultado = false;
                }
                if (!valNumIntDos)
                {

                    fila1.Cells[48].ErrorText = "Número interior inválido";
                    Resultado = false;
                }
                if (!valPais)
                {

                    fila1.Cells[49].ErrorText = "País inválido";
                    Resultado = false;
                }
                if (!valtitulo)
                {

                    fila1.Cells[50].ErrorText = "Título inválido";
                    Resultado = false;
                }
                if (!valTipoDocumento)
                {

                    fila1.Cells[51].ErrorText = "Tipo documento inválido";
                    Resultado = false;
                }
                if (!valDescripcionDos)
                {

                    fila1.Cells[52].ErrorText = "Descripción inválido";
                    Resultado = false;
                }
                if (!valURLDos)
                {

                    fila1.Cells[53].ErrorText = "URL inválido";
                    Resultado = false;
                }
                if (!ValFechaPS)
                {

                    fila1.Cells[54].ErrorText = "Fecha  inválido";
                    Resultado = false;
                }
                //En esta parte evaluamos los catálogos, si corresponden a lo que se encuentra en la B.D, no marcara error, de lo contrario si 
                if (fila1.Cells[22].Value.ToString() == "")
                {
                   
                }
                else { 
                         if (!(obtenerMonedaID(fila1.Cells[22].Value.ToString()) == -1))
                         {


                         }
                         else
                         {
                              fila1.Cells[22].ErrorText = "No corresponde al catálogo de Moneda";
                                 Resultado = false;
                         }

                }

                if (!(obtenerTipoSancionPSID(fila1.Cells[23].Value.ToString()) == -1))
                {
                    
                }
                else
                {
                    fila1.Cells[23].ErrorText = "No corresponde al catálogo Tipo Sanción";
                    Resultado = false;
                }

                if (fila1.Cells[36].Value.ToString() == "")
                {

                }
                else
                {
                    if (!(obtenerEntidadFederativaID(fila1.Cells[36].Value.ToString()) == -1))
                    {

                        enti = obtenerEntidadFederativaID(fila1.Cells[36].Value.ToString());
                       

                    }
                    else
                    {
                        fila1.Cells[36].ErrorText = "No corresponde al catálogo Entidad federativa";
                        Resultado = false;
                    }
                }
                if (fila1.Cells[37].Value.ToString() == "")
                {

                }
                else
                {
                    if (!(obtenerMunicipioID(fila1.Cells[37].Value.ToString(), enti) == -1))
                    {
                        muni = obtenerMunicipioID(fila1.Cells[37].Value.ToString(), enti);
                        List<modeloMunicipio> lMunicipio = new controladorMunicipio().obtenerListaMunicipio(enti);
                       
                        muni = lMunicipio[muni].id;

                    }
                    else
                    {
                        fila1.Cells[37].ErrorText = "No corresponde al catálogo Municipio";
                        Resultado = false;
                    }
                }
                if (fila1.Cells[38].Value.ToString() == "")
                {

                }
                else
                {
                   
                    if (!(obtenerLocalidadID(fila1.Cells[38].Value.ToString(), muni) == -1))
                    {

                        loc = obtenerLocalidadID(fila1.Cells[38].Value.ToString(), muni);
                        List<modeloLocalidad> lLocalida = new controladorLocalidad().obtenerListaLocalidad(muni);
                      

                    }
                    else
                    {
                        fila1.Cells[38].ErrorText = "No corresponde al catálogo Localidad";
                        Resultado = false;
                    }
                }
                
                if (fila1.Cells[39].Value.ToString() == "")
                {

                }
                else
                {
                    if (!(obtenerVialidadID(fila1.Cells[39].Value.ToString()) == -1))
                    {
             
                    }
                    else
                    {
                        fila1.Cells[39].ErrorText = "No corresponde al catálogo Vialidad";
                        Resultado = false;
                    }
                }

                if (fila1.Cells[49].Value.ToString() == "")
                {

                }
                else
                {
                    if (!(obtenerPaisID(fila1.Cells[49].Value.ToString()) == -1))
                    {
                      

                    }
                    else
                    {
                        fila1.Cells[49].ErrorText = "No corresponde al catálogo país";
                    }
                }

                if (fila1.Cells[51].Value.ToString() == "")
                {
                
                }
                else
                {
                    if (!(obtenerDocumentoID(fila1.Cells[51].Value.ToString()) == -1))
                    {

                    }
                    else
                    {
                        fila1.Cells[51].ErrorText = "No corresponde al catálogo Tipo documento";
                        Resultado = false;
                    }
                }

            }
            return Resultado;
        }

        //En este método declaramos las variables necesarias para validar cada campo con un regex
        public bool validarCamposSPS()
        {
            //Usamos una variable booleana cuando el resultado cambia a false con una condición no la guardará.
            bool Resultado = true;
            string cadenaTexto = @"[ a-zA-ZÀ-ÿfd]+(\s*[a-zA-ZÀ-ÿfd])[a-zA-ZÀ-ÿfd.,() ]+$";
            string NoObligatorio = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{0,100}$"; 
            string cLAVEpLAZO = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,0-9()]{0,100}$";
            string NoObligatorioPuesto = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{0,140}$";
            string ClavesGenero = @"^[A-Z ]{0,10}$";
            string ClaveMoneda = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ()]{0,141}$";
            string ClavesRFC = @"^([A-ZÑ&]{4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$";
            string ClavesCURP = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";
            string Fechas = @"^([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])){0,10}$";
            string ClaveSiglas = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{0,10}$";
            string ClaveExpediente = @"[-A-Za-z0-9_(!""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~)]{3,100}";
            string ClaveClave = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{0,100}$";
            string ClaveTipoFalta = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{0,140}$";
            string Monto = @"^[0-9.]{0,200}$";
            string cadenaDocumento = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ_]{0,140}$";

            string URLSDocumento = @"[-A-Za-z0-9_(!""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~)]{0,200}";
            string FechaDocumento = @"^([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01])){0,10}$";
            string ClaveDesc= @"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,0-9()]{0,140}$";


            // bool valNombre = Regex.IsMatch(, cadenaTexto);

            foreach (DataGridViewRow fila1 in dataGridView2.Rows)
            {
                //Se usan estas variables para resetear el valor de las variables, para evitar duplicar información.
                m = 0;
                sanSPS = 0;
                docSPS = 0; 
                faltaSPS = 0;
                generoSPS = 0;
                //DATOS GENERALES
                bool valNombre = Regex.IsMatch(fila1.Cells[0].Value.ToString(), cadenaTexto);
                bool valApellido = Regex.IsMatch(fila1.Cells[1].Value.ToString(), cadenaTexto);
                bool valapellidoDos = Regex.IsMatch(fila1.Cells[2].Value.ToString(), NoObligatorio);
                bool valGenero = Regex.IsMatch(fila1.Cells[3].Value.ToString(), ClavesGenero);
                bool valRFC = Regex.IsMatch(fila1.Cells[4].Value.ToString(), ClavesRFC);
                bool valCURP = Regex.IsMatch(fila1.Cells[5].Value.ToString(), ClavesCURP);
                bool valPuestoNombre = Regex.IsMatch(fila1.Cells[6].Value.ToString(), NoObligatorioPuesto);
                bool valPuestoNivel = Regex.IsMatch(fila1.Cells[7].Value.ToString(), NoObligatorioPuesto);
                //DATOS INSTITUCIÓN
                bool valNombreInsDep = Regex.IsMatch(fila1.Cells[8].Value.ToString(), cadenaTexto);
                bool valSiglas = Regex.IsMatch(fila1.Cells[9].Value.ToString(), ClaveSiglas);
                bool valClave = Regex.IsMatch(fila1.Cells[10].Value.ToString(), ClaveClave);
                //DATOS DE LA SANCIÓN
                bool valExpediente = Regex.IsMatch(fila1.Cells[11].Value.ToString(), ClaveExpediente);
                bool valTipoFalta = Regex.IsMatch(fila1.Cells[12].Value.ToString(), ClaveTipoFalta);
                bool valDescFalta = Regex.IsMatch(fila1.Cells[13].Value.ToString(), ClaveDesc);
                bool valCausaMotivoHecho = Regex.IsMatch(fila1.Cells[14].Value.ToString(), ClaveDesc);
                bool valObservaciones = Regex.IsMatch(fila1.Cells[15].Value.ToString(), ClaveDesc);
                //DATOS RESOLUCIÓN
                bool valAutSancionada = Regex.IsMatch(fila1.Cells[16].Value.ToString(), cadenaTexto);
                bool valFechResolucion = Regex.IsMatch(fila1.Cells[17].Value.ToString(), Fechas);
                bool valURL = Regex.IsMatch(fila1.Cells[18].Value.ToString(), URLSDocumento);
                //DATOS INHABILITACIÓN
                bool valPlazo = Regex.IsMatch(fila1.Cells[19].Value.ToString(), cLAVEpLAZO);
                bool valFechInicial = Regex.IsMatch(fila1.Cells[20].Value.ToString(), Fechas);
                bool valFechFinal = Regex.IsMatch(fila1.Cells[21].Value.ToString(), Fechas);
                //DATOS MULTA
                bool valMonto = Regex.IsMatch(fila1.Cells[22].Value.ToString(), Monto);
                bool valMoneda = Regex.IsMatch(fila1.Cells[23].Value.ToString(), ClaveMoneda);
                //DATOS TIPO SANCIÓN
                bool valTSancion = Regex.IsMatch(fila1.Cells[24].Value.ToString(), cadenaTexto);
                bool valDescSancion = Regex.IsMatch(fila1.Cells[25].Value.ToString(), ClaveDesc);
                //DATOS DOCUMENTOS
                bool valTitulo = Regex.IsMatch(fila1.Cells[26].Value.ToString(), ClaveDesc);
                bool valTipoDocumento = Regex.IsMatch(fila1.Cells[27].Value.ToString(), cadenaDocumento);
                bool valDescDocumento = Regex.IsMatch(fila1.Cells[28].Value.ToString(), ClaveDesc);
                bool valDocURL = Regex.IsMatch(fila1.Cells[29].Value.ToString(), URLSDocumento);
                bool valFecha = Regex.IsMatch(fila1.Cells[30].Value.ToString(), FechaDocumento);

                //Estas condiciones validan cada una de las celdas conforme al regex asignado, si alguna no cumple con el regex mandara un msj de error.
                if (!valNombre)
                {
                    fila1.Cells[0].ErrorText = "Nombre inválido";
                    Resultado = false;
                }

                if (!valApellido)
                {
                    fila1.Cells[1].ErrorText = "Primer Apellido inválido";
                    Resultado = false;
                }
                if (!valapellidoDos)
                {
                    fila1.Cells[2].ErrorText = "Segundo Apellido inválido";
                    Resultado = false;
                }
                if (!valGenero)
                {
                    fila1.Cells[3].ErrorText = "Género inválido";
                    Resultado = false;
                }
                if (!valRFC)
                {
                    fila1.Cells[4].ErrorText = "RFC inválido";
                    Resultado = false;
                }
                if (!valCURP)
                {
                    fila1.Cells[5].ErrorText = "CURP inválido";
                    Resultado = false;
                }
                if (!valPuestoNombre)
                {
                    fila1.Cells[6].ErrorText = "Puesto nombre inválido";
                    Resultado = false;
                }
                if (!valPuestoNivel)
                {
                    fila1.Cells[7].ErrorText = "Puesto nombre inválido";
                    Resultado = false;
                }
                if (!valNombreInsDep)
                {
                    fila1.Cells[8].ErrorText = "Puesto nombre inválido";
                    Resultado = false;
                }
                if (!valSiglas)
                {
                    fila1.Cells[9].ErrorText = "Puesto nombre inválido";
                    Resultado = false;
                }
                if (!valClave)
                {
                    fila1.Cells[10].ErrorText = "Puesto nombre inválido";
                    Resultado = false;
                }
                if (!valExpediente)
                {
                    fila1.Cells[11].ErrorText = "Puesto nombre inválido";
                    Resultado = false;
                }
                if (!valTipoFalta)
                {
                    fila1.Cells[12].ErrorText = "Puesto nombre inválido";
                    Resultado = false;
                }
                if (!valDescFalta)
                {
                    fila1.Cells[13].ErrorText = "Puesto nombre inválido";
                    Resultado = false;
                }

                if (!valCausaMotivoHecho)
                {
                    fila1.Cells[14].ErrorText = "Causa Motivo o Hecho inválida";
                    Resultado = false;
                }
                if (!valObservaciones)
                {
                    fila1.Cells[15].ErrorText = "Observación inválida";
                    Resultado = false;
                }
                if (!valAutSancionada)
                {
                    fila1.Cells[16].ErrorText = "Autoridad Sancionada inválida";
                    Resultado = false;
                }
                if (!valFechResolucion)
                {
                    fila1.Cells[17].ErrorText = "Fecha inválida";
                    Resultado = false;
                }
                if (!valURL)
                {
                    fila1.Cells[18].ErrorText = "URL inválido";
                    Resultado = false;
                }
                if (!valPlazo)
                {
                    fila1.Cells[19].ErrorText = "Plazo inválido";
                    Resultado = false;
                }
                if (!valFechInicial)
                {
                    fila1.Cells[20].ErrorText = "Fecha Inicial inválida";
                    Resultado = false;
                }
                if (!valFechFinal)
                {
                    fila1.Cells[21].ErrorText = "Fecha Final inválida";
                    Resultado = false;
                }
                if (!valMonto)
                {
                    fila1.Cells[22].ErrorText = "Monto inválido";
                    Resultado = false;
                }
                if (!valMoneda)
                {
                    fila1.Cells[23].ErrorText = "Moneda inválida";
                    Resultado = false;
                }
                if (!valTSancion)
                {
                    fila1.Cells[24].ErrorText = "Tipo Sanción inválido";
                    Resultado = false;
                }
                if (!valDescSancion)
                {
                    fila1.Cells[25].ErrorText = "Descripción de Sanción inválida";
                    Resultado = false;
                }
                if (!valTitulo)
                {
                    fila1.Cells[26].ErrorText = "Título inválido";
                    Resultado = false;
                }
                if (!valTipoDocumento)
                {
                    fila1.Cells[27].ErrorText = "Tipo de Documento inválido";
                    Resultado = false;
                }
                if (!valDescDocumento)
                {
                    fila1.Cells[28].ErrorText = "Descripción invalida";
                    Resultado = false;
                }
                if (!valDocURL)
                {
                    fila1.Cells[29].ErrorText = "URL inválida";
                    Resultado = false;
                }
                if (!valFecha)
                {
                    fila1.Cells[30].ErrorText = "Fecha inválida";
                    Resultado = false;
                }


                //VALIDACIÓN GENERO
                if (fila1.Cells[3].Value.ToString() == "")
                {

                }
                else
                {

                    if (!(obtenerGeneroID(fila1.Cells[3].Value.ToString()) == -1))
                    {

                    }
                    else
                    {
                        fila1.Cells[3].ErrorText = "No corresponde al catálogo Género";
                        Resultado = false;
                    }
                }



                //VALIDACIÓN MONEDA
                if (fila1.Cells[23].Value.ToString() == "")
                {

                }

                else
                {
                    if (!(obtenerMonedaSPSID(fila1.Cells[23].Value.ToString()) == -1))
                    {

                    }
                    else
                    {
                        fila1.Cells[23].ErrorText = "No corresponde la catálogo Moneda";
                        Resultado = false;
                    }

                }

                //VALIDACIÓN TIPO FALTA
                if (!(obtenerFaltaID(fila1.Cells[12].Value.ToString()) == -1))
                {

                }
                else
                {
                    fila1.Cells[12].ErrorText = "No corresponde al catálogo Tipo Falta";
                    Resultado = false;
                }



                if (fila1.Cells[24].Value.ToString() == "")
                {

                }
                else
                {
                    if (!(obtenerSancionID(fila1.Cells[24].Value.ToString()) == -1))
                    {

                    }
                    else
                    {
                        fila1.Cells[24].ErrorText = "No corresponde al catálogo Tipo Sanción";
                        Resultado = false;
                    }
                }

                //VALIDACIPON Documentos
                if (fila1.Cells[27].Value.ToString() == "")
                {

                }
                else
                {
                    if (!(obtenerDocumentoSPSID(fila1.Cells[27].Value.ToString()) == -1))
                    {

                    }
                    else
                    {
                        fila1.Cells[27].ErrorText = "No corresponde al catálogo Tipo Documento";
                        Resultado = false;
                    }
                }


            }
            return Resultado;
        }
        private void btnMostrarPS_Click(object sender, EventArgs e) //Particulares Sancionados
        {
            try
            {
                dataGridView1.DataSource = dtsTablas.Tables[cboHojas.SelectedIndex];

                int columnas = dataGridView1.ColumnCount;
                if (columnas == 55)
                {
                    dataGridView1.DataSource = dtsTablas.Tables[cboHojas.SelectedIndex];

                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Archivo no admtido");
                }
            }
            catch
            {
                MessageBox.Show("Falta subir el archivo");
            }
            validarCamposPS();

        }
     
        //Guarda los datos que se ingresaron 
        private void GuardarPS(modeloPS PS )
        {
           
            conPS.guardarPS(PS);
           

        }
        List<modeloMoneda> lMoneda = new controladorMoneda().obtenerListaMonedas();
        List<modeloTipoSancion> lsancionPS = new controladorTipoSancion().obtenerListaSancionesPS();
        List<modeloEntidadFederativa> lEntidad = new controladorEntidadFederativa().obtenerListaPais();
        List<modeloVialidad> lVialidad = new controladorVialidad().obtenerListaVialidad(1);
        List<modeloTipoDocumento> lDocumento = new controladorTipoDocumento().obtenerListaDocumentosPS();
        //se creo las listas para evaluar que cada valor corresponda a los catálogos 
        private int obtenerMonedaID(string moneda)
        {
           
            int pos = lMoneda.FindIndex(x => x.valor == moneda);
            return pos;
        }
        private int obtenerTipoSancionPSID( string valor )
        {
           
           
            //int pos = lsancionPS.FindIndex(x => x.id == sancionaesid);
            int pos = lsancionPS.FindIndex(x => x.valor == valor);
            return pos;
        }
        private int obtenerEntidadFederativaID(string entidadFederativa)
        {
            
            int pos = lEntidad.FindIndex(x => x.name == entidadFederativa);
            return pos;
        }
        private int obtenerMunicipioID(string municipio, int entidades)
        {
            List<modeloMunicipio> lMunicipio = new controladorMunicipio().obtenerListaMunicipio(entidades);
            int pos = lMunicipio.FindIndex(x => x.name == municipio);
            return pos;
        }       


        private int obtenerLocalidadID(string localidad, int municipios )
        {
          //  MessageBox.Show("" + localidad+ municipios);
            List<modeloLocalidad> lLocalida = new controladorLocalidad().obtenerListaLocalidad(municipios);
            
            int pos = lLocalida.FindIndex(x => x.name == localidad);
         
            return pos;
        }
       
        private int obtenerVialidadID(string vialidad)
        {
            
            int pos = lVialidad.FindIndex(x => x.name == vialidad);
            return pos;
        }
        private int obtenerPaisID(string pais)
        {
            List<modeloPais> lVialidad = new controladorPais().obtenerListaPais();
            int pos = lVialidad.FindIndex(x => x.name == pais);
            return pos;
        }
        private int obtenerDocumentoID(string documentos)
        {
            
            int pos = lDocumento.FindIndex(x => x.tipoDocumento == documentos);
            return pos;
        }


    
        private void btnGuardarPS_Click(object sender, EventArgs e)
        {
     
            bool documentos = true;
            
            //Evalua que el documento ingresado contiene 55 columnas, si las contiene, abre el documento, de lo contrario no
            int columnas = dataGridView1.ColumnCount;
            if (columnas == 55) 
            {
                bool DatosInsertadosPS = false;
                modeloTipoSancion modsan = new modeloTipoSancion();
                modeloTipoDocumento modoc = new modeloTipoDocumento();
                //Recorre cada fila del documento
              foreach (DataGridViewRow row in dataGridView1.Rows)
              {
                    modeloPS modps = new modeloPS();
                    //Regresa el valor de las variables, para evitar datos duplicados
                    moned = 0;
                    san = 0;
                    enti = 0;
                    muni = 0;
                    loc = 0;
                    vial = 0;
                    paisE = 0;
                    doc = 0;

                    documentos = true;
                    //manda a llamar al metodo, para validar cada celda
                 if (validarCamposPS())
                 {
                    //modps guarda el valor que se ingrese en cada celda
                    modps.expediente = row.Cells[0].Value.ToString();

                    modps.nombreRazonSocial = row.Cells[1].Value.ToString();
                    modps.rfcPS = row.Cells[2].Value.ToString();
                    modps.causaMotivoHechos = row.Cells[3].Value.ToString();

                    if(row.Cells[4].Value.ToString() == "")
                    {
                            row.Cells[4].Value = ("");
                            modps.acto = row.Cells[4].Value.ToString();
                    }
                    else
                    {
                      modps.acto = row.Cells[4].Value.ToString();
                    }
                    if (row.Cells[5].Value.ToString() == "")
                    {
                            row.Cells[5].Value = ("");
                            modps.objetoContrato = row.Cells[5].Value.ToString();
                    }
                    else
                    {
                       modps.objetoContrato = row.Cells[5].Value.ToString();
                    }
                    modps.tipoFalta = row.Cells[6].Value.ToString();
                    modps.nombreInstitucionDependencia = row.Cells[7].Value.ToString();
                    if (row.Cells[8].Value.ToString() == "")
                    {
                            row.Cells[8].Value = ("");
                            modps.siglasInstitucionDependencia = row.Cells[8].Value.ToString();
                    }
                    else
                    {
                         modps.siglasInstitucionDependencia = row.Cells[8].Value.ToString();
                    }
                    if (row.Cells[9].Value.ToString() == "")
                    {
                            row.Cells[9].Value = ("");
                            modps.claveInstitucionDependencia = row.Cells[9].Value.ToString();
                    }
                    else
                    {
                         modps.claveInstitucionDependencia = row.Cells[9].Value.ToString();
                    }
                    if (row.Cells[10].Value.ToString() == "")
                    {
                            row.Cells[10].Value = ("");
                            modps.observaciones = row.Cells[10].Value.ToString();
                    }
                    else
                    {
                          modps.observaciones = row.Cells[10].Value.ToString();
                    }
                    modps.autoridadSancionadora = row.Cells[11].Value.ToString();
                    if (row.Cells[12].Value.ToString() == "")
                    {
                            row.Cells[12].Value = ("");
                            modps.sentidoResolucion = row.Cells[12].Value.ToString();
                    }
                    else
                    {
                            modps.sentidoResolucion = row.Cells[12].Value.ToString();
                    }
                    if (row.Cells[13].Value.ToString() == "")
                    {
                            row.Cells[13].Value = ("");
                            modps.urlResolucion = row.Cells[13].Value.ToString();
                    }
                    else
                    {
                            modps.urlResolucion = row.Cells[13].Value.ToString();
                    }
                     if (row.Cells[14].Value.ToString() == "")
                    {
                            f1 = null;
                    }
                    else
                    {
                       modps.fechaResolucion = Convert.ToDateTime(row.Cells[14].Value.ToString()).ToString("yyyy-MM-dd");
                    }
                    modps.nombreRS = row.Cells[15].Value.ToString();
                    modps.primerApellidoRS = row.Cells[16].Value.ToString();
                    if (row.Cells[17].Value.ToString() == "")
                    {
                            row.Cells[17].Value = ("");
                            modps.segundoApellidoRS = row.Cells[17].Value.ToString();
                    }
                    else
                    {
                       modps.segundoApellidoRS = row.Cells[17].Value.ToString();
                    }
                    if (row.Cells[18].Value.ToString() == "")
                    {
                            row.Cells[18].Value = ("");
                            modps.plazoInhabilitacion = row.Cells[18].Value.ToString();
                    }
                    else
                    {
                       modps.plazoInhabilitacion = row.Cells[18].Value.ToString();
                    }

                    if (row.Cells[19].Value.ToString() == "")
                    {
                            f2 = null;
                    }
                    else
                    {
                        modps.fechaInicialInhabilitacion = Convert.ToDateTime(row.Cells[19].Value.ToString()).ToString("yyyy-MM-dd");
                    }

                    if (row.Cells[20].Value.ToString() == "")
                    {
                        f3 = null;
                    }
                    else
                    {
                        modps.fechaFinalInhabilitacion = Convert.ToDateTime(row.Cells[20].Value.ToString()).ToString("yyyy-MM-dd");
                    }

                    if (row.Cells[21].Value.ToString() == "")
                    {
                            row.Cells[21].Value = ("0");
                            modps.monto = float.Parse(row.Cells[21].Value.ToString());
                    }
                    else
                    {
                        modps.monto = float.Parse(row.Cells[21].Value.ToString());
                    }
                    //EL REGEXT TIENE QUE ACEPTAR NULOS Y QUE A LA HORA DE GURDAR DE LA NOTIFICACION QUE NO SE PUDE GUARDAR PORQUE NO COORRESPONDE A LA LISTA 
                    if (row.Cells[22].Value.ToString() == "")
                    {
                        
                    }
                    else {

                            moned = obtenerMonedaID(row.Cells[22].Value.ToString());
                            modps.moneda = moned;
                     }
                       
                    
                     san = obtenerTipoSancionPSID(row.Cells[23].Value.ToString());
                    
                  
                    modps.tipoPersona = row.Cells[25].Value.ToString();
                    if (row.Cells[26].Value.ToString() == "")
                    {
                            row.Cells[26].Value = ("");
                            modps.telefono = row.Cells[26].Value.ToString();
                    }
                    else
                    {
                        modps.telefono = row.Cells[26].Value.ToString();
                    }
                    if (row.Cells[27].Value.ToString() == "")
                    {
                            row.Cells[27].Value = ("");
                            modps.objetoSocial = row.Cells[27].Value.ToString();
                        }
                    else
                    {
                        modps.objetoSocial = row.Cells[27].Value.ToString();
                    }
                    if (row.Cells[28].Value.ToString() == "")
                    {
                            row.Cells[28].Value = ("");
                            modps.nombresDG = row.Cells[28].Value.ToString();
                    }
                    else
                    {
                        modps.nombresDG = row.Cells[28].Value.ToString();
                    }
                    if (row.Cells[29].Value.ToString() == "")
                    {
                            row.Cells[29].Value = ("");
                            modps.primerApellidoDG = row.Cells[29].Value.ToString();
                    }
                    else
                    {
                        modps.primerApellidoDG = row.Cells[29].Value.ToString();
                    }
                    if (row.Cells[30].Value.ToString() == "")
                    {
                            row.Cells[30].Value = ("");
                            modps.segundoApellidoDG = row.Cells[30].Value.ToString();
                    }
                    else
                    {
                        modps.segundoApellidoDG = row.Cells[30].Value.ToString();
                    }
                    if (row.Cells[31].Value.ToString() == "")
                    {
                            row.Cells[31].Value = ("");
                            modps.curpDG = row.Cells[31].Value.ToString();
                    }
                    else
                    {
                        modps.curpDG = row.Cells[31].Value.ToString();
                    }
                    if (row.Cells[32].Value.ToString() == "")
                    {
                            row.Cells[32].Value = ("");
                            modps.nombresAL = row.Cells[32].Value.ToString();
                    }
                    else
                    {
                        modps.nombresAL = row.Cells[32].Value.ToString();
                    }
                    if (row.Cells[33].Value.ToString() == "")
                    {
                            row.Cells[33].Value = ("");
                            modps.primerApellidoAL = row.Cells[33].Value.ToString();
                    }
                    else
                    {
                        modps.primerApellidoAL = row.Cells[33].Value.ToString();
                    }
                    if (row.Cells[34].Value.ToString() == "")
                    {
                            row.Cells[34].Value = ("");
                            modps.segundoApellidoAL = row.Cells[34].Value.ToString();
                    }
                    else
                    {
                        modps.segundoApellidoAL = row.Cells[34].Value.ToString();
                    }
                    if (row.Cells[35].Value.ToString() == "")
                    {
                            row.Cells[35].Value = ("");
                            modps.curpAL = row.Cells[35].Value.ToString();
                    }
                    else
                    {
                        modps.curpAL = row.Cells[35].Value.ToString();
                    }
                    if (row.Cells[36].Value.ToString() == "")
                    {
                       
                    }
                    else { 
                            enti = obtenerEntidadFederativaID(row.Cells[36].Value.ToString());
                            modps.entidadFederativa = enti;
                    }
                    if (row.Cells[37].Value.ToString() == "")
                    {
                            
                    }
                    else { 
                       
                            muni = obtenerMunicipioID(row.Cells[37].Value.ToString(), enti);
                            List<modeloMunicipio> lMunicipio = new controladorMunicipio().obtenerListaMunicipio(enti);
                            modps.municipio = lMunicipio[muni].id;
                            muni=lMunicipio[muni].id;

                    }
                    if (row.Cells[38].Value.ToString() == "")
                    {
                    
                    }
                    else {
                   
                           loc = obtenerLocalidadID(row.Cells[38].Value.ToString(), muni);
                           List<modeloLocalidad> lLocalida = new controladorLocalidad().obtenerListaLocalidad(muni);
                            modps.localidad = lLocalida[loc].id;
                    }
                   
                    if (row.Cells[39].Value.ToString() == "")
                    {
                       
                    }
                    else { 
                          vial = obtenerVialidadID(row.Cells[39].Value.ToString());
                          modps.vialidad = vial;

                    }
                    if (row.Cells[40].Value.ToString() == "")
                    {
                           
                    }
                    else
                    {
                        modps.codigoPostalMX = row.Cells[40].Value.ToString();
                    }
                    if (row.Cells[41].Value.ToString() == "")
                    {
                         
                    }
                    else
                    {
                        modps.numeroExteriorMX = row.Cells[41].Value.ToString();
                    }
                    if (row.Cells[42].Value.ToString() == "")
                    {
                    
                    }
                    else
                    {
                        modps.numeroInteriorEX = row.Cells[42].Value.ToString();
                    }
                    if (row.Cells[43].Value.ToString() == "")
                    {
                           
                    }
                    else
                    {
                        modps.calle = row.Cells[43].Value.ToString();
                    }
                    if (row.Cells[44].Value.ToString() == "")
                    {
                           
                    }
                    else
                    {
                        modps.ciudadLocalidad = row.Cells[44].Value.ToString();
                    }
                    if (row.Cells[45].Value.ToString() == "")
                    {
                        
                    }
                    else
                    {
                        modps.estadoProvincia = row.Cells[45].Value.ToString();
                    }
                    if (row.Cells[46].Value.ToString() == "")
                    {
                            
                    }
                    else
                    {
                        modps.codigoPostalEX = row.Cells[46].Value.ToString();
                    }
                    if (row.Cells[47].Value.ToString() == "")
                    {
                    
                    }
                    else
                    {
                        modps.numeroInteriorEX = row.Cells[47].Value.ToString();
                    }

                    if (row.Cells[48].Value.ToString() == "")
                    {
                          
                    }
                    else
                    {
                        modps.numeroExteriorMX = row.Cells[48].Value.ToString();
                    }
                    if (row.Cells[49].Value.ToString() == "")
                    {
                        
                    }
                    else { 
                        
                        paisE = obtenerPaisID(row.Cells[49].Value.ToString());
                        modps.paisEX = paisE;

                    }

                    if(row.Cells[51].Value.ToString() == "")
                    {
                         
                    }
                    else
                    {
                       doc = obtenerDocumentoID(row.Cells[51].Value.ToString());
                      
                    }
                    if (row.Cells[50].Value.ToString() == "")
                    {
                            documentos = false;
                    }
                    if (row.Cells[52].Value.ToString() == "")
                    {
                            documentos = false;
                    }
                    if (row.Cells[53].Value.ToString() == "")
                    {
                            documentos = false;
                    }
                    if (row.Cells[54].Value.ToString() == "")
                    {
                         documentos = false;
                    }

                        GuardarPS(modps);

                       conPS.guardarSancionPS(san, modsan.descripcion = row.Cells[24].Value.ToString());

                        if (documentos == false)
                        {

                        }
                        else
                        {
                            conPS.guardarDocumentoPS(doc, modoc.tipoDocumento = row.Cells[50].Value.ToString(), row.Cells[52].Value.ToString(), row.Cells[53].Value.ToString(), Convert.ToDateTime(row.Cells[54].Value.ToString()).ToString("yyyy-MM-dd"));
                        }

                       
                        DatosInsertadosPS = true;
                        
                 }
                     
              }
                    if (DatosInsertadosPS == true)
                    {
                       MessageBox.Show("Datos de particulares Sancionados insertados" + ": " + dataGridView1.RowCount);
                       dataGridView1.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Hay campos con errores");
                    }

            }
            else
            {
                MessageBox.Show("No hay ningún registro");
            }

        }
        //CARGA MASIVA SERVIDORES PUBLICOS SANCIONADOS
        private int obtenerSancionID(string sancion) //Recupera el ID de los catalogos mediante los modelos.
        {
            List<modeloTipoSancion> lSancion2 = new controladorTipoSancion().obtenerListaSanciones();
            int pos = lSancion2.FindIndex(x => x.valor == sancion);
            return pos;
        }

        private int obtenerFaltaID(string sancion)
        {
            List<modeloTipoFalta> Falta = new controladorTipoFalta().obtenerListaFaltas();
            int pos = Falta.FindIndex(x => x.valor == sancion);
            return pos;
        }
        private int obtenerGeneroID(string sancion)
        {
            List<modeloListaGenero> Falta = new controladorListaGenero().obtenerListaGenero();
            int pos = Falta.FindIndex(x => x.valor == sancion);
            return pos;
        }
        private int obtenerMonedaSPSID(string sancion)
        {
            List<modeloMoneda> Falta = new controladorMoneda().obtenerListaMonedas();
            int pos = Falta.FindIndex(x => x.valor == sancion);
            return pos;
        }
        private int obtenerDocumentoSPSID(string documento)
        {
            List<modeloTipoDocumento> Falta = new controladorTipoDocumento().obtenerListaDocumentos();
            int pos = Falta.FindIndex(x => x.tipoDocumento == documento);
            return pos;
        }

        public void GuardarDatos(modeloSPS SPS) //Metodo para guardar la información de los SPS.
        {
            conSPS.guardarSPS(SPS);
        }

        private void btnLimpiar1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
        }

        private void btnLimpar2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        //Este evento pinta las celdas de lado izquierda con numeros 
        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using(SolidBrush br = new SolidBrush(dataGridView2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex +1).ToString(),e.InheritedRowStyle.Font,br,e.RowBounds.Location.X+10,e.RowBounds.Y +10);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using(SolidBrush brs = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brs, e.RowBounds.Location.X + 10, e.RowBounds.Y + 10);
            }
        }

        private void btnGuardarSPS_Click(object sender, EventArgs e)
        {
            int columnas = dataGridView2.ColumnCount;
            if (columnas == 31) //Verifica si el archivo cuenta con las 31 columnas, si en dado caso cumple esta se podra visualizar en la carga.
            {
                //Se mandan a llamar a los modelos
                modeloTipoSancion modSan = new modeloTipoSancion();
                modeloTipoDocumento modDoc = new modeloTipoDocumento();

                bool DatosInsertados = false;
                bool resultados = true;
                bool documentoSPS = true;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    modeloSPS modSPS = new modeloSPS();
                    //Se restablecen los valores de las variables para evitar datos duplicados.
                    m = 0; //Variable de moneda.
                    sanSPS = 0;
                    docSPS = 0; 
                    faltaSPS = 0;
                    generoSPS = 0;
                    documentoSPS = true;
                    if (validarCamposSPS()) //Condición que validara todos los campos al guardar.
                    {
                        modSPS.nombreSPS = row.Cells[0].Value.ToString();
                        modSPS.primerApellidoSPS = row.Cells[1].Value.ToString();

                        if (row.Cells[2].Value.ToString() == "")  //Si el campo se encuntra vacío este se guardará como null.
                        {
                            row.Cells[2].Value = ("");
                            modSPS.segundoApellidoSPS = row.Cells[2].Value.ToString();
                        }
                        else
                        {
                            modSPS.segundoApellidoSPS = row.Cells[2].Value.ToString();
                        }


                        //GENERO
                        //VALIDACIÓN GENERO
                        if (row.Cells[3].Value.ToString() == "") //Si el cmapo se encuentra vacío este se guardará como null.
                        {

                        }
                        else
                        {
                            generoSPS = obtenerGeneroID(row.Cells[3].Value.ToString());
                            modSPS.generoSPS = generoSPS;
                        }



                        modSPS.rfcSPS = row.Cells[4].Value.ToString();
                        modSPS.curpSPS = row.Cells[5].Value.ToString();
                        modSPS.puestoSPS = row.Cells[6].Value.ToString();

                        if (row.Cells[7].Value.ToString() == "") //Si no se registra algun Nivel esta quedará como null.
                        {
                            row.Cells[7].Value = ("");
                            modSPS.nivelSPS = row.Cells[7].Value.ToString();
                        }
                        else
                        {
                            modSPS.nivelSPS = row.Cells[7].Value.ToString();
                        }

                        modSPS.nombreInstitucionDependencia = row.Cells[8].Value.ToString();

                        if (row.Cells[9].Value.ToString() == "") //Si no se registra la Institución o Dependencia esta quedará como null.
                        {
                            row.Cells[9].Value = ("");
                            modSPS.siglasInstitucionDependencia = row.Cells[9].Value.ToString();
                        }
                        else
                        {
                            modSPS.siglasInstitucionDependencia = row.Cells[9].Value.ToString();
                        }

                        if (row.Cells[10].Value.ToString() == "") //Si no se registra la Clave de la Institución esta quedará como null.
                        {
                            row.Cells[10].Value = ("");
                            modSPS.claveInstitucionDependencia = row.Cells[10].Value.ToString();
                        }
                        else
                        {
                            modSPS.claveInstitucionDependencia = row.Cells[10].Value.ToString();
                        }

                        modSPS.expediente = row.Cells[11].Value.ToString();



                        faltaSPS = obtenerFaltaID(row.Cells[12].Value.ToString()); //Obtiene el ID de la falta.
                        modSPS.tipoFalta = faltaSPS;




                        if (row.Cells[13].Value.ToString() == "") //Si no se registra alguna Descripción de la Falta esta quedará como null.
                        {
                            row.Cells[13].Value = ("");
                            modSPS.descripcionFalta = row.Cells[13].Value.ToString();
                        }
                        else
                        {
                            modSPS.descripcionFalta = row.Cells[13].Value.ToString();

                        }

                        modSPS.causaMotivoHechos = row.Cells[14].Value.ToString();

                        if (row.Cells[15].Value.ToString() == "") //Si no se registra alguna observación esta quedará como null.
                        {
                            row.Cells[15].Value = ("");
                            modSPS.observaciones = row.Cells[15].Value.ToString();
                        }
                        else
                        {
                            modSPS.observaciones = row.Cells[15].Value.ToString();
                        }

                        modSPS.autoridadSancionadora = row.Cells[16].Value.ToString();

                        if (row.Cells[17].Value.ToString() == "") //Si el campo fecha queda vacío se guarda como null.
                        {
                            f5 = null;
                        }
                        else
                        {
                            modSPS.fechaResolucion = Convert.ToDateTime(row.Cells[17].Value.ToString()).ToString("yyyy-MM-dd");
                        }



                        if (row.Cells[18].Value.ToString() == "") //Si no se llena el campo URL resolución quedará como null.
                        {
                            row.Cells[18].Value = ("");
                            modSPS.urlResolucion = row.Cells[18].Value.ToString();
                        }
                        else
                        {
                            modSPS.urlResolucion = row.Cells[18].Value.ToString();
                        }

                        if (row.Cells[19].Value.ToString() == "") //Si no llena el campo Plazo Inhabilitación quedará como null.
                        {
                            row.Cells[19].Value = ("");
                            modSPS.plazoInhabilitacion = row.Cells[19].Value.ToString();
                        }
                        else
                        {
                            modSPS.plazoInhabilitacion = row.Cells[19].Value.ToString();
                        }

                        if (row.Cells[20].Value.ToString() == "") //Si no se registra la fecha Inicial de la  Inhabilitación quedará como null.
                        {
                            f6 = null;
                        }
                        else
                        {
                            modSPS.fechaInicialInhabilitacion = Convert.ToDateTime(row.Cells[20].Value.ToString()).ToString("yyyy-MM-dd");
                        }


                        if (row.Cells[21].Value.ToString() == "") //Si no se registra la fecha Final de Inhabilitación quedará como null.
                        {
                            f7 = null;
                        }
                        else
                        {
                            modSPS.fechaFinalInhabilitacion = Convert.ToDateTime(row.Cells[21].Value.ToString()).ToString("yyyy-MM-dd");
                        }



                        if (row.Cells[22].Value.ToString() == "") //Si el campo monto se deja vacío lo guardará con valor "0".
                        {
                            row.Cells[22].Value = ("0");
                            modSPS.montoMulta = float.Parse(row.Cells[22].Value.ToString());
                        }
                        else
                        {
                            modSPS.montoMulta = float.Parse(row.Cells[22].Value.ToString());
                        }


                        if (row.Cells[23].Value.ToString() == "") //Si el campo moneda se deja vacío, lo guardara como null.
                        {

                        }

                        else
                        {
                            m = obtenerMonedaSPSID(row.Cells[23].Value.ToString()); //Obtiene el ID del catalogo de moneda.
                            modSPS.monedaMulta = m;
                        }

                        if (row.Cells[24].Value.ToString() == "") //Si el campo Sanción se deja vacío, lo guardará como null.
                        {

                        }
                        else
                        {
                            sanSPS = obtenerSancionID(row.Cells[24].Value.ToString()); //Obtiene el ID del catalogo Sanación
                        }


                        if (row.Cells[27].Value.ToString() == "") //Si el campo Documentos se deja vacío, lo guardará como null.
                        {

                        }
                        else
                        {
                            docSPS = obtenerDocumentoID(row.Cells[27].Value.ToString()); //Obtiene el ID del catalogo Documentos.
                        }

                        if (row.Cells[26].Value.ToString() == "")
                        {
                            documentoSPS = false;
                        }
                        if (row.Cells[28].Value.ToString() == "")
                        {
                            documentoSPS = false;
                        }
                        if (row.Cells[29].Value.ToString() == "")
                        {
                            documentoSPS = false;
                        }
                        if (row.Cells[30].Value.ToString() == "")
                        {
                            documentoSPS = false;
                        }

                        if (documentoSPS == false)
                        {

                        }

                        GuardarDatos(modSPS); //Guarda todos los datos de SPS.

                        conSPS.guardarSancionSPS(sanSPS, modSan.descripcion = row.Cells[25].Value.ToString()); //Guarda los datos de la sanción.

                        if (documentoSPS == false) //Si ningun dato del apartado de documentos fue completado este se guardará como null.
                        {

                        }
                        else
                        {
                            //Guarda todos los datos del apartado de Documentos.
                            conSPS.guardarDocumentoSPS(docSPS, modDoc.tituloDocumento = row.Cells[26].Value.ToString(),
                                modDoc.descripcionDocumento = row.Cells[28].Value.ToString(), modDoc.urlDocumento = row.Cells[29].Value.ToString(),
                                modDoc.fechaDocumento = Convert.ToDateTime(row.Cells[30].Value.ToString()).ToString("yyyy-MM-dd"));
                        }

                        DatosInsertados = true; //Si los datos fueron insertados correctamente se guardara en una variable booleana como true;
                    }

                }
                if (DatosInsertados == true) //Si los datos fueron agregados correctamente, mandara un msj de confirmación, y si no fuese así dará un msj de error.
                {
                    MessageBox.Show("Datos insertados correctamente" + ": " + dataGridView2.RowCount);
                    dataGridView2.DataSource = null; //Limpiará todos los datos del DGV
                }
                else
                {
                    MessageBox.Show("No puedes guardar, hay campos con errores");
                }
            }
            else
            {
                MessageBox.Show("No existe ningún registro");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            try
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        DialogResult resut = MessageBox.Show("¿Está seguro de eliminar el registro?", "Warning", MessageBoxButtons.YesNo);
                        if (resut == DialogResult.Yes)
                        {



                        }
                        else if (resut == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
            }
            catch
            {

                MessageBox.Show("cellclik acivo");
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            //if (e.ColumnIndex == 34)
            //{
            //    Image someImage = Properties.Resources.basura;
            //
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
            //    var w = Properties.Resources.basura.Width;
            //    var h = Properties.Resources.basura.Height;
            //    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
            //    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
            //
            //    e.Graphics.DrawImage(someImage, new Rectangle(x, y, w, h));
            //    e.Handled = true;
            //}

           
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.CurrentCell.ErrorText = String.Empty;
            


        }

        private void comboSistema_SelectedIndexChanged(object sender, EventArgs e) //metodo para cambiar el dropdownlist (PSP % PS).
        {
            if (comboSistema.SelectedIndex != 1)
            {
                panelSPS.Visible = false; //Se ocultara el panel PS.
                btnMostrarSPS.Visible = false; //Se oculta el botón de validación de SPS.
                dataGridView1.DataSource = null; //Se limpia el DGV de SPS.
                btnGuardarSPS.Visible = false; //El botón guardar de SPS se oculta.

            }
            else //Si la opción es la 1 entonces se mostrara los siguientes componentes.
            {
                panelSPS.Visible = true; //El panel SPS se muestra.
                panelPS.Visible = false; //El panel PSP se oculta.
                btnMostrarSPS.Visible = true; //Botón mostrar de los SPS se muestra.
                btnMostrarPS.Visible = false; //El botón de los PS se oculta.
                btnGuardarSPS.Visible = true; //El botón guardar SPS se muestra.

            }

            if (comboSistema.SelectedIndex != 2) //Si es diferente a la opción 2 (PS).
            {
                panelPS.Visible = false; //El panel PS se oculta.
                btnMostrarPS.Visible = false; //El botón Mostra de los PS se oculta.
                dataGridView2.DataSource = null; //Limpia el DGV de los SPS.
                btnGuardarPS.Visible = false; //El botón Guardar de PS se oculta.

            }
            else
            {
                panelPS.Visible = true; //El panel PS se muestra.
                panelSPS.Visible = false; //El panel SPS se oculta.
                btnMostrarPS.Visible = true; //El botón Mostrar de SP se muestra.
                btnMostrarSPS.Visible = false; //El botón Mostrar SPS se oculta
                btnGuardarPS.Visible = true; //El botón Guardar PS se muestra.

            }

        }

        private void btnMostrarSPS_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = dtsTablas.Tables[cboHojas.SelectedIndex];

                int columnas = dataGridView2.ColumnCount;
                if (columnas == 31)
                {
                    dataGridView2.DataSource = dtsTablas.Tables[cboHojas.SelectedIndex];

                }
                else
                {
                    dataGridView2.DataSource = null;
                    MessageBox.Show("Archivo no admtido");
                }
            }
            catch
            {
                MessageBox.Show("Falta subir el archivo");
            }

            validarCamposSPS();
        }

        private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentCell.ErrorText = String.Empty;
        }
    }
}
