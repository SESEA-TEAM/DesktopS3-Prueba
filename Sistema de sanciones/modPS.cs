﻿using Sistema_de_sanciones.Controladores;
using Sistema_de_sanciones.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_sanciones
{
    public partial class modPS : Form
    {
        String? f1, f2, f3, f4;
        controlador1PS conPS = new controlador1PS();
        int idPs;

        //estas listas las puedo llenar desde un inicio con sus valores
        List<modeloTipoDocumento> lDocumentos = new controladorTipoDocumento().obtenerListaDocumentosPS();
        List<modeloMoneda> lMoneda = new controladorMoneda().obtenerListaMonedasPS();
        List<modeloTipoSancion> lSancion = new controladorTipoSancion().obtenerListaSancionesPS();
        List<modeloPais> lPais = new controladorPais().obtenerListaPais();
        List<modeloEntidadFederativa> lentidad = new controladorEntidadFederativa().obtenerListaPais();

        //estas listas se devclaran y se llenan despues porque dependen de otros valores
        List<modeloMunicipio> lMunicipio = new List<modeloMunicipio>();
        List<modeloLocalidad> lLocalidad = new List<modeloLocalidad>();
        List<modeloVialidad> lVialidad = new List<modeloVialidad>();
        

        //int p = 0;

        //nos ayuda a obtener la instancia de form 2
        private Form2 form2Handler;
        public modPS(Form2 form2, int id)
        {
            idPs = id;
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
            cargarDatos();

            form2Handler = form2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_Load(object sender, EventArgs e)
        {

        }

        private void rjComboBox5_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox43_Load(object sender, EventArgs e)
        {

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
                    dataGridView1.Rows.Add(Convert.ToString(sn.id),"1", comboBox2.Text);
                    textBox1.Texts = "Descripción";
                }
                else
                {
                    modeloTipoSancion sn = (modeloTipoSancion)comboBox2.SelectedItem;
                    dataGridView1.Rows.Add(Convert.ToString(sn.id),"1", comboBox2.Text, textBox1.Texts);
                    textBox1.Texts = "Descripción";
                }

            }
        }

        private void textBox32_Load(object sender, EventArgs e)
        {

        }

        private void textBox33_Load(object sender, EventArgs e)
        {

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
                errorProvider1.SetError(textBox20, "Se necesita ingresar el expediente correspondiente");
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
                errorProvider1.SetError(textBox18, "Se necesita ingresar el RFC");
                textBox18.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox18, String.Empty);

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
                textBox8.Texts = "Acto" ;
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
                errorProvider1.SetError(textBox4, String.Empty);

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
                errorProvider1.SetError(textBox3, "Se necesita ingresar el apellidodel responsable de la sanción");
                textBox3.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textBox3, String.Empty);

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
                panel7.Visible = false;
            }
            else
            {
                panel7.Visible = true;
                panel6.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (modificar())
            {
                MessageBox.Show("La modificacion se ha realizado con exito");
                this.Close();
                form2Handler.ListaPS();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton3.Checked)
            {
                //panel8.Location = new Point(0,547);
                panel8.Top += 220;
            }
            else
            {
                //panel8.Location = new Point(0, 321);
                //panel8.Location = p1;
                panel8.Top -= 220;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                panel6.Visible = false;
            }
            else
            {
                panel6.Visible = true;
                panel7.Visible = false;
            }
        }

        private void modPS_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn Ver = new DataGridViewButtonColumn();
            Ver.HeaderText = "quitar";
            Ver.Name = "quitar";
            Ver.Width = 108;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "quitar")
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (!(dataGridView1.CurrentRow.Cells["n"].Value.ToString() == "0"))
                    {
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow); //Se elimina la fila seleccionada del DataGridView.
                        //p++;
                    }
                }
            }
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
            lMunicipio = new controladorMunicipio().obtenerListaMunicipio(ef.id);
            comboBox4.DataSource = lMunicipio;
            comboBox4.ValueMember = "name";
            
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            modeloMunicipio mp = (modeloMunicipio)comboBox4.SelectedItem;
            lLocalidad = new controladorLocalidad().obtenerListaLocalidad(mp.id);
            comboBox5.DataSource = lLocalidad;
            comboBox5.ValueMember = "name";
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            modeloLocalidad lc = (modeloLocalidad)comboBox5.SelectedItem;
            lVialidad = new controladorVialidad().obtenerListaVialidad(lc.id);
            comboBox6.DataSource = lVialidad;
            comboBox6.ValueMember = "name";
        }

        private void dateTimePicker3_Enter(object sender, EventArgs e)
        {
            errorProvider1.SetError(dateTimePicker3, String.Empty);
        }

        private void dateTimePicker4_CloseUp(object sender, EventArgs e)
        {
            /*CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime result;
            String format = "ddd dd MMM yyyy";
            result = DateTime.ParseExact(dateTimePicker4.Text, format, provider);
            textBox14.Texts = result.ToString();*/
            textBox14.Texts = dateTimePicker4.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                        else
                        {
                            if (f4 == null)
                            {
                                errorProvider1.SetError(dateTimePicker3, "Se necesita introducir una fecha válida");
                            }
                            else
                            {
                                modeloTipoDocumento dc = (modeloTipoDocumento)comboBox8.SelectedItem;
                                dataGridView2.Rows.Add(Convert.ToString(dc.Id),"1", textBox45.Texts, comboBox8.Text, textBox46.Texts, textBox44.Texts, dateTimePicker3.Text);
                                textBox45.Texts = "Título*";
                                textBox46.Texts = "Descripción*";
                                textBox44.Texts = "URL*";
                                dateTimePicker3.Value = new DateTime(2000, 01, 01);
                            }
                        }
                    }
                }
            }
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            //textBox14.Texts = dateTimePicker4.Value.ToString();
            //textBox14.Texts = (DateTime.ParseExact(dateTimePicker4.ToString(), "dd", null)).ToString();
        }

        //funcion para cargar la lista de usuarios al combobox
        private void llenarCombos()
        {
            //
            //comboBox1.DataSource = new controladorMoneda().obtenerListaMonedasPS();
            comboBox1.DataSource = lMoneda;
            comboBox1.ValueMember = "valor";

            //5doc 6san
            comboBox8.DataSource = lDocumentos;
            comboBox8.ValueMember = "tipoDocumento";

            //
            comboBox2.DataSource = lSancion;
            comboBox2.ValueMember = "valor";
           
            comboBox3.DataSource = lentidad;
            comboBox3.ValueMember = "name";
           


            comboBox7.DataSource = lPais;
            comboBox7.ValueMember = "name";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            form2Handler.ListaPS();
        }

        private void CargarDG()
        {

            dataGridView1.Columns[2].Width = 500;
            dataGridView1.Columns[3].Width = 500;

            dataGridView2.Columns[2].Width = 184;
            dataGridView2.Columns[3].Width = 186;
            dataGridView2.Columns[4].Width = 204;
            dataGridView2.Columns[5].Width = 239;
            dataGridView2.Columns[6].Width = 184;
        }

        private void cargarDatos()
        {
            modeloPS mps = new modeloPS();
            mps = conPS.CsdsdargarPS(idPs);

            textBox20.Texts = mps.expediente;
            textBox19.Texts = mps.nombreRazonSocial;
            textBox18.Texts = mps.rfcPS;
            textBox17.Texts = mps.causaMotivoHechos;
            if (mps.acto == null)
            {

            }
            else
            {
                textBox8.Texts = mps.acto;
            }
            if (mps.objetoContrato == null)
            {

            }
            else
            {
                textBox16.Texts = mps.objetoContrato;
            }
            textBox12.Texts = mps.tipoFalta;
            textBox7.Texts = mps.nombreInstitucionDependencia;
            if (mps.siglasInstitucionDependencia == null)
            {

            }
            else
            {
                textBox9.Texts = mps.siglasInstitucionDependencia;
            }
            if (mps.claveInstitucionDependencia == null)
            {

            }
            else
            {
                textBox10.Texts = mps.claveInstitucionDependencia;
            }
            if (mps.observaciones == null)
            {

            }
            else
            {
                textBox11.Texts = mps.observaciones;
            }
            textBox5.Texts = mps.autoridadSancionadora;
            if (mps.sentidoResolucion == null)
            {

            }
            else
            {
                textBox6.Texts = mps.sentidoResolucion;
            }
            if (mps.urlResolucion == null)
            {

            }
            else
            {
                textBox13.Texts = mps.urlResolucion;
            }
            if (mps.fechaResolucion == null)
            {

            }
            else
            {
                dateTimePicker4.Value = DateTime.Parse(mps.fechaResolucion);
                
                String a = (dateTimePicker4.Value.ToString()).Remove(10, 15).Remove(0,6);
                String m = (dateTimePicker4.Value.ToString()).Remove(5, 20).Remove(0,3);
                String d = (dateTimePicker4.Value.ToString()).Remove(2, 23);
                String f = a+"-"+m+"-"+d;
                textBox14.Texts = f;
                //CultureInfo provider = CultureInfo.InvariantCulture;
                //DateTime d1 = DateTime.Parse(f);
                //DateTime dateTime = DateTime.ParseExact("23/09/2020", "yyyy MM dd", null);
                //textBox14.Texts = dateTime.ToString();
                //textBox14.Texts = DateTime.Parse(f).ToString();
                //textBox14.Texts = mps.fechaResolucion;
                //dateTimePicker4.Value = DateTime.ParseExact(mps.fechaResolucion, "yyyy-MM-dd",provider);

                //textBox14.Texts = (dateTimePicker4.Value.ToString()).Remove(10,15);  esto muestra la fecha solo falta formato
                //textBox14.Texts = dateTimePicker4.Text;
                //DateTime.ParseExact(mps.fechaResolucion, "yyyy-MM-dd");
                textBox14.ForeColor = Color.Black;  
            }
            textBox4.Texts = mps.nombreRS;
            textBox3.Texts = mps.primerApellidoRS;
            if (mps.segundoApellidoRS == null)
            {

            }
            else
            {
                textBox2.Texts = mps.segundoApellidoRS;
                textBox2.ForeColor = Color.Black;
            }
            if (mps.plazoInhabilitacion == null)
            {

            }
            else
            {
                textBox23.Texts = mps.plazoInhabilitacion;
                textBox23.ForeColor = Color.Black;
            }
            if (mps.fechaInicialInhabilitacion == null)
            {

            }
            else
            {
                dateTimePicker1.Value = DateTime.Parse(mps.fechaInicialInhabilitacion);
            }
            if (mps.fechaFinalInhabilitacion == null)
            {

            }
            else
            {
                dateTimePicker2.Value = DateTime.Parse(mps.fechaFinalInhabilitacion);
            }
            if (mps.monto == null)
            {

            }
            else
            {
                textBox24.Texts = Convert.ToString(mps.monto);
            }
            if (mps.moneda == null)
            {

            }
            else
            {
                comboBox1.SelectedItem = lMoneda[Convert.ToInt32(mps.moneda)];
            }
            if (mps.tipoPersona == null)
            {

            }
            else
            {
                comboBox9.Text = mps.tipoPersona;
            }
            if (mps.telefono == null)
            {

            }
            else
            {
                textBox26.Texts = mps.telefono;
                textBox26.ForeColor = Color.Black;
            }
            if (mps.objetoSocial == null)
            {

            }
            else
            {
                textBox25.Texts = mps.objetoSocial;
                textBox25.ForeColor = Color.Black;
            }
            if (mps.nombresDG == null)
            {

            }
            else
            {
                textBox31.Texts = mps.nombresDG;
                textBox31.ForeColor = Color.Black;
            }
            if (mps.primerApellidoDG == null)
            {

            }
            else
            {
                textBox30.Texts = mps.primerApellidoDG;
                textBox30.ForeColor = Color.Black;
            }
            if (mps.segundoApellidoDG == null)
            {

            }
            else
            {
                textBox29.Texts = mps.segundoApellidoDG;
                textBox29.ForeColor = Color.Black;
            }
            if (mps.curpDG == null)
            {

            }
            else
            {
                textBox28.Texts = mps.curpDG;
                textBox28.ForeColor = Color.Black;
            }
            if (mps.nombresAL == null)
            {

            }
            else
            {
                textBox35.Texts = mps.nombresAL;
                textBox35.ForeColor = Color.Black;
            }
            if (mps.primerApellidoAL == null)
            {

            }
            else
            {
                textBox32.Texts = mps.primerApellidoAL;
                textBox32.ForeColor = Color.Black;
            }
            if (mps.segundoApellidoAL == null)
            {

            }
            else
            {
                textBox27.Texts = mps.segundoApellidoAL;
                textBox27.ForeColor = Color.Black;
            }
            if (mps.curpAL == null)
            {

            }
            else
            {
                textBox15.Texts = mps.curpAL;
                textBox15.ForeColor = Color.Black;
            }
            //aqui va como cargar el radiobutton de direccion
            if (Convert.ToBoolean(mps.domMX))
            {
                radioButton1.Checked= true;
                radioButton2.Enabled= false;
                radioButton3.Enabled = false;

                //domicilio mexico combos 3,4,5,6
                if (mps.entidadFederativa == null)
                {

                }
                else
                {
                    comboBox3.SelectedItem = lentidad[Convert.ToInt32(mps.entidadFederativa)];
                }
                if (mps.municipio == null)
                {

                }
                else
                {
                    comboBox4.SelectedItem = lMunicipio[Convert.ToInt32(mps.municipio)];
                }
                if (mps.localidad == null)
                {

                }
                else
                {
                    comboBox5.SelectedItem = lLocalidad[Convert.ToInt32(mps.localidad)];
                }
                if (mps.vialidad == null)
                {

                }
                else
                {
                    comboBox6.SelectedItem = lVialidad[Convert.ToInt32(mps.vialidad)];
                }
                if (mps.codigoPostalMX == null)
                {

                }
                else
                {
                    textBox34.Texts = mps.codigoPostalMX;
                    textBox34.ForeColor = Color.Black;
                }
                if (mps.numeroExteriorMX == null)
                {

                }
                else
                {
                    textBox33.Texts = mps.numeroExteriorMX;
                    textBox33.ForeColor = Color.Black;
                }
                if (mps.numeroInteriorMX == null)
                {

                }
                else
                {
                    textBox36.Texts = mps.numeroInteriorMX;
                    textBox36.ForeColor = Color.Black;
                }
            }
            else if (Convert.ToBoolean(mps.domEX))
            {
                radioButton1.Enabled = false;
                radioButton2.Checked= true;
                radioButton3.Enabled = false;

                if (mps.calle == null)
                {

                }
                else
                {
                    textBox40.Texts = mps.calle;
                    textBox40.ForeColor = Color.Black;
                }
                if (mps.ciudadLocalidad == null)
                {

                }
                else
                {
                    textBox39.Texts = mps.ciudadLocalidad;
                    textBox39.ForeColor = Color.Black;
                }
                if (mps.estadoProvincia == null)
                {

                }
                else
                {
                    textBox38.Texts = mps.estadoProvincia;
                    textBox38.ForeColor = Color.Black;
                }
                if (mps.codigoPostalEX == null)
                {

                }
                else
                {
                    textBox37.Texts = mps.codigoPostalEX;
                    textBox37.ForeColor = Color.Black;
                }
                if (mps.numeroExteriorEX == null)
                {

                }
                else
                {
                    textBox41.Texts = mps.numeroExteriorEX;
                    textBox41.ForeColor = Color.Black;
                }
                if (mps.numeroInteriorEX == null)
                {

                }
                else
                {
                    textBox42.Texts = mps.numeroInteriorEX;
                    textBox42.ForeColor = Color.Black;
                }
                //cargar pais domicilio extranjero combo 7
                if (mps.paisEX == null)
                {

                }
                else
                {
                    comboBox7.SelectedItem = lPais[Convert.ToInt32(mps.paisEX)];
                }
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Checked= true;
            }
           
            
            
           
            List<modeloTipoSancion> listaSancionesPS = new List<modeloTipoSancion>();
            listaSancionesPS = conPS.obtenerSancionesPS(idPs);
            for (var i =0; i<listaSancionesPS.Count; i++)
            {
                dataGridView1.Rows.Add(listaSancionesPS[i].id,"0", listaSancionesPS[i].valor, listaSancionesPS[i].descripcion);

            }
            List<modeloTipoDocumento> listaDocsPS = new List<modeloTipoDocumento>();
            listaDocsPS = conPS.obtenerDocumentosPS(idPs);
            for (var i = 0; i < listaDocsPS.Count; i++)
            {
                String a = (listaDocsPS[i].fechaDocumento).Remove(10, 15).Remove(0, 6);
                String m = (listaDocsPS[i].fechaDocumento).Remove(5, 20).Remove(0, 3);
                String d = (listaDocsPS[i].fechaDocumento).Remove(2, 23);
                String f = a + "-" + m + "-" + d;
                dataGridView2.Rows.Add(listaDocsPS[i].Id, "0", listaDocsPS[i].tituloDocumento, listaDocsPS[i].tipoDocumento, listaDocsPS[i].descripcionDocumento, listaDocsPS[i].urlDocumento, f);

            }

        }

        private bool modificar()
        {
            bool r = false;
            if (textBox17.Texts == "Causa, motivo o hechos*" || textBox12.Texts == "Tipo falta*" || textBox7.Texts == "Nombre(s)*" || textBox5.Texts == "Autoridad sancionadora*" || textBox4.Texts == "Nombre(s)*" || textBox3.Texts == "Primer apellido*" || comboBox9.Text == "Tipo persona*" || textBox19.Texts == "Nombre(s)/Razón Social*" || textBox18.Texts == "RFC*" || textBox20.Texts == "Expediente*")
            {
                MessageBox.Show("Debe completar los campos obligatorios para poder hacer el registro");

            }
            else
            {
                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("Necesita asignar al menos una sanción al registro");
                }
                else
                {
                    if (dateTimePicker4.Text == "2000-01-01")
                    {
                        f1 = null;
                    }
                    else
                    {
                        f1 = textBox14.Texts;
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
                            modPS.codigoPostalMX = textBox34.Texts;
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
                    if (textBox20.Texts == "Expediente*")
                    {

                    }
                    else
                    {
                        modPS.expediente = textBox20.Texts;
                    }
                    if (textBox18.Texts == "RFC*")
                    {

                    }
                    else
                    {
                        modPS.rfcPS = textBox18.Texts;
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
                        modPS.segundoApellidoRS = textBox2.Texts;
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
                        modPS.telefono = textBox26.Texts;
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
                        modPS.nombresDG = textBox31.Texts;
                    }
                    if (textBox30.Texts == "Primer apellido")
                    {

                    }
                    else
                    {
                        modPS.primerApellidoDG = textBox30.Texts;
                    }
                    if (textBox29.Texts == "Segundo apellido")
                    {

                    }
                    else
                    {
                        modPS.segundoApellidoDG = textBox29.Texts;
                    }
                    if (textBox28.Texts == "CURP")
                    {

                    }
                    else
                    {
                        modPS.curpDG = textBox28.Texts;
                    }
                    if (textBox35.Texts == "Nombre(s)")
                    {

                    }
                    else
                    {
                        modPS.nombresAL = textBox35.Texts;
                    }
                    if (textBox32.Texts == "Primer apellido")
                    {

                    }
                    else
                    {
                        modPS.primerApellidoAL = textBox32.Texts;
                    }
                    if (textBox27.Texts == "Segundo apellido")
                    {

                    }
                    else
                    {
                        modPS.segundoApellidoAL = textBox27.Texts;
                    }
                    if (textBox15.Texts == "CURP")
                    {

                    }
                    else
                    {
                        modPS.curpAL = textBox15.Texts;
                    }
                    modPS.causaMotivoHechos = textBox17.Texts;
                    modPS.tipoFalta = textBox12.Texts;
                    modPS.nombreInstitucionDependencia = textBox7.Texts;
                    modPS.autoridadSancionadora = textBox5.Texts;
                    modPS.nombreRS = textBox4.Texts;
                    modPS.primerApellidoRS = textBox3.Texts;
                    modPS.tipoPersona = comboBox9.Text;
                    modPS.nombreRazonSocial = textBox19.Texts;

                    modPS.fechaResolucion = f1;
                    modPS.fechaInicialInhabilitacion = f2;
                    modPS.fechaFinalInhabilitacion = f3;

                    if (conPS.modificarPS(modPS, idPs)){ r = true ; } else { r = false ; }

                    foreach (DataGridViewRow fila in dataGridView1.Rows)
                    {
                        if (!(fila.Cells["n"].Value.ToString() == "0"))
                        {
                            if (conPS.agregarSancionPS(Convert.ToInt16(fila.Cells["ID"].Value), Convert.ToString(fila.Cells["Descripcion"].Value), idPs)){ r = true; } else { r = false ; }
                        }

                    }

                    foreach (DataGridViewRow fila2 in dataGridView2.Rows)
                    {
                        if (!(fila2.Cells["n2"].Value.ToString() == "0"))
                        {
                            if (conPS.agregarDocumentoPS(Convert.ToInt16(fila2.Cells["idxd"].Value), Convert.ToString(fila2.Cells["Titulo"].Value), Convert.ToString(fila2.Cells["descripcionxd"].Value), Convert.ToString(fila2.Cells["URL"].Value), Convert.ToString(fila2.Cells["Fecha"].Value), idPs)) { r = true; } else { r = false; }
                        }

                    }

                }
            }
            return r;
        }
    }
}
