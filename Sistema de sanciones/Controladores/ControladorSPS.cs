using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using Sistema_de_sanciones.Modelo;
using Microsoft.VisualBasic;
using Sistema_de_sanciones.ConexionDB;


namespace Sistema_de_sanciones.Controlador
{
    public class ControladorSPS
    {
        private Conexion ConexionSPS = new Conexion();

        private int inicio2;
        private int final2;
        private int total;
        //private string fechaActualizacion;
        // private string expediente;
        // private string institucionDependencia;
        //private string nombre;
        //private string primerApellido;
        //private string segundoApellido;
        //private string inhabilitacion;

        public int Inicio2 { get => inicio2; set => inicio2 = value; }
        public int Final2 { get => final2; set => final2 = value; }
        public int Total { get => total; set => total = value; }
        //public string FechaActualizacion { get => fechaActualizacion; set => fechaActualizacion = value; }
        // public string Expediente { get => expediente; set => expediente = value; }
        // public string InstitucionDependencia { get => institucionDependencia; set => institucionDependencia = value; }
        // public string Nombre { get => nombre; set => nombre = value; }
        // public string PrimerApellido { get => primerApellido; set => primerApellido = value; }
        // public string SegundoApellido { get => segundoApellido; set => segundoApellido = value; }
        //public string Inhabilitacion { get => inhabilitacion; set => inhabilitacion = value; }





        public DataSet BarraListadoSPS(String Expediente, String InstitucionDependencia, String Nombre, String PrimerApellido,
            String SegundoApellido, String FechaActualizacion, String Inhabilitacion)
        {
            DataSet dt = new DataSet();

            SqlCommand comando = new SqlCommand("BarraListadoSPS");
            comando.Connection = ConexionSPS.AbrirConexionSPS();
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@expediente", Expediente);
            comando.Parameters.AddWithValue("@institucionDependencia", InstitucionDependencia);
            comando.Parameters.AddWithValue("@nombre", Nombre);
            comando.Parameters.AddWithValue("@primerApellido", PrimerApellido);
            comando.Parameters.AddWithValue("@segundoApellido", SegundoApellido);
            comando.Parameters.AddWithValue("@fechaActualizacion", FechaActualizacion);
            comando.Parameters.AddWithValue("@inhabilitacion", Inhabilitacion);
            comando.Parameters.AddWithValue("@inicioTablaListadoSPS", Inicio2);
            comando.Parameters.AddWithValue("@finalTablaListadoSPS", Final2);
            SqlDataAdapter da = new SqlDataAdapter(comando);

            da.Fill(dt);
            return dt;
        }
        public int UltimoBarraListadoSPS(String Expediente, String InstitucionDependencia, String Nombre, String PrimerApellido,
            String SegundoApellido, String FechaActualizacion, String Inhabilitacion)
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
                comando.Parameters.AddWithValue("@fechaActualizacion", FechaActualizacion);
                comando.Parameters.AddWithValue("@inhabilitacion", Inhabilitacion);

                comando.Connection = ConexionSPS.AbrirConexionSPS();

                var returnParameter = comando.Parameters.Add("@Total", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;

                
                comando.ExecuteNonQuery();
                comando.Dispose();

                var result = returnParameter.Value;
                comando.Connection = ConexionSPS.CerrarConexionSPS();
                return Convert.ToInt32(result);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.ToString());
                
                ConexionSPS.CerrarConexionSPS();
                return 0;
            }
        }
    }
}
