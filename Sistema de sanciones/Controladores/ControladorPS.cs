using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_sanciones.Controlador
{
    internal class ControladorPS
    {
        private int inicio2;
        private int final2;
        private int total;
        public int Inicio2 { get => inicio2; set => inicio2 = value; }
        public int Final2 { get => final2; set => final2 = value; }
        public int Total { get => total; set => total = value; }

        SqlConnection conexion = new SqlConnection("server=DESKTOP-CDKMLM6;integrated security=true; database=ParticularesSancionados");



        public DataSet BarraListadoPS()
        {
            SqlCommand comando = new SqlCommand("BarraListadoPS", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@InicioTablaListadoPS", Inicio2);
            comando.Parameters.AddWithValue("@FinalTablaListadoPS", Final2);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt;
        }
        public int UltimoBarraListadoPS()
        {
            SqlCommand comando = new SqlCommand("UltimoBarraListadoPS", conexion);
            comando.CommandType = CommandType.StoredProcedure;
            SqlParameter retorno = new SqlParameter();
            comando.Parameters.AddWithValue("@Total", Total);

            var returnParameter = comando.Parameters.Add("@Totale", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            var result = returnParameter.Value;
            return Convert.ToInt32(result);
        }
    }
}
