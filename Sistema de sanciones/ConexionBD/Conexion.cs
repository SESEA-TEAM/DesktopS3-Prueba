using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_sanciones.ConexionBD
{
    public class Conexion
    {
        private SqlConnection ConexionBD = new SqlConnection("Server=localhost;DataBase=Usuario; Integrated Security= true;");

        public SqlConnection AbrirConexion()
        {
            if (ConexionBD.State == ConnectionState.Closed)
                ConexionBD.Open();
            return ConexionBD;


        }

        public SqlConnection CerrarConexion()
        {
            if (ConexionBD.State == ConnectionState.Open)
                ConexionBD.Close();
            return ConexionBD;

        }

    }
}
