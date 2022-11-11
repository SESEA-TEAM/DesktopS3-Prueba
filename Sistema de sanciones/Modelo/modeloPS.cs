using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_sanciones.Modelo
{
    public class modeloPS
    {
        public int? Id { get; set; }
        public String expediente { get; set; }
        public String autoridadSancionadora { get; set; }
        public String tipoFalta { get; set; }
        public String causaMotivoHechos { get; set; }
        public String objetoContrato { get; set; }
        public String acto { get; set; }
        public String observaciones { get; set; }
        public String rfcPS { get; set; }
        public String nombreRazonSocial { get; set; }
        public String objetoSocial { get; set; }
        public String tipoPersona { get; set; }
        public int? telefono { get; set; }
        public String calle { get; set; }
        public String ciudadLocalidad { get; set; }
        public String estadoProvincia { get; set; }
        public String codigoPostalEX { get; set; }
        public String numeroInteriorEX { get; set; }
        public String numeroExteriorEX { get; set; }
        public int? paisEX { get; set; }
        public int? entidadFederativa { get; set; }
        public int? municipio { get; set; }
        public int? localidad { get; set; }
        public int? vialidad { get; set; }
        public String codigoPostalMX { get; set; }
        public String numeroInteriorMX { get; set; }
        public String numeroExteriorMX { get; set; }
        public int? paisMX { get; set; }
        public float? monto { get; set; }
        public int? moneda { get; set; }
        public String claveInstitucionDependencia { get; set; }
        public String nombreInstitucionDependencia { get; set; }
        public String siglasInstitucionDependencia { get; set; }
        public String sentidoResolucion { get; set; }
        public String fechaResolucion { get; set; }
        public String urlResolucion { get; set; }
        public String nombreRS { get; set; }
        public String primerApellidoRS { get; set; }
        public String segundoApellidoRS { get; set; }
        public String curpAL { get; set; }
        public String nombresAL { get; set; }
        public String primerApellidoAL { get; set; }
        public String segundoApellidoAL { get; set; }
        public String curpDG { get; set; }
        public String nombresDG { get; set; }
        public String primerApellidoDG { get; set; }
        public String segundoApellidoDG { get; set; }
        public String plazoInhabilitacion { get; set; }
        public String fechaInicialInhabilitacion { get; set; }
        public String fechaFinalInhabilitacion { get; set; }

    }
}
