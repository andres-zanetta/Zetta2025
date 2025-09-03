using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SERVER.Repositorio;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;

namespace Zetta.Server.Controllers
{
    [ApiController]
    [Route("api/obra")]
    public class ObraController : ControllerBase
    {
        private readonly IObraRepositorio _obraRepositorio;
        private readonly Context _context; // Variable para el contexto

        public ObraController(IObraRepositorio repositorio, Context context) // Se inyecta el contexto
        {
            this._obraRepositorio = repositorio;
            this._context = context;
        }

        // Reemplaza el método Get para convertir el IEnumerable<Obra> en List<Obra>
        [HttpGet]
        public async Task<ActionResult<List<Obra>>> Get()
        {
            var obras = await _obraRepositorio.ObtenerObrasConDetallesAsync();
            return Ok(obras.ToList());
        }

        // GET: api/Obra/5
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Obra>> GetById(int id)
        {
            Obra? obra = await _obraRepositorio.ObtenerObraPorIdConDetallesAsync(id);
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
                // Se asume que el método correcto es AddAsync en el repositorio
                return await _obraRepositorio.AddAsync(obra);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la obra: {ex.Message}");
            }
        }

        // PUT: api/Obra/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Obra obra)
        {
            if (id != obra.Id)
            {
                return BadRequest("ID no coincide.");
            }

            // El método UpdateAsync se llama directamente sin asignar su resultado
            await _obraRepositorio.UpdateAsync(obra);

            try
            {
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
            // Llama directamente al método para eliminar
            await _obraRepositorio.DeleteAsync(id);

            return Ok("Obra eliminada correctamente.");
        }
    }
}