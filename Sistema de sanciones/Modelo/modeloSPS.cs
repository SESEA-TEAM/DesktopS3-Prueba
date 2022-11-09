using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_sanciones.Modelo
{
    public class modeloSPS
    {
        public int Id { get; set; }
        public string fechaC { get; set; }
        public String expediente { get; set; }
        public String autoridadSancionadora { get; set; }   
        public String causaMotivoHechos { get; set; }
        public String rfcSPS { get; set; }
        public String curpSPS { get; set; }    
        public String nombreSPS { get; set; }
        public String primerApellidoSPS { get; set; }
        public String segundoApellidoSPS { get; set; }
        public String puestoSPS { get; set; }
        public String nivelSPS { get; set; }
        public int generoSPS { get; set; }
        public int tipoFalta { get; set; }
        public String observaciones { get; set; }
        public String claveInstitucionDependencia { get; set; }
        public String nombreInstitucionDependencia { get; set; }
        public String siglasInstitucionDependencia { get; set; }
        public float montoMulta { get; set; }
        public int monedaMulta { get; set; }
        public string fechaResolucion { get; set; }
        public String urlResolucion { get; set ; }
        public String plazoInhabilitacion { get; set; }
        public String fechaInicialInhabilitacion { get; set; }
        public String fechaFinalInhabilitacion { get; set; }
        public String descripcionFalta { get; set; }
        public String ultimaActualizacion { get; set; }
    }
}
