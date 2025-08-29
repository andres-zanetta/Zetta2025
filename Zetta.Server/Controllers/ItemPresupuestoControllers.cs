using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zetta.BD.DATA;
using Zetta.BD.DATA.ENTITY;
using Zetta.Shared.DTOS.ItemPresupuesto;

namespace Zetta.SERVER.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemPresupuestoController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ItemPresupuestoController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ItemPresupuesto
        [HttpGet]
        public async Task<ActionResult<List<GET_ItemPresupuestoDTO>>> Get()
        {
            var items = await _context.ItemPresupuestos.ToListAsync();
            var itemsDTO = _mapper.Map<List<GET_ItemPresupuestoDTO>>(items);
            return Ok(itemsDTO);
        }

        // GET: api/ItemPresupuesto/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GET_ItemPresupuestoDTO>> GetById(int id)
        {
            var item = await _context.ItemPresupuestos.FindAsync(id);
            if (item == null)
            {
                return NotFound("No se encontró el ítem con ese ID.");
            }
            var itemDTO = _mapper.Map<GET_ItemPresupuestoDTO>(item);
            return Ok(itemDTO);
        }

        // POST: api/ItemPresupuesto
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] POST_ItemPresupuestoDTO dto)
        {
            try
            {
                var item = _mapper.Map<ItemPresupuesto>(dto);
                _context.ItemPresupuestos.Add(item);
                await _context.SaveChangesAsync();
                return Ok(item.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/ItemPresupuesto/{id}
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PUT_ItemPresupuestoDTO dto)
        {
            var item = await _context.ItemPresupuestos.FindAsync(id);
            if (item == null)
                return NotFound("No se encontró el ítem.");

            _mapper.Map(dto, item);

            try
            {
                _context.ItemPresupuestos.Update(item);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ItemPresupuesto/{id}
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.ItemPresupuestos.FindAsync(id);

            if (item == null)
                return NotFound("No se encontró el ítem con ese ID.");

            try
            {
                _context.ItemPresupuestos.Remove(item);
                await _context.SaveChangesAsync();
                return NoContent(); // Corregido: retorna 204 No Content
            }
            catch (Exception e)
            {
                return BadRequest($"Error al eliminar el ítem: {e.Message}");
            }
        }
    }
}