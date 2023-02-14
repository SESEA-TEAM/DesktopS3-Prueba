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
    internal class controladorMoneda
    {
        private Conexion ConexionBD = new Conexion();

        //Este controaldor sirve para poder rellenar las listas de tipo moneda, esto mediante el uso de un procedimiento almacenado
        //que hace una consulta a la base de datos.
        public List<modeloMoneda> obtenerListaMonedas()
        {
            List<modeloMoneda> oListaMonedas = new List<modeloMoneda>();
            oListaMonedas.Add(new modeloMoneda { Id = 0, valor = "Moneda" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarMoneda");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaMonedas.Add(new modeloMoneda
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        valor = Convert.ToString(dr["valor"])
                    });
                }
                dr.Close();
                ConexionBD.CerrarConexionSPS();
                return oListaMonedas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaMonedas;
            }


        }

        public List<modeloMoneda> obtenerListaMonedasPS()
        {
            List<modeloMoneda> oListaMonedas = new List<modeloMoneda>();
            oListaMonedas.Add(new modeloMoneda { Id = 0, valor = "Moneda" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarMoneda");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaMonedas.Add(new modeloMoneda
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        valor = Convert.ToString(dr["valor"])
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
