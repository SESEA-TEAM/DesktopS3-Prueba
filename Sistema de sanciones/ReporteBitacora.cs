using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Sistema_de_sanciones.Controladores;
using Sistema_de_sanciones.Modelo;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_de_sanciones
{   
    public partial class ReporteBitacora : Form
    {
        controladorBitacora contB = new controladorBitacora();
        //modeloListaUsuarios u = new modeloListaUsuarios();
        DataSet dsBit;
        String? fI = null;
        String? fF = null;
        String? sis = null;
        String? us = null;
        public ReporteBitacora()
        {
            InitializeComponent();
            
            //llama a carga de lista de usuarios
            listarUsuarios();

            //lista para combobox sistema aplicable
            List<string> lista = new List<string>();
            lista.Add("Sistema aplicable");
            lista.Add("Sistema de los Particulares Sancionados");
            lista.Add("Sistema de los Servidores Públicos Sancionados");
            comboBox1.DataSource = lista;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        //funcion para cargar la lista de usuarios al combobox
        private void listarUsuarios()
        {
            comboBox2.DataSource = new controladorListaUsusarios().obtenerListaUsuarios();
            comboBox2.ValueMember = "Usuario";

        }
        
        //funcion de carga, llamada al procedimiento que regresa un dataset con la consulta a la base de datos
        private void cargarBt()
        {
            fI = Convert.ToString(dateTimePicker1.Text)+".000";
            fF = Convert.ToString(dateTimePicker2.Text)+".000";
            if (comboBox1.Text== "Sistema aplicable")
            {

            }
            else
            {
                sis = comboBox1.Text;
            }
            if (comboBox2.Text == "Usuario")
            {

            }
            else
            {
                modeloListaUsuarios user = (modeloListaUsuarios)comboBox2.SelectedItem;
                us = Convert.ToString(user.Id);
            }
            dsBit = contB.reporteBitacora(fI,fF,sis,us);
            dataGridView1.DataSource = dsBit.Tables[0];
            dataGridView1.Columns[0].Width = 168;
            dataGridView1.Columns[1].Width = 350;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 250;
            //dataGridView1.Columns[5].Width = 184;
        }

        //resetea campos y las variables de busqueda
        private void limpiarBusqueda()
        {
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            comboBox1.SelectedItem = "Sistema aplicable";
            comboBox2.Text = "Usuario";
            sis = null;
            us = null;
        }

        private void textBox1_Load(object sender, EventArgs e)
        {

        }

        //boton de generar, toma los parametros de busqueda y manda a llamar a la funcion de carga
        private void button3_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            this.panel3.Visible = false;           
            cargarBt();
        }

        //llama al metodo para resetear los parametros de busqueda
        private void button4_Click(object sender, EventArgs e)
        {
            limpiarBusqueda();
        }

        //oculta el panel de datagridview y carga el panel de busqueda
        private void button1_Click(object sender, EventArgs e)
        {

            this.panel3.Visible = true;
            this.panel2.Visible = false;
            limpiarBusqueda();
        }

        //guarda el CSV mediante un explorador de archivos de windows
        private void button2_Click(object sender, EventArgs e)
        {
            //declara el filedialog
            using (var fd = new SaveFileDialog()) 
            {
                //en casi de dar aceptar
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    //genera el csv y lo guarda en la direccion dada por el filedialog
                    contB.aCSV(dataGridView1, @""+ fd.FileName+ ".csv");
                }
            }            
        }
    }
}