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
                comando.Parameters.AddWithValue("@nivel", sps.nivelSPS);
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

        public bool modificarSPS(modeloSPS sps, int id)
        {
            try
            {
                SqlCommand comando = new SqlCommand("ModificarSPS");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@expediente", sps.expediente);
                comando.Parameters.AddWithValue("@autoridadSancionadora", sps.autoridadSancionadora);
                comando.Parameters.AddWithValue("@causaMotivoHecho", sps.causaMotivoHechos);
                comando.Parameters.AddWithValue("@RFC", sps.rfcSPS);
                comando.Parameters.AddWithValue("@CURP", sps.curpSPS);
                comando.Parameters.AddWithValue("@nombre", sps.nombreSPS);
                comando.Parameters.AddWithValue("@primerApellido", sps.primerApellidoSPS);
                comando.Parameters.AddWithValue("@segundoApellido", sps.segundoApellidoSPS);
                comando.Parameters.AddWithValue("@puesto", sps.puestoSPS);
                comando.Parameters.AddWithValue("@nivel", sps.nivelSPS);
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
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionSPS();
                return false;
            }

        }

        public modeloSPS CsdsdargarSPS(int id)
        {
            modeloSPS sps = new modeloSPS();
            try
            {
                SqlCommand comando = new SqlCommand("VisualizarSPS");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    sps.Id = id;
                    sps.ultimaActualizacion = Convert.ToString(dr["ultimaActualizacion"]);
                    sps.expediente = Convert.ToString(dr["expediente"]);
                    sps.autoridadSancionadora = Convert.ToString(dr["autoridadSancionadora"]);
                    sps.causaMotivoHechos = Convert.ToString(dr["causaMotivoHecho"]);
                    if (!(dr["observaciones"] is DBNull))
                        sps.observaciones = Convert.ToString(dr["observaciones"]);;

                    sps.curpSPS = Convert.ToString(dr["CURP"]);
                    sps.rfcSPS = Convert.ToString(dr["RFC"]);
                    sps.nombreSPS = Convert.ToString(dr["nombre"]);
                    sps.primerApellidoSPS = Convert.ToString(dr["primerApellido"]);
                    if (!(dr["segundoApellido"] is DBNull))
                        sps.segundoApellidoSPS = Convert.ToString(dr["segundoApellido"]);
                    if (!(dr["genero"] is DBNull))
                        sps.genero = Convert.ToString(dr["genero"]);
                    sps.puestoSPS = Convert.ToString(dr["puesto"]);
                    if (!(dr["nivel"] is DBNull))
                        sps.nivelSPS = Convert.ToString(dr["nivel"]);

                    if (!(dr["clave"] is DBNull))
                        sps.claveInstitucionDependencia = Convert.ToString(dr["clave"]);
                    sps.nombreInstitucionDependencia = Convert.ToString(dr["nombreISD"]);
                    if (!(dr["siglas"] is DBNull))
                        sps.siglasInstitucionDependencia = Convert.ToString(dr["siglas"]);

                    if (!(dr["fechaResolucion"] is DBNull))
                        sps.fechaResolucion = Convert.ToString(dr["fechaResolucion"]);
                    if (!(dr["url"] is DBNull))
                        sps.urlResolucion = Convert.ToString(dr["url"]);

                    if (!(dr["plazo"] is DBNull))
                        sps.plazoInhabilitacion = Convert.ToString(dr["plazo"]);
                    if (!(dr["fechaInicial"] is DBNull))
                        sps.fechaInicialInhabilitacion = Convert.ToString(dr["fechaInicial"]);
                    if (!(dr["fechaFinal"] is DBNull))
                        sps.fechaFinalInhabilitacion = Convert.ToString(dr["fechaFinal"]);

                    if (!(dr["monto"] is DBNull))
                        sps.montoMulta = float.Parse(Convert.ToString(dr["monto"]));
                    if (!(dr["moneda"] is DBNull))
                        sps.moneda = Convert.ToString(dr["moneda"]);
                    
                    if (!(dr["falta"] is DBNull))
                        sps.falta = Convert.ToString(dr["falta"]);
                    if (!(dr["descripcionFalta"] is DBNull))
                        sps.descripcionFalta = Convert.ToString(dr["descripcionFalta"]);
                    sps.tipoFalta = Convert.ToInt16(dr["idFalta"]);
                    if (!(dr["moneda2"] is DBNull))
                        sps.monedaMulta = Convert.ToInt32(dr["moneda2"]);
                    if (!(dr["genero2"] is DBNull))
                        sps.generoSPS = Convert.ToInt32(dr["genero2"]);


                }
                dr.Close();
                //ConexionBD.CerrarConexionSPS();
                return sps;
            }
            catch (Exception ex)
            {
                ConexionBD.CerrarConexionSPS();
                MessageBox.Show("Error: " + ex.ToString());
                return sps;
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

        public List<modeloTipoSancion> obtenerSancionesSPS(int id)
        {
            int i = 0;
            List<modeloTipoSancion> oListaSanciones = new List<modeloTipoSancion>();
            try
            {
                SqlCommand comando = new SqlCommand("VisualizarSancionesSPS");
                comando.Connection = ConexionBD.AbrirConexionSPS();
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
                //ConexionBD.CerrarConexionSPS();
                return oListaSanciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaSanciones;
            }


        }

        public List<modeloTipoDocumento> obtenerDocumentosSPS(int id)
        {
            int i = 0;
            List<modeloTipoDocumento> oListaDocumentos = new List<modeloTipoDocumento>();
            try
            {
                SqlCommand comando = new SqlCommand("VisualizarDocumentosSPS");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    oListaDocumentos.Add(new modeloTipoDocumento
                    {
                        Id = i,
                        tipoDocumento = Convert.ToString(dr["tipoDocumento"]),
                        tituloDocumento = Convert.ToString(dr["titulo"]),
                        fechaDocumento = Convert.ToString(dr["fecha"]),
                        urlDocumento = Convert.ToString(dr["url"]),
                        descripcionDocumento = Convert.ToString(dr["descripcion"])
                    });
                    i++;
                }
                dr.Close();
                //ConexionBD.CerrarConexionSPS();
                return oListaDocumentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                return oListaDocumentos;
            }


        }

        //metodo para registrar una sancion a la hora de editar, este se manda a llamar varias veces, puesto que a un registro de servidor sancionado se le puede ligar mas de 1 sancion
        public bool agregarSancionSPS(int idSancion, String descripcionSancion, int id)
        {
            try
            {
                SqlCommand comando = new SqlCommand("ModificarTipoSancionSPS");
                comando.Connection = ConexionBD.AbrirConexionSPS();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = 600;
                comando.Parameters.AddWithValue("@TipoSancion", idSancion);
                comando.Parameters.AddWithValue("@descripcionSancion", descripcionSancion);
                comando.Parameters.AddWithValue("@idSancion", id);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                //ConexionBD.CerrarConexionSPS();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionSPS();
                return false;
            }
        }

        //metodo para registrar un documento a la hora de aditar, al igual que en el de sancion, un registro de servidor sancionado puede tener varios documentos ligados
        public bool agregarDocumentoSPS(int idTipoDoc, String titulo, String descripcionDoc, String urlDoc, String fechaDoc, int id)
        {
            try
            {
                SqlCommand comando = new SqlCommand("ModificarDocumentosSPS");
                comando.Connection = ConexionBD.AbrirConexionSPS();
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
                //ConexionBD.CerrarConexionSPS();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
                ConexionBD.CerrarConexionSPS();
                return false;
            }
        }
    }
}
