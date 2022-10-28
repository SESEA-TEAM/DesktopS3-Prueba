using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Sistema_de_sanciones.ConexionBD;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_de_sanciones.Controladores
{
    public class Controlador_Proveedor
    {
        private Conexion ConexionBD = new Conexion();
        private SqlDataReader LeerFilas;


        public DataTable ControladorProveedor()

        {

            DataTable Tabla = new DataTable();
            SqlCommand comando = new SqlCommand("seleccionar_proveedor");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            ConexionBD.CerrarConexion();
            return Tabla;



        }

        public void InsertarProveedor(string proveedor, string sistema)
        {

            SqlCommand comando = new SqlCommand("Insertar_proveedor");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Proveedor", proveedor);
            comando.Parameters.AddWithValue("@Sistema", sistema  );
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            ConexionBD.CerrarConexion();

        }

        public void EditarProveedor(int id, string proveedor, string sistema, string estatus )
        {

            SqlCommand comando = new SqlCommand("Editar_proveedor");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);
            comando.Parameters.AddWithValue("@Proveedor", proveedor);
            comando.Parameters.AddWithValue("@Sistema", sistema);
            comando.Parameters.AddWithValue("@Estatus", estatus);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            ConexionBD.CerrarConexion();

        }

        public void EliminarProveedor(int id)
        {

            SqlCommand comando = new SqlCommand("Eliminar_proveedor");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            ConexionBD.CerrarConexion();

        }



    }

}
