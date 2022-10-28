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
    public partial class Editar_Proveedor : Form
    {

        Controlador_Proveedor objp = new Controlador_Proveedor();
        public Editar_Proveedor()
        {
            InitializeComponent();
        }

        Listar_Proveedores objProducto = new  Listar_Proveedores();
        string operacion ="Insertar";
        public string id;

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
                objp.EditarProveedor(Convert.ToInt32(id),textProveedor.Texts, comboSistema.SelectedItem.ToString(), comboEstatus.SelectedItem.ToString());
                MessageBox.Show("Registro Insertado");

            }
            catch (Exception ex)
            {


            }


        }
    }
}
