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

namespace Sistema_de_sanciones
{
    
    public partial class modSPS : Form
    {
        controlador1SPS conSPS = new controlador1SPS();
        String? f1, f2, f3, f4;
        int idSps;
        private ServidorPublico ServidorP = new ServidorPublico();

        List<modeloTipoDocumento> lDocumentos = new controladorTipoDocumento().obtenerListaDocumentos();
        List<modeloMoneda> lMoneda = new controladorMoneda().obtenerListaMonedas();
        List<modeloTipoSancion> lSancion = new controladorTipoSancion().obtenerListaSanciones();
        List<modeloListaGenero> lGenero = new controladorListaGenero().obtenerListaGenero();
        List<modeloTipoFalta> lFalta = new controladorTipoFalta().obtenerListaFaltas();

        private Form2 form2Handler;
        public modSPS(Form2 form2, int id)
        {
            idSps= id;



            InitializeComponent();
            llenarCombos();
            CargarDG();
            dateTimePicker1.Value = new DateTime(2000, 01, 01);
            dateTimePicker2.Value = new DateTime(2000, 01, 01);
            dateTimePicker3.Value = new DateTime(2000, 01, 01);
            dateTimePicker4.Value = new DateTime(2000, 01, 01);

            cargarDatos();
            form2Handler = form2;
            //modeloSPS modSPS = new modeloSPS();
            //dataGridView1.Columns.Add("ID", "ID");
            //dataGridView1.Columns.Add("Tipo","Tipo");
            //dataGridView1.Columns.Add("Descripción","Descripción");

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
            comboBox2.DataSource = lGenero;
            comboBox2.ValueMember = "valor";

            comboBox3.DataSource = lFalta;
            comboBox3.ValueMember = "valor";

            comboBox4.DataSource = lMoneda;
            comboBox4.ValueMember = "valor";

            comboBox5.DataSource = lDocumentos;
            comboBox5.ValueMember = "tipoDocumento";

            comboBox6.DataSource = lSancion;
            comboBox6.ValueMember = "valor";
        }
        //da formato al datagridview de sanciones
        private void CargarDG()
        {
            int p = panel3.Width;

            dataGridView1.Columns[2].Width = (Convert.ToInt32(p * 0.46));
            dataGridView1.Columns[3].Width = (Convert.ToInt32(p * 0.45));
     
            dataGridView2.Columns[2].Width = 184;
            dataGridView2.Columns[3].Width = 186;
            dataGridView2.Columns[4].Width = 204;
            dataGridView2.Columns[5].Width = 239;
            dataGridView2.Columns[6].Width = 184;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox6.Text == "Tipo Sanción")
            {
                errorProvider1.SetError(comboBox6, "Se necesita seleccionar un tipo de sanción");
            }  
            else
            {
                if(textBox22.Texts == "Descripción")
                {
                    modeloTipoSancion sn = (modeloTipoSancion)comboBox6.SelectedItem;
                    dataGridView1.Rows.Add(Convert.ToString(sn.id),"1", comboBox6.Text);
                    textBox22.Texts = "Descripción";
                    comboBox6.SelectedItem = lSancion[0];
                }
                else
                {
                    modeloTipoSancion sn = (modeloTipoSancion)comboBox6.SelectedItem;
                    dataGridView1.Rows.Add(Convert.ToString(sn.id),"1", comboBox6.Text, textBox22.Texts);
                    textBox22.Texts = "Descripción";
                    comboBox6.SelectedItem = lSancion[0];
                }
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (modificar())
            {
                MessageBox.Show("La modificacion se ha realizado con exito");
                this.Close();
                form2Handler.ListaSPS();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Regex URLS = new Regex(@"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$");
            Match match = URLS.Match(textBox20.Texts);
            if (dateTimePicker4.Text == "2000-01-01")
            {
                f4 = null;
            }
            else
            {
                f4 = dateTimePicker4.Text;
            }
            if (comboBox5.Text == "Tipo Documento")
            {
                errorProvider1.SetError(comboBox5, "Se necesita seleccionar un tipo de documento");
            }
            else
            {
                if(textBox23.Texts == "Título*")
                {
                    errorProvider1.SetError(textBox23, "Se necesita introducir el título del documento");
                }
                else
                {
                    if(textBox29.Texts == "Descripción*")
                    {
                        errorProvider1.SetError(textBox29, "Se necesita introducir la descripción del documento");
                    }
                    else
                    {
                        if (textBox20.Texts == "URL*")
                        {
                            errorProvider1.SetError(textBox20, "Se necesita introducir el URL del documento");
                        }
                        else if (!match.Success)
                        {
                            errorProvider1.SetError(textBox20, "Ingrese un URL válido");
                        }
                        else
                        {
                            if (f4 == null)
                            {
                                errorProvider1.SetError(dateTimePicker4, "Se necesita introducir una fecha válida");
                            }
                            else
                            {
                                modeloTipoDocumento dc = (modeloTipoDocumento)comboBox5.SelectedItem;
                                dataGridView2.Rows.Add(Convert.ToString(dc.Id),"1", textBox23.Texts, comboBox5.Text, textBox29.Texts, textBox20.Texts, dateTimePicker4.Text);
                                textBox23.Texts = "Título*";
                                textBox29.Texts = "Descripción*";
                                textBox20.Texts = "URL*";
                                dateTimePicker4.Value = new DateTime(2000, 01, 01);
                                comboBox5.SelectedItem = lDocumentos[0];
                            }                            
                        }
                    }
                }
            }
            
        }

        private void modSPS_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "quitar";
            Ver.Name = "quitar";
            Ver.Width = 106;
            Ver.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(Ver);
            //dataGridView2.Columns.Add(Ver);
            DataGridViewButtonColumn Ver2 = new DataGridViewButtonColumn();
            Ver2.HeaderText = "quitar";
            Ver2.Name = "quitar";
            Ver2.Width = 109;
            Ver2.FlatStyle = FlatStyle.Flat;
            dataGridView2.Columns.Add(Ver2);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 4)
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
                    if (!(dataGridView1.CurrentRow.Cells["n"].Value.ToString() == "0"))
                    {
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow); //Se elimina la fila seleccionada del DataGridView.
                    }
                }
            }
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
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
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "quitar")
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    if (!(dataGridView2.CurrentRow.Cells["n2"].Value.ToString() == "0"))
                    {
                        dataGridView2.Rows.Remove(dataGridView2.CurrentRow); //Se elimina la fila seleccionada del DataGridView.
                    }
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Texts == "Nombre(s)*")
            {
                textBox1.Texts = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Texts == "")
            {
                textBox1.Texts = "Nombre(s)*";
                errorProvider1.SetError(textBox1, "Se necesita ingresar un nombre");
                textBox1.ForeColor = Color.Gray;
            }
            else
            {
                textBox1.ForeColor = Color.Black;
                Regex nombre = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match match = nombre.Match(textBox1.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox1, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox1, "Se necesita un nombre válido");
                }
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Texts == "Primer apellido*")
            {
                textBox2.Texts = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Texts == "")
            {
                textBox2.Texts = "Primer apellido*";
                errorProvider1.SetError(textBox2, "Se necesita ingresar un apellido");
                textBox2.ForeColor = Color.Gray;
            }
            else
            {
                textBox2.ForeColor = Color.Black;
                Regex apellidoP = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match match = apellidoP.Match(textBox2.Texts);
                if (match.Success)
                {
                    errorProvider1.SetError(textBox2, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox2, "Se necesita un apellido válido");
                }
            }
        }

        private void textBox3_Enter_1(object sender, EventArgs e)
        {
            
                if (textBox3.Texts == "Segundo apellido")
                {
                    textBox3.Texts = "";
                    textBox3.ForeColor = Color.Black;
                }
            
        }

        private void textBox3_Leave_1(object sender, EventArgs e)
        {
            if (textBox3.Texts == "")
            {
                textBox3.Texts = "Segundo apellido";
                textBox3.ForeColor = Color.Gray;
            }
            else
            {
                textBox3.ForeColor = Color.Black;
                Regex apellidoM = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
                Match match = apellidoM.Match(textBox3.Texts);
                if (match.Success)
                {
                    errorProvider1.SetError(textBox3, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox3, "Se necesita un apellido válido");
                }
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Texts == "RFC*")
            {
                textBox4.Texts = "";
                errorProvider1.SetError(textBox4, "Se necesita ingresar un RFC");
                textBox4.ForeColor = Color.Gray;
            }
            else
            {
                textBox4.ForeColor = Color.Black;
                Regex RFC = new Regex(@"^([A-ZÑ&]{4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$");

                Match match = RFC.Match(textBox4.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox4, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox4, "Se necesita ingresar un RFC válido");

                }

            }
        }

        private void textBox4_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Texts == "CURP*")
            {
                errorProvider1.SetError(textBox5, "Se necesita ingresar un CURP");
                textBox5.ForeColor = Color.Gray;
            }
            else
            {
                textBox5.ForeColor = Color.Black;
                Regex CURP = new Regex(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$");

                Match match = CURP.Match(textBox5.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox5, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox5, "Se necesita ingresar un CURP válido");
                }
            }
        }

        private void textBox5_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Texts == "")
            {
                textBox4.Texts = "RFC*";
                errorProvider1.SetError(textBox4, "Se necesita ingresar el RFC");
                textBox4.ForeColor = Color.Gray;
            }
            else
            {
                textBox4.ForeColor = Color.Black;
                Regex RFC = new Regex(@"^([A-ZÑ&]{4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$");

                Match match = RFC.Match(textBox4.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox4, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox4, "Se necesita ingresar un RFC válido");

                }

            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Texts == "")
            {
                textBox5.Texts = "CURP*";
                errorProvider1.SetError(textBox5, "Se necesita ingresar la CURP");
                textBox5.ForeColor = Color.Gray;
            }
            else
            {
                textBox5.ForeColor = Color.Black;
                Regex CURP = new Regex(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$");

                Match match = CURP.Match(textBox5.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox4, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox5, "Se necesita ingresar un CURP válido");
                }
            }
        }

        private void textBox25_Enter(object sender, EventArgs e)
        {
            if (textBox25.Texts == "Puesto nombre*")
            {
                textBox25.Texts = "";
                textBox25.ForeColor = Color.Black;
            }
        }

        private void textBox25_Leave(object sender, EventArgs e)
        {
            if (textBox25.Texts == "")
            {
                textBox25.Texts = "Puesto nombre*";
                errorProvider1.SetError(textBox25, "Se necesita ingresar un puesto");
                textBox25.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox25, String.Empty);

            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Texts == "Puesto nivel")
            {
                textBox6.Texts = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Texts == "")
            {
                textBox6.Texts = "Puesto nivel";
                textBox6.ForeColor = Color.Gray;
            }
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            if (textBox15.Texts == "Nombre*")
            {
                textBox15.Texts = "";
                textBox15.ForeColor = Color.Black;
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            if (textBox15.Texts == "")
            {
                textBox15.Texts = "Nombre*";
                errorProvider1.SetError(textBox15, "Se necesita ingresar una institución o dependencia");
                textBox15.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox15, String.Empty);

            }
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            if (textBox13.Texts == "Siglas")
            {
                textBox13.Texts = "";
                textBox13.ForeColor = Color.Black;
            }
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {
            if (textBox13.Texts == "")
            {
                textBox13.Texts = "Siglas";
                textBox13.ForeColor = Color.Gray;
            }
        }

        private void textBox14_Enter(object sender, EventArgs e)
        {
            if (textBox14.Texts == "Clave")
            {
                textBox14.Texts = "";
                textBox14.ForeColor = Color.Black;
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            if (textBox14.Texts == "")
            {
                textBox14.Texts = "Clave";
                textBox14.ForeColor = Color.Gray;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Texts == "Expediente*")
            {
                textBox7.Texts = "";
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Texts == "")
            {
                textBox7.Texts = "Expediente*";
                errorProvider1.SetError(textBox7, "Se necesita ingresar el expediente correspondiente");
                textBox7.ForeColor = Color.Gray;
            }
            else
            {
                textBox7.ForeColor = Color.Black;
                errorProvider1.SetError(textBox7, String.Empty);

            }
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textBox11.Texts == "Descripción")
            {
                textBox11.Texts = "";
                textBox11.ForeColor = Color.Black;
            }
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Texts == "")
            {
                textBox11.Texts = "Descripción";
                textBox11.ForeColor = Color.Gray;
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Texts == "Causa, motivo o hechos*")
            {
                textBox9.Texts = "";
                textBox9.ForeColor = Color.Black;
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Texts == "")
            {
                textBox9.Texts = "Causa, motivo o hechos*";
                errorProvider1.SetError(textBox9, "Se necesita una causa, motivo o hecho");
                textBox9.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox9, String.Empty);
            }
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            if (textBox12.Texts == "Observaciones")
            {
                textBox12.Texts = "";
                textBox12.ForeColor = Color.Black;
            }
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            if (textBox12.Texts == "")
            {
                textBox12.Texts = "Observaciones";
                textBox12.ForeColor = Color.Gray;
            }
        }

        private void textBox16_Load(object sender, EventArgs e)
        {

        }

        private void textBox16_Leave(object sender, EventArgs e)
        {
            if (textBox16.Texts == "")
            {
                textBox16.Texts = "Autoridad sancionadora*";
                errorProvider1.SetError(textBox16, "Se necesita ingresar la autoridad sancionadora");
                textBox16.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox16, String.Empty);

            }
        }

        private void textBox16_Enter(object sender, EventArgs e)
        {
            if (textBox16.Texts == "Autoridad sancionadora*")
            {
                textBox16.Texts = "";
                textBox16.ForeColor = Color.Black;
            }
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (textBox10.Texts == "URL")
            {
                textBox10.Texts = "";
                textBox10.ForeColor = Color.Black;
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Texts == "")
            {
                textBox10.Texts = "URL";
                textBox10.ForeColor = Color.Gray;
            }
            else
            {
                Regex URLS = new Regex(@"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$");

                Match match = URLS.Match(textBox10.Texts);

                if (match.Success)
                {
                    errorProvider1.SetError(textBox10, String.Empty);
                }
                else
                {
                    errorProvider1.SetError(textBox10, "Ingrese un URL válido");
                }
            }
        }

        private void textBox19_Enter(object sender, EventArgs e)
        {
            if (textBox19.Texts == "Plazo")
            {
                textBox19.Texts = "";
                textBox19.ForeColor = Color.Black;
            }
        }

        private void textBox19_Leave(object sender, EventArgs e)
        {
            if (textBox19.Texts == "")
            {
                textBox19.Texts = "Plazo";
                textBox19.ForeColor = Color.Gray;
            }
        }

        private void textBox21_Enter(object sender, EventArgs e)
        {
            if (textBox21.Texts == "Monto")
            {
                textBox21.Texts = "";
                textBox21.ForeColor = Color.Black;
            }
        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            if (textBox21.Texts == "")
            {
                textBox21.Texts = "Monto";
                textBox21.ForeColor = Color.Gray;
            }
        }

        private void textBox22_Enter(object sender, EventArgs e)
        {
            if (textBox22.Texts == "Descripción")
            {
                textBox22.Texts = "";
                textBox22.ForeColor = Color.Black;
            }
        }

        private void textBox22_Leave(object sender, EventArgs e)
        {
            if (textBox22.Texts == "")
            {
                textBox22.Texts = "Descripción";
                textBox22.ForeColor = Color.Gray;
            }
        }

        private void comboBox6_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox6, String.Empty);
        }

        private void textBox23_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox23, String.Empty);
            if (textBox23.Texts == "Título*")
            {
                textBox23.Texts = "";
                textBox23.ForeColor = Color.Black;
            }
        }

        private void textBox23_Leave(object sender, EventArgs e)
        {
            if (textBox23.Texts == "")
            {
                textBox23.Texts = "Título*";
                textBox23.ForeColor = Color.Gray;
            }
        }

        private void textBox29_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox29, String.Empty);
            if (textBox29.Texts == "Descripción*")
            {
                textBox29.Texts = "";
                textBox29.ForeColor = Color.Black;
            }
        }

        private void textBox29_Leave(object sender, EventArgs e)
        {
            if (textBox29.Texts == "")
            {
                textBox29.Texts = "Descripción*";
                textBox29.ForeColor = Color.Gray;
            }
        }

        private void dateTimePicker4_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(dateTimePicker4, String.Empty);
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox5, String.Empty);
        }

        private void textBox20_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox20, String.Empty);
            if (textBox20.Texts == "URL*")
            {
                textBox20.Texts = "";
                textBox20.ForeColor = Color.Black;
            }
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            if (textBox20.Texts == "")
            {
                textBox20.Texts = "URL*";
                errorProvider1.SetError(textBox20, "Se requiere un URL");
                textBox20.ForeColor = Color.Gray;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            form2Handler.ListaSPS();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.textKeyPress(e);
        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            ServidorP.textBoxEvent.validarNumeros(e);
        }

        private void comboBox5_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox5, String.Empty);
        }

        public void cargarDatos()
        {
            modeloSPS msps = new modeloSPS();
            msps = conSPS.CsdsdargarSPS(idSps);

            textBox16.Texts = msps.autoridadSancionadora;
            textBox16.ForeColor = Color.Black;
            textBox7.Texts = msps.expediente;
            textBox7.ForeColor = Color.Black;
            textBox4.Texts = msps.rfcSPS;
            textBox4.ForeColor = Color.Black;
            textBox5.Texts = msps.curpSPS;
            textBox5.ForeColor = Color.Black;
            textBox1.Texts = msps.nombreSPS;
            textBox1.ForeColor = Color.Black;
            textBox2.Texts = msps.primerApellidoSPS;
            textBox2.ForeColor = Color.Black;
            textBox25.Texts = msps.puestoSPS;
            textBox25.ForeColor = Color.Black;
            textBox15.Texts = msps.nombreInstitucionDependencia;
            textBox15.ForeColor = Color.Black;
            textBox9.Texts = msps.causaMotivoHechos;
            textBox9.ForeColor = Color.Black;
            comboBox3.SelectedItem = lFalta[Convert.ToInt32(msps.tipoFalta)];
            if (msps.segundoApellidoSPS == null)
            {

            }
            else
            {
                textBox3.Texts = msps.segundoApellidoSPS;
                textBox3.ForeColor = Color.Black;
            }
            if (msps.nivelSPS == null)
            {

            }
            else
            {
                textBox6.Texts = msps.nivelSPS;
                textBox6.ForeColor = Color.Black;
            }
            if (msps.siglasInstitucionDependencia == null)
            {

            }
            else
            {
                textBox13.Texts = msps.siglasInstitucionDependencia;
                textBox13.ForeColor = Color.Black;
            }
            if (msps.claveInstitucionDependencia == null)
            {

            }
            else
            {
                textBox14.Texts = msps.claveInstitucionDependencia;
                textBox14.ForeColor = Color.Black;
            }
            if (msps.descripcionFalta == null)
            {

            }
            else
            {
                textBox11.Texts = msps.descripcionFalta;
                textBox11.ForeColor = Color.Black;
            }
            if (msps.observaciones == null)
            {

            }
            else
            {
                textBox12.Texts = msps.observaciones;
                textBox12.ForeColor = Color.Black;
            }
            if (msps.urlResolucion == null)
            {

            }
            else
            {
                textBox10.Texts = msps.urlResolucion;
                textBox10.ForeColor = Color.Black;
            }
            if (msps.plazoInhabilitacion == null)
            {

            }
            else
            {
                textBox19.Texts = msps.plazoInhabilitacion;
                textBox19.ForeColor = Color.Black;
            }
            if (msps.montoMulta == null)
            {

            }
            else
            {
                textBox21.Texts = Convert.ToString(msps.montoMulta);
                textBox21.ForeColor = Color.Black;
            }
            if (msps.monedaMulta == null)
            {

            }
            else
            {
                comboBox4.SelectedItem = lMoneda[Convert.ToInt32(msps.monedaMulta)];
            }
            if (msps.generoSPS == null)
            {

            }
            else
            {
                comboBox2.SelectedItem = lGenero[Convert.ToInt32(msps.generoSPS)];
            }

            List<modeloTipoSancion> listaSancionesSPS = new List<modeloTipoSancion>();
            listaSancionesSPS = conSPS.obtenerSancionesSPS(idSps);
            for (var i = 0; i < listaSancionesSPS.Count; i++)
            {
                dataGridView1.Rows.Add(listaSancionesSPS[i].id, "0", listaSancionesSPS[i].valor, listaSancionesSPS[i].descripcion);

            }
            List<modeloTipoDocumento> listaDocsSPS = new List<modeloTipoDocumento>();
            listaDocsSPS = conSPS.obtenerDocumentosSPS(idSps);
            for (var i = 0; i < listaDocsSPS.Count; i++)
            {
                String a = (listaDocsSPS[i].fechaDocumento).Remove(10, 15).Remove(0, 6);
                String m = (listaDocsSPS[i].fechaDocumento).Remove(5, 20).Remove(0, 3);
                String d = (listaDocsSPS[i].fechaDocumento).Remove(2, 23);
                String f = a + "-" + m + "-" + d;
                dataGridView2.Rows.Add(listaDocsSPS[i].Id, "0", listaDocsSPS[i].tituloDocumento, listaDocsSPS[i].tipoDocumento, listaDocsSPS[i].descripcionDocumento, listaDocsSPS[i].urlDocumento, f);

            }
        }

        private bool modificar()
        {
            Regex nombre = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchN = nombre.Match(textBox1.Texts);
            Regex apellidoP = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchP = apellidoP.Match(textBox2.Texts);
            Regex RFC = new Regex(@"^([A-ZÑ&]{4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$");
            Match matchR = RFC.Match(textBox4.Texts);
            Regex CURP = new Regex(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$");
            Match matchC = CURP.Match(textBox5.Texts);
            Regex URLS = new Regex(@"^https?:\/\/[\w\-]+(\.[\w\-]+)+[#?]?.*$");
            Match matchU = URLS.Match(textBox10.Texts);
            Regex apellidoM = new Regex(@"^[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙÑñ]{3,100}$");
            Match matchM = apellidoM.Match(textBox3.Texts);

            bool r = true;
            if (textBox1.Texts == "Nombre(s)*" || textBox2.Texts == "Primer apellido*" || textBox4.Texts == "RFC*" || textBox5.Texts == "CURP*" || textBox7.Texts == "Expediente*" || textBox25.Texts == "Puesto nombre*" || textBox15.Texts == "Nombre*" || textBox16.Texts == "Autoridad sancionadora*" || textBox9.Texts == "Causa, motivo o hechos*" || comboBox3.Text == "Tipo falta")
            {
                MessageBox.Show("Debe completar los campos obligatorios para poder hacer el registro");
                r = false;
            }
            else
            {
                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("Necesita asignar al menos una sanción al registro");
                }
                else
                {
                    if (matchN.Success)
                    {
                        errorProvider1.SetError(textBox1, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox1, "Se necesita un nombre válido");
                        r = false;
                    }
                    if (matchP.Success)
                    {
                        errorProvider1.SetError(textBox2, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox2, "Se necesita un apellido válido");
                        r = false;
                    }
                    if (matchR.Success)
                    {
                        errorProvider1.SetError(textBox4, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox4, "Se necesita un RFC válido");
                        r = false;
                    }
                    if (matchC.Success)
                    {
                        errorProvider1.SetError(textBox5, String.Empty);
                    }
                    else
                    {
                        errorProvider1.SetError(textBox5, "Se necesita un CURP válido");
                        r = false;
                    }

                    if (dateTimePicker1.Text == "2000-01-01")
                    {
                        f1 = null;
                    }
                    else
                    {
                        f1 = dateTimePicker1.Text;
                    }
                    if (dateTimePicker2.Text == "2000-01-01")
                    {
                        f2 = null;
                    }
                    else
                    {
                        f2 = dateTimePicker2.Text;
                    }
                    if (dateTimePicker3.Text == "2000-01-01")
                    {
                        f3 = null;
                    }
                    else
                    {
                        f3 = dateTimePicker3.Text;
                    }

                    modeloListaGenero gn = (modeloListaGenero)comboBox2.SelectedItem;
                    modeloTipoFalta fl = (modeloTipoFalta)comboBox3.SelectedItem;
                    modeloMoneda mn = (modeloMoneda)comboBox4.SelectedItem;


                    modeloSPS modSPS = new modeloSPS();
                    if (gn.Id == 0)
                    {

                    }
                    else
                    {
                        modSPS.generoSPS = Convert.ToInt32(gn.Id);
                    }
                    if (mn.Id == 0)
                    {

                    }
                    else
                    {
                        modSPS.monedaMulta = Convert.ToInt32(mn.Id);
                    }
                    if (textBox3.Texts == "Segundo apellido")
                    {

                    }
                    else
                    {
                        if (matchM.Success)
                        {
                            modSPS.segundoApellidoSPS = textBox3.Texts;
                            errorProvider1.SetError(textBox3, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox3, "Se necesita un apellido válido");
                            r = false;
                        }
                    }
                    if (textBox4.Texts == "RFC")
                    {

                    }
                    else
                    {
                        modSPS.rfcSPS = textBox4.Texts;
                    }
                    if (textBox5.Texts == "CURP")
                    {

                    }
                    else
                    {
                        modSPS.curpSPS = textBox5.Texts;
                    }
                    if (textBox6.Texts == "Puesto nivel")
                    {

                    }
                    else
                    {
                        modSPS.nivelSPS = textBox6.Texts;
                    }
                    if (textBox13.Texts == "Siglas")
                    {

                    }
                    else
                    {
                        modSPS.siglasInstitucionDependencia = textBox13.Texts;
                    }
                    if (textBox14.Texts == "Clave")
                    {

                    }
                    else
                    {
                        modSPS.claveInstitucionDependencia = textBox14.Texts;
                    }
                    if (textBox7.Texts == "Expediente")
                    {

                    }
                    else
                    {
                        modSPS.expediente = textBox7.Texts;
                    }
                    if (textBox11.Texts == "Descripción")
                    {

                    }
                    else
                    {
                        modSPS.descripcionFalta = textBox11.Texts;
                    }
                    if (textBox12.Texts == "Observaciones")
                    {

                    }
                    else
                    {
                        modSPS.observaciones = textBox12.Texts;
                    }
                    if (textBox16.Texts == "Autoridad sancionadora")
                    {

                    }
                    else
                    {
                        modSPS.autoridadSancionadora = textBox16.Texts;
                    }
                    if (textBox10.Texts == "URL")
                    {

                    }
                    else
                    {
                        if (matchU.Success)
                        {
                            modSPS.urlResolucion = textBox10.Texts;
                            errorProvider1.SetError(textBox10, String.Empty);
                        }
                        else
                        {
                            errorProvider1.SetError(textBox10, "Se necesita un apellido válido");
                            r = false;
                        }
                    }
                    if (textBox19.Texts == "Plazo")
                    {

                    }
                    else
                    {
                        modSPS.plazoInhabilitacion = textBox19.Texts;
                    }
                    if (textBox21.Texts == "Monto")
                    {

                    }
                    else
                    {
                        modSPS.montoMulta = Convert.ToInt32(textBox21.Texts);
                    }
                    modSPS.nombreSPS = textBox1.Texts;
                    modSPS.primerApellidoSPS = textBox2.Texts;
                    modSPS.rfcSPS = textBox4.Texts;
                    modSPS.curpSPS = textBox5.Texts;
                    modSPS.puestoSPS = textBox25.Texts;
                    modSPS.nombreInstitucionDependencia = textBox15.Texts;
                    modSPS.autoridadSancionadora = textBox16.Texts;
                    modSPS.causaMotivoHechos = textBox9.Texts;
                    modSPS.tipoFalta = fl.Id;
                    modSPS.fechaResolucion = f2;
                    modSPS.fechaInicialInhabilitacion = f1;
                    modSPS.fechaFinalInhabilitacion = f3;

                    if (r == true)
                    {
                        if (conSPS.modificarSPS(modSPS, idSps)) 
                        { 
                            r = true;
                            foreach (DataGridViewRow fila in dataGridView1.Rows)
                            {
                                if (!(fila.Cells["n"].Value.ToString() == "0"))
                                {
                                    if (conSPS.agregarSancionSPS(Convert.ToInt16(fila.Cells["ID"].Value), Convert.ToString(fila.Cells["Descripcion"].Value), idSps)) { r = true; } else { r = false; }
                                }

                            }

                            foreach (DataGridViewRow fila2 in dataGridView2.Rows)
                            {
                                if (!(fila2.Cells["n2"].Value.ToString() == "0"))
                                {
                                    if (conSPS.agregarDocumentoSPS(Convert.ToInt16(fila2.Cells["idxd"].Value), Convert.ToString(fila2.Cells["Titulo"].Value), Convert.ToString(fila2.Cells["descripcionxd"].Value), Convert.ToString(fila2.Cells["URL"].Value), Convert.ToString(fila2.Cells["Fecha"].Value), idSps)) { r = true; } else { r = false; }
                                }

                            }
                        } 
                        else { r = false; }
                    }
                    else
                    {
                        MessageBox.Show("Debe completar los campos obligatorios para poder hacer el registro");
                    }
                }
            }
            return r;
        }
    }
}
