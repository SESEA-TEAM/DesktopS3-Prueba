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
using System.Security.Cryptography.Xml;
using System.Data.SqlClient;
using Sistema_de_sanciones.ConexionBD;
using System.Security.Cryptography.X509Certificates;

namespace Sistema_de_sanciones
{
    public partial class Login : Form
    {

        Controlador_Login objp = new Controlador_Login();
        private Conexion ConexionBD = new Conexion(); 
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        //cambia de color
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textUsuario.Texts == "Nombre de usuario*")
            {
                textUsuario.Texts = "";
                textUsuario.ForeColor = Color.Black;

            }
        }
        //cambia de color 
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textUsuario.Texts == "")
            {
                textUsuario.Texts = "Nombre de usuario*";
                textUsuario.ForeColor = Color.Black;

            }
        }
        //cambia de color
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textContrasena.Texts == "Contraseña*")
            {
                textContrasena.Texts = "";
                textContrasena.ForeColor = Color.Black;

            }
        }
        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (textContrasena.Texts == "")
            {
                textContrasena.Texts = "Contraseña*";
                textContrasena.ForeColor = Color.Black;

            }
        }
        
        public void logear(string usuario, string contrasena)

        {
            try
            {
                //manda a llamar el procedimieto almacenado login, compara la contraseña y el usuario
                SqlCommand comando = new SqlCommand("login");
                comando.Connection = ConexionBD.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Contrasena", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Según corresponda su perfil en la B.D accederá a los módulos correspondientes.  
                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    //this.Close();
                    if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        new Form2(this, dt.Rows[0][0].ToString(), 0, Convert.ToInt32(dt.Rows[0][2].ToString())).Show();

                    }
                    else if (dt.Rows[0][1].ToString() == "Capturador")
                    {
                        new Form2(this,dt.Rows[0][0].ToString(),1, Convert.ToInt32(dt.Rows[0][2].ToString())).Show();
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrecta");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                ConexionBD.CerrarConexion();


            }
        }
        //limpia los campos 
        private void limpiar()
        {
            textUsuario.Texts = "Nombre de usuario*";
            textUsuario.ForeColor = Color.Black;

            textContrasena.Texts = "Contraseña*";
            textContrasena.ForeColor = Color.Black;

        }
        private void buttonEntrar_Click(object sender, EventArgs e)
        {
        
            //manda a llamar el procedimiento almacenado logear, para verificar los campos correspondientes
            logear(textUsuario.Texts, Encrypt.GetSHA256(textContrasena.Texts.Trim()));
            limpiar();


        }
    }
}
