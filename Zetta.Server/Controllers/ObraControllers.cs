using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;

namespace Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/obra")]
    public class ObraController : ControllerBase
    {
        private readonly Context _context;

        public ObraController(Context context)
        {
            _context = context;
        }

        // GET: api/Obra
        [HttpGet]
        public async Task<ActionResult<List<Obra>>> Get()
        {
            return await _context.Obras
                                //.Include(o => o.Cliente)
                                .Include(o => o.Presupuesto)
                                .ToListAsync();
        }

        // GET: api/Obra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Obra>> GetById(int id)
        {
            var obra = await _context.Obras
                                    //.Include(o => o.Cliente)
                                    .Include(o => o.Presupuesto)
                                    .FirstOrDefaultAsync(o => o.Id == id);

            if (obra == null)
            {
                return NotFound("Obra no encontrada.");
            }

            return obra;
        }

        // POST: api/Obra
        [HttpPost]
        public async Task<ActionResult<int>> Post(Obra obra)
        {
            try
            {
                _context.Obras.Add(obra);
                await _context.SaveChangesAsync();
                return obra.Id;
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la obra: {ex.Message}");
            }
        }

        // PUT: api/Obra/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Obra obra)
        {
            if (id != obra.Id)
                return BadRequest("ID no coincide.");

            var dbObra = await _context.Obras.FindAsync(id);
            if (dbObra == null)
                return NotFound("Obra no encontrada.");

            dbObra.Estado = obra.Estado;
            dbObra.PresupuestoId = obra.PresupuestoId;
            dbObra.FechaInicio = obra.FechaInicio;
            dbObra.Comentarios = obra.Comentarios;
           // dbObra.Cliente = obra.Cliente;

            try
            {
                _context.Obras.Update(dbObra);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar la obra: {ex.Message}");
            }
        }

        // DELETE: api/Obra/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var obra = await _context.Obras.FindAsync(id);
            if (obra == null)
                return NotFound("Obra no encontrada.");

            try
            {
                _context.Obras.Remove(obra);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar la obra: {ex.Message}");
            }
        }
    }
}
