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
    public class controlador1SPS
    {
        private Conexion ConexionBD = new Conexion();

        //metodo que manda a llamar el procedimiento almacenado de alta de servidor sancionado que se llena mediante una instancia de modeloSPS
        public void guardarSPS(modeloSPS sps)
        {
            try
            {
                SqlCommand comando = new SqlCommand("InsertarSPS");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@expediente", sps.expediente);
                comando.Parameters.AddWithValue("@autoridadSancionadora", sps.autoridadSancionadora);
                comando.Parameters.AddWithValue("@causaMotivoHecho", sps.causaMotivoHechos);
                comando.Parameters.AddWithValue("@RFC", sps.rfcSPS);
                comando.Parameters.AddWithValue("@CURP", sps.curpSPS);
                comando.Parameters.AddWithValue("@nombre", sps.nombreSPS);
                comando.Parameters.AddWithValue("@primerApellido", sps.primerApellidoSPS);
                comando.Parameters.AddWithValue("@segundoApellido", sps.segundoApellidoSPS);
                comando.Parameters.AddWithValue("@puesto", sps.puestoSPS);
                comando.Parameters.AddWithValue("@nivel", sps.puestoSPS);
                comando.Parameters.AddWithValue("@genero", sps.generoSPS);
                comando.Parameters.AddWithValue("@tipoFalta", sps.tipoFalta);
                comando.Parameters.AddWithValue("@observaciones", sps.observaciones);
                comando.Parameters.AddWithValue("@claveInstitucionDependencia", sps.claveInstitucionDependencia);
                comando.Parameters.AddWithValue("@nombreInstitucionDependencia", sps.nombreInstitucionDependencia);
                comando.Parameters.AddWithValue("@siglasInstitucionDependencia", sps.siglasInstitucionDependencia);
                comando.Parameters.AddWithValue("@monto", sps.montoMulta);
                comando.Parameters.AddWithValue("@moneda", sps.monedaMulta);
                comando.Parameters.AddWithValue("@fechaResolucion", sps.fechaResolucion);
                comando.Parameters.AddWithValue("@urlResolucion", sps.urlResolucion);
                comando.Parameters.AddWithValue("@plazoInhabilitacion", sps.plazoInhabilitacion);
                comando.Parameters.AddWithValue("@fechaInicialInhabilitacion", sps.fechaInicialInhabilitacion);
                comando.Parameters.AddWithValue("@fechaFinalInhabilitacion", sps.fechaFinalInhabilitacion);
                comando.Parameters.AddWithValue("@descripcionFalta", sps.descripcionFalta);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                ConexionBD.CerrarConexionSPS();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionSPS();
            }

        }

        //metodo para registrar una sancion, este se manda a llamar varias veces, puesto que a un registro de servidor sancionado se le puede ligar mas de 1 sancion
        public void guardarSancionSPS(int idSancion, String descripcionSancion)
        {
            try
            {
                SqlCommand comando = new SqlCommand("InsertarTipoSancionSPS");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@TipoSancion", idSancion);
                comando.Parameters.AddWithValue("@descripcionSancion", descripcionSancion);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                ConexionBD.CerrarConexionSPS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionSPS();
            }
        }

        //metodo para registrar un documento, al igual que en el de sancion, un registro de servidor sancionado puede tener varios documentos ligados
        public void guardarDocumentoSPS(int idTipoDoc, String titulo, String descripcionDoc, String urlDoc, String fechaDoc)
        {
            try
            {
                SqlCommand comando = new SqlCommand("InsertarDocumentosSPS");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@Titulo", titulo);
                comando.Parameters.AddWithValue("@idTipoDocumento", idTipoDoc);
                comando.Parameters.AddWithValue("@descripcion", descripcionDoc);
                comando.Parameters.AddWithValue("@url", urlDoc);
                comando.Parameters.AddWithValue("@fecha", fechaDoc);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                ConexionBD.CerrarConexionSPS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionSPS();
            }
        }
    }
}
