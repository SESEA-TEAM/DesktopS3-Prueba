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
    internal class controladorTipoFalta
    {
        private Conexion ConexionBD = new Conexion();

        //Este controaldor sirve para poder rellenar las listas de tipo falta, esto mediante el uso de un procedimiento almacenado
        //que hace una consulta a la base de datos.
        public List<modeloTipoFalta> obtenerListaFaltas()
        {
            List<modeloTipoFalta> oListaFaltas = new List<modeloTipoFalta>();
            oListaFaltas.Add(new modeloTipoFalta { Id = 0, valor = "Tipo Falta*" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarFalta");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaFaltas.Add(new modeloTipoFalta
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        valor = Convert.ToString(dr["valor"])
                    });
                }
                dr.Close();
                ConexionBD.CerrarConexionSPS();
                return oListaFaltas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaFaltas;
            }


        }
    }
}
