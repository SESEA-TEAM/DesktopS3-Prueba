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
    public partial class Editar_Usuarios : Form
    {

        Controlador_Usuario objp = new Controlador_Usuario();

        public Editar_Usuarios()
        {
            InitializeComponent();
        }

        Listar_Usuarios objProducto = new Listar_Usuarios();
        string operacion = "Insertar";
        public string id;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {


            }
        }
    }
}
