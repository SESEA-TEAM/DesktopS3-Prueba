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

namespace Sistema_de_sanciones
{
    public partial class CargaMasiva : Form
    {
        controlador1PS conPS = new controlador1PS();
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

        public bool validarCamposPS()
        {
            bool Resultado = true;
            string ClaveExpedientes = @"[-A-Za-z0-9_(!""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~)]{3,100}";
            string cadenaTexto = @"^[a-zA-ZÀ-ÿfd]+(\s*[a-zA-ZÀ-ÿfd])[a-zA-ZÀ-ÿfd]+$";
            string NoObligatorio = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{0,100}$";
            string ClavesRFCs = @"^([A-ZÑ&]{4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$";
            string Fechas = @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01]){1}$";
            string FechasNobligatoria = @"^[0-9-]{0,10}$";
            string URLS = @"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$";
            string urlNoObligatorio = @"[-A-Za-z0-9_(!""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~)]{0,200}";
            string ClaveSiglas = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ]{0,10}$";
            string ClaveClave = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ]{0,100}$";
            string Monto = @"^[0-9]+([,][0-9]+)?$";
            string TelefonoNoObligatorio = @"^[0-9]{0,10}$";
            string ClaveObjetoSocial = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{0,100}$";  
            string ClaveLocalidad = @"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ 0-9]{0,100}$";
            string ClaveCalle = @"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,0-9]{0,100}$";
            string ClaveObligatorioPS = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ.,]{3,100}$";
            string ClaveCURPPS = @"^[A-Za-z0-9]{0,17}";
            string ClaveCodPostalPS = @"^\d{0,5}$";
            string Documento = @"^[A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ_]{0,100}$";
            string ClaveNumeroExterior = @"^[0-9]{0,20}$";

            foreach (DataGridViewRow fila1 in dataGridView1.Rows)
            {
                bool valExpediente = Regex.IsMatch(fila1.Cells[0].Value.ToString(), ClaveExpedientes);
                bool valNombres = Regex.IsMatch(fila1.Cells[1].Value.ToString(), NoObligatorio);
                bool valRFCs = Regex.IsMatch(fila1.Cells[2].Value.ToString(), ClavesRFCs);//CAMBIAR
                bool valCausaMotivoHecho = Regex.IsMatch(fila1.Cells[3].Value.ToString(), ClaveObligatorioPS);//CAMBIAR
                bool valActo = Regex.IsMatch(fila1.Cells[4].Value.ToString(), NoObligatorio);
                bool valObjContrato = Regex.IsMatch(fila1.Cells[5].Value.ToString(), NoObligatorio);
                bool valTipoFalta = Regex.IsMatch(fila1.Cells[6].Value.ToString(), cadenaTexto);
                bool valNombreInsDep = Regex.IsMatch(fila1.Cells[7].Value.ToString(), ClaveObligatorioPS);
                bool valSiglas = Regex.IsMatch(fila1.Cells[8].Value.ToString(), ClaveSiglas);
                bool valClave = Regex.IsMatch(fila1.Cells[9].Value.ToString(), ClaveClave);
                bool Observacion = Regex.IsMatch(fila1.Cells[10].Value.ToString(), NoObligatorio);
                bool valAutSancionadora = Regex.IsMatch(fila1.Cells[11].Value.ToString(), cadenaTexto);
                bool valSentido = Regex.IsMatch(fila1.Cells[12].Value.ToString(), NoObligatorio);
                bool valURL = Regex.IsMatch(fila1.Cells[13].Value.ToString(), urlNoObligatorio);
                bool valFechaResolucion = Regex.IsMatch(fila1.Cells[14].Value.ToString(), FechasNobligatoria);
                bool valNombreRespSocial = Regex.IsMatch(fila1.Cells[15].Value.ToString(), cadenaTexto);
                bool valApellidoUnoResp = Regex.IsMatch(fila1.Cells[16].Value.ToString(), cadenaTexto);
                bool valApellidoDosResp = Regex.IsMatch(fila1.Cells[17].Value.ToString(), NoObligatorio);
                bool valPlazo = Regex.IsMatch(fila1.Cells[18].Value.ToString(), NoObligatorio);
                bool valFechaInicial = Regex.IsMatch(fila1.Cells[19].Value.ToString(), FechasNobligatoria);

                bool valFechaFinal = Regex.IsMatch(fila1.Cells[20].Value.ToString(), FechasNobligatoria);
                bool valMonto = Regex.IsMatch(fila1.Cells[21].Value.ToString(), Monto);
                bool valMoneda = Regex.IsMatch(fila1.Cells[22].Value.ToString(), cadenaTexto);
                bool valTipoSancion = Regex.IsMatch(fila1.Cells[23].Value.ToString(), cadenaTexto);
                bool valDescripcion = Regex.IsMatch(fila1.Cells[24].Value.ToString(), NoObligatorio);
                bool valTipoPersona = Regex.IsMatch(fila1.Cells[25].Value.ToString(), cadenaTexto);
                bool valTelefono = Regex.IsMatch(fila1.Cells[26].Value.ToString(), TelefonoNoObligatorio);
                ///2DA PARTE
                bool valObjetoSocial = Regex.IsMatch(fila1.Cells[27].Value.ToString(), ClaveObjetoSocial);
                bool valNombrePS = Regex.IsMatch(fila1.Cells[28].Value.ToString(), ClaveObjetoSocial);
                bool valPrimerApellidoPS = Regex.IsMatch(fila1.Cells[29].Value.ToString(), ClaveObjetoSocial);
                bool valSegundoApelldoPS = Regex.IsMatch(fila1.Cells[30].Value.ToString(), ClaveObjetoSocial);
                bool valCURPs = Regex.IsMatch(fila1.Cells[31].Value.ToString(), ClaveCURPPS);
                bool valNombreDosPS = Regex.IsMatch(fila1.Cells[32].Value.ToString(), ClaveObjetoSocial);
                bool valPrimerApellidoDosPS = Regex.IsMatch(fila1.Cells[33].Value.ToString(), ClaveObjetoSocial);
                bool valSegundopelldoDosPS = Regex.IsMatch(fila1.Cells[34].Value.ToString(), ClaveObjetoSocial);
                bool valCurpDosPS = Regex.IsMatch(fila1.Cells[35].Value.ToString(), ClaveCURPPS);
                bool valEntidadFederativa = Regex.IsMatch(fila1.Cells[36].Value.ToString(), ClaveObjetoSocial);
                bool valMunicipio = Regex.IsMatch(fila1.Cells[37].Value.ToString(), ClaveObjetoSocial);
                bool valLocalidad = Regex.IsMatch(fila1.Cells[38].Value.ToString(), ClaveLocalidad);
                bool valVialidad = Regex.IsMatch(fila1.Cells[39].Value.ToString(), ClaveCalle);//cambiar
                bool valCodPostal = Regex.IsMatch(fila1.Cells[40].Value.ToString(), ClaveCodPostalPS);
                bool valNumExt = Regex.IsMatch(fila1.Cells[41].Value.ToString(), ClaveNumeroExterior);
                bool valNumInt = Regex.IsMatch(fila1.Cells[42].Value.ToString(), ClaveNumeroExterior);
                bool valCalle = Regex.IsMatch(fila1.Cells[43].Value.ToString(), ClaveCalle);
                bool valCiudad = Regex.IsMatch(fila1.Cells[44].Value.ToString(), ClaveObjetoSocial);
                bool valEstado = Regex.IsMatch(fila1.Cells[45].Value.ToString(), ClaveObjetoSocial);
                bool valCodPostalDos = Regex.IsMatch(fila1.Cells[46].Value.ToString(), ClaveCodPostalPS);
                bool valNumExtDos = Regex.IsMatch(fila1.Cells[47].Value.ToString(), ClaveNumeroExterior);
                bool valNumIntDos = Regex.IsMatch(fila1.Cells[48].Value.ToString(), ClaveNumeroExterior);
                bool valPais = Regex.IsMatch(fila1.Cells[49].Value.ToString(), ClaveObjetoSocial);
                bool valtitulo = Regex.IsMatch(fila1.Cells[50].Value.ToString(), ClaveObligatorioPS);
                bool valTipoDocumento = Regex.IsMatch(fila1.Cells[51].Value.ToString(), Documento);
                bool valDescripcionDos = Regex.IsMatch(fila1.Cells[52].Value.ToString(), ClaveObligatorioPS);
                bool valURLDos = Regex.IsMatch(fila1.Cells[53].Value.ToString(), URLS);
                bool ValFechaPS = Regex.IsMatch(fila1.Cells[54].Value.ToString(), Fechas);

                if (!valExpediente)
                {
                    fila1.Cells[0].ErrorText = "Expediente Invalido";
                    Resultado = false;
                }


                if (!valNombres)
                {
                    fila1.Cells[1].ErrorText = "Nombre Invalido";
                    Resultado = false;
                }
                if (!valRFCs)
                {
                    fila1.Cells[2].ErrorText = "RFC Invalido";
                    Resultado = false;
                }
                if (!valCausaMotivoHecho)
                {
                    fila1.Cells[3].ErrorText = "Causa Motivo y Hecho Invalido";
                    Resultado = false;
                }
                if (!valActo)
                {
                    fila1.Cells[4].ErrorText = "Acto Invalido";
                    Resultado = false;
                }

                if (!valObjContrato)
                {
                    fila1.Cells[5].ErrorText = "Objeto Contratante Invalido";
                    Resultado = false;
                }
                if (!valTipoFalta)
                {
                    fila1.Cells[6].ErrorText = "Tipo de Falta Invalida";
                    Resultado = false;
                }
                if (!valNombreInsDep)
                {
                    fila1.Cells[7].ErrorText = "Nombre de la Institución o Dependencia Invalida";
                    Resultado = false;
                }
                if (!valSiglas)
                {
                    fila1.Cells[8].ErrorText = "Siglas Invalidas";
                    Resultado = false;
                }
                if (!valClave)
                {
                    fila1.Cells[9].ErrorText = "Clave Invalida";
                    Resultado = false;
                }
                if (!Observacion)
                {
                    fila1.Cells[10].ErrorText = "Observacion Invalida";
                    Resultado = false;
                }

                if (!valAutSancionadora)
                {
                    fila1.Cells[11].ErrorText = "Autoridad Sancionada Invalida";
                    Resultado = false;
                }
                if (!valSentido)
                {
                    fila1.Cells[12].ErrorText = "Sentido de Resolución Invalida";
                    Resultado = false;
                }
                if (!valURL)
                {
                    fila1.Cells[13].ErrorText = "URL Invalida";
                    Resultado = false;
                }
                if (!valFechaResolucion)
                {
                    fila1.Cells[14].ErrorText = "Fecha de Resolución Invalida";
                    Resultado = false;
                }
                if (!valNombreRespSocial)
                {
                    fila1.Cells[15].ErrorText = "Nombre del Responsable Social Invalido";
                    Resultado = false;
                }
                if (!valApellidoUnoResp)
                {
                    fila1.Cells[16].ErrorText = "Primer Apellido Invalido";
                    Resultado = false;
                }
                if (!valApellidoDosResp)
                {
                    fila1.Cells[17].ErrorText = "Segundo Apellido Invalido";
                    Resultado = false;
                }
                if (!valPlazo)
                {
                    fila1.Cells[18].ErrorText = "Plazo Invalido";
                    Resultado = false;
                }
                if (!valFechaInicial)
                {
                    fila1.Cells[19].ErrorText = "Fecha Inicial Invalida";
                    Resultado = false;
                }

                if (!valFechaFinal)
                {
                    fila1.Cells[20].ErrorText = "Fecha Final Invalida";
                    Resultado = false;
                }
                if (!valMonto)
                {
                    fila1.Cells[21].ErrorText = "Monto Invalido";
                    Resultado = false;
                }
                if (!valMoneda)
                {
                    fila1.Cells[22].ErrorText = "Moneda Invalida";
                    Resultado = false;
                }
                if (!valTipoSancion)
                {
                    fila1.Cells[23].ErrorText = "Tipo de sanción Invalida";
                    Resultado = false;
                }

                if (!valDescripcion)
                {
                    fila1.Cells[24].ErrorText = "Descripción Invalida";
                    Resultado = false;
                }
                if (!valTipoPersona)
                {
                    fila1.Cells[25].ErrorText = "Tipo de Persona Invalida";
                    Resultado = false;
                }
                if (!valTelefono)
                {
                    fila1.Cells[26].ErrorText = "Teléfono Invalido";
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

                    fila1.Cells[49].ErrorText = "Pais inválido";
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


            }
            return Resultado;
        }

        public bool validarCamposSPS()
        {
            bool Resultado = true;
            string cadenaTexto = @"^[a-zA-ZÀ-ÿfd]+(\s*[a-zA-ZÀ-ÿfd])[a-zA-ZÀ-ÿfd]+$";
            string ClavesGenero = @"^[A-z]{8,9}$";
            string ClavesRFC = @"^([A-ZÑ&]{4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$";
            string ClavesCURP = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";
            string ObligatoriaFechas = @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01]){1}$";
            string Fechas = @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$";
            string URLS = @"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$";
            string ClavePuesto = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{0,100}$";
            string ClaveSiglas = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{0,10}$";
            string ClaveExpediente = @"[-A-Za-z0-9_(!""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~)]{3,100}";
            string ClaveClave = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{0,100}$";
            string ClaveTipoFalta = @"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{0,100}$";


            // bool valNombre = Regex.IsMatch(, cadenaTexto);

            foreach (DataGridViewRow fila1 in dataGridView2.Rows)
            {

                bool valNombre = Regex.IsMatch(fila1.Cells[0].Value.ToString(), cadenaTexto);
                bool valApellido = Regex.IsMatch(fila1.Cells[1].Value.ToString(), cadenaTexto);
                bool valapellidoDos = Regex.IsMatch(fila1.Cells[2].Value.ToString(), cadenaTexto);
                bool valGenero = Regex.IsMatch(fila1.Cells[3].Value.ToString(), ClavesGenero);
                bool valRFC = Regex.IsMatch(fila1.Cells[4].Value.ToString(), ClavesRFC);
                bool valCURP = Regex.IsMatch(fila1.Cells[5].Value.ToString(), ClavesCURP);
                bool valPuestoNombre = Regex.IsMatch(fila1.Cells[6].Value.ToString(), ClavePuesto);
                bool valPuestoNivel = Regex.IsMatch(fila1.Cells[7].Value.ToString(), ClavePuesto);
                bool valNombreInsDep = Regex.IsMatch(fila1.Cells[8].Value.ToString(), ClavePuesto);
                bool valSiglas = Regex.IsMatch(fila1.Cells[9].Value.ToString(), ClaveSiglas);
                bool valClave = Regex.IsMatch(fila1.Cells[10].Value.ToString(), ClaveClave);
                bool valExpediente = Regex.IsMatch(fila1.Cells[11].Value.ToString(), ClaveExpediente);
                bool valTipoFalta = Regex.IsMatch(fila1.Cells[12].Value.ToString(), ClaveTipoFalta);
                bool valDescFalta = Regex.IsMatch(fila1.Cells[13].Value.ToString(), ClavePuesto);
                bool valCausaMotivoHecho = Regex.IsMatch(fila1.Cells[14].Value.ToString(), ClavePuesto);
                ////Mi parte
                bool valObservaciones = Regex.IsMatch(fila1.Cells[15].Value.ToString(), cadenaTexto);
                bool valAutSancionada = Regex.IsMatch(fila1.Cells[16].Value.ToString(), cadenaTexto);
                bool valFechResolucion = Regex.IsMatch(fila1.Cells[17].Value.ToString(), cadenaTexto);
                bool valURL = Regex.IsMatch(fila1.Cells[18].Value.ToString(), URLS);
                bool valPlazo = Regex.IsMatch(fila1.Cells[19].Value.ToString(), cadenaTexto);
                bool valFechInicial = Regex.IsMatch(fila1.Cells[20].Value.ToString(), Fechas);
                bool valFechFinal = Regex.IsMatch(fila1.Cells[21].Value.ToString(), Fechas);
                bool valMonto = Regex.IsMatch(fila1.Cells[22].Value.ToString(), cadenaTexto);
                bool valMoneda = Regex.IsMatch(fila1.Cells[23].Value.ToString(), cadenaTexto);
                bool valTSancion = Regex.IsMatch(fila1.Cells[24].Value.ToString(), cadenaTexto);
                bool valDescSancion = Regex.IsMatch(fila1.Cells[25].Value.ToString(), cadenaTexto);
                bool valTitulo = Regex.IsMatch(fila1.Cells[26].Value.ToString(), cadenaTexto);
                bool valTipoDocumento = Regex.IsMatch(fila1.Cells[27].Value.ToString(), cadenaTexto);
                bool valDescDocumento = Regex.IsMatch(fila1.Cells[28].Value.ToString(), cadenaTexto);
                bool valDocURL = Regex.IsMatch(fila1.Cells[29].Value.ToString(), URLS);
                bool valFecha = Regex.IsMatch(fila1.Cells[30].Value.ToString(), ObligatoriaFechas);
                
                if (!valNombre)
                {
                    fila1.Cells[0].ErrorText = "Nombre invalido";
                    Resultado = false;
                }

                if (!valApellido)
                {
                    fila1.Cells[1].ErrorText = "Primer Apellido invalido";
                    Resultado = false;
                }
                if (!valapellidoDos)
                {
                    fila1.Cells[2].ErrorText = "Segundo Apellido invalido";
                    Resultado = false;
                }
                if (!valGenero)
                {
                    fila1.Cells[3].ErrorText = "Genero invalido";
                    Resultado = false;
                }
                if (!valRFC)
                {
                    fila1.Cells[4].ErrorText = "RFC invalido";
                    Resultado = false;
                }
                if (!valCURP)
                {
                    fila1.Cells[5].ErrorText = "CURP invalido";
                    Resultado = false;
                }
                if (!valCausaMotivoHecho)
                {
                    fila1.Cells[14].ErrorText = "Causa Motivo o Hecho invalida";
                    Resultado = false;
                }
                if (!valObservaciones)
                {
                    fila1.Cells[15].ErrorText = "Observación invalida";
                    Resultado = false;
                }
                if (!valAutSancionada)
                {
                    fila1.Cells[16].ErrorText = "Autoridad Sancionada invalida";
                    Resultado = false;
                }
                if (!valFechResolucion)
                {
                    fila1.Cells[17].ErrorText = "Fecha invalida";
                    Resultado = false;
                }
                if (!valURL)
                {
                    fila1.Cells[18].ErrorText = "URL invalido";
                    Resultado = false;
                }
                if (!valPlazo)
                {
                    fila1.Cells[19].ErrorText = "Plazo invalido";
                    Resultado = false;
                }
                if (!valFechInicial)
                {
                    fila1.Cells[20].ErrorText = "FechInicial invalida";
                    Resultado = false;
                }
                if (!valFechFinal)
                {
                    fila1.Cells[21].ErrorText = "Fech Final invalida";
                    Resultado = false;
                }
                if (!valMonto)
                {
                    fila1.Cells[22].ErrorText = "Monto invalido";
                    Resultado = false;
                }
                if (!valMoneda)
                {
                    fila1.Cells[23].ErrorText = "Moneda invalida";
                    Resultado = false;
                }
                if (!valTSancion)
                {
                    fila1.Cells[24].ErrorText = "Tipo Sanción invalido";
                    Resultado = false;
                }
                if (!valDescSancion)
                {
                    fila1.Cells[25].ErrorText = "Descripción de Sanción invalida";
                    Resultado = false;
                }
                if (!valTitulo)
                {
                    fila1.Cells[26].ErrorText = "Titulo invalido";
                    Resultado = false;
                }
                if (!valTipoDocumento)
                {
                    fila1.Cells[27].ErrorText = "Tipo de Documento invalido";
                    Resultado = false;
                }
                if (!valDescDocumento)
                {
                    fila1.Cells[28].ErrorText = "Descripción invalida";
                    Resultado = false;
                }
                if (!valDocURL)
                {
                    fila1.Cells[29].ErrorText = "URL invalida";
                    Resultado = false;
                }
                if (!valFecha)
                {
                    fila1.Cells[30].ErrorText = "Fecha invalida";
                    Resultado = false;
                }
                

            }
            return Resultado;
        }
        private void btnMostar_Click(object sender, EventArgs e) //Particulares Sancionados
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
        modeloPS modps = new modeloPS();

        private void GuardarPS()
        {
            conPS.guardarPS(modps);
           

        }
        private int obtenerMonedaID(string moneda)
        {
            List<modeloMoneda> lMoneda = new controladorMoneda().obtenerListaMonedas();
            int pos = lMoneda.FindIndex(x => x.valor == moneda);
            return pos;
        }
        private int obtenerTipoSancionPSID( string valor )
        {
            List<modeloTipoSancion> lsancionPS = new controladorTipoSancion().obtenerListaSancionesPS();
           
            //int pos = lsancionPS.FindIndex(x => x.id == sancionaesid);
            int pos = lsancionPS.FindIndex(x => x.valor == valor);
            return pos;
        }
        private int obtenerEntidadFederativaID(string entidadFederativa)
        {
            List<modeloEntidadFederativa> lEntidad = new controladorEntidadFederativa().obtenerListaPais();
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
            List<modeloLocalidad> lLocalida = new controladorLocalidad().obtenerListaLocalidad(municipios);
            int pos = lLocalida.FindIndex(x => x.name == localidad);
            return pos;
        }
        private int obtenerVialidadID(string vialidad, int localidades )
        {
            List<modeloVialidad> lVialidad = new controladorVialidad().obtenerListaVialidad(localidades);
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
            List<modeloTipoDocumento> lDocumento = new controladorTipoDocumento().obtenerListaDocumentosPS();
            int pos = lDocumento.FindIndex(x => x.tipoDocumento == documentos);
            return pos;
        }
    
        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            int columnas = dataGridView1.ColumnCount;
            if (columnas == 55) 
            { 

                modeloTipoSancion modsan = new modeloTipoSancion();
                modeloTipoDocumento modoc = new modeloTipoDocumento();

              foreach (DataGridViewRow row in dataGridView1.Rows)
              {
                 if (validarCamposPS())
                 {
                      
                    modps.expediente = row.Cells[0].Value.ToString();
                    modps.nombreRazonSocial = row.Cells[1].Value.ToString();
                    modps.rfcPS = row.Cells[2].Value.ToString();
                    modps.causaMotivoHechos = row.Cells[3].Value.ToString();
                    modps.acto = row.Cells[4].Value.ToString();
                    modps.objetoContrato = row.Cells[5].Value.ToString();
                    modps.tipoFalta = row.Cells[6].Value.ToString();
                    modps.nombreInstitucionDependencia = row.Cells[7].Value.ToString();
                    modps.siglasInstitucionDependencia = row.Cells[8].Value.ToString();
                    modps.claveInstitucionDependencia = row.Cells[9].Value.ToString();
                    modps.observaciones = row.Cells[10].Value.ToString();
                    modps.autoridadSancionadora = row.Cells[11].Value.ToString();
                    modps.sentidoResolucion = row.Cells[12].Value.ToString();
                    modps.urlResolucion = row.Cells[13].Value.ToString();
                    modps.fechaResolucion = (row.Cells[14].Value.ToString());
                    modps.nombreRS = row.Cells[15].Value.ToString();
                    modps.primerApellidoRS = row.Cells[16].Value.ToString();
                    modps.segundoApellidoRS = row.Cells[17].Value.ToString();
                    modps.plazoInhabilitacion = row.Cells[18].Value.ToString();
                        modps.fechaInicialInhabilitacion = (row.Cells[19].Value.ToString());
                    modps.fechaFinalInhabilitacion = (row.Cells[20].Value.ToString());
                    modps.monto = float.Parse(row.Cells[21].Value.ToString());
                    int m = obtenerMonedaID(row.Cells[22].Value.ToString());
                    modps.moneda = m;
                    int s = obtenerTipoSancionPSID(row.Cells[23].Value.ToString());
                    conPS.guardarSancionPS(s, modsan.descripcion = row.Cells[24].Value.ToString());
                    modps.tipoPersona = row.Cells[25].Value.ToString();
                    modps.telefono = row.Cells[26].Value.ToString();
                    modps.objetoSocial = row.Cells[27].Value.ToString();
                    modps.nombresDG = row.Cells[28].Value.ToString();
                    modps.primerApellidoDG = row.Cells[29].Value.ToString();
                    modps.segundoApellidoDG = row.Cells[30].Value.ToString();
                    modps.curpDG = row.Cells[31].Value.ToString();
                    modps.nombresAL = row.Cells[32].Value.ToString();
                    modps.primerApellidoAL = row.Cells[33].Value.ToString();
                    modps.segundoApellidoAL = row.Cells[34].Value.ToString();
                    modps.curpAL = row.Cells[35].Value.ToString();
                    int entidad = obtenerEntidadFederativaID(row.Cells[36].Value.ToString());
                    modps.entidadFederativa = entidad;
                    int muni = obtenerMunicipioID(row.Cells[37].Value.ToString(), entidad);
                    modps.municipio = muni;
                    int loc = obtenerLocalidadID(row.Cells[38].Value.ToString(), muni);
                    modps.localidad = loc;
                    int vial = obtenerVialidadID(row.Cells[39].Value.ToString(), loc);
                    modps.vialidad = vial;
                    modps.codigoPostalMX = row.Cells[40].Value.ToString();
                    modps.numeroExteriorMX = row.Cells[41].Value.ToString();
                    modps.numeroInteriorEX = row.Cells[42].Value.ToString();
                    modps.calle = row.Cells[43].Value.ToString();
                    modps.ciudadLocalidad = row.Cells[44].Value.ToString();
                    modps.estadoProvincia = row.Cells[45].Value.ToString();
                    modps.codigoPostalEX = row.Cells[46].Value.ToString();
                    modps.numeroInteriorEX = row.Cells[47].Value.ToString();
                    modps.numeroExteriorEX = row.Cells[48].Value.ToString();
                    int paisE = obtenerPaisID(row.Cells[49].Value.ToString());
                    modps.paisEX = paisE;
                    int doc = obtenerDocumentoID(row.Cells[51].Value.ToString());
                    conPS.guardarDocumentoPS(doc, modoc.tipoDocumento = row.Cells[50].Value.ToString(), row.Cells[52].Value.ToString(), row.Cells[53].Value.ToString(), Convert.ToDateTime(row.Cells[54].Value.ToString()).ToString("yyyy-MM-dd"));
                        
                        GuardarPS();
                        MessageBox.Show("Datos de particulares Sancionados insertados");
                    }
                    else
                    {
                        MessageBox.Show("no puedes guardar, tienes campos con errores");
                    }
                }


              
               
            }
            else
            {
                MessageBox.Show("no hay ningun registro");
            }
            //if (validarCamposSPS())
            //{
            //     GuardarPS();
            //}

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        DialogResult resut = MessageBox.Show("Esta seguro de eliminar el registro?", "Warning", MessageBoxButtons.YesNo);
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
                dataGridView2.CurrentCell.ErrorText = String.Empty;


        }

        private void comboSistema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSistema.SelectedIndex != 1)
            {
                panelPS.Visible = false;
                MostrarPS.Visible = false;
                dataGridView1.DataSource = null;

            }
            else
            {
                panelPS.Visible = true;
                panelSPS.Visible = false;
                MostrarPS.Visible = true;
                btnMostar.Visible = false;

            }

            if(comboSistema.SelectedIndex != 2)
            {
                panelSPS.Visible = false;
                btnMostar.Visible = false;
                dataGridView2.DataSource = null;
            
            }
            else
            {
                panelSPS.Visible = true;  
                panelPS.Visible = false;
                btnMostar.Visible = true;
                MostrarPS.Visible = false;
            
            }



        }

        private void MostrarPS_Click(object sender, EventArgs e)
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
    }
}
