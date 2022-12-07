using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_sanciones.Controladores
{
    //Este modelo obtiene el id y el proveedor, para usarlo en el modulo crear usuario ComboBox proveedores
    public class modeloListaProveedores
    {
        public int id { get; set; }
        public string proveedor { get; set; }
    }
}