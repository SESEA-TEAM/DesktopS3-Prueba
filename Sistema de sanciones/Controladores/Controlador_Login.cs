using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sistema_de_sanciones.ConexionBD;
using System.Data;
using System.Xml.Linq;
using System.Security.Cryptography.Xml;

namespace Sistema_de_sanciones.Controladores
{
    public class Controlador_Login
    {
        //realiza la conexión a la base de datos 
        private Conexion ConexionBD = new Conexion();

        //método el cual inserta a la base de datos la contraseña encriptada en sha256
        public void Insertar()

        {
            try
            {
               
                string cadenaEncriptada = Encrypt.GetSHA256("12345");
                
                var comando = new SqlCommand();
                comando.Connection = ConexionBD.AbrirConexion();
                string cadena = "insert into contrasena(contrasena) values ('" + cadenaEncriptada + "')";
                comando.CommandText = cadena;      
                comando.ExecuteNonQuery();
                ConexionBD.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
            }
       
        }

    }

}
