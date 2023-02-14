﻿using System;
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
    public class controladorEntidadFederativa
    {
        private Conexion ConexionBD = new Conexion();
        
        //Este controlador sirve para obtener el listado de las entidades federativas del estado de mexico, esto mediante un
        //procedimiento almacenado que hace una consulta a la base de datos.
        public List<modeloEntidadFederativa> obtenerListaPais()
        {
            List<modeloEntidadFederativa> oListaMonedas = new List<modeloEntidadFederativa>();
            oListaMonedas.Add(new modeloEntidadFederativa { id = 0, name = "Entidad federativa" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarEntidadFederativa");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaMonedas.Add(new modeloEntidadFederativa
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
