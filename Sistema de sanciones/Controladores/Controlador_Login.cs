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
        //Se realila la conexion a la baase de datos 
        private Conexion ConexionBD = new Conexion();

        //metodo el cual inserta a la base de datos la contraseña encriptada en sha256
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
            /*SqlCommand comando = new SqlCommand(cadena, conexion)
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandText = @"INSERT INTO contrasena
                                         (contrasena)
                                    VALUES ('@Constrasena')";

            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@Constrasena", contrasena);
          */
        }

        
        /*
        public void logear(string usuario, string contrasena)

               {
            try
            {
                
                SqlCommand comando = new SqlCommand("login");
                comando.Connection = ConexionBD.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Contrasena", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                if (dt.Rows.Count == 1)
                {
                    
                    if (dt.Rows[0][1].ToString() == "Administrador")
                    {
                        new Form1(dt.Rows[0][0].ToString()).Show();
                        
                    }
                    else if(dt.Rows[0][1].ToString() == "Capturador")
                    {
                        new Form2(dt.Rows[0][0].ToString()).Show();
                    }
                }else
                {
                    MessageBox.Show("Usuario y/o Contraseña Incorrecta");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                 ConexionBD.CerrarConexion();
                

            }
        }
        */
        

    }

}
