using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Sistema_de_sanciones.ConexionBD;

namespace Sistema_de_sanciones.Controladores
{
    public class Controlador_Usuario
    {

        private Conexion ConexionBD = new Conexion();
        private SqlDataReader LeerFilas;

        public DataTable ControladorUsuario()
        {
            DataTable Tabla = new DataTable();
            SqlCommand comando = new SqlCommand("seleccionar_usuario");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            ConexionBD.CerrarConexion();
            return Tabla;
        }

        public void InsertarUsuario(string nombre, string apellidoUno, string apellidoDos, string cargo, string correoElectronico, string telefono, string extension, string usuario, string sistema)
        {

            SqlCommand comando = new SqlCommand("insertar_usuario");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@ApellidoUno", apellidoUno);
            comando.Parameters.AddWithValue("@ApellidoDos", apellidoDos);
            comando.Parameters.AddWithValue("@Cargo", cargo);
            comando.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
            comando.Parameters.AddWithValue("@Telefono", telefono);
            comando.Parameters.AddWithValue("@Extension", extension);
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Sistemas", sistema);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            ConexionBD.CerrarConexion();
        }

        public void EditarUsuario(string nombre, string apellidoUno, string apellidoDos, string cargo, string correoElectronico, string telefono, string extension, string usuario, string sistema, int estatus)
        {
            SqlCommand comando = new SqlCommand("Editar_proveedor");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@ApellidoUno", apellidoUno);
            comando.Parameters.AddWithValue("@ApellidoDos", apellidoDos);
            comando.Parameters.AddWithValue("@Cargo", cargo);
            comando.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
            comando.Parameters.AddWithValue("@Telefono", telefono);
            comando.Parameters.AddWithValue("@Extension", extension);
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Sistemas", sistema);
            comando.Parameters.AddWithValue("@Estatus", estatus);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            ConexionBD.CerrarConexion();
        }

        public void EliminarUsuario(int id)
        {
            SqlCommand comando = new SqlCommand("Eliminar_usuario");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);
            comando.ExecuteReader();
            comando.Parameters.Clear();
            ConexionBD.CerrarConexion();
        }


    }
     
}
