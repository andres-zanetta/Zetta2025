using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class Profesional : EntityBase
    {
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public decimal Comision { get; set; } = 0.05m;

        public ICollection<Obra> ObrasDerivadas { get; set; }
    }

}
