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

        //Este controaldor sirve para poder rellenar las listas de vialidad, esto mediante el uso de un procedimiento almacenado
        //que hace una consulta a la base de datos.
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
