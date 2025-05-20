using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zetta.BD.DATA.ENTITY
{
    public class Presupuesto:EntityBase
    {
        public bool Aceptado { get; set; } = false; /*esto es para saber si el presupuesto fue aceptado o no, por defecto es falso*/

        public string Item { get; set; }

        [Precision(18, 2)]
        public decimal PrecioUnitario { get; set; }

        public string Observacion { get; set; }

        public int Cantidad { get; set; }
        
        [Precision(18, 2)]
        public decimal Total { get; set; }

        public DateTime FechaInicioP { get; set; } = DateTime.Now; /*esto es para el inicio de la fecha actual del presupuesto*/

        public DateTime FechaFinP { get; set; } = DateTime.Now.AddDays(30); /*esto es para la fecha de fin del presupuesto, se le suma 30 dias a la fecha actual*/
    
        public string ValidacionDias { get; set; } = "30"; /*esto es para la validacion de los dias del presupuesto, se le suma 30 dias a la fecha actual*/

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
    #endregion
