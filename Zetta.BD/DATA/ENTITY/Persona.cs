using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class Persona:EntityBase
    {
        public string NombreApellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string TipoPersona { get; set; }//Si es cliente o personal/empleado

        // Constructor
        public Persona()
        {
            // Inicializar propiedades si es necesario
        }
    }
}
