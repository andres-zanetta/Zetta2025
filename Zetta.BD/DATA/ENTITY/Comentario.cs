using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Zetta.BD.DATA.ENTITY
{
    public class Comentario: EntityBase
    {
        public string Texto { get; set; } // Contenido del comentario

        public DateTime Fecha { get; set; } // Fecha y hora del comentario
    }
}
