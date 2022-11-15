using Sistema_de_sanciones.ConexionBD;
using Sistema_de_sanciones.Controladores;
using Sistema_de_sanciones.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Sistema_de_sanciones
{
    public partial class Crear_Usuarios : Form
    {
        Controlador_Usuario objp = new Controlador_Usuario(); //Creo un nuevo objeto para llamar la clase de usuarios.

        DataSet dsTabla;

        private Conexion ConexionBD = new Conexion();
        private SqlDataReader LeerFilas;
        private Usuarios usuarios = new Usuarios();

        public Crear_Usuarios()
        {
            InitializeComponent();
            listarProveedor();
            listarPerfil();
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
                errorProvider1.SetError(txtNombres, "Se necesita ingresar un nombre");
                txtNombres.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(txtNombres,String.Empty);
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.textKeyPress(e);
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
                errorProvider1.SetError(textPApellido, "Se necesita ingresar el Primer Apellido");
                textPApellido.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textPApellido, String.Empty);
            }
        }

        private void textPApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.textKeyPress(e) ;
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

        private void textSApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.textKeyPress(e);
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
                errorProvider1.SetError(textCargo, "Se necesita ingresar el Cargo");
                textCargo.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textCargo, String.Empty);
            }
        }

        private void textCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.textKeyPress(e);
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

            string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            bool isEmailValid = Regex.IsMatch(textCorreo.Texts, emailPattern);
            
            if (!isEmailValid)
            {
                errorProvider1.SetError(textCorreo, "Correo no valido");
            }
            else
            {
                errorProvider1.SetError(textCorreo, String.Empty);
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
                errorProvider1.SetError(textTelefono, "Se necesita ingresar el Teléfono");
                textTelefono.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textTelefono, String.Empty);
            }

        }

        private void textTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.validarNumeros(e);
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

        private void textExtension_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.validarNumeros(e);
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
                errorProvider1.SetError(textUser, "Se necesita ingresar el Nombre de Usuario");
                textUser.ForeColor = Color.Gray;
            }
            else
            {
                errorProvider1.SetError(textUser, String.Empty);
            }
        }

        private void textUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            usuarios.textBoxEvent.textKeyPress(e);
        }

        private void limpiar()
        {
            txtNombres.Texts = "Nombres *";
            txtNombres.ForeColor = Color.Gray;
            //Limpiar primer apellido y aplicar color del Texto.
            textPApellido.Texts = "Primer Apellido *";
            textPApellido.ForeColor = Color.Gray;
            // Limpiar segundo apellido y aplicar color del Texto.
            textSApellido.Texts = "Segundo Apellido";
            textSApellido.ForeColor = Color.Gray;
            // Limpiar cargo y aplicar color del Texto.
            textCargo.Texts = "Cargo *";
            textCargo.ForeColor = Color.Gray;
            // Limpiar teléfono y aplicar color del Texto.
            textTelefono.Texts = "Número de teléfono *";
            textTelefono.ForeColor = Color.Gray;
            //Limpiar Correo eléctronico y aplicar color del texto
            textCorreo.Texts = "Correo eléctronico *";
            textCorreo.ForeColor = Color.Gray;
            //Limpiar Extensión y aplicar color del texto
            textExtension.Texts = "Extensión";
            textExtension.ForeColor = Color.Gray;
            //Limpiar Usuario y aplicar color del texto
            textUser.Texts = "Nombre de Usuario *";
            textUser.ForeColor = Color.Gray;
            //Limpiar Contraseña y aplica color del texto
            textContraseña.Texts = "";
            textContraseña.ForeColor = Color.Gray;
            //Limpiar tetxBox Confirmar Contraseña y aplica color al texto
            textConfirmarContra.Texts = "";
            textConfirmarContra.ForeColor = Color.Gray;

            comboProveedor.Text = "Proveedor";
        }

        private void listarProveedor()
        {
            comboProveedor.DataSource = new Controlador_Usuario().obtenerListaProveedor();
            comboProveedor.ValueMember = "proveedor";
        }


        private void listarPerfil()
        {
            comboPerfil.DataSource = new Controlador_Usuario().obtenerPerfil();
            comboPerfil.ValueMember = "cargo";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            bool isEmailValid = Regex.IsMatch(textCorreo.Texts, emailPattern);

            if (!isEmailValid || txtNombres.Texts == "Nombres *" || textPApellido.Texts == "Primer Apellido *" ||
                            textCargo.Texts == "Cargo *" || textCorreo.Texts == "Correo eléctronico *" ||
                            textTelefono.Texts == "Número de télefono *" || textUser.Texts == "Nombre de Usuario *" || comboProveedor.Text == "Proveedor" || textContraseña.Texts == "" || textConfirmarContra.Texts == "" )
            {
                MessageBox.Show("Hay datos que aun no se han proporcionado");
            }
            else if (textTelefono.Texts.Length < 10 || textTelefono.Texts.Length > 10)
            {
                errorProvider1.SetError(textTelefono, "El número de telefono debe de tener 10 Digitos");
            }
            else if (!usuarios.textBoxEvent.validadContrasena(textContraseña.Texts) || !usuarios.textBoxEvent.validadContrasena(textConfirmarContra.Texts))
            {
                errorProvider1.SetError(textContraseña, "Ingrese una contraseña valida");
                errorProvider1.SetError(textConfirmarContra, "Ingrese una contraseña valida");
            }
            else if (!textContraseña.Texts.Equals(textConfirmarContra.Texts))
            {
                errorProvider1.SetError(textContraseña, "Las contraseña no coinciden");
                errorProvider1.SetError(textConfirmarContra, "Las contraseña no coinciden");
            }
            else
            {
                modeloListaProveedores user = (modeloListaProveedores)comboProveedor.SelectedItem;
                int us = Convert.ToInt32(user.id);

                modeloPerfil perfil = (modeloPerfil)comboPerfil.SelectedItem;
                int sus = Convert.ToInt32(perfil.id);

                string cadenaEncriptada = Encrypt.GetSHA256(textContraseña.Texts.Trim());
                objp.InsertarUsuario(txtNombres.Texts, textPApellido.Texts, textSApellido.Texts, textCargo.Texts, textCorreo.Texts,
                textTelefono.Texts, textExtension.Texts, textUser.Texts, us, sus, cadenaEncriptada);

                MessageBox.Show("Registro Insertado");
                limpiar();
                pbOcultar.ResetText();
;                errorProvider1.Clear();
            }   
            
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbMostrar_Click(object sender, EventArgs e)
        {
            pbOcultar.BringToFront();
            textContraseña.PasswordChar = false;
        }

        private void pbOcultar_Click(object sender, EventArgs e)
        {
            pbMostrar.BringToFront();
            textContraseña.PasswordChar = true;
        }

        private void pbMostrar1_Click(object sender, EventArgs e)
        {
            pbOcultar1.BringToFront();
            textConfirmarContra.PasswordChar = false;
        }

        private void pbOcultar1_Click(object sender, EventArgs e)
        {
            pbMostrar1.BringToFront();
            textConfirmarContra.PasswordChar = true;
        }


    }
}
