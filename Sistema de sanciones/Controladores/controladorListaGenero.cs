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
    public class controladorListaGenero
    {
        private Conexion ConexionBD = new Conexion();

        //Este controaldor sirve para poder rellenar las listas de genero, esto mediante el uso de un procedimiento almacenado
        //que hace una consulta a la base de datos.
        public List<modeloListaGenero> obtenerListaGenero()
        {
            List<modeloListaGenero> oListaGenero = new List<modeloListaGenero>();
            oListaGenero.Add(new modeloListaGenero { Id = 0, valor = "Género" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarGenero");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaGenero.Add(new modeloListaGenero
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        valor = Convert.ToString(dr["valor"])
                    });
                }
                dr.Close();
                ConexionBD.CerrarConexionSPS();
                return oListaGenero;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaGenero;
            }


        }
    }
}
