using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly Context _context;

        public ClienteController(Context context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await _context.Clientes
                                 .Include(c => c.Presupuestos) // Incluye presupuestos si querés traerlos también
                                 .ToListAsync();
        }

        // GET: api/clientes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var cliente = await _context.Clientes
                                        .Include(c => c.Presupuestos)
                                        .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound("Cliente no encontrado.");
            }
               

            return Ok(cliente);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<int>> Post(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente.Id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/clientes/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id)
                return BadRequest("El ID no coincide.");

            var dbCliente = await _context.Clientes.FindAsync(id);
            if (dbCliente == null)
                return NotFound("Cliente no encontrado.");

            // Actualiza los campos
            dbCliente.Nombre = cliente.Nombre;
            dbCliente.Apellido = cliente.Apellido;
            dbCliente.Direccion = cliente.Direccion;
            dbCliente.Localidad = cliente.Localidad;
            dbCliente.Telefono = cliente.Telefono;
            dbCliente.Email = cliente.Email;

            try
            {
                _context.Clientes.Update(dbCliente);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return NotFound("Cliente no encontrado.");

            try
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

#region Diccionario
//=========================================================================
// Nombre       | Tipo                         | Descripción
//==============|==============================|==============================================
// Id           | int                          | Identificador único del cliente.
// Nombre       | string?                      | Nombre del cliente. Opcional.
// Apellido     | string?                      | Apellido del cliente. Opcional.
// Direccion    | string?                      | Dirección del cliente. Opcional.
// Localidad    | string?                      | Localidad del cliente (ciudad o zona). Opcional.
// Telefono     | string                       | Teléfono de contacto del cliente. Obligatorio.
// Email        | string?                      | Correo electrónico del cliente. Opcional.
// Presupuestos | ICollection<Presupuesto>     | Lista de presupuestos asociados a este cliente.
//=========================================================================
#endregion

