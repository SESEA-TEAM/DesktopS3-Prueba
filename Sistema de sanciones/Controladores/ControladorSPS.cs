using Sistema_de_sanciones.ConexionBD;
using Sistema_de_sanciones.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_sanciones.Controladores
{
    internal class controladorSPS
    {
        private Conexion ConexionBD = new Conexion();

        private int inicio2;
        private int final2;
        private int total;


        public int Inicio2 { get => inicio2; set => inicio2 = value; }
        public int Final2 { get => final2; set => final2 = value; }
        public int Total { get => total; set => total = value; }



        public DataSet BarraListadoSPS(String Expediente, String InstitucionDependencia, String Nombre, String PrimerApellido,
            String SegundoApellido, String TipoSancion, String FechaActualizacion,  String Inhabilitacion)
        {
            DataSet dt = new DataSet();

            SqlCommand comando = new SqlCommand("BarraListadoSPS");
            comando.Connection = ConexionBD.AbrirConexionSPS();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@expediente", Expediente);
            comando.Parameters.AddWithValue("@institucionDependencia", InstitucionDependencia);
            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@primerApellido", PrimerApellido);
            comando.Parameters.AddWithValue("@segundoApellido", SegundoApellido);
            comando.Parameters.AddWithValue("@tipoSancion", TipoSancion);
            comando.Parameters.AddWithValue("@fechaActualizacion", FechaActualizacion);
            comando.Parameters.AddWithValue("@inhabilitacion", Inhabilitacion);
            comando.Parameters.AddWithValue("@inicioTablaListadoSPS", Inicio2);
            comando.Parameters.AddWithValue("@finalTablaListadoSPS", Final2);
            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);
            return dt;
        }
        public int UltimoBarraListadoSPS(String Expediente, String InstitucionDependencia, String Nombre, String PrimerApellido,
            String SegundoApellido, String TipoSancion, String FechaActualizacion, String Inhabilitacion)
        {
            try
            {


                SqlCommand comando = new SqlCommand("UltimoBarraListadoSPS");
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter retorno = new SqlParameter();
                comando.Parameters.AddWithValue("@expediente", Expediente);
                comando.Parameters.AddWithValue("@institucionDependencia", InstitucionDependencia);
                comando.Parameters.AddWithValue("@nombre", Nombre);
                comando.Parameters.AddWithValue("@primerApellido", PrimerApellido);
                comando.Parameters.AddWithValue("@segundoApellido", SegundoApellido);
                comando.Parameters.AddWithValue("@tipoSancion", TipoSancion);
                comando.Parameters.AddWithValue("@fechaActualizacion", FechaActualizacion);
                comando.Parameters.AddWithValue("@inhabilitacion", Inhabilitacion);
                

                comando.Connection = ConexionBD.AbrirConexionSPS();

                var returnParameter = comando.Parameters.Add("@Total", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;


                comando.ExecuteNonQuery();
                comando.Dispose();

                var result = returnParameter.Value;
                comando.Connection = ConexionBD.CerrarConexionSPS();
                return Convert.ToInt32(result);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.ToString());

                ConexionBD.CerrarConexionSPS();
                return 0;
            }
        }
    }
}
