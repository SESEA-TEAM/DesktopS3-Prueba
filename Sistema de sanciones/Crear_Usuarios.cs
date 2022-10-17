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
    public partial class Crear_Usuarios : Form
    {
        public Crear_Usuarios()
        {
            InitializeComponent();
        }

        private void Crear_Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void txtNombres_Enter(object sender, EventArgs e)
        {
            if(txtNombres.Texts == "Nombres *")
            {
                txtNombres.Texts = "";
                txtNombres.ForeColor = Color.Black;

            }
            
        }

        private void txtNombres_Leave(object sender, EventArgs e)
        {
            if (txtNombres.Texts == "")
            {
                txtNombres.Texts = "Nombres *";
                txtNombres.ForeColor = Color.Gray;

            }
        }

        private void textPApellido_Enter(object sender, EventArgs e)
        {
            if(textPApellido.Texts == "Primer Apellido *")
            {
                textPApellido.Texts = "";
                textPApellido.ForeColor = Color.Black;
            }
        }

        private void textPApellido_Leave(object sender, EventArgs e)
        {
            if (textPApellido.Texts == "")
            {
                textPApellido.Texts = "Primer Apellido *";
                textPApellido.ForeColor = Color.Gray;
            }
        }

        private void textSApellido_Enter(object sender, EventArgs e)
        {
            if (textSApellido.Texts == "Segundo Apellido")
            {
                textSApellido.Texts = "";
                textSApellido.ForeColor = Color.Black;
            }
        }

        private void textSApellido_Leave(object sender, EventArgs e)
        {
            if (textSApellido.Texts == "")
            {
                textSApellido.Texts = "Segundo Apellido";
                textSApellido.ForeColor = Color.Gray;
            }
        }

        private void textCargo_Enter(object sender, EventArgs e)
        {
            if(textCargo.Texts == "Cargo *")
            {
                textCargo.Texts = "";
                textCargo.ForeColor = Color.Black;
            }
        }

        private void textCargo_Leave(object sender, EventArgs e)
        {
            if (textCargo.Texts == "")
            {
                textCargo.Texts = "Cargo *";
                textCargo.ForeColor = Color.Gray;
            }
        }

        private void textCorreo_Enter(object sender, EventArgs e)
        {
            if (textCorreo.Texts == "Correo eléctronico *")
            {
                textCorreo.Texts = "";
                textCorreo.ForeColor = Color.Black;
            }
        }

        private void textCorreo_Leave(object sender, EventArgs e)
        {
            if (textCorreo.Texts == "")
            {
                textCorreo.Texts = "Correo eléctronico *";
                textCorreo.ForeColor = Color.Gray;
            }
        }

        private void textTelefono_Enter(object sender, EventArgs e)
        {
            if (textTelefono.Texts == "Número de teléfono *")
            {
                textTelefono.Texts = "";
                textTelefono.ForeColor = Color.Black;
            }
        }

        private void textTelefono_Leave(object sender, EventArgs e)
        {
            if (textTelefono.Texts == "")
            {
                textTelefono.Texts = "Número de teléfono *";
                textTelefono.ForeColor = Color.Gray;
            }
        }

        private void textExtension_Enter(object sender, EventArgs e)
        {
            if (textExtension.Texts == "Extensión")
            {
                textExtension.Texts = "";
                textExtension.ForeColor = Color.Black;
            }
        }

        private void textExtension_Leave(object sender, EventArgs e)
        {
            if (textExtension.Texts == "")
            {
                textExtension.Texts = "Extensión";
                textExtension.ForeColor = Color.Gray;
            }
        }

        private void textUser_Enter(object sender, EventArgs e)
        {
            if (textUser.Texts == "Nombre de Usuario *")
            {
                textUser.Texts = "";
                textUser.ForeColor = Color.Black;
            }
        }

        private void textUser_Leave(object sender, EventArgs e)
        {
            if (textUser.Texts == "")
            {
                textUser.Texts = "Nombre de Usuario *";
                textUser.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
