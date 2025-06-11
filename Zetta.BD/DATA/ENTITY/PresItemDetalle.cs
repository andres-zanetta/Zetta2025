using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.BD.DATA.ENTITY
{
    public class PresItemDetalle : EntityBase 
    {
        // Clave Foránea y Propiedad de Navegación al Presupuesto al que pertenece este detalle.
        // EF Core inferirá la relación por el nombre si sigues las convenciones.
        public int PresupuestoId { get; set; }
        public Presupuesto Presupuesto { get; set; }

        // Clave Foránea y Propiedad de Navegación al ItemPresupuesto del catálogo que se está utilizando.
        public int ItemPresupuestoId { get; set; }
        public ItemPresupuesto ItemPresupuesto { get; set; }

        // Cantidad de este ItemPresupuesto específico para este Presupuesto.
        public int Cantidad { get; set; }

        // Precio unitario del ítem en el momento en que se agregó a este presupuesto.
        // Esto es crucial para la integridad histórica, ya que el precio del catálogo podría cambiar.
        [Precision(18, 2)] // Define la precisión y escala para el tipo decimal en la base de datos.
        public decimal PrecioUnitario { get; set; }
    }
}

#region Diccionario
// Diccionario
// | Nombre            | Tipo                | Descripción                                                                 |
// |-------------------|---------------------|-----------------------------------------------------------------------------|
// | Id                | int                 | Identificador único del detalle.                                            |
// | PresupuestoId     | int                 | Clave foránea al presupuesto al que pertenece este detalle.                 |
// | Presupuesto       | Presupuesto         | Referencia al presupuesto asociado.                                         |
// | ItemPresupuestoId | int                 | Clave foránea al ítem de catálogo utilizado en este detalle.                |
// | ItemPresupuesto   | ItemPresupuesto     | Referencia al ítem de catálogo asociado.                                    |
// | Cantidad          | int                 | Cantidad de este ítem en el presupuesto.                                    |
// | PrecioUnitario    | decimal             | Precio unitario del ítem al momento de agregarlo al presupuesto.            |

#endregion
