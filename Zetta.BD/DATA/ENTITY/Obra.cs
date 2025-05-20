using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class Obra : EntityBase
    {
        public string Estado { get; set; } // Iniciada, En Proceso, Finalizada

        public int PresupuestoId { get; set; }
        public Presupuesto Presupuesto { get; set; }

        public int? ProfesionalId { get; set; }
        public Profesional Profesional { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

}
