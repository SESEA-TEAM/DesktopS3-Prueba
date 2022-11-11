using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_de_sanciones.ConexionBD;
using Sistema_de_sanciones.Modelo;

namespace Sistema_de_sanciones.Controladores
{
    internal class controladorPS
    {

        private Conexion ConexionBD = new Conexion();

        private int inicio2;
        private int final2;
        private int total;
        public int Inicio2 { get => inicio2; set => inicio2 = value; }
        public int Final2 { get => final2; set => final2 = value; }
        public int Total { get => total; set => total = value; }

        public void guardarPS(modeloPS ps)
        {
            try
            {
                SqlCommand comando = new SqlCommand("InsertarPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@expediente", ps.expediente);
                comando.Parameters.AddWithValue("@autoridadSancionadora", ps.autoridadSancionadora);
                comando.Parameters.AddWithValue("@tipoFalta", ps.tipoFalta);
                comando.Parameters.AddWithValue("@objetoContrato", ps.objetoContrato);
                comando.Parameters.AddWithValue("@causaMotivoHecho", ps.causaMotivoHechos);
                comando.Parameters.AddWithValue("@acto", ps.acto);
                comando.Parameters.AddWithValue("@observaciones", ps.observaciones);
                comando.Parameters.AddWithValue("@RFC", ps.rfcPS);
                comando.Parameters.AddWithValue("@nombreRazonSocial", ps.nombreRazonSocial);
                comando.Parameters.AddWithValue("@objetoSocial", ps.objetoSocial);
                comando.Parameters.AddWithValue("@tipoPersona", ps.tipoPersona);
                comando.Parameters.AddWithValue("@telefono", ps.telefono);
                comando.Parameters.AddWithValue("@calle", ps.calle);
                comando.Parameters.AddWithValue("@ciudadLocalidad", ps.ciudadLocalidad);
                comando.Parameters.AddWithValue("@estadoProvincia", ps.estadoProvincia);
                comando.Parameters.AddWithValue("@codigoPostalEX", ps.codigoPostalEX);
                comando.Parameters.AddWithValue("@numeroInteriorEX", ps.numeroInteriorEX);
                comando.Parameters.AddWithValue("@numeroExteriorEX", ps.numeroExteriorEX);
                comando.Parameters.AddWithValue("@paisEX", ps.paisEX);
                comando.Parameters.AddWithValue("@entidadFederativa", ps.entidadFederativa);
                comando.Parameters.AddWithValue("@municipio", ps.municipio);
                comando.Parameters.AddWithValue("@localidad", ps.localidad);
                comando.Parameters.AddWithValue("@vialidad", ps.vialidad);
                comando.Parameters.AddWithValue("@codigoPostalMX", ps.codigoPostalMX);
                comando.Parameters.AddWithValue("@numeroInteriorMX", ps.numeroInteriorMX);
                comando.Parameters.AddWithValue("@numeroExteriorMX", ps.numeroExteriorMX);
                comando.Parameters.AddWithValue("@paisMX", ps.paisMX);
                comando.Parameters.AddWithValue("@monto", ps.monto);
                comando.Parameters.AddWithValue("@moneda", ps.moneda);
                comando.Parameters.AddWithValue("@claveInstitucionDependencia", ps.claveInstitucionDependencia);
                comando.Parameters.AddWithValue("@nombreInstitucionDependencia", ps.nombreInstitucionDependencia);
                comando.Parameters.AddWithValue("@siglasInstitucionDependencia", ps.siglasInstitucionDependencia);
                comando.Parameters.AddWithValue("@sentidoResolucion", ps.sentidoResolucion);
                comando.Parameters.AddWithValue("@fechaResolucion", ps.fechaResolucion);
                comando.Parameters.AddWithValue("@urlResolucion", ps.urlResolucion);
                comando.Parameters.AddWithValue("@nombreRS", ps.nombreRS);
                comando.Parameters.AddWithValue("@primerApellidoRS", ps.@primerApellidoRS);
                comando.Parameters.AddWithValue("@segundoApellidoRS", ps.segundoApellidoRS);
                comando.Parameters.AddWithValue("@curpAL", ps.curpAL);
                comando.Parameters.AddWithValue("@nombresAL", ps.nombresAL);
                comando.Parameters.AddWithValue("@primerApellidoAL", ps.primerApellidoAL);
                comando.Parameters.AddWithValue("@segundoApellidoAL", ps.segundoApellidoAL);
                comando.Parameters.AddWithValue("@curpDG", ps.curpDG);
                comando.Parameters.AddWithValue("@nombresDG", ps.nombresDG);
                comando.Parameters.AddWithValue("@primerApellidoDG", ps.primerApellidoDG);
                comando.Parameters.AddWithValue("@segundoApellidoDG", ps.segundoApellidoDG);
                comando.Parameters.AddWithValue("@plazoInhabilitacion", ps.plazoInhabilitacion);
                comando.Parameters.AddWithValue("@fechaInicialInhabilitacion", ps.fechaInicialInhabilitacion);
                comando.Parameters.AddWithValue("@fechaFinalInhabilitacion", ps.fechaFinalInhabilitacion);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                ConexionBD.CerrarConexionPS();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionPS();
            }
        }

        //metodo para registrar una sancion, este se manda a llamar varias veces, puesto que a un registro de servidor sancionado se le puede ligar mas de 1 sancion
        public void guardarSancionPS(int idSancion, String descripcionSancion)
        {
            try
            {
                SqlCommand comando = new SqlCommand("InsertarTipoSancionPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@TipoSancion", idSancion);
                comando.Parameters.AddWithValue("@descripcionSancion", descripcionSancion);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                ConexionBD.CerrarConexionPS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionPS();
            }
        }

        //metodo para registrar un documento, al igual que en el de sancion, un registro de servidor sancionado puede tener varios documentos ligados
        public void guardarDocumentoPS(int idTipoDoc, String titulo, String descripcionDoc, String urlDoc, String fechaDoc)
        {
            try
            {
                SqlCommand comando = new SqlCommand("InsertarDocumentosPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@Titulo", titulo);
                comando.Parameters.AddWithValue("@idTipoDocumento", idTipoDoc);
                comando.Parameters.AddWithValue("@descripcion", descripcionDoc);
                comando.Parameters.AddWithValue("@url", urlDoc);
                comando.Parameters.AddWithValue("@fecha", fechaDoc);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                ConexionBD.CerrarConexionPS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionPS();
            }
        }

        public DataSet BarraListadoPS(String Expediente, String InstitucionDependencia, String NombreRazonSocial, String TipoPersona, String TipoSancion,
            String FechaActualizacion, String Inhabilitacion)
        {

            try
            {

                DataSet dt = new DataSet();

                SqlCommand comando = new SqlCommand("BarraListadoPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@expediente", Expediente);
                comando.Parameters.AddWithValue("@institucionDependencia", InstitucionDependencia);
                comando.Parameters.AddWithValue("@nombreRazonSocial", NombreRazonSocial);
                comando.Parameters.AddWithValue("@fechaActualizacion", FechaActualizacion);
                comando.Parameters.AddWithValue("@tipoPersona", TipoPersona);
                comando.Parameters.AddWithValue("@tipoSancion", TipoSancion);
                comando.Parameters.AddWithValue("@inhabilitacion", Inhabilitacion);
                comando.Parameters.AddWithValue("@InicioTablaListadoPS", Inicio2);
                comando.Parameters.AddWithValue("@FinalTablaListadoPS", Final2);
                SqlDataAdapter da = new SqlDataAdapter(comando);


                da.Fill(dt);
                return dt;
            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.ToString());

                ConexionBD.CerrarConexionPS();
                return null;
            }

        }
        public int UltimoBarraListadoPS(String Expediente, String InstitucionDependencia, String NombreRazonSocial, String TipoPersona, String TipoSancion,
            String FechaActualizacion, String Inhabilitacion)
        {

            try
            {

                SqlCommand comando = new SqlCommand("UltimoBarraListadoPS");
                comando.CommandType = CommandType.StoredProcedure;
                SqlParameter retorno = new SqlParameter();
                comando.Parameters.AddWithValue("@expediente", Expediente);
                comando.Parameters.AddWithValue("@institucionDependencia", InstitucionDependencia);
                comando.Parameters.AddWithValue("@nombreRazonSocial", NombreRazonSocial);
                comando.Parameters.AddWithValue("@tipoPersona", TipoPersona);
                comando.Parameters.AddWithValue("@tipoSancion", TipoSancion);
                comando.Parameters.AddWithValue("@fechaActualizacion", FechaActualizacion);
                comando.Parameters.AddWithValue("@inhabilitacion", Inhabilitacion);

                comando.Connection = ConexionBD.AbrirConexionPS();

                var returnParameter = comando.Parameters.Add("@Total", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                comando.ExecuteNonQuery();
                comando.Dispose();

                var result = returnParameter.Value;
                comando.Connection = ConexionBD.CerrarConexionPS();
                return Convert.ToInt32(result);

            }

            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.ToString());

                ConexionBD.CerrarConexionPS();
                return 0;
            }

        }



    }
}
