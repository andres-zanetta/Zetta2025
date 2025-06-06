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
        public string RubroObra { get; set; } // electricidad, gas, etc.
        public bool Aceptado { get; set; } = false;

        public string Item { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;

        [Precision(18, 2)]
        public decimal PrecioUnitario { get; set; }

        public string Observacion { get; set; }

        public int Cantidad { get; set; }

        [Precision(18, 2)]
        public decimal Total { get; set; }

        [Precision(18, 2)]
        public decimal ManodeObra { get; set; } = 0.00m;

        [Precision(18, 2)]
        public decimal MaterialesP { get; set; } = 0.00m;

        [Precision(18, 2)]
        public decimal TotalP { get; set; } = 0.00m;

        public string TiempoAproximadoDeObra { get; set; } = "0";

        public string ValidacionDias { get; set; } = "30";

        public enum OpcionDePago
        {
            Contado,
            Tarjeta,
            MercadoPagoConLink
        }
    }
}

#region Diccionario
/*18 es la precisión total (número máximo de dígitos, incluidos los enteros y los decimales).

2 es la escala (la cantidad de dígitos que van después del punto decimal).

*/
//| Nombre | Tipo | Descripción |
//| ---------------- | ---------- | -------------------------------------------- |
//| `Id`             | `int`      | Identificador único.                         |
//| `Aceptado`       | `bool`     | Indica si fue aprobado por el cliente.       |
//| `FechaInicioP`   | `DateTime` | Fecha de creación o validez del presupuesto. |
//| `FechaFinP`      | `DateTime` | Fecha límite para aceptación o finalización. |
//| `ValidacionDias` | `string`   | Días de validez del presupuesto.             |
//| `Observacion`    | `string`   | Notas internas o aclaraciones.               |
//| `MetodoPago`     | `enum`     | Tipo de pago: contado, transferencia o link. |
//| `Total`          | `decimal`  | Monto total del presupuesto.                 |
//| `ClienteId`      | `int`      | Relación con el cliente.                     |

#endregion
