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
    public class Controlador_Proveedor
    {

        private Conexion ConexionBD = new Conexion();
        
        public DataSet ControladorProveedor()

        {
           
            SqlCommand comando = new SqlCommand("seleccionar_proveedor");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }

        public void InsertarProveedor(string proveedor, string sistema)
        {
            SqlCommand comando = new SqlCommand("Insertar_proveedor");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Proveedor", proveedor);
            comando.Parameters.AddWithValue("@Sistema", sistema);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void EliminarProveedor(int id)
        {
            SqlCommand comando = new SqlCommand("Eliminar_proveedor");
            comando.Connection = ConexionBD.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);
            comando.ExecuteReader();
            comando.Parameters.Clear();
        }

    }
}
