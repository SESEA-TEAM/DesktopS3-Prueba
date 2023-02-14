using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Sistema_de_sanciones.ConexionBD;
using Sistema_de_sanciones.Modelo;

namespace Sistema_de_sanciones.Controladores
{
    public class controladorListaUsusarios
    {


        private Conexion ConexionBD = new Conexion();

        //Este controaldor sirve para poder rellenar las listas de tipo sancion, esto mediante el uso de un procedimiento almacenado
        //que hace una consulta a la base de datos.
        public List<modeloListaUsuarios> obtenerListaUsuarios()
        {
            List<modeloListaUsuarios> oListaUsuarios = new List<modeloListaUsuarios>();
            oListaUsuarios.Add(new modeloListaUsuarios { Id = 0, usuario = "Usuario" });
            try
            {
                SqlCommand comando = new SqlCommand("llenaUsuarios");
                comando.Connection = ConexionBD.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaUsuarios.Add(new modeloListaUsuarios
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        usuario = Convert.ToString(dr["usuario"])
                    });
                }
                dr.Close();
                return oListaUsuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaUsuarios;
            }


        }


        //SqlCommand comando = new SqlCommand("consultaBitacora");
        //comando.Connection = ConexionBD.AbrirConexion();
        //    comando.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(comando);
        //DataSet dt = new DataSet();
        //da.Fill(dt);
        //    return dt;
    }
}
