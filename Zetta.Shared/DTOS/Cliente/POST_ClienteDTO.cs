using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zetta.Shared.DTOS.Cliente
{
    public class POST_ClienteDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Apellido { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Direccion { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Localidad { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Formato de teléfono inválido.")]
        public string Telefono { get; set; }

        [EmailAddress(ErrorMessage = "Formato de correo inválido.")]
        public string? Email { get; set; }
    }
}
