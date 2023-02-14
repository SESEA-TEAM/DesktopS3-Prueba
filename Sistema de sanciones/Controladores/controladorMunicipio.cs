using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_sanciones.ConexionBD;
using Sistema_de_sanciones.Modelo;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_de_sanciones.Controladores
{
    public class controladorMunicipio
    {
        private Conexion ConexionBD = new Conexion();

        //Este controaldor sirve para poder rellenar las listas de municipios, esto mediante el uso de un procedimiento almacenado
        //que hace una consulta a la base de datos.
        public List<modeloMunicipio> obtenerListaMunicipio(int entidad)
        {
            List<modeloMunicipio> oListaMonedas = new List<modeloMunicipio>();
            oListaMonedas.Add(new modeloMunicipio { id = 0, name = "Municipio" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarMunicipio");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@id", entidad);

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaMonedas.Add(new modeloMunicipio
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["valor"])
                    });
                }
                dr.Close();
                ConexionBD.CerrarConexionPS();

                return oListaMonedas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaMonedas;
            }


        }
    }
}
