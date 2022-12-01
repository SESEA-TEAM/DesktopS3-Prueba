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
        controlador1PS conPS = new controlador1PS();
        String? f1, f2, f3, f4;
        private Particular ParticularS = new Particular();
        private Form2 form2Handler;

        List<modeloTipoDocumento> lDocumentos = new controladorTipoDocumento().obtenerListaDocumentosPS();
        List<modeloTipoSancion> lSancion = new controladorTipoSancion().obtenerListaSancionesPS();
        public CapPS(Form2 form2)
        {
            InitializeComponent();
            llenarCombos();
            CargarDG();
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
            //
            comboBox1.DataSource = new controladorMoneda().obtenerListaMonedasPS();
            comboBox1.ValueMember = "valor";

            //5doc 6san
            comboBox8.DataSource = lDocumentos;
            comboBox8.ValueMember = "tipoDocumento";

            //
            comboBox2.DataSource = lSancion;
            comboBox2.ValueMember = "valor";

            comboBox3.DataSource = new controladorEntidadFederativa().obtenerListaPais();
            comboBox3.ValueMember = "name";



            comboBox7.DataSource = new controladorPais().obtenerListaPais();
            comboBox7.ValueMember = "name";

        }
        //da formato al datagridview de sanciones
        private void CargarDG()
        {

            int p = panel3.Width;

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

        private void button1_Click(object sender, EventArgs e)
        {
            Regex URLS = new Regex(@"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$");

            Match match = URLS.Match(textBox44.Texts);
            if (dateTimePicker3.Text == "2000-01-01")
            {
                f4 = null;
            }
            else
            {
                f4 = dateTimePicker3.Text;
            }
            if (comboBox8.Text == "Tipo Documento")
            {
                errorProvider1.SetError(comboBox8, "Se necesita seleccionar un tipo de documento");
            }
            else
            {
                if (textBox45.Texts == "Título*")
                {
                    errorProvider1.SetError(textBox45, "Se necesita introducir el título del documento");
                }
                else
                {
                    if (textBox46.Texts == "Descripción*")
                    {
                        errorProvider1.SetError(textBox46, "Se necesita introducir la descripción del documento");
                    }
                    else
                    {
                        if (textBox44.Texts == "URL*")
                        {
                            errorProvider1.SetError(textBox44, "Se necesita introducir el URL del documento");
                        }
                        else if (!match.Success)
                        {
                            errorProvider1.SetError(textBox44, "Ingrese un URL válido");
                        }
                        else
                        {
                            if (f4 == null)
                            {
                                errorProvider1.SetError(dateTimePicker3, "Se necesita introducir una fecha válida");
                            }
                            else
                            {
                                modeloTipoDocumento dc = (modeloTipoDocumento)comboBox8.SelectedItem;
                                dataGridView2.Rows.Add(Convert.ToString(dc.Id), textBox45.Texts, comboBox8.Text, textBox46.Texts, textBox44.Texts, dateTimePicker3.Text);
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            int p = panel10.Height;
            if (!radioButton3.Checked)
            {
                
                //panel8.Location = new Point(0,547);
                panel8.Top += p;
            }
            else
            {
                //panel8.Location = new Point(0, 321);
                //panel8.Location = p1;
                panel8.Top -= p;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                panel10.Visible = false;
            }
            else
            {
                panel10.Visible = true;
                panel9.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (guardar())
            {
                MessageBox.Show("Se ha realizado el registro con exito");
                form2Handler.ListaPS();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Tipo Sanción")
            {
                errorProvider1.SetError(comboBox2, "Se necesita seleccionar un tipo de sanción");
            }
            else
            {
                if (textBox1.Texts == "Descripción")
                {
                    modeloTipoSancion sn = (modeloTipoSancion)comboBox2.SelectedItem;
                    dataGridView1.Rows.Add(Convert.ToString(sn.id), comboBox2.Text);
                    textBox1.Texts = "Descripción";
                    comboBox2.SelectedItem = lSancion[0];
                }
                else
                {
                    modeloTipoSancion sn = (modeloTipoSancion)comboBox2.SelectedItem;
                    dataGridView1.Rows.Add(Convert.ToString(sn.id), comboBox2.Text, textBox1.Texts);
                    textBox1.Texts = "Descripción";
                    comboBox2.SelectedItem = lSancion[0];
                }

            }
        }

        private void CapPS_Load(object sender, EventArgs e)
        {
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

            modeloEntidadFederativa ef = (modeloEntidadFederativa)comboBox3.SelectedItem;
            comboBox4.DataSource = new controladorMunicipio().obtenerListaMunicipio(ef.id);
            comboBox4.ValueMember = "name";

        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
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
            modeloLocalidad lc = (modeloLocalidad)comboBox5.SelectedItem;
            comboBox6.DataSource = new controladorVialidad().obtenerListaVialidad(lc.id);
            comboBox6.ValueMember = "name";
        }

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
                Regex RFC = new Regex(@"^([A-ZÑ&]{4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$");

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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (!radioButton2.Checked)
            {
                panel9.Visible = false;
            }
            else
            {
                panel9.Visible = true;
                panel10.Visible = false;
            }
        }

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

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resut = MessageBox.Show("¿Desea cancelar esta operación? Si cancela se perderán todos los datos que ha ingresado", "Cancelar registro", MessageBoxButtons.YesNo);
            if (resut == DialogResult.Yes)
            {

                form2Handler.ListaPS();

            }
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
            Regex ZIPC = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$");
            Match matchZIPMX = ZIPC.Match(textBox34.Texts);
            Regex RFC = new Regex(@"^([A-ZÑ&]{4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$");
            Match matchRFC = RFC.Match(textBox18.Texts);
            Regex nombre = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchN = nombre.Match(textBox4.Texts);
            Regex apellidoP = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchP = apellidoP.Match(textBox3.Texts);
            Regex apellidoM = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchM = apellidoM.Match(textBox2.Texts);
            Regex CURP = new Regex(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$");
            Match matchC = CURP.Match(textBox28.Texts);
            bool valor = true;
            if (textBox17.Texts == "Causa, motivo o hechos*" || textBox18.Texts == "RFC*" || textBox20.Texts == "Expediente*" || textBox12.Texts == "Tipo falta*" || textBox7.Texts == "Nombre(s)*" || textBox5.Texts == "Autoridad sancionadora*" || textBox4.Texts == "Nombre(s)*" || textBox3.Texts == "Primer apellido*" || comboBox9.Text == "Tipo persona*" || textBox19.Texts == "Nombre(s)/Razón Social*")
            {
                MessageBox.Show("Debe completar los campos obligatorios para poder hacer el registro");

                valor = false;
            }
            else
            {
                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("Necesita asignar al menos una sanción al registro");
                    valor = false;
                }
                else
                {
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

                    //modeloListaGenero gn = (modeloListaGenero)comboBox2.SelectedItem;
                    //modeloTipoFalta fl = (modeloTipoFalta)comboBox3.SelectedItem;

                    modeloMoneda mn = (modeloMoneda)comboBox1.SelectedItem;
                    //modeloTipoSancion sn = (modeloTipoSancion)comboBox3.SelectedItem;
                    modeloPS modPS = new modeloPS();
                    if (radioButton1.Checked)
                    {
                        modeloEntidadFederativa ef = (modeloEntidadFederativa)comboBox3.SelectedItem;
                        modeloMunicipio mp = (modeloMunicipio)comboBox4.SelectedItem;
                        modeloLocalidad lc = (modeloLocalidad)comboBox5.SelectedItem;
                        modeloVialidad v = (modeloVialidad)comboBox6.SelectedItem;

                        //cambiar por el id de mexico en la tabla final de paisas
                        modPS.paisMX = 3;

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
                    if (radioButton2.Checked)
                    {
                        modeloPais ps = (modeloPais)comboBox7.SelectedItem;
                        if (ps.id == 0)
                        {

                        }
                        else
                        {
                            modPS.paisEX = Convert.ToInt32(ps.id);
                        }
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

                    modPS.fechaResolucion = f1;
                    modPS.fechaInicialInhabilitacion = f2;
                    modPS.fechaFinalInhabilitacion = f3;

                    if (valor == true)
                    {
                        conPS.guardarPS(modPS);

                        foreach (DataGridViewRow fila in dataGridView1.Rows)
                        {
                            conPS.guardarSancionPS(Convert.ToInt16(fila.Cells["ID"].Value), Convert.ToString(fila.Cells["Descripcion"].Value));
                        }

                        foreach (DataGridViewRow fila2 in dataGridView2.Rows)
                        {
                            conPS.guardarDocumentoPS(Convert.ToInt16(fila2.Cells["idxd"].Value), Convert.ToString(fila2.Cells["Titulo"].Value), Convert.ToString(fila2.Cells["descripcionxd"].Value), Convert.ToString(fila2.Cells["URL"].Value), Convert.ToString(fila2.Cells["Fecha"].Value));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe completar los campos obligatorios para poder hacer el registro");
                    }
                }
            }
            return valor;
        }
    }
}
