using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA
{
    public class EntityBase
    {
        public int Id { get; set; }

        public bool Aceptado { get; set; } = false;
    }
}
