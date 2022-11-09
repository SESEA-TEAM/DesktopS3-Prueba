using Microsoft.VisualBasic.Logging;
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

namespace Sistema_de_sanciones
{
    public partial class Crear_Proveedores : Form
    {
        Controlador_Proveedor objp = new Controlador_Proveedor();

        private Proveedores proveedores = new Proveedores();
        public Crear_Proveedores()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textProveedor.Texts == "Proveedor*")
            {
                textProveedor.Texts = "";
                textProveedor.ForeColor = Color.Gray;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (textProveedor.Texts == "")
            {
                textProveedor.Texts = "Proveedor*";
                errorProvider1.SetError(textProveedor, "Se necesita ingresar un proveedor");
                textProveedor.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textProveedor, String.Empty);

            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            proveedores.textBoxEvent.textKeyPress(e);

        }

        private void limpiar()
        {
            textProveedor.Texts = "Proveedor*";
            textProveedor.ForeColor = Color.Gray;

            comboSistema.Text = "Selecciona los sistemas aplicables";
          
        }




        private void Guardar_Click(object sender, EventArgs e)
        {
          
            if(textProveedor.Texts == "Proveedor*" || comboSistema.Text == "Sistemas aplicable*")
            {
                errorProvider1.SetError(comboSistema, "Selecciona los sistemas aplicables");
                MessageBox.Show("Hay datos que aun no se han proporcionado");   
            }
            else
            {

                objp.InsertarProveedor(textProveedor.Texts, comboSistema.SelectedItem.ToString());
                MessageBox.Show("Registro Guardado");
                limpiar();
                errorProvider1.Clear();
            }
        }
    }
}
