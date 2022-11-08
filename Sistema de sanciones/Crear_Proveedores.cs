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
      
        public Crear_Proveedores()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textProveedor.Texts == "Proveedor*")
            {
                textProveedor.Texts = "";
                textProveedor.ForeColor = Color.Black;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textProveedor.Texts == "")
            {
                textProveedor.Texts = "Proveedor*";
                textProveedor.ForeColor = Color.Black;

            }
        }

      

        private void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                objp.InsertarProveedor(textProveedor.Texts, comboSistema.SelectedItem.ToString()) ;
                MessageBox.Show("Registro Guardado");

             
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
