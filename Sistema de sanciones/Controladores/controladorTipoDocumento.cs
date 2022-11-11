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
    internal class controladorTipoDocumento
    {
        private Conexion ConexionBD = new Conexion();

        public List<modeloTipoDocumento> obtenerListaDocumentos()
        {
            List<modeloTipoDocumento> oListaDocumentos = new List<modeloTipoDocumento>();
            oListaDocumentos.Add(new modeloTipoDocumento { Id = 0, tipoDocumento = "Tipo Documento" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarDocumento");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaDocumentos.Add(new modeloTipoDocumento
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        tipoDocumento = Convert.ToString(dr["tipoDocumento"])
                    });
                }
                dr.Close();
                return oListaDocumentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaDocumentos;
            }


        }

        public List<modeloTipoDocumento> obtenerListaDocumentosPS()
        {
            List<modeloTipoDocumento> oListaDocumentos = new List<modeloTipoDocumento>();
            oListaDocumentos.Add(new modeloTipoDocumento { Id = 0, tipoDocumento = "Tipo Documento" });
            try
            {
                SqlCommand comando = new SqlCommand("llenarDocumento");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaDocumentos.Add(new modeloTipoDocumento
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        tipoDocumento = Convert.ToString(dr["tipoDocumentos"])
                    });
                }
                dr.Close();
                return oListaDocumentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaDocumentos;
            }


        }
    }
}
