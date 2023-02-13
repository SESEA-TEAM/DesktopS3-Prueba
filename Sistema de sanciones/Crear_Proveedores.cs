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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_de_sanciones
{
    public partial class Crear_Proveedores : Form
    {
        //Creo un nuevo objeto para llamar la clase de proveedor.
        Controlador_Proveedor objp = new Controlador_Proveedor();
        //manda a llamar al controlador proveedor
        private Proveedores proveedores = new Proveedores();
        public Crear_Proveedores()
        {   //inicializa los componentes del form
            InitializeComponent();
            //Asigna opciones a la lista desplegable
            List<string> lista = new List<string>();
            lista.Add("Selecciona los sistemas aplicables*");
            lista.Add("Sistema de los Servidores Públicos Sancionados");
            lista.Add("Sistema de los Particulares Sancionados");
            lista.Add("Sistema de los Servidores Públicos Sancionados, Sistema de los Particulares Sancionados");
            comboSistema.DataSource = lista;
        }
        //Cambia de color la palabra proveedor
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textProveedor.Texts == "Proveedor*")
            {
                textProveedor.Texts = "";
                textProveedor.ForeColor = Color.Black;

            }
        }
        //Cambia de color la palabra proveedor
        private void textBox1_Leave(object sender, EventArgs e)
        {

            if (textProveedor.Texts == "")
            {
                textProveedor.Texts = "Proveedor*";
                //Esta función indica si el campo esta vacío.
                errorProvider1.SetError(textProveedor, "Se necesita ingresar un proveedor");
                textProveedor.ForeColor = Color.Black;
            }
            else
            {
                errorProvider1.SetError(textProveedor, String.Empty);

            }
        }
        //permite controlar los mensajes del teclado en el nivel de formulario, antes de que los mensajes lleguen a un control.  
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            proveedores.textBoxEvent.textKeyPress(e);

        }
        // limpia el campo proveedor 
        private void limpiar()
        {
            textProveedor.Texts = "Proveedor*";
            textProveedor.ForeColor = Color.Black;

            comboSistema.Text = "Selecciona los sistemas aplicables*";
          
        }



        //Guarda la información del proveedor y sistema aplicable 
        private void Guardar_Click(object sender, EventArgs e)
        {
             //El usuario tiene que dar estos datos de lo contrario marcaría que faltan datos. 
            if(textProveedor.Texts == "Proveedor*" || comboSistema.Text == "Selecciona los sistemas aplicables*")
            {
                errorProvider1.SetError(comboSistema, "Selecciona los sistemas aplicables");
                MessageBox.Show("Hay datos que aún no se han proporcionado");   
            }
            else
            {
                //si el usuario inserta los datos, mandamos a llamar al procedimiento almacenado para que inserte los datos en la B.D
                objp.InsertarProveedor(textProveedor.Texts, comboSistema.SelectedItem.ToString());
               //Mensaje de registro guradado 
                MessageBox.Show("Registro Guardado");
                //manda a llamar a la función limpiar los campos 
                limpiar();
                //limpia los errrores de campos vacíos 
                errorProvider1.Clear();
            }
        }
    }
}
