using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_sanciones.Modelo;
using Sistema_de_sanciones.ConexionBD;

namespace Sistema_de_sanciones.Controlador
{
    internal class ControladorListaTipoSancion
    {
        private Conexion ConexionBD = new Conexion();
        SqlConnection conexion = new SqlConnection("server=DESKTOP-CDKMLM6;integrated security=true; database=PublicosSancionados");

        public List<modeloTipoSancion> obtenerTipoSancion()
        {
            List<modeloTipoSancion> oTipoSancion = new List<modeloTipoSancion>();
            oTipoSancion.Add(new modeloTipoSancion { id = 0, valor = "Tipo Sancion" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarSancion");
                conexion.Open();

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oTipoSancion.Add(new modeloTipoSancion
                    {
                        id = Convert.ToInt32(dr["id"]),
                        valor = Convert.ToString(dr["valor"])
                    });
                }
                dr.Close();
                //ConexionBD.CerrarConexionSPS();
                //ConexionBD.CerrarConexionPS();
                return oTipoSancion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oTipoSancion;
            }


        }
    }
}
