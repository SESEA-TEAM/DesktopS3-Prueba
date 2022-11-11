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
    internal class controladorTipoSancion
    {
        private Conexion ConexionBD = new Conexion();

        public List<modeloTipoSancion> obtenerListaSanciones()
        {
            List<modeloTipoSancion> oListaSanciones = new List<modeloTipoSancion>();
            oListaSanciones.Add(new modeloTipoSancion { id = 0, valor = "Tipo Sanción" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarSancion");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaSanciones.Add(new modeloTipoSancion
                    {
                        id = Convert.ToInt32(dr["id"]),
                        valor = Convert.ToString(dr["valor"])
                    });
                }
                dr.Close();
                return oListaSanciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaSanciones;
            }


        }

        public List<modeloTipoSancion> obtenerListaSancionesPS()
        {
            List<modeloTipoSancion> oListaSanciones = new List<modeloTipoSancion>();
            oListaSanciones.Add(new modeloTipoSancion { id = 0, valor = "Tipo Sanción" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarSancion");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaSanciones.Add(new modeloTipoSancion
                    {
                        id = Convert.ToInt32(dr["id"]),
                        valor = Convert.ToString(dr["valor"])
                    });
                }
                dr.Close();
                return oListaSanciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaSanciones;
            }


        }
    }
}
