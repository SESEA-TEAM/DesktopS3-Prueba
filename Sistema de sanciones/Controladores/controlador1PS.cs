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
    public class controlador1PS
    {
        private Conexion ConexionBD = new Conexion();
        //metodo que manda a llamar el procedimiento almacenado de alta de servidor sancionado que se llena mediante una instancia de modelops
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

        public bool modificarPS(modeloPS ps, int id)
        {
            try
            {
                SqlCommand comando = new SqlCommand("ModificarPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@id", id);
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
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionPS();
                return false;
            }
        }

        public modeloPS CsdsdargarPS(int id)
        {
            modeloPS ps = new modeloPS();
            try
            {
                SqlCommand comando = new SqlCommand("VisualizarPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ps.Id = id;
                    ps.ultimaActualizacion = Convert.ToString(dr["ultimaActualizacion"]);
                    ps.expediente = Convert.ToString(dr["expediente"]);
                    ps.autoridadSancionadora = Convert.ToString(dr["autoridadSancionadora"]);
                    ps.causaMotivoHechos = Convert.ToString(dr["causaMotivoHecho"]);

                    ps.nombreRazonSocial = Convert.ToString(dr["nombreRazonSocial"]);
                    ps.rfcPS = Convert.ToString(dr["RFC"]);
                    ps.tipoFalta = Convert.ToString(dr["tipoFalta"]);

                    if (!(dr["clave"] is DBNull))
                        ps.claveInstitucionDependencia = Convert.ToString(dr["clave"]);

                    if (!(dr["siglas"] is DBNull))
                        ps.siglasInstitucionDependencia = Convert.ToString(dr["siglas"]);

                    ps.nombreInstitucionDependencia = Convert.ToString(dr["nombre"]);

                    if (!(dr["acto"] is DBNull))
                        ps.acto = Convert.ToString(dr["acto"]);

                    if (!(dr["objetoSocial"] is DBNull))
                        ps.objetoSocial = Convert.ToString(dr["objetoSocial"]);

                    if (!(dr["tipoPersona"] is DBNull))
                        ps.tipoPersona = Convert.ToString(dr["tipoPersona"]);

                    if (!(dr["telefono"] is DBNull))
                        ps.telefono = Convert.ToString(dr["telefono"]);

                    if (!(dr["observaciones"] is DBNull))
                        ps.observaciones = Convert.ToString(dr["observaciones"]);

                    if (!(dr["paisV"] is DBNull))
                        ps.paisV = Convert.ToString(dr["paisV"]);

                    if (!(dr["calle"] is DBNull))
                        ps.calle = Convert.ToString(dr["calle"]);

                    if (!(dr["ciudadLocalidad"] is DBNull))
                        ps.ciudadLocalidad = Convert.ToString(dr["ciudadLocalidad"]);

                    if (!(dr["estadoProvincia"] is DBNull))
                        ps.estadoProvincia = Convert.ToString(dr["estadoProvincia"]);

                    if (!(dr["codigoPostalEX"] is DBNull))
                        ps.codigoPostalEX = Convert.ToString(dr["codigoPostalEX"]);

                    if (!(dr["numeroExteriorEX"] is DBNull))
                        ps.numeroExteriorEX = Convert.ToString(dr["numeroExteriorEX"]);

                    if (!(dr["numeroInteriorEX"] is DBNull))
                        ps.numeroInteriorEX = Convert.ToString(dr["numeroInteriorEX"]);

                    if (!(dr["entidadFederativaV"] is DBNull))
                        ps.entidadFederativaV = Convert.ToString(dr["entidadFederativaV"]);

                    if (!(dr["municipioV"] is DBNull))
                        ps.municipioV = Convert.ToString(dr["municipioV"]);

                    if (!(dr["localidadV"] is DBNull))
                        ps.localidadV = Convert.ToString(dr["localidadV"]);

                    if (!(dr["vialidadV"] is DBNull))
                        ps.vialidadV = Convert.ToString(dr["vialidadV"]);

                    if (!(dr["codigoPostalMX"] is DBNull))
                        ps.codigoPostalMX = Convert.ToString(dr["codigoPostalMX"]);

                    if (!(dr["numeroExteriorMX"] is DBNull))
                        ps.numeroExteriorMX = Convert.ToString(dr["numeroExteriorMX"]);

                    if (!(dr["numeroInteriorMX"] is DBNull))
                        ps.numeroInteriorEX = Convert.ToString(dr["numeroInteriorMX"]);

                    ps.nombreRS = Convert.ToString(dr["nombresRS"]);
                    ps.primerApellidoRS = Convert.ToString(dr["primerApellidoRS"]);

                    if (!(dr["segundoApellidoRS"] is DBNull))
                        ps.segundoApellidoRS = Convert.ToString(dr["segundoApellidoRS"]);

                    if (!(dr["curpDG"] is DBNull))
                        ps.curpDG = Convert.ToString(dr["curpDG"]);

                    if (!(dr["nombresDG"] is DBNull))
                        ps.nombresDG = Convert.ToString(dr["nombresDG"]);

                    if (!(dr["primerApellidoDG"] is DBNull))
                        ps.primerApellidoDG = Convert.ToString(dr["primerApellidoDG"]);

                    if (!(dr["segundoApellidoDG"] is DBNull))
                        ps.segundoApellidoDG = Convert.ToString(dr["segundoApellidoDG"]);

                    if (!(dr["curpAL"] is DBNull))
                        ps.curpAL = Convert.ToString(dr["curpAL"]);

                    if (!(dr["nombresAL"] is DBNull))
                        ps.nombresAL = Convert.ToString(dr["nombresAL"]);

                    if (!(dr["primerApellidoAL"] is DBNull))
                        ps.primerApellidoAL = Convert.ToString(dr["primerApellidoAL"]);

                    if (!(dr["segundoApellidoAL"] is DBNull))
                        ps.segundoApellidoAL = Convert.ToString(dr["segundoApellidoAL"]);

                    if (!(dr["sentido"] is DBNull))
                        ps.sentidoResolucion = Convert.ToString(dr["sentido"]);

                    if (!(dr["fechaResolucion"] is DBNull))
                        ps.fechaResolucion = Convert.ToString(dr["fechaResolucion"]);

                    if (!(dr["url"] is DBNull))
                        ps.urlResolucion = Convert.ToString(dr["url"]);

                    if (!(dr["plazo"] is DBNull))
                        ps.plazoInhabilitacion = Convert.ToString(dr["plazo"]);

                    if (!(dr["fechaInicial"] is DBNull))
                        ps.fechaInicialInhabilitacion = Convert.ToString(dr["fechaInicial"]);

                    if (!(dr["fechaFinal"] is DBNull))
                        ps.fechaFinalInhabilitacion = Convert.ToString(dr["fechaFinal"]);

                    if (!(dr["monto"] is DBNull))
                        ps.monto = float.Parse(Convert.ToString(dr["monto"]));

                    if (!(dr["moneda2"] is DBNull))
                        ps.moneda2 = Convert.ToString(dr["moneda2"]);

                }
                dr.Close();
                return ps;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return ps;
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

        public List<modeloTipoSancion> obtenerSancionesPS(int id)
        {
            int i = 0;
            List<modeloTipoSancion> oListaSanciones = new List<modeloTipoSancion>();
            try
            {
                SqlCommand comando = new SqlCommand("VisualizarSancionesPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaSanciones.Add(new modeloTipoSancion
                    {
                        id = i,
                        valor = Convert.ToString(dr["valor"]),
                        descripcion = Convert.ToString(dr["descripcionSancion"])
                    });
                    i++;
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

        public List<modeloTipoDocumento> obtenerDocumentosPS(int id)
        {
            int i = 0;
            List<modeloTipoDocumento> oListaDocumentos = new List<modeloTipoDocumento>();
            try
            {
                SqlCommand comando = new SqlCommand("VisualizarDocumentosPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaDocumentos.Add(new modeloTipoDocumento
                    {
                        Id = i,
                        tipoDocumento = Convert.ToString(dr["tipoDocumentos"]),
                        tituloDocumento = Convert.ToString(dr["titulo"]),
                        fechaDocumento = Convert.ToString(dr["fecha"]),
                        urlDocumento = Convert.ToString(dr["url"]),
                        descripcionDocumento = Convert.ToString(dr["descripcion"])
                    });
                    i++;
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

        //metodo para registrar una sancion a la hora de editar, este se manda a llamar varias veces, puesto que a un registro de servidor sancionado se le puede ligar mas de 1 sancion
        public bool agregarSancionPS(int idSancion, String descripcionSancion, int id)
        {
            try
            {
                SqlCommand comando = new SqlCommand("ModificarTipoSancionPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@TipoSancion", idSancion);
                comando.Parameters.AddWithValue("@descripcionSancion", descripcionSancion);
                comando.Parameters.AddWithValue("@idSancion", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                ConexionBD.CerrarConexionPS();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionPS();
                return false;
            }
        }

        //metodo para registrar un documento a la hora de aditar, al igual que en el de sancion, un registro de servidor sancionado puede tener varios documentos ligados
        public bool agregarDocumentoPS(int idTipoDoc, String titulo, String descripcionDoc, String urlDoc, String fechaDoc, int id)
        {
            try
            {
                SqlCommand comando = new SqlCommand("ModificarDocumentosPS");
                comando.Connection = ConexionBD.AbrirConexionPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@Titulo", titulo);
                comando.Parameters.AddWithValue("@idTipoDocumento", idTipoDoc);
                comando.Parameters.AddWithValue("@descripcion", descripcionDoc);
                comando.Parameters.AddWithValue("@url", urlDoc);
                comando.Parameters.AddWithValue("@fecha", fechaDoc);
                comando.Parameters.AddWithValue("@idSancion", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                ConexionBD.CerrarConexionPS();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionPS();
                return false;
            }
        }

    }
}
