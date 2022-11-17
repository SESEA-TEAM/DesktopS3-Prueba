using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_sanciones.Modelo
{
    public class modeloTipoDocumento
    {
        public int Id { get; set; }
        public String tipoDocumento { get; set; }
        public String tituloDocumento { get; set; }
        public String fechaDocumento { get; set; }
        public String urlDocumento { get; set; }
        public String descripcionDocumento { get; set; }
    }
}
