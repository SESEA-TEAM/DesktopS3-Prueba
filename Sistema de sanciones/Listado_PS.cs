using Sistema_de_sanciones.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_sanciones
{
    public partial class Listado_PS : Form
    {
        ControladorPS objs = new ControladorPS();
        DataSet dsTable;
        int TotalDefinitivoFinal;
        public Listado_PS()
        {
            InitializeComponent();
            CargarDB();
        }

        private void CargarDB()
        {
            objs.Inicio2 = 1;
            objs.Final2 = 10;

            dsTable = objs.BarraListadoPS();
            dataGridView1.DataSource = dsTable.Tables[1];

            TotalDefinitivoFinal = objs.UltimoBarraListadoPS();

            botonAnterior.Enabled = false;

            label10.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2) + " de: " + TotalDefinitivoFinal.ToString();

        }

        public void contador()
        {
            label10.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2 - 1) + " de: " + TotalDefinitivoFinal.ToString();
        }

        private void Listado_PS_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            objs.Inicio2 = 1;

            if (TotalDefinitivoFinal < 10)
            {
                
                botonAnterior.Enabled = false;
                botonSiguiente.Enabled = false;
                objs.Final2 = TotalDefinitivoFinal;
            }
            else
            {
                objs.Final2 = 10;
            }

            botonSiguiente.Enabled = true;
            dsTable.Clear();
            dsTable = objs.BarraListadoPS();
            dataGridView1.DataSource = dsTable.Tables[1];
            botonAnterior.Enabled = false;

            label10.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2) + " de: " + TotalDefinitivoFinal.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            objs.Inicio2 = objs.Inicio2 - 10;
            objs.Final2 = objs.Inicio2 + 10;
            botonSiguiente.Enabled = true;
            if (objs.Inicio2 <= 1)
            {
                botonAnterior.Enabled = false;
            }
            dsTable.Clear();
            dsTable = objs.BarraListadoPS();
            dataGridView1.DataSource = dsTable.Tables[1];
            label10.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2 - 1) + " de: " + TotalDefinitivoFinal.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            objs.Inicio2 = objs.Inicio2 + 10;
            objs.Final2 = objs.Inicio2 + 10;
            if (objs.Final2 >= TotalDefinitivoFinal)
            {

                botonSiguiente.Enabled = false;
                botonAnterior.Enabled = true;
                dsTable.Clear();
                dsTable = objs.BarraListadoPS();
                dataGridView1.DataSource = dsTable.Tables[1];
                label10.Text = "Registros: " + objs.Inicio2 + " - " + TotalDefinitivoFinal + " de: " + TotalDefinitivoFinal.ToString();
            }
            else
            {

                objs.Final2 = objs.Inicio2 + 10;


                botonPrimero.Enabled = true;

                botonAnterior.Enabled = true;
                dsTable.Clear();
                dsTable = objs.BarraListadoPS();
                dataGridView1.DataSource = dsTable.Tables[1];

                label10.Text = "Registros: " + objs.Inicio2 + " - " + (objs.Final2 - 1) + " de: " + TotalDefinitivoFinal.ToString();
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (TotalDefinitivoFinal % 10 == 0)
            {
                objs.Inicio2 = TotalDefinitivoFinal - (TotalDefinitivoFinal % 10) + 1 - 10;
                objs.Final2 = objs.Inicio2 + 10;
                dsTable.Clear();
                dsTable = objs.BarraListadoPS();
                dataGridView1.DataSource = dsTable.Tables[1];
                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                botonSiguiente.Enabled = false;
            }
            else
            {
                objs.Inicio2 = TotalDefinitivoFinal - (TotalDefinitivoFinal % 10) + 1;
                objs.Final2 = objs.Inicio2 + 10;
                dsTable.Clear();
                dsTable = objs.BarraListadoPS();
                dataGridView1.DataSource = dsTable.Tables[1];
                botonPrimero.Enabled = true;
                botonAnterior.Enabled = true;
                botonSiguiente.Enabled = false;
            }
            label10.Text = "Registros: " + objs.Inicio2 + " - " + TotalDefinitivoFinal + " de: " + TotalDefinitivoFinal.ToString();
        }

    }
}
