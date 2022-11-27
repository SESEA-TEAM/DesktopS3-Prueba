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
    public class controladorVialidad
    {
        private Conexion ConexionBD = new Conexion();

        public List<modeloVialidad> obtenerListaVialidad(int localidad)
        {
            List<modeloVialidad> oListaMonedas = new List<modeloVialidad>();
            oListaMonedas.Add(new modeloVialidad { id = 0, name = "Vialidad" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarVialidad");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaMonedas.Add(new modeloVialidad
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["valor"])
                    });
                }
                dr.Close();
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
