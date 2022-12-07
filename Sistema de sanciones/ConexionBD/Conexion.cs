using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_sanciones.ConexionBD
{
    //conexiones a las 3 bases de datos.
    public class Conexion
    {
        private SqlConnection ConexionBD = new SqlConnection("Server=localhost;DataBase=Usuario; Integrated Security= true;");
        private SqlConnection ConexionBDSPS = new SqlConnection("Server=localhost;DataBase=PublicosSancionados; Integrated Security= true;");
        private SqlConnection ConexionBDPS = new SqlConnection("Server=localhost;DataBase=ParticularesSancionados; Integrated Security= true;");

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

        public SqlConnection AbrirConexionSPS()
        {
            if (ConexionBDSPS.State == ConnectionState.Closed)
                ConexionBDSPS.Open();
            return ConexionBDSPS;


        }

        public SqlConnection CerrarConexionSPS()
        {
            if (ConexionBDSPS.State == ConnectionState.Open)
                ConexionBDSPS.Close();
            return ConexionBDSPS;

        }

        public SqlConnection AbrirConexionPS()
        {
            if (ConexionBDPS.State == ConnectionState.Closed)
                ConexionBDPS.Open();
            return ConexionBDPS;


        }

        public SqlConnection CerrarConexionPS()
        {
            if (ConexionBDPS.State == ConnectionState.Open)
                ConexionBDPS.Close();
            return ConexionBDPS;

        }

    }
}
