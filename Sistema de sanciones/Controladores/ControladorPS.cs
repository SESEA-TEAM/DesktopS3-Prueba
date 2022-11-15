using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_sanciones.ConexionBD;
using Sistema_de_sanciones.Modelo;

namespace Sistema_de_sanciones.Controladores
{
    internal class controladorPS
    {

        private Conexion ConexionBD = new Conexion();

        private int inicio2;
        private int final2;
        private int total;
        public int Inicio2 { get => inicio2; set => inicio2 = value; }
        public int Final2 { get => final2; set => final2 = value; }
        public int Total { get => total; set => total = value; }

        public DataSet BarraListadoPS(String Expediente, String InstitucionDependencia, String NombreRazonSocial, String TipoPersona, String TipoSancion,
            String FechaActualizacion, String Inhabilitacion)
        {

            try
            {

                DataSet dt = new DataSet();

                SqlCommand comando = new SqlCommand("BarraListadoPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@expediente", Expediente);
                comando.Parameters.AddWithValue("@institucionDependencia", InstitucionDependencia);
                comando.Parameters.AddWithValue("@nombreRazonSocial", NombreRazonSocial);
                comando.Parameters.AddWithValue("@fechaActualizacion", FechaActualizacion);
                comando.Parameters.AddWithValue("@tipoPersona", TipoPersona);
                comando.Parameters.AddWithValue("@tipoSancion", TipoSancion);
                comando.Parameters.AddWithValue("@inhabilitacion", Inhabilitacion);
                comando.Parameters.AddWithValue("@InicioTablaListadoPS", Inicio2);
                comando.Parameters.AddWithValue("@FinalTablaListadoPS", Final2);
                SqlDataAdapter da = new SqlDataAdapter(comando);


                da.Fill(dt);
                return dt;
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.ToString());

                ConexionBD.CerrarConexionPS();
                return null;
            }

        }
        public int UltimoBarraListadoPS(String Expediente, String InstitucionDependencia, String NombreRazonSocial, String TipoPersona, String TipoSancion,
            String FechaActualizacion, String Inhabilitacion)
        {

            try
            {

                SqlCommand comando = new SqlCommand("UltimoBarraListadoPS");
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter retorno = new SqlParameter();
                comando.Parameters.AddWithValue("@expediente", Expediente);
                comando.Parameters.AddWithValue("@institucionDependencia", InstitucionDependencia);
                comando.Parameters.AddWithValue("@nombreRazonSocial", NombreRazonSocial);
                comando.Parameters.AddWithValue("@tipoPersona", TipoPersona);
                comando.Parameters.AddWithValue("@tipoSancion", TipoSancion);
                comando.Parameters.AddWithValue("@fechaActualizacion", FechaActualizacion);
                comando.Parameters.AddWithValue("@inhabilitacion", Inhabilitacion);

                comando.Connection = ConexionBD.AbrirConexionPS();

                var returnParameter = comando.Parameters.Add("@Total", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;


                comando.ExecuteNonQuery();
                comando.Dispose();

                var result = returnParameter.Value;
                comando.Connection = ConexionBD.CerrarConexionPS();
                return Convert.ToInt32(result);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.ToString());

                ConexionBD.CerrarConexionPS();
                return 0;
            }

        }



    }
}
