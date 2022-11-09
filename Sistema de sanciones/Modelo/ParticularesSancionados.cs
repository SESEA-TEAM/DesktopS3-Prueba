using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_sanciones.Modelo
{
    internal class ParticularesSancionados
    {
        public int Id { get; set; }
        public string particularSancionado { get; set; }
        public string fechaCaptura { get; set; }
        public string expediente { get; set; }
        public string autoridadSancionadora { get; set; }
        public string tipoSancion { get; set; }
        public string tipoFalta { get; set; }
        public string causaMotivoHecho { get; set; }
        public string servidorPublicoSancionado { get; set; }
        public string acto { get; set; }
        public string observaciones { get; set; }
        public string multa { get; set; }
        public string resolucion { get; set; }
        public string inhabilitacion { get; set; }
        public string documentos { get; set; }
        public string descripcionSancion { get; set; }
        public string responsableSancion { get; set; }
        public string institucionDependiente { get; set; }
        public string directorGeneral { get; set; }
        public string apoderadoLegal { get; set; }
    }
}
