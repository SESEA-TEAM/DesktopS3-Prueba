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

        //Controlador_Login objp = new Controlador_Login();
        //se manda a lamar a la clase de conexion
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
        //cambia el color y regresa al valor por defecto en caso de estar vacio
        private void textBox2_Leave_1(object sender, EventArgs e)
        {
            if (textContrasena.Texts == "")
            {
                textContrasena.Texts = "Contraseña*";
                textContrasena.ForeColor = Color.Black;

            }
        }
        
        //procedimiento de logueo
        public void logear(string usuario, string contrasena)

        {
            try
            {
                //manda a llamar el procedimieto almacenado login que consulta si existen el usuario y la contraseña en la base de datos
                SqlCommand comando = new SqlCommand("login");
                comando.Connection = ConexionBD.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Contrasena", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Según corresponda su perfil en la B.D accederá a los módulos correspondientes.  
                //comprueba que haya habido una coincidencia en la base de datos
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
