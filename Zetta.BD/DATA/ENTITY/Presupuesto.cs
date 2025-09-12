using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zetta.BD.DATA.ENTITY
{
    public class Presupuesto : EntityBase
    {
        public Rubro Rubro { get; set; } // Categoría principal del presupuesto (ej: Gas, Electricidad).
        public bool Aceptado { get; set; } = false; // Estado de aceptación del presupuesto por el cliente.

        // PROPIEDAD CLAVE PARA LA RELACIÓN MUCHOS A MUCHOS
        // Representa la colección de ítems detallados que componen este presupuesto.
        // Cada PresupuestoItemDetalle contendrá la cantidad y el precio del ítem de catálogo.
        public List<PresItemDetalle> ItemsDetalle { get; set; } = new List<PresItemDetalle>();

        // Propiedad calculada para el subtotal de los ítems en el presupuesto.
        // Suma el resultado de (PrecioUnitario * Cantidad) de cada PresupuestoItemDetalle.
        [Precision(18, 2)] // Define la precisión y escala para el tipo decimal en la base de datos.
        public decimal Subtotal => ItemsDetalle?.Sum(i => (i.PrecioUnitario * i.Cantidad)) ?? 0;

        public string? Observacion { get; set; } // Notas o comentarios adicionales.

        [Precision(18, 2)]
        public decimal Total { get; set; } // Monto total final del presupuesto.

        [Precision(18, 2)]
        public decimal? ManodeObra { get; set; } // Costo estimado de mano de obra.

        [Precision(18, 2)]
        public decimal TotalP { get; set; } // Campo adicional para otro cálculo de total si es necesario.

        public string TiempoAproxObra { get; set; } // Tiempo estimado para la ejecución de la obra.

        public string ValidacionDias { get; set; } // Días de validez del presupuesto.

        public OpcionDePago OpcionDePago { get; set; } // Opción de pago seleccionada.

        // Añadir estas líneas para establecer la relación con Cliente
        public int ClienteId { get; set; } // Clave foránea para la relación con Cliente
        public Cliente Cliente { get; set; } = null!; // Propiedad de navegación

    }

    // Enumeración para las opciones de pago.
    public enum OpcionDePago
    {
        Contado,
        Tarjeta,
        MercadoPagoConLink
    }

    // Enumeración para los rubros.
    public enum Rubro
    {
        Gas,
        Electricidad,
        Refrigeracion,
        Solar,
        Plomeria
    }
}

#region Diccionario

/*18 es la precisión total (número máximo de dígitos, incluidos los enteros y los decimales).

2 es la escala (la cantidad de dígitos que van después del punto decimal).

// | Nombre           | Tipo                | Descripción                                                                 |
// |------------------|---------------------|-----------------------------------------------------------------------------|
// | Id               | int                 | Identificador único del presupuesto.                                        |
// | Rubro            | Rubro               | Categoría principal del presupuesto (ej: Gas, Electricidad, etc.).          |
// | Aceptado         | bool                | Indica si el presupuesto fue aceptado por el cliente.                       |
// | ItemsDetalle     | List<PresItemDetalle>| Lista de ítems detallados (cantidad y precio de cada ítem en el presupuesto).|
// | Subtotal         | decimal             | Suma de (PrecioUnitario * Cantidad) de todos los ítems del presupuesto.     |
// | Observacion      | string?             | Notas o comentarios adicionales.                                            |
// | Total            | decimal             | Monto total final del presupuesto.                                          |
// | ManodeObra       | decimal?            | Costo estimado de mano de obra.                                             |
// | TotalP           | decimal             | Campo adicional para otro cálculo de total si es necesario.                 |
// | TiempoAproxObra  | string              | Tiempo estimado para la ejecución de la obra.                               |
// | ValidacionDias   | string              | Días de validez del presupuesto.                                            |
// | OpcionDePago     | OpcionDePago        | Opción de pago seleccionada (Contado, Tarjeta, MercadoPagoConLink, etc.).   |

*/
#endregion