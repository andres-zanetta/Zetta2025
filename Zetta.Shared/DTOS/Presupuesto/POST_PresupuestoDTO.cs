using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zetta.Shared.DTOS.ItemPresupuesto;

namespace Zetta.Shared.DTOS.Presupuesto
{
    public class POST_PresupuestoDTO
    {
        public string ClienteNombre { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public bool IncluyeMateriales { get; set; }

        // Items que componen el presupuesto
        public required List<GET_ItemPresupuestoDTO> Items { get; set; }
    }

}
